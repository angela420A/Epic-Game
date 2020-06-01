using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class PayViewModel
    {
        public string ProductName { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ImgUrl { get; set; }
    }
}