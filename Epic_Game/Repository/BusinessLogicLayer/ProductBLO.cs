using Epic_Game.Models;
using Epic_Game.Repository.DataOperationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class ProductBLO
    {
        private ProductDAO ProductDAO;
        public ProductBLO()
        {
            ProductDAO = new ProductDAO();
        }

        public IEnumerable<HomeViewModels> getHomeProduct()
        {
            var data = ProductDAO.getProducts();
            data.OrderBy(x => x.Discount).Take(5);
            List<HomeViewModels> homeViews = new List<HomeViewModels>();
            foreach(var item in data)
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