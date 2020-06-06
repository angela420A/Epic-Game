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

        //public ActionResult ECPay()
        //{
        //    var tradeInfo = new AllInOne()
        //    {
        //        /* 服務參數 */
        //        ServiceMethod = HttpMethod.HttpPOST,//介接服務時，呼叫 API 的方法
        //        ServiceURL = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5",//要呼叫介接服務的網址
        //        HashKey = "5294y06JbISpM5x9",//ECPay提供的Hash Key
        //        HashIV = "v77hoKGq4kWxNNIS",//ECPay提供的Hash IV
        //        MerchantID = "2000132",//ECPay提供的特店編號
        //    };

        //    var postData = tradeInfo.CheckOut();

        //    return PartialView();
        //}
    }
}