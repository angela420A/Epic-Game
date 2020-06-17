using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class NewsManageBLO
    {
        private NewsManageDAO newsDAO { get; set; }

        //EGContext db= new EGContext();

        public NewsManageBLO()
        {
            newsDAO = new NewsManageDAO();
        }
        public NewsManageViewModel Getnewsdata(string NewsID)
        {
            News n = newsDAO.Getnewsdata(NewsID);
            return ModelViewModel(n);
        }
        public NewsManageViewModel ModelViewModel(News n)
        {
            var nvm = new NewsManageViewModel
            {
                NewsID = n.NewsID,
                Author = n.Author,
                NewsTitle = n.NewsTitle,
                Date = n.Date,
                Description = n.Description,
                NewsImg = n.NewsImg
            };
            return nvm;
        }
        
        public List<News> GetallnewsDatas()
        {
            return newsDAO.Getallnewsdata();
        }
        //public List<NewsManageViewModel> SearchNews(string option,string search)
        //{
        //    NewsManageDAO NewsManageDAO = new NewsManageDAO();
        //    var newslist = NewsManageDAO.Searchnews(option,search);
        //    List<NewsManageViewModel> vm = new List<NewsManageViewModel>();
        //    foreach(var n in newslist)
        //    {
        //        vm.Add(ModelViewModel(n));
        //    }
        //    return vm;

        //}







        public NewsManageViewModel getdata(string guid)
        {
            var result = newsDAO.Getnewsdata(guid);
            if (result != null)
            {
                return new NewsManageViewModel()
                {
                    NewsID = result.NewsID,
                    Author = result.Author,
                    NewsTitle = result.NewsTitle,
                    Date = result.Date,
                    Description = result.Description,
                    NewsImg = result.NewsImg
                };
            }
            else
            {
                return null;
            }
        }
        public News Convert(NewsManageViewModel ovm)
        {
            return new News()
            {
                NewsID = ovm.NewsID,
                Author = ovm.Author,
                NewsTitle = ovm.NewsTitle,
                Date = ovm.Date,
                Description = ovm.Description,
                NewsImg = ovm.NewsImg
            };
        }


        public bool addnews(NewsManageViewModel data)
        {
            data.NewsID = Guid.NewGuid();
            newsDAO.adddao(data);
            return true;
        }
        public bool updatenews(NewsManageViewModel data)
        {
            newsDAO.updatedao(data);
            return true;
        }
        public bool deletenews(Guid guid)
        {
            newsDAO.deletedao(guid);
            return true;
        }

    
}
}