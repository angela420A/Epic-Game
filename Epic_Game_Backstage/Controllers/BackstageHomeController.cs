using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
    public class BackstageHomeController : Controller
    {
        private BackstageHomeBLO backstageHomeBLO;
        public BackstageHomeController()
        {
            backstageHomeBLO = new BackstageHomeBLO();
        }
        // GET: Home
        public ActionResult Index()
        {
            var allData = backstageHomeBLO.GetAllData();
            foreach (var data in allData.backstageSingleDataVM)
            {
                ViewBag.Product = data.ProductQuantity;
                ViewBag.Total = data.TotalPrice;
                ViewBag.Order = data.OrderQuantity;
                ViewBag.User = data.UserQuantity;
            }

            ViewBag.MonthData = allData.monthDataTotalPrice;

            return View(allData);
        }
    }
}