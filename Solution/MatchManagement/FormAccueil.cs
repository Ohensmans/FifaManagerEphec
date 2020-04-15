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

            if (!checkMatchJoueApres(dataGridListeMatchs.SelectedRows[0].Index))
            {
                if (!checkMatchPasJoueAvant(dataGridListeMatchs.SelectedRows[0].Index))
                {
                    if ((Boolean)dataGridListeMatchs.SelectedRows[0].Cells[4].Value)
                    {
                        MessageBox.Show("Ce match a déjà une feuille de match remplie");
                    }
                    else
                    {

                        FormFeuilleDeMatch oForm = new FormFeuilleDeMatch((Guid)dataGridListeMatchs.SelectedRows[0].Cells[6].Value);
                        oForm.MdiParent = this.MdiParent;

                        oForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Il faut remplir de manière chronologique les matchs, une des 2 équipes n'a pas joué un match précédent");
                }

            }
            else
            {
                MessageBox.Show("Un match postérieur a déjà été joué par une des 2 équipes, il n'est pas possible de modifier cette feuille de match");
            }
        }

        // vérifie si il y a un match joué pour une des 2 équipes postérieure à celle sélectionnée
        private bool checkMatchJoueApres(int indexSelectedRow)
        {
            for (int i = indexSelectedRow + 1; i < dataGridListeMatchs.Rows.Count; i++)
            {
                if ((dataGridListeMatchs.Rows[i].Cells["Equipe A :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe A :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe B :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe A :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe A :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe B :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe B :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe B :"].Value))
                    && (bool)dataGridListeMatchs.Rows[i].Cells["Match Joué : "].Value)
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkMatchPasJoueAvant(int indexSelectedRow)
        {
            for (int i = indexSelectedRow - 1; i >= 0; i--)
            {
                if ((dataGridListeMatchs.Rows[i].Cells["Equipe A :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe A :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe B :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe A :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe A :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe B :"].Value)
                    || dataGridListeMatchs.Rows[i].Cells["Equipe B :"].Value.Equals(dataGridListeMatchs.Rows[indexSelectedRow].Cells["Equipe B :"].Value))
                    && !(bool)dataGridListeMatchs.Rows[i].Cells["Match Joué : "].Value)
                {
                    return true;
                }
            }
            return false;
        }

        private void FormAccueil_Load(object sender, EventArgs e)
        {
            getChampionnats();

        }

        private void getChampionnats()
        {
            cb_Champ.Items.Clear();
            try
            {
                ChampionnatsService champServ = new ChampionnatsService();
                foreach (ChampionnatsModele champModel in champServ.GetListeObject())
                {
                    cb_Champ.Items.Add(champModel.annee);
                }
                cb_Champ.Sorted = true;

                cb_Champ.SelectedIndex = 0;
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            
        }


        private void cb_Champ_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload();
        }


        private void reload()
        {
            try
            {
                dataGridListeMatchs.DataSource = GenerationTableauxAccueil.getMatchEquipe(System.Convert.ToInt32(cb_Champ.SelectedItem.ToString()));
                dataGridListeMatchs.Columns["matchId"].Visible = false;
                dataGridListeMatchs.Sort(this.dataGridListeMatchs.Columns[0], ListSortDirection.Ascending);

            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void b_Refresh_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resultats oForm = new Resultats((Guid)dataGridListeMatchs.SelectedRows[0].Cells[6].Value, (Boolean)dataGridListeMatchs.SelectedRows[0].Cells[5].Value);
            oForm.MdiParent = this.MdiParent;

            oForm.Show();
        }
    }
}
