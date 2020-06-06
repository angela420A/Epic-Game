using Epic_Game.Repository.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class HomeController : Controller
    {
        private HomeBLO _rbp;
        public HomeController()
        {
            _rbp = new HomeBLO();
        }
        public ActionResult Index()
        {
            var result = _rbp.getHomeViewModel();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult ProductMore()
        {
            return View();
        }
    }
}