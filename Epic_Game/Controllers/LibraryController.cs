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
        // GET: Library
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return GetLibrary(UserId);
            }
        }

        private ActionResult GetLibrary(string userId)
        {
            var libraryBLO = new LibraryBLO(userId);
            return View(libraryBLO.GetLibraryProduct());
        }

        [HttpPost]
        public ActionResult ShowOrder(string Key)
        {
            var UserId = User.Identity.GetUserId();
            var libraryBLO = new LibraryBLO(UserId, Key);
            return Json(libraryBLO.OrderLibraryProduct(),JsonRequestBehavior.AllowGet);
        }
    }
}