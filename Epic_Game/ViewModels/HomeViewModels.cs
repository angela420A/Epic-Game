﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class HomeViewModels
    {
        public List<HomeActivityViewModels> Activities { get; set; }
        public List<StoreItems> TopSales { get; set; } //熱銷
        public List<StoreItems> BestDiscount { get; set; } //折扣最高
        public List<StoreItems> MostRelated { get; set; } //最新發售
        public List<StoreItems> BestPrice{ get; set; } //價錢最低
        public List<StoreItems> BestRank { get; set; } //評價最高
        public List<StoreItems> MostFollowe { get; set; } //最多人關注
        public List<StoreItems> FreeGame { get; set; }
        public List<StoreItems> TopDiscount { get; set; }
    }

    public class StoreItems
    {
        public Guid ProductID { get; set; }
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public decimal Discount { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }

    public class HomeActivityViewModels 
    {
        public string ActivityName { get; set; }
        public string Slogan { get; set; }
        public string Information { get; set; }
        public string IMG { get; set; }
    }
}