using Epic_Game.Repository.BusinessLogicLayer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Models;

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
            var wishlistBLO = new WishListBLO(userId);
            return View(wishlistBLO.GetWishListProduct());
        }
        public void removeWish(string jdata)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Index();
            }
            var UserId = User.Identity.GetUserId();
            new WishListBLO(UserId).RemoveWish(jdata);
        }

        public void addWish(string ProductId)
        {
            var UserId = User.Identity.GetUserId();
            var blo = new WishListBLO(UserId);
            blo.addWish(ProductId);
        }
        public void ChangeWish(string jdata)
        {
            var data = JsonConvert.DeserializeObject<WishChangeModel>(jdata);
            WishListBLO blo = new WishListBLO(User.Identity.GetUserId());
            if (blo.ifWish(data.ProductId))
            {
                removeWish(data.ProductId);
            }
            else
            {
                addWish(data.ProductId);
            }
            RedirectToAction("Index", data.RedirectTo);
        }
        public ActionResult Delete()
        {
            return View();
        }
       
    }
}