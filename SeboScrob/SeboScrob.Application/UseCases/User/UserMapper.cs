using AutoMapper;
using SeboScrob.Application.UseCases.User.CreateUser;
using SeboScrob.Application.UseCases.User.GetUser;
using SeboScrob.Application.UseCases.User.UpdateUser;
using SeboScrob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<UserEntity, CreateUserResponse>();
            CreateMap<CreateUserResponse, UserEntity>();
            CreateMap<CreateUserRequest, UserEntity>();
            CreateMap<CreateUserRequest, CreateUserResponse>();
            CreateMap<UpdateUserRequest, UserEntity>();
            CreateMap<UserEntity, UpdateUserResponse>();
            CreateMap<UserEntity, GetUserResponse>();
        }
    }
}
