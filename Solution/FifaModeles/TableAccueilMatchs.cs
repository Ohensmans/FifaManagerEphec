using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    public class TableAccueilMatchs
    {

        public DataTable getTable()
        {
            DataTable tableNettoyee = new DataTable();

            DataColumn date = new DataColumn();
            date.DataType = System.Type.GetType("System.DateTime");
            date.ColumnName = "Date du Match :";
            tableNettoyee.Columns.Add(date);

            DataColumn equipeA = new DataColumn();
            equipeA.DataType = System.Type.GetType("System.String");
            equipeA.ColumnName = "Equipe A :";
            tableNettoyee.Columns.Add(equipeA);

            DataColumn equipeB = new DataColumn();
            equipeB.DataType = System.Type.GetType("System.String");
            equipeB.ColumnName = "Equipe B :";
            tableNettoyee.Columns.Add(equipeB);

            DataColumn resultat = new DataColumn();
            resultat.DataType = System.Type.GetType("System.String");
            resultat.ColumnName = "Résultat :";
            tableNettoyee.Columns.Add(resultat);

            DataColumn matchJoue = new DataColumn();
            matchJoue.DataType = System.Type.GetType("System.Boolean");
            matchJoue.ColumnName = "Match Joué : ";
            tableNettoyee.Columns.Add(matchJoue);

            DataColumn matchId = new DataColumn();
            matchId.DataType = System.Type.GetType("System.Guid");
            matchId.ColumnName = "matchId";
            tableNettoyee.Columns.Add(matchId);

            return tableNettoyee;

        }

    }
}
