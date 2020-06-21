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
            Library library = ProductDAO.GetLibraryModels(ProductId, UserId);
            Pack pack = ProductDAO.GetPackModel(ProductId);
            List<Comment> comment = ProductDAO.GetCommentModels(ProductId);
            Comment UserComm = ProductDAO.GetUserComm(ProductId, UserId);
            List<Specifications> spe = ProductDAO.GetSpecificationsModel(ProductId);
            
            return ModelToViewModel(p, sm, img, library, pack, comment, UserComm, spe);
        }

        public ProductViewModel ModelToViewModel(Product p, List<Social_Media> sm, List<Image> img, Library library, Pack pack, List<Comment> comment, Comment UserComm, List<Specifications> spe)
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
                Library_Condition = library == null ? 2 : library.Condition
            };

            //SocialMediaViewModel
            pmv.SM = new List<SocialMediaViewModel>();
            foreach (var socialMedia in sm)
            {
                var smvm = new SocialMediaViewModel()
                {
                    SM_URL = socialMedia.URL,
                    SM_Community = socialMedia.Community,
                    SM_ProductID = socialMedia.ProductID.ToString()
                };
                pmv.SM.Add(smvm);
            }

            //CommentViewModel
            var _Comment = new CommentViewModel();
            _Comment.Comment_ProductID = p.ProductID.ToString();
            _Comment.Comments = new List<CommentItem>();
            foreach (var item in comment)
            {
                _Comment.Comments.Add(CommMaping(item));
            }
            if(UserComm != null) {
                _Comment.UserComment = CommMaping(UserComm);
            }             
            pmv.PD_Comment = _Comment;

            //ImageViewModel
            pmv.PD_image = new List<ImageViewModel>();
            foreach (var Image in img)
            {
                var imagevm = new ImageViewModel()
                {
                    Image_URL = Image.Url,
                    Image_Location = Image.Location,
                    Media_Type = Image.Type
                };
                IsVideo(imagevm);
                pmv.PD_image.Add(imagevm);
            }

            //SpecificationsViewModel
            pmv.PD_Specificatoin = new SpecificationsViewModel[4];
            foreach (var specifications in spe)
            {
                int i = specifications.Type;
                pmv.PD_Specificatoin[i] = new SpecificationsViewModel()
                {
                    SPE_OS = specifications.OS,
                    SPE_CPU = specifications.CPU,
                    SPE_GPU = specifications.GPU,
                    SPE_Processor = specifications.Processor,
                    SPE_RAM = specifications.RAM,
                    SPE_Memory = specifications.Memory,
                    SPE_Storage = specifications.Storage,
                    SPE_GraphiceCard = specifications.GraphiceCard,
                    SPE_HDD = specifications.HDD,  
                    SPE_DirectX = specifications.DirectX,
                    SPE_Additional = specifications.Additional_Features,
                    SPE_Type = specifications.Type
                };
            }
            return pmv;
        }
        public void IsVideo(ImageViewModel vm)
        {
            if (vm.Media_Type == 2)
            {
                vm.Image_URL += "?enablejsapi=1&amp;rel=0&amp;showinfo=0&amp;iv_load_policy=3";               
            }
        }
        public CommentItem CommMaping(Comment c)
        {
            return new CommentItem
            {
                Comment_Title = c.Title,
                Comment_Description = c.Description,
                Comment_Rank = c.Rank,
                Comment_Date = c.Date.ToString("yyyy,MM,dd"),
                Comment_UserName = ProductDAO.GetUserModels(c.UserID)
            };
        }
        //帶入comment裡的資料及用戶身份
        public List<CommentItem> UploadComment(CommentPushViewModel CVM, string UserId)
        {
            ProductDAO.UploadCom(CVM, UserId);
            List<CommentItem> res = new List<CommentItem>();
            foreach(var c in ProductDAO.GetCommentModels(CVM.Comment_ProductID))
            {
                res.Add(CommMaping(c));
            }
            return res;
        }

        //public void AddComment(CommentPushViewModel CVM, string UserId)
        //{
        //    ProductDAO.AddCom(CVM, UserId);
        //}
        //public void DeleteComment(string ProductId , string UserId)
        //{
        //    ProductDAO.DeleteCom(ProductId,UserId);
        //}
    }
}