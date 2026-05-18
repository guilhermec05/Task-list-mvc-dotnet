using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using task.Models.enums;

namespace task.ViewModels
{
    public class TaskListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsExpired { get; set; }

        public StateTask State { get; set; }

    }
}