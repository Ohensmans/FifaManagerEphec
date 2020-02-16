using BackEndBL.GenerationTableaux;
using BackEndBL.Services;
using FifaError;
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
    public partial class CalendrierMatchs : Form
    {
        private int annee;
        private List<String> lEquipe;
        private DateTimePicker dtp = new DateTimePicker();
        private DataTable oTable;

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
                oTable = tab.generationCalendrier(annee, lEquipe);
                dg_listeMatch.DataSource = oTable;
                datagridRules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //donne les paramètres de base du datagrid
        private void datagridRules()
        {
            dg_listeMatch.Columns["Match n° :"].ReadOnly = true;
            dg_listeMatch.Columns["Equipe à Domicile :"].ReadOnly = true;
            dg_listeMatch.Columns["Equipe à l'extérieur :"].ReadOnly = true;

            
            dg_listeMatch.Columns["Date du Match :"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            try
            {
                cleanColor();
                MatchsService matchs = new MatchsService();
                matchs.enregistrerMatchs(oTable.DefaultView);
                this.Close();
            }
            catch (BusinessError be)
            {
                if (!be.rowNumber.Equals(""))
                {
                    for (int i = 0; i<dg_listeMatch.Rows.Count;i++)
                    {
                        if (dg_listeMatch.Rows[i].Cells["Match n° :"].Value.ToString().Equals(be.rowNumber))
                        {
                            dg_listeMatch.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
                MessageBox.Show(be.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //enleve les couleurs de fond du datagrid
        private void cleanColor ()
        {
            for (int i = 0; i < dg_listeMatch.Rows.Count; i++)
            {
                dg_listeMatch.Rows[i].DefaultCellStyle.BackColor = DefaultBackColor;
            }

        }
         

        //crée un évenèment pour afficher un datetimepicker dans la case cliquée pour changer la date
        private void dg_listeMatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //vérifie que la case est bien celle des dates
            if (dg_listeMatch.Columns[e.ColumnIndex].Name == "Date du Match :")
            {
                dtp.Visible = false;

                //règle le datetimepicker
                getDateTimePicker((DateTime)(dg_listeMatch.CurrentCell.Value));

                //règle size et location
                var rect = dg_listeMatch.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);
                

                //attache les events
                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_OnTextChange);

                dg_listeMatch.Controls.Add(dtp);
            }
        }

        //change la valeur dans le tableau après tout changement
        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dg_listeMatch.CurrentCell.Value = dtp.Text.ToString();
        }

        //ferme le dtp
        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }


        //paramétrise un nouveau datetimepicker
        private void getDateTimePicker (DateTime day)
        {
            try
            {
                this.dtp = new DateTimePicker();

                GenerationTabCalendrierMatchs tabCalendrier = new GenerationTabCalendrierMatchs();

                QuartersModele quarter1 = tabCalendrier.getQuarters(annee, 1);
                QuartersModele quarter2 = tabCalendrier.getQuarters(annee, 2);

                //vérifie si une date est déjà prévue ou si il s'agit de celle de base
                if (day.Year == annee)
                {
                    dtp.Value = day;

                    //assigne les valeurs max et min du dtp en fonction du quarters dans le match était déjà
                    if (day <= quarter1.dateFin)
                    {
                        dtp.MinDate = quarter1.dateDebut;
                        dtp.MaxDate = quarter1.dateFin;
                    }
                    else
                    {
                        dtp.MinDate = quarter2.dateDebut;
                        dtp.MaxDate = quarter2.dateFin;
                    }
                    
                }

                //dans la génération du tableau il est prévu que l'année soit 1 pour le quarter 1 et 2 pour le quarter 2
                else if (day.Year == 1801)
                {
                    dtp.Value = quarter1.dateDebut;
                    dtp.MinDate = quarter1.dateDebut;
                    dtp.MaxDate = quarter1.dateFin;                   
                }

                else
                {
                    dtp.Value = quarter2.dateDebut;
                    dtp.MinDate = quarter2.dateDebut;
                    dtp.MaxDate = quarter2.dateFin;                
                }

                dtp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
