package data.parsers;

import data.parsers.articles.dynamicArticles.DAP;
import data.parsers.articles.staticArticles.SAP;
import data.parsers.catalogs.CatalogParser;

public record Parsers(
    CatalogParser catalogParser,
	DAP dynamicArticleParsers,
	SAP staticArticleParsers
) {}
