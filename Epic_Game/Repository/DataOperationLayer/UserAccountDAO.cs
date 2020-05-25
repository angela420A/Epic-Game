using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGameLibrary.Models;
using EpicGameLibrary.Repository;
using Microsoft.AspNet.Identity;


namespace Epic_Game.Repository.DataOperationLayer
{
    public class UserAccountDAO
    {
        public EGRepository<AspNetUsers> repo;
        public EGContext context;

        public UserAccountDAO()
        {
            context = new EGContext();
            repo = new EGRepository<AspNetUsers>(context);
        }

        public AspNetUsers GetUserById(string UserId)
        {
            return context.AspNetUsers.Single(x => x.Id == UserId);
        }
    }
}