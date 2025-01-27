namespace PineWheel_Project.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuList { get; set; }
        public int MenuId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
