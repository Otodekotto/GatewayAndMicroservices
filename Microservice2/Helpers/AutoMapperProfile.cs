using AutoMapper;
using Microservice2.Models;
using Microservice2.ViewModel;

namespace Microservice2.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<ViewModel.PostViewModel, User>();
        }
    }
}
