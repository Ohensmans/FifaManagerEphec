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

        public DataSet getMatchUnJoueurUnQuarter(List<dynamic> lst, string newTableName)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@dateDebutQuarter", lst[0]));
                lstSqlParam.Add(new SqlParameter("@dateFinQuarter", lst[1]));
                lstSqlParam.Add(new SqlParameter("@joueurId", lst[2]));
                return LoadOne("Matchs_GetParticipationOneJoueurOneQuarter", lstSqlParam, newTableName);

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

        public DataSet getMatchUneEquipeUnQuarter(List<dynamic> lst, string newTableName)
        {
            try
            {
                List<SqlParameter> lstSqlParam = new List<SqlParameter>();

                lstSqlParam.Add(new SqlParameter("@dateDebutQuarter", lst[0]));
                lstSqlParam.Add(new SqlParameter("@dateFinQuarter", lst[1]));
                lstSqlParam.Add(new SqlParameter("@equipeId", lst[2]));
                return LoadOne("[Matchs_GetParticipationOneEquipeOneQuarter]", lstSqlParam, newTableName);

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
