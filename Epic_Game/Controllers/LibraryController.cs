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
        public LibraryController()
        {
        }
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
                if (TempData["Order"] != null)
                {
                    ViewData.Model = (List<LibraryViewModel>)TempData["Order"];
                    return View();
                }
                else
                {
                    ViewData.Model = blo.GetLibraryProduct();
                    return View();
                }
            }
        }

        //private ActionResult GetLibrary()
        //{
        //    return View(blo.GetLibraryProduct());
        //}
        [HttpPost]
        public ActionResult ShowOrder(string Key)
        {
            var UserId = User.Identity.GetUserId();
            var libraryBLO = new LibraryBLO(UserId, Key);
            TempData["Order"] = libraryBLO.OrderLibraryProduct();
            //return RedirectToAction("Index");
            return Json(libraryBLO.OrderLibraryProduct(),JsonRequestBehavior.AllowGet);
        }
    }
}