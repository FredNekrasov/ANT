package presentation.commands;

import domain.models.Content;
import domain.useCases.ContentUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;

public class ContentCommands {
    private final ContentUseCases contentUseCases;
    private final PrintStream printer; 
    @Inject
    public ContentCommands(ContentUseCases contentUseCases, PrintStream printStream) {
        this.contentUseCases = contentUseCases;
        this.printer = printStream;
    }
    public void printRemoteContentList() {
        contentUseCases.getContentList().forEach(printer::println);
    }
    public void upsertContent(Content content) {
        contentUseCases.upsertContent(content);
    }
    public void deleteContent(int id) {
        var status = contentUseCases.deleteContent(id);
        printer.println(status.name());
    }
    public void getContentById(int id) {
        var content = contentUseCases.getContentById(id);
        printer.println(content.id() + " " + content.articleId() + " " + content.data());
    }
}
