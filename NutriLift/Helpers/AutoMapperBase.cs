using AutoMapper;
using NutriLift.Entities;
using NutriLift.Models;

namespace NutriLift.Helpers
{
    public class AutoMapperBase
    {
        protected readonly IMapper mapper;
        protected AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<UserDetails, UserDetailsModel>();
                x.CreateMap<FoodName, FoodNameModel>();
                x.CreateMap<FoodNameModel, FoodName>();
            });
            mapper = config.CreateMapper();
        }
    }
}
