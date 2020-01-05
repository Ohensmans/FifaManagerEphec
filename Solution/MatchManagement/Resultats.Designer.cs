namespace MatchManagement
{
    partial class Resultats
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
            this.pb_Equipe2 = new System.Windows.Forms.PictureBox();
            this.pb_Equipe1 = new System.Windows.Forms.PictureBox();
            this.l_NomEquipe2 = new System.Windows.Forms.Label();
            this.l_NomEquipe1 = new System.Windows.Forms.Label();
            this.l_dateMatch = new System.Windows.Forms.Label();
            this.l_Titre = new System.Windows.Forms.Label();
            this.l_Goals1 = new System.Windows.Forms.Label();
            this.dg_GoalsEq1 = new System.Windows.Forms.DataGridView();
            this.dg_CartJauEq1 = new System.Windows.Forms.DataGridView();
            this.l_CartJaune1 = new System.Windows.Forms.Label();
            this.dg_CartRougEq1 = new System.Windows.Forms.DataGridView();
            this.l_CartRouges1 = new System.Windows.Forms.Label();
            this.dg_CartRougEq2 = new System.Windows.Forms.DataGridView();
            this.l_CartRoug2 = new System.Windows.Forms.Label();
            this.dg_CartJaunEq2 = new System.Windows.Forms.DataGridView();
            this.l_CartJaunesEq2 = new System.Windows.Forms.Label();
            this.dg_GoalsEq2 = new System.Windows.Forms.DataGridView();
            this.l_Goals2 = new System.Windows.Forms.Label();
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_GoalsEq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartJauEq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartRougEq1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartRougEq2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartJaunEq2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_GoalsEq2)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Equipe2
            // 
            this.pb_Equipe2.Location = new System.Drawing.Point(397, 130);
            this.pb_Equipe2.Name = "pb_Equipe2";
            this.pb_Equipe2.Size = new System.Drawing.Size(85, 57);
            this.pb_Equipe2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Equipe2.TabIndex = 12;
            this.pb_Equipe2.TabStop = false;
            // 
            // pb_Equipe1
            // 
            this.pb_Equipe1.Location = new System.Drawing.Point(39, 130);
            this.pb_Equipe1.Name = "pb_Equipe1";
            this.pb_Equipe1.Size = new System.Drawing.Size(85, 57);
            this.pb_Equipe1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Equipe1.TabIndex = 11;
            this.pb_Equipe1.TabStop = false;
            // 
            // l_NomEquipe2
            // 
            this.l_NomEquipe2.AutoSize = true;
            this.l_NomEquipe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_NomEquipe2.Location = new System.Drawing.Point(393, 97);
            this.l_NomEquipe2.Name = "l_NomEquipe2";
            this.l_NomEquipe2.Size = new System.Drawing.Size(105, 20);
            this.l_NomEquipe2.TabIndex = 10;
            this.l_NomEquipe2.Text = "Nom Equipe2";
            // 
            // l_NomEquipe1
            // 
            this.l_NomEquipe1.AutoSize = true;
            this.l_NomEquipe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_NomEquipe1.Location = new System.Drawing.Point(35, 97);
            this.l_NomEquipe1.Name = "l_NomEquipe1";
            this.l_NomEquipe1.Size = new System.Drawing.Size(105, 20);
            this.l_NomEquipe1.TabIndex = 9;
            this.l_NomEquipe1.Text = "Nom Equipe1";
            // 
            // l_dateMatch
            // 
            this.l_dateMatch.AutoSize = true;
            this.l_dateMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_dateMatch.Location = new System.Drawing.Point(309, 57);
            this.l_dateMatch.Name = "l_dateMatch";
            this.l_dateMatch.Size = new System.Drawing.Size(143, 20);
            this.l_dateMatch.TabIndex = 8;
            this.l_dateMatch.Text = "Match du xx/xx/xxxx";
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(252, 18);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(264, 25);
            this.l_Titre.TabIndex = 7;
            this.l_Titre.Text = "Inscription des résultats";
            // 
            // l_Goals1
            // 
            this.l_Goals1.AutoSize = true;
            this.l_Goals1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Goals1.Location = new System.Drawing.Point(36, 206);
            this.l_Goals1.Name = "l_Goals1";
            this.l_Goals1.Size = new System.Drawing.Size(44, 16);
            this.l_Goals1.TabIndex = 13;
            this.l_Goals1.Text = "Goals";
            // 
            // dg_GoalsEq1
            // 
            this.dg_GoalsEq1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_GoalsEq1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_GoalsEq1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_GoalsEq1.Location = new System.Drawing.Point(39, 225);
            this.dg_GoalsEq1.Name = "dg_GoalsEq1";
            this.dg_GoalsEq1.Size = new System.Drawing.Size(330, 150);
            this.dg_GoalsEq1.TabIndex = 14;
            this.dg_GoalsEq1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_GoalsEq1_EditingControlShowing);
            // 
            // dg_CartJauEq1
            // 
            this.dg_CartJauEq1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_CartJauEq1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_CartJauEq1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CartJauEq1.Location = new System.Drawing.Point(39, 411);
            this.dg_CartJauEq1.Name = "dg_CartJauEq1";
            this.dg_CartJauEq1.Size = new System.Drawing.Size(330, 150);
            this.dg_CartJauEq1.TabIndex = 16;
            this.dg_CartJauEq1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_CartJauEq1_EditingControlShowing);
            // 
            // l_CartJaune1
            // 
            this.l_CartJaune1.AutoSize = true;
            this.l_CartJaune1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CartJaune1.Location = new System.Drawing.Point(36, 392);
            this.l_CartJaune1.Name = "l_CartJaune1";
            this.l_CartJaune1.Size = new System.Drawing.Size(101, 16);
            this.l_CartJaune1.TabIndex = 15;
            this.l_CartJaune1.Text = "Cartons Jaunes";
            // 
            // dg_CartRougEq1
            // 
            this.dg_CartRougEq1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_CartRougEq1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_CartRougEq1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CartRougEq1.Location = new System.Drawing.Point(39, 596);
            this.dg_CartRougEq1.Name = "dg_CartRougEq1";
            this.dg_CartRougEq1.Size = new System.Drawing.Size(330, 150);
            this.dg_CartRougEq1.TabIndex = 18;
            this.dg_CartRougEq1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_CartRougEq1_EditingControlShowing);
            // 
            // l_CartRouges1
            // 
            this.l_CartRouges1.AutoSize = true;
            this.l_CartRouges1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CartRouges1.Location = new System.Drawing.Point(36, 577);
            this.l_CartRouges1.Name = "l_CartRouges1";
            this.l_CartRouges1.Size = new System.Drawing.Size(105, 16);
            this.l_CartRouges1.TabIndex = 17;
            this.l_CartRouges1.Text = "Cartons Rouges";
            // 
            // dg_CartRougEq2
            // 
            this.dg_CartRougEq2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_CartRougEq2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_CartRougEq2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CartRougEq2.Location = new System.Drawing.Point(397, 596);
            this.dg_CartRougEq2.Name = "dg_CartRougEq2";
            this.dg_CartRougEq2.Size = new System.Drawing.Size(330, 150);
            this.dg_CartRougEq2.TabIndex = 24;
            this.dg_CartRougEq2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_CartRougEq2_EditingControlShowing);
            // 
            // l_CartRoug2
            // 
            this.l_CartRoug2.AutoSize = true;
            this.l_CartRoug2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CartRoug2.Location = new System.Drawing.Point(394, 577);
            this.l_CartRoug2.Name = "l_CartRoug2";
            this.l_CartRoug2.Size = new System.Drawing.Size(105, 16);
            this.l_CartRoug2.TabIndex = 23;
            this.l_CartRoug2.Text = "Cartons Rouges";
            // 
            // dg_CartJaunEq2
            // 
            this.dg_CartJaunEq2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_CartJaunEq2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_CartJaunEq2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_CartJaunEq2.Location = new System.Drawing.Point(397, 411);
            this.dg_CartJaunEq2.Name = "dg_CartJaunEq2";
            this.dg_CartJaunEq2.Size = new System.Drawing.Size(330, 150);
            this.dg_CartJaunEq2.TabIndex = 22;
            this.dg_CartJaunEq2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_CartJaunEq2_EditingControlShowing);
            // 
            // l_CartJaunesEq2
            // 
            this.l_CartJaunesEq2.AutoSize = true;
            this.l_CartJaunesEq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_CartJaunesEq2.Location = new System.Drawing.Point(394, 392);
            this.l_CartJaunesEq2.Name = "l_CartJaunesEq2";
            this.l_CartJaunesEq2.Size = new System.Drawing.Size(101, 16);
            this.l_CartJaunesEq2.TabIndex = 21;
            this.l_CartJaunesEq2.Text = "Cartons Jaunes";
            // 
            // dg_GoalsEq2
            // 
            this.dg_GoalsEq2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_GoalsEq2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_GoalsEq2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_GoalsEq2.Location = new System.Drawing.Point(397, 225);
            this.dg_GoalsEq2.Name = "dg_GoalsEq2";
            this.dg_GoalsEq2.Size = new System.Drawing.Size(330, 150);
            this.dg_GoalsEq2.TabIndex = 20;
            this.dg_GoalsEq2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_GoalsEq2_EditingControlShowing);
            // 
            // l_Goals2
            // 
            this.l_Goals2.AutoSize = true;
            this.l_Goals2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Goals2.Location = new System.Drawing.Point(394, 206);
            this.l_Goals2.Name = "l_Goals2";
            this.l_Goals2.Size = new System.Drawing.Size(44, 16);
            this.l_Goals2.TabIndex = 19;
            this.l_Goals2.Text = "Goals";
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(182, 766);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(187, 55);
            this.b_Save.TabIndex = 25;
            this.b_Save.Text = "Sauvegarder";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Return
            // 
            this.b_Return.Location = new System.Drawing.Point(397, 766);
            this.b_Return.Name = "b_Return";
            this.b_Return.Size = new System.Drawing.Size(187, 55);
            this.b_Return.TabIndex = 26;
            this.b_Return.Text = "Back";
            this.b_Return.UseVisualStyleBackColor = true;
            this.b_Return.Click += new System.EventHandler(this.b_Return_Click);
            // 
            // Resultats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 833);
            this.Controls.Add(this.b_Return);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.dg_CartRougEq2);
            this.Controls.Add(this.l_CartRoug2);
            this.Controls.Add(this.dg_CartJaunEq2);
            this.Controls.Add(this.l_CartJaunesEq2);
            this.Controls.Add(this.dg_GoalsEq2);
            this.Controls.Add(this.l_Goals2);
            this.Controls.Add(this.dg_CartRougEq1);
            this.Controls.Add(this.l_CartRouges1);
            this.Controls.Add(this.dg_CartJauEq1);
            this.Controls.Add(this.l_CartJaune1);
            this.Controls.Add(this.dg_GoalsEq1);
            this.Controls.Add(this.l_Goals1);
            this.Controls.Add(this.pb_Equipe2);
            this.Controls.Add(this.pb_Equipe1);
            this.Controls.Add(this.l_NomEquipe2);
            this.Controls.Add(this.l_NomEquipe1);
            this.Controls.Add(this.l_dateMatch);
            this.Controls.Add(this.l_Titre);
            this.Name = "Resultats";
            this.Text = "Resultats";
            this.Load += new System.EventHandler(this.Resultats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_GoalsEq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartJauEq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartRougEq1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartRougEq2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_CartJaunEq2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_GoalsEq2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Equipe2;
        private System.Windows.Forms.PictureBox pb_Equipe1;
        private System.Windows.Forms.Label l_NomEquipe2;
        private System.Windows.Forms.Label l_NomEquipe1;
        private System.Windows.Forms.Label l_dateMatch;
        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_Goals1;
        private System.Windows.Forms.DataGridView dg_GoalsEq1;
        private System.Windows.Forms.DataGridView dg_CartJauEq1;
        private System.Windows.Forms.Label l_CartJaune1;
        private System.Windows.Forms.DataGridView dg_CartRougEq1;
        private System.Windows.Forms.Label l_CartRouges1;
        private System.Windows.Forms.DataGridView dg_CartRougEq2;
        private System.Windows.Forms.Label l_CartRoug2;
        private System.Windows.Forms.DataGridView dg_CartJaunEq2;
        private System.Windows.Forms.Label l_CartJaunesEq2;
        private System.Windows.Forms.DataGridView dg_GoalsEq2;
        private System.Windows.Forms.Label l_Goals2;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Button b_Return;
    }
}