using System.ComponentModel.DataAnnotations;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class CategoryUpdateVM
    {
        [MaxLength(30, ErrorMessage = "Name's length must be max 30")]
        public string Name { get; set; }
    }
}
