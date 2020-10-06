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
    public class UsersController : BaseController
    {
        protected readonly IUsersDataService localUsersDataService;
        public UsersController(
            ILogger<ILogActionFilter> logger, 
            IUsersDataService usersDataService)
            : base(logger)
        {
            localUsersDataService = usersDataService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult FindAll()
        {
            var items = localUsersDataService.FindAll();
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User payload)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User payload)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
