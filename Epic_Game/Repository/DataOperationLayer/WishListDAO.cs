using System;
using System.Collections.Generic;
using System.Linq;
using EpicGameLibrary.Models;
using System.Web;
using System.Data.Entity;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class WishListDAO
    {
        public Image img;
        public EGContext context;
        public Library library;
        public List<string> img_url = new List<string>();
        private string UserId;
        public WishListDAO(string UserId)
        {
            library = new Library();
            context = new EGContext();
            this.UserId = UserId;


        }
        public List<Library> GetWishListProduct()
        {
            return context.Library.Where(x => x.UserID == UserId && x.Condition == 1).ToList();
        }
        public string GetImg(string ProductId)
        {
            var img = context.Image.FirstOrDefault(x => x.ProductOrPack.ToString().Equals(ProductId) && x.Location == 1);
            if (img == null)
            {
                return string.Empty;
            }
            else
            {
                return img.Url;
            }
        }
        public long GetProductCount(string ProductId)
        {
            var product = context.Order.Where(x => x.ProductID.ToString().Equals(ProductId)).LongCount();
            return product;
        }
        public string GetDate(string ProductId)
        {
            var product = context.Product.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductId));
            return product.ReleaseDate.ToString("yyyy-MM-dd");
        }
        //ting
        public void AddWish(string ProductId)
        {
            var lib = new Library
            {
                ProductID = Guid.Parse(ProductId),
                UserID = UserId,
                Condition = 1
            };
            context.Library.Add(lib);
            context.SaveChanges();
        }
        //阿寶
        public void DeleteWishListProduct(string jdata)
        {
            var delete_item = context.Library.FirstOrDefault(x => x.ProductID.ToString().Equals(jdata) && x.Condition == 1);
            context.Library.Remove(delete_item);
            context.SaveChanges();
        }
    }
}