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

            // FormData Class�� ������ �ޱ�
			
            fd = ptFd;
			
            // ������ȣ ä���
            foreach (string cbc in fd.comboBox������ȣ.Items)
                checkedListBoxCar.Items.Add(cbc);
            fd.nlCarSel = new List<int>();

           //����ȣ ä���
            foreach (string cbd in fd.comboBox����ȣ.Items)
                checkedListBoxDriver.Items.Add(cbd);
            fd.nlDrvSel = new List<int>();

            // �Ⱓ �˻� ä���
            comboBox�˻�������AMPM.SelectedIndex = 0;
            comboBox�˻����۽�.SelectedIndex = 0;

            comboBox�˻�������AMPM.SelectedIndex = 0;
            comboBox�˻������.SelectedIndex = 0;

			if (fd.Dayseach_tacho == true)
			{
				radioButton_Ÿ��.Checked = true;
			}
			else if (fd.Dayseach_tachoday == true)
			{
				radioButton_�Ϻ�.Checked = true;
			}
			else if (fd.Dayseach_tacho2day == true)
			{
				radioButton_����и�.Checked = true;
			}
			else if (fd.Dayseach_tachoauto == true)
			{
				radioButton_�ڵ��и�.Checked = true;
			}

			 
        }

        private void checkBox��������_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��������.Checked)
            {
                checkBox��ü����.Enabled = true;
                checkedListBoxCar.Enabled = true;
            }
            else
            {
                checkBox��ü����.Enabled = false;
                checkedListBoxCar.Enabled = false;
            }
        }

        private void checkBox��ü����_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��ü����.Checked)
                checkedListBoxCar.Enabled = false;
            else
                checkedListBoxCar.Enabled = true;
        }

        private void checkedListBoxCar_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxCar.CheckedItems.Count == 1)
                e.NewValue = CheckState.Checked;
        }

        private void checkBox��籸��_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��籸��.Checked)
            {
                checkBox��ü���.Enabled = true;
                checkedListBoxDriver.Enabled = true;
            }
            else
            {
                checkBox��ü���.Enabled = false;
                checkedListBoxDriver.Enabled = false;
            }
        }

        private void checkBox��ü���_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��ü���.Checked)
                checkedListBoxDriver.Enabled = false;
            else
                checkedListBoxDriver.Enabled = true;
        }

        private void checkedListBoxDriver_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxDriver.CheckedItems.Count == 1)
                e.NewValue = CheckState.Checked;
        }

        private void checkBox����_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox����.Checked)
            {
                textBox����.Enabled = true;
                radioButton�����̻�.Enabled = true;
                radioButton��������.Enabled = true;
            }
            else
            {
                textBox����.Enabled = false;
                radioButton�����̻�.Enabled = false;
                radioButton��������.Enabled = false;
            }
        }

        private void checkBox�����_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox�����.Checked)
                dateTimePicker�����.Enabled = true;
            else
                dateTimePicker�����.Enabled = false;
        }

        private void checkBox�԰���_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox�԰���.Checked)
                dateTimePicker�԰���.Enabled = true;
            else
                dateTimePicker�԰���.Enabled = false;
        }

        private void checkBox�Ⱓ�˻�_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox�Ⱓ�˻�.Checked)
            {
                dateTimePicker�˻�������.Enabled = true;
                comboBox�˻�������AMPM.Enabled = true;
                comboBox�˻����۽�.Enabled = true;

                dateTimePicker�˻�������.Enabled = true;
                comboBox�˻�������AMPM.Enabled = true;
                comboBox�˻������.Enabled = true;

                comboBox�˻�������AMPM.SelectedIndex = 0;
                comboBox�˻����۽�.SelectedIndex = 0;

                comboBox�˻�������AMPM.SelectedIndex = 0;
                comboBox�˻������.SelectedIndex = 0;
				fd.MonthSeach = true;

			
            }
            else
            {
                dateTimePicker�˻�������.Enabled = false;
                comboBox�˻�������AMPM.Enabled = false;
                comboBox�˻����۽�.Enabled = false;

                dateTimePicker�˻�������.Enabled = false;
                comboBox�˻�������AMPM.Enabled = false;
                comboBox�˻������.Enabled = false;
				
            }
        }

        private void checkBox����⺻_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox����⺻.Checked)
            {
                textBox����⺻.Enabled = true;
                radioButton����⺻�̻�.Enabled = true;
                radioButton����⺻����.Enabled = true;
            }
            else
            {
                textBox����⺻.Enabled = false;
                radioButton����⺻�̻�.Enabled = false;
                radioButton����⺻����.Enabled = false;
            }
        }

        private void checkBox��������_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��������.Checked)
            {
                textBox��������.Enabled = true;
                radioButton���������̻�.Enabled = true;
                radioButton������������.Enabled = true;
            }
            else
            {
                textBox��������.Enabled = false;
                radioButton���������̻�.Enabled = false;
                radioButton������������.Enabled = false;
            }
        }

        private void checkBox�����⺻_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox�����⺻.Checked)
            {
                textBox�����⺻.Enabled = true;
                radioButton�����⺻�̻�.Enabled = true;
                radioButton�����⺻����.Enabled = true;
            }
            else
            {
                textBox�����⺻.Enabled = false;
                radioButton�����⺻�̻�.Enabled = false;
                radioButton�����⺻����.Enabled = false;
            }
        }

        private void checkBox��������_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox��������.Checked)
            {
                textBox��������.Enabled = true;
                radioButton���������̻�.Enabled = true;
                radioButton������������.Enabled = true;
            }
            else
            {
                textBox��������.Enabled = false;
                radioButton���������̻�.Enabled = false;
                radioButton������������.Enabled = false;
            }
        }

        private void checkBox�����_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox�����.Checked)
            {
                dateTimePicker�����.Enabled = true;
            }
            else
            {
                dateTimePicker�����.Enabled = false;
            }
        }

        private void checkBox�԰���_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox�԰���.Checked)
            {
                dateTimePicker�԰���.Enabled = true;
            }
            else
            {
                dateTimePicker�԰���.Enabled = false;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
			
            #region ����
            {

                if (checkBox����.Checked)
                {
                    fd.bCompareMoneySel = true;

                    try
                    {
                        fd.nCompareMoney = Convert.ToInt32(textBox����.Text);
                    }
                    catch
                    {
                        MessageBox.Show("�ݾ��� �ٽ� �Է��� �ּ���.", "����");
                        textBox����.Focus();
                        return;
                    }

                    if (radioButton�����̻�.Checked)
                        fd.bCompareMoneyUpper = true;
                    else
                        fd.bCompareMoneyUpper = false;
                }
                else
                {
                    fd.bCompareMoneySel = false;
                }
            }
            #endregion // ����
			string str;
            #region ���� ����
            {
                if (checkBox��������.Checked)
                {
                    fd.bCarSel = true;
					/////
					fd.radioButton����������.Checked = true; // 11.06.20
					if (fd.radioButton����������.Checked)
					{
					//	fd.comboBox����ȣ.Enabled = false;
						fd.comboBox������ȣ.Enabled = true;
					//	fd.dateTimePicker����Ϻ�����.Enabled = false;
					//	fd.dateTimePicker�԰��Ϻ�����.Enabled = false;
																					
					}
					else
					{
						fd.comboBox������ȣ.Enabled = false;
					}
					///////
                    if (checkBox��ü����.Checked)
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
							if (!fd.comboBox������ȣ.Items.Contains(str))
							fd.comboBox������ȣ.Items.Add(str);

							fd.comboBox������ȣ.SelectedIndex = fd.comboBox������ȣ.Items.IndexOf(str);
							
							
							}
							
                        }
					
                    }
                    else
                    {
                        MessageBox.Show("��� �ϳ� �̻��� ������ ������ �ּ���.", "����");
                        return;
                    }
                }
                else
                {
                    fd.bCarSel = false;
                }
            }
            #endregion // ���� ����

            #region ��� ����
            {
                if (checkBox��籸��.Checked)
                {
                    fd.bDrvSel = true;

                    if (checkBox��ü���.Checked)
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
                        MessageBox.Show("��� �Ѻ� �̻��� ������ ������ �ּ���.", "����");
                        return;
                    }
                }
                else
                {
                    fd.bDrvSel = false;
                }
            }
            #endregion // ��� ����

            #region �����
            {
                if (checkBox�����.Checked)
                {
                    fd.bOutDaySel = true;
                    fd.dtOutDay = dateTimePicker�����.Value;
                }
                else
                {
                    fd.bOutDaySel = false;
                }
            }
            #endregion // �����

            #region �԰���
            {
                if (checkBox�԰���.Checked)
                {
                    fd.bInDaySel = true;
                    fd.dtInDay = dateTimePicker�԰���.Value;
                }
                else
                {
                    fd.bInDaySel = false;
                }
            }
            #endregion // �԰���

            #region ����
            {
                if (checkBox����.Checked)
                    fd.bOverDriveSel = true;
                else
                    fd.bOverDriveSel = false;
            }
            #endregion // ����

            #region ������
            {
                if (checkBox������.Checked)
                    fd.bEmerBreakSel = true;
                else
                    fd.bEmerBreakSel = false;
            }
            #endregion // ������

            #region ���� �⺻
            {
                if (checkBox����⺻.Checked)
                {
                    fd.bDriveBasicSel = true;

                    try
                    {
                        fd.nDriveBasic = Convert.ToInt32(textBox����⺻.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[���� �⺻] ���� �ٽ� �Է��� �ּ���.", "����");
                        textBox����⺻.Focus();
                        return;
                    }

                    if (radioButton����⺻�̻�.Checked)
                        fd.bDriveBasicUpper = true;
                    else
                        fd.bDriveBasicUpper = false;
                }
                else
                {
                    fd.bDriveBasicSel = false;
                }
            }
            #endregion //���� �⺻

            #region ���� ����
            {
                if (checkBox��������.Checked)
                {
                    fd.bDriveAfterSel = true;

                    try
                    {
                        fd.nDriveAfter = Convert.ToInt32(textBox��������.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[���� ����] ���� �ٽ� �Է��� �ּ���.", "����");
                        textBox��������.Focus();
                        return;
                    }

                    if (radioButton���������̻�.Checked)
                        fd.bDriveAfterUpper = true;
                    else
                        fd.bDriveAfterUpper = false;
                }
                else
                {
                    fd.bDriveAfterSel = false;
                }
            }
            #endregion //���� ����

            #region ���� �⺻
            {
                if (checkBox�����⺻.Checked)
                {
                    fd.bAddBasicSel = true;

                    try
                    {
                        fd.nAddBasic = Convert.ToInt32(textBox�����⺻.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[���� �⺻] ���� �ٽ� �Է��� �ּ���.", "����");
                        textBox�����⺻.Focus();
                        return;
                    }

                    if (radioButton�����⺻�̻�.Checked)
                        fd.bAddBasicUpper = true;
                    else
                        fd.bAddBasicUpper = false;
                }
                else
                {
                    fd.bAddBasicSel = false;
                }
            }
            #endregion //���� �⺻

            #region ���� ����
            {
                if (checkBox��������.Checked)
                {
                    fd.bAddAfterSel = true;

                    try
                    {
                        fd.nAddAfter = Convert.ToInt32(textBox��������.Text);
                    }
                    catch
                    {
                        MessageBox.Show("[���� ����] ���� �ٽ� �Է��� �ּ���.", "����");
                        textBox��������.Focus();
                        return;
                    }

                    if (radioButton���������̻�.Checked)
                        fd.bAddAfterUpper = true;
                    else
                        fd.bAddAfterUpper = false;
                }
                else
                {
                    fd.bAddAfterSel = false;
                }
            }
            #endregion //���� ����

            #region �Ⱓ �˻�
            {
                if (checkBox�Ⱓ�˻�.Checked)
                {
                    fd.bSearchStartSel = true;
                    fd.dtSearchStartDay = dateTimePicker�˻�������.Value;
                    fd.bSearchStartAM = (comboBox�˻�������AMPM.SelectedIndex == 0) ? true : false;
                    fd.nSearchStartHour = comboBox�˻����۽�.SelectedIndex;

                    fd.bSearchEndSel = true;
                    fd.dtSearchEndDay = dateTimePicker�˻�������.Value;
                    fd.bSearchEndAM = (comboBox�˻�������AMPM.SelectedIndex == 0) ? true : false;
                    fd.nSearchEndHour = comboBox�˻������.SelectedIndex;



					if (radioButton_Ÿ��.Checked)
					{
						fd.Dayseach_tacho = true;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = false;
					}
					else if (radioButton_�Ϻ�.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = true;
					}
					else if (radioButton_����и�.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = true;
						fd.Dayseach_tachoauto = false;
						fd.Dayseach_tachoday = false;
					}
					else if (radioButton_�ڵ��и�.Checked)
					{
						fd.Dayseach_tacho = false;
						fd.Dayseach_tacho2day = false;
						fd.Dayseach_tachoauto = true;
						fd.Dayseach_tachoday = false;
					}
					else
					{
						MessageBox.Show("Ÿ�� ������ ���� �Ͽ� �ּ���!");
						return;
					}
                }
                else
                {
                    fd.bSearchStartSel = false;
                    fd.bSearchEndSel = false;
                }

				
            }
            #endregion // �Ⱓ �˻�


			if (checkBox�Ⱓ�˻�.Checked == false)
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

        private void tabControl��¥_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl��¥.SelectedIndex == 0)
            {
                checkBox�Ⱓ�˻�.Checked = false;
            }
            else if (tabControl��¥.SelectedIndex == 1)
            {
                checkBox�����.Checked = false;
                checkBox�԰���.Checked = false;
            }
        }

        private void comboBox�˻�������AMPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox�˻�������AMPM.SelectedIndex == 0)
            {
                int nTmp = comboBox�˻����۽�.SelectedIndex;
                comboBox�˻����۽�.Items.RemoveAt(0);
                comboBox�˻����۽�.Items.Insert(0, "0��");
                comboBox�˻����۽�.SelectedIndex = nTmp;
            }
            else if (comboBox�˻�������AMPM.SelectedIndex == 1)
            {
                int nTmp = comboBox�˻����۽�.SelectedIndex;
                comboBox�˻����۽�.Items.RemoveAt(0);
                comboBox�˻����۽�.Items.Insert(0, "12��");
                comboBox�˻����۽�.SelectedIndex = nTmp;
            }
        }

        private void comboBox�˻�������AMPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox�˻�������AMPM.SelectedIndex == 0)
            {
                int nTmp = comboBox�˻������.SelectedIndex;
                comboBox�˻������.Items.RemoveAt(0);
                comboBox�˻������.Items.Insert(0, "0��");
                comboBox�˻������.SelectedIndex = nTmp;
            }
            else if (comboBox�˻�������AMPM.SelectedIndex == 1)
            {
                int nTmp = comboBox�˻������.SelectedIndex;
                comboBox�˻������.Items.RemoveAt(0);
                comboBox�˻������.Items.Insert(0, "12��");
                comboBox�˻������.SelectedIndex = nTmp;
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

			fd.comboBox������ȣ.Items.Clear();

			for (int j = 0; j < fd.listView1.Items.Count - 2; j++)
			{
				string cbc = fd.listView1.Items[j].SubItems[1].Text;   // listview Id -> string

				if(!fd.comboBox������ȣ.Items.Contains(cbc))
				fd.comboBox������ȣ.Items.Add(cbc);

				if(!checkedListBoxCar.Items.Contains(cbc))
				checkedListBoxCar.Items.Add(cbc);
			}
			
		   fd.nlCarSel = new List<int>();


		 
		   

		
			
		}
    }
}