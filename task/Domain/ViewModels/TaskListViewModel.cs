using task.Domain.Models.enums;
using task.Extensions;

namespace task.Domain.ViewModels
{
    public class TaskListViewModel
    {
        public int? Id { get; set; }

        public string Title { get; set; } = null;

        public string Description { get; set; } = null;

        public bool IsExpired { get; set; } = false;

        public StateTask State { get; set; } = StateTask.Pending;

        public string StatusDisplay => State.GetDisplayName();

    }
}