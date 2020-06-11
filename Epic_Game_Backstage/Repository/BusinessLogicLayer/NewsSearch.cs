using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class NewsSearch: Controller
    {

            private EGContext db = new EGContext();
            public ActionResult Searchmethod1(string search, string option, string searchname, string searchnametxt)
            {

                List<NewsManageViewModel> newsVMlist = new List<NewsManageViewModel>();

                var news1 = db.News.ToList();
            NewsManageBLO newsBLO = new NewsManageBLO();
                foreach (var item in news1)
                {
                NewsManageViewModel vm = newsBLO.Getnewsdata(item.NewsID.ToString());
                newsVMlist.Add(vm);
                }
                IQueryable<NewsManageViewModel> newsVMlistiqu1 = null;
                var newsVMlistiqu = newsVMlist.AsQueryable();
                searchname = search;
                if (option == $"{searchnametxt}")
                {
                    if (string.IsNullOrEmpty(searchname))
                    {
                        return Content($"{searchnametxt}名稱不得為空白");
                    }

                    //orderVMlist.AsQueryable()可以將List轉IEnumerable，像db. 。
                    if (searchname == "*")
                    //*等於全部
                    {
                    newsVMlistiqu1 = newsVMlistiqu;
                    }
                    else
                    {
                        switch (searchnametxt)
                        {
                            case "Author":
                            newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Author.ToString().Contains(searchname));
                                break;
                            case "NewsTitle":
                            newsVMlistiqu1 = newsVMlistiqu.Where(x => x.NewsTitle.ToString().Contains(searchname));
                                break;
                            case "Date":
                            newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Date.ToString().Contains(searchname));
                                break;
                            case "Description":
                            newsVMlistiqu1 = newsVMlistiqu.Where(x => x.Description.ToString().Contains(searchname));
                                break;
                            case "NewsImg":
                            newsVMlistiqu1 = newsVMlistiqu.Where(x => x.NewsImg.ToString().Contains(searchname));
                            break;
                            default:
                            newsVMlistiqu1 = null;
                                break;
                        }
                    }
                    if (newsVMlistiqu1 == null)
                    {
                        return Content("找不到資料");
                    }
                }
                return View(newsVMlistiqu1);
            }
        
    }
}