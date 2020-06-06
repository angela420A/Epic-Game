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
        public WishListBLO wishlistBLO;

        // GET: WishList
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            if (!User.Identity.IsAuthenticated)
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
            wishlistBLO = new WishListBLO(userId);
            return View(wishlistBLO.GetWishListProduct());
        }

        public void Delete(string jdata)
        {
            
            new WishListBLO(User.Identity.GetUserId()).DeleteWishListProduct(jdata);
            GetWishList(User.Identity.GetUserId());
        }
    }
}