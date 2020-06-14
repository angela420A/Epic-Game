using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backstage.Repository;
using Epic_Game_Backstage.Repository.BusinessLogicLayer;

namespace Epic_Game_Backstage.Controllers
{
    public class UserManageController : Controller
    {
        private UserManageBLO _userBLO;

        public UserManageController()
        {
            _userBLO = new UserManageBLO();
        }

        // GET: UserManage
        public ActionResult Index()
        {
            var result = _userBLO.GetUserManageViewModel();
            return View(result);
        }
    }
}