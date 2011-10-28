using System.Linq;
using System.Web.Mvc;
using ITVerket.FinalCut.Domain.Entities.Enum;
using ITVerket.FinalCut.Services;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.UI.Models;
using MvcContrib;

namespace ITVerket.FinalCut.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;

        public SearchController()
        {
            _movieService = new MovieService();
        }

        public ActionResult Index()
        {
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Index(SearchCriteria? searchCriteria, string searchText)
        {
            
            searchText = searchText.Trim();
            switch (searchCriteria)
            {
                case SearchCriteria.All:
                    return this.RedirectToAction(x => x.All(searchText));
                case SearchCriteria.Genre:
                    return this.RedirectToAction(x => x.Genre(searchText));
                case SearchCriteria.Title:
                    return this.RedirectToAction(x => x.Title(searchText));
                case SearchCriteria.Actor:
                    return this.RedirectToAction(x => x.Actor(searchText));
                default:
                    return new HttpNotFoundResult();
            }
        }

        public ActionResult All(string searchText)
        {
            var result = _movieService.SearchAll(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index",model);
        }

        public ActionResult Genre(string searchText)
        {
            var result = _movieService.SearchGenre(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

        public ActionResult Title(string searchText)
        {
            var result = _movieService.SearchTitle(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

        public ActionResult Actor(string searchText)
        {
            var result = _movieService.SearchActor(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

    }
}
