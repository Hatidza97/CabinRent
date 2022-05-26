using CabinRent.Model;
using CabinRent.Model.Requests;
using CabinRent.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinRent.WinUI.Users
{
    public partial class frmEditClient : Form
    {
        private int? _v;
        protected APIService _servisKlijent = new APIService("Klijent");
        protected APIService _servisGrad = new APIService("Grad");
        
        public frmEditClient(int? v)
        {
            _v = v;
            InitializeComponent();
            LoadTip();
        }

        private async void frmEditClient_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            if (_v.HasValue)
            {

                var podaci = await _servisKlijent.GetById<Model.Klijent>(_v);
                txtIme.Text = podaci.Ime;
                txtPrezime.Text = podaci.Prezime;
                txtTelefon.Text = podaci.Telefon;
                txtKorisnickoIme.Text = podaci.KorisnickoIme;
                txtEmail.Text = podaci.Email;
                if (podaci.Slika.Length > 0)
                    pictureBox1.Image = ImageHelper.FromByteToImage(podaci.Slika);
            }
        }

        private async Task LoadTip()
        {
            var lista = await _servisGrad.Get<List<Model.Grad>>();
            lista.Insert(0, new Model.Grad());
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.DataSource = lista;
        }
        KlijentUpdateRequest request = new KlijentUpdateRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (_v.HasValue)
            {
                if (this.ValidateChildren())
                {
                    request.Ime = txtIme.Text;
                    request.Prezime = txtPrezime.Text;
                    request.KorisnickoIme = txtKorisnickoIme.Text;
                    request.Email = txtEmail.Text;
                    request.Telefon = txtTelefon.Text;
                    var tipId = cmbGrad.SelectedValue;
                    if (int.TryParse(tipId.ToString(), out int TipId))
                    {
                        request.GradId = TipId;
                    }

                    await _servisKlijent.Update<Klijent>(_v, request);
                    MessageBox.Show("Podaci o klientu su izmijenjeni", "Poruka", MessageBoxButtons.OK);
                    this.Close();
                }

            }
        }
    }
}
