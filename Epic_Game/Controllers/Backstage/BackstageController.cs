using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers.Backstage
{
    public class BackstageController : Controller
    {
        // GET: Backstage
        public ActionResult Index()
        {
            return View();
        }
    }
}