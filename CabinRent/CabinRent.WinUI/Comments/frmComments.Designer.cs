namespace CabinRent.WinUI.Comments
{
    partial class frmComments
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
            this.dgvKomentari = new System.Windows.Forms.DataGridView();
            this.OcjenaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Komentar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjekatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImeKlijenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrezimeKlijenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKomentari)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(299, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Komentari i ocjene";
            // 
            // dgvKomentari
            // 
            this.dgvKomentari.AllowUserToAddRows = false;
            this.dgvKomentari.AllowUserToDeleteRows = false;
            this.dgvKomentari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKomentari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKomentari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OcjenaId,
            this.Ocjena,
            this.Komentar,
            this.ObjekatId,
            this.ImeKlijenta,
            this.PrezimeKlijenta});
            this.dgvKomentari.Location = new System.Drawing.Point(12, 164);
            this.dgvKomentari.Name = "dgvKomentari";
            this.dgvKomentari.ReadOnly = true;
            this.dgvKomentari.RowHeadersWidth = 51;
            this.dgvKomentari.RowTemplate.Height = 29;
            this.dgvKomentari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKomentari.Size = new System.Drawing.Size(776, 274);
            this.dgvKomentari.TabIndex = 1;
            // 
            // OcjenaId
            // 
            this.OcjenaId.DataPropertyName = "OcjenaId";
            this.OcjenaId.HeaderText = "OcjenaId";
            this.OcjenaId.MinimumWidth = 6;
            this.OcjenaId.Name = "OcjenaId";
            this.OcjenaId.ReadOnly = true;
            this.OcjenaId.Visible = false;
            // 
            // Ocjena
            // 
            this.Ocjena.DataPropertyName = "Ocjena1";
            this.Ocjena.HeaderText = "Ocjena";
            this.Ocjena.MinimumWidth = 6;
            this.Ocjena.Name = "Ocjena";
            this.Ocjena.ReadOnly = true;
            // 
            // Komentar
            // 
            this.Komentar.DataPropertyName = "Komentar";
            this.Komentar.HeaderText = "Komentar";
            this.Komentar.MinimumWidth = 6;
            this.Komentar.Name = "Komentar";
            this.Komentar.ReadOnly = true;
            // 
            // ObjekatId
            // 
            this.ObjekatId.DataPropertyName = "NazivObjekta";
            this.ObjekatId.HeaderText = "Objekat";
            this.ObjekatId.MinimumWidth = 6;
            this.ObjekatId.Name = "ObjekatId";
            this.ObjekatId.ReadOnly = true;
            // 
            // ImeKlijenta
            // 
            this.ImeKlijenta.DataPropertyName = "ImeKlijenta";
            this.ImeKlijenta.HeaderText = "Ime klijenta";
            this.ImeKlijenta.MinimumWidth = 6;
            this.ImeKlijenta.Name = "ImeKlijenta";
            this.ImeKlijenta.ReadOnly = true;
            // 
            // PrezimeKlijenta
            // 
            this.PrezimeKlijenta.DataPropertyName = "PrezimeKlijenta";
            this.PrezimeKlijenta.HeaderText = "Prezime klijenta";
            this.PrezimeKlijenta.MinimumWidth = 6;
            this.PrezimeKlijenta.Name = "PrezimeKlijenta";
            this.PrezimeKlijenta.ReadOnly = true;
            // 
            // frmComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKomentari);
            this.Controls.Add(this.label1);
            this.Name = "frmComments";
            this.Text = "frmComments";
            this.Load += new System.EventHandler(this.frmComments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKomentari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dgvKomentari;
        private DataGridViewTextBoxColumn OcjenaId;
        private DataGridViewTextBoxColumn Ocjena;
        private DataGridViewTextBoxColumn Komentar;
        private DataGridViewTextBoxColumn ObjekatId;
        private DataGridViewTextBoxColumn ImeKlijenta;
        private DataGridViewTextBoxColumn PrezimeKlijenta;
    }
}