using System.ComponentModel.DataAnnotations;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Surname { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }
        [MaxLength(40)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
