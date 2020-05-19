using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult General()
        {
            return View();
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