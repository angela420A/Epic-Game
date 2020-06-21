using EpicGameLibrary.Models;
using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class ActivityManageDAO
    {
        public EGContext context = new EGContext();

        public List<Activity> GetAllActivities()
        {

            using (var _context = new EGContext())
            {
                var repo = new EGRepository<Activity>(_context);
                return repo.GetAll().AsEnumerable().ToList();

            }

        }
        //Create
        public void CreateActivity(Activity a)
        {
            using(var _context = new EGContext())
            {
                var repo = new EGRepository<Activity>(_context);
                repo.Create(a);
                _context.SaveChanges();
            }
        }
        //Detail
        public Activity GetDetailActivity(string id)
        {
            return context.Activity.SingleOrDefault(x => x.ActivityID.ToString().Equals(id));
        }
        //Delete
        public void DeleteAct(int Id)
        {
            var delete_item = context.Activity.FirstOrDefault(x => x.ActivityID.Equals(Id));
            context.Activity.Remove(delete_item);
            context.SaveChanges();
        }
        //updateImg

        public Activity GetActivities(string id)
        {
            return context.Activity.FirstOrDefault(x => x.ActivityID.ToString().Equals(id));
        }

        public void UpDate(ActivityViewModel VM)
        {
            using(var context = new EGContext())
            {
                var a = GetActivities(VM.ActivityID.ToString());
                ViewModelToModel(a, VM);
                context.Activity.AddOrUpdate(a);
                context.SaveChanges();
            }
        }

        public void ViewModelToModel(Activity a, ActivityViewModel VM)
        {
            a.ActivityName = VM.ProductName;
            a.Information = VM.Content;
            a.Slogan = VM.Title;
            a.Date = VM.Time;
            a.IMG = VM.Picture;
        }
        
    }
}