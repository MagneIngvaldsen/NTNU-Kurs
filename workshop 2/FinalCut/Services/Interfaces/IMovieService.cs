using System;
using System.Collections.Generic;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.Services.Interfaces
{
    public interface IMovieService
    {
        void Create(Movie movie);
        IList<Movie> GetFeaturedMovies();
        IList<Movie> GetAll();
        Movie GetById(Guid id);
        Movie GetByTitle(string title);
        IEnumerable<Movie> SearchAll(string searchText);
        IEnumerable<Movie> SearchGenre(string searchText);
        IEnumerable<Movie> SearchTitle(string searchText);
        IEnumerable<Movie> SearchActor(string searchText);
    }
}