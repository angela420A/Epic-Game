using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic_Game_Backstage.Repository.BusinessLogicLayer;

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
