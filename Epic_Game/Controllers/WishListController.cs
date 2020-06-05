using Epic_Game.Repository.BusinessLogicLayer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return GetWishList(UserId);
            }
        }

        private ActionResult GetWishList(string userId)
        {
            //var wishlistBLO = new WishListBLO(userId);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}