namespace PineWheel_Project.Models
{
    public class Pages
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Discribtion { get; set; }
        public string ButtonLable { get; set; }
        public string Type { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
