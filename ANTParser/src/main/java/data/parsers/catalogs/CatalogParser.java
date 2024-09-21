package data.parsers.catalogs;

import jakarta.inject.Inject;
import org.jsoup.Jsoup;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

public class CatalogParser {
    @Inject public CatalogParser() {}
    public List<String> parseCatalogs() {
        try {
            var extractedData = Jsoup.connect("https://hramalnevskogo.ru/").get()
                    .getElementsByClass("t451m__list_item")
                    .html()
                    .replaceAll("<a[\\w\\s-.\"=/>]*", "");
            return Arrays.stream(extractedData.split("</a>")).map(it -> it.replaceAll("\n", "")).toList();
        } catch (IOException e) {
            System.out.println(e.getLocalizedMessage());
            throw new RuntimeException(e);
        }
    }
}