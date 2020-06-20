using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.ViewModels
{
    public class BackstageHomeViewModel
    {
        public List<BackstageSingleDataVM> backstageSingleDataVM;
        public List<BackstageChartLineVM> backstageChartLineVM;
        public List<BackstageChartLineVMPie> backstageChartLineVMPie;
        public int[] monthDataTotalPrice { get; set; }
        public List<BackstageChartLineVM002> backstageChartLineVM002;
        public int[] monthDataTotalCount { get; set; }
        public int[] PieData { get; set; }
        public string[] PieProductName { get; set; }
    }
    public class BackstageSingleDataVM
    {
        public string ProductQuantity { get; set; }
        public string TotalPrice { get; set;}
        public string OrderQuantity { get; set; }
        public string UserQuantity { get; set; }

    }

    public class BackstageChartLineVM
    {
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
    }

    public class BackstageChartLineVM002
    {
        public int JanCount { get; set; }
        public int FebCount { get; set; }
        public int MarCount { get; set; }
        public int AprCount { get; set; }
        public int MayCount { get; set; }
        public int JunCount { get; set; }
        public int JulCount { get; set; }
        public int AugCount { get; set; }
        public int SepCount { get; set; }
        public int OctCount { get; set; }
        public int NovCount { get; set; }
        public int DeceCount { get; set; }
    }

    public class BackstageChartLineVMPie
    {
        public string ProductName { get; set; }
        public int count { get; set; }
    }

}