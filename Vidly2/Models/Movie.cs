using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly2.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [ForeignKey("GenreTypeId")]
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreTypeId { get; set; }
    }
}


/*
 
It is worth noting here that when the Movie model was orignally created (along with the Genre model) a column was automatically added called Genre_Id in the Movie model.
This colum nwas being used as the foreign key and not GenreTypeID - I don't know why Genre_Id was created.

To resolve the issue I added the [ForeignKey( )] attribute to the Genre property, pointing to GenreTypeID.
I used a migration - commenting everything out except:

            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id", cascadeDelete: true);     

This seems to have fixed the problem.

So, add the annotation re. desired foreign key, making the unwanted column obsolete, migrate, then remove the unwanted column
     
*/
