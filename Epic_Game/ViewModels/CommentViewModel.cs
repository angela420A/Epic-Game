using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class CommentViewModel //給使用者看
    {
        public string Comment_ProductID { get; set; }
        public List<CommentItem> Comments { get; set; }
    }
    public class CommentItem
    {
        public string Comment_Title { get; set; }
        public string Comment_Date { get; set; }
        public string Comment_Description { get; set; }
        public int Comment_Rank { get; set; }
        public string Comment_UserName { get; set; }
    }
}