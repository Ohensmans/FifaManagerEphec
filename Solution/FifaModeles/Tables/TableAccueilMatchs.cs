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
            DataTable tableAccueil = new DataTable();

            DataColumn date = new DataColumn();
            date.DataType = System.Type.GetType("System.DateTime");
            date.ColumnName = "Date du Match :";
            tableAccueil.Columns.Add(date);

            DataColumn equipeA = new DataColumn();
            equipeA.DataType = System.Type.GetType("System.String");
            equipeA.ColumnName = "Equipe A :";
            tableAccueil.Columns.Add(equipeA);

            DataColumn equipeB = new DataColumn();
            equipeB.DataType = System.Type.GetType("System.String");
            equipeB.ColumnName = "Equipe B :";
            tableAccueil.Columns.Add(equipeB);

            DataColumn resultat = new DataColumn();
            resultat.DataType = System.Type.GetType("System.String");
            resultat.ColumnName = "Résultat :";
            tableAccueil.Columns.Add(resultat);

            DataColumn feuilleRemplie = new DataColumn();
            feuilleRemplie.DataType = System.Type.GetType("System.Boolean");
            feuilleRemplie.ColumnName = "Feuille de Match remplie : ";
            tableAccueil.Columns.Add(feuilleRemplie);

            DataColumn matchJoue = new DataColumn();
            matchJoue.DataType = System.Type.GetType("System.Boolean");
            matchJoue.ColumnName = "Match Joué : ";
            tableAccueil.Columns.Add(matchJoue);

            DataColumn matchId = new DataColumn();
            matchId.DataType = System.Type.GetType("System.Guid");
            matchId.ColumnName = "matchId";
            tableAccueil.Columns.Add(matchId);

            return tableAccueil;

        }

    }
}
