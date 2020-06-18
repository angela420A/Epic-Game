﻿using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class OrderManageDAO
    {
        EGContext ordercontext;

        public OrderManageDAO()
        {
            ordercontext = new EGContext();
        }
        public Order GetOrderdata(string orderID)
        {
            return ordercontext.Order.FirstOrDefault(x => x.OrderID.ToString().Equals(orderID));
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
        public List<Order> Getallorderdata()
        {
            return ordercontext.Order.ToList();
        }

        public void updatedao(OrderManageViewModel data)
        {
            ordercontext.Order.AddOrUpdate(Convert(data));
            ordercontext.SaveChanges();
        }
        public void deletedao(Guid guid)
        {
            var deleteo = ordercontext.Order.FirstOrDefault(x => x.OrderID == guid);
            ordercontext.Order.Remove(deleteo);
            ordercontext.SaveChanges();
        }
    }
}