namespace BackEnd
{
    partial class TransfertJoueurs
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
            this.dg_TransfertJoueurs = new System.Windows.Forms.DataGridView();
            this.b_Back = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TransfertJoueurs)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(225, 31);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(257, 29);
            this.l_Titre.TabIndex = 2;
            this.l_Titre.Text = "Transférer des joueurs";
            // 
            // dg_TransfertJoueurs
            // 
            this.dg_TransfertJoueurs.AllowUserToAddRows = false;
            this.dg_TransfertJoueurs.AllowUserToDeleteRows = false;
            this.dg_TransfertJoueurs.AllowUserToOrderColumns = true;
            this.dg_TransfertJoueurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_TransfertJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_TransfertJoueurs.Location = new System.Drawing.Point(49, 95);
            this.dg_TransfertJoueurs.Name = "dg_TransfertJoueurs";
            this.dg_TransfertJoueurs.Size = new System.Drawing.Size(609, 343);
            this.dg_TransfertJoueurs.TabIndex = 5;
            this.dg_TransfertJoueurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_TransfertJoueurs_CellClick);
            // 
            // b_Back
            // 
            this.b_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Back.Location = new System.Drawing.Point(49, 459);
            this.b_Back.Name = "b_Back";
            this.b_Back.Size = new System.Drawing.Size(148, 37);
            this.b_Back.TabIndex = 6;
            this.b_Back.Text = "Retour";
            this.b_Back.UseVisualStyleBackColor = true;
            this.b_Back.Click += new System.EventHandler(this.b_Back_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(510, 459);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(148, 37);
            this.B_Save.TabIndex = 7;
            this.B_Save.Text = "Sauvegarder et rafraichir";
            this.B_Save.UseVisualStyleBackColor = true;
            // 
            // TransfertJoueurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 519);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.b_Back);
            this.Controls.Add(this.dg_TransfertJoueurs);
            this.Controls.Add(this.l_Titre);
            this.Name = "TransfertJoueurs";
            this.Text = "Transfert de Joueurs";
            this.Load += new System.EventHandler(this.TransfertJoueurs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TransfertJoueurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.DataGridView dg_TransfertJoueurs;
        private System.Windows.Forms.Button b_Back;
        private System.Windows.Forms.Button B_Save;
    }
}