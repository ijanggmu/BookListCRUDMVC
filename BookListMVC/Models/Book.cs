using System.ComponentModel.DataAnnotations;

namespace BookListMVC.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string author { get; set; }
        public string ISBN { get; set; }

    }
    
}
