using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.UI.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string ReleaseDateShortDate
        {
            get { return ReleaseDate.ToShortDateString(); }
            set
            {
                DateTime date;
                if (DateTime.TryParse(value, out date))
                    ReleaseDate = date;
            }
        }

        public MovieViewModel()
        {
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Length = movie.Length;
            Genre = movie.Genre;
            CoverUrl = movie.CoverUrl;
            TrailerUrl = movie.TrailerUrl;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}