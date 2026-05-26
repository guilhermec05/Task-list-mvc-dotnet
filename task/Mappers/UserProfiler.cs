using AutoMapper;
using task.Domain.Models;
using task.Domain.ViewModels;

namespace task.Mappers
{
    public class UserProfiler : Profile
    {
        public UserProfiler()
        {
            CreateMap<User, SignUpViewModel>();

            CreateMap<SignUpViewModel, User>();

            CreateMap<User, UserViewModel>();


            CreateMap<UserViewModel, User>();

            

        }
    }
}