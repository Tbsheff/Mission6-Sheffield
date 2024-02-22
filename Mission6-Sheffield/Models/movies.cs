﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Mission6_Sheffield.Models
{
    public class movies // movies model
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // MovieId getter and setter

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } // Category getter and setter
        public Categories Category { get; set; } // Category getter and setter
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } // Title getter and setter
        [Required]
        public string Year { get; set; } // Year getter and setter
        public string? Director { get; set; } // Director getter and setter
        [AllowNull]
        public string? Rating { get; set; } // Rating getter and setter

        // optional fields
        [Required]
        public bool Edited { get; set; } // edited getter and setter

        public string? LentTo { get; set; } // lentTo getter and setter
        [Required]
        public bool CopiedToPlex { get; set; } // copiedToPlex getter and setter

        [AllowNull]
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; } // notes getter and setter
    }

}
