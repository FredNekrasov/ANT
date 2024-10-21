package data.parsers.articles;

import data.parsers.articles.dynamicArticles.DAP;
import data.parsers.articles.staticArticles.SAP;

public record ArticleParsers(
    DAP dynamicArticleParsers,
    SAP staticArticleParsers
) {}
