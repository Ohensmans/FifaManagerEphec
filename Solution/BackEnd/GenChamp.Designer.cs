using System;

namespace BackEnd
{
    partial class GenChamp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_Titre = new System.Windows.Forms.Label();
            this.l_Annee = new System.Windows.Forms.Label();
            this.tb_Annee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_DateDebut = new System.Windows.Forms.DateTimePicker();
            this.gb_Resume = new System.Windows.Forms.GroupBox();
            this.l_datesQ2 = new System.Windows.Forms.Label();
            this.l_datesInt = new System.Windows.Forms.Label();
            this.l_datesQ1 = new System.Windows.Forms.Label();
            this.l_TitreQ2 = new System.Windows.Forms.Label();
            this.l_titreInter = new System.Windows.Forms.Label();
            this.l_TitreQ1 = new System.Windows.Forms.Label();
            this.dg_EquipesSelection = new System.Windows.Forms.DataGridView();
            this.b_Next = new System.Windows.Forms.Button();
            this.b_Back = new System.Windows.Forms.Button();
            this.gb_Resume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_EquipesSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(110, 33);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(277, 29);
            this.l_Titre.TabIndex = 0;
            this.l_Titre.Text = "Générer un championnat";
            // 
            // l_Annee
            // 
            this.l_Annee.AutoSize = true;
            this.l_Annee.Location = new System.Drawing.Point(24, 110);
            this.l_Annee.Name = "l_Annee";
            this.l_Annee.Size = new System.Drawing.Size(74, 13);
            this.l_Annee.TabIndex = 1;
            this.l_Annee.Text = "Entrez l\'année";
            // 
            // tb_Annee
            // 
            this.tb_Annee.Location = new System.Drawing.Point(262, 107);
            this.tb_Annee.Name = "tb_Annee";
            this.tb_Annee.Size = new System.Drawing.Size(100, 20);
            this.tb_Annee.TabIndex = 2;
            this.tb_Annee.TextChanged += new System.EventHandler(this.tb_Annee_TextChanged);
            this.tb_Annee.Leave += new System.EventHandler(this.tb_Annee_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entrez la date de début du championnat :";
            // 
            // dtp_DateDebut
            // 
            this.dtp_DateDebut.Location = new System.Drawing.Point(262, 139);
            this.dtp_DateDebut.Name = "dtp_DateDebut";
            this.dtp_DateDebut.Size = new System.Drawing.Size(200, 20);
            this.dtp_DateDebut.TabIndex = 4;
            this.dtp_DateDebut.ValueChanged += new System.EventHandler(this.dtp_DateDebut_ValueChanged);
            // 
            // gb_Resume
            // 
            this.gb_Resume.Controls.Add(this.l_datesQ2);
            this.gb_Resume.Controls.Add(this.l_datesInt);
            this.gb_Resume.Controls.Add(this.l_datesQ1);
            this.gb_Resume.Controls.Add(this.l_TitreQ2);
            this.gb_Resume.Controls.Add(this.l_titreInter);
            this.gb_Resume.Controls.Add(this.l_TitreQ1);
            this.gb_Resume.Location = new System.Drawing.Point(27, 195);
            this.gb_Resume.Name = "gb_Resume";
            this.gb_Resume.Size = new System.Drawing.Size(435, 90);
            this.gb_Resume.TabIndex = 5;
            this.gb_Resume.TabStop = false;
            this.gb_Resume.Text = "Résumé :";
            // 
            // l_datesQ2
            // 
            this.l_datesQ2.AutoSize = true;
            this.l_datesQ2.Location = new System.Drawing.Point(125, 67);
            this.l_datesQ2.Name = "l_datesQ2";
            this.l_datesQ2.Size = new System.Drawing.Size(114, 13);
            this.l_datesQ2.TabIndex = 5;
            this.l_datesQ2.Text = "de xx/xx/xx à xx/xx/xx";
            // 
            // l_datesInt
            // 
            this.l_datesInt.AutoSize = true;
            this.l_datesInt.Location = new System.Drawing.Point(125, 43);
            this.l_datesInt.Name = "l_datesInt";
            this.l_datesInt.Size = new System.Drawing.Size(114, 13);
            this.l_datesInt.TabIndex = 4;
            this.l_datesInt.Text = "de xx/xx/xx à xx/xx/xx";
            // 
            // l_datesQ1
            // 
            this.l_datesQ1.AutoSize = true;
            this.l_datesQ1.Location = new System.Drawing.Point(125, 20);
            this.l_datesQ1.Name = "l_datesQ1";
            this.l_datesQ1.Size = new System.Drawing.Size(114, 13);
            this.l_datesQ1.TabIndex = 3;
            this.l_datesQ1.Text = "de xx/xx/xx à xx/xx/xx";
            // 
            // l_TitreQ2
            // 
            this.l_TitreQ2.AutoSize = true;
            this.l_TitreQ2.Location = new System.Drawing.Point(6, 67);
            this.l_TitreQ2.Name = "l_TitreQ2";
            this.l_TitreQ2.Size = new System.Drawing.Size(57, 13);
            this.l_TitreQ2.TabIndex = 2;
            this.l_TitreQ2.Text = "Quarter 2 :";
            // 
            // l_titreInter
            // 
            this.l_titreInter.AutoSize = true;
            this.l_titreInter.Location = new System.Drawing.Point(6, 43);
            this.l_titreInter.Name = "l_titreInter";
            this.l_titreInter.Size = new System.Drawing.Size(64, 13);
            this.l_titreInter.TabIndex = 1;
            this.l_titreInter.Text = "Intersaison :";
            // 
            // l_TitreQ1
            // 
            this.l_TitreQ1.AutoSize = true;
            this.l_TitreQ1.Location = new System.Drawing.Point(7, 20);
            this.l_TitreQ1.Name = "l_TitreQ1";
            this.l_TitreQ1.Size = new System.Drawing.Size(57, 13);
            this.l_TitreQ1.TabIndex = 0;
            this.l_TitreQ1.Text = "Quarter 1 :";
            // 
            // dg_EquipesSelection
            // 
            this.dg_EquipesSelection.AllowUserToAddRows = false;
            this.dg_EquipesSelection.AllowUserToDeleteRows = false;
            this.dg_EquipesSelection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_EquipesSelection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_EquipesSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_EquipesSelection.Location = new System.Drawing.Point(27, 316);
            this.dg_EquipesSelection.Name = "dg_EquipesSelection";
            this.dg_EquipesSelection.Size = new System.Drawing.Size(435, 200);
            this.dg_EquipesSelection.TabIndex = 6;
            // 
            // b_Next
            // 
            this.b_Next.Location = new System.Drawing.Point(262, 541);
            this.b_Next.Name = "b_Next";
            this.b_Next.Size = new System.Drawing.Size(137, 45);
            this.b_Next.TabIndex = 7;
            this.b_Next.Text = "Enregistrer et passer aux matchs";
            this.b_Next.UseVisualStyleBackColor = true;
            this.b_Next.Click += new System.EventHandler(this.b_Next_Click);
            // 
            // b_Back
            // 
            this.b_Back.Location = new System.Drawing.Point(89, 541);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(137, 45);
            this.b_Back.TabIndex = 8;
            this.b_Back.Text = "Retour";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_Back_Click);
            // 
            // GenChamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 610);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.b_Next);
            this.Controls.Add(this.dg_EquipesSelection);
            this.Controls.Add(this.gb_Resume);
            this.Controls.Add(this.dtp_DateDebut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Annee);
            this.Controls.Add(this.l_Annee);
            this.Controls.Add(this.l_Titre);
            this.Name = "GenChamp";
            this.Text = "Générer un championnat";
            this.Load += new System.EventHandler(this.GenChamp_Load);
            this.gb_Resume.ResumeLayout(false);
            this.gb_Resume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_EquipesSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_Annee;
        private System.Windows.Forms.TextBox tb_Annee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_DateDebut;
        private System.Windows.Forms.GroupBox gb_Resume;
        private System.Windows.Forms.Label l_datesQ2;
        private System.Windows.Forms.Label l_datesInt;
        private System.Windows.Forms.Label l_datesQ1;
        private System.Windows.Forms.Label l_TitreQ2;
        private System.Windows.Forms.Label l_titreInter;
        private System.Windows.Forms.Label l_TitreQ1;
        private System.Windows.Forms.DataGridView dg_EquipesSelection;
        private System.Windows.Forms.Button b_Next;
        private System.Windows.Forms.Button b_Back;
    }
}