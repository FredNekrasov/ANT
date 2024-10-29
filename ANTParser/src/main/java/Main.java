import di.DaggerAppComponent;
import domain.models.Catalog;
import domain.models.Content;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
		var choice = -1;
		var id = 2L;
		var image = "";
		while (choice != 0) {
			System.out.println("Enter the url");
			var url = scanner.next();
			var article = menu.parsers().articleParsers().dynamicArticleParsers().parishLife().getArticle(url, new Catalog("Приходская жизнь", 2L));
			printer.println(article);
			var content = menu.parsers().articleParsers().dynamicArticleParsers().parishLife().parseContent(url).split("\n");
			for (int i = 0; i < content.length; i ++) printer.println(i + "|" + content[i] + "|");
			System.out.println("enter your choice");
			choice = scanner.nextInt();
			if (choice == 9) {
				System.out.println("enter an image url");
				image = scanner.next();
			}
			menu.articleCommands().upsertArticle(article);
			if (image.isBlank()) {
				for (var c : content) menu.contentCommands().upsertContent(new Content(id, c, 0L));
			} else menu.contentCommands().upsertContent(new Content(id, image, 0L));
			image = "";
			id++;
		}
        System.out.println("Hello, World!");
    }
}
