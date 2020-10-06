using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataServices;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utilities.ActionFilters;
using Microsoft.Extensions.Logging;
using Database.Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User>
    {
        public UsersController(
            ILogger<ILogActionFilter> logger, 
            IUsersDataService usersDataService)
            : base(logger, usersDataService)
        {
        }

    }
}
