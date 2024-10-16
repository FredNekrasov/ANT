package data.parsers.articles.staticArticles.impl;

import jakarta.inject.Inject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public final class ContactParser {
    @Inject public ContactParser() {}
    private Document parseData() {
        try {
            return Jsoup.connect("https://hramalnevskogo.ru/page42046286.html").get();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public String parseTitle() {
        var listOfPageData = parseData()
                .getElementsByClass("t555__contentwrapper")
                .html()
                .split("<[\\w>\\s=\"-:;!@]*");
        return Arrays.stream(listOfPageData)
                .filter(it -> !it.isBlank())
                .limit(2)
                .map(String::trim)
                .collect(Collectors.joining(" "));
    }

    public List<String> parseContacts() {
        return parseData()
                .getElementsByClass("t451__rightside t451__side t451__side_socials")
                .stream()
                .map(it -> it.getElementsByTag("a"))
                .flatMap(Collection::stream)
                .map(it -> it.attr("href").trim()).toList();
    }
}
