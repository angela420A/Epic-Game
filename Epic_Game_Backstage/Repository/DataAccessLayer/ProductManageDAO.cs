using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}