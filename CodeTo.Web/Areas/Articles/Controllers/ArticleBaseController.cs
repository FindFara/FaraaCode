using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Web.Attributes;

namespace CodeTo.Web.Areas.Articles.Controllers
{
    [Area("Articles")]
    [PermissionChecker]
    public class ArticleBaseController : Controller { }
}
