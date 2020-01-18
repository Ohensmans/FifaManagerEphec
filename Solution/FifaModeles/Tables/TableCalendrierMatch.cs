using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles.Tables
{
    public class TableCalendrierMatch
    {
        public DataTable getTable()
        {
            DataTable tableMatch = new DataTable();

            DataColumn countMatch = new DataColumn();
            countMatch.DataType = System.Type.GetType("System.Int32");
            countMatch.ColumnName = "Match n° :";
            tableMatch.Columns.Add(countMatch);

            DataColumn nomEquipeA = new DataColumn();
            nomEquipeA.DataType = System.Type.GetType("System.String");
            nomEquipeA.ColumnName = "Equipe à Domicile :";
            tableMatch.Columns.Add(nomEquipeA);

            DataColumn nomEquipeB = new DataColumn();
            nomEquipeB.DataType = System.Type.GetType("System.String");
            nomEquipeB.ColumnName = "Equipe à l'extérieur :";
            tableMatch.Columns.Add(nomEquipeB);

            DataColumn date = new DataColumn();
            date.DataType = System.Type.GetType("System.DateTime");
            date.ColumnName = "Date du Match :";
            tableMatch.Columns.Add(date);

            return tableMatch;

        }
    }
}
