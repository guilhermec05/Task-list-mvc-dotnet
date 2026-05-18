using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using task.Models.enums;

namespace task.Models
{
    [TableName("tasks")]
    public class Tasks
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate {  get; set; }

        public StateTask State { get; set; } = StateTask.Pending;

        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}