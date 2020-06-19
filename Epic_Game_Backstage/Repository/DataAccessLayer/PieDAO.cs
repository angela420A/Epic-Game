using Dapper;
using Epic_Game_Backstage.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Epic_Game_Backstage.Repository.DataAccessLayer
{
    public class PieDAO
    {
        private string SQLConnectionStr = ConfigurationManager.ConnectionStrings["EGContext"].ConnectionString;

        public IEnumerable<PieViewModel> GetProductTop5()
        {
            string SQLcommand = @"select top 5
	                                p.ProductName,
	                                count(*) as count
                                  from [Order] o
                                  inner join Product p on o.ProductID = p.ProductID 
                                  group by p.ProductName
                                  order by count desc";
            IEnumerable<PieViewModel> result;
            using (SqlConnection conn = new SqlConnection(SQLConnectionStr))
            {
                result = conn.Query<PieViewModel>(SQLcommand);
            }
            return result;
        }
    }
}