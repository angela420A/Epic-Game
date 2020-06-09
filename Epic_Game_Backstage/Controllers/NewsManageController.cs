using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
    public class NewsManageController : Controller
    {
        private EGContext db = new EGContext();

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
            var news1 = db.News.ToList();
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            foreach (var item in news1)
            {
                NewsManageViewModel vm = newsManageBLO.Getnewsdata(item.NewsID.ToString());
                newsVMlist.Add(vm);
            }
            switch (sort)
            {
                case "Author":
                    if (sort.Equals(nowsort))
                    //看sort有沒有跟現在的sort有沒有一樣
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.Author).ToList();
                        ViewBag.Nowsort = null;
                        //將目前的清空，這樣才可以迴圈正反序
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.Author).ToList();
                    }
                    break;

                case "NewsTitle":
                    if (sort.Equals(nowsort))
                    //看sort有沒有跟現在的sort有沒有一樣
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.NewsTitle).ToList();
                        ViewBag.Nowsort = null;
                        //將目前的清空，這樣才可以迴圈正反序
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.NewsTitle).ToList();
                    }
                    break;

                case "Date":
                    if (sort.Equals(nowsort))
                    //看sort有沒有跟現在的sort有沒有一樣
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.Date).ToList();
                        ViewBag.Nowsort = null;
                        //將目前的清空，這樣才可以迴圈正反序
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.Date).ToList();
                    }
                    break;
                case "Description":
                    if (sort.Equals(nowsort))
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.Description).ToList();
                        ViewBag.Nowsort = null;
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.Description).ToList();
                    }
                    break;
                case "NewsImg":
                    if (sort.Equals(nowsort))
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.NewsImg).ToList();
                        ViewBag.Nowsort = null;
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.NewsImg).ToList();
                    }
                    break;             
                default:
                    if (sort.Equals(nowsort))
                    {
                        newsVMlist = newsVMlist.OrderByDescending(s => s.NewsTitle).ToList();
                        ViewBag.Nowsort = null;
                    }
                    else
                    {
                        newsVMlist = newsVMlist.OrderBy(s => s.NewsTitle).ToList();
                    }
                    break;
            }
            return View(newsVMlist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult searchsort(string option, string sort, string nowsort, string search, string Author, string NewsTitle, string Date, string Description,string NewsImg)
        {
            ViewBag.Nowsort = sort;
            //目前的會等於現在sort名稱的，看是日期、錢等等
            sort = string.IsNullOrEmpty(sort) ? "NewsTitle" : sort;
            //看是如果現在是空的話就拿money來當排序
            List<NewsManageViewModel> newsVMlist = new List<NewsManageViewModel>();
            var newsvm = new NewsManageViewModel();
            var order1 = db.News.ToList();
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            foreach (var item in order1)
            {
                NewsManageViewModel vm = newsManageBLO.Getnewsdata(item.NewsID.ToString());
                newsVMlist.Add(vm);
            }



            IQueryable<NewsManageViewModel> newsVMlistiqu1 = null;
            var newsVMlistiqu = newsVMlist.AsQueryable();
            Author = search;
            if (option == "Author")
            {
                if (string.IsNullOrEmpty(Author))
                {
                    return Content("Author名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (Author == "*")
                //*等於全部
                {
                    newsVMlistiqu1 = newsVMlistiqu;
                }
                else
                {
                    //search = "Author";
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Author.Contains(Author));
                }
                if (newsVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            NewsTitle = search;
            if (option == "NewsTitle")
            {
                if (string.IsNullOrEmpty(NewsTitle))
                {
                    return Content(" NewsTitle名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (NewsTitle == "*")
                //*等於全部
                {
                    newsVMlistiqu1 = newsVMlistiqu;
                }
                else
                {
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    newsVMlistiqu1 = newsVMlistiqu.Where(x => x.NewsTitle.Contains(NewsTitle));
                }
                if (newsVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            Date = search;
            if (option == "Date")
            {
                if (string.IsNullOrEmpty(Date))
                {
                    return Content("Date名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (Date == "*")
                //*等於全部
                {
                    newsVMlistiqu1 = newsVMlistiqu;
                }
                else
                {
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Date.ToString().Contains(Date));
                }
                if (newsVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            Description = search;
            if (option == "Description")
            {
                if (string.IsNullOrEmpty(Description))
                {
                    return Content("Description名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (Description == "*")
                //*等於全部
                {
                    newsVMlistiqu1 = newsVMlistiqu;
                }
                else
                {
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Description.Contains(Description));
                }
                if (newsVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            NewsImg = search;
            if (option == "NewsImg")
            {
                if (string.IsNullOrEmpty(NewsImg))
                {
                    return Content("NewsImg名稱不得為空白");
                }
                //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                if (NewsImg == "*")
                //*等於全部
                {
                    newsVMlistiqu1 = newsVMlistiqu;
                }
                else
                {
                    //users = db.order.Where(x => x.ProductID.ToString().Contains(ProductID));
                    newsVMlistiqu1 = newsVMlistiqu.Where(x => x.NewsImg.Contains(NewsImg));
                }
                if (newsVMlistiqu1 == null)
                {
                    return Content("找不到資料");
                }
            }
            return View(newsVMlistiqu1);

        }







        // GET: orders1/Create
        public ActionResult Create()
        {
            NewsManageViewModel data = new NewsManageViewModel();
            return View(data);
        }

        // POST: orders1/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
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



        public ActionResult Edit(Guid id)
        {
            NewsManageBLO newsManageBLO = new NewsManageBLO();
            return View(newsManageBLO.getdata(id));
        }

        // POST: orders1/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
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


        // GET: orders1/Delete/5
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}