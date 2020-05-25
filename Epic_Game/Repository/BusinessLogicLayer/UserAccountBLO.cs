using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using Epic_Game.ViewModels;
using Epic_Game.Repository.DataOperationLayer;

namespace Epic_Game.Repository.BusinessLayer
{
    public class UserAccountBLO
    {
        public UserAccountDAO UserAccountDAO { get; set; }
        public UserAccountBLO()
        {
            UserAccountDAO = new UserAccountDAO();
        }

        public UserInfoViewModel GetUserById(string UserID)
        {
            AspNetUsers u = UserAccountDAO.GetUserById(UserID);
            string[] s = new string[3] { "","","" };
            if (u.Birthday != null) { 
                s = u.Birthday.ToString("yyyy.mm.dd").Split('.');
            }
            UserInfoViewModel viewmModel = new UserInfoViewModel
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
            return viewmModel;
        }
    }
}