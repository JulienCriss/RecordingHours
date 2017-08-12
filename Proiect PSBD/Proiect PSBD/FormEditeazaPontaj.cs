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
    public partial class FormEditeazaPontaj : Form
    {
        public FormAngajat parentForm;
        Dictionary<int, string> projectMapping = new Dictionary<int, string>();
        public string oldValueName = "";
        public string oldValueNumeProiect = "";
        public int oldValueOraStart = 0;
        public int oldValueOraStop = 0;
        public int oldValueTotalOre = 0;
        public string oldValueDate = "";

        public FormEditeazaPontaj()
        {
            InitializeComponent();
            populareComboBoxProiecte();
            populareIntervalOrar(comboBoxOraStartEdit);
            populareIntervalOrar(comboBoxOraStopEdit);
        }

        public FormEditeazaPontaj(FormAngajat form, DataGridView gridView) : this()
        {
            parentForm = form;

            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                oldValueName = row.Cells[0].Value.ToString();
                oldValueNumeProiect = comboBoxProiectEdit.Text = row.Cells[1].Value.ToString();

                oldValueOraStart = int.Parse(row.Cells[2].Value.ToString());
                comboBoxOraStartEdit.Text = row.Cells[2].Value.ToString();

                oldValueOraStop = int.Parse(row.Cells[3].Value.ToString());
                comboBoxOraStopEdit.Text = row.Cells[3].Value.ToString();

                oldValueTotalOre = int.Parse(row.Cells[4].Value.ToString());

                oldValueDate = dateTimePickerEdit.Text = row.Cells[5].Value.ToString();
            }

        }

        /** Populare interfata cu proiectele pe care user-ul poate ponta **/
        public void populareComboBoxProiecte()
        {
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
                        // mapare proiecte impreuna cu id-ul
                        projectMapping.Add(projectID, projectName);

                        comboBoxProiectEdit.Items.Insert(index++, projectName);

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

        /** Editeaza pontajul **/
        private void buttonEditeazaPontaj_Click(object sender, EventArgs e)
        {
            int oraStart = -1;
            int oraStop = -1;
            int indexOraStart = comboBoxOraStartEdit.SelectedIndex;
            int indexOraStop = comboBoxOraStopEdit.SelectedIndex;
            int totalOrePontate = 0;

            /** validare date inainte de a executa procedura **/
            // daca orele nu sunt selectate
            if (indexOraStart == -1 || indexOraStop == -1)
            {
                MessageBox.Show("[Eroare] Va rugam sa selectati intervalul orar corect.");
            }
            else
            {
                oraStart = comboBoxOraStartEdit.Items[indexOraStart].ToString().Length > 0 ? Int32.Parse(comboBoxOraStartEdit.Items[indexOraStart].ToString()) : -1;
                oraStop = comboBoxOraStopEdit.Items[indexOraStop].ToString().Length > 0 ? Int32.Parse(comboBoxOraStopEdit.Items[indexOraStop].ToString()) : -1;
                totalOrePontate += oraStop - oraStart;

                // verifica turele de noapte
                if ((oraStop >= 1 && oraStop <= 6) || oraStop == 24)
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
                        int buffer = 3079;

                        OracleCommand command = MyOracleConnection.con.CreateCommand();
                        try
                        {
                            command.CommandText = "userDBA.ANGAJAT_PACKAGE.FUNC_EDITEAZA_PONTAJ";

                            command.Parameters.Add("flag", OracleDbType.Int32, buffer);
                            command.Parameters["flag"].Direction = ParameterDirection.ReturnValue;

                            // asigneaza valori parametrilor 
                            Console.Write(projectMapping.FirstOrDefault(x => x.Value == oldValueNumeProiect).Key);
                            command.Parameters.Add(new OracleParameter("dataPontaj", OracleDbType.Date)).Value = dateTimePickerEdit.Value;
                            command.Parameters.Add(new OracleParameter("numeAngajat", OracleDbType.Varchar2)).Value = MyOracleConnection.utilizatorId;
                            command.Parameters.Add(new OracleParameter("idProiect", OracleDbType.Int32)).Value = projectMapping.FirstOrDefault(x => x.Value == oldValueNumeProiect).Key;

                            command.Parameters.Add(new OracleParameter("oldOraStart", OracleDbType.Int32)).Value = oldValueOraStart;
                            command.Parameters.Add(new OracleParameter("oldOraStop", OracleDbType.Int32)).Value = oldValueOraStop;

                            command.Parameters.Add(new OracleParameter("newOraStart", OracleDbType.Int32)).Value = oraStart;
                            command.Parameters.Add(new OracleParameter("newOraStop", OracleDbType.Int32)).Value = oraStop;


                            command.Parameters.Add(new OracleParameter("old_pro_ore_efec", OracleDbType.Int32)).Value = oldValueTotalOre;
                            command.Parameters.Add(new OracleParameter("new_pro_ore_efec", OracleDbType.Int32)).Value = oraStop - oraStart;

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
                                        MessageBox.Show("[Log] Editare cu succes.");
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
                                        MessageBox.Show("[Log] Data not found.");
                                        totalOrePontate = 0;
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
