using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backend.ViewModels
{
    public class ActivityDetailsViewModel
    {
        public string ActivityID { get; set; }
        public string Picture { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}