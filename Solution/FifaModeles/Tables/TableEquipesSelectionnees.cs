using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles.Tables
{
    public class TableEquipesSelectionnees
    {
        public DataTable getTable()
        {
            DataTable tableEquipe = new DataTable();

            DataColumn nomEquipe = new DataColumn();
            nomEquipe.DataType = System.Type.GetType("System.String");
            nomEquipe.ColumnName = "Equipes Actives :";
            tableEquipe.Columns.Add(nomEquipe);

            DataColumn selection = new DataColumn();
            selection.DataType = System.Type.GetType("System.Boolean");
            selection.ColumnName = "Est sélectionné : ";
            tableEquipe.Columns.Add(selection);

            return tableEquipe;

        }
    }
}
