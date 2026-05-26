using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using task.Resources;



namespace task.Domain.ViewModels
{
    public class UserViewModel
    {

        public int Id { get; set; }

        [Display(
            ResourceType = typeof(UserMessages),
            Name = nameof(UserMessages.Name)
            )]
        [Required(
    ErrorMessageResourceType = typeof(Message),
    ErrorMessageResourceName = nameof(Message.FillUser))]
        public string Name { get; set; }


        [Display(
          ResourceType = typeof(UserMessages),
          Name = nameof(UserMessages.Email)
        )]
        [EmailAddress(ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.InvalidEmail)
         )]
        [Required(
            ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.FillEmail)
        )]
        public string Email { get; set; }

        [Display(
           ResourceType = typeof(UserMessages),
           Name = nameof(UserMessages.Password)
       )]
        

        [DataType(DataType.Password)]
        public string Password { get; set; } = null;
    }
}