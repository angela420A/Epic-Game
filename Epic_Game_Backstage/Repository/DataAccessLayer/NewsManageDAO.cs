using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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


        public List<News> Getallnewsdata()
        {
            return newscontext.News.ToList();
        }

        public void updatedao(NewsManageViewModel data)
        {
            newscontext.News.AddOrUpdate(Convert(data));
            newscontext.SaveChanges();
        }

        public void adddao(NewsManageViewModel data)
        {
            newscontext.News.Add(Convert(data));
            newscontext.SaveChanges();
        }

        public void deletedao(Guid guid)
        {
            var deleteo = newscontext.News.FirstOrDefault(x => x.NewsID == guid);
            newscontext.News.Remove(deleteo);
            newscontext.SaveChanges();
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
        //public IEnumerable<News> Getallnewsdatadb()
        //{
        //    return newscontext.News;
        //}

        //public List<News> Searchnews(string option, string search)
        //{
        //    var a = newscontext.News.AsEnumerable();
        //    return a.Where(x => x.GetType().GetProperty(option).GetValue(x).ToString().Contains(search)).ToList();
        //}
    }
}