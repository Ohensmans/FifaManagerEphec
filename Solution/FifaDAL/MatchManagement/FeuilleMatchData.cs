using FifaError;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.MatchManagement
{
    public class FeuilleMatchData : FifaManagementData
    {
        public FeuilleMatchData(string _Connection) : base(_Connection)
        {
        }

        //fait appel à la procédure stockée Update
        public int Update(List<dynamic> lst)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@feuilleId", lst[0]));
                lstSqlParam.Add(new SqlParameter("@matchId", lst[1]));
                lstSqlParam.Add(new SqlParameter("@equipeId", lst[2]));
                lstSqlParam.Add(new SqlParameter("@lastUpdate", lst[3]));
                return Execute( "Update", lstSqlParam);

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
