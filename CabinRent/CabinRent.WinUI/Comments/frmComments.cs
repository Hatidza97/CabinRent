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

namespace CabinRent.WinUI.Comments
{
    public partial class frmComments : Form
    {
        private readonly APIService _apiService = new APIService("Objekat");
        private readonly APIService _apiOcjena = new APIService("Ocjena");

        public frmComments()
        {
            InitializeComponent();
        }

        private void frmComments_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            var podaci = await _apiOcjena.Get<List<Model.Ocjena>>();
            List<frmOcjeneKomentari> lista = new List<frmOcjeneKomentari>();
            foreach (var x in podaci)
            {
                frmOcjeneKomentari forma = new frmOcjeneKomentari
                {
                    OcjenaId = x.OcjenaId,
                    Ocjena1 = x.Ocjena1,
                    KlijentId = x.KlijentId,
                    ImeKlijenta = x.Klijent.Ime,
                    PrezimeKlijenta = x.Klijent.Prezime,
                    ObjekatId = x.ObjekatId,
                    NazivObjekta = x.Objekat.Naziv,
                    Komentar = x.Komentar
                };
                lista.Add(forma);
            }
            dgvKomentari.AutoGenerateColumns = false;
            dgvKomentari.DataSource=lista;
        }
    }
}
