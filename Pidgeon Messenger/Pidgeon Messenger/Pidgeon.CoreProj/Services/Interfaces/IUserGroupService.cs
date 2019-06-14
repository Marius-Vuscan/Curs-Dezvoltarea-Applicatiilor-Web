using Pidgeon.Core.Models;
using System.Collections.Generic;

namespace Pidgeon.Core.Services.Interfaces
{
    public interface IUserGroupService
    {
        IList<TEntity> GetAll<TEntity>();

        TEntity GetById<TEntity>(string id, string[] includes = null);

        TEntity GetByName<TEntity>(string name, string[] includes = null);

        void Create(UserGroupViewModel model);
    }
}
