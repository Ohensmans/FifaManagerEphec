using FifaError;
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
    public partial class FormFeuilleDeMatch : Form
    {
        private Guid matchId;
        private Guid equipeAId;
        private Guid equipeBId;

        public FormFeuilleDeMatch()
        {
            InitializeComponent();
        }

        public FormFeuilleDeMatch(Guid matchId)
        {
            InitializeComponent();
            this.matchId = matchId;
        }

        private void FormFeuilleDeMatch_Load(object sender, EventArgs e)
        {
            getNames();
            getDataGrid();
        }

        private void getDataGrid()
        {
            try
            {
                dg_Equipe1.DataSource = GenerationTableauxFeuille.getFeuilleA(matchId, out equipeAId);

                dg_Equipe2.DataSource = GenerationTableauxFeuille.getFeuilleB(matchId, out equipeBId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getNames()
        {
            try
            {
                l_NomEquipe1.Text = GenerationInfosMatchs.getEquipeAName(matchId);
                l_NomEquipe2.Text = GenerationInfosMatchs.getEquipeBName(matchId);
                l_dateMatch.Text = "Match du : " + GenerationInfosMatchs.getDateMatch(matchId).ToString("dd/MM/yyyy");
                String pathpb = "./logos/";
                pb_Equipe1.Load(pathpb + GenerationInfosMatchs.getlogoEquipeA(matchId));
                pb_Equipe2.Load(pathpb + GenerationInfosMatchs.getlogoEquipeB(matchId));

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dg_Equipe1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dg_Equipe1.Columns["joueurId"].Visible = false;

                for (int i = 0; i < 4; i++)
                {
                    dg_Equipe1.Columns[i].ReadOnly = true;
                }

                for (int i = 0; i < dg_Equipe1.RowCount; i++)
                {
                    if (Convert.ToInt32(dg_Equipe1.Rows[i].Cells[1].Value.ToString()) > Convert.ToInt32(dg_Equipe1.Rows[i].Cells[3].Value.ToString()))
                    {
                        dg_Equipe1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        dg_Equipe1.Rows[i].ReadOnly = true;
                    }

                    if (Convert.ToInt32(dg_Equipe1.Rows[i].Cells[2].Value.ToString()) > 0)
                    {
                        dg_Equipe1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dg_Equipe1.Rows[i].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_Equipe2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dg_Equipe2.Columns["joueurId"].Visible = false;

                for (int i = 0; i < 4; i++)
                {
                    dg_Equipe2.Columns[i].ReadOnly = true;
                }

                for (int i = 0; i < dg_Equipe2.RowCount; i++)
                {
                    if (Convert.ToInt32(dg_Equipe2.Rows[i].Cells[1].Value.ToString()) > Convert.ToInt32(dg_Equipe2.Rows[i].Cells[3].Value.ToString()))
                    {
                        dg_Equipe2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        dg_Equipe2.Rows[i].ReadOnly = true;
                    }

                    if (Convert.ToInt32(dg_Equipe2.Rows[i].Cells[2].Value.ToString()) > 0)
                    {
                        dg_Equipe2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dg_Equipe2.Rows[i].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void b_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int countA = 0;

                for (int i = 0; i < dg_Equipe1.RowCount; i++)
                {
                    if ((Boolean)dg_Equipe1.Rows[i].Cells[4].Value)
                    {
                        countA++;
                    }
                }

                int countB = 0;
                for (int i = 0; i < dg_Equipe2.RowCount; i++)
                {
                    if ((Boolean)dg_Equipe2.Rows[i].Cells[4].Value)
                    {
                        countB++;
                    }
                }

                if (countA < 5 && countB >= 5)
                {
                    DialogResult dialogResult = MessageBox.Show("l'équipe A n'a pas assez de joueurs inscrits (min 5), si elle compte moins de joueurs que l'équipe B, elle sera forfait ! Souhaitez-vous enregistrer ?", "Confirm", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.SaveAll();
                        this.Close();
                    }
                }
                else if (countA >= 5 && countB < 5)
                {
                    DialogResult dialogResult = MessageBox.Show("l'équipe B n'a pas assez de joueurs inscrits (min 5), si elle compte moins de joueurs que l'équipe A, elle sera forfait ! Souhaitez-vous enregistrer ?", "Confirm", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.SaveAll();
                        this.Close();
                    }
                }
                else if (countA < 5 && countB < 5)
                {
                    DialogResult dialogResult = MessageBox.Show("les 2 équipes n'ont pas assez de joueurs inscrits (min 5), seule qui compte le moins de joueurs sera forfait ! Souhaitez-vous enregistrer ?", "Confirm", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.SaveAll();
                        this.Close();
                    }
                }
                else if (countA>=5 && countB>=5)
                {
                    this.SaveAll();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAll()
        {
            try
            {
                JoueursParticipationService jps = new JoueursParticipationService();
                jps.SaveAll((DataView)dg_Equipe1.DataSource, matchId, equipeAId);
                jps.SaveAll((DataView)dg_Equipe2.DataSource, matchId, equipeBId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
