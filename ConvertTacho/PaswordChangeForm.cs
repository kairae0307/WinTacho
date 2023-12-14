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
	public partial class PaswordChangeForm : Form
	{
		FormPassword formPassword;
		public string NewPassword;
		public PaswordChangeForm(FormPassword f)
		{
			formPassword = f;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox1.Text ==textBox2.Text)
			{

				NewPassword = textBox1.Text;
				char[] pw = new char[4];
				byte[] temp = new byte[4] ;
				int [] num = new int[4];
				for (int i = 0; i<NewPassword.Length; i++)
				{
					pw[i] = NewPassword[i];
					temp[i] = (byte)pw[i];
					num[i] = (int)temp[i]-18;

				}

			

				string path = Application.StartupPath + "\\datasetting.ini";
				using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
				{
					sw.Write("WinTacho Data Setting\r\n\r\n");
					sw.Write("RC = 100000\r\n");
					sw.Write("CA = 0\r\n");
					sw.Write("DY = 5\r\n");
					sw.Write("CC = 1\r\n");
					sw.Write("AM = 11\r\n");
					sw.Write("PM = 11\r\n");
					sw.Write(num[0].ToString() + "\r\n");
					sw.Write(num[1].ToString() + "\r\n");
					sw.Write(num[2].ToString() + "\r\n");
					sw.Write(num[3].ToString() + "\r\n");
					
				}
				MessageBox.Show("비밀번호가 변경 되었습니다.");
				this.Close();
				formPassword.Close();			


			}
			else
			{
				MessageBox.Show("새로운 비밀번호를 다시 입력하여 주세요");
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
			{
				char cKey = e.KeyChar;
				cKey = char.ToUpper(cKey);
				e.Handled = true;
			}

			else
			{
				e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
			{
				char cKey = e.KeyChar;
				cKey = char.ToUpper(cKey);
				e.Handled = true;
			}

			else
			{
				e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}
	}
}