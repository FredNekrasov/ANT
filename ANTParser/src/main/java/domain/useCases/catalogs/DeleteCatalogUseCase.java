package domain.useCases.catalogs;

import domain.models.Catalog;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

public class DeleteCatalogUseCase {
    private final IRepository<Catalog> repository;
    @Inject
    public DeleteCatalogUseCase(IRepository<Catalog> repository) {
        this.repository = repository;
    }
    public ActionStatus invoke(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        if (repository.getById(id) == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
}
