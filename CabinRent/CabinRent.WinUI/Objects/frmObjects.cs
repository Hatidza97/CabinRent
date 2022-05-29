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

namespace CabinRent.WinUI.Objects
{
    public partial class frmObjects : Form
    {
        private readonly APIService _apiService = new APIService("Objekat");

        public frmObjects()
        {
            InitializeComponent();
        }

        private async void frmObjects_Load(object sender, EventArgs e)
        {
            var podaci = await _apiService.Get<List<Model.Objekat>>(null);
            List<frmObjectClass> lista = new List<frmObjectClass>();
            foreach (var item in podaci)
            {
                frmObjectClass forma = new frmObjectClass
                {
                   ObjekatId=item.ObjekatId,
                   BrojMjestaDjeca=item.BrojMjestaDjeca,
                   BrojMjestaOdrasli=item.BrojMjestaOdrasli,   
                   BrojMjestaUkupno=item.BrojMjestaUkupno,
                   Rezervisan=item.Rezervisan,
                   GradId=item.GradId,
                   Cijena=item.Cijena,
                   KorisnikId=item.KorisnikId,
                   Naziv=item.Naziv,
                   Opis=item.Opis,
                   Povrsina=item.Povrsina,
                   TipObjektaId=item.TipObjektaId

                };
                lista.Add(forma);
            }
            dgvObjects.AutoGenerateColumns = false;
            dgvObjects.DataSource = lista;
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            var pretraga = new ObjekatSearchRequest
            {
                Naziv = txtPretraga.Text
            };
            var podaci = await _apiService.Get<List<Model.Objekat>>(pretraga);
            var lista = new List<frmObjectClass>();

            foreach (var item in podaci)
            {
                var forma = new frmObjectClass
                {
                    ObjekatId = item.ObjekatId,
                    BrojMjestaDjeca = item.BrojMjestaDjeca,
                    BrojMjestaOdrasli = item.BrojMjestaOdrasli,
                    Naziv = item.Naziv,
                    Povrsina = item.Povrsina,
                    Opis = item.Opis,
                    Rezervisan = item.Rezervisan
                };
                lista.Add(forma);
            }
            dgvObjects.AutoGenerateColumns = false;
            dgvObjects.DataSource = lista;
            if (lista.Count == 0)
            {
                MessageBox.Show("Nema rezultata pretrage", "Poruka", MessageBoxButtons.OK);
            }
        }

        private void dgvObjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var objekat = dgvObjects.SelectedRows[0].Cells[0].Value;
            var rez = objekat;
            Form forma = new frmObjectDetail(Convert.ToInt32(rez));
            if (forma.ShowDialog() == DialogResult.OK)
                forma.Show();
        }
    }
}
