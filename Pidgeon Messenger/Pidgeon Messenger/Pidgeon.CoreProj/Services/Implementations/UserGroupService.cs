using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;

namespace Pidgeon.Core.Services.Implementations
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IDatabaseContext dbContext;
        private readonly IMapper mapper;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUserVsgroupRepository userVsgroupRepository;
        private readonly IMessageRepository messageRepository;

        public UserGroupService(IDatabaseContext dbContext, IMapper mapper, IUserGroupRepository userGroupRepository, IUserVsgroupRepository userVsgroupRepository, IMessageRepository messageRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userGroupRepository = userGroupRepository;
            this.userVsgroupRepository = userVsgroupRepository;
            this.messageRepository = messageRepository;
        }

        public TEntity GetById<TEntity>(string id, string[] includes = null)
        {
            var resultFromDb = userGroupRepository.GetAll(includes).SingleOrDefault(userGroup => userGroup.Id == id);

            var result = mapper.Map<TEntity>(resultFromDb);

            return result;
        }

        public TEntity GetByName<TEntity>(string name, string[] includes = null)
        {
            var resultFromDb = userGroupRepository.GetAll(includes).SingleOrDefault(userGroup => userGroup.Name == name);

            var result = mapper.Map<TEntity>(resultFromDb);

            return result;
        }

        public IList<TEntity> GetAll<TEntity>()
        {
            var resultFromDb = userGroupRepository.GetAll().ToList();

            var result = mapper.Map<IList<UsersGroup>, IList<TEntity>>(resultFromDb);

            return result;
        }

        public void Create(UserGroupViewModel model)
        {
            var result = mapper.Map<UserGroupViewModel, UsersGroup>(model);

            userGroupRepository.Add(result);

            dbContext.Complete();
        }
    }
}
