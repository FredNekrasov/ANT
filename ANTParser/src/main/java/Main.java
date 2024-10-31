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
        var parser = menu.parsers().articleParsers().dynamicArticleParsers().advice();
        var choice = -1;
        var id = 114L;
        var image = "";
        while (choice != 0) {
            System.out.println("Enter the url");
            var url = scanner.next();
            var article = parser.getArticle(url, new Catalog("Советы священника", 7L));
            printer.println(article);
            var content = parser.parseContent(url);
            printer.println("|" + content + "|");
            System.out.println("enter your choice");
            choice = scanner.nextInt();
            if (choice == 9) {
                System.out.println("enter an image url");
                image = scanner.next();
            }
            menu.articleCommands().upsertArticle(article);
            if (image.isBlank()) {
                menu.contentCommands().upsertContent(new Content(id, content, 0L));
            } else menu.contentCommands().upsertContent(new Content(id, image, 0L));
            id++;
            image = "";
        }
        System.out.println("Hello, World!");
    }
}
