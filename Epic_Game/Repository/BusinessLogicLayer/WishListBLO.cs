using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class WishListBLO
    {
        private WishListDAO wishlistDAO { get; set; }

        public WishListBLO(string UserId)
        {
            wishlistDAO = new WishListDAO(UserId);
        }
        public List<WishListViewModel> WishListToView(List<Library> p)
        {
            var viewModel = new List<WishListViewModel>();

            foreach (var item in p)
            {
                viewModel.Add(new WishListViewModel { ProductID = item.ProductID.ToString(),ProductName = item.Product.ProductName, Img_Url = wishlistDAO.GetImg(item.ProductID.ToString()),Price = item.Product.Price });
            }

            return viewModel;
        }
        public List<WishListViewModel> GetWishListProduct()
        {
            var l = wishlistDAO.GetWishListProduct();
            return WishListToView(l);
        }
        public void DeleteWishListProduct(string jdata)
        {
            wishlistDAO.DeleteWishListProduct(jdata);
        }
    }
}