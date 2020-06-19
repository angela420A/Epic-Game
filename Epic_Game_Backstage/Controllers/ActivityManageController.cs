using Epic_Game_Backstage.Repository.BusinessLogicLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.Controllers
{
    public class ActivityManageController : Controller
    {
        private ActivityManageBLO blo;
        // GET: Activity
        public ActivityManageController()
        {
            blo = new ActivityManageBLO();
        }
        public ActionResult Index()
        {
            var vm = blo.GetActivityManageView();
            return View(vm);
        }
        // GET: ProductManage/Create
        public ActionResult Create()
        {
            ActivityViewModel data = new ActivityViewModel();
            return View(data);
            //return View();
        }
        [HttpPost]
        public ActionResult Create(string jdata)
        {
            if (jdata == null) return HttpNotFound("Error");
            ActivityViewModel AVM = JsonConvert.DeserializeObject<ActivityViewModel>(jdata);
            blo = new ActivityManageBLO();
            blo.ViewToModel(AVM);
            return RedirectToAction("Index");
        }
        [HttpPost]

        public ActionResult Delete()
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
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public void UploadImg(string id)
        {

        }
    }
}