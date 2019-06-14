using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Pidgeon.Data.DatabaseModel
{
    public partial class UserVsgroup
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }

        public UsersGroup Group { get; set; }
        public IdentityUser User { get; set; }
    }
}
