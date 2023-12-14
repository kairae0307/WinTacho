using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertTacho
{
    public partial class FormOpenMonth : Form
    {


		FormData formData;
		FormTotalRec formTotalRec;
        FormCarTotal formCarTotal;

        public FormOpenMonth(FormData f)
        {
            InitializeComponent();
			formData = f;
          //  checkBox2.Visible = false;
            if (formData.Dayseach_tacho == true)
            {
                radioButton_타코.Checked = true;
            }
            else if (formData.Dayseach_tachoday == true)
            {
                radioButton_일별.Checked = true;
            }
            else if (formData.Dayseach_tacho2day == true)
            {
                radioButton_교대분리.Checked = true;
            }
            else if (formData.Dayseach_tachoauto == true)
            {
                radioButton_자동분리.Checked = true;
            }
          //  textBox1.Enabled = false;

            if (formData.daysearchcar == false)
            {

                radioButton1.Enabled = false;
                textBox1.Enabled = false;
            }
       //     groupBox6.Enabled = false;
			
			
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TimeSpan diff = dateTimePickerEnd.Value - dateTimePickerStart.Value;
            if (formData.daysearchcar == false)
            {

               
                //  TimeSpan diff = dateTimePickerEnd.Value - dateTimePickerStart.Value;

                /*  if ((dateTimePickerStart.Value.Year == dateTimePickerEnd.Value.Year)
                      && (dateTimePickerStart.Value.Month == dateTimePickerEnd.Value.Month)
                      && (dateTimePickerStart.Value.Day == dateTimePickerEnd.Value.Day))
                      diff = dateTimePickerEnd.Value - dateTimePickerEnd.Value;

                  FormDayDirveRec formDayDirveRec = new FormDayDirveRec(formData);*/



                formData.dtSearchStartDay = dateTimePickerStart.Value;
                formData.dtSearchEndDay = dateTimePickerEnd.Value;


                if (radioButton_타코.Checked)
                {
                    formData.Dayseach_tacho = true;
                    formData.Dayseach_tacho2day = false;
                    formData.Dayseach_tachoauto = false;
                    formData.Dayseach_tachoday = false;
                }
                else if (radioButton_일별.Checked)
                {
                    formData.Dayseach_tacho = false;
                    formData.Dayseach_tacho2day = false;
                    formData.Dayseach_tachoauto = false;
                    formData.Dayseach_tachoday = true;
                }
                else if (radioButton_교대분리.Checked)
                {
                    formData.Dayseach_tacho = false;
                    formData.Dayseach_tacho2day = true;
                    formData.Dayseach_tachoauto = false;
                    formData.Dayseach_tachoday = false;
                }
                else if (radioButton_자동분리.Checked)
                {
                    formData.Dayseach_tacho = false;
                    formData.Dayseach_tacho2day = false;
                    formData.Dayseach_tachoauto = true;
                    formData.Dayseach_tachoday = false;
                }
                else
                {
                    MessageBox.Show("타코 종류를 선택 하여 주세요!");
                    return;
                }
                string Car_Num = "1111";
                formTotalRec = new FormTotalRec(formData);
                formData.TotalRec = true;
                formTotalRec.MdiParent = this.ParentForm;
                formTotalRec.BringToFront();
                formTotalRec.Show();
                // fd.bSearchStartSel = false;
                formTotalRec.FillDaySearchData(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay,0);
            }
            else
            {
                //   formData.daysearchcar = false;

                if (radioButton1.Checked == true)
                {
                    if (textBox1.Text.Length != 7)
                    {
                        MessageBox.Show("차 번호가 잘못되었습니다. 다시 입력하여주세요!");
                        return;
                    }
                    string Car_Num = textBox1.Text;
                    formData.dtSearchStartDay = dateTimePickerStart.Value;
                    formData.dtSearchEndDay = dateTimePickerEnd.Value;
                  

               //     formData.FillDays(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay); // 새로운 폼 윈도루로 대신하기 위하여 삭제 

                  

                    formTotalRec = new FormTotalRec(formData);
                    formData.TotalRec = false;
                    formTotalRec.MdiParent = this.ParentForm;
                    formTotalRec.BringToFront();
                    formTotalRec.Show();
                    // fd.bSearchStartSel = false;
                    formTotalRec.FillDaySearchData(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay,0);


                    formCarTotal = new FormCarTotal(formData);
                    formCarTotal.MdiParent = this.ParentForm;
                    formCarTotal.BringToFront();
                    formCarTotal.Show();
                    formCarTotal.FillDays(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay,0);
                }
                else if (radioButton2.Checked == true)
                {
                    formData.TotalRec_print = true;
                    formData.dtSearchStartDay = dateTimePickerStart.Value;
                    formData.dtSearchEndDay = dateTimePickerEnd.Value;

                 
                    formData.TotalSeachData(formData.dtSearchStartDay, formData.dtSearchEndDay);
                  
                    ///////////////////////////////////////////////////////  표 출력하기//////////////////////////////////////
                /*    string Car_Num = "1111";
                    formTotalRec = new FormTotalRec(formData);
                    formData.TotalRec = true;
                    formTotalRec.MdiParent = this.ParentForm;
                    formTotalRec.BringToFront();
                    formTotalRec.Show();
                    // fd.bSearchStartSel = false;
                    formTotalRec.FillDaySearchData(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay);*/
                
                }
                else if (radioButton3.Checked == true)
                {
                   /* if (textBox2.Text.Length != 4)
                    {
                        MessageBox.Show("기사 번호가 잘못되었습니다. 다시 입력하여주세요!");
                        return;
                    }*/
                    string Driver_Num = textBox2.Text;
                    formData.dtSearchStartDay = dateTimePickerStart.Value;
                    formData.dtSearchEndDay = dateTimePickerEnd.Value;


                    //     formData.FillDays(Car_Num, formData.dtSearchStartDay, formData.dtSearchEndDay); // 새로운 폼 윈도루로 대신하기 위하여 삭제 



                    formTotalRec = new FormTotalRec(formData);
                    formData.TotalRec = false;
                    formTotalRec.MdiParent = this.ParentForm;
                    formTotalRec.BringToFront();
                    formTotalRec.Show();
                    // fd.bSearchStartSel = false;
                    formTotalRec.FillDaySearchData(Driver_Num, formData.dtSearchStartDay, formData.dtSearchEndDay,1);


                    formCarTotal = new FormCarTotal(formData);
                    formCarTotal.MdiParent = this.ParentForm;
                    formCarTotal.BringToFront();
                    formCarTotal.Show();
                    formCarTotal.FillDays(Driver_Num, formData.dtSearchStartDay, formData.dtSearchEndDay,1);
                }


            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonTotal_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButtonDriver_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButtonCar_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void textBoxInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Return)))
            {
                buttonOK_Click(sender, e);
            }
        }

        private void FormOpenMonth_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

      

      
    }
}