package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import domain.models.Article;
import domain.models.Catalog;
import jakarta.inject.Inject;

public final class ParishLife extends DATParser {
    @Inject public ParishLife() {}
    private String parseDescription(String url) {
        return super.parseDescription(url, "t-feed__post-popup__text-wrapper");
    }
    @Override
    public Article getArticle(String url, Catalog catalog) {
        return new Article(catalog, parseTitle(url), parseDescription(url), parseDate(url), 0L);
    }
}
