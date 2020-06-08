using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class NewsManageDAO
    {
        EGContext newscontext;

        public NewsManageDAO()
        {
            newscontext = new EGContext();
        }
        public News Getnewsdata(string NewsID)
        {
            return newscontext.News.FirstOrDefault(x => x.NewsID.ToString().Equals(NewsID));
        }
    }
}