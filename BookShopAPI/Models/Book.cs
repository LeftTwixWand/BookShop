using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopAPI.Models
{

    /// <summary>
    /// <see cref="Book"/> data model 
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Publication { get; set; }

        [Required]
        public Cover Cover { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}