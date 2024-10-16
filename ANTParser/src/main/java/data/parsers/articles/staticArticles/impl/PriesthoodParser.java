package data.parsers.articles.staticArticles.impl;

import jakarta.inject.Inject;
import org.jsoup.Jsoup;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.Arrays;
import java.util.stream.Collectors;

public final class PriesthoodParser {
    @Inject public PriesthoodParser() {}
    private Elements parseData() {
        try {
            return Jsoup.connect("https://hramalnevskogo.ru/page40988065.html")
                    .get()
                    .getElementsByClass("tn-atom");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseTitle() {
        return parseData().stream()
                .map(it -> it.children().tagName("strong").html().trim())
                .filter(it -> !it.isBlank())
                .collect(Collectors.joining(""));
    }
    public String parseContent() {
        return parseData().stream()
                .map(it -> it.children().attr("data-original").trim())
                .filter(it -> !it.isBlank())
                .collect(Collectors.joining(""));
    }
    public String parseDescription() {
        var extractedData = parseData().stream()
                .map(it -> it.wholeOwnText().trim())
                .collect(Collectors.joining("\n"))
                .split("\n");
        return Arrays.stream(extractedData)
                .map(String::trim)
                .filter(it -> !it.isBlank())
                .collect(Collectors.joining("\n"));
    }
}
