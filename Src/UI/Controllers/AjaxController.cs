using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITVerket.FinalCut.UI.Models;

namespace ITVerket.FinalCut.UI.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/
        public ActionResult Index()
        {
            return View();
        }


        public bool Create(MovieViewModel movie)
        {            
            return true;
        }

    }
}
