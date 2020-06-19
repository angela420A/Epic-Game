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
        public BackstageHomeViewModel GetAllData()
        {
            BackstageHomeViewModel backstageHomeVM = new BackstageHomeViewModel();
            backstageHomeVM.backstageSingleDataVM = backstageHomeDAO.getSingledata();
            backstageHomeVM.backstageChartLineVM = backstageHomeDAO.getMonthData();
            backstageHomeVM.monthDataTotalPrice = new int[12];
            backstageHomeVM.backstageChartLineVM002 = backstageHomeDAO.getMonthCount();
            backstageHomeVM.monthDataTotalCount = new int[12];

            var type = backstageHomeVM.backstageChartLineVM[0].GetType();
            var r = type.GetProperties();

            var type2 = backstageHomeVM.backstageChartLineVM002[0].GetType();
            var r2 = type2.GetProperties();

            for (int i = 0; i < 12; i++)
            {
                var name = r[i].Name;
                var val  = (int)backstageHomeVM.backstageChartLineVM[0].GetType().GetProperty(name).GetValue(backstageHomeVM.backstageChartLineVM[0]);
                backstageHomeVM.monthDataTotalPrice[i] = val;

                var name2 = r2[i].Name;
                var val2 = (int)backstageHomeVM.backstageChartLineVM002[0].GetType().GetProperty(name2).GetValue(backstageHomeVM.backstageChartLineVM002[0]);
                backstageHomeVM.monthDataTotalCount[i] = val2;
            }

            

            

            return backstageHomeVM;
        }

    }
}