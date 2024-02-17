using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mission6_Sheffield.Models
{
    public class movies // movies model
    {
        [Key]
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } // Title getter and setter

        [Required]
        public string Category { get; set; } // Category getter and setter

        [Required]
        public string Director { get; set; } // Director getter and setter

        [Required]
        public string Year { get; set; } // Year getter and setter

        [Required]
        public string Rating { get; set; } // Rating getter and setter

        // optional fields
        [MaybeNull]
        public bool? Edited { get; set; } // edited getter and setter

        [AllowNull]
        public string LentTo { get; set; } // lentTo getter and setter

        [AllowNull]
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string Notes { get; set; } // notes getter and setter
    }

}
