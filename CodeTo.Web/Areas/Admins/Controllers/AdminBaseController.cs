using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Web.Attributes;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    [Area("Admins")]
    [PermissionChecker]

    public class AdminBaseController : Controller
    {

    }
}
