using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
    public class ActivityController : Controller
    {
        private EGContext db = new EGContext();
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}