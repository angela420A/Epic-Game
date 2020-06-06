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
            ProductBLO proBLO = new ProductBLO();
            
            ProductViewModel VM = proBLO.GetProductViewModel("d75ebeb8-4bc7-44b3-86bf-904ec05a5686", UserId);

            return View(VM);
        }


    }
}