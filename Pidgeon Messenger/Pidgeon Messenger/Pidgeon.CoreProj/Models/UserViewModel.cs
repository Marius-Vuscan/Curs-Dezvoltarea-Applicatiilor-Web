using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Core.Models
{
    public class UserViewModel
    {
        public virtual string PasswordHash { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
    }
}
