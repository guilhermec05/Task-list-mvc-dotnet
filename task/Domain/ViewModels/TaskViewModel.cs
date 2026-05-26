using System;
using System.ComponentModel.DataAnnotations;
using task.Domain.Models.enums;
using task.Resources;

namespace task.Domain.ViewModels
{
    public class TaskViewModel
    {


        public int Id { get; set; }


        [Display(
            ResourceType = typeof(TaskMessages),
            Name = nameof(TaskMessages.Title)
            )]
        public string Title { get; set; }

        [Display(
           ResourceType = typeof(TaskMessages),
           Name = nameof(TaskMessages.Description)
           )]
        public string Description { get; set; }


        [Display(
           ResourceType = typeof(TaskMessages),
           Name = nameof(TaskMessages.DueDate)
           )]
        public DateTime? DueDate { get; set; }


        [Display(
           ResourceType = typeof(TaskMessages),
           Name = nameof(TaskMessages.State)
           )]
        public StateTask State { get; set; } = StateTask.Pending;

        public int UserId { get; set; }
    }
}