using Microsoft.AspNetCore.SignalR;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pidgeon.Web.Hubs
{
    public class GroupHub : Hub
    {
        private readonly IUserGroupService userGroupService;
        private readonly IUserVsgroupService userVsgroupService;

        public GroupHub(IUserGroupService userGroupService, IUserVsgroupService userVsgroupService)
        {
            this.userGroupService = userGroupService;
            this.userVsgroupService = userVsgroupService;
        }

        public override async Task OnConnectedAsync()
        {
            var groups = userVsgroupService.GetAllByUserName<UserVsgroupViewModel>(Context.User.Identity.Name);

            foreach (var item in groups)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.GroupId);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var groups = userVsgroupService.GetAllByUserName<UserVsgroupViewModel>(Context.User.Identity.Name);

            foreach (var item in groups)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, item.GroupId);
            }
        }

        public void SendMessageToGroup(string userName, string groupId, string message)
        {
            Clients.Group(groupId).SendAsync("sendMessageToGroup",  userName, groupId, message);
        }
    }
}
