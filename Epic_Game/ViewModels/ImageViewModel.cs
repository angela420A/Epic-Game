using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class ImageViewModel
    {
        public string Image_URL { get; set; }
        public int Image_Location { get; set; }

        public int? Media_Type { get; set; } // ? 可以變成null 
        
    }
}