using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    public class TableFeuilleMatch
    {
        public DataTable getTable()
        {
            DataTable tableNettoyee = new DataTable();

            DataColumn joueur = new DataColumn();
            joueur.DataType = System.Type.GetType("System.String");
            joueur.ColumnName = "Joueurs Inscrits :";
            tableNettoyee.Columns.Add(joueur);

            DataColumn nbreCartonsJaunes = new DataColumn();
            nbreCartonsJaunes.DataType = System.Type.GetType("System.Int32");
            nbreCartonsJaunes.ColumnName = "Nombres de cartons jaunes actifs :";
            tableNettoyee.Columns.Add(nbreCartonsJaunes);

            DataColumn nbreSuspension = new DataColumn();
            nbreSuspension.DataType = System.Type.GetType("System.Int32");
            nbreSuspension.ColumnName = "Nombre de suspensions restantes";
            tableNettoyee.Columns.Add(nbreSuspension);

            DataColumn nbreMatchsRestants = new DataColumn();
            nbreMatchsRestants.DataType = System.Type.GetType("System.Int32");
            nbreMatchsRestants.ColumnName = "Nombre de matchs restants :";
            tableNettoyee.Columns.Add(nbreMatchsRestants);

            DataColumn selection = new DataColumn();
            selection.DataType = System.Type.GetType("System.Boolean");
            selection.ColumnName = "Est sélectionné : ";
            tableNettoyee.Columns.Add(selection);

            DataColumn joueurId = new DataColumn();
            joueurId.DataType = System.Type.GetType("System.Guid");
            joueurId.ColumnName = "joueurId";
            tableNettoyee.Columns.Add(joueurId);

            return tableNettoyee;

        }
    }
}
