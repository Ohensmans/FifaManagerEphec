namespace BackEnd
{
    partial class ClassementJoueur
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
            this.dg_Classement = new System.Windows.Forms.DataGridView();
            this.cb_Classement = new System.Windows.Forms.ComboBox();
            this.cb_Championnat = new System.Windows.Forms.ComboBox();
            this.l_titreClass = new System.Windows.Forms.Label();
            this.l_titreChamp = new System.Windows.Forms.Label();
            this.l_Titre = new System.Windows.Forms.Label();
            this.b_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Classement)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Classement
            // 
            this.dg_Classement.AllowUserToAddRows = false;
            this.dg_Classement.AllowUserToDeleteRows = false;
            this.dg_Classement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Classement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Classement.Location = new System.Drawing.Point(30, 201);
            this.dg_Classement.Name = "dg_Classement";
            this.dg_Classement.ReadOnly = true;
            this.dg_Classement.Size = new System.Drawing.Size(663, 197);
            this.dg_Classement.TabIndex = 13;
            // 
            // cb_Classement
            // 
            this.cb_Classement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Classement.FormattingEnabled = true;
            this.cb_Classement.Location = new System.Drawing.Point(307, 136);
            this.cb_Classement.Name = "cb_Classement";
            this.cb_Classement.Size = new System.Drawing.Size(126, 21);
            this.cb_Classement.TabIndex = 12;
            this.cb_Classement.SelectedIndexChanged += new System.EventHandler(this.cb_Classement_SelectedIndexChanged);
            // 
            // cb_Championnat
            // 
            this.cb_Championnat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Championnat.FormattingEnabled = true;
            this.cb_Championnat.Location = new System.Drawing.Point(307, 105);
            this.cb_Championnat.Name = "cb_Championnat";
            this.cb_Championnat.Size = new System.Drawing.Size(126, 21);
            this.cb_Championnat.TabIndex = 11;
            this.cb_Championnat.SelectedIndexChanged += new System.EventHandler(this.cb_Championnat_SelectedIndexChanged);
            // 
            // l_titreClass
            // 
            this.l_titreClass.AutoSize = true;
            this.l_titreClass.Location = new System.Drawing.Point(105, 139);
            this.l_titreClass.Name = "l_titreClass";
            this.l_titreClass.Size = new System.Drawing.Size(133, 13);
            this.l_titreClass.TabIndex = 10;
            this.l_titreClass.Text = "Sélectionner le classement";
            // 
            // l_titreChamp
            // 
            this.l_titreChamp.AutoSize = true;
            this.l_titreChamp.Location = new System.Drawing.Point(105, 108);
            this.l_titreChamp.Name = "l_titreChamp";
            this.l_titreChamp.Size = new System.Drawing.Size(130, 13);
            this.l_titreChamp.TabIndex = 9;
            this.l_titreChamp.Text = "Sélectionner championnat";
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(229, 41);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(255, 29);
            this.l_Titre.TabIndex = 8;
            this.l_Titre.Text = "Classement par joueur";
            // 
            // b_Back
            // 
            this.b_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Back.Location = new System.Drawing.Point(307, 410);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(101, 35);
            this.b_Back.TabIndex = 14;
            this.b_Back.Text = "Retour";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_Back_Click);
            // 
            // ClassementJoueur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 457);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.dg_Classement);
            this.Controls.Add(this.cb_Classement);
            this.Controls.Add(this.cb_Championnat);
            this.Controls.Add(this.l_titreClass);
            this.Controls.Add(this.l_titreChamp);
            this.Controls.Add(this.l_Titre);
            this.Name = "ClassementJoueur";
            this.Text = "Classement par Joueur";
            this.Load += new System.EventHandler(this.ClassementJoueur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Classement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Classement;
        private System.Windows.Forms.ComboBox cb_Classement;
        private System.Windows.Forms.ComboBox cb_Championnat;
        private System.Windows.Forms.Label l_titreClass;
        private System.Windows.Forms.Label l_titreChamp;
        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Button b_Back;
    }
}