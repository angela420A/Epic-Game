using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class TransactionHistoryDAO
    {
        public EGContext context;
        public TransactionHistoryDAO()
        {
            context = new EGContext();
        }

        public IEnumerable GetOrderModels(string UserId)
        {
            return context.Order.Where(x => x.UserID.Equals(UserId)).ToList();
            
            //var result = from o in context.Order
            //             join p in context.Product
            //             on o.ProductID equals p.ProductID
            //             select
            //             new TransactionHistoryViewModel
            //             { PurchaseDate = o.Date.ToString("yyyy.MM.dd"), ProductName = p.ProductName, Price = p.Price };
        }

        public Product GetProduct(Guid Pid)
        {
            return context.Product.Single(x => x.ProductID.Equals(Pid));
        }
    }
}