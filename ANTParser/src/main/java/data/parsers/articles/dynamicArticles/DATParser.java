package data.parsers.articles.dynamicArticles;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import java.io.IOException;
import java.util.stream.Collectors;

public abstract class DATParser {// Dynamic articles type (DAT)
    protected Document parseData(String url) {
        try {
            return Jsoup.connect(url).get();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseTitle(String url) {
        return parseData(url).getElementsByClass("t-feed__post-popup__title-wrapper").text();
    }
    public String parseContent(String url) {
        return parseData(url)
                .getElementsByClass("t_feed__post-popup__gallery-imgwrapper")
                .stream()
                .map(it -> it.children().attr("data-original").trim())
                .collect(Collectors.joining("\n"));
    }
    public String parseDate(String url) {
        return parseData(url).getElementsByClass("t-feed__post-popup__date-wrapper").text();
    }
    protected String parseDescription(String url, String clazzName) {
        return parseData(url).getElementsByClass(clazzName).text();
    }
}
