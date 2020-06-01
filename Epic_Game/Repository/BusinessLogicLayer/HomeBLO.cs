using Epic_Game.Models;
using Epic_Game.Repository.DataOperationLayer;
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

        public IEnumerable<HomeViewModels> GetHomeProduct()
        {
            var data = HomeDAO.GetProducts();
            data.OrderBy(x => x.Discount).Take(5);
            List<HomeViewModels> homeViews = new List<HomeViewModels>();
            foreach (var item in data)
            {
                homeViews.Add(new HomeViewModels()
                {
                    Url = item.Url,
                    ProductName = item.ProductName,
                    Publisher = item.Publisher,
                    Discount = item.Discount,
                    Developer = item.Developer,
                    Price = item.Price
                });
            }
            return homeViews;
        }
    }
}