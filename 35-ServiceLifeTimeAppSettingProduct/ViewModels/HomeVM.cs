using _34_Front_To_BackSqlConnection.Models;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Shipping> Shippings { get; set; }
        public List<Presentation> Presentations { get; set; }
        public List<Group> Groups { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Category> Categories { get; set; }
    }
}
