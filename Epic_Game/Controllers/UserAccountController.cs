using System.Web;
using System.Web.Mvc;
using Epic_Game.ViewModels;
using Epic_Game.Repository.BusinessLayer;
using Epic_Game.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;

namespace Epic_Game.Controllers
{
    public class UserAccountController : Controller
    {
        public UserAccountBLO CreateBLO()
        {
            return new UserAccountBLO(User.Identity.GetUserId());
        }

        public ActionResult General()
        {
            
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return GetUserInfo();
            }
        }

        [HttpPost]
        //Update
        public ActionResult General(UserInfoViewModel ViewModel)
        {
            return View(ViewModel);
        }

        public ActionResult GetUserInfo()
        { 
            return View(CreateBLO().GetUser());
        }

        public ActionResult GetUserInfoJSON()
        {
            return Json(CreateBLO().GetUser(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public void ChangeDisplayName(string jdata)
        {
            var ViewModel = CreateBLO().ChangeDisplayName(jdata);
            General(ViewModel);
        }

        //public ActionResult ChangeDisplayName(UserInfoViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        General();
        //    }
        //    var UserId = User.Identity.GetUserId();
        //    var userAccountBLO = new UserAccountBLO(UserId);
        //    var ViewModel = userAccountBLO.ChangeDisplayName(vm.DisplayName);
        //    return RedirectToAction("General");
        //}

        [HttpPost]
        public void ChangeEmail(string jdata)
        {
            var ViewModel = CreateBLO().ChangeEmail(jdata);
            General(ViewModel);
        }

        [HttpPost]
        public void ChangePersonalInfo(string jdata)
        {
            var convertor = new JsonToViewModel<UserInfoViewModel>(new UserInfoViewModel(), jdata);
            var ViewModel = CreateBLO().ChangeUserInfo(convertor.Obj);
            General(ViewModel);
        }

        [HttpPost]
        public void ChangeAddress(string jdata)
        {
            var convertor = new JsonToViewModel<UserInfoViewModel>(new UserInfoViewModel(), jdata);
            var ViewModel = CreateBLO().ChangeAddress(convertor.Obj);
            General(ViewModel);
        }
    }
}