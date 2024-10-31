import di.DaggerAppComponent;
import domain.models.*;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var parser = menu.parsers().articleParsers().staticArticleParsers().contactParser();
        var article = parser.getArticle(new Catalog("Контакты", 10L));
        var content = parser.parseContacts();
        printer.println(article);
        for (var c : content) printer.println("|" + c + "|");
        var isCorrect = scanner.next();
        if (isCorrect.contentEquals("0")) return;
        menu.articleCommands().upsertArticle(article);
        for (var c : content) menu.contentCommands().upsertContent(new Content(204L, c, 0L));
        System.out.println("Hello, World!");
    }
}
