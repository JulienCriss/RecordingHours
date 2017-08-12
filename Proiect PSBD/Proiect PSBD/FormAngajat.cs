using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect_PSBD
{
    public partial class FormAngajat : Form
    {
        public FormAngajat()
        {
            InitializeComponent();
            MyOracleConnection.getAngId();
            MyOracleConnection.collectPontaj(MyOracleConnection.utilizatorId, dataGridPontaj);
            labelCounterObjects.Text = dataGridPontaj.RowCount.ToString();
        }
        /** Get grid Object **/
        public DataGridView getGridObject()
        {
            return dataGridPontaj;
        }

        /** Set label with user's name **/
        public void setUserLabel(string username)
        {
            labelUserName.Text = username;
        }

        /** Adauga pontaj nou pe un proiect **/
        private void buttonAdaugaPontaj_Click(object sender, EventArgs e)
        {
            FormAdaugaPontaj adaugaElementNou = new FormAdaugaPontaj(this);
            adaugaElementNou.ShowDialog();
        }

        /** Editeaza pontaj **/
        private void buttonEditUserObject_Click(object sender, EventArgs e)
        {
            if(dataGridPontaj.SelectedRows.Count == 0)
            {
                MessageBox.Show("[Eroare] Tabela de pontaje este goala sau nu este selectat nici un elemet.");
            }
            else
            {
                FormEditeazaPontaj editeazaElement = new FormEditeazaPontaj(this, dataGridPontaj);
                editeazaElement.ShowDialog();
            }
            
        }

        /** Sterge un element.Pontaj din tabel **/
        private void buttonDeleteUserObject_Click(object sender, EventArgs e)
        {
            // daca tabela de pontaj nu este goala
            if (dataGridPontaj.RowCount > 0)
            {
                string proiectNume = "";
                int oraStart = 0;
                int oraStop = 0;
                int totalOre = 0;
                string dateTimePontaj = "";

                foreach (DataGridViewRow row in dataGridPontaj.SelectedRows)
                {
                    proiectNume = row.Cells[1].Value.ToString();
                    oraStart = int.Parse(row.Cells[2].Value.ToString());
                    oraStop = int.Parse(row.Cells[3].Value.ToString());
                    totalOre = int.Parse(row.Cells[4].Value.ToString());
                    dateTimePontaj = row.Cells[5].Value.ToString();
                }

                int buffer = 3079;
                OracleCommand command = MyOracleConnection.con.CreateCommand();

                try
                {
                    command.CommandText = "userDBA.ANGAJAT_PACKAGE.FUNC_STERGE_PONTAJ";
                    // seteaza flag
                    command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                    command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                    // asigneaza valori parametrilor 
                    command.Parameters.Add(new OracleParameter("dataPontaj", OracleDbType.Date)).Value = DateTime.ParseExact(dateTimePontaj, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    command.Parameters.Add(new OracleParameter("oraStart", OracleDbType.Int32)).Value = oraStart;
                    command.Parameters.Add(new OracleParameter("oraStop", OracleDbType.Int32)).Value = oraStop;
                    command.Parameters.Add(new OracleParameter("proiect_nume", OracleDbType.Varchar2)).Value = proiectNume;
                    command.Parameters.Add(new OracleParameter("numeAngajat", OracleDbType.Varchar2)).Value = MyOracleConnection.utilizatorId;
                    command.Parameters.Add(new OracleParameter("pro_ore_efec", OracleDbType.Int32)).Value = totalOre;

                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("[Eroare-Exception] " + exc);
                }

                string flag_insert = Convert.ToString(command.Parameters["flag"].Value);
                if (flag_insert == "1")
                {
                    MyOracleConnection.collectPontaj(MyOracleConnection.utilizatorId, dataGridPontaj);
                    MessageBox.Show("[Log] Stergere cu succes.");
                }
                else
                {
                    MessageBox.Show("[Eroare] Nu s-a sters elementul nou.\n");
                }
            }
            else
            {
                MessageBox.Show("[Eroare] Nu exista elemente.\nTabel gol.");
            }
        }
        
        /** Logout button **/
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        private void buttonInfoSalar_Click(object sender, EventArgs e)
        {
            FormInfoSalar formInfoSalar = new FormInfoSalar();
            formInfoSalar.ShowDialog();
        }
    }
}
