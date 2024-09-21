package data.parsers.articles;

import data.parsers.articles.dynamicArticles.DAP;
import data.parsers.articles.staticArticles.SAP;
import jakarta.inject.Inject;

public record ArticleParsers(
    DAP dynamicArticleParsers,
    SAP staticArticleParsers
) {
    @Inject public ArticleParsers {}
}
