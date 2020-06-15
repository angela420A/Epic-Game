using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Repository.BusinessLogicLayer;
using EpicGameLibrary.Models;
using System.ComponentModel;
using Epic_Game.ViewModels;
using Newtonsoft.Json;

namespace Epic_Game.Controllers
{
    public class LibraryController : Controller
    {
        LibraryBLO blo;
        // GET: Library
        public ActionResult Index()
        {
            blo = new LibraryBLO(User.Identity.GetUserId());

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewData.Model = blo.GetLibraryProduct();
                return View();
            }
        }

        [HttpPost]
        public ActionResult ShowOrder(string Key)
        {
            var UserId = User.Identity.GetUserId();
            var libraryBLO = new LibraryBLO(UserId, Key);
            return Json(libraryBLO.OrderLibraryProduct(), JsonRequestBehavior.AllowGet);
        }
    }
}