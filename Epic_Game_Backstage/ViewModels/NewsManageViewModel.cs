using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backstage.ViewModels
{
    public class NewsManageViewModel
    {
        public Guid NewsID { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(100)]
        [Display(Name = "請第一個輸入新聞頁面標題，之後請@再輸入新聞內容標題")]
        public string NewsTitle { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(2000)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "請第一個輸入新聞頁面圖片網址，之後請。再輸入新聞內容圖片網址")]
        public string NewsImg { get; set; }
    }
}