package domain.useCases;

import domain.models.Article;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

import java.util.List;

public final class ArticleUseCases {
    private final IRepository<Article> repository;
    @Inject
    public ArticleUseCases(IRepository<Article> repository) {
        this.repository = repository;
    }
    public ActionStatus deleteArticle(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        var article = repository.getById(id);
        if (article == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
    public void upsertArticle(Article model) {
        if(model.id() > 0) {
            repository.update(model);
        } else repository.insert(model);
    }
    public List<Article> getArticles() {
        return repository.getAll();
    }
    public Article getArticleById(long id) {
        return repository.getById(id);
    }
}
