package presentation.commands;

import domain.models.Article;
import domain.useCases.ArticleUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;

public class ArticleCommands {
    private final ArticleUseCases articleUseCases;
    @Inject
    public ArticleCommands(ArticleUseCases articleUseCases) {
        this.articleUseCases = articleUseCases;
    }
    public void printRemoteArticles(PrintStream printer) {
        articleUseCases.getArticles().forEach(printer::println);
    }
    public void upsertArticle(Article article) {
        articleUseCases.upsertArticle(article);
    }
    public void deleteArticle(int id) {
        var status = articleUseCases.deleteArticle(id);
        System.out.println(status.name());
    }
    public void getArticleById(int id, PrintStream printer) {
        var article = articleUseCases.getArticleById(id);
        printer.println(article.catalog().id() + " " + article.catalog().name() + "\t | " + article.id() + " " + article.title() + " " + article.description() + " " + article.dateOrBanner());
    }
}
