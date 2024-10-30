package data.parsers.articles.staticArticles.impl;

import domain.models.Article;
import domain.models.Catalog;
import jakarta.inject.Inject;
import org.jsoup.Jsoup;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.Collection;
import java.util.stream.Collectors;

public final class ScheduleParser {
    @Inject public ScheduleParser() {}
    private Elements parseElements(String clazzName) {
        try {
            return Jsoup.connect("https://hramalnevskogo.ru/page40966859.html")
                    .get()
                    .getElementsByClass(clazzName);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseIf1Content() {
        return parseElements("t-align_center")
                .stream()
                .map(it -> it.children().attr("data-original"))
                .collect(Collectors.joining("\n"));
    }
    public String parseIf2Content() {
        return parseElements("t156__wrapper")
                .stream()
                .map(it -> it.getElementsByClass("t156__item"))
                .flatMap(Collection::stream)
                .map(it -> it.children().attr("data-original").trim())
                .collect(Collectors.joining("\n"));
    }
}
