using System.ComponentModel.DataAnnotations;

namespace _34_Front_To_BackSqlConnection.Models
{
    public class Category : Base.BaseEntity
    {
        [MaxLength(30, ErrorMessage ="el ayagi dinc tut")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }

    }
}
