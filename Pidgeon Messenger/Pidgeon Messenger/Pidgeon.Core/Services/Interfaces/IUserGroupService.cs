using System.Collections.Generic;

namespace Pidgeon.Core.Services.Interfaces
{
    public interface IUserGroupService
    {
        IList<TEntity> GetAll<TEntity>();

        TEntity GetById<TEntity>(int id, string[] includes = null);

        TEntity GetByName<TEntity>(string name, string[] includes = null);
    }
}
