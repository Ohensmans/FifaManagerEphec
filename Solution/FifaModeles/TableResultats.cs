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



            return tableResults;

        }

        public DataTable getTableResultatsCombo()
        {
            DataTable tableResults = new DataTable();

            DataColumn joueur = new DataColumn();
            joueur.DataType = System.Type.GetType("System.String");
            joueur.ColumnName = "joueursInscrits";
            tableResults.Columns.Add(joueur);

            return tableResults;

        }

    }
}
