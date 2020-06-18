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
        //public News Getnewsdata(string NewsID)
        //{
        //    return newscontext.News.FirstOrDefault(x => x.NewsID.ToString().Equals(NewsID));
        //}
        //public List<News> Searchnews(string option, string search)
        //{
        //    var a = newscontext.News.AsEnumerable();
        //    return a.Where(x => x.GetType().GetProperty(option).GetValue(x).ToString().Contains(search)).ToList();
        //}
    }
}