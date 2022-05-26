using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services.Helper;
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
    public partial class frmNewClient : Form
    {
        protected APIService _servisKlijent = new APIService("Klijent");
        protected APIService _servisGrad = new APIService("Grad");

        public frmNewClient()
        {
            InitializeComponent();
            AddNewClientAsync();

        }


        private async void AddNewClientAsync()
        {
            var lista = await _servisGrad.Get<List<Model.Grad>>();
            lista.Insert(0, new Model.Grad());
            cmbGradovi.ValueMember = "GradId";
            cmbGradovi.DisplayMember = "Naziv";
            cmbGradovi.DataSource = lista;
        }

        private async void frmNewClient_Load(object sender, EventArgs e)
        {
        }
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider1.SetError(txtKorisnickoIme, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider1.SetError(txtLozinka, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLozinka, null);
            }
        }

        private void txtPotvrdaLozinke_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text))
            {
                errorProvider1.SetError(txtPotvrdaLozinke, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPotvrdaLozinke, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }
        KlijentInsertRequest request = new KlijentInsertRequest();

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Email = txtEmail.Text;
                request.Telefon = txtTelefon.Text;
                request.KorisnickoIme = txtKorisnickoIme.Text;
                request.Lozinka = txtLozinka.Text;
                request.LozinkaSalt = HashGenerator.GenerateSalt();
                request.LozinkaHash = HashGenerator.GenerateHash(request.LozinkaSalt, request.Lozinka);
                var tipId = cmbGradovi.SelectedValue;
                if (int.TryParse(tipId.ToString(), out int TipId))
                {
                    request.GradId = TipId;
                }
                request.Slika = ImageHelper.FromImageToByte(pbUserImage.Image);
                var search = new KlijentSearchRequest
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text
                };
                var listaKlijenata = await _servisKlijent.Get<List<Model.Klijent>>(search);
                if (listaKlijenata.Count >= 1)
                {
                    MessageBox.Show("Klijent je već unijet u sistem, pokušajte ponovo sa novim klijentom.", "Greška", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    await _servisKlijent.Insert<Model.Klijent>(request);

                    MessageBox.Show("Klijent je dodan u bazu", "Poruka", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlika.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbUserImage.Image = img;
                pbUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
