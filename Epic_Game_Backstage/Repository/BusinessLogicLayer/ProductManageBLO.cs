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
            foreach (var i in p)
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
        
        public void CreateProduct(ProductCeateViewModel vm)
        {
            dao = new ProductManageDAO();
            var p = ProductMapping(vm);

            dao.CreateProduct(p);
            dao.CreateImages(ImageMapping(vm, p));
            dao.CreateSocialMedia(CreateSMList(vm.SMVM, p.ProductID));
            dao.CreateSpecification(CreateSPList(vm.SPVM, p.ProductID));
        }
        public List<Image> ImageMapping(ProductCeateViewModel vm, Product p)
        {
            var imgList = new List<Image>();
            imgList.Add(new Image { Url = vm.ImageVM.StoreImg, ProductOrPack = p.ProductID, Location = 0, Type = 1 });
            imgList.Add(new Image { Url = vm.ImageVM.GameLogo, ProductOrPack = p.ProductID, Location = 1, Type = 1 });
            CreateSwiperList(imgList, vm.ImageVM.SwiperImg, p.ProductID);
            CreateImageList(imgList, vm.ImageVM.SwiperImg, p.ProductID);
            return imgList;
        }
        public Product ProductMapping(ProductCeateViewModel vm)
        {
            return new Product()
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
                OS = getOS(vm.SPVM),
                LanguagesSupported = "AUDIO: English, French, German, ItalianTEXT: Chinese - Traditional, English, Chinese - Simplified, Czech, French, German, Italian, Korean, Polish, Russian, Spanish - Spain, Portuguese - Brazil, Spanish - Latin America, Japanese"
            };
        }
        public int getOS(List<SpecificationCreateViewModel> vm)
        {
            if(vm[0].OS.Length > 0 && vm[1].OS.Length > 0)
            {
                return 3;
            }else if(vm[0].OS.Length > 0)
            {
                return 1;
            }else if(vm[1].OS.Length > 0)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public void CreateSwiperList(List<Image> list, List<string> source, Guid Pid)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 2, ProductOrPack = Pid };
                if (url.Contains("imgur") || url.Contains("jpg")) image.Type = 1;
                else image.Type = 2;
                list.Add(image);
            }
        }
        public void CreateImageList(List<Image> list, List<string> source, Guid Pid)
        {
            foreach (var url in source)
            {
                Image image = new Image { Url = url, Location = 3, Type = 1, ProductOrPack = Pid };
                list.Add(image);
            }
        }
        public List<Social_Media> CreateSMList(List<SocialMediaCreateViewModel> list, Guid pid)
        {
            var result = new List<Social_Media>();
            foreach (var vm in list) result.Add(new Social_Media { FollowID = Guid.NewGuid(), ProductID = pid, Community = vm.Community, URL = vm.URL });
            return result;
        }
        public List<Specifications> CreateSPList(List<SpecificationCreateViewModel> list, Guid pid)
        {
            var result = new List<Specifications>();
            foreach (var vm in list)
            { 
                if (vm.OS != null && vm.OS.Length > 0) result.Add(SPMapping(vm, pid));
            }
            return result;

        }
        public Specifications SPMapping(SpecificationCreateViewModel vm, Guid pid)
        {
            return new Specifications
            {
                ProductID = pid,
                OS = vm.OS,
                CPU = vm.CPU,
                GPU = vm.GPU,
                Memory = vm.Memory,
                RAM = vm.RAM,
                Storage = vm.Storage,
                Processor = vm.Processor,
                GraphiceCard = vm.GraphiceCard,
                HDD = vm.HDD,
                DirectX = vm.DirectX,
                Additional_Features = vm.Additional_Features,
                Type = vm.Type
            };
        }
    }
}