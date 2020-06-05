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

        public HomeViewModels GetHomeViewModel()
        {
            var data = HomeDAO.GetProducts();
            return new HomeViewModels
            {
                BestDiscount = HomeDAO.GetProducts().OrderBy(x => x.Discount).Take(5).ToList(),
                Activities = GetHomeActivity().ToList(),
                TopSales = TopSales()
            };
        }
        
        public List<StoreItems> TopSales()
        {
            var sales = HomeDAO.GetSales().GroupBy(x => x.ProductID).Select(s => new GroupList() { Key = s.Key, Count = s.Count() }).OrderByDescending(o => o.Count).ToList();
            var topSales = HomeDAO.getTop5Sale(sales);
            return topSales;
        }

        public IEnumerable<HomeActivityViewModels> GetHomeActivity()
        {
            var ActivityData = HomeDAO.GetActivity();
            return ActivityData;
        }

        //public IEnumerable<>


    }
}