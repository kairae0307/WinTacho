using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConvertTacho
{
    public partial class FormDataSetting : Form
    {
        public DataSetting ds;

        public struct DataSetting
        {
            public int nRecentDataCount;
            public bool bInputNumberAnytime;
            public int nIndexOfDefaultViewItem;
            public bool bCheckedChangeSet;
            public int nIndexOfChangeAMHour;
            public int nIndexOfChangePMHour;
        }

        public FormDataSetting()
        {
            InitializeComponent();

            ds = new DataSetting();
            InputDefaultDataSetting();
        }

        private void InputDefaultDataSetting()
        {
            bool isDataFull = false;
            string path = Application.StartupPath + "\\datasetting.ini";

            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string line, destStr = "";
                    char[] dest = new char[20];
                    line = sr.ReadLine();

                    if (line.CompareTo("WinTacho Data Setting") == 0)
                    {
                        // 공백 Line 건너뛰기
                        line = sr.ReadLine();

                        // 최근자료보기(N)
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        ds.nRecentDataCount = Convert.ToInt32(destStr);
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 볼 때마다 갯수 입력(1: Checked, 0: Uncheck)
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        if (Convert.ToInt32(destStr) == 1)
                            ds.bInputNumberAnytime = true;
                        else
                            ds.bInputNumberAnytime = false;
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 자료 기본 보기 형태(0:최근, 1:주, 2:월, 3:분기, 4:년, 5:전체)
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        ds.nIndexOfDefaultViewItem = Convert.ToInt32(destStr);
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 교대시간 개별설정
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        if (Convert.ToInt32(destStr) == 1)
                            ds.bCheckedChangeSet = true;
                        else
                            ds.bCheckedChangeSet = false;
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 교대시간 오전
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        ds.nIndexOfChangeAMHour = Convert.ToInt32(destStr);
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 교대시간 오후
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        ds.nIndexOfChangePMHour = Convert.ToInt32(destStr);
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        isDataFull = true;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                    sw.Write("WinTacho Data Setting\r\n\r\n");
                    sw.Write("RC = 25\r\n");
                    sw.Write("CA = 0\r\n");
                    sw.Write("DV = 5\r\n");
                    sw.Write("CC = 0\r\n");
                    sw.Write("AM = 4\r\n");
                    sw.Write("PM = 4\r\n");
                }

              /*  string errpath = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(errpath, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                }*/
            }
            finally
            {
                if (!isDataFull)
                {
                    ds.nRecentDataCount = 25;
                    ds.bInputNumberAnytime = false;
                    ds.nIndexOfDefaultViewItem = 5;
                    ds.bCheckedChangeSet = false;
                    ds.nIndexOfChangeAMHour = 4;
                    ds.nIndexOfChangePMHour = 4;
                }

                InputDefaultDataSettingToForm();
            } 
        }

        private void InputDefaultDataSettingToForm()
        {
            textBoxNcount.Text = ds.nRecentDataCount.ToString();
            checkBoxAnytime.Checked = ds.bInputNumberAnytime;
            switch (ds.nIndexOfDefaultViewItem)
            {
                case 0: radioButtonRecent.Checked = true; break;
                case 1: radioButtonWeek.Checked = true; break;
                case 2: radioButtonMonth.Checked = true; break;
                case 3: radioButtonTerm.Checked = true; break;
                case 4: radioButtonYear.Checked = true; break;
                default: radioButtonTotal.Checked = true; break;
            }
            checkBoxChangeSet.Checked = ds.bCheckedChangeSet;
            comboBoxChange1Hour.SelectedIndex = ds.nIndexOfChangeAMHour;
            comboBoxChange2Hour.SelectedIndex = ds.nIndexOfChangePMHour;
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            ds.nRecentDataCount = 25;
            ds.bInputNumberAnytime = false;
            ds.nIndexOfDefaultViewItem = 5;
            ds.bCheckedChangeSet = false;
            ds.nIndexOfChangeAMHour = 4;
            ds.nIndexOfChangePMHour = 4;

            InputDefaultDataSettingToForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\datasetting.ini";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.Write("WinTacho Data Setting\r\n\r\n");
                sw.Write("RC = {0}\r\n", textBoxNcount.Text);
                sw.Write("CA = {0}\r\n", checkBoxAnytime.Checked ? "1" : "0");
                if(radioButtonRecent.Checked)
                    sw.Write("DY = 0\r\n");
                else if(radioButtonWeek.Checked)
                    sw.Write("DY = 1\r\n");
                else if(radioButtonMonth.Checked)
                    sw.Write("DY = 2\r\n");
                else if(radioButtonTerm.Checked)
                    sw.Write("DY = 3\r\n");
                else if(radioButtonYear.Checked)
                    sw.Write("DY = 4\r\n");
                else
                    sw.Write("DY = 5\r\n");
                sw.Write("CC = {0}\r\n", checkBoxChangeSet.Checked ? "1" : "0");
                sw.Write("AM = {0}\r\n", comboBoxChange1Hour.SelectedIndex.ToString());
                sw.Write("PM = {0}\r\n", comboBoxChange2Hour.SelectedIndex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxChangeSet_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxChangeSet.Checked)
            {
                comboBoxChange2Hour.Enabled = false;
                comboBoxChange2Hour.SelectedIndex = comboBoxChange1Hour.SelectedIndex;
            }
            else
            {
                comboBoxChange2Hour.Enabled = true;
            }
        }

        private void comboBoxChange1Hour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBoxChangeSet.Checked)
            {
                comboBoxChange2Hour.SelectedIndex = comboBoxChange1Hour.SelectedIndex;
            }
        }
    }
}