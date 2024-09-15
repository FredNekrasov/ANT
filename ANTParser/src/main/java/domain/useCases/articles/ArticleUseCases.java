package domain.useCases.articles;

import jakarta.inject.Inject;

public record ArticleUseCases(
    GetArticlesUseCase getArticlesUseCase,
    UpsertArticleUseCase upsertArticleUseCase,
    DeleteArticleUseCase deleteArticleUseCase
) {
    @Inject public ArticleUseCases {}
}
