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
            CreateSwiperList(imgList, vm.ImageVM.ScreenShots, p.ProductID);
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
            if (vm[0].OS.Length > 0 && vm[1].OS.Length > 0)
            {
                return 3;
            }
            else if (vm[0].OS.Length > 0)
            {
                return 1;
            }
            else if (vm[1].OS.Length > 0)
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
        public ProductCeateViewModel getProductCreateView(string ProductId)
        {
            dao = new ProductManageDAO();
            Product p = dao.getProduct(ProductId);
            List<Image> imgs = dao.getImages(ProductId);
            List<Social_Media> SMs = dao.getMedias(ProductId);
            List<Specifications> SPs = dao.getSpecifications(ProductId);

            return MappingProductToVM(p, imgs, SMs, SPs);
        }
        public ProductCeateViewModel MappingProductToVM(Product p, List<Image> imgs, List<Social_Media> SMs, List<Specifications> SPs)
        {
            var VM = new ProductCeateViewModel
            {
                ProductName = p.ProductName,
                ContentType = p.ContentType,
                Title = p.Title,
                Price = p.Price,
                Developer = p.Developer,
                Publisher = p.Publisher,
                Category = p.Category,
                AgeRestriction = p.AgeRestriction,
                Description = p.Description,
                PrivacyPolicy = p.PrivacyPolicy,
                PrivacyPolicyUrl = p.PrivacyPolicyUrl,
                ImageVM = MappingImagesToVM(imgs),
                SMVM = MappinMediaToVM(SMs),
                SPVM = MappinSpecificationToVM(SPs)
            };
            return VM;
        }
        public ImageCreateViewModel MappingImagesToVM(List<Image> imgs)
        {
            var vm = new ImageCreateViewModel();
            vm.StoreImg = imgs.FirstOrDefault(x => x.Location == 0).Url;
            vm.GameLogo = imgs.FirstOrDefault(x => x.Location == 1).Url;
            vm.SwiperImg = imgs.Where(x => x.Location == 2).Select(x => x.Url).ToList();
            vm.ScreenShots = imgs.Where(x => x.Location == 3).Select(x => x.Url).ToList();
            return vm;
        }
        public List<SpecificationCreateViewModel> MappinSpecificationToVM(List<Specifications> specs)
        {
            var res = new List<SpecificationCreateViewModel>();
            foreach (var s in specs)
            {
                var specification = new SpecificationCreateViewModel
                {
                    OS = s.OS,
                    CPU = s.CPU,
                    GPU = s.GPU,
                    Memory = s.Memory,
                    RAM = s.RAM,
                    Storage = s.Storage,
                    Processor = s.Processor,
                    GraphiceCard = s.GraphiceCard,
                    HDD = s.HDD,
                    DirectX = s.DirectX,
                    Additional_Features = s.Additional_Features,
                    Type = s.Type
                };
                res.Add(specification);
            }
            return res;
        }
        public List<SocialMediaCreateViewModel> MappinMediaToVM(List<Social_Media> medias)
        {
            var res = new List<SocialMediaCreateViewModel>();
            foreach (var m in medias)
            {
                var media = new SocialMediaCreateViewModel
                {
                    Community = m.Community,
                    URL = m.URL
                };
                res.Add(media);
            }
            return res;
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