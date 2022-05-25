using CabinRent.Model.SearchObjects;
using CabinRent.Model.ViewModel;
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
    public partial class frmUsers : Form
    {
        private readonly APIService _apiService = new APIService("Klijent");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            var podaci = await _apiService.Get<List<Model.Klijent>>(null);
            List<frmUsersClass> lista = new List<frmUsersClass>();
            foreach (var item in podaci)
            {
                frmUsersClass forma = new frmUsersClass
                {
                    KlijentId = item.KlijentId,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    Slika = item.Slika,
                    GradID = item.GradId,
                    //Grad=item.Grad.Naziv,
                    Telefon = item.Telefon,
                    Username = item.KorisnickoIme
                   

                };
                lista.Add(forma);
            }
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = lista;
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var pretraga = new KlijentSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            
            var podaci = await _apiService.Get<List<Model.Klijent>>(pretraga);
            var lista = new List<frmUsersClass>();

            foreach (var item in podaci)
            {
                var forma = new frmUsersClass
                {
                    KlijentId = item.KlijentId,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    Slika = item.Slika,
                    Telefon = item.Telefon,
                    Username = item.KorisnickoIme

                };
                lista.Add(forma);
            }
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = lista;
            if (lista.Count == 0)
            {
                MessageBox.Show("Nema rezultata pretrage", "Poruka", MessageBoxButtons.OK);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var klijent = dgvUsers.SelectedRows[0].Cells[0].Value;
            
            var rez = klijent.ToString();
            Form forma = new frmUserDetails(int.Parse(rez));
            if(forma.ShowDialog()==DialogResult.OK)
            forma.Show();
        }
    }
}
