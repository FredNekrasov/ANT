package domain.useCases.contents;

import domain.models.Content;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

public class DeleteContentUseCase {
    private final IRepository<Content> repository;
    @Inject
    public DeleteContentUseCase(IRepository<Content> repository) {
        this.repository = repository;
    } 
    public ActionStatus invoke(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        if (repository.getById(id) == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
}
