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
    public partial class Resultats : Form
    {
        private Guid matchId;
        private Guid equipeAId;
        private Guid equipeBId;

        public Resultats(Guid matchId)
        {
            InitializeComponent();
            this.matchId = matchId;
           
        }

        private void getDataGridGoalA()
        {
            try
            {
                DataView GoalA = GenerationTablesResults.getFeuilleA(matchId, out equipeAId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                
                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeAId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }

                dg_GoalsEq1.Columns.Add("joueurId", "joueurId");
                dg_GoalsEq1.Columns.Add(comboxColonne);
                dg_GoalsEq1.Columns.Add("minute", "Minute :");
                dg_GoalsEq1.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in GoalA)
                {
                    dg_GoalsEq1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_GoalsEq1.Columns[0].Visible = false;
                dg_GoalsEq1.Columns[3].Visible = false;
                dg_GoalsEq1.Sort(this.dg_GoalsEq1.Columns[2], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDataGridGoalB()
        {
            try
            {
                DataView GoalB = GenerationTablesResults.getFeuilleB(matchId, out equipeBId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";

                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeBId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }

                dg_GoalsEq2.Columns.Add("joueurId", "joueurId");
                dg_GoalsEq2.Columns.Add(comboxColonne);
                dg_GoalsEq2.Columns.Add("minute", "Minute :");
                dg_GoalsEq2.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in GoalB)
                {
                    dg_GoalsEq2.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_GoalsEq2.Columns[0].Visible = false;
                dg_GoalsEq2.Columns[3].Visible = false;
                dg_GoalsEq2.Sort(this.dg_GoalsEq2.Columns[2], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDataGridCarteJauneA()
        {
            try
            {
                DataView carteJ = GenerationTablesResults.fillInCartesJaunes(equipeAId, matchId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";

                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeAId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }

                dg_CartJauEq1.Columns.Add("joueurId", "joueurId");
                dg_CartJauEq1.Columns.Add(comboxColonne);
                dg_CartJauEq1.Columns.Add("minute", "Minute :");
                dg_CartJauEq1.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in carteJ)
                {
                    dg_CartJauEq1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_CartJauEq1.Columns[0].Visible = false;
                dg_CartJauEq1.Columns[3].Visible = false;
                dg_CartJauEq1.Sort(this.dg_CartJauEq1.Columns[2], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDataGridCarteJauneB()
        {
            try
            {
                DataView carteJ = GenerationTablesResults.fillInCartesJaunes(equipeBId, matchId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";

                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeBId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }


                dg_CartJaunEq2.Columns.Add("joueurId", "joueurId");
                dg_CartJaunEq2.Columns.Add(comboxColonne);
                dg_CartJaunEq2.Columns.Add("minute", "Minute :");
                dg_CartJaunEq2.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in carteJ)
                {
                    dg_CartJaunEq2.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_CartJaunEq2.Columns[0].Visible = false;
                dg_CartJaunEq2.Columns[3].Visible = false;
                dg_CartJaunEq2.Sort(this.dg_CartJaunEq2.Columns[2], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void getDataGridCarteRougeA()
        {
            try
            {
                DataView carteJ = GenerationTablesResults.fillInCartesRouges(equipeAId, matchId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";

                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeAId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }


                dg_CartRougEq1.Columns.Add("joueurId", "joueurId");
                dg_CartRougEq1.Columns.Add(comboxColonne);
                dg_CartRougEq1.Columns.Add("minute", "Minute :");
                dg_CartRougEq1.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in carteJ)
                {
                    dg_CartRougEq1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_CartRougEq1.Columns[0].Visible = false;
                dg_CartRougEq1.Columns[3].Visible = false;
                dg_CartRougEq1.Sort(this.dg_CartRougEq1.Columns[2], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDataGridCarteRougeB()
        {
            try
            {
                DataView carteJ = GenerationTablesResults.fillInCartesRouges(equipeBId, matchId);

                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";

                foreach (DataRowView dr in GenerationTablesResults.getJoueurs(matchId, equipeBId))
                {
                    comboxColonne.Items.Add(dr[0]);
                }


                dg_CartRougEq2.Columns.Add("joueurId", "joueurId");
                dg_CartRougEq2.Columns.Add(comboxColonne);
                dg_CartRougEq2.Columns.Add("minute", "Minute :");
                dg_CartRougEq2.Columns.Add("itemId", "itemId");

                foreach (DataRowView dr in carteJ)
                {
                    dg_CartRougEq2.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
                dg_CartRougEq2.Columns[0].Visible = false;
                dg_CartRougEq2.Columns[3].Visible = false;
                dg_CartRougEq2.Sort(this.dg_CartRougEq2.Columns[2], ListSortDirection.Ascending);
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


        private void getDataGrid()
        {
            getDataGridGoalA();
            getDataGridGoalB();
            getDataGridCarteJauneA();
            getDataGridCarteJauneB();
            getDataGridCarteRougeA();
            getDataGridCarteRougeB();           
        }

        private void Resultats_Load(object sender, EventArgs e)
        {
            getDataGrid();
            getNames();
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkFull((DataView)dg_GoalsEq1.DataSource) || checkFull((DataView)dg_GoalsEq2.DataSource)
                    || checkFull((DataView)dg_CartJauEq1.DataSource)|| checkFull((DataView)dg_CartJaunEq2.DataSource)
                    || checkFull((DataView)dg_CartRougEq1.DataSource)||checkFull((DataView)dg_CartRougEq2.DataSource))
                {
                    GoalsService gs = new GoalsService();
                    gs.SaveAll((DataView)dg_GoalsEq1.DataSource, matchId, equipeAId);
                    gs.SaveAll((DataView)dg_GoalsEq2.DataSource, matchId, equipeBId);

                    CartesJaunesService cjs = new CartesJaunesService();
                    cjs.SaveAll((DataView)dg_CartJauEq1.DataSource, matchId, equipeAId);
                    cjs.SaveAll((DataView)dg_CartJaunEq2.DataSource, matchId, equipeBId);

                    CartesRougesService crs = new CartesRougesService();
                    crs.SaveAll((DataView)dg_CartRougEq1.DataSource, matchId, equipeAId);
                    crs.SaveAll((DataView)dg_CartRougEq2.DataSource, matchId, equipeBId);
                }
                else
                {
                    MessageBox.Show("Tous les champs doivent être soit remplis soit vides");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean checkFull(DataView oView)
        {
            Boolean check = true;

            foreach (DataRowView dr in oView)
            {
                if (Object.ReferenceEquals(dr[1],null) || Object.ReferenceEquals(dr[2], null))
                {
                    check = false;
                }
            }
            return check;
        }


    }
}
