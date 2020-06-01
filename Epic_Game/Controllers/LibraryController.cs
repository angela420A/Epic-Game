﻿using Microsoft.AspNet.Identity;
using System;
using Epic_Game.Repository.BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Repository.BusinessLogicLayer;

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
    }
}