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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.l_Titre = new System.Windows.Forms.Label();
            this.l_SelChamp = new System.Windows.Forms.Label();
            this.cb_Champ = new System.Windows.Forms.ComboBox();
            this.b_FeuMatch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridListeMatchs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListeMatchs)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Location = new System.Drawing.Point(237, 35);
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
            // cb_Champ
            // 
            this.cb_Champ.FormattingEnabled = true;
            this.cb_Champ.Location = new System.Drawing.Point(188, 92);
            this.cb_Champ.Name = "cb_Champ";
            this.cb_Champ.Size = new System.Drawing.Size(121, 21);
            this.cb_Champ.TabIndex = 3;
            this.cb_Champ.SelectedIndexChanged += new System.EventHandler(this.cb_Champ_SelectedIndexChanged);
            // 
            // b_FeuMatch
            // 
            this.b_FeuMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_FeuMatch.Location = new System.Drawing.Point(150, 373);
            this.b_FeuMatch.Name = "b_FeuMatch";
            this.b_FeuMatch.Size = new System.Drawing.Size(94, 65);
            this.b_FeuMatch.TabIndex = 5;
            this.b_FeuMatch.Text = "Remplir les feuilles de match";
            this.b_FeuMatch.UseVisualStyleBackColor = true;
            this.b_FeuMatch.Click += new System.EventHandler(this.b_FeuMatch_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(350, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 65);
            this.button1.TabIndex = 6;
            this.button1.Text = "Inscrire/Modifier les résultats";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridListeMatchs
            // 
            this.dataGridListeMatchs.AllowUserToAddRows = false;
            this.dataGridListeMatchs.AllowUserToDeleteRows = false;
            this.dataGridListeMatchs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridListeMatchs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridListeMatchs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridListeMatchs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridListeMatchs.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListeMatchs.Location = new System.Drawing.Point(27, 137);
            this.dataGridListeMatchs.Name = "dataGridListeMatchs";
            this.dataGridListeMatchs.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridListeMatchs.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridListeMatchs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListeMatchs.Size = new System.Drawing.Size(535, 176);
            this.dataGridListeMatchs.TabIndex = 7;
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.dataGridListeMatchs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_FeuMatch);
            this.Controls.Add(this.cb_Champ);
            this.Controls.Add(this.l_SelChamp);
            this.Controls.Add(this.l_Titre);
            this.Name = "FormAccueil";
            this.Text = "MatchManagement Accueil";
            this.Load += new System.EventHandler(this.FormAccueil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListeMatchs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_SelChamp;
        private System.Windows.Forms.ComboBox cb_Champ;
        private System.Windows.Forms.Button b_FeuMatch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridListeMatchs;
    }
}