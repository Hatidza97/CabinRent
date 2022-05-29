using CabinRent.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinRent.WinUI.Objects
{
    public partial class frmEditObject : Form
    {
        private int? _v;
        protected APIService _servisObjekat = new APIService("Objekat");
        protected APIService _servisGrad = new APIService("Grad");
        protected APIService _servisTip = new APIService("TipObjektum");
        public frmEditObject(int? v)
        {
            _v = v;
            InitializeComponent();
            LoadTip();
            LoadTipObjekta();
        }

        private async void LoadTipObjekta()
        {
            var lista=await _servisTip.Get<List<Model.TipObjektum>>();  
            lista.Insert(0,new Model.TipObjektum());
            cmbTip.DisplayMember = "Tip";
            cmbTip.ValueMember = "TipObjektaId";
            cmbTip.DataSource = lista;
        }

        private async void LoadTip()
        {
            var lista = await _servisGrad.Get<List<Model.Grad>>();
            lista.Insert(0, new Model.Grad());
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.DataSource = lista;
        }

        private void frmEditObject_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            if (_v.HasValue)
            {
                var podaci = await _servisObjekat.GetById<Model.Objekat>(_v);
                txtCijena.Text = podaci.Cijena.ToString();
                txtDjeca.Text = podaci.BrojMjestaDjeca.ToString();
                txtOdrasli.Text = podaci.BrojMjestaOdrasli.ToString();
                txtOpis.Text = podaci.Opis;
                txtPovrsina.Text = podaci.Povrsina;
                txtNaziv.Text = podaci.Naziv;
            }
        }
        ObjekatUpdateRequest request = new ObjekatUpdateRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (_v.HasValue)
            {
                if (this.ValidateChildren())
                {
                    request.Naziv = txtNaziv.Text;
                    request.BrojMjestaDjeca =Convert.ToInt32(txtDjeca.Text);
                    request.BrojMjestaOdrasli =Convert.ToInt32(txtOdrasli.Text);
                    request.BrojMjestaUkupno = request.BrojMjestaDjeca + request.BrojMjestaOdrasli;
                    request.Opis = txtOpis.Text;
                    request.Cijena =Convert.ToDouble(txtCijena.Text);
                    request.Povrsina = txtPovrsina.Text;
                    var tipId = cmbTip.SelectedValue;
                    var GradId=cmbGrad.SelectedValue;   
                    if (int.TryParse(tipId.ToString(), out int TipId))
                    {
                        request.TipObjektaId = TipId;
                    }
                    if (int.TryParse(GradId.ToString(), out int gradId))
                    {
                        request.GradId = gradId;
                    }
                    await _servisObjekat.Update<Model.Objekat>(_v, request);
                    MessageBox.Show("Podaci o objektu su izmijenjeni", "Poruka", MessageBoxButtons.OK);
                   
                    this.Close();
                }

            }
        }

        private void btnSlike_Click(object sender, EventArgs e)
        {
            frmObjectPictures forma = new frmObjectPictures(_v);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                forma.Show();
            }
        }
    }
}
