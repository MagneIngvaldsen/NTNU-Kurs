using System;
using System.Collections.Generic;
using System.Linq;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.Services.TestData
{
    public class StaticTestData
    {
        private static IList<Movie> _movies;

        public static IList<Movie> Movies
        {
            get { return _movies ?? (_movies = GetListOfMovies()); }
        }

        private static IList<Movie> GetListOfMovies()
        {
            var theHelp = new Movie("The Help",
                                    @"A look at what happens when a southern town's unspoken code of rules and behavior is shattered by three courageous women who strike up an unlikely friendship.",
                                    146, Genre.Drama, "../../Content/images/MV5BMTM5OTMyMjIxOV5BMl5BanBnXkFtZTcwNzU4MjIwNQ@@._V1._SY317_.jpg", null, new DateTime(2011, 10, 7));
            theHelp.AddCast(GetCharactersForTheHelp().ToList());
            

            var planetOfTheApes = new Movie("Rise of the Planet of the Apes",
                                            @"During experiments to find a cure for Alzheimer's disease, a genetically-enhanced chimpanzee uses its greater intelligence to lead other apes to freedom."
                                            , 105, Genre.SciFi, "../../Content/images/MV5BMTQyMjUxNTc0Ml5BMl5BanBnXkFtZTcwMjg1ODExNg@@._V1._SY317_CR0,0,214,317_.jpg", null, new DateTime(2011, 8, 12));

            var conan = new Movie("Conan the Barbarian",
                                  @"The tale of Conan the Cimmerian and his adventures across the continent of Hyboria on a quest to avenge the murder of his father and the slaughter of his village.",
                                  113, Genre.Action, "../../Content/images/MV5BMTQ1NDUyODk5NF5BMl5BanBnXkFtZTcwODk0MjIwNg@@._V1._SY317_.jpg", null, new DateTime(2011, 8, 12));

            var shawshankRed = new Movie("The Shawshank Redemption",
                                         @"Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                                         142, Genre.Crime, "../../Content/images/MV5BMTM2NjEyNzk2OF5BMl5BanBnXkFtZTcwNjcxNjUyMQ@@._V1._SY317_.jpg", null, new DateTime(1995, 1, 6));

            var theGodfather = new Movie("The Godfather",
                                         @"The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                                         175, Genre.Drama, "../../Content/images/MV5BMTIyMTIxNjI5NF5BMl5BanBnXkFtZTcwNzQzNDM5MQ@@._V1._SY317_CR2,0,214,317_.jpg", null, new DateTime(1972, 1, 1));

            var pulp = new Movie("Pulp Fiction",
                                 @"The lives of two mob hit men, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                                 154, Genre.Thriller, "../../Content/images/MV5BMjE0ODk2NjczOV5BMl5BanBnXkFtZTYwNDQ0NDg4._V1._SY317_CR4,0,214,317_.jpg", null, new DateTime(1994, 10, 21));

            var pirates = new Movie("Pirates of the Caribbean - On Stranger Tides",
                                 @"Jack Sparrow and Barbossa embark on a quest to find the elusive fountain of youth, only to discover that Blackbeard and his daughter are after it too.",
                                 136, Genre.Action, "../../Content/images/MV5BMjE5MjkwODI3Nl5BMl5BanBnXkFtZTcwNjcwMDk4NA@@._V1._SY317_CR0,0,214,317_.jpg",
                                 "http://www.youtube.com/embed/kV8D96aSPoI?rel=1&autoplay=0", 
                                 new DateTime(2011, 05, 18));

            var avengers = new Movie("The Avengers",
                                     @"The S.H.I.E.L.D. agency brings together a team of superhumans to help save the Earth from annihilation by extraterrestrial invaders.",
                                     136, Genre.Action, "../../Content/images/MV5BMTg5Nzk1MzUyNF5BMl5BanBnXkFtZTcwNDcxODQwNg@@._V1._SY317_.jpg",
                                     "http://www.youtube.com/embed/tXcv8hcZv-E?rel=1&amp;hd=1",
                                     new DateTime(2012, 05, 04));

            return new List<Movie> { theHelp, planetOfTheApes, conan, shawshankRed, theGodfather, pulp, pirates, avengers }.OrderBy(x => x.Title).ToList();
        }

        private static IEnumerable<Character> GetCharactersForTheHelp()
        {
            yield return new Character("Eugenia 'Skeeter' Phelan", new Actor("Emma", "Stone", new DateTime(1988,11,6), "http://www.danielatamayo.com/img/emma-stone-8.jpg"));
            yield return new Character("Aibileen Clark", new Actor("Viola", "Davis", new DateTime(1965, 8,11), "http://famosos.culturamix.com/blog/wp-content/gallery/viola-davis/foto-viola-davis-01.jpg"));
            yield return new Character("Hilly Holbrook", new Actor("Bryce", "Dallas Howard", new DateTime(1981, 3, 2), "http://imstars.aufeminin.com/stars/fan/bryce-dallas-howard/bryce-dallas-howard-20070706-280363.jpg"));
          
            
        }
    }
}