using FifaError;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.MatchManagement
{
    public class MatchData : FifaManagementData
    {

        public MatchData(string _Connection) : base(_Connection)
        {
        }

        public int UpdateIsPlayed(dynamic matchId)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@matchId", matchId));
                
                return Execute("Matchs_IsPlayed", lstSqlParam);
            }
            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
