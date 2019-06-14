using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;

namespace Pidgeon.Data.Implementations
{
    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        private readonly PidgeonContext dbContext;

        public UserGroupRepository(PidgeonContext context) : base(context)
        {
            this.dbContext = context;
        }
    }
}
