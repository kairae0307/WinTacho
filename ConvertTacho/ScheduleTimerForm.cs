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
using System.Net;

namespace ConvertTacho
{
	public partial class ScheduleTimerForm : Form
	{
		Form1 form1;
		public bool ParsingUse = false;
		public int P_use = 0;
		public ScheduleTimerForm(Form1 f)
		{
			form1 = f;
			InitializeComponent();
			radioButton_notuse.Checked = true;
			 string path = Application.StartupPath + "\\serialsetting.ini";

			 try
			 {
				 using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
				 {
					 string line, destStr = "";
					 char[] dest = new char[20];
					 line = sr.ReadLine();

					 if (line.CompareTo("WinTacho Serial Setting") == 0)
					 {
						 // ���� Line �ǳʶٱ�
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();

						 // Hour
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numHour.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';


						 // Minute
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numMin.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';


						 // Sec
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numSec.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';

						

						 /////////////////////////////////////////////]
						 // Hour
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numHour1.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';


						 // Minute
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numMin1.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';


						 // Sec
						 line = sr.ReadLine();
						 line.CopyTo(5, dest, 0, (line.Length - 5));

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
						 numSec1.Value = Convert.ToInt32(destStr);
						 destStr = "";
						 for (int j = 0; j < 20; j++) dest[j] = '\0';
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						 line = sr.ReadLine();
						  line = sr.ReadLine();



						 line.CopyTo(18, dest, 0, (line.Length - 18));   // �ǵ��� �ڵ����� ����

						 for (int i = 0; i < 20; i++)
						 {
							 if (dest[i] == '\0')
								 break;
							 destStr += dest[i];
						 }
							P_use =  Convert.ToInt32(destStr);
						 for (int j = 0; j < 20; j++) dest[j] = '\0';
					 }
				 }
			 }
			catch
			 {

			 }

			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//ScheduledTimer st = new ScheduledTimer();
			//st.SetTime(GetTimeSpan(), ExecMethod); // SetTime(����ð�, ����޼ҵ�)
		/*	int num = 0;
			
			if (radioButton_use.Checked == true)
			{
				num = 1;
			}
			else if (radioButton_notuse.Checked == true)
			{
				num = 0;
			}
			
			
			string path = Application.StartupPath + "\\serialsetting.ini";
			using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
			{
				sw.Write("WinTacho Serial Setting\r\n\r\n");
				sw.Write("SP = COM1\r\n");
				sw.Write("BS = 38400\r\n");
				sw.Write("DB = 8\r\n");
				sw.Write("PA = ����\r\n");
				sw.Write("SB = 1\r\n");
				sw.Write("FC = ����\r\n");			
				sw.Write("h1 = {0}\r\n", numHour.Value.ToString());			// 
				sw.Write("m1 = {0}\r\n", numMin.Value.ToString());	// 
				sw.Write("s1 = {0}\r\n", numSec.Value.ToString());			// 
				sw.Write("h2 = {0}\r\n", numHour1.Value.ToString());			// ���� �⺻ ���
				sw.Write("m2 = {0}\r\n", numMin1.Value.ToString());	// ���� �⺻ �Ÿ�
				sw.Write("s2 = {0}\r\n", numSec1.Value.ToString());
				sw.Write("0\r\n");
				sw.Write("1\r\n");
				sw.Write("2\r\n");
				sw.Write("3\r\n");
				sw.Write("PS = {0}\r\n", num.ToString());  //; Ÿ�� �Ľ� ����
				sw.Write("classic-pro_Use = {0}\r\n", P_use.ToString()); 
			}
			MessageBox.Show("�ǵ��� ���� ���� �ð��� ���� �Ǿ����ϴ�.!!\r\n�ǵ��� ����â�� ������ �ٽ� ���� �Ͽ� �ּ���!!\n");
		*/

		}
		private TimeSpan GetTimeSpan()
		{
			return new TimeSpan((int)numHour.Value, (int)numMin.Value, (int)numSec.Value);
		}

		private void ExecMethod()
		{
			MessageBox.Show(DateTime.Now.ToLongTimeString());
		}
	}
}