using BackEndBL.GenerationTableaux;
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
    public partial class CalendrierMatchs : Form
    {
        private int annee;
        private List<String> lEquipe;

        public CalendrierMatchs(int annee, List<string> lEquipe)
        {
            InitializeComponent();
            this.annee = annee;
            this.lEquipe = lEquipe;
        }

        private void CalendrierMatchs_Load(object sender, EventArgs e)
        {
            try
            {
                GenerationTabCalendrierMatchs tab = new GenerationTabCalendrierMatchs();
                dg_listeMatch.DataSource = tab.generationCalendrier(annee, lEquipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_Save_Click(object sender, EventArgs e)
        {

        }
    }
}
