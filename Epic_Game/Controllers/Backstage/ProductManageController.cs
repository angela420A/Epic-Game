using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpicGameLibrary.Models;

namespace Epic_Game.Controllers.Backstage
{
    public class ProductManageController : Controller
    {
        // GET: ProductManage
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName, Price, Discount")] Product p)
        {
            return View();
        }
    }
}