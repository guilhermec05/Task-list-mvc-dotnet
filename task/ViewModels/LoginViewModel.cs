using Resources;
using System.ComponentModel.DataAnnotations;
using task.Resources;

namespace task.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.InvalidUser))]
        [EmailAddress(ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.InvalidEmail))]

        [Display(
            ResourceType = typeof(Message),
            Name = nameof(Message.Login)
        )]
        public string User { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.FillPassword))]
        [DataType(DataType.Password)]

        [Display(
            ResourceType = typeof(Message),
            Name = nameof(Message.Password)
        )]
        public string Password { get; set; }
    }
}