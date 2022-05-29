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
    public partial class frmNewPictures : Form
    {
        private int objekatId;
        protected APIService _servisObjekat = new APIService("Objekat");
        protected APIService _servisObjekatSlike = new APIService("TipObjektaSllike");
   
        public frmNewPictures(int objekatId)
        {
            this.objekatId = objekatId;
            InitializeComponent();
        }

        private void frmNewPictures_Load(object sender, EventArgs e)
        {

        }
        TipObjektaSllikeInsertRequest request = new TipObjektaSllikeInsertRequest();

        private void btnDodaj1_Click(object sender, EventArgs e)
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
                txtSlika3.Text = fileName;

                Image img = Image.FromFile(fileName);
                pbSlika3.Image = img;
                pbSlika3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSlika_Click(object sender, EventArgs e)
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (pbSlika1.Image != null)
                {
                    request.ObjekatId = objekatId;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika1.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika2.Image != null)
                {
                    request.ObjekatId = objekatId;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika2.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika3.Image != null)
                {
                    request.ObjekatId = objekatId;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika3.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                if (pbSlika4.Image != null)
                {
                    request.ObjekatId = objekatId;
                    request.Slika = ImageHelper.FromImageToByte(pbSlika4.Image);
                    await _servisObjekatSlike.Insert<Model.TipObjektaSllike>(request);
                }
                MessageBox.Show("Fotografija je dodana u bazu", "Poruka", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
