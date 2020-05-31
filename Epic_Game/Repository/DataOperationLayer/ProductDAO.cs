using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.DataOperationLayer
{
    
    public class ProductDAO
    {
        EGContext context;

        public ProductDAO()
        {
            context = new EGContext();
        }
        public Product GetProductModel(string ProductID)
        {
            var repo = new EGRepository<Product>(context);
            return repo.GetAll().Single(x => x.ProductID.ToString().Equals(ProductID));
        }
        //public Pack GetPackModel(string PackID)
        //{
        //    var repoPack = new EGRepository<Pack>(context);
        //    return repoPack.GetAll().Single(x => x.PackID.ToString().Equals(PackID));
        //}


    }
}