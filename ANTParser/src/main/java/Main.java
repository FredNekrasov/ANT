import di.DaggerAppComponent;
import domain.models.Article;
import domain.models.Catalog;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var scheduleParser = menu.parsers().articleParsers().staticArticleParsers().scheduleParser();
		var article = new Article(new Catalog("Расписание Богослужений", 3L), scheduleParser.parseIf2Content().split("\n")[0], scheduleParser.parseIf2Content().split("\n")[1], "", 0L);
        printer.println(article);
        var txt = scanner.nextLine();
        if (txt.isBlank()) menu.articleCommands().upsertArticle(article);
        System.out.println("Hello, World!");
    }
}
