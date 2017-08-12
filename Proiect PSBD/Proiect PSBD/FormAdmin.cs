using System;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect_PSBD
{

    public partial class FormAdmin : Form
    {
        int angajatIdBD = 0;
        public FormAdmin()
        {
            InitializeComponent();
            afisareAngajati();
        }

        /** Afisare Angajati **/
        public void afisareAngajati()
        {
            dataGridAngajati.Rows.Clear();

            string query = @"SELECT T1.ANG_ID,
                            T1.ANG_NUME || ', ' || T1.ANG_PRENUME,
                            T1.ANG_SALARIU,
                            T1.ANG_DATA_ANGAJARE,
                            T1.ANG_DATA_PARASIRE,
                            T2.DEPT_NUME
                            FROM userDBA.ANGAJATI T1
                            INNER JOIN userDBA.DEPARTAMENTE T2 ON T1.DEPT_ID = T2.DEPT_ID";

            string[] row = { "", "", "", "", "", "", "" };
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    try
                    {
                        row[0] = reader.GetInt32(0).ToString();                     //id
                        row[1] = reader.GetString(1);                               //nume/prenume         
                        row[2] = reader.GetInt32(2).ToString();                     //salariu
                        row[3] = reader.GetDateTime(3).ToString("dd/MM/yyyy");      //data angajare
                        row[5] = reader.GetString(5);                               //departament
                        row[6] = "inactiv";                                         //stadiul
                        if (!reader.IsDBNull(4))
                        {
                            row[4] = reader.GetDateTime(4).ToString("dd/MM/yyyy");  //data parasirii firmei
                        }
                        else
                        {
                            row[4] = "null";
                            row[6] = "activ";
                        }
                        dataGridAngajati.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Afisare angajati:" + ex.Message);
                    }
                }
            }

            labelCounterObjects.Text = dataGridAngajati.RowCount.ToString();
            angajatIdBD = int.Parse(dataGridAngajati.RowCount.ToString());
            dataGridAngajati.Sort(dataGridAngajati.Columns[6], ListSortDirection.Ascending);
        }

        /** Seteaza username in inerfata **/
        public void setUserLabel(string username)
        {
            this.labelUserName.Text = username;
        }

        /** Action Buton Logout **/
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /** Afiseaza stadiu proiecte **/
        private void buttonStadiuProiect_Click(object sender, EventArgs e)
        {
            FormStadiuProiecte formProiecte = new FormStadiuProiecte();
            formProiecte.ShowDialog();
        }

        /** Afiseaza Informatii despre un angajat **/
        private void buttonInfoAngajat_Click(object sender, EventArgs e)
        {
            FormInfoAngajat infoAngajat = new FormInfoAngajat(dataGridAngajati);
            infoAngajat.ShowDialog();
        }

        /** Insereaza un angajat **/
        private void buttonInsertNewObject_Click(object sender, EventArgs e)
        {
            FormAdaugaAngajat newAngajat = new FormAdaugaAngajat(angajatIdBD);
            newAngajat.ShowDialog();
            afisareAngajati();
        }

        /** Editeaza un angajat **/
        private void buttonEditObject_Click(object sender, EventArgs e)
        {
            FormEditareAngajat editAngajat = new FormEditareAngajat(dataGridAngajati);
            editAngajat.ShowDialog();
            afisareAngajati();
        }

        /** Sterge un Angajat
            Va fi marcat cu statusul inactiv **/
        private void buttonDeleteObject_Click(object sender, EventArgs e)
        {
            int id_angajat = -1;

            foreach (DataGridViewRow row in dataGridAngajati.SelectedRows)
            {
                id_angajat = int.Parse(row.Cells[0].Value.ToString());
            }

            if (id_angajat == -1)
            {
                MessageBox.Show("[Eroare] Va rugam sa selectati un angajat!");
            }
            else
            {
                try
                {
                    OracleCommand command = MyOracleConnection.con.CreateCommand();
                    command.CommandText = "userDBA.ADMIN_PACKAGE.PROC_DELETE_ANGAJAT";
                    // asigneaza valori parametrilor 
                    command.Parameters.Add(new OracleParameter("id_angajat", OracleDbType.Int32)).Value = id_angajat;

                    // executa funtia
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.Cancel();
                    afisareAngajati();

                }
                catch (Exception exc)
                {
                    MessageBox.Show("[Log - Exception] " + exc);
                }
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
