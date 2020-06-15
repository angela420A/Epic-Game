using Epic_Game.Models;
using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EpicGameLibrary.Service;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class HomeBLO
    {
        private HomeDAO HomeDAO;
        public HomeBLO()
        {
            HomeDAO = new HomeDAO();
        }


        public HomeViewModels GetHomeViewModel()
        {
            HomeViewModels homeViewModels = new HomeViewModels();

            homeViewModels.TopSales = HomeDAO.GetTopSales();
            homeViewModels.BestDiscount = HomeDAO.GetProducts().OrderBy(x => x.Discount).Take(5).ToList();
            homeViewModels.Activities = HomeDAO.GetActivity();
            homeViewModels.MostRelated = HomeDAO.GetTopMostRelated();
            homeViewModels.BestRank = HomeDAO.GetTopBestRank();
            return homeViewModels;
        }

        public List<SearchViewModel> Flit(int num)
        {
           return HomeDAO.GetSearches().Where(x => new GameType().searchGameType(num,x.Category)).ToList();
        }

        public List<SearchViewModel> SearchOrde(string key/*, int num*/)
        {
            return HomeDAO.GetSearches()/*.Where(x => new GameType().searchGameType(num, x.Category))*/.OrderByPropertyName(key).ToList();
        }

        public List<SearchViewModel> GetAll()
        {
            return HomeDAO.GetSearches().ToList();
        }
    }
}