import di.DaggerAppComponent;

import java.io.PrintStream;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var menu = DaggerAppComponent.create().getMenu();
        Scanner scanner = new Scanner(System.in);
        PrintStream printer = new PrintStream(System.out, true, StandardCharsets.UTF_8);
        var choice = -1;
        while (choice != 0) {
            System.out.println("""
                    Меню:
                    * 1. Получить парсенные каталоги
                    * 2. Получить каталоги из удаленного хранилища
                    * 3. Создать/обновить каталог
                    * 4. Удалить каталог
                    * 5. Получить каталог по идентификатору
                    * 0. Выход
                    """);
            menu.catalogCommands().catalogMenu(scanner, printer);
            choice = scanner.nextInt();
        }
        System.out.println("Hello, World!");
    }
}
