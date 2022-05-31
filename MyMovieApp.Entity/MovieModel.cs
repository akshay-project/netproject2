using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyMovieApp.Entity
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public string MovieDescription { get; set; }

        public string MovieType { get; set; }

        public string MovieLanguage { get; set; }

    }
}
