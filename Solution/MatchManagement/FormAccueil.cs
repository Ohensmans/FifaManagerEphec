using FifaError;
using FifaModeles;
using MatchManagementBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchManagement
{
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        private void b_FeuMatch_Click(object sender, EventArgs e)
        {
            if ((Boolean)dataGridListeMatchs.SelectedRows[0].Cells[4].Value)
            {
                MessageBox.Show("Ce match est déjà joué");
            }
            else
            { 
                
                FormFeuilleDeMatch oForm = new FormFeuilleDeMatch((Guid)dataGridListeMatchs.SelectedRows[0].Cells[5].Value);
                oForm.MdiParent = this.MdiParent;

                oForm.Show();
            }
        }

        private void FormAccueil_Load(object sender, EventArgs e)
        {
            getChampionnats();

        }

        private void getChampionnats ()
        {
            cb_Champ.Items.Clear();
            try
            {
               ChampionnatsService champServ = new ChampionnatsService();
                foreach(ChampionnatsModele champModel in champServ.GetListeObject())
                {
                    cb_Champ.Items.Add(champModel.annee);
                }
            }
            catch (CustomsError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            cb_Champ.SelectedIndex = 0;
        }


        private void cb_Champ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MatchsService matchs = new MatchsService();
                dataGridListeMatchs.DataSource = GenerationTableauxAccueil.getMatchEquipe(System.Convert.ToInt32(cb_Champ.SelectedItem.ToString()));
                dataGridListeMatchs.Columns["matchId"].Visible = false;
            }
            catch (CustomsError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
