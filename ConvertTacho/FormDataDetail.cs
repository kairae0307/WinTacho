using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertTacho
{
    public partial class FormDataDetail : Form
    {
        FormData fd;
		
		FormDayInfo formDayInfo;
		FormDayInfoCal formDayInfoCal;
        public FormDataDetail(FormData ptFd)
        {
            InitializeComponent();

            // FormData Class의 포인터 받기
			
            fd = ptFd;
			
            // 차량번호 채우기
            foreach (string cbc in fd.comboBox차량번호.Items)
                checkedListBoxCar.Items.Add(cbc);
            fd.nlCarSel = new List<int>();

           //기사번호 채우기
            foreach (string cbd in fd.comboBox기사번호.Items)
                checkedListBoxDriver.Items.Add(cbd);
            fd.nlDrvSel = new List<int>();

            // 기간 검색 채우기
            comboBox검색시작일AMPM.SelectedIndex = 0;
            comboBox검색시작시.SelectedIndex = 0;

            comboBox검색종료일AMPM.SelectedIndex = 0;
            comboBox검색종료시.SelectedIndex = 0;

			if (fd.Dayseach_tacho == true)
			{
				radioButton_타코.Checked = true;
			}
			else if (fd.Dayseach_tachoday == true)
			{
				radioButton_일별.Checked = true;
			}
			else if (fd.Dayseach_tacho2day == true)
			{
				radioButton_교대분리.Checked = true;
			}
			else if (fd.Dayseach_tachoauto == true)
			{
				radioButton_자동분리.Checked = true;
			}

			 
        }

        private void checkBox차량구분_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox차량구분.Checked)
            {
                checkBox전체차량.Enabled = true;
                checkedListBoxCar.Enabled = true;
            }
            else
            {
                checkBox전체차량.Enabled = false;
                checkedListBoxCar.Enabled = false;
            }
        }

        private void checkBox전체차량_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox전체차량.Checked)
                checkedListBoxCar.Enabled = false;
            else
                checkedListBoxCar.Enabled = true;
        }

        private void checkedListBoxCar_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxCar.CheckedItems.Count == 1)
                e.NewValue = CheckState.Checked;
        }

        private void checkBox기사구분_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox기사구분.Checked)
            {
                checkBox전체기사.Enabled = true;
                checkedListBoxDriver.Enabled = true;
            }
            else
            {
                checkBox전체기사.Enabled = false;
                checkedListBoxDriver.Enabled = false;
            }
        }

        private void checkBox전체기사_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox전체기사.Checked)
                checkedListBoxDriver.Enabled = false;
            else
                checkedListBoxDriver.Enabled = true;
        }

        private void checkedListBoxDriver_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxDriver.CheckedItems.Count == 1)
                e.NewValue = CheckState.Checked;
        }

        private void checkBox수입_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox수입.Checked)
            {
                textBox수입.Enabled = true;
                radioButton수입이상.Enabled = true;
                radioButton수입이하.Enabled = true;
            }
            else
            {
                textBox수입.Enabled = false;
                radioButton수입이상.Enabled = false;
                radioButton수입이하.Enabled = false;
            }
        }

        private void checkBox출고일_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox출고일.Checked)
                dateTimePicker출고일.Enabled = true;
            else
                dateTimePicker출고일.Enabled = false;
        }

        private void checkBox입고일_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox입고일.Checked)
                dateTimePicker입고일.Enabled = true;
            else
                dateTimePicker입고일.Enabled = false;
        }

        private void checkBox기간검색_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox기간검색.Checked)
            {
                dateTimePicker검색시작일.Enabled = true;
                comboBox검색시작일AMPM.Enabled = true;
                comboBox검색시작시.Enabled = true;

                dateTimePicker검색종료일.Enabled = true;
                comboBox검색종료일AMPM.Enabled = true;
                comboBox검색종료시.Enabled = true;

                comboBox검색시작일AMPM.SelectedIndex = 0;
                comboBox검색시작시.SelectedIndex = 0;

                comboBox검색종료일AMPM.SelectedIndex = 0;
                comboBox검색종료시.SelectedIndex = 0;
				fd.MonthSeach = true;

			
            }
            else
            {
                dateTimePicker검색시작일.Enabled = false;
                comboBox검색시작일AMPM.Enabled = false;
                comboBox검색시작시.Enabled = false;

                dateTimePicker검색종료일.Enabled = false;
                comboBox검색종료일AMPM.Enabled = false;
                comboBox검색종료시.Enabled = false;
				
            }
        }

        private void checkBox주행기본_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox주행기본.Checked)
            {
                textBox주행기본.Enabled = true;
                radioButton주행기본이상.Enabled = true;
                radioButton주행기본이하.Enabled = true;
            }
            else
            {
                textBox주행기본.Enabled = false;
                radioButton주행기본이상.Enabled = false;
                radioButton주행기본이하.Enabled = false;
            }
        }

        private void checkBox주행이후_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox주행이후.Checked)
            {
                textBox주행이후.Enabled = true;
                radioButton주행이후이상.Enabled = true;
                radioButton주행이후이하.Enabled = true;
            }
            else
            {
                textBox주행이후.Enabled = false;
                radioButton주행이후이상.Enabled = false;
                radioButton주행이후이하.Enabled = false;
            }
        }

        private void checkBox할증기본_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox할증기본.Checked)
            {
                textBox할증기본.Enabled = true;
                radioButton할증기본이상.Enabled = true;
                radioButton할증기본이하.Enabled = true;
            }
            else
            {
                textBox할증기본.Enabled = false;
                radioButton할증기본이상.Enabled = false;
                radioButton할증기본이하.Enabled = false;
            }
        }

        private void checkBox할증이후_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox할증이후.Checked)
            {
                textBox할증이후.Enabled = true;
                radioButton할증이후이상.Enabled = true;
                radioButton할증이후이하.Enabled = true;
            }
            else
            {
                textBox할증이후.Enabled = false;
                radioButton할증이후이상.Enabled = false;
                radioButton할증이후이하.Enabled = false;
            }
        }

        private void checkBox출고일_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox출고일.Checked)
            {
                dateTimePicker출고일.Enabled = true;
            }
            else
            {
                dateTimePicker출고일.Enabled = false;
            }
        }

        private void checkBox입고일_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox입고일.Checked)
            {
                dateTimePicker입고일.Enabled = true;
            }
            else
            {
                dateTimePicker입고일.Enabled = false;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
			
            #region 수입
            {

                if (checkBox수입.Checked)
                {
                    fd.bCompareMoneySel = true;

                    try
                    {
                        fd.nCompareMoney = Convert.ToInt32(textBox수입.Text);
                    }
                    catch
                    {
                        MessageBox.Show("금액을 다시 입력해 주세요.", "오류");
                        textBox수입.Focus();
                        return;
                    }

                    if (radioButton수입이상.Checked)
                        fd.bCompareMoneyUpper = true;
                    else
                        fd.bCompareMoneyUpper = false;
                }
                else
                {
                    fd.bCompareMoneySel = false;
                }
            }
            #endregion // 수입
			string str;
            #region 차량 구분
            {
                if (checkBox차량구분.Checked)
                {
                    fd.bCarSel = true;
					/////
					fd.radioButton차량별보기.Checked = true; // 11.06.20
					if (fd.radioButton차량별보기.Checked)
					{
					//	fd.comboBox기사번호.Enabled = false;
						fd.comboBox차량번호.Enabled = true;
					//	fd.dateTimePicker출고일별보기.Enabled = false;
					//	fd.dateTimePicker입고일별보기.Enabled = false;
																					
					}
					else
					{
						fd.comboBox차량번호.Enabled = false;
					}
					///////
                    if (checkBox전체차량.Checked)
                    {
                        fd.bCarTotalSel = true;
                    }
                    else if (checkedListBoxCar.CheckedItems.Count > 0)
                    {

					
                        fd.bCarTotalSel = false;

                        if (fd.nlCarSel.Count > 0)
                            fd.nlCarSel.Clear();

						
					
                        for (int i = 0; i < checkedListBoxCar.Items.Count; i++)
                        {

						
							if (checkedListBoxCar.GetItemChecked(i))
							{
								
								fd.nlCarSel.Add(i);

							str =	checkedListBoxCar.Text;
							if (!fd.comboBox차량번호.Items.Contains(str))
							fd.comboBox차량번호.Items.Add(str);

							fd.comboBox차량번호.SelectedIndex = fd.comboBox차량번호.Items.IndexOf(str);
							
							
							}
							
                        }
					
                    }
                    else
                    {
                        MessageBox.Show("적어도 하나 이상의 차량을 선택해 주세요.", "오류");
                        return;
                    }
                }
                else
                {
                    fd.bCarSel = false;
                }
            }
            #endregion // 차량 구분

            #region 기사 구분
            {
                if (checkBox기사구분.Checked)
                {
                    fd.bDrvSel = true;

                    if (checkBox전체기사.Checked)
                    {
                        fd.bDrvTotalSel = true;
                    }
                    else if (checkedListBoxDriver.CheckedItems.Count > 0)
                    {
                        fd.bDrvTotalSel = false;

                        if (fd.nlDrvSel.Count > 0)
                            fd.nlDrvSel.Clear();

                        for (int i = 0; i < checkedListBoxDriver.Items.Count; i++)
                        {
                            if (checkedListBoxDriver.GetItemChecked(i))
                                fd.nlDrvSel.Add(i);
                        }
                    }
                    else
                    {
                        MessageBox.Show("적어도 한분 이상의 기사님을 선택해 주세요.", "오류");
                        return;
                    }
                }
                else
                {
                    fd.bDrvSel = false;
                }
            }
            #endregion // 기사 구분

            #region 출고일
            {
                if (checkBox출고일.Checked)
                {
                    fd.bOutDaySel = true;
                    fd.dtOutDay = dateTimePicker출고일.Value;
                }
                else
                {
                    fd.bOutDaySel = false;
                }
            }
            #endregion // 출고일

            #region 입고일
            {
                if (checkBox입고일.Checked)
                {
                    fd.bInDaySel = true;
                    fd.dtInDay = dateTimePicker입고일.Value;
                }
                else
                {
                    fd.bInDaySel = false;
                }
            }
            #endregion // 입고일

            #region 과속
            {
                if (checkBox과속.Checked)
                    fd.bOverDriveSel = true;
                else
                    fd.bOverDriveSel = false;
            }
            #endregion // 과속

            #region 급제동
            {
                if (checkBox급제동.Checked)
                    fd.bEmerBreakSel = true;
                else
                    fd.bEmerBreakSel = false;
            }
            #endregion // 급제동

            #region 주행 기본
            {
                if (checkBox주행기본.Checked)
                {
                    fd.bDriveBasicSel = true;

                    try
                    {
                        fd.nDriveBasic = Convert.ToInt32(textBox주행기본.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[주행 기본] 값을 다시 입력해 주세요.", "오류");
                        textBox주행기본.Focus();
                        return;
                    }

                    if (radioButton주행기본이상.Checked)
                        fd.bDriveBasicUpper = true;
                    else
                        fd.bDriveBasicUpper = false;
                }
                else
                {
                    fd.bDriveBasicSel = false;
                }
            }
            #endregion //주행 기본

            #region 주행 이후
            {
                if (checkBox주행이후.Checked)
                {
                    fd.bDriveAfterSel = true;

                    try
                    {
                        fd.nDriveAfter = Convert.ToInt32(textBox주행이후.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[주행 이후] 값을 다시 입력해 주세요.", "오류");
                        textBox주행이후.Focus();
                        return;
                    }

                    if (radioButton주행이후이상.Checked)
                        fd.bDriveAfterUpper = true;
                    else
                        fd.bDriveAfterUpper = false;
                }
                else
                {
                    fd.bDriveAfterSel = false;
                }
            }
            #endregion //주행 이후

            #region 할증 기본
            {
                if (checkBox할증기본.Checked)
                {
                    fd.bAddBasicSel = true;

                    try
                    {
                        fd.nAddBasic = Convert.ToInt32(textBox할증기본.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[할증 기본] 값을 다시 입력해 주세요.", "오류");
                        textBox할증기본.Focus();
                        return;
                    }

                    if (radioButton할증기본이상.Checked)
                        fd.bAddBasicUpper = true;
                    else
                        fd.bAddBasicUpper = false;
                }
                else
                {
                    fd.bAddBasicSel = false;
                }
            }
            #endregion //할증 기본

            #region 할증 이후
            {
                if (checkBox할증이후.Checked)
                {
                    fd.bAddAfterSel = true;

                    try
                    {
                        fd.nAddAfter = Convert.ToInt32(textBox할증이후.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[할증 이후] 값을 다시 입력해 주세요.", "오류");
                        textBox할증이후.Focus();
                        return;
                    }

                    if (radioButton할증이후이상.Checked)
                        fd.bAddAfterUpper = true;
                    else
                        fd.bAddAfterUpper = false;
                }
                else
                {
                    fd.bAddAfterSel = false;
                }
            }
            #endregion //할증 이후

            #region 기간 검색
            {
                if (checkBox기간검색.Checked)
                {
                    fd.bSearchStartSel = true;
                    fd.dtSearchStartDay = dateTimePicker검색시작일.Value;
                    fd.bSearchStartAM = (comboBox검색시작일AMPM.SelectedIndex == 0) ? true : false;
                    fd.nSearchStartHour = comboBox검색시작시.SelectedIndex;

                    fd.bSearchEndSel = true;
                    fd.dtSearchEndDay = dateTimePicker검색종료일.Value;
                    fd.bSearchEndAM = (comboBox검색종료일AMPM.SelectedIndex == 0) ? true : false;
                    fd.nSearchEndHour = comboBox검색종료시.SelectedIndex;



					if (radioButton_타코.Checked)
					{
						fd.Dayseach_tacho = true;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = false;
					}
					else if (radioButton_일별.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = true;
					}
					else if (radioButton_교대분리.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = true;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = false;
					}
					else if (radioButton_자동분리.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = true;
						fd.Dayseach_tachoday = false;
					}
					else
					{
						MessageBox.Show("타코 종류를 선택 하여 주세요!");
						return;
					}
                }
                else
                {
                    fd.bSearchStartSel = false;
                    fd.bSearchEndSel = false;
                }

				
            }
            #endregion // 기간 검색


			if (checkBox기간검색.Checked == false)
			{
				fd.bIsDetail = true;
				fd.FillData(fd.selectedColumnIndex, fd.selectedOrder);
			}
			else
			{
				formDayInfoCal = new FormDayInfoCal(fd);
				formDayInfoCal.MdiParent = this.ParentForm;
				formDayInfoCal.BringToFront();
				formDayInfoCal.Show();
	
			}
            //this.Close();
        }

        private void tabControl날짜_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl날짜.SelectedIndex == 0)
            {
                checkBox기간검색.Checked = false;
            }
            else if (tabControl날짜.SelectedIndex == 1)
            {
                checkBox출고일.Checked = false;
                checkBox입고일.Checked = false;
            }
        }

        private void comboBox검색시작일AMPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox검색시작일AMPM.SelectedIndex == 0)
            {
                int nTmp = comboBox검색시작시.SelectedIndex;
                comboBox검색시작시.Items.RemoveAt(0);
                comboBox검색시작시.Items.Insert(0, "0시");
                comboBox검색시작시.SelectedIndex = nTmp;
            }
            else if (comboBox검색시작일AMPM.SelectedIndex == 1)
            {
                int nTmp = comboBox검색시작시.SelectedIndex;
                comboBox검색시작시.Items.RemoveAt(0);
                comboBox검색시작시.Items.Insert(0, "12시");
                comboBox검색시작시.SelectedIndex = nTmp;
            }
        }

        private void comboBox검색종료일AMPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox검색종료일AMPM.SelectedIndex == 0)
            {
                int nTmp = comboBox검색종료시.SelectedIndex;
                comboBox검색종료시.Items.RemoveAt(0);
                comboBox검색종료시.Items.Insert(0, "0시");
                comboBox검색종료시.SelectedIndex = nTmp;
            }
            else if (comboBox검색종료일AMPM.SelectedIndex == 1)
            {
                int nTmp = comboBox검색종료시.SelectedIndex;
                comboBox검색종료시.Items.RemoveAt(0);
                comboBox검색종료시.Items.Insert(0, "12시");
                comboBox검색종료시.SelectedIndex = nTmp;
            }
        }

        private void FormDataDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  fd.bIsDetail = false;
        }

		private void button1_Click(object sender, EventArgs e)
		{


			fd.SortCheck = true;
			fd.FillData(1, 1);
			checkedListBoxCar.Items.Clear();

			fd.comboBox차량번호.Items.Clear();

			for (int j = 0; j < fd.listView1.Items.Count - 2; j++)
			{
				string cbc = fd.listView1.Items[j].SubItems[1].Text;   // listview Id -> string

				if(!fd.comboBox차량번호.Items.Contains(cbc))
				fd.comboBox차량번호.Items.Add(cbc);

				if(!checkedListBoxCar.Items.Contains(cbc))
				checkedListBoxCar.Items.Add(cbc);
			}
			
		   fd.nlCarSel = new List<int>();


		 
		   

		
			
		}
    }
}