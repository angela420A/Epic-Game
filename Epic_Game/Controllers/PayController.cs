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

        EGContext context = new EGContext();

        private PayBLO PayBLO { get; set; }

        public PayController()
        {
            PayBLO = new PayBLO();
        }

        // GET: Pay
        public ActionResult Index(string ProductId)
        {
            //string ProductID = (string)TempData["ProductId"];
            var UserId = User.Identity.GetUserId();
            PayViewModel VM = PayBLO.GetPayViewModel(ProductId);
            var hasgame = PayBLO.GetLibrary(UserId, ProductId);
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (hasgame == true)
                {
                    return RedirectToAction("Index", "Library");
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

        public void CreatOrder()
        {
            string ProductID = "d75ebeb8-4bc7-44b3-86bf-904ec05a5686";
            var UserId = User.Identity.GetUserId();
            var collect = PayBLO.Collect(UserId, ProductID);
            Guid g = Guid.NewGuid();


            Order order = new Order { OrderID = g, UserID = UserId, ProductID = Guid.Parse(ProductID), Date = DateTime.Now };
            Library library = new Library { UserID = UserId, ProductID = Guid.Parse(ProductID), Condition = 0 };
            context.Order.Add(order);
            context.Library.Add(library);
            context.SaveChanges();

        }


        public string ToECpay(string jdata)
        {
            PayViewModel VM = PayBLO.GetPayViewModel(jdata);
            Session["Name"] = VM.ProductName;
            Session["P"] = string.Format("{0:####.#}", Session["Price"] = VM.Price);

            return "../EpicGameCheckOut.aspx";
        }


    }
}