using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epic_Game_Backstage.ViewModels;
using System.Data.SqlClient;
using EpicGameLibrary.Models;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class UserManageDAO
    {

        private EGContext context;

        public UserManageDAO()
        {
            context = new EGContext();
        }

        public IEnumerable<UserManageViewModel> GetUser()
        {
            var user = (from u in context.AspNetUsers
                        select new UserManageViewModel { UserName = u.UserName, Birthday = u.Birthday, Phone = u.Phone, Email = u.Email, City = u.City, Country = u.Country, Address = u.Address, PostalCode = u.PostalCode });

            return user;
        }
    }
}