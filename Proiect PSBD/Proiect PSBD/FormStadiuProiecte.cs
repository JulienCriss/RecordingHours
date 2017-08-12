using Oracle.DataAccess.Client;
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
    public partial class FormStadiuProiecte : Form
    {
        public FormStadiuProiecte()
        {
            InitializeComponent();
            afisareStadiuProiecte();
        }

        /** Afisare Stadiu Proiecte **/
        public void afisareStadiuProiecte()
        {
            string query = @"SELECT PRO_NUME, PRO_ORE_ESTIMATE, PRO_ORE_EFECTUATE, PRO_STADIU
                            FROM userDBA.PROIECTE";

            string[] row = { "", "", "", "" };
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    try
                    {
                        row[0] = reader.GetString(0);
                        row[1] = reader.GetInt32(1).ToString();
                        row[2] = reader.GetInt32(2).ToString();
                        row[3] = reader.GetString(3);
                        dataGridViewProiecte.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Afisare stadiu Proiecte:" + ex.Message);
                    }
                }
            }

            labelCounterObjects.Text = dataGridViewProiecte.RowCount.ToString();
        }

        private void labelCounterObjects_Click(object sender, EventArgs e)
        {

        }
    }
}
