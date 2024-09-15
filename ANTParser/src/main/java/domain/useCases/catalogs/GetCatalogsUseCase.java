package domain.useCases.catalogs;

import domain.models.Catalog;
import domain.repository.IRepository;
import jakarta.inject.Inject;

import java.util.List;

public class GetCatalogsUseCase {
    private final IRepository<Catalog> repository;
    @Inject
    public GetCatalogsUseCase(IRepository<Catalog> repository) {
        this.repository = repository;
    }
    public List<Catalog> invoke() {
        return repository.getAll();
    }
}
