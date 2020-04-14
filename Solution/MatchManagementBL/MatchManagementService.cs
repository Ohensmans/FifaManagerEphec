using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class MatchManagementService
    {
        //protected string _Connection = "Data Source=(local);Initial Catalog = FifaManagerEphec; Persist Security Info=True;User ID = MatchManagement; Password=ephec01";
        protected string _Connection = "Data Source = DESKTOP-C7PMR28\\COURS2019;Initial Catalog = FifaManagerEphec; User ID = MatchManagement; Password=ephec01";
        public MatchManagementService()
        {
            this.name = "";
        }

        public string name { get; set; }

        //transforme une datatable en liste typée
        protected static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        // vérifie que toutes les propriétés correspondent bien avec le type de l'objet cible
        protected static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //utilise les procédures stockées de lecture GetAll
        public DataView loadAllData ()
        {
            try
            {
                FifaDAL.MatchManagement.FifaManagementData oData = new FifaDAL.MatchManagement.FifaManagementData(_Connection);
                return oData.Load(this.name+"_GetAll", this.name).Tables[this.name].DefaultView;
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

        //utilise les procédures stockées de lecture procedureName
        public DataView loadSpecificTable(string newTableName, string procedureName)
        {
            try
            {
                FifaDAL.MatchManagement.FifaManagementData oData = new FifaDAL.MatchManagement.FifaManagementData(_Connection);
                return oData.Load(procedureName, newTableName).Tables[newTableName].DefaultView;
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
