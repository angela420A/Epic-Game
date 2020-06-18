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

        public NewsViewModels ModelViewModel(News n)
        {
            var nvm = new NewsViewModels
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
    }
}