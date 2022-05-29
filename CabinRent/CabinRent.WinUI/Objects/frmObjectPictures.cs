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

namespace CabinRent.WinUI.Objects
{
    public partial class frmObjectPictures : Form
    {
        private int? _v;
        protected APIService _servisObjekat = new APIService("Objekat");
        protected APIService _servisObjekatSlike = new APIService("TipObjektaSllike");

        public frmObjectPictures(int? v)
        {
            InitializeComponent();
            _v = v;
        }

        private void frmObjectPictures_Load(object sender, EventArgs e)
        {

        }

        private void pbSlika1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string putanja = openFileDialog1.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika1.Image = slika;
            }
           
        }
        TipObjektaSllikeInsertRequest request = new TipObjektaSllikeInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.ObjekatId = (int)_v;
                if (pbSlika1.Image != null)
                {
                    request.Slika = ImageHelper.FromImageToByte(pbSlika1.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika2.Image != null)
                {
                    request.ObjekatId = (int)_v;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika2.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika3.Image != null)
                {
                    request.ObjekatId = (int)_v;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika3.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika4.Image != null)
                {
                    request.ObjekatId = (int)_v;    
                    request.Slika = ImageHelper.FromImageToByte(pbSlika4.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                MessageBox.Show("Fotografija je dodana u bazu", "Poruka", MessageBoxButtons.OK);
                this.Close();
            }
           
        }

        private void pbSlika2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string putanja = openFileDialog1.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika2.Image = slika;
            }
        }

        private void pbSlika3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string putanja = openFileDialog1.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika3.Image = slika;
            }
        }

        private void pbSlika4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string putanja = openFileDialog1.FileName;
                Image slika = Image.FromFile(putanja);
                pbSlika4.Image = slika;
            }
        }

        private void btnSlika1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlika1.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbSlika1.Image = img;
                pbSlika1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSlika2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlika2.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbSlika2.Image = img;
                pbSlika2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSlika3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSliak3.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbSlika3.Image = img;
                pbSlika3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSlika4_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlika4.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbSlika4.Image = img;
                pbSlika4.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
