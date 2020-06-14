using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Repository.BusinessLogicLayer;
using Microsoft.AspNet.Identity;
using Epic_Game.ViewModels;

namespace Epic_Game.Controllers
{
    public class ProductController : Controller
    {
        //GET: Product
        public ActionResult Index(string ProductId)
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
                ProductViewModel VM = proBLO.GetProductViewModel("02902f18-c98a-4955-b6c7-16711c511b34", UserId);
                return View(VM);
            }
          
        }
    }
}