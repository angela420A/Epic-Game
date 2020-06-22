using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic_Game_Backend.ViewModels
{
    public class NewsManageViewModel
    {
        public Guid NewsID { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(500)]
        public string NewsTitle { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(2000)]
        [AllowHtml]
        public string Description { get; set; }


        public string NewsImg { get; set; }
    }
}