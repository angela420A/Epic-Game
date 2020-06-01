using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class HomeViewModels
    {
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public decimal Discount { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}