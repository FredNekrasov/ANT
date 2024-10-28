import di.DaggerAppComponent;
import domain.models.Catalog;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var article = menu.parsers().articleParsers().staticArticleParsers().mainPageParser().getArticle(new Catalog("Главная страница", 1L));
        printer.println(article);
        var result = scanner.nextInt();
        if (result == 0) menu.articleCommands().upsertArticle(article);
        System.out.println("Hello, World!");
    }
}
