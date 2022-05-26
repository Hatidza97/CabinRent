namespace CabinRent.WinUI.Objects
{
    partial class frmObjectDetail
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
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblPovrsina = new System.Windows.Forms.Label();
            this.lblDjeca = new System.Windows.Forms.Label();
            this.lblOdrasli = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.lblCijena = new System.Windows.Forms.Label();
            this.lblRezervisano = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtPovrsina = new System.Windows.Forms.TextBox();
            this.txtDjeca = new System.Windows.Forms.TextBox();
            this.txtOdrasli = new System.Windows.Forms.TextBox();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.cbRezervisan = new System.Windows.Forms.CheckBox();
            this.lblTipObjekta = new System.Windows.Forms.Label();
            this.cmbTipObjekta = new System.Windows.Forms.ComboBox();
            this.lblGrad = new System.Windows.Forms.Label();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(21, 37);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(103, 20);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv objekta:";
            // 
            // lblPovrsina
            // 
            this.lblPovrsina.AutoSize = true;
            this.lblPovrsina.Location = new System.Drawing.Point(21, 76);
            this.lblPovrsina.Name = "lblPovrsina";
            this.lblPovrsina.Size = new System.Drawing.Size(66, 20);
            this.lblPovrsina.TabIndex = 1;
            this.lblPovrsina.Text = "Povrsina:";
            // 
            // lblDjeca
            // 
            this.lblDjeca.AutoSize = true;
            this.lblDjeca.Location = new System.Drawing.Point(21, 114);
            this.lblDjeca.Name = "lblDjeca";
            this.lblDjeca.Size = new System.Drawing.Size(146, 20);
            this.lblDjeca.TabIndex = 2;
            this.lblDjeca.Text = "Broj mjesta za djecu:";
            // 
            // lblOdrasli
            // 
            this.lblOdrasli.AutoSize = true;
            this.lblOdrasli.Location = new System.Drawing.Point(21, 156);
            this.lblOdrasli.Name = "lblOdrasli";
            this.lblOdrasli.Size = new System.Drawing.Size(159, 20);
            this.lblOdrasli.TabIndex = 3;
            this.lblOdrasli.Text = "Broj mjesta za odrasle:";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(21, 201);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(140, 20);
            this.lblUkupno.TabIndex = 4;
            this.lblUkupno.Text = "Broj mjesta ukupno:";
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.Location = new System.Drawing.Point(21, 241);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(53, 20);
            this.lblCijena.TabIndex = 5;
            this.lblCijena.Text = "Cijena:";
            // 
            // lblRezervisano
            // 
            this.lblRezervisano.AutoSize = true;
            this.lblRezervisano.Location = new System.Drawing.Point(21, 282);
            this.lblRezervisano.Name = "lblRezervisano";
            this.lblRezervisano.Size = new System.Drawing.Size(82, 20);
            this.lblRezervisano.TabIndex = 6;
            this.lblRezervisano.Text = "Rezervisan:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(205, 30);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(125, 27);
            this.txtNaziv.TabIndex = 7;
            // 
            // txtPovrsina
            // 
            this.txtPovrsina.Location = new System.Drawing.Point(205, 69);
            this.txtPovrsina.Name = "txtPovrsina";
            this.txtPovrsina.Size = new System.Drawing.Size(125, 27);
            this.txtPovrsina.TabIndex = 8;
            // 
            // txtDjeca
            // 
            this.txtDjeca.Location = new System.Drawing.Point(205, 107);
            this.txtDjeca.Name = "txtDjeca";
            this.txtDjeca.Size = new System.Drawing.Size(125, 27);
            this.txtDjeca.TabIndex = 9;
            // 
            // txtOdrasli
            // 
            this.txtOdrasli.Location = new System.Drawing.Point(205, 149);
            this.txtOdrasli.Name = "txtOdrasli";
            this.txtOdrasli.Size = new System.Drawing.Size(125, 27);
            this.txtOdrasli.TabIndex = 10;
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(205, 194);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(125, 27);
            this.txtUkupno.TabIndex = 11;
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(205, 238);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(125, 27);
            this.txtCijena.TabIndex = 12;
            // 
            // cbRezervisan
            // 
            this.cbRezervisan.AutoSize = true;
            this.cbRezervisan.Location = new System.Drawing.Point(205, 282);
            this.cbRezervisan.Name = "cbRezervisan";
            this.cbRezervisan.Size = new System.Drawing.Size(110, 24);
            this.cbRezervisan.TabIndex = 13;
            this.cbRezervisan.Text = "Rezervisano";
            this.cbRezervisan.UseVisualStyleBackColor = true;
            // 
            // lblTipObjekta
            // 
            this.lblTipObjekta.AutoSize = true;
            this.lblTipObjekta.Location = new System.Drawing.Point(21, 323);
            this.lblTipObjekta.Name = "lblTipObjekta";
            this.lblTipObjekta.Size = new System.Drawing.Size(87, 20);
            this.lblTipObjekta.TabIndex = 14;
            this.lblTipObjekta.Text = "Tip objekta:";
            // 
            // cmbTipObjekta
            // 
            this.cmbTipObjekta.FormattingEnabled = true;
            this.cmbTipObjekta.Location = new System.Drawing.Point(205, 315);
            this.cmbTipObjekta.Name = "cmbTipObjekta";
            this.cmbTipObjekta.Size = new System.Drawing.Size(125, 28);
            this.cmbTipObjekta.TabIndex = 15;
            // 
            // lblGrad
            // 
            this.lblGrad.AutoSize = true;
            this.lblGrad.Location = new System.Drawing.Point(21, 358);
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(44, 20);
            this.lblGrad.TabIndex = 16;
            this.lblGrad.Text = "Grad:";
            // 
            // cmbGrad
            // 
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(205, 355);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(125, 28);
            this.cmbGrad.TabIndex = 17;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(616, 392);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(94, 29);
            this.btnSacuvaj.TabIndex = 18;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // frmEditObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 447);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.lblGrad);
            this.Controls.Add(this.cmbTipObjekta);
            this.Controls.Add(this.lblTipObjekta);
            this.Controls.Add(this.cbRezervisan);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.txtOdrasli);
            this.Controls.Add(this.txtDjeca);
            this.Controls.Add(this.txtPovrsina);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblRezervisano);
            this.Controls.Add(this.lblCijena);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.lblOdrasli);
            this.Controls.Add(this.lblDjeca);
            this.Controls.Add(this.lblPovrsina);
            this.Controls.Add(this.lblNaziv);
            this.Name = "frmEditObject";
            this.Text = "frmEditObject";
            this.Load += new System.EventHandler(this.frmEditObject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNaziv;
        private Label lblPovrsina;
        private Label lblDjeca;
        private Label lblOdrasli;
        private Label lblUkupno;
        private Label lblCijena;
        private Label lblRezervisano;
        private TextBox txtNaziv;
        private TextBox txtPovrsina;
        private TextBox txtDjeca;
        private TextBox txtOdrasli;
        private TextBox txtUkupno;
        private TextBox txtCijena;
        private CheckBox cbRezervisan;
        private Label lblTipObjekta;
        private ComboBox cmbTipObjekta;
        private Label lblGrad;
        private ComboBox cmbGrad;
        private Button btnSacuvaj;
    }
}