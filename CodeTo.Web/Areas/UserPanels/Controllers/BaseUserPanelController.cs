using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Web.Attributes;

namespace CodeTo.Web.Areas.UserPanel.Controllers
{
    [Area("Userpanels")]
    [Route("cpanel")]
    [PermissionChecker]
    public class BaseUserPanelController : Controller { }
}

