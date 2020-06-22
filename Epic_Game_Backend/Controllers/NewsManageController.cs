using Epic_Game_Backend.Repository.BusinessLogicLayer;
using Epic_Game_Backend.Repository.DataAccessLayer;
using Epic_Game_Backend.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backend.ActionFilter;


namespace Epic_Game_Backend.Controllers
{
    [Backend]
    public class NewsManageController : Controller
    {
        //private EGContext db = new EGContext();

        // GET: NewsManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult searchsort(string sort, string nowsort)
        {
            //看是如果現在是空的話就拿money來當排序
            if (string.IsNullOrEmpty(sort) && string.IsNullOrEmpty(sort))
            {
                sort = "Date";
                nowsort = "Date";
            }

            //目前的會等於現在sort名稱的，看是日期、錢等等
            ViewBag.Nowsort = sort;

            bool order = sort.Equals(nowsort);
            var newsVMlist = new NewsManageBLO().NewsViewModelstolist().OrderByPropertyName(sort, !order).ToList();
            if(order) ViewBag.Nowsort = null;

            return View(newsVMlist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult searchsort(string searchname, string option, string search)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            searchname = option;
            List<NewsManageViewModel> newslist = newsManageBLO.SearchNews(searchname, search);
            return View(newslist);
        }
        public ActionResult Create()
        {
            NewsManageViewModel data = new NewsManageViewModel();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsManageViewModel data)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            if (newsManageBLO.addnews(data))
            {
                return RedirectToAction("searchsort");
            }
            else
            {
                ViewBag.Status = false;
                return View(data);
            }
        }
        public ActionResult Edit(string id)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            return View(newsManageBLO.getdata(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsManageViewModel data)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            if (newsManageBLO.updatenews(data))
            {
                return RedirectToAction("searchsort");
            }
            else
            {
                ViewBag.Status = false;
                return View(data);
            }
        }
        public ActionResult Delete(Guid id)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            if (newsManageBLO.deletenews(id))
            {
                ViewBag.Status = true;
            }
            else
            {
                ViewBag.Status = false;
            }
            return RedirectToAction("searchsort");
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