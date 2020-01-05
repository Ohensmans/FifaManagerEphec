namespace BackEnd
{
    partial class Accueil
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
            this.b_GenChamp = new System.Windows.Forms.Button();
            this.l_Titre = new System.Windows.Forms.Label();
            this.b_TransfJoueurs = new System.Windows.Forms.Button();
            this.b_Match = new System.Windows.Forms.Button();
            this.b_ClassEqu = new System.Windows.Forms.Button();
            this.b_ClasJoueu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_GenChamp
            // 
            this.b_GenChamp.Location = new System.Drawing.Point(82, 134);
            this.b_GenChamp.Name = "b_GenChamp";
            this.b_GenChamp.Size = new System.Drawing.Size(182, 61);
            this.b_GenChamp.TabIndex = 0;
            this.b_GenChamp.Text = "Générer un championnat";
            this.b_GenChamp.UseVisualStyleBackColor = true;
            // 
            // l_Titre
            // 
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(29, 29);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(301, 31);
            this.l_Titre.TabIndex = 1;
            this.l_Titre.Text = "BackEnd FifaManager";
            // 
            // b_TransfJoueurs
            // 
            this.b_TransfJoueurs.Location = new System.Drawing.Point(82, 219);
            this.b_TransfJoueurs.Name = "b_TransfJoueurs";
            this.b_TransfJoueurs.Size = new System.Drawing.Size(182, 61);
            this.b_TransfJoueurs.TabIndex = 2;
            this.b_TransfJoueurs.Text = "Transférer des joueurs";
            this.b_TransfJoueurs.UseVisualStyleBackColor = true;
            // 
            // b_Match
            // 
            this.b_Match.Location = new System.Drawing.Point(82, 304);
            this.b_Match.Name = "b_Match";
            this.b_Match.Size = new System.Drawing.Size(182, 61);
            this.b_Match.TabIndex = 3;
            this.b_Match.Text = "Visualiser un match - modifier le résultat";
            this.b_Match.UseVisualStyleBackColor = true;
            // 
            // b_ClassEqu
            // 
            this.b_ClassEqu.Location = new System.Drawing.Point(82, 387);
            this.b_ClassEqu.Name = "b_ClassEqu";
            this.b_ClassEqu.Size = new System.Drawing.Size(182, 61);
            this.b_ClassEqu.TabIndex = 4;
            this.b_ClassEqu.Text = "Voir le classement par équipe";
            this.b_ClassEqu.UseVisualStyleBackColor = true;
            // 
            // b_ClasJoueu
            // 
            this.b_ClasJoueu.Location = new System.Drawing.Point(82, 472);
            this.b_ClasJoueu.Name = "b_ClasJoueu";
            this.b_ClasJoueu.Size = new System.Drawing.Size(182, 61);
            this.b_ClasJoueu.TabIndex = 5;
            this.b_ClasJoueu.Text = "Voir le classement par joueur";
            this.b_ClasJoueu.UseVisualStyleBackColor = true;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 561);
            this.Controls.Add(this.b_ClasJoueu);
            this.Controls.Add(this.b_ClassEqu);
            this.Controls.Add(this.b_Match);
            this.Controls.Add(this.b_TransfJoueurs);
            this.Controls.Add(this.l_Titre);
            this.Controls.Add(this.b_GenChamp);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_GenChamp;
        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Button b_TransfJoueurs;
        private System.Windows.Forms.Button b_Match;
        private System.Windows.Forms.Button b_ClassEqu;
        private System.Windows.Forms.Button b_ClasJoueu;
    }
}