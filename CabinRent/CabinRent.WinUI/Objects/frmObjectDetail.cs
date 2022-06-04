using CabinRent.Model.SearchObjects;
using CabinRent.WinUI.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        protected APIService _servisSlike = new APIService("TipObjektaSllike");
        List<byte[]> zaListanje = new List<byte[]>();
        int brojac = 0;
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
        private T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }
        public static Dictionary<String, Object> parse(byte[] json)
        {
            var reader = new StreamReader(new MemoryStream(json), Encoding.Default);

            Dictionary<String, Object> values = new JsonSerializer().Deserialize<Dictionary<string, object>>(new JsonTextReader(reader));

            return values;
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
                ObjekatSlikeSearchRequest request = new ObjekatSlikeSearchRequest
                {
                    ObjekatId = _v
                };
                var slike = await _servisSlike.Get<List<Model.TipObjektaSllike>>(request);
                if (slike.Count() >0)
                {
                    foreach (var item in slike)
                    {
                        if (item.ObjekatId == _v)
                        {
                            zaListanje.Add(item.ImageData);
                        }
                    }
                    if (zaListanje.Count() > 0)
                    {
                        pbSlike.Image = ImageHelper.FromByteToImage(zaListanje[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Nema slika za prikazati.");
                }
            }
        }

       
        private void btnUredi_Click(object sender, EventArgs e)
        {
            frmEditObject forma = new frmEditObject(_v);
            if (forma.ShowDialog() == DialogResult.OK)
                forma.Show();
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            if (brojac <= 0)
            {
                return;
            }
            else
            {
                brojac--;
                if (zaListanje[brojac].Length == 0)
                {
                    pbSlike.Image = null;
                }
                else
                {
                    pbSlike.Image = ImageHelper.FromByteToImage(zaListanje[brojac]);
                    btnNazad.Text = brojac.ToString();
                }
            }
        }

        private void btnNaprijed_Click(object sender, EventArgs e)
        {
            if (brojac == zaListanje.Count() - 1)
            {
                return;
            }
            else
            {
                brojac++;
                if (zaListanje[brojac].Length == 0)
                {
                    pbSlike.Image = null;
                }
                else
                {
                    pbSlike.Image = ImageHelper.FromByteToImage(zaListanje[brojac]);
                    btnNaprijed.Text = brojac.ToString();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
