namespace _34_Front_To_BackSqlConnection.Models
{
    public class ProductImage : Base.BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool? IsMain { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
