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
        public void DeleteWishProduct(string productId)
        {
            var lib = context.Library.FirstOrDefault(x => x.ProductID.ToString().Equals(productId));
            context.Library.Remove(lib);
            context.SaveChanges();
        }
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
    }
}