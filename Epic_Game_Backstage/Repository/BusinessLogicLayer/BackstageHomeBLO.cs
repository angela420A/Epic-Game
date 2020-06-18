using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class BackstageHomeBLO
    {
        private BackstageHomeDAO backstageHomeDAO;
        public BackstageHomeBLO()
        {
            backstageHomeDAO = new BackstageHomeDAO();
        }
        public List<BackstageHomeViewModel> GetSingleData()
        {
            return backstageHomeDAO.getSingledata().ToList();
        }
    }
}