using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class NewsDAO
    {
        EGContext newscontext;

        public NewsDAO()
        {
            newscontext = new EGContext();
        }
        public News Getnewsdata(string NewsID)
        {
            return newscontext.News.FirstOrDefault(x => x.NewsID.ToString().Equals(NewsID));
        }
        public News Findid(Guid id)
        {
            return newscontext.News.Find(id);
        }
        public List<News> Getallnewsdata()
        {
            return newscontext.News.ToList();
        }
    }
}