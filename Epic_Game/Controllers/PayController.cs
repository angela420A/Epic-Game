using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class PayController : Controller
    {
        

        // GET: Pay
        public ActionResult Index()
        {
            String ProductID = (string)TempData["ProductId"];
            var UserId = User.Identity.GetUserId();
            PayBLO payBLO = new PayBLO();
            PayViewModel VM = payBLO.GetPayViewModel(ProductID,UserId);
            var hasgame = payBLO.GetLibrary(UserId,ProductID);
            if (hasgame == true)
            {
                return RedirectToAction("Index","Library");
            }
            else
            {
                return View(VM);
            }
            
        }

        public ActionResult Finish()
        {
            return View();
        }
    }
}