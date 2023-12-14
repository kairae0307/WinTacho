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
using System.Data.OleDb;
using System.Threading;


using System.Windows.Forms;

namespace ConvertTacho
{
	public partial class FormDayInfoCal : Form
	{
		FormData fd;
		FormDayInfo formDayInfo;
		FormTotalRec formTotalRec;
        
        public bool DriverCheck = false;
		public string Car_Num = "";
		public int indexcount = 0;
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();
		public FormDayInfoCal(FormData f)
		{
			fd = f;
			InitializeComponent();

			// ������ȣ ä���
            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // Ÿ�� ��Ʈ

			if (fd.bSearchStartSel == false)
			{

                int CarCount = 0; 
				foreach (string cbc in fd.comboBox������ȣ.Items)
					checkedListBoxCar.Items.Add(cbc);
				fd.nlCarSel = new List<int>();

				//////
				fd.SortCheck = true;
                if (fd.Driverilbo == true)
                {
                    DriverCheck = true;
                    Carcnt_label.Text = "�� ���� :";
                    groupBox3.Text ="��� ����";
                    fd.comboBox����ȣ.Items.Clear();
                    fd.FillData(2, 0);
                }
                else
                {
                    DriverCheck = false;
                    
                    Carcnt_label.Text = "�� ������ :";
                    groupBox3.Text = "���� ����";
                    fd.comboBox������ȣ.Items.Clear();
                    fd.FillData(1, 0);
                }
				checkedListBoxCar.Items.Clear();

             /*   if (fd.Driverilbo == true)
                {
                    fd.comboBox����ȣ.Items.Clear();
                    fd.FillData(2, 1);
                }
                else
                {
                    fd.comboBox������ȣ.Items.Clear();
                    fd.FillData(1, 1);
                }*/

				for (int j = 0; j < fd.listView1.Items.Count - 2; j++)
				{
                    string cbc = ""; ;
                    if (fd.Driverilbo == true)
                    {
                        cbc = fd.listView1.Items[j].SubItems[2].Text;   // listview Id -> string
                         /*if (!fd.comboBox����ȣ.Items.Contains(cbc))
                            {
                                fd.comboBox����ȣ.Items.Add(cbc);
                                CarCount++;
                            }*/
                    }
                    else
                    {
                        cbc = fd.listView1.Items[j].SubItems[1].Text;   // listview Id -> string
                            /*if (!fd.comboBox������ȣ.Items.Contains(cbc))
                            {
                                fd.comboBox������ȣ.Items.Add(cbc);
                                CarCount++;
                            }*/
                    }

                    
               
					if (!checkedListBoxCar.Items.Contains(cbc))
						checkedListBoxCar.Items.Add(cbc);
				}

				fd.nlCarSel = new List<int>();
               // Carcnt_label.Text += " " + CarCount.ToString();

                Carcnt_label.Text += checkedListBoxCar.Items.Count.ToString();
			}
			else
			{

              /*  string path1 = Application.StartupPath + "\\FtpSetting.ini";
                using (StreamReader sr = new StreamReader(path1, System.Text.Encoding.UTF8))
                {
                    string line, destStr = "";
                    char[] dest = new char[20];
                    line = sr.ReadLine();

                    if (line.CompareTo("Ftp Setting") == 0)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            line = sr.ReadLine();
                        }



                        line = sr.ReadLine();                           // c:\tacho2
                        TACHO2_path = line;
                    }
                }*/
				string Dirname = "";

				if(fd.Dayseach_tacho== true)
				{
                    Dirname = TACHO2_path + "\\Ÿ��";
				}
				else if(fd.Dayseach_tachoday == true)
				{
                    Dirname = TACHO2_path + "\\Ÿ�� �Ϻ�";
				}
				else if(fd.Dayseach_tacho2day == true)
				{
                    Dirname = TACHO2_path + "\\Ÿ�� ����и�";
				}
				else if(fd.Dayseach_tachoauto== true)
				{
                    Dirname = TACHO2_path + "\\Ÿ�� �ڵ��и�";
				}
				if (Directory.Exists(Dirname))
				{

				}
				else
				{
					MessageBox.Show("�������� �ʴ� Ÿ�� �Դϴ�.\nŸ�� ������ �ٽ� �Ͽ��ּ���!");
					return;
				}
				DirectoryInfo dirs = new DirectoryInfo(Dirname);
				DirectoryInfo[] DIRS = dirs.GetDirectories();
				FileInfo[] files = dirs.GetFiles();

				string[] file_str = new string[files.Length];

				char[] trimChars = { '.', 'm', 'd', 'b' };
				int cnt = 0;
				for (int i = 0; i < files.Length; i++)
				{

					if (files[i].Extension != ".ldb")
					{

						file_str[i] = files[i].ToString();
						file_str[i] = file_str[i].TrimEnd(trimChars);

					}


				}
				int j = 0;

				string[] Carnum = new string[10000];
				for (int i = 0; i < file_str.Length; i++)
				{


					string DBstring = "";

					
					if (fd.Db_backup == true)
					{
						if (file_str[i] == null)
						{
							continue;
						}

							DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";
						
						//					 Db_backup = false;


					}
					else
					{
						DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

					}
					string queryRead = "select * from TblTacho";

					OleDbConnection conn1 = new OleDbConnection(@DBstring);
					conn1.Open();
					OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
					OleDbDataReader srRead = commRead.ExecuteReader();
					
					//if ((srRead.GetString(1).Contains(compareObject) == false))
					//	continue;   // ������ȣ�� ����� Ÿ ������ȣ �Ÿ���
					while(srRead.Read())
					{

                        if (fd.Driverilbo == true)
                        {
                            Carnum[j] = srRead.GetString(2);
                        }
                        else
                        {
                            Carnum[j] = srRead.GetString(1);
                        }
						j++;
					}
					conn1.Close();

				}
				Carnum = GetDistinctValues<string>(Carnum);
				for(int i=0; i<Carnum.Length; i++)
				{
					if(Carnum[i] != null)
					checkedListBoxCar.Items.Add(Carnum[i]);
				}

			
			
			}
			////
			
			
		}
		public T[] GetDistinctValues<T>(T[] array)
		{
			List<T> tmp = new List<T>();

			for(int i=0; i<array.Length; i++)
			{
				if(tmp.Contains(array[i])) continue;
				tmp.Add(array[i]);
			}

			return tmp.ToArray();
		}
		private void Run_Click(object sender, EventArgs e)
		{

			fd.SortCheck = true;
            if (fd.Driverilbo == true)
            {
                fd.comboBox����ȣ.Items.Clear();
                fd.FillData(2, 1);
            }
            else
            {
               // fd.comboBox������ȣ.Items.Clear();
                fd.FillData(1, 1);
            }
			checkedListBoxCar.Items.Clear();

		

			for (int j = 0; j < fd.listView1.Items.Count - 2; j++)
			{
                if (fd.Driverilbo == true)
                {
                    string cbc = fd.listView1.Items[j].SubItems[2].Text;   // listview Id -> string

                    if (!fd.comboBox����ȣ.Items.Contains(cbc))
                        fd.comboBox����ȣ.Items.Add(cbc);

                    if (!checkedListBoxCar.Items.Contains(cbc))
                        checkedListBoxCar.Items.Add(cbc);
                }
                else
                {
                    string cbc = fd.listView1.Items[j].SubItems[1].Text;   // listview Id -> string

                    if (!fd.comboBox������ȣ.Items.Contains(cbc))
                        fd.comboBox������ȣ.Items.Add(cbc);

                    if (!checkedListBoxCar.Items.Contains(cbc))
                        checkedListBoxCar.Items.Add(cbc);
                }
			}

			fd.nlCarSel = new List<int>();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if (checkedListBoxCar.CheckedItems.Count == 1)
             {

					
                        fd.bCarTotalSel = false;

                        if (fd.nlCarSel.Count > 0)
                            fd.nlCarSel.Clear();

						
					
                        for (int i = 0; i < checkedListBoxCar.Items.Count; i++)
                        {

						
							if (checkedListBoxCar.GetItemChecked(i))
							{

								Car_Num = checkedListBoxCar.Text;

                                if (Car_Num == "����")
                                {
                                    MessageBox.Show(" '����' ���˻��Ҽ� �����ϴ�.");
                                    return;
                                }
							
							}
							
                        }
						//MessageBox.Show(Car_Num);
               }
             else
              {
                  if (fd.Driverilbo == true)
                  {
                      MessageBox.Show("��縦 ������ �ּ���.", "����");
                      return;
                  }
                  else
                  {
                      MessageBox.Show("�Ѱ��� ������ ������ �ּ���.", "����");
                      return;
                  }
              }

			  for (int j = 0; j < fd.listView1.Items.Count - 2; j++)
			  {
                  string cbc = "";
                  if (fd.Driverilbo == true)
                  {
                      cbc = fd.listView1.Items[j].SubItems[2].Text;

                      if (Car_Num == cbc)
                          indexcount++;
                  }
                  else
                  {
                       cbc = fd.listView1.Items[j].SubItems[1].Text;

                      if (Car_Num == cbc)
                          indexcount++;
                  }
			
			  }

			
			  if (fd.bSearchStartSel == false)
			  {
				  formDayInfo = new FormDayInfo(fd);
				  formDayInfo.FillData(Car_Num, indexcount);
				  formDayInfo.MdiParent = this.ParentForm;
				  formDayInfo.BringToFront();
				  formDayInfo.Show();

			  }
			  else 
			  {
				  formTotalRec = new FormTotalRec(fd);
				
				  formTotalRec.MdiParent = this.ParentForm;
				  formTotalRec.BringToFront();
				  formTotalRec.Show();
				 // fd.bSearchStartSel = false;
				  formTotalRec.FillDaySearchData(Car_Num, fd.dtSearchStartDay, fd.dtSearchEndDay,0);
			  }
			 
			  this.Close();



		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}