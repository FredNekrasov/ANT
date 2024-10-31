import di.DaggerAppComponent;
import domain.models.*;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var parser = menu.parsers().articleParsers().staticArticleParsers().sacramentParser();
        var article = parser.getArticle(new Catalog("Требы", 9L));
        printer.println(article);
        menu.articleCommands().upsertArticle(article);
        System.out.println("Hello, World!");
    }
}
