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
                    oTable = new GenerationTabClassementEquipe().getClassementEquipe(Convert.ToInt32(cb_Championnat.SelectedItem.ToString()));
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

                oTable.DefaultView.Sort = "Goals Totaux asc";

            }
            else if (cb_Classement.SelectedItem.ToString() == "Cartes")
            {
                dg_Classement.Columns["Cartes Jaunes Q1 :"].Visible = true;
                dg_Classement.Columns["Cartes Jaunes Q2 :"].Visible = true;
                dg_Classement.Columns["Cartes Jaunes Totales"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Q1 :"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Q2 :"].Visible = true;
                dg_Classement.Columns["Cartes Rouges Totales"].Visible = true;

                oTable.DefaultView.Sort = "CartonsValeur asc";
            }
            else
            {
                dg_Classement.Columns["Points Q1 :"].Visible = true;
                dg_Classement.Columns["Points Q2 :"].Visible = true;
                dg_Classement.Columns["Points Totaux :"].Visible = true;

                oTable.DefaultView.Sort = "Points Totaux : asc";
            }
        }

        private void resetDataGrid()
        {

            dg_Classement.Columns["Points Q1 :"].Visible = false;
            dg_Classement.Columns["Points Q2 :"].Visible = false;
            dg_Classement.Columns["Points Totaux :"].Visible = false;
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
    }
}
