using Epic_Game_Backstage.ViewModels;
using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class BackstageHomeDAO
    {
        private EGContext context;

        public BackstageHomeDAO()
        {
            context = new EGContext();
        }

        
    }
}