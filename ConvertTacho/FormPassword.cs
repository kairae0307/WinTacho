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
	public partial class FormPassword : Form
	{
		Form1 form1;
		public string password;
		public FormPassword(Form1 f)
		{
			form1 = f;
			InitializeComponent();
			radioButton_use.Checked = true;
			int num = 0;
			int ec = 0;
			string path = Application.StartupPath + "\\datasetting.ini";
			using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
			{
				string line, destStr = "";
				char[] dest = new char[20];
				line = sr.ReadLine();

				if (line.CompareTo("WinTacho Data Setting") == 0)
				{
					// 공백 Line 건너뛰기
					line = sr.ReadLine();
					line = sr.ReadLine();
					line = sr.ReadLine();
					line = sr.ReadLine();
					line = sr.ReadLine();
					line = sr.ReadLine();
					line = sr.ReadLine();

					byte temp;

					line = sr.ReadLine();   // password
					temp = Convert.ToByte(line);
					temp -= 30;
					password += temp.ToString();

					line = sr.ReadLine();   // password
					temp = Convert.ToByte(line);
					temp -= 30;
					password += temp.ToString();

					line = sr.ReadLine();   // password
					temp = Convert.ToByte(line);
					temp -= 30;
					password += temp.ToString();


					line = sr.ReadLine();   // password
					temp = Convert.ToByte(line);
					temp -= 30;
					password += temp.ToString();


				// /	MessageBox.Show(password);

				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == password && textBox2.Text == password)
			{

				string formName = "FormCarDB";
				
				FormCarDB formCarDB = new FormCarDB();
				formCarDB.MdiParent = form1;
				formCarDB.Show();

				this.Close();

			}
			else
			{
				MessageBox.Show("비밀 번호가 잘못 되었습니다.!!");
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

		private void button2_Click(object sender, EventArgs e)
		{

			if (textBox1.Text == password && textBox2.Text == password)
			{

				PaswordChangeForm passwordchange = new PaswordChangeForm(this);
				passwordchange.StartPosition = FormStartPosition.CenterParent;
				passwordchange.ShowDialog();

			}
			else
			{
				MessageBox.Show("비밀 번호가 잘못 되었습니다.!!");
			}

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}