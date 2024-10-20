package presentation.commands;

import data.parsers.catalogs.CatalogParser;
import domain.useCases.CatalogUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;

public class CatalogCommands {
    private final CatalogUseCases catalogUseCases;
    private final CatalogParser catalogParser;
    private final PrintStream printer;
    @Inject
    public CatalogCommands(CatalogUseCases catalogUseCases, CatalogParser catalogParser, PrintStream printStream) {
        this.catalogUseCases = catalogUseCases;
        this.catalogParser = catalogParser;
        this.printer = printStream;
    }
    public void getParsedCatalogs() {
        catalogParser.parseCatalogs().forEach(printer::println);
    }
    public void getRemoteCatalogs() {
        catalogUseCases.getCatalogs().forEach(it -> printer.println(it.id() + " " + it.name()));
    }
    public void upsertCatalog(String name) {
        var status = catalogUseCases.upsertCatalog(name);
        printer.println(status.name());
    }
    public void deleteCatalog(int id) {
        var status = catalogUseCases.deleteCatalog(id);
        printer.println(status.name());
    }
    public void getCatalogById(int id) {
        var catalog = catalogUseCases.getCatalogById(id);
        printer.println(catalog.id() + " " + catalog.name());
    }
}
