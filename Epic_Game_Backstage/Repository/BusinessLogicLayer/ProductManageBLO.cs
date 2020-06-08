using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using EpicGameLibrary.Service;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class ProductManageBLO
    {
        private ProductManageDAO dao;

        public ProductManageBLO()
        {
            dao = new ProductManageDAO();
        }

        public List<ProductManageViewModel> GetProductManageView()
        {
            var products = dao.GetAllProducts().ToList();
            return ModelToView(products);
        }

        private List<ProductManageViewModel> ModelToView(List<Product> p)
        {
            var result = new List<ProductManageViewModel>();
            foreach(var i in p)
            {
                try
                {
                    var item = new ProductManageViewModel
                    {
                        ProductID = i.ProductID.ToString(),
                        ProductName = i.ProductName,
                        ProductImage = dao.GetStoreImage(i.ProductID).Url,
                        ContentType = i.ContentType,
                        Price = i.Price,
                        Developer = i.Developer,
                        Publisher = i.Publisher,
                        ReleaseDate = i.ReleaseDate.ToString("yyyy.MM.dd"),
                        Categories = new GameType().getGameType(i.Category)
                    };
                    result.Add(item);
                }
                catch (Exception ex) { }
                finally { }
            }
            return result;
        }
    }
}