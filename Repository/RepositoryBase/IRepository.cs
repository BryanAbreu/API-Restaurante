using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.RepositoryBase
{
    interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        
    }
}
