using ECPay.Payment.Integration;
using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class PayController : Controller
    {
        private PayBLO PayBLO { get; set; }

        public PayController()
        {
            PayBLO = new PayBLO();
        }

        // GET: Pay
        public ActionResult Index()
        {
            //string ProductID = (string)TempData["ProductId"];
            string ProductID = "d75ebeb8-4bc7-44b3-86bf-904ec05a5686";
            var UserId = User.Identity.GetUserId();
            PayViewModel VM = PayBLO.GetPayViewModel(ProductID);
            var hasgame = PayBLO.GetLibrary(UserId,ProductID);
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (hasgame == true)
                {
                    return RedirectToAction("Index","Library");
                }
                else
                {
                    return View(VM);
                }
            }
        }

        public ActionResult Finish()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Finish([Bind(Include = "ProductId,ProductName")] PayViewModel info)
        //{
        //    return View();
        //}


        public string ToECpay(string jdata)
        {
            PayViewModel VM = PayBLO.GetPayViewModel(jdata);
            Session["Name"] = VM.ProductName;
            Session["P"] = string.Format("{0:####.#}", Session["Price"]= VM.Price);

            return "../EpicGameCheckOut.aspx";
        }
    }
}