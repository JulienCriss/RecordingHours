using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect_PSBD
{
    enum TipUtilizator
    {
        None,
        Angajat,
        Admin
    };

    public partial class LoginForm : Form
    {
        public string username;
        public string password;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonConectareLogin_Click(object sender, EventArgs e)
        {
            username = textBoxUserName.Text;
            password = textBoxPassword.Text;

            if (!(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
            {
                if (MyOracleConnection.Connect(username, password))
                {
                    TipUtilizator tipUtilizator = MyOracleConnection.TypeOfUtilizator();
                    switch (tipUtilizator)
                    {
                        case TipUtilizator.Admin:
                            FormAdmin formAdmin = new FormAdmin();
                            MyOracleConnection.utilizatorId = username;
                            formAdmin.setUserLabel(username);
                            this.Hide();
                            formAdmin.ShowDialog(this);
                            this.Show();
                            break;

                        case TipUtilizator.Angajat:
                            FormAngajat formAngajat = new FormAngajat();
                            MyOracleConnection.utilizatorId = username;
                            formAngajat.setUserLabel(username);
                            this.Hide();
                            formAngajat.ShowDialog(this);
                            this.Show();
                            break;
                        case TipUtilizator.None:
                            MessageBox.Show("Accesul utilizatorului curent este restrictionat!");
                            break;
                    }
                    MyOracleConnection.Close();
                }
                else
                {
                    MessageBox.Show("Introduceti datele corect!");
                }
            }
        }

        public string getUserName()
        {
            return username;
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
