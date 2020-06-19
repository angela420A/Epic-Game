using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using Epic_Game_Backstage.ViewModels;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Newtonsoft.Json;

namespace Epic_Game_Backstage.Controllers
{
    public class ProductManageController : Controller
    {
        // GET: ProductManage
        private ProductManageBLO blo;
        public ProductManageController()
        {
            blo = new ProductManageBLO();
        }

        public ActionResult Index()
        {
            var vm = blo.GetProductManageView();
            return View(vm);
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
            blo.ViewToModel(vm);
            return RedirectToAction("Index");
        }

        // GET: ProductManage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductManage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
