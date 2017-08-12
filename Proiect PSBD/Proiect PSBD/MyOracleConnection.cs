using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect_PSBD
{
    class MyOracleConnection
    {
        public static OracleConnection con;
        public static string utilizatorId;
        public static int angID;
        public static bool Connect(string utilizator, string parola)
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "User Id="+utilizator+";Password="+parola+";Data Source=orcl";
                con.Open();
                Console.WriteLine("Connected to OracleDB!");
                utilizatorId = utilizator;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public static void Close()
        {
            try
            {
                con.Close();
                con.Dispose();
                Console.WriteLine("Disconnected!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static OracleDataReader ExecuteQuery(string query)
        {
            string queryString = query;
            OracleCommand command = new OracleCommand(queryString, MyOracleConnection.con);
            OracleDataReader reader = command.ExecuteReader();
            return reader;
        }

        /**Colectare date pentru angajat **/
        public static void collectPontaj(string username, DataGridView dataGridPontaj)
        {
            dataGridPontaj.Rows.Clear();

            string query = @"SELECT T2.ANG_NUME || ', ' || T2.ANG_PRENUME,
                            T3.PRO_NUME,
                            T1.PONTAJ_ORA_START,
                            T1.PONTAJ_ORA_END,
                            (T1.PONTAJ_ORA_END-T1.PONTAJ_ORA_START) AS ORE,
                            T1.PONTAJ_ZI
                            FROM userDBA.PONTAJ T1
                            INNER JOIN userDBA.ANGAJATI T2 ON T1.ANG_ID = T2.ANG_ID
                            INNER JOIN userDBA.PROIECTE T3 on T3.PRO_ID = T1.PRO_ID
                            WHERE lower(T2.ANG_NUME) = '" + username + "'";
            string[] row = { "", "", "", "", "", "" };
            using (OracleDataReader reader = MyOracleConnection.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    try
                    {
                        row[0] = reader.GetString(0);
                        row[1] = reader.GetString(1);
                        row[2] = reader.GetInt32(2).ToString();
                        row[3] = reader.GetInt32(3).ToString();
                        row[4] = reader.GetInt32(4).ToString();
                        row[5] = reader.GetDateTime(5).ToString("dd-MM-yyyy");

                        dataGridPontaj.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[Eroare] Colectare Pontaj: " + ex.Message);
                    }
                }
            }
        }

        public static TipUtilizator TypeOfUtilizator()
        {
            string query = "SELECT role FROM session_roles";
            using (OracleDataReader reader = ExecuteQuery(query))
            {
                string tipUtilizator;
                while (reader.Read())
                {
                    tipUtilizator = reader.GetString(0);
                    Console.WriteLine("tip: " + tipUtilizator);
                    if ((!string.IsNullOrEmpty(tipUtilizator)) && tipUtilizator == "ADMIN_ANG")
                    {
                        return TipUtilizator.Admin;
                    }
                    if ((!string.IsNullOrEmpty(tipUtilizator)) && tipUtilizator == "ROL_ANGAJAT")
                    {
                        return TipUtilizator.Angajat;
                    }
                }
            }
            return TipUtilizator.None;
        }

        public static void getAngId()
        {
            string query = "SELECT ang_id FROM userDBA.angajati WHERE lower(ang_nume) = '" + utilizatorId +"'";
            using (OracleDataReader reader = ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    angID = reader.GetInt32(0);
                }
            }
            Console.WriteLine("Angajat id: " + angID.ToString());
        }
    }
}
