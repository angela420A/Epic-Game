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
        private EGContext context;
        private EGRepository<Product> repo;

        public ProductManageDAO()
        {
            context = new EGContext();
            repo = new EGRepository<Product>(context);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetAll().AsEnumerable();
        }
        
        public Image GetStoreImage(Guid ProductId)
        {
            return context.Image.FirstOrDefault(x => x.ProductOrPack.Equals(ProductId) && x.Location == 0);
        }
    }
}