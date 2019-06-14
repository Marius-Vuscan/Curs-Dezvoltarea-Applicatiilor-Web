using Microsoft.AspNetCore.Mvc;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon_Messenger.Models;
using System.Diagnostics;
using System.Linq;

namespace Pidgeon_Messenger.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserGroupService userGroupService;

        public HomeController(IUserGroupService userGroupService)
        {
            this.userGroupService = userGroupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserGroupSample()
        {
            var model = userGroupService.GetAll<UserGroupViewModel>().FirstOrDefault();

            return View(model);
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            return Ok(userGroupService.GetAll<UserGroupViewModel>());
        }
    }
}
