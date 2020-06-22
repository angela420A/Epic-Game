﻿using Epic_Game_Backend.Repository.DataAccessLayer;
using Epic_Game_Backend.ViewModels;
using EpicGameLibrary.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace Epic_Game_Backend.Repository.BusinessLogicLayer
{
    public class ActivityManageBLO
    {
        private ActivityManageDAO dao;

        //Create
        public List<ActivityViewModel> GetActivityManageView()
        {
            dao = new ActivityManageDAO();
            var Activity = dao.GetAllActivities();
            return ModelsToViews(Activity);
        }

        private List<ActivityViewModel> ModelsToViews(List<Activity> a)
        {
            dao = new ActivityManageDAO();
            var result = new List<ActivityViewModel>();
            foreach (var i in a)
            {
                try
                {
                    var item = ModelToView(i);
                    result.Add(item);
                }
                catch (Exception ex) { }
                finally { }
            }
            return result;
        }

        private ActivityViewModel ModelToView(Activity i)
        {
            return new ActivityViewModel
            {
                ActivityID = i.ActivityID,
                Picture = i.IMG,
                Title = i.Slogan,
                ProductName = i.ActivityName,
                Content = i.Information,
                Time = i.Date
            };
        }
        public void ViewToModel(ActivityViewModel AVM)
        {
            dao = new ActivityManageDAO();
            var a = new Activity()
            {
                ActivityName = AVM.ProductName,
                Slogan = AVM.Title,
                Information = AVM.Content,
                IMG = AVM.Picture,
                Date = AVM.Time
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
        //Delete
        public void DeleteActivity(int id)
        {
            dao = new ActivityManageDAO();
            dao.DeleteAct(id);
        }

        //private ActivityViewModel ActivityToView(Activity a)
        //{
        //    dao = new ActivityManageDAO();
        //    var result = new ActivityViewModel()
        //    {
        //            ActivityID = a.ActivityID,
        //            Picture = a.IMG,
        //            Title = a.Slogan,
        //            ProductName = a.ActivityName,
        //            Content = a.Information,
        //            Time = a.Date
        //    };
        //    return result;
        //}

        public ActivityViewModel GetEdit(string id)
        {
            dao = new ActivityManageDAO();
            var result = dao.GetActivities(id);
            return ModelToView(result);
        }

        public void UpDate(ActivityViewModel VM)
        {
            dao = new ActivityManageDAO();
            dao.UpDate(VM);
        }
    }
}