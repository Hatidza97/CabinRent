using CabinRent.Model;
using CabinRent.Model.SearchObjects;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinRent.WinUI
{
    public partial class Login : Form
    {
        private readonly APIService aPIService = new APIService("Korisnici");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;


                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Sva polja su obavezna", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var request = new KorisniciSearchRequest
                {
                    Username = txtUsername.Text

                };
                var result = await aPIService.Get<List<Korisnik>>(request);

                if (result is null || result.Count == 0)
                {

                    return;
                }
                else
                {
                    var result1 = await aPIService.Get<List<Korisnik>>(request);
                    int id = 0;
                    foreach (var item in result1)
                    {
                        id = item.KorisnikId;
                    }
                    frmMainPage frm = new frmMainPage(id);
                    frm.Show();
                    this.Hide();
                }
            }

            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 401)
                    MessageBox.Show("Neispravno korisničko ime ili lozinka! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Došlo je do greške, pokušajte opet! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
