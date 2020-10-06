using WebAPI.Utilities.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [TypeFilter(typeof(NLogActionFilter))]
    [TypeFilter(typeof(AuthActionFilter))]
    public abstract class BaseController : Controller
    {
        protected readonly ILogger<ILogActionFilter> _logger;

        public BaseController(
            ILogger<ILogActionFilter> logger
            )
        {
            _logger = logger;
        }
    }
}