using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using Epic_Game.ViewModels;
using Epic_Game.Repository.DataOperationLayer;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class UserAccountBLO
    {
        private UserAccountDAO userAccountDAO { get; set; }

        public UserAccountBLO(string UserId)
        {
            userAccountDAO = new UserAccountDAO(UserId);
        }

        public UserInfoViewModel UserToView(AspNetUsers u)
        {
            var viewModel = new UserInfoViewModel
            {
                UserID = u.Id,
                DisplayName = u.UserName,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                AddressLine = u.Address,
                City = u.City,
                Postalcode = u.PostalCode == null ? "" : u.PostalCode.ToString(),
                Country = u.Country,
                Birthday = u.Birthday.ToString("yyyy.MM.dd")
            };
            return viewModel;
        }

        public UserInfoViewModel GetUser()
        {
            var u = userAccountDAO.GetUser();
            return UserToView(u);
        }

        public UserInfoViewModel ChangeDisplayName(string newName)
        {
            var u = userAccountDAO.EditDisplayName(newName);
            return UserToView(u);
        }

        public UserInfoViewModel ChangeEmail(string Email)
        {
            var u = userAccountDAO.EditEmail(Email);
            return UserToView(u);
        }

        public UserInfoViewModel ChangeUserInfo(UserInfoViewModel Info)
        {
            var u = userAccountDAO.EditPersonalInfo(Info);
            return UserToView(u);
        }

        public UserInfoViewModel ChangeAddress(UserInfoViewModel Info)
        {
            var u = userAccountDAO.EditAddress(Info);
            return UserToView(u);
        }
    }
}