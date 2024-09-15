package domain.useCases.catalogs;

import jakarta.inject.Inject;

public record CatalogUseCases(
    UpsertCatalogUseCase upsertCatalogUseCase,
    DeleteCatalogUseCase deleteCatalogUseCase,
    GetCatalogsUseCase getCatalogsUseCase
) {
    @Inject public CatalogUseCases {}
}
