package domain.useCases.articles;

import domain.models.Article;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

public class DeleteArticleUseCase {
    private final IRepository<Article> repository;
    @Inject
    public DeleteArticleUseCase(IRepository<Article> repository) {
        this.repository = repository;
    }
    public ActionStatus invoke(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        var article = repository.getById(id);
        if (article == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
}
