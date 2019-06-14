using AutoMapper;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Core.Services.Implementations
{
    public class MessageService: IMessageService
    {
        private readonly IDatabaseContext dbContext;
        private readonly IMapper mapper;
        private readonly IMessageRepository messageRepository;

        public MessageService(IDatabaseContext dbContext, IMapper mapper, IMessageRepository messageRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.messageRepository = messageRepository;
        }

        public void Create(MessageViewModel model)
        {
            var result = mapper.Map<MessageViewModel, Message>(model);

            messageRepository.Add(result);

            dbContext.Complete();
        }
    }
}
