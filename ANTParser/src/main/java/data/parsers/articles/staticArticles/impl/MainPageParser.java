package data.parsers.articles.staticArticles.impl;

import jakarta.inject.Inject;
import org.jsoup.Jsoup;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public final class MainPageParser {
    @Inject public MainPageParser() {}
    private Elements parseData() {
        try {
            return Jsoup.connect("https://hramalnevskogo.ru/")
                    .get()
                    .getElementsByClass("tn-atom");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseBanner() {
        return parseData().stream()
                .map(it -> it.wholeOwnText().replaceAll("\\s+", " ").trim())
                .limit(2)
                .collect(Collectors.joining(" "));
    }
    private List<String> parseText() {
        return Arrays.stream(parseData().html()
                .replaceAll("</?\\w*>", "\n")
                .replaceAll("\\s\\s+", "\n")
                .split("\n"))
                .filter(it -> !it.isEmpty())
                .skip(8)
                .toList();
    }
    public String parseTitle() {
        return parseText().getFirst();
    }
    public String parseDescription() {
        return parseText().stream()
                .skip(1)
                .collect(Collectors.joining("\n"));
    }
    public String parseContent() {
        return parseData().stream()
                .map(it -> it.children().attr("data-original"))
                .collect(Collectors.joining(""));
    }
}