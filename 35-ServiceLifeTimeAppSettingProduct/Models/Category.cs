namespace _34_Front_To_BackSqlConnection.Models
{
    public class Category : Base.BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
