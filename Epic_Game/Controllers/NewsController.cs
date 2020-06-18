using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Epic_Game.Repository.BusinessLogicLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;

namespace Epic_Game.Controllers
{
    public class NewsController : Controller
    {
        //private EGContext db = new EGContext();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Newsitem()
        //{
        //    return View(db.News.ToList());
        //}
        public ActionResult Newsitem()
        {
            NewsBLO NewsBLO=new NewsBLO();
            var news1 = NewsBLO.NewsViewModelstolist();
            return View(news1);
        }
        public ActionResult Newscontent(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsBLO NewsBLO = new NewsBLO();
            //News @new = db.News.Find(id);
            NewsViewModels @new = NewsBLO.FindViewModel(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}