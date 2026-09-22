namespace FirstApi.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(string id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(string id);
    }
}
