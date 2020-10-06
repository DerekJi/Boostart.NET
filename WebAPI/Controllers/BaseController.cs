using WebAPI.Utilities.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DataServices;
using Core.Entities;

namespace WebAPI.Controllers
{
    [TypeFilter(typeof(NLogActionFilter))]
    [TypeFilter(typeof(AuthActionFilter))]
    public abstract class BaseController<TEntity> : Controller
        where TEntity: BaseEntity
    {
        protected readonly ILogger<ILogActionFilter> _logger;
        protected readonly IBaseDataService<TEntity> _ds;

        public BaseController(
            ILogger<ILogActionFilter> logger,
            IBaseDataService<TEntity> ds
            )
        {
            _logger = logger;
            _ds = ds;
        }


        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<TEntity>> FindAll()
        {
            var items = _ds.FindAll();
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(int id)
        {
            var item = _ds.FindByIdFastAsync(id);
            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TEntity model)
        {
            var result = _ds.CreateAsync(model);
            return Ok(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TEntity model)
        {
            var result = _ds.UpdateAsync(id, model);
            return Ok(model);
        }

        // DELETE: soft delete api/TEntitys/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _ds.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}