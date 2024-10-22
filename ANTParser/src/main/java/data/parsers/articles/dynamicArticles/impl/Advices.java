package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import domain.models.Article;
import domain.models.Catalog;
import jakarta.inject.Inject;

public final class Advices extends DATParser {
    @Inject public Advices() {}
    @Override
    public String parseContent(String url) {
        var element = super.parseData(url).getElementById("feed-cover");
        if (element == null) return "";
        return element.getElementsByTag("img").attr("src");
    }
    private String parseDescription(String url) {
        return super.parseDescription(url, "t-redactor__text");
    }
    public Article getArticle(String url, Catalog catalog) {
        return new Article(catalog, parseTitle(url), parseDescription(url), parseDate(url), 0L);
    }
}
