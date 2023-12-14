using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertTacho
{
    public partial class UserTimeForm : Form
    {
        Form1 form1;
        public UserTimeForm(Form1 f)
        {
            InitializeComponent();

            form1 = f;              
            radioButton_OneDay.Checked = true;
            numericUpDown_Year.Value = DateTime.Now.Year;
            numericUpDown_Month.Value = DateTime.Now.Month;
            numericUpDown_Day.Value = DateTime.Now.Day;
        }

        private void button수신시작_Click(object sender, EventArgs e)
        {
            form1.User_Year = (int)numericUpDown_Year.Value;
            form1.User_Month = (int)numericUpDown_Month.Value;
            form1.User_Day = (int)numericUpDown_Day.Value;

            if (radioButton_AM.Checked)
            {
                form1.UserAM = true;
            }
            else
            {
                form1.UserAM = false;
            }

            if (radioButton_PM.Checked)
            {
                form1.UserPM = true;
            }
            else
            {
                form1.UserPM = false;
            }

            this.Close();
        }

        private void UserTimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.User_Year = (int)numericUpDown_Year.Value;
            form1.User_Month = (int)numericUpDown_Month.Value;
            form1.User_Day = (int)numericUpDown_Day.Value;

            if (radioButton_AM.Checked)
            {
                form1.UserAM = true;
            }
            else
            {
                form1.UserAM = false;
            }

            if (radioButton_PM.Checked)
            {
                form1.UserPM = true;
            }
            else
            {
                form1.UserPM = false;
            }

        }
    }
}