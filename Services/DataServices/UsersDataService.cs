using Core.Services;
using Database.Entity;
using Database.Mssql;
using Database.Mssql.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DataServices
{
    public class UsersDataService : BaseService, IUsersDataService
    {
        protected readonly IBaseRepository<User> localUserRepos;

        public UsersDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<User> userRepos
            ) : base(httpContextAccessor)
        {
            localUserRepos = userRepos;
        }

        public IQueryable<User> FindAll(bool active = true)
        {
            return localUserRepos.FindAll(active);
        }
    }
}
