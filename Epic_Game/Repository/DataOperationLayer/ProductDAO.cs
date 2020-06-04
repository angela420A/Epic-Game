using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using Microsoft.Owin.Security.Provider;
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

        //public T GetModel<T>(string ID) where T : class
        //{
        //    var repo = new EGRepository<T>(context);
        //    var t = context.Entry<T>.GetType();
        //    if (context.Entry<T>)
        //    {
        //        return repo.GetAll().Single(x => x.ProductID.ToString().Equals(ID));
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public Product GetProductModel(string ProductID)
        {
            return context.Product.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID));
        }

        public Pack GetPackModel(string PackID)
        {
            return context.Pack.FirstOrDefault(x => x.PackID.ToString().Equals(PackID));
        }
        public List<Social_Media> GetSMModels(string ProductID)
        {
            return context.Social_Media.Where(x => x.ProductID.ToString().Equals(ProductID)).ToList();
        }
        public List<Comment> GetCommentModels(string ProductID)
        {
            return context.Comment.Where(x => x.ProductID.ToString().Equals(ProductID)).ToList();
        }
        public Library GetLibraryModesl(string ProductID)
        {
            return context.Library.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID));

        }
        public List<Image> GetImageModels(string ProductOrPack)
        {
            return context.Image.Where(x => x.ProductOrPack.ToString().Equals(ProductOrPack)).ToList();
        }
        public Specifications GetSpecificationsModel(string ProductID)
        {
            return context.Specifications.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID));
        }
    }
}