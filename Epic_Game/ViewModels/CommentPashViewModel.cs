using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class CommentPashViewModel
    {
        public Guid Comment_ProductID { get; set; }
        public string Comment_Date { get; set; }
        public string Comment_Description { get; set; }
        public int Comment_Rank { get; set; }  
    }
}