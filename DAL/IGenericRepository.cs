using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class, IWithId
    {
        Task<IReadOnlyList<TEntity>> GetEntitiesAsync();
        Task<TEntity> LoadEntityAsync(int id);

        Task SaveEntityAsync(TEntity entity);
        Task<TEntity> CreateNewEntityAsync(TEntity entity);
        Task HardDeleteEntity(int id);
    }
}