package domain.useCases.contents;

import jakarta.inject.Inject;

public record ContentUseCases(
    GetContentsUseCase getContents,
    DeleteContentUseCase deleteContent,
    UpsertContentUseCase insertContent
) {
    @Inject public ContentUseCases {}
}
