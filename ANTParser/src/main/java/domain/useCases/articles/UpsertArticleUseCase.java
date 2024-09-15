package domain.useCases.articles;

import domain.models.Article;
import domain.repository.IRepository;
import jakarta.inject.Inject;

public class UpsertArticleUseCase {
    private final IRepository<Article> repository;
    @Inject
    public UpsertArticleUseCase(IRepository<Article> repository) {
        this.repository = repository;
    }
    public void invoke(Article model) {
        if(model.id() > 0) {
            repository.update(model);
        } else repository.insert(model);
    }
}
