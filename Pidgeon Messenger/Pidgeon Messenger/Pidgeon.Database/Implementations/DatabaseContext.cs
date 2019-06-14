using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;

namespace Pidgeon.Data.Implementations
{
    public class DatabaseContext : IDatabaseContext
    {
        private PidgeonContext context;

        public DatabaseContext(PidgeonContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
