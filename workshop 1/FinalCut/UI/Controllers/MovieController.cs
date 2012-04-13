using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ITVerket.FinalCut.Domain.Entities;
using ITVerket.FinalCut.Services;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.UI.Extensions;
using ITVerket.FinalCut.UI.Models;
using MvcContrib;

namespace ITVerket.FinalCut.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        public ActionResult Index()
        {
            var result = _movieService.GetAll();
            var model = new List<MovieViewModel>();
            foreach (var movie in result)
            {
                model.Add(new MovieViewModel(movie));
            }
            return View(model.OrderBy(x => x.Title));
        }

        public ActionResult Details(string slug)
        {
            var movie = _movieService.GetByTitle(slug.FromUrlText());

            if (movie == null)
                return new HttpNotFoundResult();
            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.Create(new Movie(model.Title, model.Description, model.Length, model.Genre, model.CoverUrl, model.TrailerUrl, model.ReleaseDate));
            return this.RedirectToAction(x => x.Details(model.Title.ToUrlText()));
        }

        [HttpGet]
        public ActionResult CreateAjax()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAjax(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.Create(new Movie(model.Title, model.Description, model.Length, model.Genre, model.CoverUrl, model.TrailerUrl, model.ReleaseDate));
            return Json(new { url = Url.Action("Index") });
        }

        [HttpGet]
        public ActionResult Edit(string slug)
        {
            var movie = _movieService.GetByTitle(slug.FromUrlText());

            if (movie == null)
                return new HttpNotFoundResult();
            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var movie = _movieService.GetById(model.Id);
            if (movie == null)
                return new HttpNotFoundResult();
            movie.Update(model.Title, model.Description, model.Genre, model.ReleaseDate, model.Length, model.CoverUrl, movie.TrailerUrl);
            return this.RedirectToAction(x => x.Details(model.Title.ToUrlText()));
        }
    }
}
