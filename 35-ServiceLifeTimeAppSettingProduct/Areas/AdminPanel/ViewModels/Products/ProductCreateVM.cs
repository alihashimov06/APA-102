using _34_Front_To_BackSqlConnection.Models;
using System.ComponentModel.DataAnnotations;

namespace _34_Front_To_BackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class ProductCreateVM
    {
        public IFormFile MainPhoto { get; set; }
        public IFormFile HoverPhoto { get; set; }
        public List<IFormFile>? AdditionalPhotos { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
        [Required]
        public List<int> SizeIds { get; set; }
        public List<Size>? Sizes { get; set; }
    }
}
