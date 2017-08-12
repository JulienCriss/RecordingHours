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
    public partial class FormAdaugaAngajat : Form
    {
        Dictionary<int, string> departamentMapping = new Dictionary<int, string>();
        Dictionary<int, string> competenteMapping = new Dictionary<int, string>();
        List<string> competenteSelectate = new List<string>();

        public int idAngajat = 0;

        public FormAdaugaAngajat()
        {
            InitializeComponent();

        }

        public FormAdaugaAngajat(int id) : this()
        {
            idAngajat = id + 1;
            labelIdAngajat.Text = idAngajat.ToString();
            setDepartamente();
            setCompetente();
        }
        
        /** Adauga Departamente in interfata**/
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
                        // mapare departamente impreuna cu id-ul din baza de date
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

        /** Pentru inceput este nevoie doar de o competenta **/
        private void checkedListBoxCompetente_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxCompetente.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxCompetente.SetItemChecked(ix, false);
        }

        /** Adauga competentele in interfata **/
        public void setCompetente()
        {
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
                        // mapare competente impreuna cu id-ul din BD
                        competenteMapping.Add(competentaID, competenta);
                        checkedListBoxCompetente.Items.Add(competenta);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare competente:" + ex.Message);
                    }
                }
            }
        }
        private void create_angajat(string nume, string parola)
        {
            OracleCommand command = MyOracleConnection.con.CreateCommand();
            try
            {
                command.CommandText =
                        "begin " +
                        "  execute immediate 'alter session set \"_ORACLE_SCRIPT\"=true';" +
                        "  execute immediate 'CREATE USER "+ nume + " IDENTIFIED BY "+ parola + "';" +
                        "  execute immediate 'GRANT rol_angajat TO "+ nume + "';" +
                        "  execute immediate 'commit';"+
                        "end;";
                command.CommandType = CommandType.Text;
                Console.WriteLine(command.CommandText);
                // executa funtia
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        /** Functie de adaugare a unui nou angajat **/
        private void buttonAdaugaPontaj_Click(object sender, EventArgs e)
        {
            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            int salariu = int.Parse(textBoxSalariu.Text);
            int departamendID = comboBoxDepartament.SelectedIndex;
            string dataAngajarii = dateTimePickerAngajare.Value.ToShortDateString().Replace('.', '-');

            foreach (object itemChecked in checkedListBoxCompetente.CheckedItems)
            {
                competenteSelectate.Add(itemChecked.ToString());
            }

            if (nume.Length == 0 || prenume.Length == 0)
            {
                MessageBox.Show("[Eroare] Numele si Prenumele trebuie sa fie valide.\n Nu lasati campuri necompletate!");
            }
            else
            {
                if (salariu <= 0)
                {
                    MessageBox.Show("[Eroare] Salariul nu poate fi 0.");
                }
                else
                {
                    if (departamendID == -1)
                    {
                        MessageBox.Show("[Eroare] Va rugam sa selectati un departament.");
                    }
                    else
                    {
                        if (competenteSelectate.Count == 0)
                        {
                            MessageBox.Show("[Eroare] Va rugam sa selectati o competenta.");
                        }
                        else
                        {
                            int buffer = 3079;
                            string departamentName = comboBoxDepartament.Items[departamendID].ToString();
                            string competenta = competenteSelectate[0];

                            int idDepartament = departamentMapping.FirstOrDefault(x => x.Value == departamentName).Key;
                            int idCompetenta = competenteMapping.FirstOrDefault(x => x.Value == competenta).Key;

                            OracleCommand command = MyOracleConnection.con.CreateCommand();
                            try
                            {
                                command.CommandText = "userDBA.ADMIN_PACKAGE.FUNC_ADAUGA_ANGAJAT";

                                command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                                command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                                // asigneaza valori parametrilor 
                                
                                command.Parameters.Add(new OracleParameter("id_angajat", OracleDbType.Int32)).Value = idAngajat;
                                command.Parameters.Add(new OracleParameter("nume_angajat", OracleDbType.Varchar2)).Value = nume;
                                command.Parameters.Add(new OracleParameter("prenume_angajat", OracleDbType.Varchar2)).Value = prenume;
                                command.Parameters.Add(new OracleParameter("sal_angajat", OracleDbType.Int32)).Value = salariu;
                                command.Parameters.Add(new OracleParameter("data_angajare", OracleDbType.Date)).Value = Convert.ToDateTime(dataAngajarii);
                                command.Parameters.Add(new OracleParameter("id_departament", OracleDbType.Int32)).Value = idDepartament;
                                command.Parameters.Add(new OracleParameter("competenta_id", OracleDbType.Int32)).Value = idCompetenta;

                                // executa funtia
                                command.CommandType = CommandType.StoredProcedure;
                                command.ExecuteNonQuery();

                                string flag_insert = Convert.ToString(command.Parameters["flag"].Value);
                                // verifica ce returneaza functia pl/sql
                                create_angajat(nume, nume);
                                switch (flag_insert)
                                {
                                    case "0":
                                        {
                                            MessageBox.Show("[Log] Adaugare cu succes.");
                                            this.Close();
                                            break;
                                        }
                                    case "1":
                                        {
                                            MessageBox.Show("[Log-Err] Angajatul exista deja!");
                                            break;
                                        }
                                }
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

        private void checkedListBoxCompetente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
