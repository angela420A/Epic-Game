using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Repository.BusinessLogicLayer;
using Microsoft.AspNet.Identity;
using Epic_Game.ViewModels;
using Newtonsoft.Json;

namespace Epic_Game.Controllers
{
    public class ProductController : Controller
    {
        //GET: Product
        public ActionResult Index(string id)
        {
            var UserId = User.Identity.GetUserId();
            //如果使用者沒有登入,則會回傳到登入介面
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ProductBLO proBLO = new ProductBLO();
                //ProductViewModel VM = proBLO.GetProductViewModel("02902f18-c98a-4955-b6c7-16711c511b34", UserId);
                ProductViewModel VM = proBLO.GetProductViewModel(id, UserId);
                return View(VM);
            }

        }
        //新增評論
        public ActionResult CreateComment(string jdata)
        {
            CommentPushViewModel CVM = JsonConvert.DeserializeObject<CommentPushViewModel>(jdata);
            ProductBLO blo = new ProductBLO();
            var comments = blo.UploadComment(CVM , User.Identity.GetUserId());
            return Json(comments, JsonRequestBehavior.AllowGet);//允許用戶get資料  以json的方式回傳到ajax
        }


        //public ActionResult DeleteComment(string jdata)
        //{
        //    CommentPushViewModel CVM = JsonConvert.DeserializeObject<CommentPushViewModel>(jdata);
        //    ProductBLO blo = new ProductBLO();
        //    blo.DeleteComment(CVM.Comment_ProductID, User.Identity.GetUserId());
        //    return View();
        //}
        //public ActionResult UploadComment(string jdata)
        //{
        //    CommentPushViewModel CVM = JsonConvert.DeserializeObject<CommentPushViewModel>(jdata);
        //    ProductBLO blo = new ProductBLO();
        //    blo.UploadComment(CVM, User.Identity.GetUserId());
        //    return View();
        //}
    }
}