using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.Articles.Controllers
{
    [Area("Articles")]
    [Route("AR")]
    //Todo Put Authorize attribut for this controller and its chileds
    public class ArticleBaseController : Controller { }
}
