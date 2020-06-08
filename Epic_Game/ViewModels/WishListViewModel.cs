using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class WishListViewModel
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Img_Url { get; set; }
        public decimal Price { get; set; }
    }
}