using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using task.Models;
using task.ViewModels;

namespace task.Mappers
{
    public class UserProfiler : Profile
    {
        public UserProfiler() {
            CreateMap<User, SignUpViewModel>();

            CreateMap<SignUpViewModel,User >();

        }
    }
}