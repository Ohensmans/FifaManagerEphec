namespace BackEnd
{
    partial class ClassementEquipe
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
            this.l_titreChamp = new System.Windows.Forms.Label();
            this.l_titreClass = new System.Windows.Forms.Label();
            this.cb_Championnat = new System.Windows.Forms.ComboBox();
            this.cb_Classement = new System.Windows.Forms.ComboBox();
            this.dg_Classement = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Classement)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(214, 46);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(262, 29);
            this.l_Titre.TabIndex = 2;
            this.l_Titre.Text = "Classement par équipe";
            // 
            // l_titreChamp
            // 
            this.l_titreChamp.AutoSize = true;
            this.l_titreChamp.Location = new System.Drawing.Point(53, 116);
            this.l_titreChamp.Name = "l_titreChamp";
            this.l_titreChamp.Size = new System.Drawing.Size(130, 13);
            this.l_titreChamp.TabIndex = 3;
            this.l_titreChamp.Text = "Sélectionner championnat";
            // 
            // l_titreClass
            // 
            this.l_titreClass.AutoSize = true;
            this.l_titreClass.Location = new System.Drawing.Point(53, 147);
            this.l_titreClass.Name = "l_titreClass";
            this.l_titreClass.Size = new System.Drawing.Size(133, 13);
            this.l_titreClass.TabIndex = 4;
            this.l_titreClass.Text = "Sélectionner le classement";
            // 
            // cb_Championnat
            // 
            this.cb_Championnat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Championnat.FormattingEnabled = true;
            this.cb_Championnat.Location = new System.Drawing.Point(255, 113);
            this.cb_Championnat.Name = "cb_Championnat";
            this.cb_Championnat.Size = new System.Drawing.Size(121, 21);
            this.cb_Championnat.TabIndex = 5;
            this.cb_Championnat.SelectedIndexChanged += new System.EventHandler(this.cb_Championnat_SelectedIndexChanged);
            // 
            // cb_Classement
            // 
            this.cb_Classement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Classement.FormattingEnabled = true;
            this.cb_Classement.Location = new System.Drawing.Point(255, 144);
            this.cb_Classement.Name = "cb_Classement";
            this.cb_Classement.Size = new System.Drawing.Size(121, 21);
            this.cb_Classement.TabIndex = 6;
            this.cb_Classement.SelectedIndexChanged += new System.EventHandler(this.cb_Classement_SelectedIndexChanged);
            // 
            // dg_Classement
            // 
            this.dg_Classement.AllowUserToAddRows = false;
            this.dg_Classement.AllowUserToDeleteRows = false;
            this.dg_Classement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Classement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Classement.Location = new System.Drawing.Point(56, 202);
            this.dg_Classement.Name = "dg_Classement";
            this.dg_Classement.ReadOnly = true;
            this.dg_Classement.Size = new System.Drawing.Size(588, 218);
            this.dg_Classement.TabIndex = 7;
            // 
            // ClassementEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 446);
            this.Controls.Add(this.dg_Classement);
            this.Controls.Add(this.cb_Classement);
            this.Controls.Add(this.cb_Championnat);
            this.Controls.Add(this.l_titreClass);
            this.Controls.Add(this.l_titreChamp);
            this.Controls.Add(this.l_Titre);
            this.Name = "ClassementEquipe";
            this.Text = "Classement par équipe";
            this.Load += new System.EventHandler(this.ClassementEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Classement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_titreChamp;
        private System.Windows.Forms.Label l_titreClass;
        private System.Windows.Forms.ComboBox cb_Championnat;
        private System.Windows.Forms.ComboBox cb_Classement;
        private System.Windows.Forms.DataGridView dg_Classement;
    }
}