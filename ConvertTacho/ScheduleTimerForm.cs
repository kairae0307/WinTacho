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
						 // 공백 Line 건너뛰기
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



						 line.CopyTo(18, dest, 0, (line.Length - 18));   // 판독기 자동삭제 유뮤

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
			//st.SetTime(GetTimeSpan(), ExecMethod); // SetTime(예약시간, 실행메소드)
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
				sw.Write("PA = 없음\r\n");
				sw.Write("SB = 1\r\n");
				sw.Write("FC = 없음\r\n");			
				sw.Write("h1 = {0}\r\n", numHour.Value.ToString());			// 
				sw.Write("m1 = {0}\r\n", numMin.Value.ToString());	// 
				sw.Write("s1 = {0}\r\n", numSec.Value.ToString());			// 
				sw.Write("h2 = {0}\r\n", numHour1.Value.ToString());			// 주행 기본 요금
				sw.Write("m2 = {0}\r\n", numMin1.Value.ToString());	// 주행 기본 거리
				sw.Write("s2 = {0}\r\n", numSec1.Value.ToString());
				sw.Write("0\r\n");
				sw.Write("1\r\n");
				sw.Write("2\r\n");
				sw.Write("3\r\n");
				sw.Write("PS = {0}\r\n", num.ToString());  //; 타코 파싱 유무
				sw.Write("classic-pro_Use = {0}\r\n", P_use.ToString()); 
			}
			MessageBox.Show("판독기 수신 예약 시간이 설정 되었습니다.!!\r\n판독기 수신창을 닫은후 다시 실행 하여 주세요!!\n");
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