using Epic_Game.Models;
using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


        public HomeViewModels getHomeViewModel()
        {
            HomeViewModels homeViewModels = new HomeViewModels();

            homeViewModels.TopSales = HomeDAO.getTopSales(); ;
            homeViewModels.BestDiscount = HomeDAO.getProducts().OrderBy(x => x.Discount).Take(5).ToList();
            homeViewModels.Activities = HomeDAO.getActivity();
            homeViewModels.MostRelated = HomeDAO.getTopMostRelated();
            homeViewModels.BestRank = HomeDAO.getTopBestRank();
            return homeViewModels;
        }

    }
}