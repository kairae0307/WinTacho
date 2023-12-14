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
using System.Drawing.Printing;
using ZedGraph;


namespace ConvertTacho
{
	public partial class FormTotalRec : Form
	{
		FormData formData;

        private int m_nPageNumber = 2;
        private int m_nStartRow = 0;
        private int m_nStartCol = 0;
        public double x_backup = 0;
        public double xbase_backup = 0;
        private bool m_bPrintSel = false;
        public bool first_empty_dist = false;
        private bool m_bFitToPage = false;
        public bool click = false;
        public string Sales_Temp_str = "";
        private float m_fListWidth = 0.0f;
        private float[] m_arColsWidth;

        private float m_fDpi = 96.0f;

        private string m_strTitle = "";

        public bool printstart = false;
        public int tapX = 996;

        public Boolean m_bStart;
        public double Distance_empty = new double();

		private string strTitle = "";
		public DateTime OutTime_info = new DateTime();
		public DateTime InTime_info = new DateTime();
		public DateTime Sales_Time = new DateTime();
		public DateTime Over_Time = new DateTime();
        public TimeSpan salestime_total = new TimeSpan();
		public TimeSpan emptytime_total = new TimeSpan();
		public TimeSpan overtime_total = new TimeSpan();

		public string Time_Temp;
        public byte[] Speed_Temp = new byte[125000];
        public byte[] Distance_Temp = new byte[125000];
		public string Engine_Temp;
		public string Sales_Temp;
		public string Door_Temp;
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();


		public int BasicMoney = 0;
		public int AfterMoney = 0;
		public int BasicDistance = 0;
		public int AfterDistance = 0;
		public int Totalcnt = 0;


		private string compareObject = "";
		GraphPane myPane1;
		GraphPane myPane2;
		GraphPane myPane3;
		
		textBoxData tBoxData = new textBoxData();
        private struct Graph_temp
        {

            public DateTime OutTime;
            public string Time_Temp;
            public byte[] Speed_Temp;
            public byte[] Distance_Temp;
            public string Engine_Temp;
            public string Sales_Temp;
            public string Door_Temp;
            public int key;


        }
     /*   public class ColHeader : ColumnHeader
        {
            public bool ascending;

            // �����ڸ� ���� �÷���, ������, ������ġ, ���� ���θ� �����ϵ��� �����ڸ� �����ε� ���ش�.
            public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
            {
                this.Text = text;
                this.Width = width;
                this.TextAlign = align;
                this.ascending = asc;
            }
        }*/


        class ListViewItemComparerDESC : IComparer
        {

            private int col;

            public ListViewItemComparerDESC()
            {

                col = 0;

            }

            public ListViewItemComparerDESC(int column)
            {

                col = column;

            }



            public int Compare(object x, object y)
            {

                try
                {

                    if (Convert.ToInt32(((ListViewItem)x).SubItems[col].Text) < Convert.ToInt32(((ListViewItem)y).SubItems[col].Text))
                    {

                        return 1;

                    }

                    else

                        return -1;

                }

                catch (Exception)
                {

                    if (String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text) == 1)
                    {

                        return -1;

                    }

                    else

                        return 1;



                }

            }
        }

        class ListViewItemComparerASC : IComparer
        {

            private int col;

            public ListViewItemComparerASC()
            {

                col = 0;

            }

            public ListViewItemComparerASC(int column)
            {

                col = column;

            }



            public int Compare(object x, object y)
            {

                try
                {

                    // ���� ��

                    if (Convert.ToInt32(((ListViewItem)x).SubItems[col].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[col].Text))
                    {

                        return 1;

                    }

                    else

                        return -1;

                }

                catch (Exception)
                {

                    // �ؽ�Ʈ ��

                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                }

            }

        }


        class ListViewItemComparer : IComparer
        {

            private int col;

            public string sort = "asc";

            public ListViewItemComparer()
            {

                col = 0;

            }

            /// <summary>
            /// �÷��� ���� ����(asc, desc)�� ����Ͽ� ���� ��.
            /// </summary>
            /// <param name="column">�� ��° �÷������� ��Ÿ��.</param>
            /// <param name="sort">���� ����� ��Ÿ��. Ex) asc, desc</param>
            public ListViewItemComparer(int column, string sort)
            {

                col = column;

                this.sort = sort;

            }

