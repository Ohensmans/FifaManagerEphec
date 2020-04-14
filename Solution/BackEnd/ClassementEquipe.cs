using BackEndBL;
using BackEndBL.GenerationTableaux;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackEnd
{
    public partial class ClassementEquipe : Form
    {
        private DataTable oTable;

        public ClassementEquipe()
        {
            InitializeComponent();
        }

        private void ClassementEquipe_Load(object sender, EventArgs e)
        {
            resetCombo();
        }

        private void resetCombo()
        {
            try
            {
                List<ChampionnatsModele> lChampionnats = new ChampionnatService().ListAll();

                if (lChampionnats.Count != 0)
                {
                    foreach (ChampionnatsModele championnat in lChampionnats)
                    {
                        cb_Championnat.Items.Add(championnat.annee);
                    }
                    cb_Championnat.Sorted = true;

                    cb_Classement.Items.Add("Points");
                    cb_Classement.Items.Add("Goals");
                    cb_Classement.Items.Add("Cartes");

                    cb_Championnat.SelectedIndex = 0;
                    cb_Classement.SelectedItem = "Points";
                }
                else
                {
                    MessageBox.Show("Pour afficher les classements, il faut au moins qu'un championnat existe");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cb_Championnat_SelectedIndexChanged(object sender, EventArgs e)
        {
                loadDataGrid();
        }

        private void loadDataGrid()
        {
            try
            {
                if (cb_Championnat.SelectedItem.ToString() != null)
                {
                    //crée la date du 31/12/championnat.year
                    DateTime date = new DateTime(Convert.ToInt32(cb_Championnat.SelectedItem.ToString()), 12, 31);

                    //récupère la table de classement pour toute l'année du championnat
                    oTable = new GenerationTabClassementEquipe().getClassementEquipe(date);
                    dg_Classement.DataSource = oTable.DefaultView;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_Classement_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetDataGrid();

            if (cb_Classement.SelectedItem.ToString() == "Goals")
            {
                dg_Classement.Columns["Goals Q1 :"].Visible = true;
                dg_Classement.Columns["Goals Q2 :"].Visible = true;
                dg_Classement.Columns["Goals Totaux"].Visible = true;

                oTable.DefaultView.Sort = "Goals Totaux desc";

            }
            else if (cb_Classement.SelectedItem.ToString() == "Cartes")
            {
                dg_Classement.Columns["Cartes Jaunes Q1 :"].Visible = true;
                dg_Classement.Columns["Cartes Jaunes Q2 :"].Visible = true;
                dg_Classement.Columns["Cartes Jaunes Totales"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Q1 :"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Q2 :"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Totales"].Visible = true;

                oTable.DefaultView.Sort = "CartonsValeur desc";
            }
            else
            {
                dg_Classement.Columns["Points Q1 :"].Visible = true;
                dg_Classement.Columns["Points Q2 :"].Visible = true;
                dg_Classement.Columns["Points Totaux"].Visible = true;

                oTable.DefaultView.Sort = "Points Totaux desc";
            }
            ClasserEquipes();
        }

        private void resetDataGrid()
        {

            dg_Classement.Columns["Points Q1 :"].Visible = false;
            dg_Classement.Columns["Points Q2 :"].Visible = false;
            dg_Classement.Columns["Points Totaux"].Visible = false;
            dg_Classement.Columns["Goals Q1 :"].Visible = false;
            dg_Classement.Columns["Goals Q2 :"].Visible = false;
            dg_Classement.Columns["Goals Totaux"].Visible = false;
            dg_Classement.Columns["Cartes Jaunes Q1 :"].Visible = false;
            dg_Classement.Columns["Cartes Jaunes Q2 :"].Visible = false;
            dg_Classement.Columns["Cartes Jaunes Totales"].Visible = false;
            dg_Classement.Columns["Cartes Rouges Q1 :"].Visible = false;
            dg_Classement.Columns["Cartes Rouges Q2 :"].Visible = false;
            dg_Classement.Columns["Cartes Rouges Totales"].Visible = false;
            dg_Classement.Columns["CartonsValeur"].Visible = false;
        }

        private void ClasserEquipes()
        {
            int i = 1;
            foreach (DataRowView row in oTable.DefaultView)
            {
                row["Classement :"] = i;
                i++;
            }
        }

        private void b_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
