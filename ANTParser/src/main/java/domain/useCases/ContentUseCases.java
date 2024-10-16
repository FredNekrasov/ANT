package domain.useCases;

import domain.models.Content;
import domain.repository.IRepository;
import domain.utils.ActionStatus;
import jakarta.inject.Inject;

import java.util.List;

public final class ContentUseCases {
    private final IRepository<Content> repository;
    @Inject
    public ContentUseCases(IRepository<Content> repository) {
        this.repository = repository;
    }
    public ActionStatus deleteContent(long id) {
        if (id <= 0) return ActionStatus.FAILURE;
        if (repository.getById(id) == null) return ActionStatus.NOT_FOUND;
        repository.delete(id);
        return ActionStatus.SUCCESS;
    }
    public void upsertContent(Content content) {
        if (content.id() > 0) {
            repository.update(content);
        } else repository.insert(content);
    }
    public List<Content> getContentList() {
        return repository.getAll();
    }
    public Content getContentById(long id) {
        return repository.getById(id);
    }
}
