using AutoMapper;
using Pidgeon.Core.Models;
using Pidgeon.Data.DatabaseModel;

namespace Pidgeon.Core.Mappings.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<UsersGroup, UserGroupViewModel>();
            CreateMap<UserGroupViewModel, UsersGroup>();

            CreateMap<UserVsgroup, UserVsgroupViewModel>();
            CreateMap<UserVsgroupViewModel, UserVsgroup>();

            CreateMap<MessageViewModel, Message>();
            CreateMap<Message, MessageViewModel>();
        }
    }
}