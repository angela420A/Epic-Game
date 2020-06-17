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
            homeViewModels.BestPrice = HomeDAO.GetTopBestPrice();
            homeViewModels.MostFollowe = HomeDAO.GetTopMostFollowe();
            return homeViewModels;
        }

        public List<SearchViewModel> SearchOrde(string Key,bool Boo,int num)
        {
            return HomeDAO.GetSearches().Where(x => new GameType().searchGameType(num, x.Category)).OrderByPropertyName(Key,Boo).ToList();
        }

        public List<SearchViewModel> GetAll()
        {
            return HomeDAO.GetSearches().ToList();
        }

        public IEnumerable<SearchViewModel> GetUserSearch(string id)
        {
            return HomeDAO.GetSearches().Where(x => x.ProductName.Contains(id));
        }
    }
}