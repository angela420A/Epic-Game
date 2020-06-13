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
        //ting
        public void addWish(string ProductId)
        {
            var UserId = User.Identity.GetUserId();
            var blo = new WishListBLO(UserId);
            blo.addWish(ProductId);
        }
        //ting
        public void ChangeWish(string jdata)
        {
            var data = JsonConvert.DeserializeObject<WishChangeModel>(jdata);
            WishListBLO blo = new WishListBLO(User.Identity.GetUserId());
            if (blo.ifWish(data.ProductId))
            {
                Delete(data.ProductId);
            }
            else
            {
                addWish(data.ProductId);
            }
            RedirectToAction("Index", data.RedirectTo);
        }
        //阿寶
        public void Delete(string jdata)
        {
            new WishListBLO(User.Identity.GetUserId()).DeleteWishListProduct(jdata);
            GetWishList(User.Identity.GetUserId());
        }

        [HttpPost]
        public ActionResult ShowOrder(string Key, bool boolean)
        {
            var UserId = User.Identity.GetUserId();
            var WishListBLO = new WishListBLO(UserId, Key, boolean);
            return Json(WishListBLO.OrderWishListProduct(), JsonRequestBehavior.AllowGet);
        }
    }
}