using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using WebGrease.Css.Extensions;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class LibraryBLO
    {
        private LibraryDAO libraryDAO { get; set; }

        public LibraryBLO(string UserId)
        {
            libraryDAO = new LibraryDAO(UserId);
        }
        public LibraryViewModel LibraryToView(Library l,Image i)
        {
            var viewModel = new LibraryViewModel
            {
                ProductName = l.Product.ProductName,
                Img_Url = i.Url
            };
            return viewModel;
        }
        public LibraryViewModel GetLibraryProduct()
        {
            var l = libraryDAO.GetLibraryProduct();
            var imgUrl = libraryDAO.GetImg();
            return LibraryToView(l, imgUrl);
        }

    }
}