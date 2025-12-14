namespace _34_Front_To_BackSqlConnection.Models
{
    public class Product : Base.BaseEntity
    {
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
