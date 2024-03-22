using Registration.DataAccess;

namespace Registration.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T register);
    }
}
