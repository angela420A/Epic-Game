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

        public List<BackstageSingleDataVM> getSingledata()
        {
            List<BackstageSingleDataVM> backstageHomeVM;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"SELECT 
		                         COUNT(p.ProductID) AS ProductQuantity, 
		                         (select	CAST(SUM(o.Payment) AS float)
			from [Order] o) AS TotalPrice, 
		                         (select COUNT(o.OrderID)
			from [Order] o )AS OrderQuantity, 
		                         (select COUNT(u.Id)
			from [AspNetUsers] u) AS UserQuantity
		                        FROM Product p
		                       ";

                backstageHomeVM = conn.Query<BackstageSingleDataVM>(sql).ToList();

            }
            return backstageHomeVM;
        }
        public List<BackstageChartLineVM> getMonthData()
        {
            List<BackstageChartLineVM> backstageHomeVM;

            using (conn = new SqlConnection(connString))
                {
                    string sql = @"SELECT 
	                            SUM(o.Payment) AS January,
	                            (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'February') AS February,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'March') AS March,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'April') AS April,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'May') AS May,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'June') AS June,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'July') AS July,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'August') AS August,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'September') AS September,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'October') AS October,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'November') AS November,
	                             (select SUM(o.Payment)
	                             from [Order] o
	                             WHERE DATENAME(month, o.Date) = 'December') AS December
                            from [Order] o
                            WHERE DATENAME(month, o.Date) = 'January'";
                backstageHomeVM = conn.Query<BackstageChartLineVM>(sql).ToList();
            }
            return backstageHomeVM;
        }

        public List<BackstageChartLineVM002> getMonthCount()
        {
            List<BackstageChartLineVM002> backstageChartLineVM002;
            using (conn = new SqlConnection(connString))
            {
                string sql = @"SELECT 
								COUNT(o.ProductID) AS JanCount,
								(select COUNT(o.ProductID)
								from [Order] o
								where datename(month, o.Date) = 'February') AS FebCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'March') AS MarCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'April') AS AprCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'May') AS MayCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'June') AS JunCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'July') AS JulCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'August') AS AugCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'September') AS SepCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'October') AS OctCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'November') AS NovCount,
								(select COUNT(o.ProductID)
								from [Order] o 
								where datename(month, o.Date) = 'December') AS DeceCount
							FROM [Order] o 
							WHERE DATENAME(month, o.Date) = 'January'";
				backstageChartLineVM002 = conn.Query<BackstageChartLineVM002>(sql).ToList();
            }
			return backstageChartLineVM002;
        }

        public IEnumerable<BackstageChartLineVMPie> GetProductTop5()
        {
            string SQLcommand = @"select top 5
	                                p.ProductName,
	                                count(*) as count
                                  from [Order] o
                                  inner join Product p on o.ProductID = p.ProductID 
                                  group by p.ProductName
                                  order by count desc";
            IEnumerable<BackstageChartLineVMPie> result;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                result = conn.Query<BackstageChartLineVMPie>(SQLcommand);
            }
            return result;
        }
    }
}