package presentation.commands;

import domain.models.Article;
import domain.useCases.ArticleUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;

public class ArticleCommands {
    private final ArticleUseCases articleUseCases;
    private final PrintStream printer;
    @Inject
    public ArticleCommands(ArticleUseCases articleUseCases, PrintStream printer) {
        this.articleUseCases = articleUseCases;
        this.printer = printer;
    }
    public void printRemoteArticles() {
        articleUseCases.getArticles().forEach(printer::println);
    }
    public void upsertArticle(Article article) {
        articleUseCases.upsertArticle(article);
    }
    public void deleteArticle(int id) {
        var status = articleUseCases.deleteArticle(id);
        printer.println(status.name());
    }
    public void getArticleById(int id) {
        var article = articleUseCases.getArticleById(id);
        printer.println(article.id() + " " + article.title());
    }
}
