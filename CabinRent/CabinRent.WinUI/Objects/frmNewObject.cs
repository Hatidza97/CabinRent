using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.WinUI.Users;
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
    public partial class frmNewObject : Form
    {
        protected APIService _servisGrad = new APIService("Grad");
        protected APIService _servisTip = new APIService("TipObjektum");
        protected APIService _servisObjekat = new APIService("Objekat");

        //public frmNewObject()
        //{
        //}

        public frmNewObject(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void frmNewObject_Load(object sender, EventArgs e)
        {
            UcitajGrad();
            UcitajTip();
        }

        private async void UcitajTip()
        {
            var lista = await _servisTip.Get<List<Model.TipObjektum>>();
            lista.Insert(0,new Model.TipObjektum());
            cmbTip.ValueMember = "TipObjektaId";
            cmbTip.DisplayMember = "Tip";
            cmbTip.DataSource = lista;
        }

        private async void UcitajGrad()
        {

            var lista = await _servisGrad.Get<List<Model.Grad>>();
            lista.Insert(0, new Model.Grad());
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.DataSource = lista;
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtPovrsina_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPovrsina.Text))
            {
                errorProvider1.SetError(txtPovrsina, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPovrsina, null);
            }
        }

        private void txtDjeca_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDjeca.Text))
            {
                errorProvider1.SetError(txtDjeca, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtDjeca, null);
            }
        }

        private void txtOdrasli_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOdrasli.Text))
            {
                errorProvider1.SetError(txtOdrasli, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOdrasli, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, " Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }
        ObjekatInsertRequest request = new ObjekatInsertRequest();
        private int id;

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Cijena =Convert.ToDouble(txtCijena.Text);
                request.BrojMjestaDjeca = Convert.ToInt32(txtDjeca.Text);
                request.BrojMjestaOdrasli = Convert.ToInt32(txtOdrasli.Text);
                request.Opis = txtOpis.Text;
                request.Rezervisan = cbRezervisnao.Checked;
                request.BrojMjestaUkupno = request.BrojMjestaDjeca + request.BrojMjestaOdrasli;
                var gradId = cmbGrad.SelectedValue;
                request.Naziv = txtNaziv.Text;
                request.Povrsina=txtPovrsina.Text;
                request.KorisnikId = id;
                if (int.TryParse(gradId.ToString(), out int GradId))
                {
                    request.GradId = GradId;
                }
                var tipId = cmbTip.SelectedValue;
                if (int.TryParse(tipId.ToString(), out int TipId))
                {
                    request.TipObjektaId = TipId;
                }
                var search = new ObjekatSearchRequest()
                {
                    Naziv = txtNaziv.Text
                };
                var listaObjekata = await _servisObjekat.Get<List<Model.Objekat>>(search);
                if (listaObjekata.Count >= 1)
                {
                    MessageBox.Show("Objekat je već unijet u sistem, pokušajte ponovo sa novim objektom.", "Greška", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    await _servisObjekat.Insert<Model.Objekat>(request);
                    var result=MessageBox.Show("Objekat je dodan u bazu, da li zelite dodati slike za isti", "Poruka", MessageBoxButtons.YesNo);
                    var zadnji=await _servisObjekat.Get<List<Model.Objekat>>();
                    var brojac = 0;
                    foreach (var item in zadnji)
                    {
                        brojac++;
                    }
                    var el = await _servisObjekat.GetById<Model.Objekat>(brojac);
                    var rez = el.ObjekatId;
                    if (result == DialogResult.Yes)
                    {
                        Form nova = new frmNewPictures(el.ObjekatId);
                        if (nova.ShowDialog() == DialogResult.OK)
                            nova.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                    this.Close();
                }
            }
        }
    }
}
