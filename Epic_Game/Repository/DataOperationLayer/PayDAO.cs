using EpicGameLibrary.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.DataOperationLayer
{
    public class PayDAO
    {
        EGContext context;
        public PayDAO()
        {
            context = new EGContext();
        }


        public bool hasgame(string _UserID,string _ProductID)
        {
            return context.Library.Any(x => x.ProductID.ToString().Equals(_ProductID) && x.UserID.ToString().Equals(_UserID) && x.Condition.Equals("0"));
        }

        public Product GetProduct(string _ProductID)
        {
            return context.Product.FirstOrDefault(x => x.ProductID.ToString().Equals(_ProductID));
        }

        public Pack GetPack(string _ProductID)
        {
            return context.Pack.FirstOrDefault(x => x.ProductID.ToString().Equals(_ProductID));
        }

        public string GetImageUrl(string _ProductID)
        {
            return context.Image.FirstOrDefault(x => x.ProductOrPack.ToString().Equals(_ProductID) && x.Location == 0).Url;
        }
    }
}