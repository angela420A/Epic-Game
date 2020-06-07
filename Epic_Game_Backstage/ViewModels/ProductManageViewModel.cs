using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Epic_Game_Backstage.ViewModels
{
    public class ProductManageViewModel
    {
        public string ProductID { get; set; }

        public string ProductImage { get; set; }
         
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Developer { get; set; }

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }

        public string ReleaseDate { get; set; }

        public List<string> Categories { get; set; }

    }
}