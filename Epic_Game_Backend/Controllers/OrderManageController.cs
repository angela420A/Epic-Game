using Epic_Game_Backend.Repository.BusinessLogicLayer;
using Epic_Game_Backend.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backend.ActionFilter;

namespace Epic_Game_Backend.Controllers
{
    [Backend]
    public class OrderManageController : Controller
    {

        //private EGContext db = new EGContext();
        // GET: OrderManage
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult ordersearchsort(string sort, string nowsort)
        {
            if (string.IsNullOrEmpty(sort) && string.IsNullOrEmpty(sort))
            {
                sort = "Date";
                nowsort = "Date";
            }
            //目前的會等於現在sort名稱的，看是日期、錢等等
            ViewBag.Nowsort = sort;

            bool order = sort.Equals(nowsort);
            var orderVMlist = new OrderManageBLO().NewsViewModelstolist().OrderByPropertyName(sort, !order).ToList();
            if (order) ViewBag.Nowsort = null;
            return View(orderVMlist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ordersearchsort(string searchname, string option, string search)
        {
            OrderManageBLO orderManageBLO = new OrderManageBLO();
            searchname = option;
            List<OrderManageViewModel> orderlist = orderManageBLO.Searchorder(searchname, search);
            return View(orderlist);
        }
        public ActionResult Edit(string id)
        {
            OrderManageBLO orderManageBLO = new OrderManageBLO();
            return View(orderManageBLO.getdata(id));
        }

        // POST: orders1/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderManageViewModel data)
        {
            OrderManageBLO orderManageBLO = new OrderManageBLO();
            if (orderManageBLO.updateorder(data))
            {
                return RedirectToAction("ordersearchsort");
            }
            else
            {
                ViewBag.Status = false;
                return View(data);
            }
        }
        public ActionResult Delete(Guid id)
        {
            OrderManageBLO orderManageBLO = new OrderManageBLO();
            if (orderManageBLO.deleteorder(id))
            {
                ViewBag.Status = true;
            }
            else
            {
                ViewBag.Status = false;
            }
            return RedirectToAction("ordersearchsort");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}