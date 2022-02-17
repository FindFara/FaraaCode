using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("Userpanels")]
    [Route("cpanel")]
    public class BaseUserPanelController : Controller { }
}

