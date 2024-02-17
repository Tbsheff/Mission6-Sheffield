using System.ComponentModel.DataAnnotations;

namespace Mission6_Sheffield.Models
{
    public class movies
    {
        [Key]
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string Notes { get; set; }


    }
}
