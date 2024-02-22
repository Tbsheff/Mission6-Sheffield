using System.ComponentModel.DataAnnotations;

namespace Mission6_Sheffield.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; } // CategoryId getter and setter
        public string Category { get; set; } // Name getter and setter
    }
}
