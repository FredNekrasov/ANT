package di;

import dagger.Binds;
import dagger.Module;
import data.repositories.*;
import domain.models.*;
import domain.repository.IRepository;

@Module
public interface RepositoryBinder {
    @Binds
    IRepository<Catalog> bindCatalogRepository(CatalogRepository catalogRepository);
    @Binds
    IRepository<Content> bindContentRepository(ContentRepository contentRepository);
    @Binds
    IRepository<Article> bindArticleRepository(ArticleRepository articleRepository);
}
