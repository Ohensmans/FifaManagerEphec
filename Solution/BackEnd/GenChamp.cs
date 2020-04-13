using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEndBL;
using BackEndBL.GenerationTableaux;
using BackEndBL.Services;

namespace BackEnd
{
    public partial class GenChamp : Form
    {
        // les quarters durant chacun 5 semaines et l'intersaison 6 mois, la durée durant laquelle le championnat peut commencer est de 109 jours
        private int PRESAISON = 108; // en jours
        private int DUREEQUARTER = 35; // en jours
        private int dureeIntersaison = 6; // en mois
        private int PREMIEREANNEE = 1900;
        private int DERNIEREANNEE = 9998;

        private DateTime dateDebut;
        private DateTime dateFinQ1;
        private DateTime dateDebutInt;
        private DateTime dateFinInt;
        private DateTime dateDebutQ2;
        private DateTime dateFinQ2;

        List<String> lEquipe;
        private int annee;

        public GenChamp()
        {
            InitializeComponent();
        }

        private void GenChamp_Load(object sender, EventArgs e)
        {
            dtp_DateDebut.Enabled = false;
        }


        private void checkAnnee()
        {
            
            if (Int32.TryParse(tb_Annee.Text, out annee))
            {
                if (annee >= PREMIEREANNEE && annee <9999)
                {
                    int dureePresaison = PRESAISON;

                    //vérifie si l'année est bissextile
                    if ((Convert.ToInt32(tb_Annee.Text) % 4 == 0 && Convert.ToInt32(tb_Annee.Text) % 100 != 0) || Convert.ToInt32(tb_Annee.Text) % 400 == 0)
                    {
                        dureePresaison += +1;
                    }

                    dtp_DateDebut.MinDate = new DateTime(PREMIEREANNEE, 1, 1);
                    dtp_DateDebut.MaxDate = new DateTime(DERNIEREANNEE, 1, 1);

                    DateTime dateDebut = new DateTime(Convert.ToInt32(tb_Annee.Text), 1, 1);
                    dtp_DateDebut.Enabled = true;
                    dtp_DateDebut.MinDate = dateDebut;
                    dtp_DateDebut.MaxDate = dateDebut.AddDays(dureePresaison);


                }
                else
                {
                    MessageBox.Show("L'année encodée doit être supérieure ou égale à " + PREMIEREANNEE+" et inférieure ou égale à "+ DERNIEREANNEE);
                    tb_Annee.Text = "";
                }
            }
        }


        private void dtp_DateDebut_ValueChanged(object sender, EventArgs e)
        {
            getResume();
        }

