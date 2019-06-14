using Pidgeon.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Core.Services.Interfaces
{
    public interface IUserVsgroupService
    {
        void Create(UserVsgroupViewModel model);

        IList<TEntity> GetAllByUserName<TEntity>(string userName);

        TEntity GetByUserNameAndGroupId<TEntity>(string userName, string groupId);
    }
}
