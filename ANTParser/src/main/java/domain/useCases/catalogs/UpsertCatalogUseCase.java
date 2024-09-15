package domain.useCases.catalogs;

import domain.models.Catalog;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

public class UpsertCatalogUseCase {
    private final IRepository<Catalog> repository;
    @Inject
    public UpsertCatalogUseCase(IRepository<Catalog> repository) {
        this.repository = repository;
    }
    public ActionStatus invoke(String catalogName) {
        if (catalogName.isBlank()) return ActionStatus.FAILURE;
        var catalog = repository.getAll()
                .stream()
                .filter(it -> it.name().equalsIgnoreCase(catalogName))
                .findFirst()
                .orElse(null);
        if (catalog != null) return ActionStatus.ALREADY_EXISTS;
        repository.insert(new Catalog(catalogName, 0L));
        return ActionStatus.SUCCESS;
    }
}
