package data.parsers.articles.staticArticles.impl;

import domain.models.Article;
import domain.models.Catalog;
import jakarta.inject.Inject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public final class VolunteerismParser {
    @Inject public VolunteerismParser() {}
    private Document parseData() {
        try {
            return Jsoup.connect("https://hramalnevskogo.ru/page45347187.html").get();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    private String[] parseText() {
        var data = parseData().getElementsByClass("t-container")
                .stream()
                .map(it -> it.children().html())
                .limit(1)
                .collect(Collectors.joining());
        return Arrays.stream(data.split("^[<\\w\\s=\"-:>;]*"))
                .map(String::trim)
                .collect(Collectors.joining("\n"))
                .split("<[\\w>\\s=\"-:;]*");
    }
    private String parseTitle() {
        return Arrays.stream(parseText()).filter(it -> !it.isEmpty()).toList().getFirst().trim();
    }
    public List<String> parseContent() {
        return parseData().getElementsByClass("t156__wrapper")
                .stream()
                .map(it -> it.getElementsByClass("t156__item"))
                .flatMap(Collection::stream)
                .map(it -> it.children().attr("data-original"))
                .toList();
    }
    private String parseDescription() {
        return Arrays.stream(parseText())
                .map(String::trim)
                .skip(1)
                .filter(it -> !it.isBlank())
                .collect(Collectors.joining("\n"));
    }
    public Article getArticle(Catalog catalog) {
        return new Article(catalog, parseTitle(), parseDescription(), "", 0L);
    }
}
