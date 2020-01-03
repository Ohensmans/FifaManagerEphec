using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.MatchManagement
{
    public class CartonsJaunesData : FifaManagementData
    {
        public CartonsJaunesData(string _Connection) : base(_Connection)
        {
        }

        public int AddCarte(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@joueurId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@matchId", lst[1]));
            lstSqlParam.Add(new SqlParameter("@equipeId", lst[2]));
            lstSqlParam.Add(new SqlParameter("@minuteRecue", lst[3]));

            return Execute("CartonsJaunes_Add", lstSqlParam);
        }

        public int DeleteCarte(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@carteJauneId", lst[0]));
            return Execute("CartonsJaunes_Delete", lstSqlParam);
        }

        public int UpdateCarte(List<dynamic> lst)
        {
            List<SqlParameter> lstSqlParam = new List<SqlParameter>();

            lstSqlParam.Add(new SqlParameter("@carteJauneId", lst[0]));
            lstSqlParam.Add(new SqlParameter("@joueurId", lst[1]));
            lstSqlParam.Add(new SqlParameter("@matchId", lst[2]));
            lstSqlParam.Add(new SqlParameter("@minuteRecue", lst[3]));
            lstSqlParam.Add(new SqlParameter("@lastUpdate", lst[4]));
            return Execute("CartonsJaunes_Update", lstSqlParam);
        }
    }
}
