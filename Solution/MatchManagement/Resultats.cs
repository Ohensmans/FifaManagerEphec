using FifaModeles;
using MatchManagementBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        private List<JoueursModele> lJoueursEqA;
        private List<JoueursModele> lJoueursEqB;
        DataView GoalA;
        DataView GoalB;
        DataView carteJ;
        DataView carteJ2;
        DataView carteR;
        DataView carteR2;
        Boolean isPlayed;

        public Resultats(Guid matchId, Boolean isPlayed)
        {
            InitializeComponent();
            this.matchId = matchId;
            this.isPlayed = isPlayed;           
        }

        private void getDataGridGoalA()
        {
            try
            {               
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";
                
                foreach (JoueursModele jm in lJoueursEqA)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_GoalsEq1.DataSource = GoalA;
                dg_GoalsEq1.Columns.Add(comboxColonne);

                dg_GoalsEq1.Columns["joueurId"].DisplayIndex = 0;
                dg_GoalsEq1.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_GoalsEq1.Columns["minute"].DisplayIndex = 2;
                dg_GoalsEq1.Columns["itemId"].DisplayIndex = 4;
                dg_GoalsEq1.Columns["combo"].DisplayIndex = 3;
                dg_GoalsEq1.Columns["lastUpdate"].DisplayIndex = 5;

                dg_GoalsEq1.Columns["joueurId"].Visible = false;
                dg_GoalsEq1.Columns["itemId"].Visible = false;
                dg_GoalsEq1.Sort(this.dg_GoalsEq1.Columns["minute"], ListSortDirection.Ascending);
                dg_GoalsEq1.Columns["lastUpdate"].Visible = false;

                if (lJoueursEqA.Count < 5 || lJoueursEqB.Count<5)
                {
                    dg_GoalsEq1.ReadOnly = true;
                }
                else
                {
                    dg_GoalsEq1.Columns["joueursInscrits"].ReadOnly = true;
                    dg_GoalsEq1.Columns["minute"].ReadOnly = false;
                    dg_GoalsEq1.Columns["itemId"].ReadOnly = true;
                    dg_GoalsEq1.Columns["combo"].ReadOnly = false;
                }

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
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";

                foreach (JoueursModele jm in lJoueursEqB)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_GoalsEq2.DataSource = GoalB;
                dg_GoalsEq2.Columns.Add(comboxColonne);

                dg_GoalsEq2.Columns["joueurId"].DisplayIndex = 0;
                dg_GoalsEq2.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_GoalsEq2.Columns["minute"].DisplayIndex = 2;
                dg_GoalsEq2.Columns["itemId"].DisplayIndex = 4;
                dg_GoalsEq2.Columns["combo"].DisplayIndex = 3;
                dg_GoalsEq2.Columns["lastUpdate"].DisplayIndex = 5;

                dg_GoalsEq2.Columns["joueurId"].Visible = false;
                dg_GoalsEq2.Columns["itemId"].Visible = false;
                dg_GoalsEq2.Sort(this.dg_GoalsEq2.Columns["minute"], ListSortDirection.Ascending);
                dg_GoalsEq2.Columns["lastUpdate"].Visible = false;

                if (lJoueursEqA.Count < 5 || lJoueursEqB.Count < 5)
                {
                    dg_GoalsEq2.ReadOnly = true;
                }
                else
                {
                    dg_GoalsEq2.Columns["joueursInscrits"].ReadOnly = true;
                    dg_GoalsEq2.Columns["minute"].ReadOnly = false;
                    dg_GoalsEq2.Columns["itemId"].ReadOnly = true;
                    dg_GoalsEq2.Columns["combo"].ReadOnly = false;
                }
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
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";

                foreach (JoueursModele jm in lJoueursEqA)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_CartJauEq1.DataSource = carteJ;
                dg_CartJauEq1.Columns.Add(comboxColonne);

                dg_CartJauEq1.Columns["joueurId"].DisplayIndex = 0;
                dg_CartJauEq1.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_CartJauEq1.Columns["minute"].DisplayIndex = 2;
                dg_CartJauEq1.Columns["itemId"].DisplayIndex = 4;
                dg_CartJauEq1.Columns["combo"].DisplayIndex = 3;
                dg_CartJauEq1.Columns["lastUpdate"].DisplayIndex = 5;

                dg_CartJauEq1.Columns["joueurId"].Visible = false;
                dg_CartJauEq1.Columns["itemId"].Visible = false;
                dg_CartJauEq1.Sort(this.dg_CartJauEq1.Columns["minute"], ListSortDirection.Ascending);
                dg_CartJauEq1.Columns["lastUpdate"].Visible = false;

                if (isPlayed)
                {
                    dg_CartJauEq1.ReadOnly = true;
                }
                else
                {
                    dg_CartJauEq1.Columns["joueursInscrits"].ReadOnly = true;
                    dg_CartJauEq1.Columns["minute"].ReadOnly = false;
                    dg_CartJauEq1.Columns["itemId"].ReadOnly = true;
                    dg_CartJauEq1.Columns["combo"].ReadOnly = false;
                }
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
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";

                foreach (JoueursModele jm in lJoueursEqB)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_CartJaunEq2.DataSource = carteJ2;
                dg_CartJaunEq2.Columns.Add(comboxColonne);

                dg_CartJaunEq2.Columns["joueurId"].DisplayIndex = 0;
                dg_CartJaunEq2.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_CartJaunEq2.Columns["minute"].DisplayIndex = 2;
                dg_CartJaunEq2.Columns["itemId"].DisplayIndex = 4;
                dg_CartJaunEq2.Columns["combo"].DisplayIndex = 3;
                dg_CartJaunEq2.Columns["lastUpdate"].DisplayIndex = 5;

                dg_CartJaunEq2.Columns["joueurId"].Visible = false;
                dg_CartJaunEq2.Columns["itemId"].Visible = false;
                dg_CartJaunEq2.Sort(this.dg_CartJaunEq2.Columns["minute"], ListSortDirection.Ascending);
                dg_CartJaunEq2.Columns["lastUpdate"].Visible = false;

                if (isPlayed)
                {
                    dg_CartJaunEq2.ReadOnly = true;
                }
                else
                {
                    dg_CartJaunEq2.Columns["joueursInscrits"].ReadOnly = true;
                    dg_CartJaunEq2.Columns["minute"].ReadOnly = false;
                    dg_CartJaunEq2.Columns["itemId"].ReadOnly = true;
                    dg_CartJaunEq2.Columns["combo"].ReadOnly = false;
                }

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
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";

                foreach (JoueursModele jm in lJoueursEqA)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_CartRougEq1.DataSource = carteR;
                dg_CartRougEq1.Columns.Add(comboxColonne);

                dg_CartRougEq1.Columns["joueurId"].DisplayIndex = 0;
                dg_CartRougEq1.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_CartRougEq1.Columns["minute"].DisplayIndex = 2;
                dg_CartRougEq1.Columns["itemId"].DisplayIndex = 4;
                dg_CartRougEq1.Columns["combo"].DisplayIndex = 3;
                dg_CartRougEq1.Columns["lastUpdate"].DisplayIndex = 5;

                dg_CartRougEq1.Columns["joueurId"].Visible = false;
                dg_CartRougEq1.Columns["itemId"].Visible = false;
                dg_CartRougEq1.Sort(this.dg_CartRougEq1.Columns["minute"], ListSortDirection.Ascending);
                dg_CartRougEq1.Columns["lastUpdate"].Visible = false;

                if (isPlayed)
                {
                    dg_CartRougEq1.ReadOnly = true;
                }
                else
                {
                    dg_CartRougEq1.Columns["joueursInscrits"].ReadOnly = true;
                    dg_CartRougEq1.Columns["minute"].ReadOnly = false;
                    dg_CartRougEq1.Columns["itemId"].ReadOnly = true;
                    dg_CartRougEq1.Columns["combo"].ReadOnly = false;
                }
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
                DataGridViewComboBoxColumn comboxColonne;
                comboxColonne = new DataGridViewComboBoxColumn();
                comboxColonne.HeaderText = "Changer de Joueur :";
                comboxColonne.DisplayMember = "joueursInscrits";
                comboxColonne.Name = "combo";

                foreach (JoueursModele jm in lJoueursEqB)
                {
                    string nomAffiche = jm.prenom + " " + jm.nom;
                    comboxColonne.Items.Add(nomAffiche);
                }

                dg_CartRougEq2.DataSource = carteR2;
                dg_CartRougEq2.Columns.Add(comboxColonne);

                dg_CartRougEq2.Columns["joueurId"].DisplayIndex = 0;
                dg_CartRougEq2.Columns["joueursInscrits"].DisplayIndex = 1;
                dg_CartRougEq2.Columns["minute"].DisplayIndex = 2;
                dg_CartRougEq2.Columns["itemId"].DisplayIndex = 4;
                dg_CartRougEq2.Columns["combo"].DisplayIndex = 3;
                dg_CartRougEq2.Columns["lastUpdate"].DisplayIndex = 5;

                dg_CartRougEq2.Columns["joueurId"].Visible = false;
                dg_CartRougEq2.Columns["itemId"].Visible = false;
                dg_CartRougEq2.Sort(this.dg_CartRougEq2.Columns["minute"], ListSortDirection.Ascending);
                dg_CartRougEq2.Columns["lastUpdate"].Visible = false;

                if (isPlayed)
                {
                    dg_CartRougEq2.ReadOnly = true;
                }
                else
                {
                    dg_CartRougEq2.Columns["joueursInscrits"].ReadOnly = true;
                    dg_CartRougEq2.Columns["minute"].ReadOnly = false;
                    dg_CartRougEq2.Columns["itemId"].ReadOnly = true;
                    dg_CartRougEq2.Columns["combo"].ReadOnly = false;
                }
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
            dg_CartJauEq1.Columns.Clear();
            dg_CartJaunEq2.Columns.Clear();
            dg_CartRougEq1.Columns.Clear();
            dg_CartRougEq2.Columns.Clear();
            dg_GoalsEq1.Columns.Clear();
            dg_GoalsEq2.Columns.Clear();

            getDataGridGoalA();
            getDataGridGoalB();
            getDataGridCarteJauneA();
            getDataGridCarteJauneB();
            getDataGridCarteRougeA();
            getDataGridCarteRougeB();           
        }

        private void getListeJoueurs()
        { 
            GoalA = GenerationTablesResults.getFeuilleA(matchId, out equipeAId);
            GoalB = GenerationTablesResults.getFeuilleB(matchId, out equipeBId);
            carteJ = GenerationTablesResults.fillInCartesJaunes(equipeAId, matchId);
            carteJ2 = GenerationTablesResults.fillInCartesJaunes(equipeBId, matchId);
            carteR = GenerationTablesResults.fillInCartesRouges(equipeAId, matchId);
            carteR2 = GenerationTablesResults.fillInCartesRouges(equipeBId, matchId);
            lJoueursEqA = GenerationTablesResults.getJoueurs(matchId, equipeAId);
            lJoueursEqB = GenerationTablesResults.getJoueurs(matchId, equipeBId);
        }

        private void Resultats_Load(object sender, EventArgs e)
        {
            refresh();          
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkFull((DataView)dg_GoalsEq1.DataSource) && checkFull((DataView)dg_GoalsEq2.DataSource)
                    && checkFull((DataView)dg_CartJauEq1.DataSource)&& checkFull((DataView)dg_CartJaunEq2.DataSource)
                    && checkFull((DataView)dg_CartRougEq1.DataSource)&&checkFull((DataView)dg_CartRougEq2.DataSource))

                {
                    if(checkMin((DataView)dg_GoalsEq1.DataSource) && checkMin((DataView)dg_GoalsEq2.DataSource)
                    && checkMin((DataView)dg_CartJauEq1.DataSource) && checkMin((DataView)dg_CartJaunEq2.DataSource)
                    && checkMin((DataView)dg_CartRougEq1.DataSource) && checkMin((DataView)dg_CartRougEq2.DataSource))
                    {
                        if (checkCartesRougesA((DataView)dg_GoalsEq1.DataSource)&& checkCartesRougesB((DataView)dg_GoalsEq2.DataSource))
                            {
                            DialogResult dialogResult = MessageBox.Show("Pour des raisons de sécurité, on ne peut encoder qu'une seule fois les cartes, une fois sorti de la fenêtre vous ne pourrez plus les modifier, êtes vous sûrs que tout est bon ?", "Confirm", MessageBoxButtons.OKCancel);
                            if (dialogResult == DialogResult.OK)
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

                                refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Un ou des joueurs ont reçu des cartons rouges avant de marquer");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tous les champs minutes doivent être compris entre 0 et 120");

                    }

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
            Boolean rowRemplie = true;

            foreach (DataRowView dr in oView)
            {
                if (dr["minute"].ToString().Equals("") || dr["joueurId"].ToString().Equals(""))
                {
                    rowRemplie = false;
                }
            }
            return rowRemplie;
        }

        private Boolean checkMin(DataView oView)
        {
            Boolean minTimingBon = true;

            foreach (DataRowView dr in oView)
            {
                if ((int)dr["minute"]<0 || (int)dr["minute"] > 120)
                {
                    minTimingBon = false;
                }
            }
            return minTimingBon;
        }

        private Boolean checkCartesRougesA(DataView oView)
        {
            Boolean noCard = true;

            foreach (DataRowView dr in oView)
            {
                for (int i = 0;i<dg_CartRougEq1.Rows.Count-1;i++)
                {
                    if ((Guid)dr["joueurId"] == (Guid) dg_CartRougEq1.Rows[i].Cells["joueurId"].Value)
                {
                        if ((int)dr["minute"]>= (int)dg_CartRougEq1.Rows[i].Cells["minute"].Value)
                        {
                            noCard = false;
                        }
                }
                }
            }
            return noCard;
        }

        private Boolean checkCartesRougesB(DataView oView)
        {
            Boolean noCard = true;

            foreach (DataRowView dr in oView)
            {
                for (int i = 0; i < dg_CartRougEq2.Rows.Count-1; i++)
                {
                    if ((Guid)dr["joueurId"] == (Guid)dg_CartRougEq2.Rows[i].Cells["joueurId"].Value)
                    {
                        if ((int)dr["minute"] >= (int)dg_CartRougEq2.Rows[i].Cells["minute"].Value)
                        {
                            noCard = false;
                        }
                    }
                }
            }
            return noCard;
        }




        private void dg_GoalsEq1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellG1_SelectedIndexChanged);
            }
        }

        private void dg_GoalsEq2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellG2_SelectedIndexChanged);
            }           
        }

        private void dg_CartJauEq1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellJ1_SelectedIndexChanged);
            }
        }

        private void dg_CartJaunEq2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellJ2_SelectedIndexChanged);
            }
        }

        private void dg_CartRougEq1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellR1_SelectedIndexChanged);
            }
        }

        private void dg_CartRougEq2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboCell = e.Control as ComboBox;
            if (comboCell != null)
            {
                comboCell.SelectedIndexChanged += new EventHandler(comboCellR2_SelectedIndexChanged);
            }
        }


        void comboCellG1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_GoalsEq1.CurrentRow.Cells["joueurId"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].joueurId;
            dg_GoalsEq1.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].prenom +" " 
                                                                      +lJoueursEqA[((ComboBox)sender).SelectedIndex].nom;
        }

        void comboCellG2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_GoalsEq2.CurrentRow.Cells["joueurId"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].joueurId;
            dg_GoalsEq2.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].prenom + " "
                                                                      + lJoueursEqB[((ComboBox)sender).SelectedIndex].nom;
        }

        void comboCellJ1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_CartJauEq1.CurrentRow.Cells["joueurId"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].joueurId;
            dg_CartJauEq1.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].prenom + " "
                                                                      + lJoueursEqA[((ComboBox)sender).SelectedIndex].nom;
        }

        void comboCellJ2_SelectedIndexChanged(object sender, EventArgs e)
        {
           dg_CartJaunEq2.CurrentRow.Cells["joueurId"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].joueurId;
            dg_CartJaunEq2.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].prenom + " "
                                                                      + lJoueursEqB[((ComboBox)sender).SelectedIndex].nom;
        }

        void comboCellR1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_CartRougEq1.CurrentRow.Cells["joueurId"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].joueurId;
            dg_CartRougEq1.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqA[((ComboBox)sender).SelectedIndex].prenom + " "
                                                                      + lJoueursEqA[((ComboBox)sender).SelectedIndex].nom;
        }

        void comboCellR2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_CartRougEq2.CurrentRow.Cells["joueurId"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].joueurId;
            dg_CartRougEq2.CurrentRow.Cells["joueursInscrits"].Value = lJoueursEqB[((ComboBox)sender).SelectedIndex].prenom + " "
                                                                      + lJoueursEqB[((ComboBox)sender).SelectedIndex].nom;
        }

        private void b_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refresh ()
        {
            getListeJoueurs();
            getDataGrid();
            getNames();
        }

    }
}
