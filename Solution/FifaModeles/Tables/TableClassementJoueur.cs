using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles.Tables
{
    public class TableClassementJoueur
    {
        public DataTable getTable()
        {
            DataTable tableClassementEquipe = new DataTable();

            DataColumn Classement = new DataColumn();
            Classement.DataType = System.Type.GetType("System.Int32");
            Classement.ColumnName = "Classement :";
            tableClassementEquipe.Columns.Add(Classement);

            DataColumn joueur = new DataColumn();
            joueur.DataType = System.Type.GetType("System.String");
            joueur.ColumnName = "Joueur :";
            tableClassementEquipe.Columns.Add(joueur);

            DataColumn GoalsQ1 = new DataColumn();
            GoalsQ1.DataType = System.Type.GetType("System.Int32");
            GoalsQ1.ColumnName = "Goals Q1 :";
            tableClassementEquipe.Columns.Add(GoalsQ1);

            DataColumn GoalsQ2 = new DataColumn();
            GoalsQ2.DataType = System.Type.GetType("System.Int32");
            GoalsQ2.ColumnName = "Goals Q2 :";
            tableClassementEquipe.Columns.Add(GoalsQ2);

            DataColumn GoalsTotaux = new DataColumn();
            GoalsTotaux.DataType = System.Type.GetType("System.Int32");
            GoalsTotaux.ColumnName = "Goals Totaux";
            tableClassementEquipe.Columns.Add(GoalsTotaux);

            DataColumn CartonsJaunesQ1 = new DataColumn();
            CartonsJaunesQ1.DataType = System.Type.GetType("System.Int32");
            CartonsJaunesQ1.ColumnName = "Cartes Jaunes Q1 :";
            tableClassementEquipe.Columns.Add(CartonsJaunesQ1);

            DataColumn CartonsJaunesQ2 = new DataColumn();
            CartonsJaunesQ2.DataType = System.Type.GetType("System.Int32");
            CartonsJaunesQ2.ColumnName = "Cartes Jaunes Q2 :";
            tableClassementEquipe.Columns.Add(CartonsJaunesQ2);

            DataColumn CartonsJaunesTotaux = new DataColumn();
            CartonsJaunesTotaux.DataType = System.Type.GetType("System.Int32");
            CartonsJaunesTotaux.ColumnName = "Cartes Jaunes Totales";
            tableClassementEquipe.Columns.Add(CartonsJaunesTotaux);

            DataColumn CartonsRougesQ1 = new DataColumn();
            CartonsRougesQ1.DataType = System.Type.GetType("System.Int32");
            CartonsRougesQ1.ColumnName = "Cartes Rouges Q1 :";
            tableClassementEquipe.Columns.Add(CartonsRougesQ1);

            DataColumn CartonsRougesQ2 = new DataColumn();
            CartonsRougesQ2.DataType = System.Type.GetType("System.Int32");
            CartonsRougesQ2.ColumnName = "Cartes Rouges Q2 :";
            tableClassementEquipe.Columns.Add(CartonsRougesQ2);

            DataColumn CartonsRougesTotaux = new DataColumn();
            CartonsRougesTotaux.DataType = System.Type.GetType("System.Int32");
            CartonsRougesTotaux.ColumnName = "Cartes Rouges Totales";
            tableClassementEquipe.Columns.Add(CartonsRougesTotaux);

            DataColumn CartonsValeur = new DataColumn();
            CartonsValeur.DataType = System.Type.GetType("System.Int32");
            CartonsValeur.ColumnName = "CartonsValeur";
            tableClassementEquipe.Columns.Add(CartonsValeur);

            return tableClassementEquipe;

        }
    }
}
