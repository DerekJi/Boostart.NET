using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utilities.ActionFilters
{
    public interface ILogActionFilter : IActionFilter, IResultFilter
    {
    }
}
