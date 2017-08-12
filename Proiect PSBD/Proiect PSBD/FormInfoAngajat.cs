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
    public partial class FormInfoAngajat : Form
    {
        public int angID = 0;
        public FormInfoAngajat()
        {
            InitializeComponent();
        }

        public FormInfoAngajat(DataGridView dataGrid) : this()
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                angID = int.Parse(row.Cells[0].Value.ToString());

                labelNume.Text = row.Cells[1].Value.ToString();
                labelAngajare.Text = row.Cells[3].Value.ToString();
                labelParasirii.Text = row.Cells[4].Value.ToString() != "null" ? row.Cells[4].Value.ToString() : "-- Stadiu Activ --";
                labelDepartament.Text = row.Cells[5].Value.ToString();
                labelStatus.Text = row.Cells[6].Value.ToString();
            }

            if (labelStatus.Text == "inactiv")
            {
                labelStatus.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
            {
                labelStatus.ForeColor = System.Drawing.Color.ForestGreen;
            }

            char[] delimiters = { ',' };
            string userName = labelNume.Text.Split(delimiters)[0].ToLower();
            string query = @"SELECT t1.PRO_NUME, t5.COMP_DENUMIRE
                            FROM userDBA.PROIECTE t1 
                            INNER JOIN userDBA.PROIECTE_COMPETENTE t2 on t1.pro_id = t2.pro_id
                            INNER JOIN userDBA.ANGAJATI_COMPETENTE t3 on t3.comp_id = t2.comp_id
                            INNER JOIN userDBA.ANGAJATI t4 on t4.ang_id = t3.ang_id
                            INNER JOIN userDBA.COMPETENTE t5 on t5.comp_id = t2.comp_id
                            WHERE t4.ang_id = " + angID;



            string[] rowToAdd = { "" };
            string[] rowToAdd_2 = { "" };
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    try
                    {
                        rowToAdd[0] = reader.GetString(0);
                        dataGridViewCompetente.Rows.Add(rowToAdd);

                        rowToAdd_2[0] = reader.GetString(1);
                        dataGridViewProiecteAng.Rows.Add(rowToAdd_2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Afisare Competente:" + ex.Message);
                    }
                }
            }
        }
    }
}
