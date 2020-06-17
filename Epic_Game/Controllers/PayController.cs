using Dapper;
using ECPay.Payment.Integration;
using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        private string SQLConnectionStr = ConfigurationManager.ConnectionStrings["EGContext"].ConnectionString;
        public ActionResult CreatOrder(string productid)
        {
            var UserId = User.Identity.GetUserId();
            var collect = PayBLO.Collect(UserId, productid);
            Guid g = Guid.NewGuid();
            PayViewModel VM = PayBLO.GetPayViewModel(productid);
            var price = decimal.Round(VM.Discount * VM.Price);
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                var datas = new { OID = g, UID = UserId, PID = productid, DATE = DateTime.Now, PRICE = price };
                if (collect == true)
                {
                    string sql = "Insert into [Order] values (@OID, @UID, @PID, @DATE, @PRICE)" +
                                 "Update Library set Condition= 0 Where UserID=@UID and ProductID=@PID";
                    conn.Execute(sql, datas);
                }
                else
                {
                    string sql = "Insert into [Order] values (@OID, @UID, @PID, @DATE, @PRICE)" +
                                 "Insert into Library(UserID, ProductID, Condition) values (@UID, @PID , 0)";
                    conn.Execute(sql, datas);
                }
                conn.Close();
            }
            return RedirectToAction("Finish");
        }


        public string ToECpay(string jdata)
        {
            PayViewModel VM = PayBLO.GetPayViewModel(jdata);
            Session["ProductId"] = VM.ProductId;
            Session["Name"] = VM.ProductName;
            Session["P"] = string.Format("{0:####.#}", Session["Price"] = VM.Price * VM.Discount);

            return "../EpicGameCheckOut.aspx";
        }


    }
}