namespace _34_Front_To_BackSqlConnection.Models
{
    public class Tag : Base.BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
