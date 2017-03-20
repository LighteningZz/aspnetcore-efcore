using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcore_efcore.Models.Api.Corp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnetcore_efcore.Controllers.Api
{
    [Route("api/[controller]")]
    public class CorpController : Controller
    {
        [HttpGet("{ID}")]
        public IActionResult Get(string ID)
        {
            return Json(new Data().Get(ID));
        }

        [HttpPost("Add")]
        public IActionResult Post(Field.Corp param)
        {
            return Json(new Data().Add(param));
        }

        [HttpPost("Update")]
        public IActionResult Update(Field.Corp param)
        {
            return Json(new Data().Update(param));
        }

        [HttpPost("List")]
        public IActionResult List()
        {
            return Json(new Data().List());
        }

    }
}
