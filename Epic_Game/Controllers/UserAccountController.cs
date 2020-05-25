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
            var t = ViewData;
            var UserId = User.Identity.GetUserId();

            if (UserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var UserView = new UserAccountBLO().GetUserById(UserId);
            return View(UserView);
        }

        [HttpPost]
        public ActionResult DesgardChanges(string jdata)
        {
            var t = ViewData;
            return View(ViewData);
        }

        public ActionResult History()
        {
            var UserId = User.Identity.GetUserId();
            return View();
        }

        public ActionResult Security()
        {
            return View();
        }
    }
}