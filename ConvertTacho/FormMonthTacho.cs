using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertTacho
{
    public partial class FormMonthTacho : Form
    {
        FormData formData;
        FormCarTotal formCarTotal;
        public FormMonthTacho(FormData f)
        {
            InitializeComponent();
            formData = f;

            
          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yymm = 0;
            DateTime SearchDate = dateTimePicker1.Value;

            yymm = ((SearchDate.Year - 2000) * 100) + SearchDate.Month;


            if (textBox1.Text.Length != 7)
            {
                MessageBox.Show("차 번호가 잘못되었습니다. 다시 입력하여주세요!");
            }
            string Car_Num = textBox1.Text;

            formCarTotal = new FormCarTotal(formData);
            formCarTotal.MdiParent = this.ParentForm;
            formCarTotal.BringToFront();
            formCarTotal.Show();
            formCarTotal.FillMonth(Car_Num, SearchDate);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}