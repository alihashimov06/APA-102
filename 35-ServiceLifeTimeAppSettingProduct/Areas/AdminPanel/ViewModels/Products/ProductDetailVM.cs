using _34_Front_To_BackSqlConnection.Models;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public List<string> AdditionalImages { get; set; }
        public List<string> Tags { get; set; }
        public List<ProductSize> Sizes { get; set; }
    }
}
