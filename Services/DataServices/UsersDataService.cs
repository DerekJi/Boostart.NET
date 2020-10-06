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
    public class UsersDataService : BaseDataService<User>, IUsersDataService
    {
        public UsersDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<User> repos
            ) : base(httpContextAccessor, repos)
        {
        }
    }
}
