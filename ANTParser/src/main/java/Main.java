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
        var parser = menu.parsers().dynamicArticleParsers().PAS();
        var aid = 206L;
        var choice = -1;
        var image = "";
        while (choice != 0) {
            System.out.println("Enter url: ");
            var url = scanner.next();
            var article = parser.getArticle(url, new Catalog("Рассказы", 13L));
            printer.println(article);
            var content = parser.parseContent(url);
            System.out.println(content);
            choice = scanner.nextInt();
            if (choice == 9) {
                System.out.println("Enter image url: ");
                image = scanner.next();
            }
            menu.articleCommands().upsertArticle(article);
            if (image.isBlank()) menu.contentCommands().upsertContent(new Content(aid, content, 0L));
            else menu.contentCommands().upsertContent(new Content(aid, image, 0L));
            aid++;
            image = "";
        }
        System.out.println("Hello, World!");
    }
}
