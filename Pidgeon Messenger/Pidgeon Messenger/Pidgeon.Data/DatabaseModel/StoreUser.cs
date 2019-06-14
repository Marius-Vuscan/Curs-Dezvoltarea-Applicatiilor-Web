using Microsoft.AspNetCore.Identity;

namespace Pidgeon.Data.DatabaseModel
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
