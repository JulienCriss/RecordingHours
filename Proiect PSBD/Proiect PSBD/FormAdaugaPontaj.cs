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
    public partial class FormAdaugaPontaj : Form
    {
        public FormAngajat parentForm;
        public int totalOrePontate = 0;
        Dictionary<int, string> projectMapping = new Dictionary<int, string>();

        public FormAdaugaPontaj()
        {
            InitializeComponent();
            populareComboBoxProiecte();
            populareIntervalOrar(comboBoxOraStart);
            populareIntervalOrar(comboBoxOraStop);
        }

        public FormAdaugaPontaj(FormAngajat form) : this()
        {
            parentForm = form;
        }

        /** Populare interfata cu proiectele pe care user-ul poate ponta **/
        public void populareComboBoxProiecte()
        {
            // adauga doar proiecte pe care user-ul poate ponta si are 
            string query = @"SELECT t1.PRO_ID, t1.PRO_NUME, lower(t4.ANG_NUME), t5.COMP_DENUMIRE
                            FROM userDBA.PROIECTE t1 
                            INNER JOIN userDBA.PROIECTE_COMPETENTE t2 on t1.pro_id = t2.pro_id
                            INNER JOIN userDBA.ANGAJATI_COMPETENTE t3 on t3.comp_id = t2.comp_id
                            INNER JOIN userDBA.ANGAJATI t4 on t4.ang_id = t3.ang_id
                            INNER JOIN userDBA.COMPETENTE t5 on t5.comp_id = t2.comp_id
                            WHERE lower(t4.ang_nume) = '" + MyOracleConnection.utilizatorId + "'";

            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                int index = 0;
                string projectName = "";
                int projectID = 0;
                while (reader.Read())
                {
                    try
                    {
                        projectID = reader.GetInt32(0);
                        projectName = reader.GetString(1);
                        // mapare proiecte impreuna cu id-ul lor 
                        projectMapping.Add(projectID, projectName);
                        // populare comBox
                        comboBoxProiect.Items.Insert(index++, projectName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare Proiecte:" + ex.Message);
                    }
                }
            }
        }

        /** Populare interval orar **/
        public void populareIntervalOrar(ComboBox combo)
        {
            for (int i = 1; i < 25; ++i)
            {
                combo.Items.Insert(i - 1, i.ToString());
            }
        }

        /** Functie Adauga Pontaj **/
        private void buttonAdaugaPontaj_Click(object sender, EventArgs e)
        {
            int idProiect = comboBoxProiect.SelectedIndex;
            int oraStart = -1;
            int oraStop = -1;
            int indexOraStart = comboBoxOraStart.SelectedIndex;
            int indexOraStop = comboBoxOraStop.SelectedIndex;
            string dataPontaj = dateTimePicker1.Value.ToShortDateString().Replace('.', '-');

            /** validare date inainte de a executa procedura **/
            // daca orele nu sunt selectate
            if (indexOraStart == -1 || indexOraStop == -1)
            {
                MessageBox.Show("[Eroare] Va rugam sa selectati intervalul orar corect.");
            }
            else
            {
                // verifica proiectul
                if (idProiect == -1)
                {
                    MessageBox.Show("[Eroare] Va rugam sa selectati un proiect valid.");
                }
                else
                {
                    oraStart = comboBoxOraStart.Items[indexOraStart].ToString().Length > 0 ? int.Parse(comboBoxOraStart.Items[indexOraStart].ToString()) : -1;
                    oraStop = comboBoxOraStop.Items[indexOraStop].ToString().Length > 0 ? int.Parse(comboBoxOraStop.Items[indexOraStop].ToString()) : -1;
                    totalOrePontate += oraStop - oraStart;
                    // verifica turele de noapte
                    if ((oraStop >= 1 && oraStop <= 6) || (oraStart >= 1 && oraStart <=6) || oraStop == 24)
                    {
                        MessageBox.Show("[Eroare] Turele de noapte nu sunt admise.\n Nu se poate ponta in intervalul 24:00 - 6:00");
                        totalOrePontate = 0;
                    }
                    else
                    {
                        // verifica daca numarul de ore pontate pe zi este depasit
                        if (totalOrePontate > 8 || totalOrePontate <= 0)
                        {
                            MessageBox.Show("[Eroare] Nu se pot ponta mai mult de 8 h/zi sau mai putin de o 1 h/zi.");
                            totalOrePontate = 0;
                        }
                        else
                        {
                            // verifica daca ziua in care se ponteaza in week-end
                            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
                            {
                                MessageBox.Show("[Eroare] Nu se pot ponta in zilele de week-end.");
                                totalOrePontate = 0;
                            }
                            else
                            {
                                int buffer = 3079;
                                string projectName = comboBoxProiect.Items[idProiect].ToString();

                                OracleCommand command = MyOracleConnection.con.CreateCommand();
                                try
                                {
                                    command.CommandText = "userDBA.ANGAJAT_PACKAGE.FUNC_ADAUGA_PONTAJ";

                                    command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                                    command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                                    // asigneaza valori parametrilor 
                                    string dateTime = dateTimePicker1.Value.ToShortDateString().Replace('.', '-');
                                    Console.Write(projectMapping.FirstOrDefault(x => x.Value == projectName).Key);
                                    command.Parameters.Add(new OracleParameter("dataPontaj", OracleDbType.Date)).Value = Convert.ToDateTime(dateTime);
                                    command.Parameters.Add(new OracleParameter("oraStart", OracleDbType.Int32)).Value = oraStart;
                                    command.Parameters.Add(new OracleParameter("oraStop", OracleDbType.Int32)).Value = oraStop;
                                    command.Parameters.Add(new OracleParameter("idProiect", OracleDbType.Int32)).Value = projectMapping.FirstOrDefault(x => x.Value == projectName).Key;//idProiect + 1;
                                    command.Parameters.Add(new OracleParameter("numeAngajat", OracleDbType.Varchar2)).Value = MyOracleConnection.utilizatorId;
                                    command.Parameters.Add(new OracleParameter("pro_ore_efec", OracleDbType.Int32)).Value = oraStop - oraStart;

                                    // executa funtia
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.ExecuteNonQuery();

                                    string flag_insert = Convert.ToString(command.Parameters["flag"].Value);
                                    // verifica ce returneaza functia pl/sql 

                                    switch (flag_insert)
                                    {
                                        case "0":
                                            {
                                                MyOracleConnection.collectPontaj(MyOracleConnection.utilizatorId, parentForm.getGridObject());
                                                MessageBox.Show("[Log] Adaugare cu succes.");
                                                totalOrePontate = 0;
                                                break;
                                            }
                                        case "1":
                                            {
                                                MessageBox.Show("[Log] Orele pe care le adaugati suprapun alte ore deja pontate.\n Verificati din nou cu atentie!");
                                                totalOrePontate = 0;
                                                break;
                                            }
                                        case "2":
                                            {
                                                MessageBox.Show("[Eroare] Nu s-a adaugat elementul nou.\n Numarul de ore pontate pe ziua: " +
                                            dateTimePicker1.Value.ToShortDateString() + " depaseste 8h/zi.");
                                                totalOrePontate = 0;
                                                break;
                                            }
                                        case "3":
                                            {
                                                MessageBox.Show("[Log] Data not found.");
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            totalOrePontate = 0;
        }
    }
}
