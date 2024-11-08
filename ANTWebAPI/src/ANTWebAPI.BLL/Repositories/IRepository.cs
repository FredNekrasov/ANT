namespace ANTWebAPI.BLL.Repositories;

/*
 * IRepository is a repository interface that provides methods for working with entities in the database
 */
public interface IRepository<M>
{
    /*
     * InsertAsync inserts a new entity in the database
     * 
     * @param model - the entity to be inserted
     * 
     * @returns nothing
     */
    Task InsertAsync(M model);
    /*
     * DeleteAsync deletes an entity from the database by its id
     * 
     * @param id - the id of the entity to be deleted
     * 
     * @returns boolean - true if the entity was deleted, false otherwise
     */
    Task<bool> DeleteAsync(long id);
    /*
     * GetListAsync returns a list of all entities in the database
     * 
     * @returns List<M> - the list of all entities
     */
    Task<List<M>> GetListAsync();
    /*
     * GetModelAsync returns an entity from the database by its id
     * 
     * @param id - the id of the entity to be returned
     * 
     * @returns M? - the entity or null if not found
     */
    Task<M?> GetModelAsync(long id);
    /*
     * UpdateAsync updates an entity in the database
     * 
     * @param model - the entity to be updated
     * 
     * @returns boolean - true if the entity was updated, false otherwise
     */
    Task<bool> UpdateAsync(M model);
    /*
     * IsEntityExistsAsync checks if an entity exists in the database by its id
     * 
     * @param id - the id of the entity
     * 
     * @returns boolean - true if the entity exists, false otherwise
     */
    Task<bool> IsEntityExistsAsync(long id);
}
