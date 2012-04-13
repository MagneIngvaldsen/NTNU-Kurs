using System;
using System.Collections.Generic;
using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Length { get; private set; }
        public Genre Genre { get; private set; }
        public string CoverUrl { get; private set; }
        public string TrailerUrl { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public IList<Character> Cast { get; private set; }

        public Movie(string title, string description, int length, Genre genre, string coverUrl, string trailerUrl, DateTime releaseDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Length = length;
            Genre = genre;
            CoverUrl = coverUrl;
            TrailerUrl = trailerUrl;
            ReleaseDate = releaseDate;
            Cast = new List<Character>();
        }

        public void AddCharacter(Character actor)
        {
            if(!Cast.Contains(actor))
            {
                Cast.Add(actor);
            }
        }

        public void AddCast(IList<Character> cast)
        {
            Cast = cast;
        }

        public void Update(string title, string description, Genre genre, DateTime releaseDate, int length, string coverUrl, string trailerUrl)
        {
            Title = title;
            Description = description;
            Length = length;
            Genre = genre;
            CoverUrl = coverUrl;
            TrailerUrl = trailerUrl;
            ReleaseDate = releaseDate;
        }
    }
}