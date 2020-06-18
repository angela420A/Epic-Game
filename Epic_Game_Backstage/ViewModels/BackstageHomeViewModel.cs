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
        public int[] monthData { get; set; }
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
}