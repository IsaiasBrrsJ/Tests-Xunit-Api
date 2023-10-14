using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAndTestsxUnit.Domain.Model.User
{
    [Table("User")]
    public class User
    {
        [Key]

        
        public int Id { get; set; }

        public string UserName { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;
    }
}
