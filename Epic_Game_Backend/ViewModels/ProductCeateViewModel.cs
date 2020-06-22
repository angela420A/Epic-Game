using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Epic_Game_Backend.ViewModels
{
    public class ProductCeateViewModel
    {
        public string ProductID { get; set; }

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

        public ImageCreateViewModel ImageVM { get; set; }
        public List<SocialMediaCreateViewModel> SMVM { get; set; }
        public List<SpecificationCreateViewModel> SPVM { get; set; }
    }

    public class ImageCreateViewModel
    {
        public string StoreImg { get; set; }

        public string GameLogo { get; set; }

        public List<string> SwiperImg { get; set; }

        public List<string> ScreenShots { get; set; }
    }

    public class SocialMediaCreateViewModel
    {
        public string Community { get; set; }
        public string URL { get; set; }
    }

    public class SpecificationCreateViewModel
    {
        public string OS { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string GraphiceCard { get; set; }
        public string HDD { get; set; }
        public string DirectX { get; set; }
        public string Additional_Features { get; set; }
        public int Type { get; set; }
    }
}