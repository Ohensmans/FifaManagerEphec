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
    public class FifaManagementData
    {
        protected String _Connection;
        public List<dynamic> lRead;
        protected static String ROLE = "MatchManagement.";

        //Reçoit la connection string qui sera dans le constructeur dans le BL
        public FifaManagementData(String _Connection)
        {
            this._Connection = _Connection;
        }


        //lance la procédure stockée sans lecture pStoredName avec la liste de paramètres lstParam et renvoie un int
        public int Execute(string pStoredName, List<SqlParameter> lstParam)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = _Connection;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = ROLE + pStoredName;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (SqlParameter oParam in lstParam)
                        {
                            cmd.Parameters.Add(oParam);
                        }
                        cmd.Connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exsql)
            {
                CustomsError oErreur = new CustomsError(exsql);
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //lance la procédure stockée avec lecture pStoredName et renvoie un DataSet avec une table du nom newTableName
        public DataSet Load(string pStoredName, string newTableName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = _Connection;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        
                        cmd.Connection = con;
                        cmd.CommandText = ROLE + pStoredName;
                        cmd.CommandType = CommandType.StoredProcedure;

                        adapter.SelectCommand = cmd;

                        DataSet data = new DataSet();
                        adapter.Fill(data, newTableName);
                        return data;
                    }
                }
            }

            catch (SqlException exsql)
            {
                CustomsError oErreur = new CustomsError(exsql);
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
