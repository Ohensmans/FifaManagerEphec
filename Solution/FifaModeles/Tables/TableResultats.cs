using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    public class TableResultats
    {
        // table pour les DataGrid dans la form Resultats
        public DataTable getTableResultats()
        {
            DataTable tableResults = new DataTable();

            DataColumn joueurId = new DataColumn();
            joueurId.DataType = System.Type.GetType("System.Guid");
            joueurId.ColumnName = "joueurId";
            tableResults.Columns.Add(joueurId);

            DataColumn joueur = new DataColumn();
            joueur.DataType = System.Type.GetType("System.String");
            joueur.ColumnName = "joueursInscrits";
            tableResults.Columns.Add(joueur);

            DataColumn minute = new DataColumn();
            minute.DataType = System.Type.GetType("System.Int32");
            minute.ColumnName = "minute";
            tableResults.Columns.Add(minute);

            DataColumn itemId = new DataColumn();
            itemId.DataType = System.Type.GetType("System.Guid");
            itemId.ColumnName = "itemId";
            tableResults.Columns.Add(itemId);

            DataColumn lastUpdate = new DataColumn();
            lastUpdate.DataType = System.Type.GetType("System.DateTime");
            lastUpdate.ColumnName = "lastUpdate";
            tableResults.Columns.Add(lastUpdate);

            return tableResults;

        }

        //table pour la liste des joueurs sur la feuille de match
        public DataTable getTableResultatsCombo()
        {
            DataTable tableResults = new DataTable();

            DataColumn joueurId = new DataColumn();
            joueurId.DataType = System.Type.GetType("System.Guid");
            joueurId.ColumnName = "joueurId";
            tableResults.Columns.Add(joueurId);

            DataColumn nom = new DataColumn();
            nom.DataType = System.Type.GetType("System.String");
            nom.ColumnName = "nom";
            tableResults.Columns.Add(nom);

            DataColumn prenom = new DataColumn();
            prenom.DataType = System.Type.GetType("System.String");
            prenom.ColumnName = "prenom";
            tableResults.Columns.Add(prenom);

            DataColumn lastUpdate = new DataColumn();
            lastUpdate.DataType = System.Type.GetType("System.DateTime");
            lastUpdate.ColumnName = "lastUpdate";
            tableResults.Columns.Add(lastUpdate);

            return tableResults;

        }

    }
}
