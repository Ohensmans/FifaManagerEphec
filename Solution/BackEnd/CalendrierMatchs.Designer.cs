namespace BackEnd
{
    partial class CalendrierMatchs
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
            this.dg_listeMatch = new System.Windows.Forms.DataGridView();
            this.b_Save = new System.Windows.Forms.Button();
            this.b_Aide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_listeMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(155, 37);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(254, 29);
            this.l_Titre.TabIndex = 1;
            this.l_Titre.Text = "Calendrier des matchs";
            // 
            // dg_listeMatch
            // 
            this.dg_listeMatch.AllowUserToAddRows = false;
            this.dg_listeMatch.AllowUserToDeleteRows = false;
            this.dg_listeMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_listeMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_listeMatch.Location = new System.Drawing.Point(31, 122);
            this.dg_listeMatch.Name = "dg_listeMatch";
            this.dg_listeMatch.Size = new System.Drawing.Size(502, 356);
            this.dg_listeMatch.TabIndex = 2;
            this.dg_listeMatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_listeMatch_CellClick);
            this.dg_listeMatch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_listeMatch_CellValueChanged);
            // 
            // b_Save
            // 
            this.b_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Save.Location = new System.Drawing.Point(186, 502);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(191, 38);
            this.b_Save.TabIndex = 3;
            this.b_Save.Text = "Sauvegarder";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_Aide
            // 
            this.b_Aide.Location = new System.Drawing.Point(459, 84);
            this.b_Aide.Name = "b_Aide";
            this.b_Aide.Size = new System.Drawing.Size(75, 23);
            this.b_Aide.TabIndex = 4;
            this.b_Aide.Text = "Aide";
            this.b_Aide.UseVisualStyleBackColor = true;
            this.b_Aide.Click += new System.EventHandler(this.b_Aide_Click);
            // 
            // CalendrierMatchs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 552);
            this.Controls.Add(this.b_Aide);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.dg_listeMatch);
            this.Controls.Add(this.l_Titre);
            this.Name = "CalendrierMatchs";
            this.Text = "Calendrier des Matchs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalendrierMatchs_FormClosing);
            this.Load += new System.EventHandler(this.CalendrierMatchs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_listeMatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.DataGridView dg_listeMatch;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Button b_Aide;
    }
}