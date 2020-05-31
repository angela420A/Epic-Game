using System.Web.Mvc;
using Epic_Game.ViewModels;
using Epic_Game.Service;
using Microsoft.AspNet.Identity;
using Epic_Game.Repository.BusinessLogicLayer;
using System.Net;

namespace Epic_Game.Controllers
{
    public class UserAccountController : Controller
    {
        public UserAccountBLO CreateUserBLO()
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
            return View(CreateUserBLO().GetUser());
        }

        public ActionResult GetUserInfoJSON()
        {
            //if (!User.Identity.IsAuthenticated)
                return Json(CreateUserBLO().GetUser(), JsonRequestBehavior.AllowGet);
            //else
            //    throw new Exception("Unknow user access.");
        }

        public ActionResult ErrorOccured()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 400;
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void ChangeDisplayName(string jdata)
        {
            if (jdata.Equals(""))
            {
                ErrorOccured();
            }
            else
            {
                var ViewModel = CreateUserBLO().ChangeDisplayName(jdata);
                General(ViewModel);
            }
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
        [ValidateAntiForgeryToken]
        public void ChangeEmail(string jdata)
        {
            if (!jdata.isEmail())
            {
                ErrorOccured();
            }
            else
            {
                var ViewModel = CreateUserBLO().ChangeEmail(jdata);
                General(ViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void ChangePersonalInfo(string jdata)
        {
            var convertor = new JsonToViewModel<UserInfoViewModel>(new UserInfoViewModel(), jdata);
            var ViewModel = CreateUserBLO().ChangeUserInfo(convertor.Obj);
            General(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void ChangeAddress(string jdata)
        {
            var convertor = new JsonToViewModel<UserInfoViewModel>(new UserInfoViewModel(), jdata);
            var ViewModel = CreateUserBLO().ChangeAddress(convertor.Obj);
            General(ViewModel);
        }

        public TransactionHistoryBLO CreateHisBLO()
        {
            return new TransactionHistoryBLO(User.Identity.GetUserId());
        }

        public ActionResult History()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            GetTransHistory();
            return View();
        }

        public void GetTransHistory()
        {
            var vm = (CreateHisBLO().GetOrders());
            ViewData.Model = vm;
            RedirectToAction("History");
        }
    }
}