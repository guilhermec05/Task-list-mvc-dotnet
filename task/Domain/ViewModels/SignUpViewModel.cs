using System.ComponentModel.DataAnnotations;
using task.Resources;

namespace task.Domain.ViewModels
{
    public class SignUpViewModel
    {

        [Display(

             ResourceType = typeof(Message),
             Name = nameof(Message.Name)
           )]
        [Required(
ErrorMessageResourceType = typeof(Message),
ErrorMessageResourceName = nameof(Message.FillUser))]
        public string Name { get; set; }

        [EmailAddress(ErrorMessageResourceType = typeof(Message),
            ErrorMessageResourceName = nameof(Message.InvalidEmail))]
        [Required(
    ErrorMessageResourceType = typeof(Message),
    ErrorMessageResourceName = nameof(Message.FillEmail))]
        [Display(

              ResourceType = typeof(Message),
              Name = nameof(Message.Email)
            )]
        public string Email { get; set; }

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