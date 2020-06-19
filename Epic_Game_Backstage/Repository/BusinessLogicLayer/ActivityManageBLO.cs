using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class ActivityManageBLO
    {
        private ActivityManageDAO dao;
        public List<ActivityViewModel> GetActivityManageView()
        {
            dao = new ActivityManageDAO();
            var Activity = dao.GetAllActivities();
            return ModelToView(Activity);
        }

        private List<ActivityViewModel> ModelToView(List<Activity> a)
        {
            dao = new ActivityManageDAO();
            var result = new List<ActivityViewModel>();
            foreach(var i in a)
            {
                try
                {
                    var item = new ActivityViewModel
                    {
                        Picture = i.IMG,
                        Title = i.Slogan,
                        ProductName = i.ActivityName,
                        Content = i.Information,
                    };
                    result.Add(item);
                }
                catch (Exception ex) { }
                finally { }
            }
            return result;
        }
        public void ViewToModel(ActivityViewModel AVM)
        {
            dao = new ActivityManageDAO();
            var a = new Activity()
            {
                ActivityName = AVM.ProductName,
                Slogan = AVM.Title,
                Information = AVM.Content,
                IMG = AVM.Picture
            };
            dao.CreateActivity(a);

        }

    }
}