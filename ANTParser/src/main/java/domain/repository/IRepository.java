package domain.repository;

import java.util.List;

public interface IRepository<M> {
    List<M> getAll();
    void insert(M model);
    void update(M model);
    void delete(long id);
    M getById(long id);
}
