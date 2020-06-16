using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class WishListBLO
    {
        public string Key;
        public bool boolean;
        private WishListDAO wishlistDAO { get; set; }

        public WishListBLO(string UserId)
        {
            wishlistDAO = new WishListDAO(UserId);
        }
        public WishListBLO(string UserId, string key,bool Boo)
        {
            wishlistDAO = new WishListDAO(UserId);
            Key = key;
            boolean = Boo;
        }
        public List<WishListViewModel> WishListToView(List<Library> p)
        {
            var viewModel = new List<WishListViewModel>();

            foreach (var item in p)
            {
                viewModel.Add(new WishListViewModel { ProductID = item.ProductID.ToString(),ProductName = item.Product.ProductName, Img_Url = wishlistDAO.GetImg(item.ProductID.ToString()),Price = decimal.Round(item.Product.Price*item.Product.Discount,0)});
            }

            return viewModel;
        }
        public List<WishListViewModel> OrderWishListProduct(List<Library> p)
        {
            var viewModel = new List<WishListViewModel>();

            foreach (var item in p)
            {
                viewModel.Add(new WishListViewModel { ProductID = item.ProductID.ToString(), ProductName = item.Product.ProductName, Img_Url = wishlistDAO.GetImg(item.ProductID.ToString()), Price = decimal.Round(item.Product.Price * item.Product.Discount,2), ProductCount = wishlistDAO.GetProductCount(item.ProductID.ToString()),Date = wishlistDAO.GetDate(item.ProductID.ToString())});
            }
            var result = viewModel.OrderByPropertyName(Key,boolean).ToList();
            return result;
        }
        public List<WishListViewModel> GetWishListProduct()
        {
            var l = wishlistDAO.GetWishListProduct();
            return WishListToView(l);
        }
        public List<WishListViewModel> OrderWishListProduct()
        {
            var l = wishlistDAO.GetWishListProduct();
            return OrderWishListProduct(l);
        }
        //阿寶
        public void DeleteWishListProduct(string jdata)
        {
            wishlistDAO.DeleteWishListProduct(jdata);
        }
        //ting 新增愛心
        public void addWish(string ProductID)
        {
            wishlistDAO.AddWish(ProductID);
        }
        public bool ifWish(string productID)
        {
            var list = wishlistDAO.GetWishListProduct();
            return list.Any(x => x.ProductID.ToString().Equals(productID));
        }
    }
}