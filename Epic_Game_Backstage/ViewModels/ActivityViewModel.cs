using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.ViewModels
{
    public class ActivityViewModel
    {
        public string Picture { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public decimal Discount { get; set; }
    }
}