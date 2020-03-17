namespace BackEnd
{
    partial class FormMdi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accueilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générerUnChampionnatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transférerUnJoueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voirLeClassementParÉquipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voirLeClassementParJoueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1684, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accueilToolStripMenuItem,
            this.générerUnChampionnatToolStripMenuItem,
            this.transférerUnJoueurToolStripMenuItem,
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem,
            this.voirLeClassementParÉquipeToolStripMenuItem,
            this.voirLeClassementParJoueurToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // accueilToolStripMenuItem
            // 
            this.accueilToolStripMenuItem.Name = "accueilToolStripMenuItem";
            this.accueilToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.accueilToolStripMenuItem.Text = "Accueil";
            // 
            // générerUnChampionnatToolStripMenuItem
            // 
            this.générerUnChampionnatToolStripMenuItem.Name = "générerUnChampionnatToolStripMenuItem";
            this.générerUnChampionnatToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.générerUnChampionnatToolStripMenuItem.Text = "Générer un championnat";
            this.générerUnChampionnatToolStripMenuItem.Click += new System.EventHandler(this.générerUnChampionnatToolStripMenuItem_Click);
            // 
            // transférerUnJoueurToolStripMenuItem
            // 
            this.transférerUnJoueurToolStripMenuItem.Name = "transférerUnJoueurToolStripMenuItem";
            this.transférerUnJoueurToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.transférerUnJoueurToolStripMenuItem.Text = "Transférer un joueur";
            this.transférerUnJoueurToolStripMenuItem.Click += new System.EventHandler(this.transférerUnJoueurToolStripMenuItem_Click);
            // 
            // visualiserUnMatchModifierLeRésultatToolStripMenuItem
            // 
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem.Name = "visualiserUnMatchModifierLeRésultatToolStripMenuItem";
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem.Text = "Visualiser un match - modifier le résultat";
            this.visualiserUnMatchModifierLeRésultatToolStripMenuItem.Click += new System.EventHandler(this.visualiserUnMatchModifierLeRésultatToolStripMenuItem_Click);
            // 
            // voirLeClassementParÉquipeToolStripMenuItem
            // 
            this.voirLeClassementParÉquipeToolStripMenuItem.Name = "voirLeClassementParÉquipeToolStripMenuItem";
            this.voirLeClassementParÉquipeToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.voirLeClassementParÉquipeToolStripMenuItem.Text = "Voir le classement par équipe";
            this.voirLeClassementParÉquipeToolStripMenuItem.Click += new System.EventHandler(this.voirLeClassementParÉquipeToolStripMenuItem_Click);
            // 
            // voirLeClassementParJoueurToolStripMenuItem
            // 
            this.voirLeClassementParJoueurToolStripMenuItem.Name = "voirLeClassementParJoueurToolStripMenuItem";
            this.voirLeClassementParJoueurToolStripMenuItem.Size = new System.Drawing.Size(359, 26);
            this.voirLeClassementParJoueurToolStripMenuItem.Text = "Voir le classement par joueur";
            this.voirLeClassementParJoueurToolStripMenuItem.Click += new System.EventHandler(this.voirLeClassementParJoueurToolStripMenuItem_Click);
            // 
            // FormMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BackEnd.Properties.Resources.production_ballon_de_foot_football_sport_coupe_du_monde;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1684, 837);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMdi";
            this.Text = "BackEnd FifaManager";
            this.Load += new System.EventHandler(this.FormMdi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accueilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem générerUnChampionnatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transférerUnJoueurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualiserUnMatchModifierLeRésultatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voirLeClassementParÉquipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voirLeClassementParJoueurToolStripMenuItem;
    }
}