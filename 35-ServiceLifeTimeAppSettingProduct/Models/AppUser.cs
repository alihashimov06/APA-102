using Microsoft.AspNetCore.Identity;

namespace _34_Front_To_BackSqlConnection.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
