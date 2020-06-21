using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backend.Repository.BusinessLogicLayer;
using Epic_Game_Backend.ViewModels;
using EpicGameLibrary.Service;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Newtonsoft.Json;
using Epic_Game_Backend.ActionFilter;

namespace Epic_Game_Backend.Controllers
{
    [Backend]
    public class ProductManageController : Controller
    {
        // GET: ProductManage
        private ProductManageBLO blo;
        public ProductManageController()
        {
            blo = new ProductManageBLO();
        }

        public ActionResult Index(string sort, string nowsort)
        {
            ViewBag.Nowsort = sort;
            sort = string.IsNullOrEmpty(sort) ? "ProductName" : sort;

            var result = blo.GetProductManageView();

            if (sort.Equals(nowsort))
            {
                result = result.OrderByPropertyName(sort, false).ToList();
                ViewBag.Nowsort = null;
            }
            else
            {
                result = result.OrderByPropertyName(sort).ToList();
            }

            return View(result);
        }

        // GET: ProductManage/Details/5
        public ActionResult Details(string id)
        {
            var vm = blo.GetProductDetailsView(id);
            return View(vm);
        }

        // GET: ProductManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManage/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateProduct(string jdata)
        {
            if (jdata == null) return HttpNotFound("Error");
            ProductCeateViewModel vm = JsonConvert.DeserializeObject<ProductCeateViewModel>(jdata);
            blo = new ProductManageBLO();
            blo.CreateProduct(vm);
            return RedirectToAction("Index");
        }

        // GET: ProductManage/Edit/5
        public ActionResult Edit(string id)
        {
            var vm = blo.getProductCreateView(id);
            return View(vm);
        }

        // POST: ProductManage/Edit/5
        [HttpPost]
        public ActionResult Edit(string jdata,string id)
        {
            try
            {
                if (jdata == null) return HttpNotFound("Error");
                ProductCeateViewModel vm = JsonConvert.DeserializeObject<ProductCeateViewModel>(jdata);
                blo = new ProductManageBLO();
                blo.UpdateProductInformation(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductManage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public void UploadImg(string id)
        {
            var client = new ImgurClient("9d370c1d1eacb51", "379fb3b22df582883d16ce0d9bf3ad99878c390f");
            var endpoint = new ImageEndpoint(client);
            var test = Request.Files[0];
            IImage image;
            var sm = test.InputStream;
            image = endpoint.UploadImageStreamAsync(sm).GetAwaiter().GetResult();
            Response.Write(image.Link);
        }
    }
}
