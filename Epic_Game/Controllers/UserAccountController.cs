using System.Web;
using System.Web.Mvc;
using Epic_Game.ViewModels;
using Epic_Game.Repository.BusinessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Epic_Game.Controllers
{
    public class UserAccountController : Controller
    {
        public ActionResult General()
        {
            var UserId = User.Identity.GetUserId();
            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return GetUserInfo(UserId);
            }
        }

        [HttpPost]
        //Update
        public ActionResult General(UserInfoViewModel ViewModel)
        {
            return View(ViewModel);
        }

        public ActionResult GetUserInfo(string UserId)
        {
            var userAccountBLO = new UserAccountBLO(UserId);
            return View(userAccountBLO.GetUser());
        }

        [HttpPost]
        public void ChangeDisplayName(string jdata)
        {
            var UserId = User.Identity.GetUserId();
            var userAccountBLO = new UserAccountBLO(UserId);
            var ViewModel = userAccountBLO.ChangeDisplayName(jdata);
            General(ViewModel);
        }

        [HttpPost]
        public void ChangeEmail(string jdata)
        {
            var UserId = User.Identity.GetUserId();
            var userAccountBLO = new UserAccountBLO(UserId);
            var ViewModel = userAccountBLO.ChangeEmail(jdata);
            General(ViewModel);
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult Security()
        {
            return View();
        }
    }
}