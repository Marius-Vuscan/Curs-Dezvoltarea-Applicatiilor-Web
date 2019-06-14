using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Pidgeon.Data.DatabaseModel
{
    public partial class Message
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
