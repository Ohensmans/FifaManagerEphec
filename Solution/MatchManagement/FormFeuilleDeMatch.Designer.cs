namespace MatchManagement
{
    partial class FormFeuilleDeMatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.l_Titre = new System.Windows.Forms.Label();
            this.l_dateMatch = new System.Windows.Forms.Label();
            this.l_NomEquipe1 = new System.Windows.Forms.Label();
            this.l_NomEquipe2 = new System.Windows.Forms.Label();
            this.pb_Equipe1 = new System.Windows.Forms.PictureBox();
            this.pb_Equipe2 = new System.Windows.Forms.PictureBox();
            this.dg_Equipe1 = new System.Windows.Forms.DataGridView();
            this.dg_Equipe2 = new System.Windows.Forms.DataGridView();
            this.b_Save = new System.Windows.Forms.Button();
            this.b_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Equipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Equipe2)).BeginInit();
            this.SuspendLayout();
            // 
            // l_Titre
            // 
            this.l_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Titre.AutoSize = true;
            this.l_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Titre.Location = new System.Drawing.Point(461, 33);
            this.l_Titre.Name = "l_Titre";
            this.l_Titre.Size = new System.Drawing.Size(244, 25);
            this.l_Titre.TabIndex = 1;
            this.l_Titre.Text = "FEUILLES DE MATCH";
            // 
            // l_dateMatch
            // 
            this.l_dateMatch.AutoSize = true;
            this.l_dateMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_dateMatch.Location = new System.Drawing.Point(517, 76);
            this.l_dateMatch.Name = "l_dateMatch";
            this.l_dateMatch.Size = new System.Drawing.Size(143, 20);
            this.l_dateMatch.TabIndex = 2;
            this.l_dateMatch.Text = "Match du xx/xx/xxxx";
            // 
            // l_NomEquipe1
            // 
            this.l_NomEquipe1.AutoSize = true;
            this.l_NomEquipe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_NomEquipe1.Location = new System.Drawing.Point(24, 109);
            this.l_NomEquipe1.Name = "l_NomEquipe1";
            this.l_NomEquipe1.Size = new System.Drawing.Size(105, 20);
            this.l_NomEquipe1.TabIndex = 3;
            this.l_NomEquipe1.Text = "Nom Equipe1";
            // 
            // l_NomEquipe2
            // 
            this.l_NomEquipe2.AutoSize = true;
            this.l_NomEquipe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_NomEquipe2.Location = new System.Drawing.Point(645, 109);
            this.l_NomEquipe2.Name = "l_NomEquipe2";
            this.l_NomEquipe2.Size = new System.Drawing.Size(105, 20);
            this.l_NomEquipe2.TabIndex = 4;
            this.l_NomEquipe2.Text = "Nom Equipe2";
            // 
            // pb_Equipe1
            // 
            this.pb_Equipe1.Location = new System.Drawing.Point(27, 142);
            this.pb_Equipe1.Name = "pb_Equipe1";
            this.pb_Equipe1.Size = new System.Drawing.Size(85, 57);
            this.pb_Equipe1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Equipe1.TabIndex = 5;
            this.pb_Equipe1.TabStop = false;
            // 
            // pb_Equipe2
            // 
            this.pb_Equipe2.Location = new System.Drawing.Point(648, 142);
            this.pb_Equipe2.Name = "pb_Equipe2";
            this.pb_Equipe2.Size = new System.Drawing.Size(85, 57);
            this.pb_Equipe2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Equipe2.TabIndex = 6;
            this.pb_Equipe2.TabStop = false;
            // 
            // dg_Equipe1
            // 
            this.dg_Equipe1.AllowUserToAddRows = false;
            this.dg_Equipe1.AllowUserToDeleteRows = false;
            this.dg_Equipe1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Equipe1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Equipe1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Equipe1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Equipe1.Location = new System.Drawing.Point(27, 220);
            this.dg_Equipe1.MultiSelect = false;
            this.dg_Equipe1.Name = "dg_Equipe1";
            this.dg_Equipe1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dg_Equipe1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Equipe1.Size = new System.Drawing.Size(550, 267);
            this.dg_Equipe1.TabIndex = 7;
            this.dg_Equipe1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dg_Equipe1_DataBindingComplete);
            // 
            // dg_Equipe2
            // 
            this.dg_Equipe2.AllowUserToAddRows = false;
            this.dg_Equipe2.AllowUserToDeleteRows = false;
            this.dg_Equipe2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Equipe2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Equipe2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Equipe2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_Equipe2.Location = new System.Drawing.Point(648, 220);
            this.dg_Equipe2.MultiSelect = false;
            this.dg_Equipe2.Name = "dg_Equipe2";
            this.dg_Equipe2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Equipe2.Size = new System.Drawing.Size(550, 267);
            this.dg_Equipe2.TabIndex = 8;
            this.dg_Equipe2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dg_Equipe2_DataBindingComplete);
            // 
            // b_Save
            // 
            this.b_Save.Location = new System.Drawing.Point(366, 535);
            this.b_Save.Name = "b_Save";
            this.b_Save.Size = new System.Drawing.Size(211, 73);
            this.b_Save.TabIndex = 9;
            this.b_Save.Text = "Save";
            this.b_Save.UseVisualStyleBackColor = true;
            this.b_Save.Click += new System.EventHandler(this.b_Save_Click);
            // 
            // b_back
            // 
            this.b_back.Location = new System.Drawing.Point(648, 535);
            this.b_back.Name = "b_back";
            this.b_back.Size = new System.Drawing.Size(211, 73);
            this.b_back.TabIndex = 10;
            this.b_back.Text = "Back";
            this.b_back.UseVisualStyleBackColor = true;
            this.b_back.Click += new System.EventHandler(this.b_back_Click);
            // 
            // FormFeuilleDeMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1248, 684);
            this.Controls.Add(this.b_back);
            this.Controls.Add(this.b_Save);
            this.Controls.Add(this.dg_Equipe2);
            this.Controls.Add(this.dg_Equipe1);
            this.Controls.Add(this.pb_Equipe2);
            this.Controls.Add(this.pb_Equipe1);
            this.Controls.Add(this.l_NomEquipe2);
            this.Controls.Add(this.l_NomEquipe1);
            this.Controls.Add(this.l_dateMatch);
            this.Controls.Add(this.l_Titre);
            this.Name = "FormFeuilleDeMatch";
            this.Text = "MatchManagement : Feuille de Match";
            this.Load += new System.EventHandler(this.FormFeuilleDeMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Equipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Equipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Equipe2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Titre;
        private System.Windows.Forms.Label l_dateMatch;
        private System.Windows.Forms.Label l_NomEquipe1;
        private System.Windows.Forms.Label l_NomEquipe2;
        private System.Windows.Forms.PictureBox pb_Equipe1;
        private System.Windows.Forms.PictureBox pb_Equipe2;
        private System.Windows.Forms.DataGridView dg_Equipe1;
        private System.Windows.Forms.DataGridView dg_Equipe2;
        private System.Windows.Forms.Button b_Save;
        private System.Windows.Forms.Button b_back;
    }
}