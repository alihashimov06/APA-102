using System.ComponentModel.DataAnnotations;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class LoginVM
    {
        [MinLength(3)]
        [MaxLength(20)]
        public string UserNameOrEmail { get; set; }
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