        private void loadTab(DateTime dt)
        {
            try
            {
                dg_EquipesSelection.DataSource = GenerationTabEquipeSelection.getEquipes(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_Annee_Leave(object sender, EventArgs e)
        {
            checkAnnee();
        }

        private void getResume()
        {
             dateDebut = dtp_DateDebut.Value;
             dateFinQ1 = dateDebut.AddDays(DUREEQUARTER);
             dateDebutInt = dateFinQ1.AddDays(1);
             dateFinInt = dateDebutInt.AddMonths(dureeIntersaison);
             dateDebutQ2 = dateFinInt.AddDays(1);
             dateFinQ2 = dateDebutQ2.AddDays(DUREEQUARTER);

            l_datesQ1.Text = "de " + dateDebut.ToString("dd-MM-yy") + " à " + dateFinQ1.ToString("dd-MM-yy");
            l_datesInt.Text = "de " + dateDebutInt.ToString("dd-MM-yy") + " à " + dateFinInt.ToString("dd-MM-yy");
            l_datesQ2.Text = "de " + dateDebutQ2.ToString("dd-MM-yy") + " à " + dateFinQ2.ToString("dd-MM-yy");


            loadTab(dtp_DateDebut.Value);
                
        }

        private void resetLabels()
        {
            l_datesQ1.Text = "de xx/xx/xx à xx/xx/xx";
            l_datesInt.Text = "de xx/xx/xx à xx/xx/xx";
            l_datesQ2.Text = "de xx/xx/xx à xx/xx/xx";
        }

        private void tb_Annee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.TryParse(tb_Annee.Text, out annee))
                {
                    if (annee >= PREMIEREANNEE)
                    {
                        ChampionnatService cs = new ChampionnatService();

                        if (cs.getChampionnat(annee)==null)
                        {
                            checkAnnee();
                        }
                        else
                        {
                            dg_EquipesSelection.DataSource = "";
                            dtp_DateDebut.Enabled = false;
                            resetLabels();
                            MessageBox.Show("Ce championnat existe déjà");
                        }
                        
                    }
                    else
                    {
                        dg_EquipesSelection.DataSource = "";
                        dtp_DateDebut.Enabled = false;
                        resetLabels();
                    }
                }
                else
                {
                    dg_EquipesSelection.DataSource = "";
                    dtp_DateDebut.Enabled = false;
                    resetLabels();
                    MessageBox.Show("Le format de l'année doit être valide en 4 chiffres");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_Next_Click(object sender, EventArgs e)
        {
            lEquipe = getListeNomEquipes();

            // vérifie qu'il y ait assez d'équipes
            if (lEquipe.Count>=2)
            {
                //vérifie qu'il y ait une année inscrite (la condition de valeur min est contrôlée sur l'event Leave)
                if (tb_Annee.Text!="")
                {
                    if (enregistrerNewDivison(lEquipe))
                    {

                        CalendrierMatchs oForm = new CalendrierMatchs(annee, lEquipe);
                        oForm.MdiParent = this.MdiParent;
                        oForm.Show();

                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Il faut minimum 2 équipes inscrites pour créer un championnat");
            }
        }

        private Boolean enregistrerNewDivison(List<string> lEquipe)
        {
            Boolean _return = false;
            try
            {
                // enregistre le nouveau championnat 
                ChampionnatService cs = new ChampionnatService();
                Guid championnatId;
                

                //vérifie si le championnat a pu être créé et si oui lance la création de quarters et d'intersaison
                if (cs.enregistrerNewChampionnat(Convert.ToInt32(tb_Annee.Text), out championnatId))
                 {
                    //enregistre la nouvelle intersaison
                    IntersaisonsService interS = new IntersaisonsService();
                    interS.enregistrerNewIntersaison(dateDebutInt, dateFinInt, championnatId);

                    //enregistre les nouveaux quarters
                    QuartersService qs = new QuartersService();
                    qs.enregistrerNewQuarter(dateDebut, dateFinQ1, championnatId);
                    qs.enregistrerNewQuarter(dateDebutQ2, dateFinQ2, championnatId);

                    //enregistre les équipes
                    enregistrerEquipes(lEquipe, championnatId);

                    _return = true;
                }
                return _return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return _return;
            }
        }

        // obtient la liste des noms des équipes sélectionnées
        private List<String> getListeNomEquipes()
        {
            List<String> lEquipe = new List<string>();

            for (int i =0; i<dg_EquipesSelection.Rows.Count;i++)
            {
                if ((Boolean)dg_EquipesSelection.Rows[i].Cells["Est sélectionné : "].Value)
                {
                    lEquipe.Add(dg_EquipesSelection.Rows[i].Cells["Equipes Actives :"].Value.ToString());
                }
            }

            return lEquipe;
        }

        //récupère la liste des équipes inscrites et les rajoute dans EquipePartcipation
        private void enregistrerEquipes (List<string> lEquipe, Guid championnatId)
        {
            try
            {
                //transforme la liste de string en liste d'équipes puis les inscrits
                EquipesService es = new EquipesService();
                EquipesParticipationService eps = new EquipesParticipationService();
                eps.enregistrerEquipesParticipation(es.ListeEquipeParticipants(lEquipe), championnatId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
