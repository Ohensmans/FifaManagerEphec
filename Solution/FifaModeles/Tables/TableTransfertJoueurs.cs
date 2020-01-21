using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles.Tables
{
    public class TableTransfertJoueurs
    {
        public DataTable getTable()
        {
            DataTable tableTransferts = new DataTable();

            DataColumn joueur = new DataColumn();
            joueur.DataType = System.Type.GetType("System.String");
            joueur.ColumnName = "Joueur :";
            tableTransferts.Columns.Add(joueur);

            DataColumn equipe = new DataColumn();
            equipe.DataType = System.Type.GetType("System.String");
            equipe.ColumnName = "Equipe :";
            tableTransferts.Columns.Add(equipe);

            DataColumn dateIn = new DataColumn();
            dateIn.DataType = System.Type.GetType("System.DateTime");
            dateIn.ColumnName = "Date arrivee :";
            tableTransferts.Columns.Add(dateIn);

            DataColumn dateOut = new DataColumn();
            dateOut.DataType = System.Type.GetType("System.DateTime");
            dateOut.ColumnName = "Date du transfert :";
            tableTransferts.Columns.Add(dateOut);

            return tableTransferts;

        }
    }
}
