using AutoMapper;
using SeboScrob.Domain.Entities;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.DTOs.Responses.User;

namespace SeboScrob.WebAPI.Mappers
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
