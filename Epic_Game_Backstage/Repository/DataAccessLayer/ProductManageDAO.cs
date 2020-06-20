using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
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

        public Image GetStoreImage(Guid ProductId)
        {
            using (var _context = new EGContext())
            {
                return _context.Image.FirstOrDefault(x => x.ProductOrPack.Equals(ProductId) && x.Location == 0);
            }

        }

        public void CreateProduct(Product p)
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Product>(_context);
                repo.Create(p);
                _context.SaveChanges();
            }
        }

        public void CreateImages(IList<Image> images)
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Image>(_context);
                foreach (var img in images)
                {
                    repo.Create(img);
                }
                _context.SaveChanges();
            }
        }

        public void CreateSocialMedia(IList<Social_Media> medias)
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Social_Media>(_context);
                foreach (var m in medias)
                {
                    repo.Create(m);
                }
                _context.SaveChanges();
            }
        }

        public void CreateSpecification(IList<Specifications> specifications)
        {
            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Specifications>(_context);
                foreach (var s in specifications)
                {
                    repo.Create(s);
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
        public EGContext context = new EGContext();
        public Product GetDetial(string id)
        {
            return context.Product.SingleOrDefault(x => x.ProductID.ToString().Equals(id));
        }
        public int GetSalesVol(string id)
        {
            return context.Order.Count(x => x.ProductID.ToString().Equals(id));
        }
        public int GetTotalIncome(string id)
        {
            var result = context.Order.Where(x => x.ProductID.ToString().Equals(id)).Sum(x => x.Payment);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return (int)result;
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