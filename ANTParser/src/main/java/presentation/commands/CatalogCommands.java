package presentation.commands;

import data.parsers.catalogs.CatalogParser;
import domain.useCases.CatalogUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;
import java.util.Scanner;

public class CatalogCommands {
    private final CatalogUseCases catalogUseCases;
    private final CatalogParser catalogParser;
    @Inject
    public CatalogCommands(CatalogUseCases catalogUseCases, CatalogParser catalogParser) {
        this.catalogUseCases = catalogUseCases;
        this.catalogParser = catalogParser;
    }
    private void getParsedCatalogs(PrintStream printer) {
        catalogParser.parseCatalogs().forEach(printer::println);
    }
    private void getRemoteCatalogs(PrintStream printer) {
        catalogUseCases.getCatalogs().forEach(it -> printer.println(it.id() + " " + it.name()));
    }
    private void upsertCatalog() {
        for (String name : catalogParser.parseCatalogs()) {
            var status = catalogUseCases.upsertCatalog(name);
            System.out.println(status.name());
        }
    }
    private void deleteCatalog(int id) {
        var status = catalogUseCases.deleteCatalog(id);
        System.out.println(status.name());
    }
    private void getCatalogById(int id, PrintStream printer) {
        var catalog = catalogUseCases.getCatalogById(id);
        printer.println(catalog.id() + " " + catalog.name());
    }
    public void catalogMenu(Scanner scanner, PrintStream printer) {
        var choice = -1;
        while (choice != 0) {
            choice = scanner.nextInt();
            switch (choice) {
                case 1 -> getParsedCatalogs(printer);
                case 2 -> getRemoteCatalogs(printer);
                case 3 -> upsertCatalog();
                case 4 -> {
                    System.out.println("Enter catalog id: ");
                    var id = scanner.nextInt();
                    deleteCatalog(id);
                }
                case 5 -> {
                    System.out.println("Enter catalog id: ");
                    var id = scanner.nextInt();
                    getCatalogById(id, printer);
                }
                default -> System.out.println("Invalid choice");
            }
        }
    }
}
