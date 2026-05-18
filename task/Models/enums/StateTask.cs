using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using task.Resources;

namespace task.Models.enums
{
    public enum StateTask
    {

        [Display(
           ResourceType = typeof(TaskMessages),
           Name = nameof(TaskMessages.Pending)
           )]
        [Description("Pendente")]
        Pending = 1,

        [Display(
        ResourceType = typeof(TaskMessages),
        Name = nameof(TaskMessages.InProgress)
        )]
        [Description("Em andamento")]
        InProgress = 2,


        [Display(
       ResourceType = typeof(TaskMessages),
       Name = nameof(TaskMessages.Fineshed)
       )]
        [Description("Finalizada")]
        Finished = 3,


        [Display(
          ResourceType = typeof(TaskMessages),
          Name = nameof(TaskMessages.Cancelled)
          )]
        [Description("Cancelada")]
        Cancelled = 4

    }

}