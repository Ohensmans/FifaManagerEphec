using MatchManagement;
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
    public partial class FormMdi : Form
    {
        public FormMdi()
        {
            InitializeComponent();
        }

        private void FormMdi_Load(object sender, EventArgs e)
        {
            Accueil oForm = new Accueil();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void générerUnChampionnatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenChamp oForm = new GenChamp();
            oForm.MdiParent = this;

            oForm.Show();
        }

        private void transférerUnJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransfertJoueurs oForm = new TransfertJoueurs();
            oForm.MdiParent = this;

            oForm.Show();
        }

        private void visualiserUnMatchModifierLeRésultatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchManagement.FormAccueil oForm = new FormAccueil();
            oForm.MdiParent = this;

            oForm.Show();
        }

        private void voirLeClassementParÉquipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassementEquipe oForm = new ClassementEquipe();
            oForm.MdiParent = this;

            oForm.Show();
        }

        private void voirLeClassementParJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassementJoueur oForm = new ClassementJoueur();
            oForm.MdiParent = this;

            oForm.Show();
        }
    }
}
