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

namespace BackEnd
{
    public partial class GenChamp : Form
    {
        // les quarters durant chacun 5 semaines et l'intersaison 6 mois, la durée durant laquelle le championnat peut commencer est de 109 jours
        int PRESAISON = 109; // en jours
        int DUREEQUARTER = 35; // en jours
        int dureeIntersaison = 6; // en mois

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
            if (Convert.ToInt32(tb_Annee.Text) >= 1900)
            {
                dtp_DateDebut.MinDate = new DateTime(1900, 1, 1);
                dtp_DateDebut.MaxDate = new DateTime(3000, 1, 1);

                DateTime dateDebut = new DateTime(Convert.ToInt32(tb_Annee.Text), 1, 1);
                dtp_DateDebut.Enabled = true;
                dtp_DateDebut.MinDate = dateDebut;
                dtp_DateDebut.MaxDate = dateDebut.AddDays(PRESAISON);

            }
            else
            {
                MessageBox.Show("L'année encodée doit être supérieure à 1900");
            }
        }


        private void dtp_DateDebut_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateDebut = dtp_DateDebut.Value;
            DateTime dateFinQ1 = dateDebut.AddDays(DUREEQUARTER);
            DateTime dateDebutInt = dateFinQ1.AddDays(1);
            DateTime dateFinInt = dateDebutInt.AddMonths(dureeIntersaison);
            DateTime dateDebutQ2 = dateFinInt.AddDays(1);
            DateTime dateFinQ2 = dateDebutQ2.AddDays(DUREEQUARTER);

            l_datesQ1.Text = "de " + dateDebut.ToString("dd-MM-yy") + " à " + dateFinQ1.ToString("dd-MM-yy");
            l_datesInt.Text = "de " + dateDebutInt.ToString("dd-MM-yy") + " à " + dateFinInt.ToString("dd-MM-yy");
            l_datesQ2.Text = "de " + dateDebutQ2.ToString("dd-MM-yy") + " à " + dateFinQ2.ToString("dd-MM-yy");


            loadTab(dtp_DateDebut.Value);
        }

        private void loadTab(DateTime dt)
        {
            dg_EquipesSelection.DataSource = GenerationTabEquipeSelection.getEquipes(dt);
        }

        private void tb_Annee_Leave(object sender, EventArgs e)
        {
            checkAnnee();
        }
    }
}
