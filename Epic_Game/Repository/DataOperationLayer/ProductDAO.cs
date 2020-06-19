using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.DataOperationLayer
{

    public class ProductDAO
    {
        EGContext context;

        public ProductDAO()
        {
            context = new EGContext();
        }

        //public T GetModel<T>(string ID) where T : class
        //{
        //    var repo = new EGRepository<T>(context);
        //    var t = context.Entry<T>.GetType();
        //    if (context.Entry<T>)
        //    {
        //        return repo.GetAll().Single(x => x.ProductID.ToString().Equals(ID));
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public Product GetProductModel(string ProductID)
        {
            return context.Product.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID));
        }
        public Pack GetPackModel(string PackID)
        {
            return context.Pack.FirstOrDefault(x => x.PackID.ToString().Equals(PackID));
        }
        public List<Social_Media> GetSMModels(string ProductID)
        {
            return context.Social_Media.Where(x => x.ProductID.ToString().Equals(ProductID)).ToList();
        }
        //抓取目前最新的三則評論
        public List<Comment> GetCommentModels(string ProductID)
        {
            return context.Comment.Where(x => x.ProductID.ToString().Equals(ProductID)).OrderByDescending(x => x.Date).Take(3).ToList();
        }
        public Library GetLibraryModels(string ProductID, string UserId)
        {
            return context.Library.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID) && x.UserID.Equals(UserId));
        }
        public List<Image> GetImageModels(string ProductOrPack)
        {
            return context.Image.Where(x => x.ProductOrPack.ToString().Equals(ProductOrPack)).ToList();
        }
        public List<Specifications> GetSpecificationsModel(string ProductID)
        {
            return context.Specifications.Where(x => x.ProductID.ToString().Equals(ProductID)).ToList();

        }
        public string GetUserModels(string UserId)
        {
            return context.AspNetUsers.FirstOrDefault(x => x.Id.ToString().Equals(UserId)).UserName;
        }
        //新增一個評論
        public void AddCom(CommentPushViewModel CVM , string UserId)
        {
            var comment = new Comment
            {
                CommentID = Guid.NewGuid(),
                ProductID = Guid.Parse(CVM.Comment_ProductID),
                Title = CVM.Comment_Title,
                Date = DateTime.Now,
                Description = CVM.Comment_Description,
                Rank = CVM.Comment_Rank,
                UserID = UserId
            };
            context.Comment.Add(comment);
            context.SaveChanges();
        }
        //更改過去的評論
        public void UploadCom(CommentPushViewModel CVM, string UserId)
        {
            var update_item = context.Comment.FirstOrDefault(x => x.ProductID.ToString().Equals(CVM.Comment_ProductID) && x.UserID == UserId);
            if(update_item == null)
            {
                AddCom(CVM, UserId);
                return;
            }

            update_item.Title = CVM.Comment_Title;
            update_item.Date = DateTime.Now;
            update_item.Description = CVM.Comment_Description;
            update_item.Rank = CVM.Comment_Rank;
            context.Comment.AddOrUpdate(update_item);
            context.SaveChanges();
        }
        //public void DeleteCom(string ProductId, string UserId)
        //{
        //    var delete_item = context.Comment.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductId) && x.UserID == UserId);
        //    context.Comment.Remove(delete_item);
        //    context.SaveChanges();
        //}
        //要登入用戶才可進行評論
        public Comment GetUserComm(string ProductID, string UserID)
        {
            return context.Comment.FirstOrDefault(x => x.ProductID.ToString().Equals(ProductID) && x.UserID.Equals(UserID));
        }
    }
}