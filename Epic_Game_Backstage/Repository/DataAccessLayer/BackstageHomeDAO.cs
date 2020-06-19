using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class BackstageHomeDAO
    {
        private static string connString;
        public SqlConnection conn;
        //private EGContext context;

        public BackstageHomeDAO()
        {
            //context = new EGContext();
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["EGContext"].ConnectionString;
            }
        }

        public List<BackstageHomeViewModel> getSingledata()
        {
            List<BackstageHomeViewModel> backstageHomeVM;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"SELECT 
	                                COUNT(p.ProductID) AS ProductQuantity, 
	                                SUM(o.Payment) AS TotalPrice, 
	                                COUNT(o.OrderID) AS OrderQuantity, 
	                                COUNT(u.Id) AS UserQuantity
                                FROM Product p
                                inner join [Order] o on o.ProductID = p.ProductID
                                inner join Library l on p.ProductID = l.ProductID
                                inner join AspNetUsers u on l.UserID = u.Id
                               ";

                backstageHomeVM = conn.Query<BackstageHomeViewModel>(sql).ToList();

                //string totalPrice = @"select SUM(Payment) from [Order]";
                //string orderQuantity = @"select COUNT(*) from [Order]";
                //string userQuantity = @"select COUNT(*) from AspNetUsers";

                //backstageHomeVM = new List<BackstageHomeViewModel>()
                //{
                //    new BackstageHomeViewModel
                //    {
                //        ProductQuantity = conn.QueryMultiple(productQuantity).ToString(),
                //        TotalPrice = conn.Query<BackstageHomeViewModel>(totalPrice).ToString(),
                //        OrderQuantity = conn.Query<BackstageHomeViewModel>(orderQuantity).ToString(),
                //        UserQuantity = conn.Query<BackstageHomeViewModel>(userQuantity).ToString()
                //    }
                //};

            }
            return backstageHomeVM;
        }
    }
}