namespace CabinRent.WinUI.Rented
{
    partial class frmRented
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRented = new System.Windows.Forms.DataGridView();
            this.ObjekatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Povrsina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojMjestaDjeca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojMjestaOdrasli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRented)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(237, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evidencija rezervisanih objekata";
            // 
            // dgvRented
            // 
            this.dgvRented.AllowUserToAddRows = false;
            this.dgvRented.AllowUserToDeleteRows = false;
            this.dgvRented.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRented.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRented.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjekatId,
            this.Naziv,
            this.Povrsina,
            this.BrojMjestaDjeca,
            this.BrojMjestaOdrasli,
            this.Cijena});
            this.dgvRented.Location = new System.Drawing.Point(12, 163);
            this.dgvRented.Name = "dgvRented";
            this.dgvRented.ReadOnly = true;
            this.dgvRented.RowHeadersWidth = 51;
            this.dgvRented.RowTemplate.Height = 29;
            this.dgvRented.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRented.Size = new System.Drawing.Size(776, 235);
            this.dgvRented.TabIndex = 1;
            // 
            // ObjekatId
            // 
            this.ObjekatId.DataPropertyName = "ObjekatId";
            this.ObjekatId.HeaderText = "ObjekatId";
            this.ObjekatId.MinimumWidth = 6;
            this.ObjekatId.Name = "ObjekatId";
            this.ObjekatId.ReadOnly = true;
            this.ObjekatId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Povrsina
            // 
            this.Povrsina.DataPropertyName = "Povrsina";
            this.Povrsina.HeaderText = "Povrsina";
            this.Povrsina.MinimumWidth = 6;
            this.Povrsina.Name = "Povrsina";
            this.Povrsina.ReadOnly = true;
            // 
            // BrojMjestaDjeca
            // 
            this.BrojMjestaDjeca.DataPropertyName = "BrojMjestaDjeca";
            this.BrojMjestaDjeca.HeaderText = "Broj mjesta djeca";
            this.BrojMjestaDjeca.MinimumWidth = 6;
            this.BrojMjestaDjeca.Name = "BrojMjestaDjeca";
            this.BrojMjestaDjeca.ReadOnly = true;
            // 
            // BrojMjestaOdrasli
            // 
            this.BrojMjestaOdrasli.DataPropertyName = "BrojMjestaOdrasli";
            this.BrojMjestaOdrasli.HeaderText = "Broj mjesta odrasli";
            this.BrojMjestaOdrasli.MinimumWidth = 6;
            this.BrojMjestaOdrasli.Name = "BrojMjestaOdrasli";
            this.BrojMjestaOdrasli.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena/dan";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pretreaga po nazivu objekta:";
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(237, 103);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(551, 27);
            this.txtPretraga.TabIndex = 3;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // frmRented
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRented);
            this.Controls.Add(this.label1);
            this.Name = "frmRented";
            this.Text = "frmRented";
            this.Load += new System.EventHandler(this.frmRented_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRented)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dgvRented;
        private DataGridViewTextBoxColumn ObjekatId;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Povrsina;
        private DataGridViewTextBoxColumn BrojMjestaDjeca;
        private DataGridViewTextBoxColumn BrojMjestaOdrasli;
        private DataGridViewTextBoxColumn Cijena;
        private Label label2;
        private TextBox txtPretraga;
    }
}