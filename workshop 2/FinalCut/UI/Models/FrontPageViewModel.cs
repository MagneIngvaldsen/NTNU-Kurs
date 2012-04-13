using System.Collections.Generic;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Domain.Entities.Enum;

namespace ITVerket.FinalCut.UI.Models
{
    public class FrontPageViewModel
    {
        public SearchCriteria SearchCriteria { get; set; }
        public IList<Movie> FeaturedMovies { get; set; }
    }
}