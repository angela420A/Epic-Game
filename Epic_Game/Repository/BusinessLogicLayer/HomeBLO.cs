using Epic_Game.Models;
using Epic_Game.Repository.DataOperationLayer;
using Epic_Game.ViewModels;
using System;
using System.Collections.Generic;
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

        public HomeViewModels GetHomeViewModel()
        {
            var data = HomeDAO.GetProducts();
            return new HomeViewModels
            {
                BestDiscount = HomeDAO.GetProducts().OrderBy(x => x.Discount).Take(5).ToList(),
                Activities = GetHomeActivity().ToList(),
 
            };
        }
        
        public IEnumerable<HomeActivityViewModels> GetHomeActivity()
        {
            var ActivityData = HomeDAO.GetActivity();
            return ActivityData;
        }

        public IEnumerable<>
    }
}