using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class ProductBLO
    {
        private ProductDAO ProductDAO { get; set; }
        //public ProductBLO()
        //{
        //    ProductDAO = new ProductDAO();
        //}
        //public ProductViewModel GetProductViewModel(string UserId, string ProductId)
        //{
        //    Product p = ProductDAO.GetProductModel(ProductId);
//            List<Social_Media> sm = ProductDAO.GetSMModel();
//            List<Image> img = ProductDAO.GetImagebraryModel();
//            Library library = ProductDAO.GetLibraryModel();

//            Pack pack = ProductDAO.GetPackModel();
//            Comment comment = ProductDAO.GetCommentModel();
//            return ModelToViewModel(p, sm, img, library, pack, comment);
//        }

//        public ProductViewModel ModelToViewModel(Product p, List<Social_Media> sm, List<Image> img, Library library, Pack pack, Comment comment)
//        {
//            var pmv = new ProductViewModel
//            {
//                //Image_URL = p.Image,
//                PD_ProductName = p.ProductName,
//                PD_ProductID = p.ProductID,
//                PD_ContentType = p.ContentType,
//                PD_Title = p.Title,
//                PD_Price = p.Price,
//                PD_Discount = p.Discount,
//                PD_Publisher = p.Publisher,
//                PD_ReleaseDate = p.ReleaseDate,
//                PD_Category = p.Category.ToString(),
//                PD_AgeRestriction = p.AgeRestriction.ToString(),
//                OS = p.OS,
//                PD_Description = p.Description,
//                SM_URL = 
//                SM_Community = 
//                Pack_image = pack.Img,
//                Pack_Price = (decimal)pack.Price,
//                Pack_Discount = (decimal)pack.Discount,
//                Library_Condition = library.Condition,
//                Comment_Title = comment.Title,
//                Comment_Date = comment.Date,
//                Comment_Description = comment.Description,
//                Comment_Rank = comment.Rank
//            };
//            return pmv;
//        }
//    }
//}