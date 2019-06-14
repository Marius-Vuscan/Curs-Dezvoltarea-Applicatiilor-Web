using Microsoft.AspNetCore.Identity;
using Pidgeon.Data.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Core.Models
{
    public class MessageViewModel
    {
        public string Id { get; set; }
        public string Message1 { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }

        public UsersGroup Group { get; set; }
        public IdentityUser User { get; set; }
    }
}
