using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using EpicGameLibrary.Service;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class ProductBLO
    {
        private ProductDAO ProductDAO { get; set; }
        public ProductBLO()
        {
            ProductDAO = new ProductDAO();
        }
        public ProductViewModel GetProductViewModel(string ProductId,string UserId )
        {

            Product p = ProductDAO.GetProductModel(ProductId);
            List<Social_Media> sm = ProductDAO.GetSMModels(ProductId);
            List<Image> img = ProductDAO.GetImageModels(ProductId);
            Library library = ProductDAO.GetLibraryModesl(ProductId, UserId);
            Pack pack = ProductDAO.GetPackModel(ProductId);
            List<Comment> comment = ProductDAO.GetCommentModels(ProductId);
            List<Specifications> spe = ProductDAO.GetSpecificationsModel(ProductId);
            return ModelToViewModel(p, sm, img, library, pack, comment,spe);
        }

        public ProductViewModel ModelToViewModel(Product p, List<Social_Media> sm, List<Image> img, Library library, Pack pack, List<Comment> comment, List<Specifications> spe)
        {
            var pmv = new ProductViewModel
            {
                PD_ProductName = p.ProductName,
                PD_ProductID = p.ProductID.ToString(),
                PD_ContentType = p.ContentType,
                PD_Title = p.Title,
                PD_Price = p.Price,
                PD_Discount = p.Discount,
                PD_Developer = p.Developer,
                PD_Publisher = p.Publisher,
                PD_ReleaseDate = p.ReleaseDate.ToString("yyyy.MM.dd"),
                PD_Category = new GameType().getGameType(p.Category),
                PD_AgeRestriction = p.AgeRestriction.ToString(),
                OS = p.OS,
                PD_Description = p.Description,
                PD_Languages = p.LanguagesSupported,
                PD_Privary = p.PrivacyPolicy,
                PD_PrivaryUrl = p.PrivacyPolicyUrl,

                //Pack_image = pack.Img,
                //Pack_Price = pack.Price,
                //Pack_Discount = pack.Discount,
                //Library_Condition = library == null ? null : library.Condition
            };

            pmv.SM = new List<SocialMediaViewModel>();
            foreach (var socialMedia in sm)
            {
                var smvm = new SocialMediaViewModel()
                {
                    SM_URL = socialMedia.URL,
                    SM_Community = socialMedia.Community
                };
                pmv.SM.Add(smvm);
            }

            pmv.PD_Comment = new List<CommentViewModel>();
            foreach (var Comment in comment)
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
                    Image_Location = Image.Location,
                    Media_Type = Image.Type
                };
                pmv.PD_image.Add(imagevm);
            }

            pmv.PD_Specifications = new List<SpecificationsViewModel>();
            foreach (var Specifications in spe)
            {
                var spevm = new SpecificationsViewModel()
                {
                    SPE_OS = Specifications.OS,
                    SPE_CPU = Specifications.CPU,
                    SPE_GPU = Specifications.GPU,
                    SPE_Processor = Specifications.Processor,
                    SPE_RAM = Specifications.RAM,
                    SPE_Memory = Specifications.Memory,
                    SPE_Storage = Specifications.Storage,
                    SPE_GraphiceCard = Specifications.GraphiceCard,
                    SPE_HDD = Specifications.HDD,
                    SPE_DirectX = Specifications.DirectX,
                    SPE_Additional = Specifications.Additional_Features,
                    SPE_Type = Specifications.Type.ToString()
                };
                pmv.PD_Specifications.Add(spevm);
            }
            return pmv;
        }
    }
}