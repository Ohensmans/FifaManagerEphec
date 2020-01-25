using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles.Tables
{
    public class TableClassementEquipe
    {
        public DataTable getTable()
        {
            DataTable tableClassementEquipe = new DataTable();

            DataColumn Classement = new DataColumn();
            Classement.DataType = System.Type.GetType("System.Int32");
            Classement.ColumnName = "Classement :";
            tableClassementEquipe.Columns.Add(Classement);

            DataColumn equipe = new DataColumn();
            equipe.DataType = System.Type.GetType("System.String");
            equipe.ColumnName = "Equipe :";
            tableClassementEquipe.Columns.Add(equipe);

            DataColumn pointsQ1 = new DataColumn();
            pointsQ1.DataType = System.Type.GetType("System.Int32");
            pointsQ1.ColumnName = "Points Q1 :";
            tableClassementEquipe.Columns.Add(pointsQ1);

            DataColumn pointsQ2 = new DataColumn();
            pointsQ2.DataType = System.Type.GetType("System.Int32");
            pointsQ2.ColumnName = "Points Q2 :";
            tableClassementEquipe.Columns.Add(pointsQ2);

            DataColumn pointsTotaux = new DataColumn();
            pointsTotaux.DataType = System.Type.GetType("System.Int32");
            pointsTotaux.ColumnName = "Points Totaux";
            tableClassementEquipe.Columns.Add(pointsTotaux);

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
