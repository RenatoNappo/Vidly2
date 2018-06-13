using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public String GenreDescription { get; set; }
    }
}