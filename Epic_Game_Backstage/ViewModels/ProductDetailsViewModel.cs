using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Img_Url { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public int sales_volume { get; set; }
        public int total_income { get; set; } //新台幣
        public string[] Sale_line { get; set; }
    }
}