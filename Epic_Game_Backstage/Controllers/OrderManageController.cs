using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
    public class OrderManageController : Controller
    {

        private EGContext db = new EGContext();
        // GET: OrderManage
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult ordersearchsort(string sort, string nowsort)
        {
            ViewBag.Nowsort = sort;
            //目前的會等於現在sort名稱的，看是日期、錢等等
            sort = string.IsNullOrEmpty(sort) ? "ProductID" : sort;
            //看是如果現在是空的話就拿money來當排序
            List<OrderManageViewModel> orderVMlist = new List<OrderManageViewModel>();
            var ordervm = new OrderManageViewModel();
            var order1 = db.Order.ToList();
            OrderManageBLO orderBLO = new OrderManageBLO();
            foreach (var item in order1)
            {
                OrderManageViewModel vm = orderBLO.GetOrderdata(item.OrderID.ToString());
                orderVMlist.Add(vm);
            }
            if (sort.Equals(nowsort))
            {
                orderVMlist = orderVMlist.OrderByPropertyName(sort, false).ToList();
                ViewBag.Nowsort = null;
            }
            else
            {
                orderVMlist = orderVMlist.OrderByPropertyName(sort).ToList();
            }    
            return View(orderVMlist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ordersearchsort(string option, string sort, string nowsort, string search, string UserID, string ProductID, string Date, string Payment)
        {
            ViewBag.Nowsort = sort;
            //目前的會等於現在sort名稱的，看是日期、錢等等
            sort = string.IsNullOrEmpty(sort) ? "ProductID" : sort;
            //看是如果現在是空的話就拿money來當排序
            List<OrderManageViewModel> orderVMlist = new List<OrderManageViewModel>();
            var order1 = db.Order.ToList();
            OrderManageBLO orderBLO = new OrderManageBLO();
            foreach (var item in order1)
            {
                OrderManageViewModel vm = orderBLO.GetOrderdata(item.OrderID.ToString());
                orderVMlist.Add(vm);
            }



            IQueryable<OrderManageViewModel> orderVMlistiqu1 = null;
            var orderVMlistiqu = orderVMlist.AsQueryable();
            UserID = search;
            if (option == "UserID")
            {
                if (string.IsNullOrEmpty(UserID))
                {
                    return Content("UserID名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (UserID == "*")
                //*等於全部
                {
                    orderVMlistiqu1 = orderVMlistiqu;
                }
                else
                {
                    orderVMlistiqu1 = orderVMlistiqu.Where(x => x.UserID.Contains(UserID));
                }
                if (orderVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            ProductID = search;
            if (option == "ProductID")
            {
                if (string.IsNullOrEmpty(ProductID))
                {
                    return Content("ProductID名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (ProductID == "*")
                //*等於全部
                {
                    orderVMlistiqu1 = orderVMlistiqu;
                }
                else
                {
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    orderVMlistiqu1 = orderVMlistiqu.Where(x => x.ProductID.ToString().Contains(ProductID));
                }
                if (orderVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            Date = search;
            if (option == "Date")
            {
                if (string.IsNullOrEmpty(Date))
                {
                    return Content("Date名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (Date == "*")
                //*等於全部
                {
                    orderVMlistiqu1 = orderVMlistiqu;
                }
                else
                {
                    orderVMlistiqu1 = orderVMlistiqu.Where(x => x.Date.ToString().Contains(Date));
                }
                if (orderVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            Payment = search;
            if (option == "Payment")
            {
                if (string.IsNullOrEmpty(Payment))
                {
                    return Content("Payment名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (Payment == "*")
                //*等於全部
                {
                    orderVMlistiqu1 = orderVMlistiqu;
                }
                else
                {
                    orderVMlistiqu1 = orderVMlistiqu.Where(x => x.Payment.ToString().Contains(Payment));
                }
                if (orderVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            return View(orderVMlistiqu1);

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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}