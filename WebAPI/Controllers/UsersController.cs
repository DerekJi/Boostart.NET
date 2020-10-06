using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly IUsersDataService localUsersDataService;
        public UsersController(IUsersDataService vendorsDataService)
        {
            localUsersDataService = vendorsDataService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult FindAll()
        {
            var vendors = localUsersDataService.FindAll();
            return Ok(vendors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
