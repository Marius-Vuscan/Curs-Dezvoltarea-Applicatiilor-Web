using Pidgeon.Data.DatabaseModel;
using System.Collections.Generic;

namespace Pidgeon.Core.Models
{
    public class UserGroupViewModel
    {
        public UserGroupViewModel()
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
