using Core.Entities;
using Core.Services;
using Database.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public interface IBaseDataService<TEntity> : IBaseService
        where TEntity: BaseEntity
    {
        IQueryable<TEntity> FindAll(bool active = true);

        IQueryable<TEntity> FindAllFast(bool active = true);

        Task<TEntity> FindByIdAsync(int id, bool active = true);

        Task<TEntity> FindByIdFastAsync(int id, bool active = true);

        Task<bool> CreateAsync(TEntity entity);

        Task<bool> UpdateAsync(int id, TEntity entity);

        Task<bool> HardDeleteAsync(int id);

        Task<bool> SoftDeleteAsync(int id);

        Task<bool> RestoreAsync(int id);
    }
}
