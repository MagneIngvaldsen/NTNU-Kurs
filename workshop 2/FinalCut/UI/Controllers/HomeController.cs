using System.Web.Mvc;
using ITVerket.FinalCut.Services;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.UI.Models;

namespace ITVerket.FinalCut.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController()
        {
            _movieService = new MovieService();
        }

        public ActionResult Index()
        {
            var model = new FrontPageViewModel
                            {
                                FeaturedMovies = _movieService.GetFeaturedMovies()
                            };

            return View(model);
        }

    }
}
