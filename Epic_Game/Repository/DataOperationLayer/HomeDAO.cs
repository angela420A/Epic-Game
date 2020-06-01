using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epic_Game.Models;
using EpicGameLibrary.Models;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class HomeDAO
    {
        
        public EGContext context;

        public HomeDAO()
        {
            context = new EGContext();

        }
        public List<HomeViewModels> GetProducts()
        {
            var product = (from p in context.Product
                          join imgs in context.Image on p.ProductID equals imgs.ProductOrPack
                          where imgs.Location == 0
                          select new HomeViewModels() { Url = imgs.Url, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price}).ToList();
            return product;
        }
    }
}