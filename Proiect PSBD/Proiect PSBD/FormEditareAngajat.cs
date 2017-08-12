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
    public partial class FormEditareAngajat : Form
    {
        Dictionary<int, string> departamentMapping = new Dictionary<int, string>();
        Dictionary<int, string> competenteMapping = new Dictionary<int, string>();
        public int angID = 0;

        public FormEditareAngajat()
        {
            InitializeComponent();
        }

        public FormEditareAngajat(DataGridView dataGrid) : this()
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                char[] delimiter = { ',' };

                angID = int.Parse(row.Cells[0].Value.ToString());
                labelIDAng.Text = angID.ToString(); 
                textBoxNume.Text = row.Cells[1].Value.ToString().Split(delimiter)[0];
                textBoxPrenume.Text = row.Cells[1].Value.ToString().Split(delimiter)[1];
                textBoxSalariu.Text = row.Cells[2].Value.ToString();
                dateTimePickerAngajare.Text = row.Cells[3].Value.ToString();
                comboBoxDepartament.Text = row.Cells[5].Value.ToString();

            }
            setDepartamente();
            setCompetente();
        }

        /** Adauga departamentele in interfata **/
        public void setDepartamente()
        {
            string query = @"SELECT dept_id, dept_nume
                            FROM userDBA.departamente";
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                int index = 0;
                string departamentName = "";
                int departamentID = 0;
                while (reader.Read())
                {
                    try
                    {
                        departamentID = reader.GetInt32(0);
                        departamentName = reader.GetString(1);
                        // mapare departamente impreuna cu id-ul
                        departamentMapping.Add(departamentID, departamentName);
                        comboBoxDepartament.Items.Insert(index++, departamentName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare departamente:" + ex.Message);
                    }
                }
            }
        }

        /** Adauga competentele in interfata **/
        public void setCompetente()
        {
            //checkedListBox1.SetItemCheckState(0, CheckState.Indeterminate);
            string query = @"SELECT comp_id, comp_denumire
                            FROM userDBA.competente";
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                string competenta = "";
                int competentaID = 0;
                while (reader.Read())
                {
                    try
                    {
                        competentaID = reader.GetInt32(0);
                        competenta = reader.GetString(1);
                        // mapare competente impreuna cu id-ul
                        competenteMapping.Add(competentaID, competenta);
                        checkedListBoxCompetente.Items.Add(competenta);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare competente:" + ex.Message);
                    }
                }
            }

            query = @"SELECT T1.comp_denumire
                    FROM userDBA.competente T1
                    INNER JOIN userDBA.angajati_competente T2 ON t1.comp_id = T2.comp_id
                    INNER JOIN userDBA.angajati T3 ON T3.ang_id = t2.ang_id
                    WHERE T3.ang_id = " + angID;
            using (OracleDataReader reader_2 = MyOracleConnection.ExecuteQuery(query))
            {
                string competenta = "";
                while (reader_2.Read())
                {
                    try
                    {
                        competenta = reader_2.GetString(0);
                        for (int index = 0; index < checkedListBoxCompetente.Items.Count; index++)
                        {
                            if (checkedListBoxCompetente.Items[index].ToString() == competenta)
                            {
                                checkedListBoxCompetente.SetItemCheckState(index, CheckState.Checked);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare competente:" + ex.Message);
                    }
                }
            }
        }

        /** Editare competente **/
        private void buttonEditareComp_Click(object sender, EventArgs e)
        {
            string query = @"DELETE FROM userDBA.ANGAJATI_COMPETENTE WHERE ang_id = " + angID;
            OracleDataReader reader = MyOracleConnection.ExecuteQuery(query);

            int idCompetenta = -1;
            int buffer = 3079;
            bool flag_ok = false;

            if (checkedListBoxCompetente.CheckedItems.Count == 0)
            {
                MessageBox.Show("[Log] Angajatul trebuie sa aiba cel putin o competenta!");
            }
            else
            {
                foreach (object itemChecked in checkedListBoxCompetente.CheckedItems)
                {
                    idCompetenta = competenteMapping.FirstOrDefault(x => x.Value == itemChecked.ToString()).Key;

                    try
                    {
                        OracleCommand command = MyOracleConnection.con.CreateCommand();
                        command.CommandText = "userDBA.ADMIN_PACKAGE.FUNC_UPDATE_COMP";

                        command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                        command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                        // asigneaza valori parametrilor 

                        command.Parameters.Add(new OracleParameter("id_angajat", OracleDbType.Int32)).Value = angID;
                        command.Parameters.Add(new OracleParameter("id_comp", OracleDbType.Int32)).Value = idCompetenta;

                        // executa funtia
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        string flag_insert = Convert.ToString(command.Parameters["flag"].Value);
                        // verifica ce returneaza functia pl/sql

                        switch (flag_insert)
                        {
                            case "0":
                                {
                                    flag_ok = true;
                                    break;
                                }
                        }

                        command.Cancel();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("[Log - Exception] " + exc);
                    }
                }

                if (flag_ok == true)
                {
                    MessageBox.Show("[Log] Update competente cu succes!");
                }
            }
        }

        /** Editare Angajat **/ 
        private void buttonEditareAng_Click(object sender, EventArgs e)
        {
            int buffer = 3079;
            int salariu = int.Parse(textBoxSalariu.Text);
            int idDepartament =comboBoxDepartament.SelectedIndex;

            if (salariu <= 0)
            {
                MessageBox.Show("[Log] Salariu nu poate fi 0 sau o valoare negativa!");
            }
            else
            {
                if (idDepartament == -1)
                {
                    MessageBox.Show("[Eroare] Va rugam sa selectati un departament.");
                }
                else
                {
                    string departamentName = comboBoxDepartament.Items[idDepartament].ToString();
                    idDepartament = departamentMapping.FirstOrDefault(x => x.Value == departamentName).Key;
                    OracleCommand command = MyOracleConnection.con.CreateCommand();

                    try
                    {
                        command.CommandText = "userDBA.ADMIN_PACKAGE.FUNC_EDITEAZA_ANGAJAT";

                        command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                        command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                        // asigneaza valori parametrilor 
                        command.Parameters.Add(new OracleParameter("id_angajat", OracleDbType.Int32)).Value = angID;
                        command.Parameters.Add(new OracleParameter("salariu_angajat", OracleDbType.Int32)).Value = salariu;
                        command.Parameters.Add(new OracleParameter("id_dept", OracleDbType.Int32)).Value = idDepartament;

                        // executa funtia
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        string flag_insert = Convert.ToString(command.Parameters["flag"].Value);
                        // verifica ce returneaza functia pl/sql

                        switch (flag_insert)
                        {
                            case "0":
                                {
                                    MessageBox.Show("[Log] Editare angajat cu succes!");
                                    break;
                                }
                        }

                        command.Cancel();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("[Log - Exception] " + exc);
                    }
                }
            }   
        }
    }
}
