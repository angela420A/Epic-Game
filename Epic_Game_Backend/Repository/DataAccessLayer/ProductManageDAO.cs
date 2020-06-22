using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Epic_Game_Backend.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;

namespace Epic_Game_Backend.Repository.DataAccessLayer
{
    public class ProductManageDAO
    {
        public List<Product> GetAllProducts()
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Product>(_context);
                return repo.GetAll().AsEnumerable().ToList();
            }
        }

        public Product getProduct(string id)
        {
            using (var _context = new EGContext())
            {
                return _context.Product.FirstOrDefault(x => x.ProductID.ToString().Equals(id));
            }
        }

        public List<Image> getImages(string id)
        {
            using (var _context = new EGContext())
            {
                return _context.Image.Where(x => x.ProductOrPack.ToString().Equals(id)).ToList();
            }
        }

        public List<Social_Media> getMedias(string id)
        {
            using (var _context = new EGContext())
            {
                return _context.Social_Media.Where(x => x.ProductID.ToString().Equals(id)).ToList();
            }
        }

        public List<Specifications> getSpecifications(string id)
        {
            using (var _context = new EGContext())
            {
                return _context.Specifications.Where(x => x.ProductID.ToString().Equals(id)).ToList();
            }
        }

        public Image GetStoreImage(Guid ProductId)
        {
            using (var _context = new EGContext())
            {
                return _context.Image.FirstOrDefault(x => x.ProductOrPack.Equals(ProductId) && x.Location == 0);
            }
        }


        public void CreateEntity<T>(T item) where T : class
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<T>(_context);
                repo.Create(item);
                _context.SaveChanges();
            }
        }
        public void CreateEntitiies<T>(IEnumerable<T> items) where T : class
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<T>(_context);
                foreach (var item in items)
                {
                    repo.Create(item);
                }
                _context.SaveChanges();
            }
        }

        public void UpdateEntity<T>(T item) where T : class
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<T>(_context);
                repo.Update(item);
                _context.SaveChanges();
            }
        }

        public void UpdateEntities<T>(IEnumerable<T> items) where T : class
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<T>(_context);
                foreach (var item in items)
                {
                    repo.Update(item);
                }
                _context.SaveChanges();
            }
        }

        public void DeleteEntitiies<T>(IEnumerable<T> items) where T : class
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<T>(_context);
                foreach (var item in items)
                {
                    repo.Delete(item);
                } 
                _context.SaveChanges();
            }
        }

        //吳家寶
        public string connString = ConfigurationManager.ConnectionStrings["EGContext"].ConnectionString;
        SqlConnection conn;
        public void FindData()
        {
            conn = new SqlConnection(connString);
        }
        public int GetSalesVol(string id)
        {
            using (var _context = new EGContext())
            {
                return _context.Order.Count(x => x.ProductID.ToString().Equals(id));
            }
        }
        public int GetTotalIncome(string id)
        {
            using (var _context = new EGContext())
            {
                var result = _context.Order.Where(x => x.ProductID.ToString().Equals(id)).Sum(x => x.Payment);
                return result == null ? 0 : (int)result;
            }
        }
        public Chart_Data_Toarray GetSalesCount(string ProductId)
        {
            FindData();
            List<Chart_Data> SC = new List<Chart_Data>();
            Chart_Data_Toarray result = new Chart_Data_Toarray();
            using (conn = new SqlConnection(connString))
            {
                string sql = @"select datepart(DD, o.Date) as DaysOfMonth, count(datepart(DD, o.Date))as CountOfDay
                               from [Order] o
                               where
	                           datepart(mm, o.Date) =  (select  datepart(mm, getdate())) 
	                           AND
	                           datepart(YYYY, o.Date) =  (select  datepart(YYYY, getdate()))
                               AND "+
	                         $"o.ProductID = '{ProductId}' "+
                              "group by datepart(DD, o.Date)";
                SC = conn.Query<Chart_Data>(sql).ToList();
            }
            var month_num = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            result.DaysOfMonth = new int[month_num];
            result.CountOfDay = new int[month_num];

            for (int i = 1; i <= month_num; i++)
            {
                var d = i;
                var c = 0;
                foreach (var item in SC)
                {
                    if (item.DaysOfMonth == i)
                    {
                        c = item.CountOfDay;
                    }
                }
                result.DaysOfMonth.SetValue(d,i - 1);
                result.CountOfDay.SetValue(c,i - 1);
            }
            return result;
        }
    }
}