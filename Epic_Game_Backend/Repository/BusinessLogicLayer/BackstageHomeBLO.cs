using Epic_Game_Backend.Repository.DataAccessLayer;
using Epic_Game_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backend.Repository.BusinessLogicLayer
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

            var resultPie = backstageHomeDAO.GetProductTop5();
            backstageHomeVM.backstageChartLineVMPie = resultPie.Select((x) => new BackstageChartLineVMPie
            {
                ProductName = x.ProductName,
                count = x.count
            }).ToList();

            int size = backstageHomeVM.backstageChartLineVMPie.Count();
            backstageHomeVM.PieData = new int[size];
            backstageHomeVM.PieProductName = new string[size];
            for (int  i = 0; i < backstageHomeVM.PieData.Length ; i++)
            {
                backstageHomeVM.PieData[i] = backstageHomeVM.backstageChartLineVMPie[i].count;
                backstageHomeVM.PieProductName[i] = backstageHomeVM.backstageChartLineVMPie[i].ProductName;
            }




            return backstageHomeVM;
        }

        //public List<BackstageChartLineVMPie> GetProductTop5()
        //{
        //    List<BackstageChartLineVMPie> result;
        //    var queryresult = backstageHomeDAO.GetProductTop5();
        //    result = queryresult.Select(x => new BackstageChartLineVMPie
        //    {
        //        ProductName = x.ProductName,
        //        count = x.count
        //    }).ToList();
        //    return result;
        //}
    }
}