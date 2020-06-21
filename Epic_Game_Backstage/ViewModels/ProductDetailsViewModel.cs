using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Detailtext _detailtext = new Detailtext();
        public Chart_Data_Toarray _chart_toarray = new Chart_Data_Toarray();
        public Chart_Data _chart = new Chart_Data();
    }

    public class Detailtext
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Img_Url { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public int sales_volume { get; set; }
        public int total_income { get; set; }
    }
    public class Chart_Data_Toarray
    {
        public int[] DaysOfMonth { get; set; }
        public int[] CountOfDay { get; set; }
    }
    public class Chart_Data
    {
        public int DaysOfMonth { get; set; }
        public int CountOfDay { get; set; }
    }
}