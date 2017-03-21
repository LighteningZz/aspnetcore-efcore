using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspnetcore_efcore.Models.Api.Branch;

namespace aspnetcore_efcore.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Branch")]
    public class BranchController : Controller
    {
        [HttpPost("List")]
        public IActionResult List(Field.Filter param, int skip = 0, int take = 0, string sortby = null)
        {
            return Json(new Data().List(param, skip, take, sortby));
        }
    }
}