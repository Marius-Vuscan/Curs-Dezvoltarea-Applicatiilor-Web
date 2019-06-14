using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon.Web.Hubs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pidgeon.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatController : Controller
    {
        private readonly IUserGroupService userGroupService;
        private readonly IMessageService messageService;
        private readonly IUserVsgroupService userVsgroupService;
        private readonly UserManager<IdentityUser> userManager;
        private IHubContext<GroupHub> hub;

        public ChatController(IUserGroupService userGroupService, IMessageService messageService, UserManager<IdentityUser> userManager, IHubContext<GroupHub> hub, IUserVsgroupService userVsgroupService)
        {
            this.userGroupService = userGroupService;
            this.messageService = messageService;
            this.userManager = userManager;
            this.hub = hub;
            this.userVsgroupService = userVsgroupService;
        }

        [HttpGet]
        public IActionResult GetUserGroups()
        {
            var user = this.User.Identity;

            var groups = userVsgroupService.GetAllByUserName<UserVsgroupViewModel>(user.Name);

            if (groups != null)
            {
                return Ok(groups);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetGroup(string groupId)
        {
            var group = userGroupService.GetById<UserGroupViewModel>(groupId, new string[] { "Message.User" });

            group.Message = group.Message.OrderBy(c => c.Date).ToList();

            if (group != null)
            {
                return Ok(group);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(string message, string groupId)
        {
            var userName = this.User.Identity.Name;

            var user = await userManager.FindByNameAsync(userName);

            var model = new MessageViewModel()
            {
                Id = Guid.NewGuid().ToString(),
                Message1 = message,
                GroupId = groupId,
                UserId = user.Id,
                Date = DateTime.Now
            };

            messageService.Create(model);

            await hub.Clients.Group(groupId).SendAsync("SendMessageToGroup", userName, groupId, message);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> AddUserInGroup(string userName, string groupId)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var userVsGroup = userVsgroupService.GetByUserNameAndGroupId<UserVsgroupViewModel>(userName, groupId);

                if (userVsGroup == null)
                {
                    var model = new UserVsgroupViewModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        GroupId = groupId,
                        UserId = user.Id,
                    };

                    userVsgroupService.Create(model);

                    return Ok();
                }

                return BadRequest();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> CreateGroup(string groupName)
        {
            var user = await userManager.FindByNameAsync(this.User.Identity.Name);

            if (user != null)
            {
                var model = new UserGroupViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name=groupName
                };

                userGroupService.Create(model);

                await AddUserInGroup(this.User.Identity.Name, model.Id);

                return Ok();
            }

            return BadRequest();
        }
    }
}