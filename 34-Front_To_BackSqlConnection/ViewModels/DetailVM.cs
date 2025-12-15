using _34_Front_To_BackSqlConnection.Models;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class DetailVM
    {
        public Product Product { get; set; }
        public List<Product> RelationProduct { get; set; }
    }
}
