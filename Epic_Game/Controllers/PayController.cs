using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            var pId = TempData["ProductId"];

            return View();
        }

        public ActionResult Finish()
        {
            return View();
        }
    }
}