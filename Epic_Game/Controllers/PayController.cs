using Dapper;
using ECPay.Payment.Integration;
using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Index()
        {
            //string ProductID = (string)TempData["ProductId"];
            string ProductID = "d75ebeb8-4bc7-44b3-86bf-904ec05a5686";
            var UserId = User.Identity.GetUserId();
            PayViewModel VM = PayBLO.GetPayViewModel(ProductID);
            var hasgame = PayBLO.GetLibrary(UserId, ProductID);
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
        public void CreatOrder()
        {
            string ProductID = "d75ebeb8-4bc7-44b3-86bf-904ec05a5686";
            var UserId = User.Identity.GetUserId();
            var collect = PayBLO.Collect(UserId, ProductID);
            Guid g = Guid.NewGuid();
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                var datas = new { OID = g, UID = UserId, PID = ProductID, DATE = DateTime.Now};
                if (collect == true) 
                { 
                    string sql = "Insert into Order(OrderID, UserID, ProductID, Date) value (@OID, @UID, @PID, @DATE)" +
                                 "Update Library set Condition= 0 Where UserID=@UID and ProductID=@PID";
                    conn.Execute(sql, datas);
                }
                else
                {
                    string sql = "Insert into Order(OrderID, UserID, ProductID, Date) value (@OID, @UID, @PID, @DATE)" +
                                 "Insert into Library(UserID, ProductID, Condition) value (@UID, @PID , 0)";
                    conn.Execute(sql, datas);
                }
                conn.Close();
            }

            //if (collect == true)
            //{
            //    //int affectedRow = 0;
            //    using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            //    {
                    
            //        conn.Close();
            //    }
            //}
            //else
            //{
            //    Order order = new Order { OrderID = g, UserID = UserId, ProductID = Guid.Parse(ProductID), Date = DateTime.Now };
            //    Library library = new Library { UserID = UserId, ProductID = Guid.Parse(ProductID), Condition = 0 };
            //    context.Order.Add(order);
            //    context.Library.Add(library);
            //}

            //context.SaveChanges();

        }


        public string ToECpay(string jdata)
        {
            PayViewModel VM = PayBLO.GetPayViewModel(jdata);
            Session["Name"] = VM.ProductName;
            Session["P"] = string.Format("{0:####.#}", Session["Price"] = VM.Price * VM.Discount);

            return "../EpicGameCheckOut.aspx";
        }


    }
}