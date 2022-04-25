using AutoMapper;
using Microservice1.Models;
using Microservice1.ViewModel;

namespace Microservice1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CellPhone, CellPhoneViewModel>();
            CreateMap<ViewModel.PostViewModel, CellPhone>();
        }
    }
}
