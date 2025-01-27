namespace PineWheel_Project.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
