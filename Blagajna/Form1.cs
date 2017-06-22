using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.IO;

namespace Blagajna
{
    public partial class Form1 : Form
    {
        private static String databasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).Replace("\\Blagajna\\bin\\Debug", "");

        private readonly string MY_CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ databasePath + "\\Blagajna\\blagajna.MDB";

        ScriptEngine m_pyEngine = null;
        ScriptScope m_pyScope = null;

        OleDbConnection myConnection;
        OleDbDataAdapter myOleDbAdapter;

        int mSelectedPosition;
        BindingList<Stavka> racun = new BindingList<Stavka>();
        double mUkupnaCijena;
        int mBrojRacuna = 1;

        BindingSource bsProizvodi = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            RefreshData();

            //Py stuff
            m_pyEngine = Python.CreateEngine();
            m_pyScope = m_pyEngine.CreateScope();

        }

        private void RefreshData()
        {
            using (myConnection = new OleDbConnection(MY_CONNECTION_STRING))
            {
                myConnection.Open();
                using (myOleDbAdapter = new OleDbDataAdapter())
                {
                    DataSet myDataSet = new DataSet();

                    myOleDbAdapter.SelectCommand = new OleDbCommand("SELECT * FROM proizvodi", myConnection);
                    myOleDbAdapter.Fill(myDataSet, "proizvodi");

                    bsProizvodi.DataSource = myDataSet;
                    bsProizvodi.DataMember = "proizvodi";

                    myConnection.Close();
                }
            }
            proizvodiGV.DataSource = bsProizvodi;

            try
            {
                DataGridViewColumn column = proizvodiGV.Columns[0];
                column.Width = 30;
                column = proizvodiGV.Columns[1];
                column.Width = 80;
                column = proizvodiGV.Columns[2];
                column.Width = 80;
                column = proizvodiGV.Columns[3];
                column.Width = 50;
                column = proizvodiGV.Columns[4];
                column.Width = 50;
                column = proizvodiGV.Columns[6];
                column.Width = 50;
            }
            catch
            {
                Console.Write("error");
            }
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            using (myConnection = new OleDbConnection(MY_CONNECTION_STRING))
            {
                myConnection.Open();
                using (myOleDbAdapter = new OleDbDataAdapter())
                {
                    DataSet myDataSet = new DataSet();
                    String currentData = searchTB.Text;
                    String sql;

                    if (brojRB.Checked) {
                        sql = "SELECT * FROM proizvodi WHERE id LIKE '%" + currentData + "%'";
                    }
                    else{
                        sql = "SELECT * FROM proizvodi WHERE naziv LIKE '%" + currentData + "%'";
                    }
                    myOleDbAdapter.SelectCommand = new OleDbCommand(sql, myConnection);
                    myOleDbAdapter.Fill(myDataSet, "proizvodi");

                    bsProizvodi.DataSource = myDataSet;
                    bsProizvodi.DataMember = "proizvodi";

                    myConnection.Close();
                }
            }
            proizvodiGV.DataSource = bsProizvodi;
        }

        private void proizvodiGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                System.Text.StringBuilder ukupniOpisProizvoda = new System.Text.StringBuilder();

                mSelectedPosition = e.RowIndex;
                ukupniOpisProizvoda.Append(proizvodiGV.Rows[mSelectedPosition].Cells["id"].Value.ToString());
                ukupniOpisProizvoda.Append(" ");
                ukupniOpisProizvoda.Append(proizvodiGV.Rows[mSelectedPosition].Cells["naziv"].Value.ToString());
                ukupniOpisProizvoda.Append(" ");
                ukupniOpisProizvoda.Append(proizvodiGV.Rows[mSelectedPosition].Cells["proizvodac"].Value.ToString());
                ukupniOpisProizvoda.Append(" ");
                ukupniOpisProizvoda.Append(proizvodiGV.Rows[mSelectedPosition].Cells["kolicina"].Value.ToString());

                selectedTB.Text = ukupniOpisProizvoda.ToString();

                bool isPromjenjivaKolicina = bool.Parse(proizvodiGV.Rows[mSelectedPosition].Cells["promjenjivaKolicina"].Value.ToString());
                if (isPromjenjivaKolicina)
                {
                    kolicinaLbl.Text = "Kilogrami:";
                    kolicinaTB.Text = "";
                }
                else
                {
                    kolicinaLbl.Text = "Kolicina:";
                    kolicinaTB.Text = "1";
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (kolicinaTB.Text == "")
            {
                potrebnoPoljeLabel.Text = "*Obvezno polje";
                return;
            }
            if (kolicinaTB.Text.Contains("."))
            {
                bool isPromjenjivaKolicina = bool.Parse(proizvodiGV.Rows[mSelectedPosition].Cells["promjenjivaKolicina"].Value.ToString());
                if (!isPromjenjivaKolicina)
                {
                    potrebnoPoljeLabel.Text = "*Samo cijeli broj";
                    return;
                }
            }

            if (Int32.Parse(kolicinaTB.Text) < 0)
            {
                potrebnoPoljeLabel.Text = "*Kriva vrijednost";
                return;
            }

            potrebnoPoljeLabel.Text = "";
            Double kupljenaKolicina;
            kupljenaKolicina = Double.Parse(kolicinaTB.Text);

            String naziv = proizvodiGV.Rows[mSelectedPosition].Cells["naziv"].Value.ToString();
            String proizvodjac = proizvodiGV.Rows[mSelectedPosition].Cells["proizvodac"].Value.ToString();
            double cijena  = Double.Parse(proizvodiGV.Rows[mSelectedPosition].Cells["cijena"].Value.ToString());
            String zadanaKolicina = proizvodiGV.Rows[mSelectedPosition].Cells["kolicina"].Value.ToString();
           
            int razinaPoreza = int.Parse(proizvodiGV.Rows[mSelectedPosition].Cells["porez"].Value.ToString());

            double cijenaSPorezom;
            double zaPlatiti = 0;

            String pythonPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            pythonPath = pythonPath.Replace("\\Blagajna\\bin\\Debug", "");
            ScriptSource ss = m_pyEngine.CreateScriptSourceFromFile(pythonPath + "\\Calculations\\Calculations.py");
            ss.Execute(m_pyScope);

            Func<double, double, double> IzracunCijeneSPorezom = m_pyScope.GetVariable<Func<double, double, double>>("IzracunCijeneSPorezom");
            cijenaSPorezom = IzracunCijeneSPorezom(cijena, razinaPoreza);
            cijenaSPorezom = Math.Round(cijenaSPorezom, 2);
      
            Func<double, double, double> IzracunKonacneCijeneStavke = m_pyScope.GetVariable<Func<double, double, double>>("IzracunKonacneCijeneStavke");
            zaPlatiti = IzracunKonacneCijeneStavke(cijenaSPorezom, kupljenaKolicina);
            zaPlatiti = Math.Round(zaPlatiti, 2);

            mUkupnaCijena += zaPlatiti;

            Stavka stavka = new Stavka();
            stavka = new Stavka(naziv, proizvodjac, zadanaKolicina, cijenaSPorezom, kupljenaKolicina, zaPlatiti);
            racun.Add(stavka);

            racunGV.DataSource = racun;

            kolicinaTB.Text = "1";
            searchTB.Text = "";
            selectedTB.Text = "";
            ukupnoLabel.Text = mUkupnaCijena.ToString();

            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double ukupnoZaPlatiti;
            double ukupnoPrimljeno;
            double zaVratiti;

            ukupnoZaPlatiti = double.Parse(ukupnoLabel.Text);
            ukupnoPrimljeno = double.Parse(primljenoTB.Text);
            zaVratiti = ukupnoPrimljeno - ukupnoZaPlatiti;

            if (zaVratiti < 0)
            {
                MessageBox.Show("Nedovoljno novca za platiti", "Blagajna",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else {
                zaVratiti = Math.Round(zaVratiti, 2);
                String stringZaPrikaz = "Za platiti: " + ukupnoZaPlatiti + "\n" + "Primljeno: " + ukupnoPrimljeno + "\n"+
                    "_________________\n"+ "VRATITI: " + zaVratiti;
                MessageBox.Show(stringZaPrikaz, "Blagajna");

                printBill(ukupnoZaPlatiti, ukupnoPrimljeno, zaVratiti);
            }
        }

        private void printBill(double ukupnoZaPlatiti, double ukupnoPrimljeno, double zaVratiti)
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("dd.MM.yyyy hh:mm:ss");
            string formattedTimeForPath = time.ToString("ddMMyyyy_hh_mm_ss");
            string folderPath = "C:\\Users\\Public\\Documents\\Racuni";

            Directory.CreateDirectory(folderPath); ;

            string path = folderPath + "\\racun"+ formattedTimeForPath + "_" + mBrojRacuna+".txt";


             using (StreamWriter writer = File.AppendText(path))
            {               
                writer.WriteLine(formattedTime);
                writer.WriteLine("\n");
                writer.WriteLine("Broj racuna " + mBrojRacuna);
                writer.WriteLine("\n");

                foreach (Stavka s in racun)
                {
                    writer.WriteLine(s.ToDelimitedString());
                }

                System.Text.StringBuilder stringZaPrikaz = new System.Text.StringBuilder();

                stringZaPrikaz.Append("_______________");
                stringZaPrikaz.Append("\r\n");
                stringZaPrikaz.Append("Za platiti:  ");
                stringZaPrikaz.Append(ukupnoZaPlatiti);
                stringZaPrikaz.Append("\r\n");
                stringZaPrikaz.Append("_______________");
                stringZaPrikaz.Append("\r\n");
                stringZaPrikaz.Append("Primljeno:  ");
                stringZaPrikaz.Append(ukupnoPrimljeno);
                stringZaPrikaz.Append("\r\n");
                stringZaPrikaz.Append("Vraceno:  ");
                stringZaPrikaz.Append(zaVratiti);
                stringZaPrikaz.Append("\r\n");

                writer.WriteLine(stringZaPrikaz);

                writer.Close();
            }

            newBill();
        }

        private void newBill()
        {
            mBrojRacuna++;
            mUkupnaCijena = 0;
            racun.Clear();
            RefreshData();
            kolicinaTB.Text = "1";
            searchTB.Text = "";
            selectedTB.Text = "";
            primljenoTB.Text = "0";
            ukupnoLabel.Text = "0";
        }       
}
}
