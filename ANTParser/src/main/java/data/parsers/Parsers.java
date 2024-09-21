package data.parsers;

import data.parsers.articles.ArticleParsers;
import data.parsers.catalogs.CatalogParser;
import jakarta.inject.Inject;

public record Parsers(
    CatalogParser catalogParser,
    ArticleParsers articleParsers
) {
    @Inject public Parsers {}
}
