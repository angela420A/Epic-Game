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
            var p = new Product();
            p.ProductID = Guid.NewGuid();
            ProductMapping(p, vm);
            dao.CreateEntity(p);
            dao.CreateEntitiies(MappingImageToModels(p.ProductID, vm));
            dao.CreateEntitiies(MappingSMToModels(vm.SMVM, p.ProductID));
            dao.CreateEntitiies(MappingSPToModels(vm.SPVM, p.ProductID));
        }
        public List<Image> MappingImageToModels(Guid ProductID, ProductCeateViewModel vm)
        {
            var imgList = new List<Image>();
            imgList.Add(new Image { Url = vm.ImageVM.StoreImg, ProductOrPack = ProductID, Location = 0, Type = 1 });
            imgList.Add(new Image { Url = vm.ImageVM.GameLogo, ProductOrPack = ProductID, Location = 1, Type = 1 });
            CreateSwiperList(imgList, vm.ImageVM.SwiperImg, ProductID);
            CreateImageList(imgList, vm.ImageVM.ScreenShots, ProductID);
            return imgList;
        }
        public void ProductMapping(Product p, ProductCeateViewModel vm)
        {
            p.ProductName = vm.ProductName;
            p.ContentType = vm.ContentType;
            p.Title = vm.Title;
            p.Price = vm.Price;
            p.Developer = vm.Developer;
            p.Publisher = vm.Publisher;
            p.ReleaseDate = DateTime.Now;
            p.Category = vm.Category;
            p.AgeRestriction = vm.AgeRestriction;
            p.Description = vm.Description.Replace("&lt;", "<").Replace("&gt;", ">");
            p.PrivacyPolicy = vm.PrivacyPolicy;
            p.PrivacyPolicyUrl = vm.PrivacyPolicyUrl;
            p.OS = getOS(vm.SPVM);
            p.LanguagesSupported = "AUDIO: English, French, German, ItalianTEXT: Chinese - Traditional, English, Chinese - Simplified, Czech, French, German, Italian, Korean, Polish, Russian, Spanish - Spain, Portuguese - Brazil, Spanish - Latin America, Japanese";
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
        public List<Social_Media> MappingSMToModels(List<SocialMediaCreateViewModel> list, Guid pid)
        {
            var result = new List<Social_Media>();
            foreach (var vm in list)
            {
                var sm = new Social_Media { FollowID = Guid.NewGuid(), ProductID = pid };
                SMMapping(vm, sm, true);
                result.Add(sm);
            }
            return result;
        }
        public void SMMapping(SocialMediaCreateViewModel vm, Social_Media sm, bool VtoM)
        {
            if (VtoM)
            {
                sm.Community = vm.Community;
                sm.URL = vm.URL;
            }
            else
            {
                vm.Community = sm.Community;
                vm.URL = sm.URL;
            }
            
        }
        public void SMMapping(Social_Media Old, Social_Media New)
        {
            Old.Community = New.Community;
            Old.URL = New.URL;
        }
        public List<Specifications> MappingSPToModels(List<SpecificationCreateViewModel> list, Guid pid)
        {
            var result = new List<Specifications>();
            foreach (var vm in list)
            {
                if (vm.OS != null && vm.OS.Length > 0)
                {
                    var sp = new Specifications { ProductID = pid };
                    SPMapping(vm, sp, true);
                    result.Add(sp);
                }
            }
            return result;

        }
        /// <summary>
        /// VToM == true: View Model mapping to Model; else Model mapping to View Model
        /// </summary>
        /// <param name="vm">ViewModel</param>
        /// <param name="sp">Model</param>
        /// <param name="VToM">Model To ViewModel or View Model to Model</param>
        public void SPMapping(SpecificationCreateViewModel vm, Specifications sp, bool VToM)
        {
            if (VToM) {
                sp.OS = vm.OS;
                sp.CPU = vm.CPU;
                sp.GPU = vm.GPU;
                sp.Memory = vm.Memory;
                sp.RAM = vm.RAM;
                sp.Storage = vm.Storage;
                sp.Processor = vm.Processor;
                sp.GraphiceCard = vm.GraphiceCard;
                sp.HDD = vm.HDD;
                sp.DirectX = vm.DirectX;
                sp.Additional_Features = vm.Additional_Features;
                sp.Type = vm.Type;
            }
            else
            {
                vm.OS = sp.OS;
                vm.CPU = sp.CPU;
                vm.GPU = sp.GPU;
                vm.Memory = sp.Memory;
                vm.RAM = sp.RAM;
                vm.Storage = sp.Storage;
                vm.Processor = sp.Processor;
                vm.GraphiceCard = sp.GraphiceCard;
                vm.HDD = sp.HDD;
                vm.DirectX = sp.DirectX;
                vm.Additional_Features = sp.Additional_Features;
                vm.Type = sp.Type;
            }
            
        }
        public void SPMapping(Specifications Old, Specifications New)
        {
            Old.OS = New.OS;
            Old.CPU = New.CPU;
            Old.GPU = New.GPU;
            Old.Memory = New.Memory;
            Old.RAM = New.RAM;
            Old.Storage = New.Storage;
            Old.Processor = New.Processor;
            Old.GraphiceCard = New.GraphiceCard;
            Old.HDD = New.HDD;
            Old.DirectX = New.DirectX;
            Old.Additional_Features = New.Additional_Features;
            Old.Type = New.Type;
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
                ProductID = p.ProductID.ToString(),
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
                var vm = new SpecificationCreateViewModel();
                SPMapping(vm, s, false);
                res.Add(vm);
            }
            return res;
        }
        public List<SocialMediaCreateViewModel> MappinMediaToVM(List<Social_Media> medias)
        {
            var res = new List<SocialMediaCreateViewModel>();
            foreach (var m in medias)
            {
                var vm = new SocialMediaCreateViewModel();
                SMMapping(vm, m, false);
                res.Add(vm);
            }
            return res;
        }
        public void UpdateProductInformation(ProductCeateViewModel vm)
        {
            dao = new ProductManageDAO();
            UpdateProduct(vm);
            CreateDeleteEntities(MappingImageToModels(Guid.Parse(vm.ProductID), vm), dao.getImages(vm.ProductID), (x, y) => x.Location == y.Location && x.Url.Equals(y.Url));
            CreateDeleteEntities(MappingSMToModels(vm.SMVM, Guid.Parse(vm.ProductID)), dao.getMedias(vm.ProductID), (x, y) => x.Community.Equals(y.Community), (x, y) => SMMapping(x, y));
            CreateDeleteEntities(MappingSPToModels(vm.SPVM, Guid.Parse(vm.ProductID)), dao.getSpecifications(vm.ProductID), (x, y) => x.Type == y.Type, (x, y) => SPMapping(x, y));
        }
        public void UpdateProduct(ProductCeateViewModel vm)
        {
            dao = new ProductManageDAO();
            Product p = dao.getProduct(vm.ProductID);
            ProductMapping(p, vm);
            dao.UpdateEntity(p);
        }
        public void CreateDeleteEntities<T>(List<T> NewList, List<T> OldList, Func<T, T, bool> CompareFunc) where T : class
        {
            dao = new ProductManageDAO();

            var UpdateList = OldList.GetUpdateEntities(NewList, (x, y) => CompareFunc(x, y)).ToList();
            var DeleteList = OldList.Except(UpdateList);
            var CreateList = NewList.Except(NewList.GetUpdateEntities(OldList, (x, y) => CompareFunc(x, y))).ToList();

            dao.CreateEntitiies(CreateList);
            dao.DeleteEntitiies(DeleteList);
        }
        public void CreateDeleteEntities<T>(List<T> NewList, List<T> OldList, Func<T, T, bool> CompareFunc, Action<T, T> Mapping) where T : class
        {
            dao = new ProductManageDAO();

            var UpdateList = OldList.GetUpdateEntities(NewList, (x, y) => CompareFunc(x, y)).ToList();
            var DeleteList = OldList.Except(UpdateList).ToList();
            var CreateList = NewList.Except(NewList.GetUpdateEntities(OldList, (x, y) => CompareFunc(x, y))).ToList();

            dao.CreateEntitiies(CreateList);
            dao.DeleteEntitiies(DeleteList);

            UpdateList.ForEach(x => Mapping(x, NewList.FirstOrDefault(y => CompareFunc(x, y))));
            dao.UpdateEntities(UpdateList);
        }
        //吳家寶
        public ProductDetailsViewModel GetProductDetailsView(string id)
        {
            dao = new ProductManageDAO();
            var details = dao.getProduct(id);
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