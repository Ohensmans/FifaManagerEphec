using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.MatchManagement
{
    public class JoueursParticipationData : FifaManagementData
    {
        public JoueursParticipationData(string _Connection) : base(_Connection)
        {
        }

        public DataSet getParticipants (List<dynamic> lst, string newTableName)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@feuilleId", lst[0]));
                return LoadOne("JoueursParticipation_GetOne", lstSqlParam, newTableName);

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


        public int AddParticipants (List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@joueurId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@feuilleId", lst[1]));

            return Execute("JoueursParticipation_Add", lstSqlParam);
        }

        public int DeleteParticipants (List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@joueurId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@feuilleId", lst[1]));

            return Execute("JoueursParticipation_Delete", lstSqlParam);
        }
    }
}
