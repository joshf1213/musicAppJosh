using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Music.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Name { get; set; }
       
        public List<Album> Albums { get; set; }
    }
}