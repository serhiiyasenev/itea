using AutoMapper;
using CoreBL.Models;
using CoreDAL.Entities;

namespace CoreBL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
        }
    }
}
