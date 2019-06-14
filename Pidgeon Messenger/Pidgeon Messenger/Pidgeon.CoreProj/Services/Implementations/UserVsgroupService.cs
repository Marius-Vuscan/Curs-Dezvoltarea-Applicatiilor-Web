using AutoMapper;
using Pidgeon.Core.Models;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pidgeon.Core.Services.Implementations
{
    public class UserVsgroupService : IUserVsgroupService
    {
        private readonly IDatabaseContext dbContext;
        private readonly IMapper mapper;
        private readonly IUserVsgroupRepository userVsgroupRepository;

        public UserVsgroupService(IDatabaseContext dbContext, IMapper mapper, IUserVsgroupRepository userVsgroupRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userVsgroupRepository = userVsgroupRepository;
        }

        public void Create(UserVsgroupViewModel model)
        {
            var result = mapper.Map<UserVsgroupViewModel, UserVsgroup>(model);

            userVsgroupRepository.Add(result);

            dbContext.Complete();
        }

        public IList<TEntity> GetAllByUserName<TEntity>(string userName)
        {
            var resultFromDb = userVsgroupRepository.GetAll(new string[] { "User", "Group" }).Where(element => element.User.UserName == userName);

            var result = mapper.Map<IEnumerable<UserVsgroup>, IList<TEntity>>(resultFromDb);

            return result;
        }

        public TEntity GetByUserNameAndGroupId<TEntity>(string userName, string groupId)
        {
            var resultFromDb = userVsgroupRepository.GetAll(new string[] { "User", "Group" }).SingleOrDefault(element => element.User.UserName == userName && element.GroupId == groupId);

            var result = mapper.Map<UserVsgroup, TEntity>(resultFromDb);

            return result;
        }
    }
}
