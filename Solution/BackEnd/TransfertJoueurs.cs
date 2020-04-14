using BackEndBL;
using BackEndBL.GenerationTableaux;
using BackEndBL.Services;
using FifaModeles;
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
    public partial class TransfertJoueurs : Form
    {
        private DataTable oTable;
        private DateTimePicker dtp = new DateTimePicker();
        private List<EquipesModele> lEquipe;
        private DataGridViewComboBoxColumn comboxColonne;

        public TransfertJoueurs()
        {
            InitializeComponent();
        }

        private void TransfertJoueurs_Load(object sender, EventArgs e)
        {
            getListeEquipes();
            refresh();
        }

        private void b_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getListeEquipes()
        {
            EquipesService es = new EquipesService();
            lEquipe = es.ListAll();
        }

        private void refresh ()
        {
            dg_TransfertJoueurs.Columns.Clear();

            //rempli le datagridview
            GenerationTabTransfertJoueurs tab = new GenerationTabTransfertJoueurs();
            oTable = tab.genererTableauTransferts();
            dg_TransfertJoueurs.DataSource = oTable.DefaultView;

            //règle les colonnes modifiables
            dg_TransfertJoueurs.Columns["Joueur :"].ReadOnly = true;
            dg_TransfertJoueurs.Columns["Equipe :"].ReadOnly = true;
            dg_TransfertJoueurs.Columns["Date arrivee :"].ReadOnly = true;


            //crée une colonne combobox           
            comboxColonne = new DataGridViewComboBoxColumn();
            comboxColonne.HeaderText = "Nouvelle equipe :";
            comboxColonne.DisplayMember = "newEquipe";
            comboxColonne.Name = "combobox";

            

            //rajoute la combobox au datagridview
            dg_TransfertJoueurs.Columns.Add(comboxColonne);

            //règle l'ordre des colonnes
            dg_TransfertJoueurs.Columns["Joueur :"].DisplayIndex = 0;
            dg_TransfertJoueurs.Columns["Equipe :"].DisplayIndex = 1;
            dg_TransfertJoueurs.Columns["Date arrivee :"].DisplayIndex = 2;
            dg_TransfertJoueurs.Columns["combobox"].DisplayIndex = 3;
            dg_TransfertJoueurs.Columns["Date du transfert :"].DisplayIndex = 4;
           
            dg_TransfertJoueurs.Columns["combo"].Visible = false;
            dg_TransfertJoueurs.Columns["Date arrivee :"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dg_TransfertJoueurs.Columns["Date du transfert :"].DefaultCellStyle.Format = "dd/MM/yyyy";

            //rempli la combobox équipe
            comboxColonne.Items.Clear();
            foreach (EquipesModele equipe in lEquipe)
            {
                comboxColonne.Items.Add(equipe.nom);
            }
            comboxColonne.Sorted = true;

        }

        private void dg_TransfertJoueurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtp.Visible = false;

                //vérifie que la case est bien celle des dates
                if (dg_TransfertJoueurs.Columns[e.ColumnIndex].Name == "Date du transfert :")
                {
                    DateTime transfertPossible;

                    //récupère la première date possible pour un transfert
                    if ((dg_TransfertJoueurs.CurrentRow.Cells["Date arrivee :"].Value).ToString() != "")
                    {
                        transfertPossible = (DateTime)(dg_TransfertJoueurs.CurrentRow.Cells["Date arrivee :"].Value);
                        // on ne peut pas être transferé dans 2 clubs le même jour
                        transfertPossible = transfertPossible.AddDays(1);
                    }
                    else
                    {
                        transfertPossible = DateTime.Now;
                    }

                    //règle le datetimepicker               
                    dtp.MinDate = transfertPossible;
                    dtp.MaxDate = DateTime.MaxValue;
                    dtp.Value = transfertPossible;
                    dtp.Visible = true;

                    //règle size et location
                    var rect = dg_TransfertJoueurs.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(rect.Width, rect.Height);
                    dtp.Location = new Point(rect.X, rect.Y);

                    //attache les events
                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);

                    dg_TransfertJoueurs.Controls.Add(dtp);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //change la valeur dans le tableau après tout changement
        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            TransfertsService ts = new TransfertsService();
            if (ts.checkDateTransfert(dg_TransfertJoueurs.CurrentRow.Cells["Joueur :"].Value.ToString(), dtp.Value))
            {
                dg_TransfertJoueurs.CurrentCell.Value = dtp.Value;
            }
            
        }

        //ferme le dtp
        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void fillEquipeOut ()
        {
            for (int i = 0; i<dg_TransfertJoueurs.Rows.Count;i++)
            {
                if (dg_TransfertJoueurs.Rows[i].Cells["combobox"].Value != null)
                {
                    dg_TransfertJoueurs.Rows[i].Cells["combo"].Value = dg_TransfertJoueurs.Rows[i].Cells["combobox"].Value.ToString();
                }
            }
           
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            try
            {
                fillEquipeOut();
                TransfertsService ts = new TransfertsService();
                ts.enregistrerTransferts(oTable);
                refresh();
            }
            catch (Exception ex)
            {
                refresh();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
