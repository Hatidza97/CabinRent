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
    public partial class frmObjectDetail : Form
    {
        private int? _v;
        private readonly APIService _apiService = new APIService("Objekat");
        protected APIService _servisGrad = new APIService("Grad");
        protected APIService _servisTip = new APIService("TipObjektum");


        public frmObjectDetail(int v)
        {
            InitializeComponent();
            _v = v;
           // LoadTip();
        }

        private async void LoadTip()
        {
            var lista = await _servisGrad.Get<List<Model.Grad>>();
            lista.Insert(0, new Model.Grad());
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.DataSource = lista;
        }

        private async void frmEditObject_Load(object sender, EventArgs e)
        {
            if (_v.HasValue)
            {
                var podaci = await _apiService.GetById<Model.Objekat>(_v);
                txtCijena.Text = podaci.Cijena.ToString();
                txtDjeca.Text = podaci.BrojMjestaDjeca.ToString();
                txtNaziv.Text = podaci.Naziv;
                txtOdrasli.Text = podaci.BrojMjestaOdrasli.ToString();
                txtPovrsina.Text = podaci.Povrsina;
                txtUkupno.Text = podaci.BrojMjestaUkupno.ToString();
                var gradovi = await _servisGrad.GetById<Model.Grad>(podaci.GradId);
                cmbGrad.Text = gradovi.Naziv;
                var tip = await _servisTip.GetById<Model.TipObjektum>(podaci.TipObjektaId);
                cmbTipObjekta.Text = tip.Tip;
                if (podaci.Rezervisan == true)
                    cbRezervisan.Checked = true;
                else
                    cbRezervisan.Checked = false;
            }
        }
    }
}
