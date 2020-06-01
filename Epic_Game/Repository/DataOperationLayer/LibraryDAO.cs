using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Repository;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class LibraryDAO
    {
        public Image img;
        public EGContext context;
        public Product product;
        public Library library;
        public LibraryDAO(string UserId)
        {
            library = context.Library.Single(x => x.UserID == UserId);
        }
        public Library GetLibraryProduct()
        {
            return library;
        }
        public Image GetImg()
        {
            return img;
        }
    }
}