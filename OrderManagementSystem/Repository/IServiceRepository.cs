namespace OrderManagementSystem.Repository
{
    public interface IServiceRepository<TEntity, in TPk> where TEntity : class
    {
        ResponseStatus<TEntity> GetRecords();
        ResponseStatus<TEntity> GetRecord(int id);
        ResponseStatus<TEntity> UpdateRecord(int id, TEntity entity);
        ResponseStatus<TEntity> DeleteRecord(int id);
        ResponseStatus<TEntity> CreateRecord(TEntity entity);
    }
}
