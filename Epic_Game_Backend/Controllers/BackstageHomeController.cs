using Epic_Game_Backend.Repository.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backend.ActionFilter;

namespace Epic_Game_Backend.Controllers
{
    [Backend]
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

            ViewBag.pd1 = allData.PieProductName[0];
            ViewBag.pd2 = allData.PieProductName[1];
            ViewBag.pd3 = allData.PieProductName[2];
            ViewBag.pd4 = allData.PieProductName[3];
            ViewBag.pd5 = allData.PieProductName[4];
            

            return View(allData);
        }
    }
}