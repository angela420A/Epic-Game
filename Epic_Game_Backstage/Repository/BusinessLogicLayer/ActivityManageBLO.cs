using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.Ajax.Utilities;
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

        //Create
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
                        ActivityID = i.ActivityID.ToString(),
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

        //Details
        public ActivityDetailsViewModel GetActivityDetailsView(string id)
        {
            dao = new ActivityManageDAO();
            var details = dao.GetDetailActivity(id);
            return DetailToView(details);
        }

        public ActivityDetailsViewModel DetailToView(Activity a)
        {
            dao = new ActivityManageDAO();
            var result = new ActivityDetailsViewModel
            {
                ActivityID = a.ActivityID.ToString(),
                Picture = a.IMG,
                ProductName = a.ActivityName,
                Title = a.Slogan,
                Content = a.Information
            };
            return result;
        }
        public void DeleteActivity(string ActivityId)
        {
            dao.DeleteAct(ActivityId);
        }
    }
}