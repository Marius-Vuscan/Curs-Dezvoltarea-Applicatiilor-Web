using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Data.Implementations
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly PidgeonContext dbContext;

        public MessageRepository(PidgeonContext context) : base(context)
        {
            this.dbContext = context;
        }
    }
}
