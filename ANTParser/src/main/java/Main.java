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
        var parser = menu.parsers().articleParsers().staticArticleParsers().priesthoodParser();
        var article = parser.getArticle(new Catalog("Священство", 6L));
        printer.println(article);
        var content = parser.parseContent();
        System.out.println("|" + content + "|");
        var choice = scanner.nextInt();
        if (choice == 1) return;
        menu.articleCommands().upsertArticle(article);
        menu.contentCommands().upsertContent(new Content(113L, content, 0L));
        System.out.println("Hello, World!");
    }
}
