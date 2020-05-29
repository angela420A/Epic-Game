using Epic_Game.Repository.DataOperationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.Repository.BusinessLogicLayer
{
    public class ProductBLO
    {
        private ProductDAO ProductDAO { get; set; }
        public ProductBLO(string ProductId)
        {
            //ProductDAO = new ProductDAO(ProductId);
        }


    }
}