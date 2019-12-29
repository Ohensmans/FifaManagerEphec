namespace MatchManagement
{
    partial class FormAccueil
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
            this.l_SelChamp = new System.Windows.Forms.Label();
            this.l_SelMatch = new System.Windows.Forms.Label();
            this.cb_Champ = new System.Windows.Forms.ComboBox();
            this.cb_Match = new System.Windows.Forms.ComboBox();
            this.b_FeuMatch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Location = new System.Drawing.Point(110, 37);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(125, 13);
            this.l_Titre.TabIndex = 0;
            this.l_Titre.Text = "MATCH MANAGEMENT";
            // 
            // l_SelChamp
            // 
            this.l_SelChamp.AutoSize = true;
            this.l_SelChamp.Location = new System.Drawing.Point(24, 95);
            this.l_SelChamp.Name = "l_SelChamp";
            this.l_SelChamp.Size = new System.Drawing.Size(141, 13);
            this.l_SelChamp.TabIndex = 1;
            this.l_SelChamp.Text = "Sélectionner le championnat";
            // 
            // l_SelMatch
            // 
            this.l_SelMatch.AutoSize = true;
            this.l_SelMatch.Location = new System.Drawing.Point(24, 131);
            this.l_SelMatch.Name = "l_SelMatch";
            this.l_SelMatch.Size = new System.Drawing.Size(109, 13);
            this.l_SelMatch.TabIndex = 2;
            this.l_SelMatch.Text = "Sélectionner le match";
            // 
            // cb_Champ
            // 
            this.cb_Champ.FormattingEnabled = true;
            this.cb_Champ.Location = new System.Drawing.Point(188, 92);
            this.cb_Champ.Name = "cb_Champ";
            this.cb_Champ.Size = new System.Drawing.Size(121, 21);
            this.cb_Champ.TabIndex = 3;
            // 
            // cb_Match
            // 
            this.cb_Match.FormattingEnabled = true;
            this.cb_Match.Location = new System.Drawing.Point(188, 128);
            this.cb_Match.Name = "cb_Match";
            this.cb_Match.Size = new System.Drawing.Size(121, 21);
            this.cb_Match.TabIndex = 4;
            // 
            // b_FeuMatch
            // 
            this.b_FeuMatch.Location = new System.Drawing.Point(39, 202);
            this.b_FeuMatch.Name = "b_FeuMatch";
            this.b_FeuMatch.Size = new System.Drawing.Size(94, 65);
            this.b_FeuMatch.TabIndex = 5;
            this.b_FeuMatch.Text = "Remplir les feuilles de match";
            this.b_FeuMatch.UseVisualStyleBackColor = true;
            this.b_FeuMatch.Click += new System.EventHandler(this.b_FeuMatch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 65);
            this.button1.TabIndex = 6;
            this.button1.Text = "Inscrire/Modifier les résultats";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 305);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_FeuMatch);
            this.Controls.Add(this.cb_Match);
            this.Controls.Add(this.cb_Champ);
            this.Controls.Add(this.l_SelMatch);
            this.Controls.Add(this.l_SelChamp);
            this.Controls.Add(this.l_Titre);
            this.Name = "FormAccueil";
            this.Text = "MatchManagement Accueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_SelChamp;
        private System.Windows.Forms.Label l_SelMatch;
        private System.Windows.Forms.ComboBox cb_Champ;
        private System.Windows.Forms.ComboBox cb_Match;
        private System.Windows.Forms.Button b_FeuMatch;
        private System.Windows.Forms.Button button1;
    }
}