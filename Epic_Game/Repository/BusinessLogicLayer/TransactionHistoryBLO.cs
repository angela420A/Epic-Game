using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using Epic_Game.ViewModels;
using Epic_Game.Repository.DataOperationLayer;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class TransactionHistoryBLO
    {
        private TransactionHistoryDAO HisDAO { get; set; }
        private string UserId { get; set; }
        public TransactionHistoryBLO(string _UserId)
        {
            UserId = _UserId;
            HisDAO = new TransactionHistoryDAO();
        }

        public List<TransactionHistoryViewModel> GetOrders()
        {
            var res = new List<TransactionHistoryViewModel>();
            foreach(Order o in HisDAO.GetOrderModels(UserId))
            {
                res.Add(new TransactionHistoryViewModel
                {
                    PurchaseDate = o.Date.ToString("yyyy,MM,dd"),
                    ProductName = HisDAO.GetProduct(o.ProductID).ProductName,
                    Price = 1
                });
            }
            return res;
        }
    }
}