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

            var type = backstageHomeVM.backstageChartLineVM[0].GetType();
            var r = type.GetProperties();
            for(int i = 0; i < 12; i++)
            {
                var name = r[i].Name;
                var val  = (int)backstageHomeVM.backstageChartLineVM[0].GetType().GetProperty(name).GetValue(backstageHomeVM.backstageChartLineVM[0]);
                backstageHomeVM.monthDataTotalPrice[i] = val;
            }

            //foreach (var item in backstageHomeDAO.getMonthData())
            //{
            //    backstageHomeVM.monthData[0] = item.January;
            //    backstageHomeVM.monthData[1] = item.February;
            //    backstageHomeVM.monthData[2] = item.March;
            //    backstageHomeVM.monthData[3] = item.April;
            //    backstageHomeVM.monthData[4] = item.May;
            //    backstageHomeVM.monthData[5] = item.June;
            //    backstageHomeVM.monthData[6] = item.July;
            //    backstageHomeVM.monthData[7] = item.August;
            //    backstageHomeVM.monthData[8] = item.September;
            //    backstageHomeVM.monthData[9] = item.October;
            //    backstageHomeVM.monthData[10] = item.November;
            //    backstageHomeVM.monthData[11] = item.December;
            //}

            return backstageHomeVM;
        }

    }
}