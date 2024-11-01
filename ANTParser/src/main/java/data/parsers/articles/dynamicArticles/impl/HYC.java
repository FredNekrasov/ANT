package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import domain.models.Article;
import domain.models.Catalog;
import jakarta.inject.Inject;

public final class HYC extends DATParser {// church History and Youth Club (HYC)
    @Inject public HYC() {}
    private String parseDescription(String url) {
        return super.parseDescription(url, "t-redactor__text");
    }
    @Override
    public Article getArticle(String url, Catalog catalog) {
        return new Article(catalog, parseTitle(url), parseDescription(url), parseDate(url), 0L);
    }
}
