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

        EGContext db= new EGContext();

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
            db.News.Add(Convert(data));
            db.SaveChanges();
            return true;
        }
        public bool updatenews(NewsManageViewModel data)
        {
            db.News.AddOrUpdate(Convert(data));
            db.SaveChanges();
            return true;
        }
        public bool deletenews(Guid guid)
        {
            var deleteo = db.News.FirstOrDefault(x => x.NewsID == guid);
            db.News.Remove(deleteo);
            db.SaveChanges();
            return true;
        }

    
}
}