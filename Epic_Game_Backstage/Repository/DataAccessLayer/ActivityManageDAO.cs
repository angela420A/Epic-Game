using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class ActivityManageDAO
    {
        public List<Activity> GetAllActivities()
        {
            using(var _context = new EGContext())
            {
                var repo = new EGRepository<Activity>(_context);
                return repo.GetAll().AsEnumerable().ToList();

            }

        }
        public void CreateActivity(Activity a)
        {
            using(var _context = new EGContext())
            {
                var repo = new EGRepository<Activity>(_context);
                repo.Create(a);
                _context.SaveChanges();
            }
        }
    }
}