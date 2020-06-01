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
        public ProductBLO()
        {
            ProductDAO = new ProductDAO();
        }
        public ProductViewModel GetProductViewModel(string UserId, string ProductId)
        {
            Product p = ProductDAO.GetProductModel(ProductId);
            List<Social_Media> sm = ProductDAO.GetSMModels(ProductId);
            List<Image> img = ProductDAO.GetImageModels(ProductId);
            Library library = ProductDAO.GetLibraryModesl(ProductId);

            Pack pack = ProductDAO.GetPackModel(ProductId);
            List<Comment> comment = ProductDAO.GetCommentModels(ProductId);
            return ModelToViewModel(p, sm, img, library, pack, comment);
        }

        public ProductViewModel ModelToViewModel(Product p, List<Social_Media> sm, List<Image> img, Library library, Pack pack, List<Comment> comment)
        {
            var pmv = new ProductViewModel
            {
                PD_ProductName = p.ProductName,
                PD_ProductID = p.ProductID,
                PD_ContentType = p.ContentType,
                PD_Title = p.Title,
                PD_Price = p.Price,
                PD_Discount = p.Discount,
                PD_Publisher = p.Publisher,
                PD_ReleaseDate = p.ReleaseDate.ToString(),
                PD_Category = p.Category.ToString(),
                PD_AgeRestriction = p.AgeRestriction.ToString("yyyy.MM.dd"),
                OS = p.OS,
                PD_Description = p.Description,
                Pack_image = pack.Img,
                Pack_Price = pack.Price,
                Pack_Discount = pack.Discount,
                Library_Condition = library.Condition,
            };

            pmv.SM = new List<SocialMediaViewModel>();
            foreach(var socialMedia in sm)
            {
                var smvm = new SocialMediaViewModel()
                {
                    SM_URL = socialMedia.URL,
                    SM_Community = socialMedia.Community
                };
                pmv.SM.Add(smvm);
            }

            pmv.PD_Comment = new List<CommentViewModel>();
            foreach(var Comment in comment)
            {
                var commentvm = new CommentViewModel()
                {
                    Comment_Title = Comment.Title,
                    Comment_Date = Comment.Date,
                    Comment_Description = Comment.Description,
                    Comment_Rank = Comment.Rank
                };
                pmv.PD_Comment.Add(commentvm);
            }
            pmv.PD_image = new List<ImageViewModel>();
            foreach (var Image in img)
            {
                var imagevm = new ImageViewModel()
                {
                    Image_URL = Image.Url,
                    Image_Location = Image.Location
                };
                pmv.PD_image.Add(imagevm);
            }
            return pmv;
        }
    }
}