using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class NewsBLO
    {
        private NewsDAO newsDAO { get; set; }

        //EGContext db= new EGContext();

        public NewsBLO()
        {
            newsDAO = new NewsDAO();
        }
        public NewsViewModels Getnewsdata(string NewsID)
        {
            News n = newsDAO.Getnewsdata(NewsID);
            return ModelViewModel(n);
        }
        public NewsViewModels FindViewModel(Guid id)
        {
            var n = newsDAO.Findid(id);
            return ModelViewModel(n);
        }
        public NewsViewModels ModelViewModel(News n)
        {
            var nvm = new NewsViewModels
            {
                NewsID = n.NewsID,
                Author = n.Author,
                NewsTitle = n.NewsTitle,
                Date = n.Date.ToString("yyyy.MM.dd"),
                Description = n.Description,
                NewsImg = n.NewsImg
            };
            return nvm;
        }
        public List<News> GetallnewsDatas()
        {
            return newsDAO.Getallnewsdata();
        }
        public List<NewsViewModels> NewsViewModelstolist()
        {
            var NewsViewModelslist = newsDAO.Getallnewsdata();
            return GetNewsViewModels(NewsViewModelslist);
        }

        public List<NewsViewModels> GetNewsViewModels(List<News> n)
        {
            var NewsViewModelslist = new List<NewsViewModels>();
            foreach(var i in n)
            {
                NewsViewModelslist.Add(new NewsViewModels
                {
                    NewsID = i.NewsID,
                    Author = i.Author,
                    NewsTitle = i.NewsTitle,
                    Date = i.Date.ToString("yyyy.MM.dd"),
                    Description = i.Description,
                    NewsImg = i.NewsImg
                });
            }
            return NewsViewModelslist;

        }
    }
}