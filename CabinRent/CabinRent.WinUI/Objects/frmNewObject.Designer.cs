namespace CabinRent.WinUI.Objects
{
    partial class frmNewObject
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
            this.components = new System.ComponentModel.Container();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblPovrsina = new System.Windows.Forms.Label();
            this.lblDjeca = new System.Windows.Forms.Label();
            this.lblOdrasli = new System.Windows.Forms.Label();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblCijena = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblGrad = new System.Windows.Forms.Label();
            this.lblRezervisan = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtPovrsina = new System.Windows.Forms.TextBox();
            this.txtDjeca = new System.Windows.Forms.TextBox();
            this.txtOdrasli = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.cbRezervisnao = new System.Windows.Forms.CheckBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(17, 30);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(103, 20);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv objekta:";
            // 
            // lblPovrsina
            // 
            this.lblPovrsina.AutoSize = true;
            this.lblPovrsina.Location = new System.Drawing.Point(17, 76);
            this.lblPovrsina.Name = "lblPovrsina";
            this.lblPovrsina.Size = new System.Drawing.Size(66, 20);
            this.lblPovrsina.TabIndex = 1;
            this.lblPovrsina.Text = "Povrsina:";
            // 
            // lblDjeca
            // 
            this.lblDjeca.AutoSize = true;
            this.lblDjeca.Location = new System.Drawing.Point(17, 124);
            this.lblDjeca.Name = "lblDjeca";
            this.lblDjeca.Size = new System.Drawing.Size(127, 20);
            this.lblDjeca.TabIndex = 2;
            this.lblDjeca.Text = "Broj mjesta djeca:";
            // 
            // lblOdrasli
            // 
            this.lblOdrasli.AutoSize = true;
            this.lblOdrasli.Location = new System.Drawing.Point(17, 178);
            this.lblOdrasli.Name = "lblOdrasli";
            this.lblOdrasli.Size = new System.Drawing.Size(136, 20);
            this.lblOdrasli.TabIndex = 3;
            this.lblOdrasli.Text = "Broj mjesta odrasli:";
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(17, 232);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(42, 20);
            this.lblOpis.TabIndex = 4;
            this.lblOpis.Text = "Opis:";
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.Location = new System.Drawing.Point(500, 30);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(84, 20);
            this.lblCijena.TabIndex = 5;
            this.lblCijena.Text = "Cijena/dan:";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(500, 76);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(87, 20);
            this.lblTip.TabIndex = 6;
            this.lblTip.Text = "Tip objekta:";
            // 
            // lblGrad
            // 
            this.lblGrad.AutoSize = true;
            this.lblGrad.Location = new System.Drawing.Point(500, 124);
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(44, 20);
            this.lblGrad.TabIndex = 7;
            this.lblGrad.Text = "Grad:";
            // 
            // lblRezervisan
            // 
            this.lblRezervisan.AutoSize = true;
            this.lblRezervisan.Location = new System.Drawing.Point(500, 178);
            this.lblRezervisan.Name = "lblRezervisan";
            this.lblRezervisan.Size = new System.Drawing.Size(82, 20);
            this.lblRezervisan.TabIndex = 8;
            this.lblRezervisan.Text = "Rezervisan:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(159, 23);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(125, 27);
            this.txtNaziv.TabIndex = 9;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // txtPovrsina
            // 
            this.txtPovrsina.Location = new System.Drawing.Point(159, 69);
            this.txtPovrsina.Name = "txtPovrsina";
            this.txtPovrsina.Size = new System.Drawing.Size(125, 27);
            this.txtPovrsina.TabIndex = 10;
            this.txtPovrsina.Validating += new System.ComponentModel.CancelEventHandler(this.txtPovrsina_Validating);
            // 
            // txtDjeca
            // 
            this.txtDjeca.Location = new System.Drawing.Point(159, 117);
            this.txtDjeca.Name = "txtDjeca";
            this.txtDjeca.Size = new System.Drawing.Size(125, 27);
            this.txtDjeca.TabIndex = 11;
            this.txtDjeca.Validating += new System.ComponentModel.CancelEventHandler(this.txtDjeca_Validating);
            // 
            // txtOdrasli
            // 
            this.txtOdrasli.Location = new System.Drawing.Point(159, 171);
            this.txtOdrasli.Name = "txtOdrasli";
            this.txtOdrasli.Size = new System.Drawing.Size(125, 27);
            this.txtOdrasli.TabIndex = 12;
            this.txtOdrasli.Validating += new System.ComponentModel.CancelEventHandler(this.txtOdrasli_Validating);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(17, 286);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(267, 118);
            this.txtOpis.TabIndex = 13;
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(590, 23);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(125, 27);
            this.txtCijena.TabIndex = 14;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // cmbTip
            // 
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(590, 68);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(125, 28);
            this.cmbTip.TabIndex = 15;
            // 
            // cmbGrad
            // 
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(590, 117);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(125, 28);
            this.cmbGrad.TabIndex = 16;
            // 
            // cbRezervisnao
            // 
            this.cbRezervisnao.AutoSize = true;
            this.cbRezervisnao.Location = new System.Drawing.Point(590, 174);
            this.cbRezervisnao.Name = "cbRezervisnao";
            this.cbRezervisnao.Size = new System.Drawing.Size(110, 24);
            this.cbRezervisnao.TabIndex = 17;
            this.cbRezervisnao.Text = "Rezervisano";
            this.cbRezervisnao.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(621, 375);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(94, 29);
            this.btnSacuvaj.TabIndex = 18;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNewObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbRezervisnao);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.txtOdrasli);
            this.Controls.Add(this.txtDjeca);
            this.Controls.Add(this.txtPovrsina);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblRezervisan);
            this.Controls.Add(this.lblGrad);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblCijena);
            this.Controls.Add(this.lblOpis);
            this.Controls.Add(this.lblOdrasli);
            this.Controls.Add(this.lblDjeca);
            this.Controls.Add(this.lblPovrsina);
            this.Controls.Add(this.lblNaziv);
            this.Name = "frmNewObject";
            this.Text = "frmNewObject";
            this.Load += new System.EventHandler(this.frmNewObject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNaziv;
        private Label lblPovrsina;
        private Label lblDjeca;
        private Label lblOdrasli;
        private Label lblOpis;
        private Label lblCijena;
        private Label lblTip;
        private Label lblGrad;
        private Label lblRezervisan;
        private TextBox txtNaziv;
        private TextBox txtPovrsina;
        private TextBox txtDjeca;
        private TextBox txtOdrasli;
        private TextBox txtOpis;
        private TextBox txtCijena;
        private ComboBox cmbTip;
        private ComboBox cmbGrad;
        private CheckBox cbRezervisnao;
        private Button btnSacuvaj;
        private ErrorProvider errorProvider1;
    }
}