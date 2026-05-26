using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using task.Resources;

namespace task.Domain.Models.enums
{
    public enum StateTask
    {

        [Display(
           ResourceType = typeof(TaskMessages),
           Name = nameof(TaskMessages.Pending)
           )]
        Pending = 1,

        [Display(
        ResourceType = typeof(TaskMessages),
        Name = nameof(TaskMessages.InProgress)
        )]
        InProgress = 2,


        [Display(
       ResourceType = typeof(TaskMessages),
       Name = nameof(TaskMessages.Fineshed)
       )]
        Finished = 3,


        [Display(
          ResourceType = typeof(TaskMessages),
          Name = nameof(TaskMessages.Cancelled)
          )]
        Cancelled = 4

    }

}