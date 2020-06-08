using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Epic_Game_Backstage.ViewModels
{
    public class ProductCeateViewModel
    {
        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        [Required]
        [StringLength(100)]
        public string Developer { get; set; }

        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Category { get; set; }

        public int AgeRestriction { get; set; }

        public int OS { get; set; }

        [Required]
        public string Description { get; set; }

        public string LanguagesSupported { get; set; }

        public string PrivacyPolicy { get; set; }

        public string PrivacyPolicyUrl { get; set; }

        public string StoreImg { get; set; }
        
        public string GameLogo { get; set; }

        public List<string> SwiperImg { get; set; }

        public List<string> ScreenShot { get; set; }
    }
}