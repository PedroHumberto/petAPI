using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PETRGAPI.USERS.Models;
using UsersApi.Models;
using UsersAPI.Data.Dto;

namespace UsersApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile(){
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
            CreateMap<User, CustomIdentityUser>();
        }
    }
}