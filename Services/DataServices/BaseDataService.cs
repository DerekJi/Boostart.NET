using Core.Entities;
using Core.Services;
using Database.Entity;
using Database.Mssql;
using Database.Mssql.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public abstract class BaseDataService<TEntity> : BaseService, IBaseDataService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> localRepos;

        public BaseDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<TEntity> repos
            ) : base(httpContextAccessor)
        {
            localRepos = repos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindAll(bool active = true)
        {
            return localRepos.FindAll(active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindAllFast(bool active = true)
        {
            return localRepos.FindAllWithoutTracking(active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(int id, bool active = true)
        {
            return await localRepos.FindByIdAsync(id, active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdFastAsync(int id, bool active = true)
        {
            return await localRepos.FindByIdWithoutTrackingAsync(id, active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await localRepos.CreateAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, TEntity entity)
        {
            return await localRepos.UpdateAsync(id, entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> HardDeleteAsync(int id)
        {
            return await localRepos.RemoveAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await localRepos.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RestoreAsync(int id)
        {
            return await localRepos.UndeleteAsync(id);
        }
    }
}
