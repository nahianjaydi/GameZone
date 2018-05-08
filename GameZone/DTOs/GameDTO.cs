using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameZone.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Rent { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public byte NumberInStock { get; set; }
    }
}