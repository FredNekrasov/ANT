import di.DaggerAppComponent;
import domain.models.Content;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var content = menu.parsers().articleParsers().staticArticleParsers().mainPageParser().parseContent();
        printer.println(content);
        var result = scanner.nextInt();
        if (result == 0) menu.contentCommands().upsertContent(new Content(1L, content, 0L));
        System.out.println("Hello, World!");
    }
}
