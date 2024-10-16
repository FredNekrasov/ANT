package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import jakarta.inject.Inject;

public final class History extends DATParser {
    @Inject public History() {}
    public String parseDescription(String url) {
        return super.parseDescription(url, "t-redactor__text");
    }
}
