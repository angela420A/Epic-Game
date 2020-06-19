using Epic_Game_Backstage.Repository.DataAccessLayer;
using Epic_Game_Backstage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.BusinessLogicLayer
{
    public class PieBLO
    {
        private PieDAO _PieDAO;
        public PieBLO()
        {
            _PieDAO = new PieDAO();
        }

        public List<PieViewModel> GetProductTop5()
        {
            List<PieViewModel> result;
            var queryresult = _PieDAO.GetProductTop5();
            result = queryresult.Select(x => new PieViewModel
            {
                ProductName = x.ProductName,
                count = x.count
            }).ToList();
            return result;
        }
    }
}