using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using Epic_Game.Service;
using Epic_Game.ViewModels;


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
            if (User == null) throw new ArgumentNullException();
        }

        public AspNetUsers GetUser()
        {
            return User;
        }
        //Update User Information
        public AspNetUsers UpdateUser()
        {
            try
            {
                repo.Update(User);
                context.SaveChanges();
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AspNetUsers EditDisplayName(string newName)
        {
            User.UserName = newName;
            return UpdateUser();
        }

        public AspNetUsers EditEmail(string Email)
        {
            User.Email = Email;
            return UpdateUser();
        }

        public AspNetUsers EditPersonalInfo(UserInfoViewModel vm)
        { 
            User.FirstName = vm.FirstName;
            User.LastName = vm.LastName;
            User.Birthday = vm.Birthday.ToDateTime();
            return UpdateUser();
        }

        public AspNetUsers EditAddress(UserInfoViewModel vm)
        {
            User.Address = vm.AddressLine;
            User.PostalCode = vm.Postalcode.ToNullable();
            User.City = vm.City;
            User.Country = vm.Country;
            return UpdateUser();
        }


    }
}