using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class UserManageBLO
    {
        private UserManageDAO userManageDAO;

        public UserManageBLO()
        {
            userManageDAO = new UserManageDAO();
        }

        public IEnumerable<UserManageViewModel> GetUserManageViewModel()
        {
            return userManageDAO.GetUser();
        }
    }
}