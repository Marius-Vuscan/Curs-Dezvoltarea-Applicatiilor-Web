using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public UserGroupService(IDatabaseContext dbContext, IMapper mapper, IUserGroupRepository userGroupRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userGroupRepository = userGroupRepository;
        }

        public TEntity GetById<TEntity>(int id, string[] includes = null)
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

            var result = mapper.Map<IList<UserGroup>, IList<TEntity>>(resultFromDb);

            return result;
        }
    }
}
