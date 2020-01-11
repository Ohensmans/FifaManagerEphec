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
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void b_GenChamp_Click(object sender, EventArgs e)
        {
            GenChamp oForm = new GenChamp();
            oForm.MdiParent = this.MdiParent;

            oForm.Show();
        }
    }
}
