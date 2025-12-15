namespace _34_Front_To_BackSqlConnection.Models
{
    public class Slider : Base.BaseEntity
    {
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Order { get; set; }
    }
}
