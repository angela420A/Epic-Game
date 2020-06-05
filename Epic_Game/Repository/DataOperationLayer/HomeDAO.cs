using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Epic_Game.Models;
using Epic_Game.ViewModels;
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
        public List<StoreItems> GetProducts()
        {
            var product = (from p in context.Product
                          join imgs in context.Image on p.ProductID equals imgs.ProductOrPack
                          where imgs.Location == 0
                          select new StoreItems() { Url = imgs.Url, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price}).ToList();
            return product;
        }

        public List<HomeActivityViewModels> GetActivity()
        {
            var Activity = (from a in context.Activity
                            select new HomeActivityViewModels() { ActivityName = a.ActivityName, Slogan = a.Slogan, Information = a.Information, IMG = a.IMG }).ToList();
            return Activity;
        }

        //public List<test> GetTopSales()
        //{
        //    //var Sales = context.Order.GroupJoin(context.Product,
        //    //                            o => o.ProductID,
        //    //                            p => p.ProductID,
        //    //                            (o, p) => new
        //    //                            {
                                            
        //    //                            });
        //    return null;
        //}

        //public class test
        //{
        //    public string Url { get; set; }
        //    public string ProductName { get; set; }
        //    public string Developer { get; set; }
        //    public string Publisher { get; set; }
        //    public decimal Discount { get; set; }
        //    [Column(TypeName = "money")]
        //    public decimal Price { get; set; }

        //    public int Count { get; set; }
        //}
    }
}