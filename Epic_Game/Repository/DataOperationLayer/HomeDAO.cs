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
                           select new StoreItems() { Url = imgs.Url, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price }).ToList();
            return product;
        }

        public List<HomeActivityViewModels> GetActivity()
        {
            var Activity = (from a in context.Activity
                            select new HomeActivityViewModels() { ActivityName = a.ActivityName, Slogan = a.Slogan, Information = a.Information, IMG = a.IMG }).ToList();
            return Activity;
        }

        public List<StoreItems> GetSales()
        {
            var Sales = (from o in context.Order
                         join p in context.Product on o.ProductID equals p.ProductID
                         join i in context.Image on p.ProductID equals i.ProductOrPack
                         where i.Location == 0
                         select new StoreItems() { ProductID = o.ProductID, Url = i.Url, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price }).ToList();

            return Sales;
        }

        public List<StoreItems> getTop5Sale(List<GroupList> groupLists)
        {
            List<StoreItems> storeItems = new List<StoreItems>();

            for (int i = 0; i < (groupLists.Count >= 5 ? 5 : groupLists.Count); i++)
            {
                var s = groupLists[i].Key;
                var storeItem =  from p in context.Product
                                 join img in context.Image on p.ProductID equals img.ProductOrPack
                                 where p.ProductID == groupLists[i].Key && img.Location == 0
                                 select new StoreItems() { ProductID = p.ProductID, Url = img.Url, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price };
                storeItems.Add(storeItem.FirstOrDefault());
            }

            return storeItems;
        }
    }
}