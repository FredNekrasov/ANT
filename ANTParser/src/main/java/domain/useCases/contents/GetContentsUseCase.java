package domain.useCases.contents;

import domain.models.Content;
import domain.repository.IRepository;
import jakarta.inject.Inject;

import java.util.List;

public class GetContentsUseCase {
    private final IRepository<Content> repository;
    @Inject
    public GetContentsUseCase(IRepository<Content> repository) {
        this.repository = repository;
    } 
    public List<Content> invoke() {
        return repository.getAll();
    }
}
