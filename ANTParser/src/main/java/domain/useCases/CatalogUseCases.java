package domain.useCases;

import domain.models.Catalog;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

import java.util.List;

public final class CatalogUseCases {
    private final IRepository<Catalog> repository;
    @Inject
    public CatalogUseCases(IRepository<Catalog> repository) {
        this.repository = repository;
    }
    public ActionStatus deleteCatalog(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        if (repository.getById(id) == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
    public ActionStatus upsertCatalog(String catalogName) {
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
    public List<Catalog> getCatalogs() {
        return repository.getAll();
    }
    public Catalog getCatalogById(long id) {
        return repository.getById(id);
    }
}
