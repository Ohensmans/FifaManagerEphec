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
    public class TransfertsData : FifaManagementData
    {
        public TransfertsData(string _Connection) : base(_Connection)
        {
        }

        public DataSet getParticipants(List<dynamic> lst, string newTableName)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@equipeId", lst[0]));
                lstSqlParam.Add(new SqlParameter("@matchDate", lst[1]));
                return LoadOne("Transferts_GetParticipants", lstSqlParam, newTableName);

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
