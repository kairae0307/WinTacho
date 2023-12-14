using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using System.Net.Sockets;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;


namespace ConvertTacho
{
    public partial class FormMdbList : Form
    {

        private iniClass inicls = new iniClass();
        public string TACHO2_path = "";
        public string MdbName = "";
        FormData formData;
        public FormMdbList(FormData f)
        {
            InitializeComponent();

            				// Ŭ���̾�Ʈ�� TMF ���� ���
            //  string path = "c:\\tmf";	
         //   string path = tmfpath;


            formData = f;
       //     string[] Tacho2Folder_tmf = new string[files.Length];
             

            string path = Application.StartupPath + "\\WinTacho.ini";
             TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path); // Ÿ�� ��Ʈ

             string RValue = "";
             RValue = inicls.GetIniValue("Tacho Init", "Tacho Send Select", path);  // Ÿ�� ���۹�� �о� ���� 
          int num = Convert.ToInt32(RValue);

          if (num == 1)
          {
              TACHO2_path += "Ÿ��";
          }
          else if (num == 2)
          {
              TACHO2_path += "Ÿ�� �Ϻ�";
          }
          else if (num == 3)
          {
              TACHO2_path += "Ÿ�� ����и�";
          }
          DirectoryInfo dir = new DirectoryInfo(TACHO2_path);
               FileInfo[] files = dir.GetFiles();   // ���� ��������

               for (int i = files.Length-1; i >=0 ; i--)
               {
                   if (files[i].Extension != ".ldb")
                   {
                       checkedListBox.Items.Add(files[i].ToString());
                       checkedListBox1.Items.Add(files[i].ToString());
                   }
               }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox.CheckedItems.Count > 1 || checkedListBox1.CheckedItems.Count > 1)
            {
                MessageBox.Show("�Ѱ��� �����Ͽ� �ּ���");
                return;
            }
            else
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {


                    if (checkedListBox.GetItemChecked(i))
                    {

                        formData.Mdb_CutNameA = TACHO2_path + "\\" + checkedListBox.Text;
                        formData.MdbMove_file = checkedListBox.Text; ;

                    }


                }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {

                        formData.Mdb_CutNameB = TACHO2_path + "\\" + checkedListBox1.Text;

                    }


                }
                if (formData.TachoCut == true)
                {
                    formData.ReadTacho_Cut();
                    formData.TachoCut = false;
                }
                else if (formData.TachoMove == true)
                {
                    
                    formData.TachoMovefunc();
                    formData.TachoMove = false;
                    checkedListBox1.Enabled = true;
                }

              

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}