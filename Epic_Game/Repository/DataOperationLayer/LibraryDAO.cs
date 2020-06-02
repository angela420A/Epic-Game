using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Repository;
using System.Data.Entity;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class LibraryDAO
    {
        public Image img;
        public EGContext context;
        public Library library;
        public List<string> img_url = new List<string>();
        private string UserId;
        public LibraryDAO(string UserId)
        {
            library = new Library();
            context = new EGContext();
            this.UserId = UserId;


        }
        public List<Library> GetLibraryProduct()
        {
            return context.Library.Where(x => x.UserID == UserId).ToList();
        }
        public string GetImg(string ProductId)
        {
            var img = context.Image.FirstOrDefault(x => x.ProductOrPack.ToString().Equals(ProductId) && x.Location == 0);
            if(img == null)
            {
                return string.Empty;
            }
            else
            {
                return img.Url;
            }
        }
    }
}