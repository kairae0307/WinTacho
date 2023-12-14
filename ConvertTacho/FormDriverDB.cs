using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using PrintableListView;
using System.Threading;
using ListViewEx;
using System.Drawing.Printing;

namespace ConvertTacho
{
    public partial class FormDriverDB : Form
    {
        private OleDbConnection conn;
        private OleDbDataAdapter adapter;
        private OleDbCommandBuilder cmdBuilder;
        private DataSet ds;
        private DataTable dataTable;
        private OleDbCommand commOpen;
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();

        private PrintableListView.PrintableListView m_list;

        public FormDriverDB()
        {
            InitializeComponent();

            m_list = new PrintableListView.PrintableListView();

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // Ÿ�� ��Ʈ

            string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + TACHO2_path + "\\Information.mdb";
            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            conn = new OleDbConnection(@DBstring);
            conn.Open();

            ds = new DataSet();

            string queryOpen = "SELECT * FROM DriverInfo";
            commOpen = new OleDbCommand(queryOpen, conn);

            //commOpen.CommandText = queryOpen;

            adapter = new OleDbDataAdapter(commOpen);

            cmdBuilder = new OleDbCommandBuilder(adapter);

            dataTable = new DataTable();
            ///
            dataTable.TableNewRow += new DataTableNewRowEventHandler(dataTable_TableNewRow);
            dataTable.RowDeleted += new DataRowChangeEventHandler(dataTable_RowDeleted);
            dataTable.RowChanged += new DataRowChangeEventHandler(dataTable_RowChanged);
            ///

            adapter.Fill(ds);
            conn.Close();

            dataTable = ds.Tables[0];
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].ReadOnly = true;   // ID 'key' �� ���� �Ұ����ϰ�

            //MessageBox.Show("Loading");
        }

        void dataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action != DataRowAction.Add)
            {
                if (e.Row.RowState != DataRowState.Unchanged)
                {
                    adapter.Update(dataTable);
                }
            }
        }

        void dataTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            adapter.Update(dataTable);
        }

        void dataTable_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            adapter.Update(dataTable);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            adapter.Update(ds);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter.Fill(ds);
            dataTable = ds.Tables[0];
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (dataGridView1.CurrentCell.ColumnIndex)
            {
                case 1: // ����ȣ
                    MessageBox.Show("1~3�ڸ� ���ڷθ� �Է��� �ּ���", "����");
                    break;
                case 2: // �̸�
                    MessageBox.Show("�ѱ� �Ǵ� ������ �̸��� �Է��� �ּ���", "����");
                    break;
                case 3: // �ּ�
                    MessageBox.Show("�ѱ� �Ǵ� ������ �ּҸ� �Է��� �ּ���", "����");
                    break;
                case 4: // ��ȭ��ȣ
                    MessageBox.Show("������ ���� �Է��� �ּ���\r\n��) 02-9988-5544", "����");
                    break;
                case 5: // �ֹε�Ϲ�ȣ
                    MessageBox.Show("������ ���� �Է��� �ּ���\r\n��) 800704-1234567", "����");
                    break;
                case 6: // ���������ȣ
                    MessageBox.Show("������ ���� �Է��� �ּ���\r\n��) ����-12-345678-90", "����");
                    break;
                case 7: // �Ի���
                case 8: // �����
                    MessageBox.Show("������ ���� �Է��� �ּ���.\r\n��) 2010-10-24", "����");
                    break;

                default:
                    MessageBox.Show("�߸��� ���� �Է��ϼ̽��ϴ�.", "����");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPageSetup_FormDriverDB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintPreview_FormDriverDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Print_FormDriverDB();
        }

        public void PrintPageSetup_FormDriverDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.PageSetup();
        }

        public void PrintPreview_FormDriverDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.Title = "��� ���� ���";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.PrintPreview();
        }

        public void Print_FormDriverDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.Title = "��� ���� ���";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.Print();
        }

        private void FillList(ListView list, DataGridView table)
        {
            list.SuspendLayout();

            // Clear list
            list.Items.Clear();
            list.Columns.Clear();

            // Columns
            int nCol = 0;
            //foreach (ColumnHeader col in table.Columns)
            foreach (DataGridViewColumn col in table.Columns)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = col.HeaderText;
                ch.TextAlign = HorizontalAlignment.Right;
                switch (nCol)
                {
                    case 0:
                    case 1: 
                        ch.Width = 65;
                        break;

                    case 2:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 80;
                        break;

                    case 3:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 200;
                        break;

                    case 4:
                    case 5:
                    case 6:
                        ch.TextAlign = HorizontalAlignment.Center;
                        ch.Width = 120;
                        break;

                    case 7:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 120;
                        break;

                    case 8:
                        ch.TextAlign = HorizontalAlignment.Right;
                        ch.Width = 120;
                        break;

                    default:
                        ch.Width = 100;
                        break;
                }
                list.Columns.Add(ch);
                nCol++;
            }

            // Rows
            for (int n = 0; n < table.Rows.Count; n++)
            {
                ListViewItem item = new ListViewItem();
                //item.Text = row[0].ToString();
                if(table.Rows[n].Cells[0].Value != null)
                    item.Text = table.Rows[n].Cells[0].Value.ToString();
                else
                    item.Text = "";

                for (int i = 1; i < table.Columns.Count; i++)
                {
                    //item.SubItems.Add(table.Rows[n].SubItems[i].Text);
                    //if (table.Rows[n].Cells[i].Value != (object)null)
                    if (string.Concat(table.Rows[n].Cells[i].Value) != "")
                    {
                        if ((i == 7) || (i == 8))
                        {
                            DateTime dt = (DateTime)table.Rows[n].Cells[i].Value;
                            string strDT = string.Format("{0:D4}-{1:D2}-{2:D2}", dt.Year, dt.Month, dt.Day);
                            item.SubItems.Add(strDT);
                        }
                        else
                        {
                            item.SubItems.Add(table.Rows[n].Cells[i].Value.ToString());
                        }
                    }
                    else
                    {
                        item.SubItems.Add("");
                    }
                }
                list.Items.Add(item);
            }

            list.ResumeLayout();
        }
    }
}