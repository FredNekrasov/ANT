package presentation.commands;

import domain.models.Content;
import domain.useCases.ContentUseCases;
import jakarta.inject.Inject;

import java.io.PrintStream;

public class ContentCommands {
    private final ContentUseCases contentUseCases;
    @Inject
    public ContentCommands(ContentUseCases contentUseCases) {
        this.contentUseCases = contentUseCases;
    }
    public void printRemoteContentList(PrintStream printer) {
        contentUseCases.getContentList().forEach(printer::println);
    }
    public void upsertContent(Content content) {
        contentUseCases.upsertContent(content);
    }
    public void deleteContent(int id) {
        var status = contentUseCases.deleteContent(id);
        System.out.println(status.name());
    }
    public void getContentById(int id, PrintStream printer) {
        var content = contentUseCases.getContentById(id);
        printer.println(content.id() + " " + content.articleId() + " " + content.data());
    }
}
