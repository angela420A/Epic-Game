using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
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
            var result = _rbp.GetHomeViewModel();
            return View(result);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";
        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View();
        //}

        public ActionResult Search(string id)
        {
            if (id == null)
            {
                var result = _rbp.GetAll(); 
                return View(result);
            }
             else
            {
                var result = _rbp.GetUserSearch(id).ToList();
                return View(result);
            }
           
        }

        [HttpPost]
        public ActionResult SearchOrder(string Key, bool Boo,string num)
        {
            var result = _rbp.SearchOrde(Key,Boo, int.Parse(num));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductMore()
        {
            return View();
        }
    }
}