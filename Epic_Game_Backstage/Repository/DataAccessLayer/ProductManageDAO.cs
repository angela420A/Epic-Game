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
            using(var _context = new EGContext())
            {
                var repo = new EGRepository<Social_Media>(_context);
                foreach(var m in medias)
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
        public EGContext context =new EGContext();
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
    }
}