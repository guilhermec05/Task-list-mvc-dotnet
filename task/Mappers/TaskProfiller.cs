using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using task.Models;
using task.ViewModels;

namespace task.Mappers
{
    public class TaskProfiller : Profile
    {
        public TaskProfiller()
        {
            CreateMap<TaskViewModel, Tasks>();

            CreateMap<Tasks, TaskViewModel>();

            CreateMap<Tasks, TaskListViewModel>().ForMember(
                dest => dest.IsExpired,
                opt => opt.MapFrom(src => src.DueDate.HasValue && src.DueDate < DateTime.Now)
            );


        }
    }
}