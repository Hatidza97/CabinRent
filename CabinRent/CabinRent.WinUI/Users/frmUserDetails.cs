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
    public partial class frmUserDetails : Form
    {
        private int? _v;
        private readonly APIService _apiService = new APIService("Klijent");
        

        public frmUserDetails(int v)
        {
            _v = v;
            InitializeComponent();
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (_v.HasValue)
            {
                var podaci = await _apiService.GetById<Model.Klijent>(_v);
                txtIme.Text = podaci.Ime;
                txtPrezime.Text = podaci.Prezime;
                txtBrTelefona.Text = podaci.Telefon;
                txtEmail.Text = podaci.Email;
                txtKorisnickoIme.Text = podaci.KorisnickoIme;
                if (podaci.Slika.Length > 0)
                    pbUserImage.Image = ImageHelper.FromByteToImage(podaci.Slika);
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            frmEditClient forma = new frmEditClient(_v);
            if (forma.ShowDialog() == DialogResult.OK)
                forma.Show();
        }
    }
}
