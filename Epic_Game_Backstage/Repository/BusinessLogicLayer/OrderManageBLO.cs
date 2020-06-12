using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class OrderManageBLO
    {
        private EGContext db = new EGContext();
        private OrderManageDAO orderDAO { get; set; }

        public OrderManageBLO()
        {
            orderDAO = new OrderManageDAO();
        }
        public OrderManageViewModel GetOrderdata(string orderID)
        {
            Order o = orderDAO.GetOrderdata(orderID);
            return ModelViewModel(o);
        }


        public OrderManageViewModel getdata(string guid)
        {
            var result = orderDAO.GetOrderdata(guid);
            if (result != null)
            {
                return new OrderManageViewModel()
                {
                    OrderID = result.OrderID,
                    UserID = result.UserID,
                    ProductID = result.ProductID,
                    Date = result.Date/*.ToString("yyyy.MM.dd")*/,
                    Payment = result.Payment
                };
            }
            else
            {
                return null;
            }
        }
        public OrderManageViewModel ModelViewModel(Order o)
        {
            var ovm = new OrderManageViewModel
            {
                OrderID = o.OrderID,
                UserID = o.UserID,
                ProductID = o.ProductID,
                Date = o.Date/*.ToString("yyyy.MM.dd")*/,
                Payment = o.Payment
            };
            return ovm;
        }


        public Order Convert(OrderManageViewModel ovm)
        {
            return new Order()
            {
                OrderID = ovm.OrderID,
                UserID = ovm.UserID,
                ProductID = ovm.ProductID,
                Date = ovm.Date/*.ToString("yyyy.MM.dd")*/,
                Payment = ovm.Payment
            };
        }


        public bool addorder(OrderManageViewModel data)
        {
            data.OrderID = Guid.NewGuid();
            db.Order.Add(Convert(data));
            db.SaveChanges();
            return true;
        }
        public bool updateorder(OrderManageViewModel data)
        {
            db.Order.AddOrUpdate(Convert(data));
            db.SaveChanges();
            return true;
        }
        public bool deleteorder(Guid guid)
        {
            var deleteo = db.Order.FirstOrDefault(x => x.OrderID == guid);
            db.Order.Remove(deleteo);
            db.SaveChanges();
            return true;
        }
    }
}