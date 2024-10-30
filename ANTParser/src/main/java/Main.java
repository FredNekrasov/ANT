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
        var parser = menu.parsers().articleParsers().dynamicArticleParsers().youthClub();
        var choice = -1;
        var id = 99L;
        while (choice != 0) {
            System.out.println("Enter the url");
            var url = scanner.next();
            var article = parser.getArticle(url, new Catalog("Молодежный клуб", 5L));
            printer.println(article);
            var content = parser.parseContent(url).split("\n");
            for (int i = 0; i < content.length; i++) printer.println(i + "|" + content[i] + "|");
            System.out.println("enter your choice");
            choice = scanner.nextInt();
            if (choice == 9) break;
            menu.articleCommands().upsertArticle(article);
            for (var c : content) menu.contentCommands().upsertContent(new Content(id, c, 0L));
            id++;
        }
        System.out.println("Hello, World!");
    }
}
