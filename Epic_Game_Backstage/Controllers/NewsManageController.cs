using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
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
            ViewBag.Nowsort = sort;
            //目前的會等於現在sort名稱的，看是日期、錢等等
            sort = string.IsNullOrEmpty(sort) ? "NewsTitle" : sort;
            //看是如果現在是空的話就拿money來當排序


            
            List<NewsManageViewModel> newsVMlist = new List<NewsManageViewModel>();
            var newsvm = new NewsManageViewModel();
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            var news1=newsManageBLO.GetallnewsDatas();
            foreach (var item in news1)
            {
                NewsManageViewModel vm = newsManageBLO.Getnewsdata(item.NewsID.ToString());
                newsVMlist.Add(vm);
            }

            if (sort.Equals(nowsort))
            {
                newsVMlist = newsVMlist.OrderByPropertyName(sort, false).ToList();
                ViewBag.Nowsort = null;
            }
            else
            {
                newsVMlist = newsVMlist.OrderByPropertyName(sort).ToList();
            }
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