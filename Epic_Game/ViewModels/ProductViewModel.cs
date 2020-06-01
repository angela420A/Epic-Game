﻿using EpicGameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class ProductViewModel
    {
        public List<string> Slider { get; set; }
        public Dictionary<string, string> SoicalMedia { get; set; }
        public int Status { get; set; }
        public Guid PD_ProductID { get; set; }
        public string PD_ProductName { get; set; }
        public string PD_ContentType { get; set; }
        public string PD_Title { get; set; }
        public decimal PD_Price { get; set; }
        public decimal PD_Discount { get; set; }
        public string PD_Publisher { get; set; }
        public string PD_ReleaseDate { get; set; }
        public string PD_Category { get; set; }
        public string PD_AgeRestriction { get; set; }
        public int OS { get; set; }
        public string PD_Description { get; set; }
        public List<SocialMediaViewModel> SM { get; set; }
        public string Pack_image { get; set; }
        public decimal? Pack_Price { get; set; }
        public decimal? Pack_Discount { get; set; }
        public string Library_Condition { get; set; }
        public List<CommentViewModel> PD_Comment { get;set; }
        public List<ImageViewModel> PD_image { get; set; }
    }
}