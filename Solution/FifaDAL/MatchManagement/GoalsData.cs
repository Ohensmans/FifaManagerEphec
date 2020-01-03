using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.MatchManagement
{
    public class GoalsData : FifaManagementData
    {
        public GoalsData(string _Connection) : base(_Connection)
        {
        }

        public int AddGoal(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@joueurId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@matchId", lst[1]));
            lstSqlParam.Add(new SqlParameter("@equipeId", lst[2]));
            lstSqlParam.Add(new SqlParameter("@minuteMarque", lst[3]));

            return Execute("Goals_Add", lstSqlParam);
        }

        public int DeleteGoal(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@goalId", lst[0]));
            return Execute("Goals_Delete", lstSqlParam);
        }

        public int UpdateGoal(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@goalId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@joueurId", lst[1]));
            lstSqlParam.Add(new SqlParameter("@matchId", lst[2]));
            lstSqlParam.Add(new SqlParameter("@minuteMarque", lst[3]));
            lstSqlParam.Add(new SqlParameter("@lastUpdate", lst[4]));
            return Execute("Goals_Update", lstSqlParam);
        }

    }
}
