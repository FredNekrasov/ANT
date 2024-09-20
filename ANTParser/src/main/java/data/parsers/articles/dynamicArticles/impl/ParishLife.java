package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import jakarta.inject.Inject;

public class ParishLife extends DATParser {
    @Inject public ParishLife() {}
    public String parseDescription(String url) {
        return super.parseDescription(url, "t-feed__post-popup__text-wrapper");
    }
}
