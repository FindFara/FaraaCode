using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Web.Attributes;

namespace CodeTo.Web.Areas.Contents.Controllers
{
    [Area("Contents")]
    [PermissionChecker]
    public class ContentBaseController : Controller
    {
    }
}
