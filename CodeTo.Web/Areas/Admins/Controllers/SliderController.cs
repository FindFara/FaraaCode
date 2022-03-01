using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    public class SliderController : ArticleBaseController
    {
        [Route("Sliders")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
