using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public ActionResult Index(string search, string item)
        {
            var result = _userBLO.GetUserManageViewModel();
            if (!String.IsNullOrEmpty(search))
            {
                switch (item)
                {
                    case "UserName":
                        result = result.Where((x) => x.UserName.Contains(search));
                        break;
                    case "City":
                        result = result.Where((x) => x.City.Contains(search));
                        break;
                    case "Country":
                        result = result.Where((x) => x.Country.Contains(search));
                        break;
                    case "Address":
                        result = result.Where((x) => x.Address.Contains(search));
                        break;
                    case "PostalCode":
                        result = result.Where((x) => x.PostalCode.ToString().Contains(search));
                        break;
                    case "Birthday":
                        result = result.Where((x) => x.Birthday.ToString().Contains(search));
                        break;
                    case "Phone":
                        result = result.Where((x) => x.Phone.Contains(search));
                        break;
                    case "Email":
                        result = result.Where((x) => x.Email.Contains(search));
                        break;
                }
            }

            return View(result);
        }

        //[HttpPost]
        //public ActionResult Index(string SearchString)
        //{

        //}
    }
}