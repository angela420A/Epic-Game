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
        public List<LibraryViewModel> LibraryToView(List<Library> p)
        {
            var viewModel = new List<LibraryViewModel>();
            
            foreach (var item in p)
            {
                viewModel.Add (new LibraryViewModel { ProductName = item.Product.ProductName, Img_Url = libraryDAO.GetImg(item.ProductID.ToString())});
            }

            return viewModel;
        }
        public List<LibraryViewModel> GetLibraryProduct()
        {
            var l = libraryDAO.GetLibraryProduct();
            return LibraryToView(l);
        }

    }
}