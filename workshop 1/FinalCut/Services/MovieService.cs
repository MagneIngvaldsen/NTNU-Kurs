using System;
using System.Collections.Generic;
using System.Linq;
using ITVerket.FinalCut.Domain;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Domain.Entities.Enum;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.Services.TestData;

namespace ITVerket.FinalCut.Services
{
    public class MovieService : IMovieService
    {
        public void Create(Movie movie)
        {
            StaticTestData.Movies.Add(movie);
        }

        public IList<Movie> GetFeaturedMovies()
        {
            return StaticTestData.Movies.OrderByDescending(x => x.ReleaseDate).Take(3).ToList();
        }

        public IList<Movie> GetAll()
        {
            return StaticTestData.Movies;
        }

        public Movie GetById(Guid id)
        {
            var movies = StaticTestData.Movies;
            return (from m in movies where m.Id == id select m).FirstOrDefault();
        }

        public Movie GetByTitle(string title)
        {
            var movies = StaticTestData.Movies;

            return (from m in movies where m.Title == title select m).FirstOrDefault();
        }

        public IEnumerable<Movie> SearchAll(string searchText)
        {
            var movies = StaticTestData.Movies;
            if (string.IsNullOrEmpty(searchText))
                return movies;
            return (from m in movies where m.Description.ToUpper().Contains(searchText) 
                    || m.Title.ToUpper().Contains(searchText)
                    || m.Genre == GetGenreFromText(searchText)
                    || m.ReleaseDate.ToShortDateString().Contains(searchText)
                    || m.Cast.Select(c => c.Actor.FirstName.ToUpper().Contains(searchText)).Any()
                    select m);
        }

        public IEnumerable<Movie> SearchGenre(string searchText)
        {
            var movies = StaticTestData.Movies;
            if (string.IsNullOrEmpty(searchText))
                return movies;
            return (from m in movies where m.Genre == GetGenreFromText(searchText) select m);
        }

        public IEnumerable<Movie> SearchTitle(string searchText)
        {
            var movies = StaticTestData.Movies;
            if (string.IsNullOrEmpty(searchText))
                return movies;
            return (from m in movies where m.Title == searchText select m);
               
        }

        public IEnumerable<Movie> SearchActor(string searchText)
        {
            var movies = StaticTestData.Movies;
            if (string.IsNullOrEmpty(searchText))
                return movies;
            return (from m in movies where m.Cast.Select(c => c.Actor.FirstName.ToUpper().Contains(searchText)).Any() select m);
        }

        private static Genre? GetGenreFromText(string searchText)
        {
            foreach (var value in Enum.GetValues(typeof(Genre)))
            {
                var name = Enum.GetName(typeof(Genre), value);
                if (name.ToUpper() == searchText)
                    return (Genre)value;
            }

            return null;
        }
    }
}