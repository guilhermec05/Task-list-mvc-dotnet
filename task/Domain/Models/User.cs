using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace task.Domain.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}