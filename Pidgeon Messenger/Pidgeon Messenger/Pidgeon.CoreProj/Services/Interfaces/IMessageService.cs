using Pidgeon.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pidgeon.Core.Services.Interfaces
{
    public interface IMessageService
    {
        void Create(MessageViewModel model);
    }
}
