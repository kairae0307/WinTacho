using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using PrintableListView;
using System.Threading;
using ZedGraph;
using ListViewEx;
using System.Drawing.Printing;
namespace ConvertTacho
{
    public partial class FormLogin : Form
    {
     
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();

        public string ID = "";
        public string Password ="";

        public FormLogin()
        {
            InitializeComponent();
            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트


            string path = TACHO2_path;
            string filename = "Information.mdb";
            string filename1 = "Information1.mdb";
            string filename2 = "Information2.mdb";
            string filename3 = "Information3.mdb";
            if (Directory.Exists(TACHO2_path))
            {
                
            }
            else
            {
                System.IO.Directory.CreateDirectory(path);

                string Filesource = System.IO.Path.Combine(Application.StartupPath, filename);
                System.IO.File.Copy(Filesource, path + "\\" + filename);   //
            }



            if (System.IO.File.Exists(path + "\\" + filename))  // information 같은 파일의이름이 존재 함
            {

            }
            else
            {
                string Filesource = System.IO.Path.Combine(Application.StartupPath, filename);
                System.IO.File.Copy(Filesource, path + "\\" + filename);   //
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            if (System.IO.File.Exists(path + "\\" + filename1))  // information1 같은 파일의이름이 존재 함
            {

            }
            else
            {
                string Filesource = System.IO.Path.Combine(Application.StartupPath, filename);
                System.IO.File.Copy(Filesource, path + "\\" + filename1);   //
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            if (System.IO.File.Exists(path + "\\" + filename2))  //information2 같은 파일의이름이 존재 함
            {

            }
            else
            {
                string Filesource = System.IO.Path.Combine(Application.StartupPath, filename);
                System.IO.File.Copy(Filesource, path + "\\" + filename2);   //
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            if (System.IO.File.Exists(path + "\\" + filename3))  // information3 같은 파일의이름이 존재 함
            {

            }
            else
            {
                string Filesource = System.IO.Path.Combine(Application.StartupPath, filename);
                System.IO.File.Copy(Filesource, path + "\\" + filename3);   //
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////

           

            string DBstring = "";
            string NameDB = TACHO2_path + "\\Information.mdb";
            //DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            //					 Db_backup = false;


            OleDbConnection conn = new OleDbConnection(@DBstring);
            conn.Open();

            string queryRead = "select  * from TachoKey";

            OleDbCommand commRead = new OleDbCommand(queryRead, conn);
            OleDbDataReader srRead = commRead.ExecuteReader();



           
            while (srRead.Read())
            {
                if (srRead.IsDBNull(1) == false)
                {

                    ID = srRead.GetString(1);
                }
                if (srRead.IsDBNull(2) == false)
                {
                    Password = srRead.GetString(2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ID)
            {
                if (textBox2.Text == Password)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Password 가 잘못 되었습니다.!");
                }
            }
            else
            {
                MessageBox.Show("ID 가 잘못 되었습니다.!");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        char a;
     
    }
}