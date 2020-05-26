using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using Epic_Game.Service;


namespace Epic_Game.Repository.DataOperationLayer
{
    public class UserAccountDAO
    {
        private AspNetUsers User;
        public EGRepository<AspNetUsers> repo;
        public EGContext context;
        public OperationResult result;
        public UserAccountDAO(string UserId)
        {
            context = new EGContext();
            repo = new EGRepository<AspNetUsers>(context);
            result = new OperationResult();
            User = context.AspNetUsers.Single(x => x.Id == UserId);
        }

        public AspNetUsers GetUser()
        {
            return User;
        }

        public AspNetUsers EditDisplayName(string newName)
        {
            try {
                User.UserName = newName;
                repo.Update(User);
                context.SaveChanges();
                return User;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

            //try
            //{
            //    BizModel context = new BizModel();
            //    BizRepository<Product> repository = new BizRepository<Product>(context);
            //    Product entity = new Product()
            //    {
            //        PartNo = product.proNo,
            //        PartName = product.proName
            //    };
            //    repository.Create(entity);
            //    context.SaveChanges();
            //    result.isSuccessful = true;
            //}
            //catch (Exception ex)
            //{
            //    result.isSuccessful = false;
            //    result.exception = ex;
            //}

            //return result;
        }
    }
}