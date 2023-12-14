using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertTacho
{
    public partial class FormInputDBCount : Form
    {
        FormData fd;

        public FormInputDBCount(FormData formData)
        {
            InitializeComponent();

            fd = formData;
            fd.nUserRecentDataCount = -1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label2.Text = "";

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {
                ExcuteInputData();
            }
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ExcuteInputData();
        }

        private void ExcuteInputData()
        {
            try
            {
                fd.nUserRecentDataCount = Convert.ToInt32(textBox1.Text);
                this.Close();
            }
            catch
            {
                label2.Text = "값을 다시 입력해 주세요";
                textBox1.Focus();
            }
        }

        private void buttonOK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}