using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using System.Security.Policy;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class PayBLO
    {
        private PayDAO PayDAO { get; set; }
        public PayBLO()
        {
            PayDAO = new PayDAO();
        }

        public bool GetLibrary(string UserID,string ProductID)
        {
            var p = PayDAO.hasgame(UserID, ProductID);
            return p;
        }

        public bool Collect(string UserID, string ProductID)
        {
            var c = PayDAO.Collect(UserID, ProductID);
            return c;
        }

        public PayViewModel GetPayViewModel(string ProductID)
        {
            Product product = PayDAO.GetProduct(ProductID);
            Pack pack = PayDAO.GetPack(ProductID);
            string img = PayDAO.GetImageUrl(ProductID);
            var PayViewModel = new PayViewModel
            {
                ProductId = product.ProductID.ToString(),
                ProductName = product.ProductName,
                Publisher = product.Publisher,
                Price = product.Price,
                Discount = product.Discount,
                ImgUrl = img
            };
            return PayViewModel;
        }
    }
}