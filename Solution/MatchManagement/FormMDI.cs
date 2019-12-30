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
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            FormAccueil oForm = new FormAccueil();
            oForm.MdiParent = this;

            oForm.Show();
        }

        private void accueilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccueil oForm = new FormAccueil();
            oForm.MdiParent = this;

            oForm.Show();
        }
    }
}
