namespace _34_Front_To_BackSqlConnection.Models
{
    public class Size : Base.BaseEntity
    {
        public string Name { get; set; }
        List<ProductSize> ProductSizes { get; set; }
    }
}
