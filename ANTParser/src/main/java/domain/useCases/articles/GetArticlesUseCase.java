package domain.useCases.articles;

import domain.models.Article;
import domain.repository.IRepository;
import jakarta.inject.Inject;

import java.util.List;

public class GetArticlesUseCase {
    private final IRepository<Article> repository;
    @Inject
    public GetArticlesUseCase(IRepository<Article> repository) {
        this.repository = repository;
    }
    public List<Article> invoke() {
        return repository.getAll();
    }
}
