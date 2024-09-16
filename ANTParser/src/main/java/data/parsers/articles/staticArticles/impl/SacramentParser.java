package data.parsers.articles.staticArticles.impl;

import jakarta.inject.Inject;
import org.jsoup.Jsoup;

import java.io.IOException;
import java.util.Arrays;
import java.util.stream.Collectors;

public class SacramentParser {
    @Inject public SacramentParser() {}
    private String[] parseData() {
        try {
            return Arrays.stream(Jsoup.connect("https://hramalnevskogo.ru/page41138104.html")
                    .get()
                    .getElementsByClass("t001__wrapper")
                    .html()
                    .split("<[\\w>\\s=\"-:;]*"))
                    .filter(it -> !it.isBlank())
                    .collect(Collectors.joining("\n"))
                    .split("\\s\\s+");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseTitle() {
        var title = Arrays.stream(parseData())
                .limit(1)
                .collect(Collectors.joining("\n"))
                .split("^\\s");
        return String.join("", title).trim();
    }
    public String parseDescription() {
        return Arrays.stream(parseData())
                .skip(1)
                .map(it -> it.replace("&nbsp;&nbsp;", ""))
                .collect(Collectors.joining("\n"));
    }
}
