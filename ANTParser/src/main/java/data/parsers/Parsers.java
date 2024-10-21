package data.parsers;

import data.parsers.articles.ArticleParsers;
import data.parsers.catalogs.CatalogParser;

public record Parsers(
    CatalogParser catalogParser,
    ArticleParsers articleParsers
) {}
