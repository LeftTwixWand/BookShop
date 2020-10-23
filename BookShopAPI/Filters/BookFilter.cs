using BookShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BookShopAPI.Filters
{
    public class BookFilter : IBook
    {
        [FromQuery(Name = "id")]
        public int Id { get; set; }

        [FromQuery(Name = "author")]
        public string Author { get; set; }

        [FromQuery(Name = "title")]
        public string Title { get; set; }

        [FromQuery(Name = "publication")]
        public DateTime? Publication { get; set; }

        [FromQuery(Name = "cover")]
        public Cover Cover { get; set; }

        [FromQuery(Name = "ageCategory")]
        public AgeCategory AgeCategory { get; set; }

        [FromQuery(Name = "genre")]
        public Genre Genre { get; set; }
    }
}