using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaDAL.BackEnd
{
    public class FifaManagementService
    {
        protected String _Connection;
        public List<dynamic> lRead;
        public int _Return;
        protected static String ROLE = "MatchManagement.";

        public FifaManagementService(String _Connection)
        {
            this._Connection = _Connection;
        }

        public virtual dynamic CreateObject (List<dynamic> lValeurs)
        {
            return null;
        }

        public int MyExecute(string pStoredName, List<SqlParameter> lstParam)
        {
            _Return = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = _Connection;

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = ROLE + pStoredName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter oParam in lstParam)
                {
                    cmd.Parameters.Add(oParam);
                }

                cmd.Connection = con;
                _Return = cmd.ExecuteNonQuery();

                con.Close();
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
            return _Return;
        }

        public List<dynamic> MyExecuteSelect(string pStoredName, string pTab)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = _Connection;
            SqlDataReader oReader;
            List<dynamic> lModele = new List<dynamic>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = ROLE + pStoredName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                oReader = cmd.ExecuteReader();

                while (oReader.Read())
                {
                    List<dynamic> lParam = new List<dynamic>();

                    for (int i = 0; i < oReader.FieldCount; i++)
                    {
                        lParam.Add(oReader.GetValue(i));
                    }

                    lModele = CreateObject(lParam);
                }
                con.Close();
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
            return lModele;
        }

        public dynamic MyExecuteSelectOne(string pStoredName, string pTab, List<SqlParameter> lstParamIn)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = _Connection;
            SqlDataReader oReader;
            dynamic oDyn = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = ROLE + pStoredName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter oParam in lstParamIn)
                {
                    cmd.Parameters.Add(oParam);
                }

                cmd.Connection = con;
                oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    List<dynamic> lParam = new List<dynamic>();

                    for (int i = 0; i < oReader.FieldCount; i++)
                    {
                        lParam.Add(oReader.GetValue(i));
                    }

                        oDyn = CreateObject(lParam);
                }
                con.Close();
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
            return oDyn;
        }



    }
}