            public int Compare(object x, object y)
            {

                if (sort == "asc")

                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                else

                    return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);

            }

        }


   

        public enum Sorting { Ascending, Descending };

        //ListView���� �÷��� ������ ������ �ǰ� �ϱ� ����... 
        public class ColumnSorter : IComparer
        {
            public int currentColumn = -1;  // ���� ������ �÷� 
            public int previousColumn = -1;  // ���� ��å�� �÷�      
            public Sorting sort = Sorting.Ascending;

            public int Compare(object x, object y)
            {
                ListViewItem rowA = (ListViewItem)x;
                ListViewItem rowB = (ListViewItem)y;
                int result = 0;
                switch (sort)
                {
                    case Sorting.Ascending:    // ������ ������ ���Ҷ� 
                        result = String.Compare(rowA.SubItems[currentColumn].Text, rowB.SubItems[currentColumn].Text);
                        break;
                    case Sorting.Descending:    // �������� ������ ���Ҷ� 
                        result = String.Compare(rowB.SubItems[currentColumn].Text, rowA.SubItems[currentColumn].Text);
                        break;
                }
                return result;
            }

            public ColumnSorter() { }
        } 




		private struct textBoxData
		{
			public int totalCarNum;

			public string h����ð�;
			public string h���ͼ���;
			public string h���Աݾ�;
			public string h�����Ÿ�;
			public string h����Ÿ�;
			public string h���ᷮ;
			public string h���ӽð�;
			public string h������ȸ��;
			public string h����⺻ȸ��;
			public string h��������ȸ��;
			public string h�����⺻ȸ��;
			public string h��������ȸ��;
			public string h������ȸ��;
			public string h����ȸ��;
			public string h�����ð�;
			public string h�����ð�;
			public string hŰ���ȸ��;
			public string h����ð�;
			public string h�����ð�;
			public string h�����Ÿ�;
			public string h������;
			public string h�����;
			public string h����Km;
			public string h�һ��ȸ��;
			public string h�һ��ð�;

			public string y����ð�;
			public string y���ͼ���;
			public string y���Աݾ�;
			public string y�����Ÿ�;
			public string y����Ÿ�;
			public string y���ᷮ;
			public string y���ӽð�;
			public string y������ȸ��;
			public string y����⺻ȸ��;
			public string y��������ȸ��;
			public string y�����⺻ȸ��;
			public string y��������ȸ��;
			public string y������ȸ��;
			public string y����ȸ��;
			public string y�����ð�;
			public string y�����ð�;
			public string yŰ���ȸ��;
			public string y����ð�;
			public string y�����ð�;
			public string y�����Ÿ�;
			//public string y������;
			//public string y�����;
			//public string y����Km;

			public int i����ð�;
			public int i���ͼ���;
			public int i���Աݾ�;
			public double i�����Ÿ�;
			public double i����Ÿ�;
			public double i���ᷮ;
			public TimeSpan i���ӽð�;
			public int i������ȸ��;
			public int i����⺻ȸ��;
			public int i��������ȸ��;
			public int i�����⺻ȸ��;
			public int i��������ȸ��;
			public int i������ȸ��;
			public int i����ȸ��;
			public TimeSpan i�����ð�;
			public int i�����ð�;
			public int iŰ���ȸ��;
			public int i�һ��ȸ��;
			public int i����ð�;
			public int i�����ð�;
			public double i�����Ÿ�;
		}
		public void FillDataSum()
		{
			textBox����ð�.Text = tBoxData.h����ð�;
			textBox���ͼ���.Text = tBoxData.h���ͼ���;
			textBox���Աݾ�.Text = tBoxData.h���Աݾ�;
			textBox�����Ÿ�.Text = tBoxData.h�����Ÿ�;
			textBox����Ÿ�.Text = tBoxData.h����Ÿ�;
			textBox���ᷮ.Text = tBoxData.h���ᷮ;
			textBox���ӽð�.Text = tBoxData.h���ӽð�;
			textBox������ȸ��.Text = tBoxData.h������ȸ��;
			textBox����⺻ȸ��.Text = tBoxData.h����⺻ȸ��;
			textBox��������ȸ��.Text = tBoxData.h��������ȸ��;
			textBox�����⺻ȸ��.Text = tBoxData.h�����⺻ȸ��;
			textBox��������ȸ��.Text = tBoxData.h��������ȸ��;
			textBox������ȸ��.Text = tBoxData.h������ȸ��;
			textBox����ȸ��.Text = tBoxData.h����ȸ��;
			textBox�����ð�.Text = tBoxData.h�����ð�;
			textBox�����ð�.Text = tBoxData.h�����ð�;
			textBoxŰ���ȸ��.Text = tBoxData.hŰ���ȸ��;
			//textBox����ð�.Text = tBoxData.h����ð�;
			//textBox�����ð�.Text = tBoxData.h�����ð�;
			textBox�����Ÿ�.Text = tBoxData.h�����Ÿ�;
			textBox������.Text = tBoxData.h������;
			textBox�����.Text = tBoxData.h�����;
			textBox����Km.Text = tBoxData.h����Km;

			//textBox�һ��ð�.Text = "0�ð� 00��";
			//textBox�ս½ð�.Text = "0�ð� 00��";
			textBox���Ը���.Text = "**.** ��";
			//textBox�����ݾ�.Text = "0 ��";
			//	textBox�ս�ȸ��.Text = "0 ȸ";
			//	textBox�ս°Ÿ�.Text = "0 Km";
			//	textBox����ݾ�.Text = "0 ��";
			//	textBox�һ��Ÿ�.Text = "0 Km";
			textBoxKm����.Text = "**.** Km";
			//	textBox�ս¿��.Text = "0 ��";
			//	textBox����ݾ�.Text = "0 ��";
			//	textBox�һ����.Text = "0 ��";
			//	textBox�һ��ȸ��.Text = "0 ȸ";
		}

        int BinToBcd8(int n)
        {
            return ((int)((n / 10) << 4) + (n % 10));
        }

        public int BcdToDecimal(byte bTemp)
        {
            return (((bTemp >> 4) * 10) + (bTemp & 0x0F));
        }

        public byte[] BinToBcd24P(byte[] arr, int n)
        {

            int rulTmp;

            rulTmp = n % 1000000;
            arr[2] = (byte)BinToBcd8(rulTmp / 10000);
            rulTmp = n % 10000;
            arr[1] = (byte)BinToBcd8(rulTmp / 100);
            arr[0] = (byte)BinToBcd8(rulTmp % 100);
            return arr;
        }
		public FormTotalRec(FormData f)
		{
            formData = f;
            InitializeComponent();
            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // Ÿ�� ��Ʈ
            m_list = new PrintableListView.PrintableListView();
		}
        private void FillList(ListView list, ListView table)
        {
            list.SuspendLayout();

            // Clear list
            list.Items.Clear();
            list.Columns.Clear();

            // Columns
            int nCol = 0;
            foreach (ColumnHeader col in table.Columns)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = col.Text;
                ch.TextAlign = HorizontalAlignment.Right;
                switch (nCol)
                {
                    case 0: ch.Width = 30; break;

                    case 1: ch.Width = 60; break;
                    case 3: ch.Width = 60; break;
                    case 4:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 100;
                        break;
                    case 5: ch.Width = 100; break;
                    case 6: ch.Width = 100; break;
                    case 8:
                    case 9: ch.Width = 100; break;
                    case 10: ch.Width = 70; break;

                    case 2:
                    case 7:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15: ch.Width = 80; break;
                    default:
                        ch.Width = 100;
                        break;
                }
                list.Columns.Add(ch);
                nCol++;
            }

            // Rows
            for (int n = 0; n < table.Items.Count; n++)
            {
                ListViewItem item = new ListViewItem();
                //item.Text = row[0].ToString();
                item.Text = table.Items[n].Text;

                for (int i = 1; i < table.Columns.Count; i++)
                {
                    item.SubItems.Add(table.Items[n].SubItems[i].Text);
                }
                list.Items.Add(item);
            }

            list.ResumeLayout();
        }
		public void FillDaySearchData(string carnum, DateTime starttime, DateTime Endtime,int sel)  // sel =0  car ,  sel =1  driver no.
		{
			string Dirname = "";
            int nCnt = 1;
            int SalesDays = 0;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Items.Clear();
            listView1.Columns.Clear();

            listView1.Columns.Add("��ȣ", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("��¥", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("�����ð�", 75, HorizontalAlignment.Right);
            listView1.Columns.Add("�����ð�", 75, HorizontalAlignment.Right);
            listView1.Columns.Add("���� (Km)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("��� (��)", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("���� (Km)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("�����ð�", 75, HorizontalAlignment.Right);
        //    listView1.Columns.Add("sort", 75, HorizontalAlignment.Right);

        
        
			if (formData.Dayseach_tacho == true)
			{
                Dirname = TACHO2_path + "\\Ÿ��";
			}
			else if (formData.Dayseach_tachoday == true)
			{
                Dirname = TACHO2_path + "\\Ÿ�� �Ϻ�";
			}
			else if (formData.Dayseach_tacho2day == true)
			{
                Dirname = TACHO2_path + "\\Ÿ�� ����и�";
			}
			else if (formData.Dayseach_tachoauto == true)
			{
                Dirname = TACHO2_path + "\\Ÿ�� �ڵ��и�";
			}

			DirectoryInfo dirs = new DirectoryInfo(Dirname);
			DirectoryInfo[] DIRS = dirs.GetDirectories();
			FileInfo[] files = dirs.GetFiles();

			string[] file_str = new string[files.Length];

			char[] trimChars = { '.', 'm', 'd', 'b' };
			int cnt = 0;

            int StartDate_int = (starttime.Year) * 10000;
            StartDate_int += (starttime.Month) * 100;
            StartDate_int += starttime.Day;
            StartDate_int -= 20000000;


            int EndDate_int = (Endtime.Year) * 10000;
            EndDate_int += (Endtime.Month) * 100;
            EndDate_int += Endtime.Day;
            EndDate_int -= 20000000;
			for (int i = 0; i < files.Length; i++)
			{

				if (files[i].Extension != ".ldb")
				{
                    string temp_str = files[i].ToString();
                    temp_str = temp_str.TrimEnd(trimChars);
                    temp_str = temp_str.Replace("AM", "");
                    temp_str = temp_str.Replace("PM", "");
                    int mdbDate_Int = Int32.Parse(temp_str);
                    if (mdbDate_Int < StartDate_int || mdbDate_Int > EndDate_int)
                    {
                        continue;
                    }

                    file_str[i] = files[i].ToString();
                    file_str[i] = file_str[i].TrimEnd(trimChars);

				}


			}
			int j = 0;
			bool start = false;



			for (int i = 0; i < file_str.Length; i++)
			{

                
				string DBstring = "";
				if (file_str[i] ==null)
				{
					continue;
				}

/*                int mdbDate_Int = Int32.Parse(file_str[i].ToString());

                if (mdbDate_Int < StartDate_int || mdbDate_Int > EndDate_int)
                {
                    continue;
                }*/

				
					DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";
				
				string queryRead = "select * from TblTacho";

				OleDbConnection conn1 = new OleDbConnection(@DBstring);
				conn1.Open();
				OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
				OleDbDataReader srRead = commRead.ExecuteReader();

				//if ((srRead.GetString(1).Contains(compareObject) == false))
				//	continue;   // ������ȣ�� ����� Ÿ ������ȣ �Ÿ���
			
				while (srRead.Read())
				{
					

						compareObject = carnum;
						
						����label.Text = "�� �� : " + compareObject;
						DateTime TimeSeach = new DateTime();
						DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
						DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);
						if (formData.TotalRec == false)
						{
							����label.Visible = true;

                            if (sel == 0)
                            {
                                if ((srRead.GetString(1).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                                    continue;   // ������ȣ�� ����� Ÿ ������ȣ �Ÿ���
                            }
                            else if(sel==1)
                            {
                                  string tt =  srRead.GetString(2);
                                  if (tt != compareObject || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                                  {
                                      continue;  
                                  }


                              //  if ((srRead.GetString(2).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                              
                                //    continue;   // ��� ��ȣ�� ����� Ÿ ������ȣ �Ÿ���
                              
                               
                            }

							string driverNo = srRead.GetString(2);
							string driverName = srRead.GetString(3);

							������label.Visible = true;
							������label.Text = "�� �� �� : " + driverNo + " ( " + driverName + ")";
						}
						else
						{
							//DateTime TimeSeach = new DateTime();
						//	DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1,1,1);
							//DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);

							TimeSeach = srRead.GetDateTime(4);

							TimeSeach = new DateTime(TimeSeach.Year, TimeSeach.Month, TimeSeach.Day, 1,1,1);
							
							����label.Visible = false;


							if (TimeSeach < StartTime || TimeSeach > EndTime)
								continue;
							else
							{
								Totalcnt++;
							}

						
						}
															
						DateTime readToday = srRead.GetDateTime(5);

						tBoxData.totalCarNum++;
					
						DateTime outT = srRead.GetDateTime(4);
						
						int count = 0;

						if (start == false)
						{
							OutTime_info = outT;
							InTime_info = readToday;
							start = true;
						}
						else
						{
							if (OutTime_info > outT)
							{
								OutTime_info = outT;
							}

							if (InTime_info < readToday)
							{
								InTime_info = readToday;
							}

						}
						if (formData.TotalRec == false)
						{
							���label.Visible = true;
							�԰�label.Visible = true;

							���label.Text = "�� �� : " + OutTime_info;
							�԰�label.Text = "�� �� : " + InTime_info;
						}
						else
						{
							������label.Visible = true;
							������label.Text = "�� ����� : " + Totalcnt.ToString() +"ȸ";
							���label.Visible = true;
							�԰�label.Visible = true;

							���label.Text = "�� �� : " + starttime.Year.ToString() + "��" + starttime.Month.ToString() + "��" + starttime.Day.ToString() + "��" + " ~ ";
							�԰�label.Text = "    �� : " + Endtime.Year.ToString() + "��" + Endtime.Month.ToString() + "��" + Endtime.Day.ToString() + "��";
						}
					
					//graph[count].OutTime = outT;

					//DateTime inT = srRead.GetDateTime(5);
					DateTime inT = readToday;
					TimeSpan dT = inT - outT;
					TimeSpan eT = dT;
                    //////////////////////////////////////////////////////////////////////////////////

                    DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                    DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                    TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);
                    Sales_Temp_str = srRead.GetString(26);   // ����
                    Time_Temp = srRead.GetString(22);  // �׷��� �ð� �б�
                    stTime = srRead.GetDateTime(4);
                    string Engine_Temp = srRead.GetString(25);   // ����

                    srRead.GetBytes(24, 0, Distance_Temp, 0, 125000);  // �Ÿ�
                   


                    byte[] Sales_Detail = new byte[50000];
                    srRead.GetBytes(27, 0, Sales_Detail, 0, 50000);  // �󼼿���
                    stTime = srRead.GetDateTime(4);
                    Distance_empty = 0;
                    first_empty_dist = false;

                    double[] distance_double = new double[Sales_Temp_str.Length];
                    char[] Sales_char = new char[Sales_Temp_str.Length];
                    char[] time_char = new char[Time_Temp.Length];
                    char[] Engine_char = new char[Engine_Temp.Length];
                    Distance_empty = 0;
                    first_empty_dist = false;

                    int enginecnt = 0;
                    for (int g = 0; g < Engine_Temp.Length; g++)    //Engine db : string  -> char 
                    {
                        Engine_char[g] = Engine_Temp[g];

                        if (Engine_char[g] == '0')
                        {
                            enginecnt++;
                        }

                    }

                    int timecnt = 0;
                    for (int a = 0; a < Time_Temp.Length; a++)    // time db : string  -> char 
                    {
                        time_char[a] = Time_Temp[a];

                        if (Time_Temp[a] == '#')
                        {
                            timecnt++;
                        }
                    }

                    int cntt = 0;
                    string[] time = new string[timecnt];
                    //	string[] speed = new string[timecnt];
                    //	string[] distance = new string[timecnt];

                    for (int a = 0; a < time_char.Length; a++)   // ������ ���� ��Ȯ �� -> �ٽ� string  ��ȯ
                    {


                        if (time_char[a] != '#')
                        {
                            time[cntt] += time_char[a];
                        }
                        else
                        {
                            cntt++;			// ������ ī��Ʈ
                        }


                    }

                    long[] time_long = new long[cntt];
                    DateTime[] datetime = new DateTime[cntt];
                    int totaltimecnt = 0;

                    for (int a = 0; a < time.Length; a++)
                    {
                        time_long[a] = Int64.Parse(time[a]);		// string  -> long ��ȯ 
                        datetime[a] = DateTime.FromBinary(time_long[a]); // long -> DateTime ��ȯ
                        //	speed_long[i] = Int32.Parse(speed[i]);			// string -> long  ��ȯ

                        if (a != 0)
                        {
                            if (Engine_char[a] == '1' && Engine_char[a - 1] == '0')
                            {
                            }
                            else
                            {

                                TimeSpan datetime1 = datetime[a] - datetime[a - 1];
                                totaltimecnt += datetime1.Minutes;
                            }
                        }

                    }
                    tBoxData.i����ð� += totaltimecnt;
                    /////////////////////////////////////////////////////////////////////////////////////////
					int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
				//	tBoxData.i����ð� += driveT;

					int meterImport = (int)srRead.GetDecimal(6);
					tBoxData.i���ͼ��� += meterImport;


					int money_save = (int)srRead.GetDecimal(7);
					tBoxData.i���Աݾ� = money_save;

					double salesDistance = srRead.GetDouble(8);
					tBoxData.i�����Ÿ� += salesDistance;

					double driveDistance = srRead.GetDouble(9);
					tBoxData.i����Ÿ� += driveDistance;

					double fuel = srRead.GetDouble(10);
					tBoxData.i���ᷮ += fuel;



					TimeSpan overT = new TimeSpan();					//���ӽð�
					Over_Time = srRead.GetDateTime(11);
					DateTime Over_Time_t = new DateTime(Over_Time.Year, Over_Time.Month, Over_Time.Day, 0, 0, 0);
					overT = Over_Time - Over_Time_t;
					overtime_total += overT;
					tBoxData.i���ӽð� = overtime_total;


					int emerBreakCnt = srRead.GetInt32(12);
					tBoxData.i������ȸ�� += emerBreakCnt;

					int driveBasicCnt = srRead.GetInt32(13);
					tBoxData.i����⺻ȸ�� += driveBasicCnt;

					int driveAfterCnt = srRead.GetInt32(14);
					tBoxData.i��������ȸ�� += driveAfterCnt;

					int addBasicCnt = srRead.GetInt32(15);
					tBoxData.i�����⺻ȸ�� += addBasicCnt;

					int addAfterCnt = srRead.GetInt32(16);
					tBoxData.i��������ȸ�� += addAfterCnt;

					//graph[count].Door_Temp = srRead.GetString(17);  //door


					int salesCnt = srRead.GetInt32(18);
					tBoxData.i����ȸ�� += salesCnt;



					TimeSpan salesT = new TimeSpan();
					Sales_Time = srRead.GetDateTime(19);
                    DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // �����ð� 
					salesT = Sales_Time - Sales_Time_t;

                    ////////////////////////////////////////////////////////////////////////////////////////

                    if (Sales_Time.Year != 1899)
                    {
                        SalesDays += Sales_Time.Day;     // 1899�⵵ �ƴѰ͸� ���ؾ��� �߸��Ǿ���!!!   19.09.26
                    }

                    salestime_total += salesT;         // 24�ð� �̻��϶��� üũ �ؾ���
                    tBoxData.i�����ð� = salestime_total;
               




					TimeSpan emptyT = new TimeSpan();					// ���� �ð�
					emptyT = eT - salesT;
					emptytime_total += emptyT;

                  int kongcha =  totaltimecnt - ((salesT.Hours * 60) + salesT.Minutes);
               
                  tBoxData.i�����ð� += kongcha;
				//	tBoxData.i�����ð� += emptytime_total;

					int keyUseCnt = srRead.GetInt32(21);
					tBoxData.iŰ���ȸ�� += keyUseCnt;

					int riderT = 0;
					tBoxData.i����ð� += riderT;

					int stopT = ((driveT > riderT) ? driveT - riderT : 0);
					tBoxData.i�����ð� += stopT;

					double emptyDistance = driveDistance - salesDistance;
					tBoxData.i�����Ÿ� += emptyDistance;


                    
                    // 14.02.27  ������ ������ ��� ����  ������ ������ �ð��� ���� �ɸ� 

                    string path = Application.StartupPath + "\\WinTacho.ini";
                    string salesdetail = inicls.GetIniValue("Tacho Init", "Car_TotalRec_slaesdetail", path); // 

                    #region Salesdetail
                    if (salesdetail == "1")
                    {


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                     



                     


                        for (int a = 0; a < Sales_Temp_str.Length; a++)    //Sales db : string  -> char 
                        {
                            Sales_char[a] = Sales_Temp_str[a];

                        }
                        for (int a = 0; a < Sales_Temp_str.Length; a++)
                        {

                            distance_double[a] = (double)(Distance_Temp[a]) / 10.0;

                            if (Sales_char[a] == '0')
                            {
                                if (first_empty_dist == false)
                                {
                                    Distance_empty += distance_double[a];
                                }

                            }
                            else
                            {
                                first_empty_dist = true;
                            }
                        }



                        int DAtacnt = 0;


                        //int hour = 0;

                        int fdcnt = 0;
                        for (int a = 0; a < Sales_Detail.Length; a++)
                        {
                            if (Sales_Detail[a] == 0xfd)
                                fdcnt++;
                        }

                        byte[] Sales_Data = new byte[fdcnt * 34];

                        for (int a = 0; a < Sales_Data.Length; a++)
                        {
                            Sales_Data[a] = Sales_Detail[a];
                        }



                        int sales_cnt = 0;
                        for (int q = 0; q < fdcnt; q++)
                        {

                            ListViewItem a = new ListViewItem(nCnt.ToString());
                            //	string str = string.Format("{0}.{1}.{2}", stTime.Year.ToString(), stTime.Month.ToString(), stTime.Day.ToString());
                            //	a.SubItems.Add(str);

                            int Year_int = 0;
                            int Month_int = 0;
                            int Day_int = 0;

                            string Year_str = "";
                            string Month_str = "";
                            string Day_str = "";


                            int in_hour = 0;
                            int out_hour = 0;

                            string in_str = "";
                            string out_str = "";

                            byte[] Sales_Distance = new byte[3];
                            byte[] Money = new byte[3];
                            byte[] Empty_Distance = new byte[3];


                            double distance = 0;
                            double empty = 0;
                            int money = 0;
                            int key = 0;
                            int break_stop = 0;


                            bool Year_chk = false;
                            bool year_ = false;
                            int year = 0;

                            DateTime sorttime = new DateTime();

                            for (int k = 0; k < 34; k++)
                            {

                                switch (k)
                                {



                                    case 0:
                                        Month_int = Sales_Data[k + q + sales_cnt];

                                        if (Month_int > 10)
                                        {
                                            Year_chk = true;
                                        }
                                        if (Year_chk == true)
                                        {
                                            if (Month_int < 10)
                                            {
                                                year_ = true;
                                                year = datetime[0].Year + 1;
                                            }

                                        }
                                        break;

                                    case 1:
                                        Day_int = Sales_Data[k + q + sales_cnt];
                                        string str = string.Format("{0}.{1}.{2}", stTime.Year.ToString(), Month_int.ToString(), Day_int.ToString());
                                        a.SubItems.Add(str);

                                        break;


                                    case 2:
                                        in_hour = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 3:
                                        in_str = string.Format("{0:D2}:{1:D2}", in_hour, Sales_Data[k + q + sales_cnt]); //����
                                        a.SubItems.Add(in_str);

                                        if (Month_int == 0x00 || Day_int == 0x00)
                                        {
                                            break;
                                        }
                                        sorttime = new DateTime(stTime.Year, Month_int, Day_int, in_hour, Sales_Data[k + q + sales_cnt], 0);
                                        break;

                                    case 4:
                                        out_hour = Sales_Data[k + q + sales_cnt];


                                        break;

                                    case 5:
                                        out_str = string.Format("{0:D2}:{1:D2}", out_hour, Sales_Data[k + q + sales_cnt]);  //����
                                        a.SubItems.Add(out_str);
                                        break;

                                    case 6:
                                        Sales_Distance[0] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 7:
                                        Sales_Distance[1] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 8:																	// �����Ÿ�
                                        Sales_Distance[2] = Sales_Data[k + q + sales_cnt];

                                        distance = (double)((BcdToDecimal(Sales_Distance[0]) * 10000)
                                                    + (BcdToDecimal(Sales_Distance[1]) * 100)
                                                    + BcdToDecimal(Sales_Distance[2])) / 1000.0;

                                        //	total.tDistS += distance;

                                        string distance_str = string.Format("{0:N} Km", distance.ToString());
                                        a.SubItems.Add(distance_str);
                                        break;

                                    case 9:
                                        Money[0] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 10:
                                        Money[1] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 11:																	// ���
                                        Money[2] = Sales_Data[k + q + sales_cnt];

                                        money = ((BcdToDecimal(Money[0]) * 10000)
                                                                    + (BcdToDecimal(Money[1]) * 100)
                                                                    + BcdToDecimal(Money[2]));
                                        //	total.tMoney += (uint)money;
                                        string money_str = string.Format("{0:C}", money);

                                        a.SubItems.Add(money_str);
                                        break;

                                    case 12:
                                        Empty_Distance[0] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 13:
                                        Empty_Distance[1] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 14:																	// �����Ÿ�
                                        Empty_Distance[2] = Sales_Data[k + q + sales_cnt];



                                        byte[] empty_byte = new byte[3];
                                        int emppty_temp = 0;

                                        if (first_empty_dist == false) //11.09.01 ù��° ���� ��� 1�е����� �Ÿ� �հ� ������ ������������ -> �׷����� ���ϰ�ǥ��
                                        {

                                            emppty_temp = (int)(Distance_empty * 1000);

                                            empty_byte = BinToBcd24P(empty_byte, emppty_temp);

                                            empty = (double)((BcdToDecimal(empty_byte[2]) * 10000)
                                                    + (BcdToDecimal(empty_byte[1]) * 100)
                                                    + BcdToDecimal(empty_byte[0])) / 1000.0;

                                            first_empty_dist = true;


                                        }
                                        else // ���� ���� �� ���� ��Ÿ� ������Ʈ�� ��� 
                                        {


                                            empty = (double)((BcdToDecimal(Empty_Distance[2]) * 10000)
                                                        + (BcdToDecimal(Empty_Distance[1]) * 100)
                                                        + BcdToDecimal(Empty_Distance[0])) / 1000.0;
                                        }

                                        string empty_str = empty.ToString();
                                        a.SubItems.Add(empty_str);
                                        break;

                                    case 15:
                                        // ���� �ð�

                                        int emptytime = Sales_Data[k + q + sales_cnt];
                                        string empty_time = string.Format("{0:D2}:{1:D2}", emptytime / 60, emptytime % 60);
                                        a.SubItems.Add(empty_time);
                                        break;

                                    case 18:

                                        key = Sales_Data[k + q + sales_cnt];

                                        break;
                                    case 19:

                                        break_stop = Sales_Data[k + q + sales_cnt];

                                        break;


                                }


                            }
                            sales_cnt += 33;

                            if (key != 0 && break_stop != 1)
                            {
                                nCnt++;
                                //  total.tMoney += (uint)money;
                                //   total.tDisteD += empty;
                                //   total.tDistS += distance;
                                a.SubItems.Add(sorttime.ToString());
                                listView1.Items.Add(a);


                            }
                        }


                        if (!this.click)   // ���⼭ this.click �� bool click �Դϴ�. ���������� ������ �ּ���.
                        {

                            this.listView1.ListViewItemSorter = new ListViewItemComparerASC(0x08);

                            this.listView1.Sort();

                            this.click = true;

                        }

                        else
                        {

                            this.listView1.ListViewItemSorter = new ListViewItemComparerDESC(0x08);

                            this.listView1.Sort();

                            this.click = false;

                        }

                        ///////////////////////////////////////////////////////////////////////////////////////////////
                    }  // if(salesdetail =="1")
                    else
                    {

                       // this.Height = 456;
                        this.listView1.Visible = false;
                        this.label1.Visible = false;
                        this.button1.Location = new Point(663, 411);
                        this.button4.Location = new Point(566, 411);
                        this.label1.Visible = false;




                    }
                    #endregion

                }
              
               
				conn1.Close();

			}
			if (tBoxData.totalCarNum > 0)
			{


                if ((tBoxData.i����ð� / 1440 != 0))
                {
                    int Day_calc = (tBoxData.i����ð� / 1440);
                    int hour_calc = ((tBoxData.i����ð� - (Day_calc * 1440)) / 60);
                    int min_calc = (tBoxData.i����ð� % 60);

                    tBoxData.h����ð� = String.Format("{0:D}�� {1:D}�ð� {2:D2}��", Day_calc, hour_calc, (tBoxData.i����ð� % 60));
                }
                else
                {

                    tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
                }

			//	tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
				tBoxData.h���ͼ��� = String.Format("{0:C} ��", tBoxData.i���ͼ���);
				tBoxData.h���Աݾ� = String.Format("{0:C} ��", tBoxData.i���Աݾ�);
				tBoxData.h�����Ÿ� = String.Format("{0:N} Km", tBoxData.i�����Ÿ�);
				tBoxData.h����Ÿ� = String.Format("{0:N} Km", tBoxData.i����Ÿ�);
				tBoxData.h���ᷮ = String.Format("{0} L", tBoxData.i���ᷮ);



				tBoxData.h���ӽð� = String.Format(overtime_total.Hours.ToString() + "�ð� " + overtime_total.Minutes.ToString() + "��");

				tBoxData.h������ȸ�� = String.Format("{0} ȸ", tBoxData.i������ȸ��);
				tBoxData.h����⺻ȸ�� = String.Format("{0} ȸ", tBoxData.i����⺻ȸ��);
				tBoxData.h��������ȸ�� = String.Format("{0} ȸ", tBoxData.i��������ȸ��);
				tBoxData.h�����⺻ȸ�� = String.Format("{0} ȸ", tBoxData.i�����⺻ȸ��);
				tBoxData.h��������ȸ�� = String.Format("{0} ȸ", tBoxData.i��������ȸ��);
				tBoxData.h������ȸ�� = String.Format("{0} ȸ", tBoxData.i������ȸ��);
				tBoxData.h����ȸ�� = String.Format("{0} ȸ", tBoxData.i����ȸ��);

                if (SalesDays == 0)
                {
                    if (salestime_total.Days != 0)
                    {
                        tBoxData.h�����ð� = String.Format(salestime_total.Days.ToString() + "��" + salestime_total.Hours.ToString() + "�ð� " + salestime_total.Minutes.ToString() + "��");
                    }
                    else
                    {
                       tBoxData.h�����ð� = String.Format(salestime_total.Hours.ToString() + "�ð� " + salestime_total.Minutes.ToString() + "��");
                    }
                }
                else
                {
                    if (salestime_total.Days != 0)
                    {
                        SalesDays += salestime_total.Days;
                        tBoxData.h�����ð� = String.Format(SalesDays.ToString() + "��" + salestime_total.Hours.ToString() + "�ð� " + salestime_total.Minutes.ToString() + "��");
                    }
                    else
                    {
                        tBoxData.h�����ð� = String.Format(SalesDays.ToString() + "��" + salestime_total.Hours.ToString() + "�ð� " + salestime_total.Minutes.ToString() + "��");
                    }
                }
                int kongchatime = tBoxData.i����ð� - (salestime_total.Days * 1440 + salestime_total.Hours * 60 + salestime_total.Minutes);
                int day=0, hour=0, min=0;
                     if (kongchatime > 1439)  // 1day
                    {
                        day = kongchatime / 1440;
                    }
                    else
                    {
                        hour = kongchatime / 60;
                        min = kongchatime % 60;
                    }


                    if (day != 0)
                    {
                       
                        tBoxData.h�����ð� = day.ToString() + "�� " + hour.ToString() + "�ð� " + min.ToString() + "�� ";
                    }
                    else
                    {
                           tBoxData.h�����ð� = hour.ToString() + "�ð� " + min.ToString() + "�� ";  // ����ð�
                    }


			//	tBoxData.h�����ð� = String.Format(emptytime_total.Days.ToString() +"��"+ emptytime_total.Hours.ToString() + "�ð� " + emptytime_total.Minutes.ToString() + "��");
				tBoxData.hŰ���ȸ�� = String.Format("{0} ȸ", tBoxData.iŰ���ȸ��);
				tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
				tBoxData.h�����ð� = String.Format("{0:D}�ð� {1:D2}��", (int)(tBoxData.i�����ð� / 60), (tBoxData.i�����ð� % 60));
				tBoxData.h�����Ÿ� = String.Format("{0:N} Km", tBoxData.i�����Ÿ�);
				tBoxData.h������ = (tBoxData.i����Ÿ� > 0) ? String.Format("{0:#.##} %", (tBoxData.i�����Ÿ� / tBoxData.i����Ÿ�) * 100) : "0.00 %";

				int driveTIme = (((tBoxData.i�����ð�.Days * 24) + tBoxData.i�����ð�.Hours) * 60) + tBoxData.i�����ð�.Minutes;

				tBoxData.h����� = (tBoxData.i����ð� > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i����ð�) : "0.00 %";
				//tBoxData.h����� = (tBoxData.i����ð� > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i����ð� / (double)tBoxData.i����ð�) * 100) : "0.00 %";

				tBoxData.h����Km = (tBoxData.i�����Ÿ� > 0) ? String.Format("{0:C} ��", (double)tBoxData.i���ͼ��� / tBoxData.i�����Ÿ�) : "0.00 ��";

				FillDataSum();
				//FillData_graph();
			}

			formData.TotalRec = false;
            FillList(this.m_list, listView1);
		}

        public void TotalSearchData( DateTime starttime, DateTime Endtime)
        {
            string Dirname = "";
            int SalesDays = 0;
            if (formData.Dayseach_tacho == true)
            {
                Dirname = TACHO2_path + "\\Ÿ��";
            }
            else if (formData.Dayseach_tachoday == true)
            {
                Dirname = TACHO2_path + "\\Ÿ�� �Ϻ�";
            }
            else if (formData.Dayseach_tacho2day == true)
            {
                Dirname = TACHO2_path + "\\Ÿ�� ����и�";
            }
            else if (formData.Dayseach_tachoauto == true)
            {
                Dirname = TACHO2_path + "\\Ÿ�� �ڵ��и�";
            }

            DirectoryInfo dirs = new DirectoryInfo(Dirname);
            DirectoryInfo[] DIRS = dirs.GetDirectories();
            FileInfo[] files = dirs.GetFiles();

            string[] file_str = new string[files.Length];

            char[] trimChars = { '.', 'm', 'd', 'b' };
            int cnt = 0;
            for (int i = 0; i < files.Length; i++)
            {

                if (files[i].Extension != ".ldb")
                {

                    file_str[i] = files[i].ToString();
                    file_str[i] = file_str[i].TrimEnd(trimChars);

                }


            }
            int j = 0;
            bool start = false;

            for (int i = 0; i < file_str.Length; i++)
            {


                string DBstring = "";
                if (file_str[i] == null)
                {
                    continue;
                }

                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";

                string queryRead = "select * from TblTacho";

                OleDbConnection conn1 = new OleDbConnection(@DBstring);
                conn1.Open();
                OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
                OleDbDataReader srRead = commRead.ExecuteReader();

                //if ((srRead.GetString(1).Contains(compareObject) == false))
                //	continue;   // ������ȣ�� ����� Ÿ ������ȣ �Ÿ���

                while (srRead.Read())
                {


                 //   compareObject = carnum;

                    ����label.Text = "�� �� : " + compareObject;
                    DateTime TimeSeach = new DateTime();
                    DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1, 1, 1);
                    DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);
                    if (formData.TotalRec == false)
                    {
                        ����label.Visible = true;
                        if ((srRead.GetString(1).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                            continue;   // ������ȣ�� ����� Ÿ ������ȣ �Ÿ���
                        string driverNo = srRead.GetString(2);
                        string driverName = srRead.GetString(3);

                        ������label.Visible = true;
                        ������label.Text = "�� �� �� : " + driverNo + " ( " + driverName + ")";
                    }
                    else
                    {
                        //DateTime TimeSeach = new DateTime();
                        //	DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1,1,1);
                        //DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);

                        TimeSeach = srRead.GetDateTime(4);

                        TimeSeach = new DateTime(TimeSeach.Year, TimeSeach.Month, TimeSeach.Day, 1, 1, 1);

                        ����label.Visible = false;


                        if (TimeSeach < StartTime || TimeSeach > EndTime)
                            continue;
                        else
                        {
                            Totalcnt++;
                        }


                    }

                    DateTime readToday = srRead.GetDateTime(5);

                    tBoxData.totalCarNum++;

                    DateTime outT = srRead.GetDateTime(4);

                    int count = 0;

                    if (start == false)
                    {
                        OutTime_info = outT;
                        InTime_info = readToday;
                        start = true;
                    }
                    else
                    {
                        if (OutTime_info > outT)
                        {
                            OutTime_info = outT;
                        }

                        if (InTime_info < readToday)
                        {
                            InTime_info = readToday;
                        }

                    }
                    if (formData.TotalRec == false)
                    {
                        ���label.Visible = true;
                        �԰�label.Visible = true;

                        ���label.Text = "�� �� : " + OutTime_info;
                        �԰�label.Text = "�� �� : " + InTime_info;
                    }
                    else
                    {
                        ������label.Visible = true;
                        ������label.Text = "�� ����� : " + Totalcnt.ToString() + "ȸ";
                        ���label.Visible = true;
                        �԰�label.Visible = true;

                        ���label.Text = "�� �� : " + starttime.Year.ToString() + "��" + starttime.Month.ToString() + "��" + starttime.Day.ToString() + "��" + " ~ ";
                        �԰�label.Text = "    �� : " + Endtime.Year.ToString() + "��" + Endtime.Month.ToString() + "��" + Endtime.Day.ToString() + "��";
                    }

                    //graph[count].OutTime = outT;

                    //DateTime inT = srRead.GetDateTime(5);
                    DateTime inT = readToday;
                    TimeSpan dT = inT - outT;
                    TimeSpan eT = dT;

                    int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
                    tBoxData.i����ð� += driveT;

                    int meterImport = (int)srRead.GetDecimal(6);
                    tBoxData.i���ͼ��� += meterImport;


                    int money_save = (int)srRead.GetDecimal(7);
                    tBoxData.i���Աݾ� = money_save;

                    double salesDistance = srRead.GetDouble(8);
                    tBoxData.i�����Ÿ� += salesDistance;

                    double driveDistance = srRead.GetDouble(9);
                    tBoxData.i����Ÿ� += driveDistance;

                    double fuel = srRead.GetDouble(10);
                    tBoxData.i���ᷮ += fuel;



                    TimeSpan overT = new TimeSpan();					//���ӽð�
                    Over_Time = srRead.GetDateTime(11);
                    DateTime Over_Time_t = new DateTime(Over_Time.Year, Over_Time.Month, Over_Time.Day, 0, 0, 0);
                    overT = Over_Time - Over_Time_t;
                    overtime_total += overT;
                    tBoxData.i���ӽð� = overtime_total;


                    int emerBreakCnt = srRead.GetInt32(12);
                    tBoxData.i������ȸ�� += emerBreakCnt;

                    int driveBasicCnt = srRead.GetInt32(13);
                    tBoxData.i����⺻ȸ�� += driveBasicCnt;

                    int driveAfterCnt = srRead.GetInt32(14);
                    tBoxData.i��������ȸ�� += driveAfterCnt;

                    int addBasicCnt = srRead.GetInt32(15);
                    tBoxData.i�����⺻ȸ�� += addBasicCnt;

                    int addAfterCnt = srRead.GetInt32(16);
                    tBoxData.i��������ȸ�� += addAfterCnt;

                    //graph[count].Door_Temp = srRead.GetString(17);  //door


                    int salesCnt = srRead.GetInt32(18);
                    tBoxData.i����ȸ�� += salesCnt;



                    TimeSpan salesT = new TimeSpan();
                    Sales_Time = srRead.GetDateTime(19);
                    DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // �����ð� 
                    salesT = Sales_Time - Sales_Time_t;
                    SalesDays += Sales_Time.Day; 
                    salestime_total += salesT;
                    tBoxData.i�����ð� = salestime_total;




                    TimeSpan emptyT = new TimeSpan();					// ���� �ð�
                    emptyT = eT - salesT;
                    emptytime_total += emptyT;
                    tBoxData.i�����ð� += (emptytime_total.Hours*60 +emptytime_total.Minutes);

                    int keyUseCnt = srRead.GetInt32(21);
                    tBoxData.iŰ���ȸ�� += keyUseCnt;

                    int riderT = 0;
                    tBoxData.i����ð� += riderT;

                    int stopT = ((driveT > riderT) ? driveT - riderT : 0);
                    tBoxData.i�����ð� += stopT;

                    double emptyDistance = driveDistance - salesDistance;
                    tBoxData.i�����Ÿ� += emptyDistance;


                    /*
                                        graph[count].Time_Temp = srRead.GetString(22);  // �׷��� �ð� �б�
                                        srRead.GetBytes(23, 0, graph[count].Speed_Temp, 0, 65530);				
                                        srRead.GetBytes(24, 0, graph[count].Distance_Temp, 0, 65530);

                                        graph[count].Engine_Temp = srRead.GetString(25);   // ����
                                        graph[count].Sales_Temp = srRead.GetString(26);   // ����


                                        int gcnt = 0;
                                        for (int i = 0; i < graph[count].Time_Temp.Length; i++)
                                        {
                                            if (graph[count].Time_Temp[i] == '#')
                                            {
                                                gcnt++;
                                            }
                                        }

                                        graphcopy[count].Time_Temp = graph[count].Time_Temp;
                                        graphcopy[count].Sales_Temp = graph[count].Sales_Temp;
                                        graphcopy[count].Engine_Temp = graph[count].Engine_Temp;
                                        graphcopy[count].Door_Temp = graph[count].Door_Temp;
                                        graphcopy[count].OutTime = graph[count].OutTime;
                                        graphcopy[count].Distance_Temp = new byte[gcnt];
                                        graphcopy[count].Speed_Temp = new byte[gcnt];

                                        for (int i = 0; i < gcnt; i++)
                                        {
                                            graphcopy[count].Speed_Temp[i] = graph[count].Speed_Temp[i];
                                            graphcopy[count].Distance_Temp[i] = graph[count].Distance_Temp[i];
                                        }


                                        //graphcopy[count] = graph[count];
                                        count++;*/

                }

                conn1.Close();

            }
            if (tBoxData.totalCarNum > 0)
            {
                if ((tBoxData.i����ð� / 1440 != 0))
                {
                    int Day_calc = (tBoxData.i����ð� / 1440);
                    int hour_calc = ((tBoxData.i����ð� - (Day_calc * 1440)) / 60);
                    int min_calc = (tBoxData.i����ð� % 60);

                    tBoxData.h����ð� = String.Format("{0:D}�� {1:D}�ð� {2:D2}��", Day_calc, hour_calc, (tBoxData.i����ð� % 60));
                }
                else
                {

                    tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
                }
              //  tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
                tBoxData.h���ͼ��� = String.Format("{0:C} ��", tBoxData.i���ͼ���);
                tBoxData.h���Աݾ� = String.Format("{0:C} ��", tBoxData.i���Աݾ�);
                tBoxData.h�����Ÿ� = String.Format("{0:N} Km", tBoxData.i�����Ÿ�);
                tBoxData.h����Ÿ� = String.Format("{0:N} Km", tBoxData.i����Ÿ�);
                tBoxData.h���ᷮ = String.Format("{0} L", tBoxData.i���ᷮ);



                tBoxData.h���ӽð� = String.Format(overtime_total.Hours.ToString() + "�ð� " + overtime_total.Minutes.ToString() + "��");

                tBoxData.h������ȸ�� = String.Format("{0} ȸ", tBoxData.i������ȸ��);
                tBoxData.h����⺻ȸ�� = String.Format("{0} ȸ", tBoxData.i����⺻ȸ��);
                tBoxData.h��������ȸ�� = String.Format("{0} ȸ", tBoxData.i��������ȸ��);
                tBoxData.h�����⺻ȸ�� = String.Format("{0} ȸ", tBoxData.i�����⺻ȸ��);
                tBoxData.h��������ȸ�� = String.Format("{0} ȸ", tBoxData.i��������ȸ��);
                tBoxData.h������ȸ�� = String.Format("{0} ȸ", tBoxData.i������ȸ��);
                tBoxData.h����ȸ�� = String.Format("{0} ȸ", tBoxData.i����ȸ��);


             // SalesDays;
                tBoxData.h�����ð� = String.Format(SalesDays.ToString() + "��" + salestime_total.Hours.ToString() + "�ð� " + salestime_total.Minutes.ToString() + "��");
                tBoxData.h�����ð� = String.Format(emptytime_total.Days.ToString() + "��" + emptytime_total.Hours.ToString() + "�ð� " + emptytime_total.Minutes.ToString() + "��");
                tBoxData.hŰ���ȸ�� = String.Format("{0} ȸ", tBoxData.iŰ���ȸ��);
                tBoxData.h����ð� = String.Format("{0:D}�ð� {1:D2}��", (tBoxData.i����ð� / 60), (tBoxData.i����ð� % 60));
                tBoxData.h�����ð� = String.Format("{0:D}�ð� {1:D2}��", (int)(tBoxData.i�����ð� / 60), (tBoxData.i�����ð� % 60));
                tBoxData.h�����Ÿ� = String.Format("{0:N} Km", tBoxData.i�����Ÿ�);
                tBoxData.h������ = (tBoxData.i����Ÿ� > 0) ? String.Format("{0:#.##} %", (tBoxData.i�����Ÿ� / tBoxData.i����Ÿ�) * 100) : "0.00 %";

                int driveTIme = (((tBoxData.i�����ð�.Days * 24) + tBoxData.i�����ð�.Hours) * 60) + tBoxData.i�����ð�.Minutes;

                tBoxData.h����� = (tBoxData.i����ð� > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i����ð�) : "0.00 %";
                //tBoxData.h����� = (tBoxData.i����ð� > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i����ð� / (double)tBoxData.i����ð�) * 100) : "0.00 %";

                tBoxData.h����Km = (tBoxData.i�����Ÿ� > 0) ? String.Format("{0:C} ��", (double)tBoxData.i���ͼ��� / tBoxData.i�����Ÿ�) : "0.00 ��";


                FillDataSum();
                //FillData_graph();
            }

            formData.TotalRec = false;
        }
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
		private Bitmap memoryImage;
		private Bitmap memoryImage1;
		private void CaptureScreen()
		{

			Graphics mygraphics = this.CreateGraphics();
			Size s = this.Size;
			//s.Width -= 20;
			//s.Height -= 300;
			memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			IntPtr dc1 = mygraphics.GetHdc();
			IntPtr dc2 = memoryGraphics.GetHdc();


			BitBlt(dc2, 0, 0, this.ClientRectangle.Width-10, this.ClientRectangle.Height - 330, dc1, 10, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);
		}
        private void PreparePrint()
        {
            // Gets the list width and the columns width in units of hundredths of an inch.
            m_fListWidth = 0.0f;
            m_arColsWidth = new float[listView1.Columns.Count];

            Graphics g = CreateGraphics();
            m_fDpi = g.DpiX;
            g.Dispose();

            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                ColumnHeader ch = listView1.Columns[i];
                float fWidth = ch.Width / m_fDpi * 100 + 1; // Column width + separator
                m_fListWidth += fWidth;
                m_arColsWidth[i] = fWidth;
            }
            m_fListWidth += 1; // separator
        }

        public Image image;
        public Image[] imagea;
        int num = 2;
        public int curPageNumber;
		private void button4_Click(object sender, EventArgs e)
		{
            
            curPageNumber = 1;
			CaptureScreen();
			//	CaptureScreen1();
			PrintDocument pd = new PrintDocument();
			//	PrintPreviewDialog ppd = new PrintPreviewDialog();
			pd.PrintPage += new PrintPageEventHandler(Graph_PrintPage);
			printPreviewDialog1.Document = pd;
			printPreviewDialog1.ShowDialog();
		}

     
		private void Graph_PrintPage(object sender, PrintPageEventArgs e)
		{

              string path = Application.StartupPath + "\\WinTacho.ini";
                    string salesdetail = inicls.GetIniValue("Tacho Init", "Car_TotalRec_slaesdetail", path); // 


                    if (salesdetail != "1")
                    {
                        e.Graphics.DrawImage(memoryImage, 0, 0);
                        return;
                    }




            Graphics g = e.Graphics;
            StringFormat sfmt = new StringFormat();
          //  e.Graphics.DrawImage(memoryImage, 0, 0);


            if (curPageNumber == 1)
            {
                e.Graphics.DrawImage(memoryImage, 0, 0);
                PreparePrint();
                int nNextStartCol = 0; 			  // First column exeeding the page width
                float x1 = 0.0f;					  // Current horizontal coordinate
                float y1 = 0.0f;					  // Current vertical coordinate
                float cx = 4.0f;                  // The horizontal space, in hundredths of an inch,
                // of the padding between items text and
                // their cell boundaries.
                float fScale = 1.0f;              // Scale factor when fit to page is enabled
                float fRowHeight = 0.0f;		  // The height of the current row
                float fColWidth = 0.0f;		  // The width of the current column

                RectangleF rectFull;			  // The full available space
                RectangleF rectBody;			  // Area for the list items

                bool bUnprintable = false;

                ;

                if (g.VisibleClipBounds.X < 0)	// Print preview
                {
                    rectFull = e.MarginBounds;

                    // Convert to hundredths of an inch
                    rectFull = new RectangleF(rectFull.X / m_fDpi * 100.0f,
                        rectFull.Y,
                        rectFull.Width / m_fDpi * 100.0f,
                        rectFull.Height / m_fDpi * 100.0f);

                }
                else							// Print
                {
                    // Printable area (approximately) of the page, taking into account the user margins
                    rectFull = new RectangleF(
                        e.MarginBounds.Left - (e.PageBounds.Width - g.VisibleClipBounds.Width) / 2,
                        e.MarginBounds.Top - (e.PageBounds.Height - g.VisibleClipBounds.Height) / 2,
                        e.MarginBounds.Width,
                        e.MarginBounds.Height);
                    //rectFull = new RectangleF(x, y + 505, width, height);


                }

                rectBody = RectangleF.Inflate(rectFull, 0, -2 * Font.GetHeight(g));

                // Display title at top

                rectFull.Y += 330;
                sfmt.Alignment = StringAlignment.Center;
                m_strTitle = "�� ���� �� ������ ��" + " <����ȣ : " + compareObject + ">";
                g.DrawString(m_strTitle, Font, Brushes.Black, rectFull, sfmt);



                // Display page number at bottom
                sfmt.LineAlignment = StringAlignment.Far;
                //	g.DrawString("Page " + m_nPageNumber, Font, Brushes.Black, rectFull, sfmt);
                m_bFitToPage = true;
                if (m_nStartCol == 0 && m_bFitToPage && m_fListWidth > rectBody.Width)
                {
                    // Calculate scale factor
                    fScale = rectBody.Width / m_fListWidth;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////
                // Scale the printable area



                rectFull = new RectangleF(rectFull.X / fScale,
                                        rectFull.Y / fScale,
                                        rectFull.Width / fScale,
                                        rectFull.Height / fScale);

                //rectFull = new RectangleF(x, y + 305, width, height);


                rectBody = new RectangleF(rectBody.X / fScale,
                                         rectBody.Y / fScale,
                                          rectBody.Width / fScale,
                                          rectBody.Height / fScale);
                rectBody.Y += 350;

                /////////////////////////////////////////////////////////////////		

                // Setting scale factor and unit of measure
                g.ScaleTransform(fScale, fScale);
                g.PageUnit = GraphicsUnit.Inch;
                g.PageScale = 0.01f;

                // Start print
                nNextStartCol = 0;
                y1 = rectBody.Top;

                // Columns headers ----------------------------------------
                Brush brushHeader = new SolidBrush(Color.LightGray);
                Font fontHeader = new Font(this.Font, FontStyle.Bold);
                fRowHeight = fontHeader.GetHeight(g) * 3.0f;
                x1 = rectBody.Left;
                //	m_arColsWidth = new float[listView1.Columns.Count];


                for (int i = m_nStartCol; i < m_list.Columns.Count; i++)
                {
                    ColumnHeader ch = m_list.Columns[i];
                    fColWidth = m_arColsWidth[i];

                    if ((x1 + fColWidth) <= rectBody.Right)
                    {
                        // Rectangle
                        g.FillRectangle(brushHeader, x1, y1, fColWidth, fRowHeight);
                        g.DrawRectangle(Pens.Black, x1, y1, fColWidth, fRowHeight);

                        // Text
                        StringFormat sf = new StringFormat();
                        if (ch.TextAlign == HorizontalAlignment.Left)
                            sf.Alignment = StringAlignment.Near;
                        else if (ch.TextAlign == HorizontalAlignment.Center)
                            sf.Alignment = StringAlignment.Center;
                        else
                            sf.Alignment = StringAlignment.Far;

                        sf.LineAlignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.Trimming = StringTrimming.EllipsisCharacter;

                        RectangleF rectText = new RectangleF(x1 + cx, y1, fColWidth - 1 - 2 * cx, fRowHeight);
                        g.DrawString(ch.Text, fontHeader, Brushes.Black, rectText, sf);
                        x1 += fColWidth;
                    }
                    else
                    {
                        if (i == m_nStartCol)
                            bUnprintable = true;

                        nNextStartCol = i;
                        break;
                    }
                }
                y1 += fRowHeight;

                // Rows ---------------------------------------------------
                int nRow = m_nStartRow;
                bool bEndOfPage = false;
                int nNumItems = m_list.Items.Count;
                while (!bEndOfPage && nRow < nNumItems)
                {
                    ListViewItem item = m_list.Items[nRow];



                    fRowHeight = item.Bounds.Height / m_fDpi * 100.0f + 5.0f;

                    if (y1 + fRowHeight > 1230)
                    {
                        bEndOfPage = true;
                    }
                    else
                    {
                        x1 = rectBody.Left;

                        for (int i = m_nStartCol; i < m_list.Columns.Count; i++)
                        {
                            ColumnHeader ch = m_list.Columns[i];
                            fColWidth = m_arColsWidth[i];

                            if ((x1 + fColWidth) <= rectBody.Right)
                            {
                                // Rectangle
                                g.DrawRectangle(Pens.Black, x1, y1, fColWidth, fRowHeight);

                                // Text
                                StringFormat sf = new StringFormat();
                                if (ch.TextAlign == HorizontalAlignment.Left)
                                    sf.Alignment = StringAlignment.Near;
                                else if (ch.TextAlign == HorizontalAlignment.Center)
                                    sf.Alignment = StringAlignment.Center;
                                else
                                    sf.Alignment = StringAlignment.Far;

                                sf.LineAlignment = StringAlignment.Center;
                                sf.FormatFlags = StringFormatFlags.NoWrap;
                                sf.Trimming = StringTrimming.EllipsisCharacter;

                                // Text
                                string strText = i == 0 ? item.Text : item.SubItems[i].Text;
                                Font font = i == 0 ? item.Font : item.SubItems[i].Font;

                                RectangleF rectText = new RectangleF(x1 + cx, y1, fColWidth - 1 - 2 * cx, fRowHeight);
                                g.DrawString(strText, font, Brushes.Black, rectText, sf);
                                x1 += fColWidth;
                            }
                            else
                            {
                                nNextStartCol = i;
                                break;
                            }
                        }

                        y1 += fRowHeight;
                        nRow++;
                    }

                }

                if (nNextStartCol == 0)
                    m_nStartRow = nRow;

                m_nStartCol = nNextStartCol;

                m_nPageNumber++;

                e.HasMorePages = (!bUnprintable && (m_nStartRow > 0 && m_nStartRow < nNumItems) || m_nStartCol > 0);

                if (!e.HasMorePages)
                {
                    curPageNumber = 1; //�Ʒ��� ++����
                    m_nPageNumber = 2;
                    m_nStartRow = 0;
                    m_nStartCol = 0;
                }
                brushHeader.Dispose();

                if (m_list.Items.Count < 30)
                {
                    e.HasMorePages = false;
                    return;
                }
                curPageNumber++;
                e.HasMorePages = true;
            }
            else if (curPageNumber == 2 && (num == 3 || num == 4))
            {
                if (num == 3)
                {
                    e.Graphics.DrawImage(imagea[2], e.MarginBounds.Left - 70, 20);
                }
                else if (num == 4)
                {


                    e.Graphics.DrawImage(imagea[2], e.MarginBounds.Left - 70, 20);
                    e.Graphics.DrawImage(imagea[3], e.MarginBounds.Left - 70, 330);
                }
                e.HasMorePages = true;
                curPageNumber++;

            }
            else
            {
                //	compareObject
                //System.Threading.Thread.Sleep(1000); 
                //m_list.FitToPage
                PreparePrint();

                int nNumItems = m_list.Items.Count; // Number of items to print

                if (nNumItems == 0 || m_nStartRow >= nNumItems)
                {


                    e.HasMorePages = false;
                    return;
                }



                int nNextStartCol = 0; 			  // First column exeeding the page width
                float x1 = 0.0f;					  // Current horizontal coordinate
                float y1 = 0.0f;					  // Current vertical coordinate
                float cx = 4.0f;                  // The horizontal space, in hundredths of an inch,
                // of the padding between items text and
                // their cell boundaries.
                float fScale = 1.0f;              // Scale factor when fit to page is enabled
                float fRowHeight = 0.0f;		  // The height of the current row
                float fColWidth = 0.0f;		  // The width of the current column

                RectangleF rectFull;			  // The full available space
                RectangleF rectBody;			  // Area for the list items

                bool bUnprintable = false;

                ;

                if (g.VisibleClipBounds.X < 0)	// Print preview
                {
                    rectFull = e.MarginBounds;

                    // Convert to hundredths of an inch
                    rectFull = new RectangleF(rectFull.X / m_fDpi * 100.0f,
                        rectFull.Y,
                        rectFull.Width / m_fDpi * 100.0f,
                        rectFull.Height / m_fDpi * 100.0f);

                }
                else							// Print
                {
                    // Printable area (approximately) of the page, taking into account the user margins
                    rectFull = new RectangleF(
                        e.MarginBounds.Left - (e.PageBounds.Width - g.VisibleClipBounds.Width) / 2,
                        e.MarginBounds.Top - (e.PageBounds.Height - g.VisibleClipBounds.Height) / 2,
                        e.MarginBounds.Width,
                        e.MarginBounds.Height);
                    //rectFull = new RectangleF(x, y + 505, width, height);


                }

                rectBody = RectangleF.Inflate(rectFull, 0, -2 * Font.GetHeight(g));

                // Display title at top


                sfmt.Alignment = StringAlignment.Center;

         

                m_strTitle = "�� ���� �� ������ ��" + " <����ȣ : " + compareObject + ">";
                g.DrawString(m_strTitle, Font, Brushes.Black, rectFull, sfmt);


                // Display page number at bottom
                sfmt.LineAlignment = StringAlignment.Far;
                //	g.DrawString("Page " + m_nPageNumber, Font, Brushes.Black, rectFull, sfmt);
                m_bFitToPage = true;
                if (m_nStartCol == 0 && m_bFitToPage && m_fListWidth > rectBody.Width)
                {
                    // Calculate scale factor
                    fScale = rectBody.Width / m_fListWidth;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////
                // Scale the printable area



                rectFull = new RectangleF(rectFull.X / fScale,
                                        rectFull.Y / fScale,
                                        rectFull.Width / fScale,
                                        rectFull.Height / fScale);

                //rectFull = new RectangleF(x, y + 305, width, height);


                rectBody = new RectangleF(rectBody.X / fScale,
                                         rectBody.Y / fScale,
                                          rectBody.Width / fScale,
                                          rectBody.Height / fScale);


                /////////////////////////////////////////////////////////////////		

                // Setting scale factor and unit of measure
                g.ScaleTransform(fScale, fScale);
                g.PageUnit = GraphicsUnit.Inch;
                g.PageScale = 0.01f;

                // Start print
                nNextStartCol = 0;
                y1 = rectBody.Top;

                // Columns headers ----------------------------------------
                Brush brushHeader = new SolidBrush(Color.LightGray);
                Font fontHeader = new Font(this.Font, FontStyle.Bold);
                fRowHeight = fontHeader.GetHeight(g) * 3.0f;
                x1 = rectBody.Left;
                //	m_arColsWidth = new float[listView1.Columns.Count];


                for (int i = m_nStartCol; i < m_list.Columns.Count; i++)
                {
                    ColumnHeader ch = m_list.Columns[i];
                    fColWidth = m_arColsWidth[i];

                    if ((x1 + fColWidth) <= rectBody.Right)
                    {
                        // Rectangle
                        g.FillRectangle(brushHeader, x1, y1, fColWidth, fRowHeight);
                        g.DrawRectangle(Pens.Black, x1, y1, fColWidth, fRowHeight);

                        // Text
                        StringFormat sf = new StringFormat();
                        if (ch.TextAlign == HorizontalAlignment.Left)
                            sf.Alignment = StringAlignment.Near;
                        else if (ch.TextAlign == HorizontalAlignment.Center)
                            sf.Alignment = StringAlignment.Center;
                        else
                            sf.Alignment = StringAlignment.Far;

                        sf.LineAlignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.Trimming = StringTrimming.EllipsisCharacter;

                        RectangleF rectText = new RectangleF(x1 + cx, y1, fColWidth - 1 - 2 * cx, fRowHeight);
                        g.DrawString(ch.Text, fontHeader, Brushes.Black, rectText, sf);
                        x1 += fColWidth;
                    }
                    else
                    {
                        if (i == m_nStartCol)
                            bUnprintable = true;

                        nNextStartCol = i;
                        break;
                    }
                }
                y1 += fRowHeight;

                // Rows ---------------------------------------------------
                int nRow = m_nStartRow;
                bool bEndOfPage = false;
                bool firstpage = false;


                while (!bEndOfPage && nRow < nNumItems)
                {
                    ListViewItem item = m_list.Items[nRow];



                    fRowHeight = item.Bounds.Height / m_fDpi * 100.0f + 5.0f;

                    if (y1 + fRowHeight > rectBody.Bottom)
                    {
                        bEndOfPage = true;
                    }
                    else
                    {
                        x1 = rectBody.Left;

                        for (int i = m_nStartCol; i < m_list.Columns.Count; i++)
                        {
                            ColumnHeader ch = m_list.Columns[i];
                            fColWidth = m_arColsWidth[i];

                            if ((x1 + fColWidth) <= rectBody.Right)
                            {
                                // Rectangle
                                g.DrawRectangle(Pens.Black, x1, y1, fColWidth, fRowHeight);

                                // Text
                                StringFormat sf = new StringFormat();
                                if (ch.TextAlign == HorizontalAlignment.Left)
                                    sf.Alignment = StringAlignment.Near;
                                else if (ch.TextAlign == HorizontalAlignment.Center)
                                    sf.Alignment = StringAlignment.Center;
                                else
                                    sf.Alignment = StringAlignment.Far;

                                sf.LineAlignment = StringAlignment.Center;
                                sf.FormatFlags = StringFormatFlags.NoWrap;
                                sf.Trimming = StringTrimming.EllipsisCharacter;

                                // Text
                                string strText = i == 0 ? item.Text : item.SubItems[i].Text;
                                Font font = i == 0 ? item.Font : item.SubItems[i].Font;

                                RectangleF rectText = new RectangleF(x1 + cx, y1, fColWidth - 1 - 2 * cx, fRowHeight);
                                g.DrawString(strText, font, Brushes.Black, rectText, sf);
                                x1 += fColWidth;
                            }
                            else
                            {
                                nNextStartCol = i;
                                break;
                            }
                        }

                        y1 += fRowHeight;
                        nRow++;
                    }

                }

                if (nNextStartCol == 0)
                    m_nStartRow = nRow;

                m_nStartCol = nNextStartCol;

                m_nPageNumber++;

                e.HasMorePages = (!bUnprintable && (m_nStartRow > 0 && m_nStartRow < nNumItems) || m_nStartCol > 0);

                if (!e.HasMorePages)
                {
                    curPageNumber = 1; //�Ʒ��� ++����
                    m_nPageNumber = 2;
                    m_nStartRow = 0;
                    m_nStartCol = 0;
                }
                brushHeader.Dispose();
            }
			

				
		}

		private void button1_Click(object sender, EventArgs e)
		{
			formData.bSearchStartSel = false;
			this.Close();
		}

        ColumnSorter columnsorter = new ColumnSorter();

        private int flag = 0; 



        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {


         /*   columnsorter.currentColumn = e.Column;

            // ���� �����ߴ� �÷��� �ٸ��� ���� ���� ���� 
            if (columnsorter.previousColumn != columnsorter.currentColumn)
            {
                columnsorter.sort = Sorting.Ascending;
            }
            else    // ���� �����ߴ� �÷��� ������ 
            {
                switch (columnsorter.sort)
                {
                    case Sorting.Ascending:// ���������̿��ٸ� ���� �������� �ٲ۴�. 
                        columnsorter.sort = Sorting.Descending;
                        break;
                    case Sorting.Descending:
                        columnsorter.sort = Sorting.Ascending;
                        break;
                }
            }

            if (flag == 0)
            {
                listView1.ListViewItemSorter = columnsorter; // �ڵ����� listvHeader.Sort()�Լ��� ����ȴ�. 
                flag = 1;
            }
            else
            {
                listView1.Sort();
            }

            // ���� �����ߴ� �÷��� ����� �д�. 
            columnsorter.previousColumn = columnsorter.currentColumn;
            return; */
           
        /*    if (this.listView1.Sorting == SortOrder.Ascending || listView1.Sorting == SortOrder.None) 
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, "desc");
                listView1.Sorting = SortOrder.Descending; 
              
            } 
            else 
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, "asc");
                listView1.Sorting = SortOrder.Ascending; 
             
            }
            listView1.Sort();
            listView1.ListViewItemSorter = null;*/

            if (!this.click)   // ���⼭ this.click �� bool click �Դϴ�. ���������� ������ �ּ���.
            {

                this.listView1.ListViewItemSorter = new ListViewItemComparerASC(0x08);

                this.listView1.Sort();

                this.click = true;

            }

            else
            {

                this.listView1.ListViewItemSorter = new ListViewItemComparerDESC(0x08);

                this.listView1.Sort();

                this.click = false;

            }




        }
	}
}