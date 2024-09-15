package domain.useCases.contents;

import domain.models.Content;
import domain.repository.IRepository;
import jakarta.inject.Inject;

public class UpsertContentUseCase {
    private final IRepository<Content> repository;
    @Inject
    public UpsertContentUseCase(IRepository<Content> repository) {
        this.repository = repository;
    } 
    public void invoke(Content content) {
        if (content.id() > 0) {
            repository.update(content);
        } else repository.insert(content);
    }
}
