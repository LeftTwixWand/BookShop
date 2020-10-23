using System;

namespace BookShopAPI.Models
{

    /// <summary>
    /// <see cref="Book"/> data model 
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public DateTime Publication { get; set; }

        public Cover Cover { get; set; }

        public AgeCategory AgeCategory { get; set; }

        public Genre Genre { get; set; }
    }
}