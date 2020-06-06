using System;
using System.Collections.Generic;
using System.Linq;
using EpicGameLibrary.Models;
using System.Web;

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
        public void DeleteWishListProduct(string jdata)
        {
            var delete_item = context.Library.FirstOrDefault(x => x.ProductID.ToString().Equals(jdata) && x.Condition == 1);
            context.Library.Remove(delete_item);
            context.SaveChanges();
        }
    }
}