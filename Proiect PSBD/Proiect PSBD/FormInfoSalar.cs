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
    public partial class FormInfoSalar : Form
    {
        public FormInfoSalar()
        {
            InitializeComponent();
            loadInfoAng();
        }
        private void loadInfoAng()
        {
            //-------Set label for NUME, PRENUME, SALAR DEFAULT, DEPARTAMENT
            string query = @"SELECT T1.ANG_NUME , T1.ANG_PRENUME,
                            T1.ANG_SALARIU,
                            T2.DEPT_NUME
                            FROM userDBA.ANGAJATI T1
                            INNER JOIN userDBA.DEPARTAMENTE T2 ON T1.DEPT_ID = T2.DEPT_ID
                            WHERE T1.ANG_ID = " + MyOracleConnection.angID;
            try
            {
                using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
                {
                    while (reader.Read())
                    {

                        labelNume.Text = reader.GetString(0) + " " + reader.GetString(1);
                        labelSalarDefault.Text = reader.GetInt32(2).ToString() + " RON";
                        labelDepartament.Text = reader.GetString(3);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("[Eroare 01] Afisare info salariu:" + ex.Message);
            }

            //-------Set label for ORE LUCRATE
            query = @"SELECT SUM(pontaj_ora_end-pontaj_ora_start) FROM userDBA.PONTAJ 
                        WHERE to_char(pontaj_zi,'MM') = to_char(ADD_MONTHS(SYSDATE, -1),'MM')
                        AND 
                        ANG_ID = " + MyOracleConnection.angID;
            try
            {
                using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
                {
                    while (reader.Read())
                    {
                        labelOreLucrate.Text = reader.GetInt32(0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[Eroare 02] Afisare info salariu:" + ex.Message);
            }

            //-------Set label for Salariu final
            int buffer = 4096;

            OracleCommand command = MyOracleConnection.con.CreateCommand();
            try
            {
                command.CommandText = "userDBA.ANGAJAT_PACKAGE.FUNC_ANGAJAT_SALAR";

                command.Parameters.Add("salar", OracleDbType.Double, buffer);
                command.Parameters["salar"].Direction = ParameterDirection.ReturnValue;

                // asigneaza valori parametrilor 
                command.Parameters.Add(new OracleParameter("var_ang_id", OracleDbType.Double)).Value = MyOracleConnection.angID;

                // executa funtia
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                string finalSalary = Convert.ToString(command.Parameters["salar"].Value);
                // verifica ce returneaza functia pl/sql 
                if (finalSalary != "null")
                {
                    labelSalarFinal.Text = finalSalary + " RON";
                }
                else
                {
                    labelSalarFinal.Text = "0 RON";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("[Log - Exception] " + exc);
            }
        }
    }
}
