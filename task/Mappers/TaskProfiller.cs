using AutoMapper;
using System;
using task.Domain.Models;
using task.Domain.ViewModels;
using task.Domain.Models.enums;

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
                opt => opt.MapFrom(src => src.DueDate.HasValue &&
                (src.State != StateTask.Finished && src.State !=StateTask.Cancelled ) &&
                 src.DueDate < DateTime.Now)
            );


        }
    }
}