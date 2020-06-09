using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
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
    }
}