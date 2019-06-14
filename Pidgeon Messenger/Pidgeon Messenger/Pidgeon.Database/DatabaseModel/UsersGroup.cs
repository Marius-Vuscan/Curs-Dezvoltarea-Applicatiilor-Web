using System;
using System.Collections.Generic;

namespace Pidgeon.Data.DatabaseModel
{
    public partial class UsersGroup
    {
        public UsersGroup()
        {
            Message = new HashSet<Message>();
            UserVsgroup = new HashSet<UserVsgroup>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Message> Message { get; set; }
        public ICollection<UserVsgroup> UserVsgroup { get; set; }
    }
}
