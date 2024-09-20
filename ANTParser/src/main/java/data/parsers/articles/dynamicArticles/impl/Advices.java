package data.parsers.articles.dynamicArticles.impl;

import data.parsers.articles.dynamicArticles.DATParser;
import jakarta.inject.Inject;

public class Advices extends DATParser {
    @Inject public Advices() {}
    @Override
    public String parseContent(String url) {
        var element = super.parseData(url).getElementById("feed-cover");
        if (element == null) return "";
        return element.getElementsByTag("img").attr("src");
    }
    public String parseDescription(String url) {
        return super.parseDescription(url, "t-redactor__text");
    }
}
