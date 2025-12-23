using _34_Front_To_BackSqlConnection.Models;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels.Products
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

    }
}
