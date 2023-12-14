using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using PrintableListView;

namespace ConvertTacho
{
    public partial class FormCarDB : Form
    {
        private OleDbConnection conn;
        private OleDbDataAdapter adapter;
        private OleDbCommandBuilder cmdBuilder;
        private DataSet ds;
        private DataTable dataTable;
        private OleDbCommand commOpen;
        public string TACHO2_path = "";
        private PrintableListView.PrintableListView m_list;
        private iniClass inicls = new iniClass();

        public FormCarDB()
        {
            InitializeComponent();

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트

            m_list = new PrintableListView.PrintableListView();

             string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + TACHO2_path + "\\Information.mdb";
             DBstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            conn = new OleDbConnection(@DBstring);
            conn.Open();

            ds = new DataSet();

            string queryOpen = "SELECT * FROM CarInfo";
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
            dataGridView1.Columns[0].ReadOnly = true;   // ID 'key' 는 수정 불가능하게

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
            //adapter.UpdateCommand.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter.Fill(ds);
            dataTable = ds.Tables[0];
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (dataGridView1.CurrentCell.ColumnIndex)
            {
                case 4: // 등록일
                case 5: // 만료일
                    MessageBox.Show("다음과 같이 입력해 주세요.\r\n예) 2010-10-24", "오류");
                    break;

                default:
                    MessageBox.Show("잘못된 값을 입력하셨습니다.", "오류");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPageSetup_FormCarDB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintPreview_FormCarDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Print_FormCarDB();
        }

        public void PrintPageSetup_FormCarDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.PageSetup();
        }

        public void PrintPreview_FormCarDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.Title = "차량 정보 출력";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.PrintPreview();
        }

        public void Print_FormCarDB()
        {
            FillList(this.m_list, dataGridView1);
            m_list.Title = "차량 정보 출력";
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
                        ch.Width = 65;
                        break;

                    case 1:
                        ch.Width = 65;
                        ch.TextAlign = HorizontalAlignment.Center;
                        break;

                    case 2:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 180;
                        break;

                    case 3:
                        ch.TextAlign = HorizontalAlignment.Center;
                        ch.Width = 70;
                        break;

                    case 4:
                    case 5:
                        ch.TextAlign = HorizontalAlignment.Center;
                        ch.Width = 110;
                        break;

                    case 6:
                        ch.TextAlign = HorizontalAlignment.Center;
                        ch.Width = 95;
                        break;

                    case 7:
                        ch.TextAlign = HorizontalAlignment.Center;
                        ch.Width = 80;
                        break;

                    case 8:
                    case 9:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 100;
                        break;

                    case 10:
                    case 11:
                        ch.TextAlign = HorizontalAlignment.Right;
                        ch.Width = 90;
                        break;

                    default:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 120;
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
                if (table.Rows[n].Cells[0].Value != null)
                    item.Text = table.Rows[n].Cells[0].Value.ToString();
                else
                    item.Text = "";

                for (int i = 1; i < table.Columns.Count; i++)
                {
                    //item.SubItems.Add(table.Rows[n].SubItems[i].Text);
                    //if (table.Rows[n].Cells[i].Value != (object)null)
                    if (string.Concat(table.Rows[n].Cells[i].Value) != "")
                    {
                        if ((i == 4) || (i == 5))
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