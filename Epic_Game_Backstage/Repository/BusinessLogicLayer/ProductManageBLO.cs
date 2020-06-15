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

        public void ViewToModel(ProductCeateViewModel vm)
        {
            var p = new Product()
            {
                ProductName = vm.ProductName,
                ContentType = vm.ContentType,
                Title = vm.Title,
                Price = vm.Price,
                Developer = vm.Developer,
                Publisher = vm.Publisher,
                ReleaseDate = DateTime.Now,
                Category = vm.Category,
                AgeRestriction = vm.AgeRestriction,
                Description = vm.Description,
                PrivacyPolicy = vm.PrivacyPolicy,
                PrivacyPolicyUrl = vm.PrivacyPolicyUrl
            };

            var imgList = new List<Image>();
            imgList.Add(new Image { Url = vm.ImageVM.StoreImg, Location = 0, Type = 1 });
            imgList.Add(new Image { Url = vm.ImageVM.GameLogo, Location = 1, Type = 1 });
            CreateSwiperList(imgList, vm.ImageVM.SwiperImg);
            CreateImageList(imgList, vm.ImageVM.SwiperImg);

            dao.CreateProduct(p);
            dao.CreateImages(imgList);
        }
        public void CreateSwiperList(List<Image> list, List<string> source)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 2};
                if (url.Contains("imgur") || url.Contains("jpg")) image.Type = 1;
                else image.Type = 2;
                list.Add(image);
            }
        }
        public void CreateImageList(List<Image> list, List<string> source)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 3 ,Type = 1};
                list.Add(image);
            }
        }

        
    }
}