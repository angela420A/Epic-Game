using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Epic_Game.Models;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class HomeDAO
    {
        public static string connString;
        public SqlConnection conn;
        public EGContext context;

        public HomeDAO()
        {
            context = new EGContext();
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["EGContext"].ConnectionString;
            }
            if (conn == null)
            {
                conn = new SqlConnection(connString);
            }
        }
        public List<StoreItems> GetProducts()
        {
            var product = (from p in context.Product
                           join imgs in context.Image on p.ProductID equals imgs.ProductOrPack
                           where imgs.Location == 0
                           select new StoreItems() { Url = imgs.Url,ProductID=p.ProductID, ProductName = p.ProductName, Developer = p.Developer, Publisher = p.Publisher, Discount = p.Discount, Price = p.Price }).ToList();
            return product;
        }

        public List<HomeActivityViewModels> GetActivity()
        {
            var Activity = (from a in context.Activity
                            select new HomeActivityViewModels() { ActivityName = a.ActivityName, Slogan = a.Slogan, Information = a.Information, IMG = a.IMG }).ToList();
            return Activity;
        }


        public List<StoreItems> GetTopSales()
        {
            List<StoreItems> TopSales;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 5
                                COUNT(o.ProductID) AS Sales,img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                                from [Order] o 
                                inner join Product P on o.ProductID = p.ProductID
                                inner join [Image] img on p.ProductID = img.ProductOrPack
                                where img.Location = 0
                                GROUP BY o.ProductID,img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                                ORDER BY Sales DESC";
                TopSales = conn.Query<StoreItems>(sql).ToList();
            }
            return TopSales;
        }


        public List<StoreItems> GetTopMostRelated()
        {
            List<StoreItems> MostRelated;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 5
                            img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                            from Product p
                            inner join Image img on p.ProductID = img.ProductOrPack
                            where img.Location = 0
                            order by p.ReleaseDate desc";
                MostRelated = conn.Query<StoreItems>(sql).ToList();
            }
            return MostRelated;
        }

        public List<StoreItems> GetTopBestPrice()
        {
            List<StoreItems> MostPopular;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 5
                            img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                            from Product p
                            inner join Image img on p.ProductID = img.ProductOrPack
                            where img.Location = 0
                            order by p.Price Asc";
                MostPopular = conn.Query<StoreItems>(sql).ToList();
            }
            return MostPopular;
        }


        public List<StoreItems> GetTopBestRank()
        {
            List<StoreItems> BestRank;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 5
                            sum(c.Rank) as rank,img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                            from Product p
                            inner join Image img on p.ProductID = img.ProductOrPack
                            inner join Comment c on p.ProductID = c.ProductID
                            where img.Location = 0
                            group by c.ProductID,img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                            order by rank desc";
                BestRank = conn.Query<StoreItems>(sql).ToList();
            }
            return BestRank;
        }

        public List<StoreItems> GetTopMostFollowe()
        {
            List<StoreItems> BestRank;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select TOP 5
                                COUNT(l.ProductID) FolloweCount,img.Url,l.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                                from Product p
                                inner join Image img on p.ProductID = img.ProductOrPack
                                inner join [Library] l on p.ProductID = l.ProductID 
                                where img.Location = 0 and l.Condition = 1
                                group by l.ProductID,img.Url,p.ProductID,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price
                                order by FolloweCount desc";
                BestRank = conn.Query<StoreItems>(sql).ToList();
            }
            return BestRank;
        }

        public List<SearchViewModel> GetSearches()
        {
            List<SearchViewModel> searches;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select p.ProductID,img.Url,p.ProductName,p.Developer,p.Publisher,p.Discount,p.Price,p.Category,CONVERT(varchar(12) ,p.ReleaseDate, 111 ) As ReleaseDate
                                from Product p 
                                inner join [Image] img on p.ProductID = img.ProductOrPack
                                where img.Location = 0
                                order by ReleaseDate DESC";
                searches = conn.Query<SearchViewModel>(sql).ToList();
            }
            return searches;
        }
    }
}