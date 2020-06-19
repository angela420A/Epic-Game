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

        public List<ProductManageViewModel> GetProductManageView()
        {
            dao = new ProductManageDAO();
            var products = dao.GetAllProducts();
            return ModelToView(products);
        }

        private List<ProductManageViewModel> ModelToView(List<Product> p)
        {
            dao = new ProductManageDAO();
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
            dao = new ProductManageDAO();
            var p = new Product()
            {
                ProductID = Guid.NewGuid(),
                ProductName = vm.ProductName,
                ContentType = vm.ContentType,
                Title = vm.Title,
                Price = vm.Price,
                Developer = vm.Developer,
                Publisher = vm.Publisher,
                ReleaseDate = DateTime.Now,
                Category = vm.Category,
                AgeRestriction = vm.AgeRestriction,
                Description = vm.Description.Replace("&lt;", "<").Replace("&gt;", ">"),
                PrivacyPolicy = vm.PrivacyPolicy,
                PrivacyPolicyUrl = vm.PrivacyPolicyUrl,
                OS = 1,
                LanguagesSupported = "AUDIO: English, French, German, ItalianTEXT: Chinese - Traditional, English, Chinese - Simplified, Czech, French, German, Italian, Korean, Polish, Russian, Spanish - Spain, Portuguese - Brazil, Spanish - Latin America, Japanese"
            };

            var imgList = new List<Image>();
            imgList.Add(new Image { Url = vm.ImageVM.StoreImg, ProductOrPack = p.ProductID, Location = 0, Type = 1 });
            imgList.Add(new Image { Url = vm.ImageVM.GameLogo, ProductOrPack = p.ProductID, Location = 1, Type = 1 });
            CreateSwiperList(imgList, vm.ImageVM.SwiperImg, p.ProductID);
            CreateImageList(imgList, vm.ImageVM.SwiperImg, p.ProductID);

            dao.CreateProduct(p);
            dao.CreateImages(imgList);
        }
        public void CreateSwiperList(List<Image> list, List<string> source, Guid Pid)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 2, ProductOrPack = Pid};
                if (url.Contains("imgur") || url.Contains("jpg")) image.Type = 1;
                else image.Type = 2;
                list.Add(image);
            }
        }
        public void CreateImageList(List<Image> list, List<string> source, Guid Pid)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 3 ,Type = 1, ProductOrPack = Pid };
                list.Add(image);
            }
        }

        //吳家寶
        public ProductDetailsViewModel GetProductDetailsView(string id)
        {
            dao = new ProductManageDAO();
            var details = dao.GetDetial(id);
            return DetailToView(details);
        }
        public ProductDetailsViewModel DetailToView(Product product)
        {
            dao = new ProductManageDAO();
            var result = new ProductDetailsViewModel
            {
                ProductId = product.ProductID.ToString(),
                ProductName = product.ProductName,
                Img_Url = dao.GetStoreImage(product.ProductID).Url,
                Developer = product.Developer,
                Publisher = product.Publisher,
                ReleaseDate = product.ReleaseDate.ToString("yyyy-MM-dd"),
                sales_volume = dao.GetSalesVol(product.ProductID.ToString()),
                total_income = dao.GetTotalIncome(product.ProductID.ToString())
            };
            return result;
        }
    }
}