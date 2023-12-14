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

            // 생성자를 통해 컬럼명, 사이즈, 정렬위치, 정렬 여부를 설정하도록 생성자를 오버로딩 해준다.
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

                    // 숫자 비교

                    if (Convert.ToInt32(((ListViewItem)x).SubItems[col].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[col].Text))
                    {

                        return 1;

                    }

                    else

                        return -1;

                }

                catch (Exception)
                {

                    // 텍스트 비교

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
            /// 컬럼과 정렬 기준(asc, desc)을 사용하여 정렬 함.
            /// </summary>
            /// <param name="column">몇 번째 컬럼인지를 나타냄.</param>
            /// <param name="sort">정렬 방법을 나타냄. Ex) asc, desc</param>
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

        //ListView에서 컬럼을 누르면 정렬이 되게 하기 위해... 
        public class ColumnSorter : IComparer
        {
            public int currentColumn = -1;  // 현재 선택한 컬럼 
            public int previousColumn = -1;  // 전에 선책한 컬럼      
            public Sorting sort = Sorting.Ascending;

            public int Compare(object x, object y)
            {
                ListViewItem rowA = (ListViewItem)x;
                ListViewItem rowB = (ListViewItem)y;
                int result = 0;
                switch (sort)
                {
                    case Sorting.Ascending:    // 오름차 정렬을 원할때 
                        result = String.Compare(rowA.SubItems[currentColumn].Text, rowB.SubItems[currentColumn].Text);
                        break;
                    case Sorting.Descending:    // 내림차순 정렬을 원할때 
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

			public string h운행시간;
			public string h미터수입;
			public string h실입금액;
			public string h영업거리;
			public string h주행거리;
			public string h연료량;
			public string h과속시간;
			public string h급제동회수;
			public string h주행기본회수;
			public string h주행이후회수;
			public string h할증기본회수;
			public string h할증이후회수;
			public string h문개폐회수;
			public string h영업회수;
			public string h영업시간;
			public string h공차시간;
			public string h키사용회수;
			public string h주행시간;
			public string h정차시간;
			public string h공차거리;
			public string h승차율;
			public string h운행률;
			public string h수입Km;
			public string h불사용회수;
			public string h불사용시간;

			public string y운행시간;
			public string y미터수입;
			public string y실입금액;
			public string y영업거리;
			public string y주행거리;
			public string y연료량;
			public string y과속시간;
			public string y급제동회수;
			public string y주행기본회수;
			public string y주행이후회수;
			public string y할증기본회수;
			public string y할증이후회수;
			public string y문개폐회수;
			public string y영업회수;
			public string y영업시간;
			public string y공차시간;
			public string y키사용회수;
			public string y주행시간;
			public string y정차시간;
			public string y공차거리;
			//public string y승차율;
			//public string y운행률;
			//public string y수입Km;

			public int i운행시간;
			public int i미터수입;
			public int i실입금액;
			public double i영업거리;
			public double i주행거리;
			public double i연료량;
			public TimeSpan i과속시간;
			public int i급제동회수;
			public int i주행기본회수;
			public int i주행이후회수;
			public int i할증기본회수;
			public int i할증이후회수;
			public int i문개폐회수;
			public int i영업회수;
			public TimeSpan i영업시간;
			public int i공차시간;
			public int i키사용회수;
			public int i불사용회수;
			public int i주행시간;
			public int i정차시간;
			public double i공차거리;
		}
		public void FillDataSum()
		{
			textBox운행시간.Text = tBoxData.h운행시간;
			textBox미터수입.Text = tBoxData.h미터수입;
			textBox실입금액.Text = tBoxData.h실입금액;
			textBox영업거리.Text = tBoxData.h영업거리;
			textBox주행거리.Text = tBoxData.h주행거리;
			textBox연료량.Text = tBoxData.h연료량;
			textBox과속시간.Text = tBoxData.h과속시간;
			textBox급제동회수.Text = tBoxData.h급제동회수;
			textBox주행기본회수.Text = tBoxData.h주행기본회수;
			textBox주행이후회수.Text = tBoxData.h주행이후회수;
			textBox할증기본회수.Text = tBoxData.h할증기본회수;
			textBox할증이후회수.Text = tBoxData.h할증이후회수;
			textBox문개폐회수.Text = tBoxData.h문개폐회수;
			textBox영업회수.Text = tBoxData.h영업회수;
			textBox영업시간.Text = tBoxData.h영업시간;
			textBox공차시간.Text = tBoxData.h공차시간;
			textBox키사용회수.Text = tBoxData.h키사용회수;
			//textBox주행시간.Text = tBoxData.h주행시간;
			//textBox정차시간.Text = tBoxData.h정차시간;
			textBox공차거리.Text = tBoxData.h공차거리;
			textBox승차율.Text = tBoxData.h승차율;
			textBox운행률.Text = tBoxData.h운행률;
			textBox수입Km.Text = tBoxData.h수입Km;

			//textBox불사용시간.Text = "0시간 00분";
			//textBox합승시간.Text = "0시간 00분";
			textBox수입리터.Text = "**.** 원";
			//textBox인정금액.Text = "0 원";
			//	textBox합승회수.Text = "0 회";
			//	textBox합승거리.Text = "0 Km";
			//	textBox지출금액.Text = "0 원";
			//	textBox불사용거리.Text = "0 Km";
			textBoxKm리터.Text = "**.** Km";
			//	textBox합승요금.Text = "0 원";
			//	textBox연료금액.Text = "0 원";
			//	textBox불사용요금.Text = "0 원";
			//	textBox불사용회수.Text = "0 회";
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
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트
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

            listView1.Columns.Add("번호", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("승차시간", 75, HorizontalAlignment.Right);
            listView1.Columns.Add("하차시간", 75, HorizontalAlignment.Right);
            listView1.Columns.Add("영업 (Km)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("요금 (원)", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("빈차 (Km)", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("빈차시간", 75, HorizontalAlignment.Right);
        //    listView1.Columns.Add("sort", 75, HorizontalAlignment.Right);

        
        
			if (formData.Dayseach_tacho == true)
			{
                Dirname = TACHO2_path + "\\타코";
			}
			else if (formData.Dayseach_tachoday == true)
			{
                Dirname = TACHO2_path + "\\타코 일별";
			}
			else if (formData.Dayseach_tacho2day == true)
			{
                Dirname = TACHO2_path + "\\타코 교대분리";
			}
			else if (formData.Dayseach_tachoauto == true)
			{
                Dirname = TACHO2_path + "\\타코 자동분리";
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
				//	continue;   // 차량번호별 집계시 타 차량번호 거르기
			
				while (srRead.Read())
				{
					

						compareObject = carnum;
						
						차번label.Text = "차 번 : " + compareObject;
						DateTime TimeSeach = new DateTime();
						DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
						DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);
						if (formData.TotalRec == false)
						{
							차번label.Visible = true;

                            if (sel == 0)
                            {
                                if ((srRead.GetString(1).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                                    continue;   // 차량번호별 집계시 타 차량번호 거르기
                            }
                            else if(sel==1)
                            {
                                  string tt =  srRead.GetString(2);
                                  if (tt != compareObject || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                                  {
                                      continue;  
                                  }


                              //  if ((srRead.GetString(2).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                              
                                //    continue;   // 기사 번호별 집계시 타 차량번호 거르기
                              
                               
                            }

							string driverNo = srRead.GetString(2);
							string driverName = srRead.GetString(3);

							운전자label.Visible = true;
							운전자label.Text = "운 전 자 : " + driverNo + " ( " + driverName + ")";
						}
						else
						{
							//DateTime TimeSeach = new DateTime();
						//	DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1,1,1);
							//DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);

							TimeSeach = srRead.GetDateTime(4);

							TimeSeach = new DateTime(TimeSeach.Year, TimeSeach.Month, TimeSeach.Day, 1,1,1);
							
							차번label.Visible = false;


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
							출고label.Visible = true;
							입고label.Visible = true;

							출고label.Text = "출 고 : " + OutTime_info;
							입고label.Text = "입 고 : " + InTime_info;
						}
						else
						{
							운전자label.Visible = true;
							운전자label.Text = "총 운행수 : " + Totalcnt.ToString() +"회";
							출고label.Visible = true;
							입고label.Visible = true;

							출고label.Text = "시 작 : " + starttime.Year.ToString() + "년" + starttime.Month.ToString() + "월" + starttime.Day.ToString() + "일" + " ~ ";
							입고label.Text = "    끝 : " + Endtime.Year.ToString() + "년" + Endtime.Month.ToString() + "월" + Endtime.Day.ToString() + "일";
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
                    Sales_Temp_str = srRead.GetString(26);   // 영업
                    Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기
                    stTime = srRead.GetDateTime(4);
                    string Engine_Temp = srRead.GetString(25);   // 엔진

                    srRead.GetBytes(24, 0, Distance_Temp, 0, 125000);  // 거리
                   


                    byte[] Sales_Detail = new byte[50000];
                    srRead.GetBytes(27, 0, Sales_Detail, 0, 50000);  // 상세영업
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

                    for (int a = 0; a < time_char.Length; a++)   // 데이터 갯수 파확 및 -> 다시 string  변환
                    {


                        if (time_char[a] != '#')
                        {
                            time[cntt] += time_char[a];
                        }
                        else
                        {
                            cntt++;			// 데이터 카운트
                        }


                    }

                    long[] time_long = new long[cntt];
                    DateTime[] datetime = new DateTime[cntt];
                    int totaltimecnt = 0;

                    for (int a = 0; a < time.Length; a++)
                    {
                        time_long[a] = Int64.Parse(time[a]);		// string  -> long 변환 
                        datetime[a] = DateTime.FromBinary(time_long[a]); // long -> DateTime 변환
                        //	speed_long[i] = Int32.Parse(speed[i]);			// string -> long  변환

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
                    tBoxData.i운행시간 += totaltimecnt;
                    /////////////////////////////////////////////////////////////////////////////////////////
					int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
				//	tBoxData.i운행시간 += driveT;

					int meterImport = (int)srRead.GetDecimal(6);
					tBoxData.i미터수입 += meterImport;


					int money_save = (int)srRead.GetDecimal(7);
					tBoxData.i실입금액 = money_save;

					double salesDistance = srRead.GetDouble(8);
					tBoxData.i영업거리 += salesDistance;

					double driveDistance = srRead.GetDouble(9);
					tBoxData.i주행거리 += driveDistance;

					double fuel = srRead.GetDouble(10);
					tBoxData.i연료량 += fuel;



					TimeSpan overT = new TimeSpan();					//과속시간
					Over_Time = srRead.GetDateTime(11);
					DateTime Over_Time_t = new DateTime(Over_Time.Year, Over_Time.Month, Over_Time.Day, 0, 0, 0);
					overT = Over_Time - Over_Time_t;
					overtime_total += overT;
					tBoxData.i과속시간 = overtime_total;


					int emerBreakCnt = srRead.GetInt32(12);
					tBoxData.i급제동회수 += emerBreakCnt;

					int driveBasicCnt = srRead.GetInt32(13);
					tBoxData.i주행기본회수 += driveBasicCnt;

					int driveAfterCnt = srRead.GetInt32(14);
					tBoxData.i주행이후회수 += driveAfterCnt;

					int addBasicCnt = srRead.GetInt32(15);
					tBoxData.i할증기본회수 += addBasicCnt;

					int addAfterCnt = srRead.GetInt32(16);
					tBoxData.i할증이후회수 += addAfterCnt;

					//graph[count].Door_Temp = srRead.GetString(17);  //door


					int salesCnt = srRead.GetInt32(18);
					tBoxData.i영업회수 += salesCnt;



					TimeSpan salesT = new TimeSpan();
					Sales_Time = srRead.GetDateTime(19);
                    DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
					salesT = Sales_Time - Sales_Time_t;

                    ////////////////////////////////////////////////////////////////////////////////////////

                    if (Sales_Time.Year != 1899)
                    {
                        SalesDays += Sales_Time.Day;     // 1899년도 아닌것만 더해야함 잘못되엇음!!!   19.09.26
                    }

                    salestime_total += salesT;         // 24시간 이상일때도 체크 해야함
                    tBoxData.i영업시간 = salestime_total;
               




					TimeSpan emptyT = new TimeSpan();					// 공차 시간
					emptyT = eT - salesT;
					emptytime_total += emptyT;

                  int kongcha =  totaltimecnt - ((salesT.Hours * 60) + salesT.Minutes);
               
                  tBoxData.i공차시간 += kongcha;
				//	tBoxData.i공차시간 += emptytime_total;

					int keyUseCnt = srRead.GetInt32(21);
					tBoxData.i키사용회수 += keyUseCnt;

					int riderT = 0;
					tBoxData.i주행시간 += riderT;

					int stopT = ((driveT > riderT) ? driveT - riderT : 0);
					tBoxData.i정차시간 += stopT;

					double emptyDistance = driveDistance - salesDistance;
					tBoxData.i공차거리 += emptyDistance;


                    
                    // 14.02.27  영업상세 데이터 출력 여부  데이터 많으면 시간이 오래 걸림 

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
                                        in_str = string.Format("{0:D2}:{1:D2}", in_hour, Sales_Data[k + q + sales_cnt]); //승차
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
                                        out_str = string.Format("{0:D2}:{1:D2}", out_hour, Sales_Data[k + q + sales_cnt]);  //하차
                                        a.SubItems.Add(out_str);
                                        break;

                                    case 6:
                                        Sales_Distance[0] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 7:
                                        Sales_Distance[1] = Sales_Data[k + q + sales_cnt];
                                        break;

                                    case 8:																	// 영업거리
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

                                    case 11:																	// 요금
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

                                    case 14:																	// 빈차거리
                                        Empty_Distance[2] = Sales_Data[k + q + sales_cnt];



                                        byte[] empty_byte = new byte[3];
                                        int emppty_temp = 0;

                                        if (first_empty_dist == false) //11.09.01 첫번째 빈차 계산 1분데이터 거리 합계 영업이 나오기전까지 -> 그래프와 동일값표현
                                        {

                                            emppty_temp = (int)(Distance_empty * 1000);

                                            empty_byte = BinToBcd24P(empty_byte, emppty_temp);

                                            empty = (double)((BcdToDecimal(empty_byte[2]) * 10000)
                                                    + (BcdToDecimal(empty_byte[1]) * 100)
                                                    + BcdToDecimal(empty_byte[0])) / 1000.0;

                                            first_empty_dist = true;


                                        }
                                        else // 이후 빈차 상세 영업 빈거리 세바이트로 사용 
                                        {


                                            empty = (double)((BcdToDecimal(Empty_Distance[2]) * 10000)
                                                        + (BcdToDecimal(Empty_Distance[1]) * 100)
                                                        + BcdToDecimal(Empty_Distance[0])) / 1000.0;
                                        }

                                        string empty_str = empty.ToString();
                                        a.SubItems.Add(empty_str);
                                        break;

                                    case 15:
                                        // 빈차 시간

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


                        if (!this.click)   // 여기서 this.click 는 bool click 입니다. 전역변수로 선언해 주세요.
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


                if ((tBoxData.i운행시간 / 1440 != 0))
                {
                    int Day_calc = (tBoxData.i운행시간 / 1440);
                    int hour_calc = ((tBoxData.i운행시간 - (Day_calc * 1440)) / 60);
                    int min_calc = (tBoxData.i운행시간 % 60);

                    tBoxData.h운행시간 = String.Format("{0:D}일 {1:D}시간 {2:D2}분", Day_calc, hour_calc, (tBoxData.i운행시간 % 60));
                }
                else
                {

                    tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
                }

			//	tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
				tBoxData.h미터수입 = String.Format("{0:C} 원", tBoxData.i미터수입);
				tBoxData.h실입금액 = String.Format("{0:C} 원", tBoxData.i실입금액);
				tBoxData.h영업거리 = String.Format("{0:N} Km", tBoxData.i영업거리);
				tBoxData.h주행거리 = String.Format("{0:N} Km", tBoxData.i주행거리);
				tBoxData.h연료량 = String.Format("{0} L", tBoxData.i연료량);



				tBoxData.h과속시간 = String.Format(overtime_total.Hours.ToString() + "시간 " + overtime_total.Minutes.ToString() + "분");

				tBoxData.h급제동회수 = String.Format("{0} 회", tBoxData.i급제동회수);
				tBoxData.h주행기본회수 = String.Format("{0} 회", tBoxData.i주행기본회수);
				tBoxData.h주행이후회수 = String.Format("{0} 회", tBoxData.i주행이후회수);
				tBoxData.h할증기본회수 = String.Format("{0} 회", tBoxData.i할증기본회수);
				tBoxData.h할증이후회수 = String.Format("{0} 회", tBoxData.i할증이후회수);
				tBoxData.h문개폐회수 = String.Format("{0} 회", tBoxData.i문개폐회수);
				tBoxData.h영업회수 = String.Format("{0} 회", tBoxData.i영업회수);

                if (SalesDays == 0)
                {
                    if (salestime_total.Days != 0)
                    {
                        tBoxData.h영업시간 = String.Format(salestime_total.Days.ToString() + "일" + salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                    }
                    else
                    {
                       tBoxData.h영업시간 = String.Format(salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                    }
                }
                else
                {
                    if (salestime_total.Days != 0)
                    {
                        SalesDays += salestime_total.Days;
                        tBoxData.h영업시간 = String.Format(SalesDays.ToString() + "일" + salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                    }
                    else
                    {
                        tBoxData.h영업시간 = String.Format(SalesDays.ToString() + "일" + salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                    }
                }
                int kongchatime = tBoxData.i운행시간 - (salestime_total.Days * 1440 + salestime_total.Hours * 60 + salestime_total.Minutes);
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
                       
                        tBoxData.h공차시간 = day.ToString() + "일 " + hour.ToString() + "시간 " + min.ToString() + "분 ";
                    }
                    else
                    {
                           tBoxData.h공차시간 = hour.ToString() + "시간 " + min.ToString() + "분 ";  // 운행시간
                    }


			//	tBoxData.h공차시간 = String.Format(emptytime_total.Days.ToString() +"일"+ emptytime_total.Hours.ToString() + "시간 " + emptytime_total.Minutes.ToString() + "분");
				tBoxData.h키사용회수 = String.Format("{0} 회", tBoxData.i키사용회수);
				tBoxData.h주행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i주행시간 / 60), (tBoxData.i주행시간 % 60));
				tBoxData.h정차시간 = String.Format("{0:D}시간 {1:D2}분", (int)(tBoxData.i정차시간 / 60), (tBoxData.i정차시간 % 60));
				tBoxData.h공차거리 = String.Format("{0:N} Km", tBoxData.i공차거리);
				tBoxData.h승차율 = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (tBoxData.i영업거리 / tBoxData.i주행거리) * 100) : "0.00 %";

				int driveTIme = (((tBoxData.i영업시간.Days * 24) + tBoxData.i영업시간.Hours) * 60) + tBoxData.i영업시간.Minutes;

				tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i운행시간) : "0.00 %";
				//tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";

				tBoxData.h수입Km = (tBoxData.i영업거리 > 0) ? String.Format("{0:C} 원", (double)tBoxData.i미터수입 / tBoxData.i영업거리) : "0.00 원";

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
                Dirname = TACHO2_path + "\\타코";
            }
            else if (formData.Dayseach_tachoday == true)
            {
                Dirname = TACHO2_path + "\\타코 일별";
            }
            else if (formData.Dayseach_tacho2day == true)
            {
                Dirname = TACHO2_path + "\\타코 교대분리";
            }
            else if (formData.Dayseach_tachoauto == true)
            {
                Dirname = TACHO2_path + "\\타코 자동분리";
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
                //	continue;   // 차량번호별 집계시 타 차량번호 거르기

                while (srRead.Read())
                {


                 //   compareObject = carnum;

                    차번label.Text = "차 번 : " + compareObject;
                    DateTime TimeSeach = new DateTime();
                    DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1, 1, 1);
                    DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);
                    if (formData.TotalRec == false)
                    {
                        차번label.Visible = true;
                        if ((srRead.GetString(1).Contains(compareObject) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                            continue;   // 차량번호별 집계시 타 차량번호 거르기
                        string driverNo = srRead.GetString(2);
                        string driverName = srRead.GetString(3);

                        운전자label.Visible = true;
                        운전자label.Text = "운 전 자 : " + driverNo + " ( " + driverName + ")";
                    }
                    else
                    {
                        //DateTime TimeSeach = new DateTime();
                        //	DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 1,1,1);
                        //DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 1, 1, 1);

                        TimeSeach = srRead.GetDateTime(4);

                        TimeSeach = new DateTime(TimeSeach.Year, TimeSeach.Month, TimeSeach.Day, 1, 1, 1);

                        차번label.Visible = false;


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
                        출고label.Visible = true;
                        입고label.Visible = true;

                        출고label.Text = "출 고 : " + OutTime_info;
                        입고label.Text = "입 고 : " + InTime_info;
                    }
                    else
                    {
                        운전자label.Visible = true;
                        운전자label.Text = "총 운행수 : " + Totalcnt.ToString() + "회";
                        출고label.Visible = true;
                        입고label.Visible = true;

                        출고label.Text = "시 작 : " + starttime.Year.ToString() + "년" + starttime.Month.ToString() + "월" + starttime.Day.ToString() + "일" + " ~ ";
                        입고label.Text = "    끝 : " + Endtime.Year.ToString() + "년" + Endtime.Month.ToString() + "월" + Endtime.Day.ToString() + "일";
                    }

                    //graph[count].OutTime = outT;

                    //DateTime inT = srRead.GetDateTime(5);
                    DateTime inT = readToday;
                    TimeSpan dT = inT - outT;
                    TimeSpan eT = dT;

                    int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
                    tBoxData.i운행시간 += driveT;

                    int meterImport = (int)srRead.GetDecimal(6);
                    tBoxData.i미터수입 += meterImport;


                    int money_save = (int)srRead.GetDecimal(7);
                    tBoxData.i실입금액 = money_save;

                    double salesDistance = srRead.GetDouble(8);
                    tBoxData.i영업거리 += salesDistance;

                    double driveDistance = srRead.GetDouble(9);
                    tBoxData.i주행거리 += driveDistance;

                    double fuel = srRead.GetDouble(10);
                    tBoxData.i연료량 += fuel;



                    TimeSpan overT = new TimeSpan();					//과속시간
                    Over_Time = srRead.GetDateTime(11);
                    DateTime Over_Time_t = new DateTime(Over_Time.Year, Over_Time.Month, Over_Time.Day, 0, 0, 0);
                    overT = Over_Time - Over_Time_t;
                    overtime_total += overT;
                    tBoxData.i과속시간 = overtime_total;


                    int emerBreakCnt = srRead.GetInt32(12);
                    tBoxData.i급제동회수 += emerBreakCnt;

                    int driveBasicCnt = srRead.GetInt32(13);
                    tBoxData.i주행기본회수 += driveBasicCnt;

                    int driveAfterCnt = srRead.GetInt32(14);
                    tBoxData.i주행이후회수 += driveAfterCnt;

                    int addBasicCnt = srRead.GetInt32(15);
                    tBoxData.i할증기본회수 += addBasicCnt;

                    int addAfterCnt = srRead.GetInt32(16);
                    tBoxData.i할증이후회수 += addAfterCnt;

                    //graph[count].Door_Temp = srRead.GetString(17);  //door


                    int salesCnt = srRead.GetInt32(18);
                    tBoxData.i영업회수 += salesCnt;



                    TimeSpan salesT = new TimeSpan();
                    Sales_Time = srRead.GetDateTime(19);
                    DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
                    salesT = Sales_Time - Sales_Time_t;
                    SalesDays += Sales_Time.Day; 
                    salestime_total += salesT;
                    tBoxData.i영업시간 = salestime_total;




                    TimeSpan emptyT = new TimeSpan();					// 공차 시간
                    emptyT = eT - salesT;
                    emptytime_total += emptyT;
                    tBoxData.i공차시간 += (emptytime_total.Hours*60 +emptytime_total.Minutes);

                    int keyUseCnt = srRead.GetInt32(21);
                    tBoxData.i키사용회수 += keyUseCnt;

                    int riderT = 0;
                    tBoxData.i주행시간 += riderT;

                    int stopT = ((driveT > riderT) ? driveT - riderT : 0);
                    tBoxData.i정차시간 += stopT;

                    double emptyDistance = driveDistance - salesDistance;
                    tBoxData.i공차거리 += emptyDistance;


                    /*
                                        graph[count].Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기
                                        srRead.GetBytes(23, 0, graph[count].Speed_Temp, 0, 65530);				
                                        srRead.GetBytes(24, 0, graph[count].Distance_Temp, 0, 65530);

                                        graph[count].Engine_Temp = srRead.GetString(25);   // 엔진
                                        graph[count].Sales_Temp = srRead.GetString(26);   // 영업


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
                if ((tBoxData.i운행시간 / 1440 != 0))
                {
                    int Day_calc = (tBoxData.i운행시간 / 1440);
                    int hour_calc = ((tBoxData.i운행시간 - (Day_calc * 1440)) / 60);
                    int min_calc = (tBoxData.i운행시간 % 60);

                    tBoxData.h운행시간 = String.Format("{0:D}일 {1:D}시간 {2:D2}분", Day_calc, hour_calc, (tBoxData.i운행시간 % 60));
                }
                else
                {

                    tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
                }
              //  tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
                tBoxData.h미터수입 = String.Format("{0:C} 원", tBoxData.i미터수입);
                tBoxData.h실입금액 = String.Format("{0:C} 원", tBoxData.i실입금액);
                tBoxData.h영업거리 = String.Format("{0:N} Km", tBoxData.i영업거리);
                tBoxData.h주행거리 = String.Format("{0:N} Km", tBoxData.i주행거리);
                tBoxData.h연료량 = String.Format("{0} L", tBoxData.i연료량);



                tBoxData.h과속시간 = String.Format(overtime_total.Hours.ToString() + "시간 " + overtime_total.Minutes.ToString() + "분");

                tBoxData.h급제동회수 = String.Format("{0} 회", tBoxData.i급제동회수);
                tBoxData.h주행기본회수 = String.Format("{0} 회", tBoxData.i주행기본회수);
                tBoxData.h주행이후회수 = String.Format("{0} 회", tBoxData.i주행이후회수);
                tBoxData.h할증기본회수 = String.Format("{0} 회", tBoxData.i할증기본회수);
                tBoxData.h할증이후회수 = String.Format("{0} 회", tBoxData.i할증이후회수);
                tBoxData.h문개폐회수 = String.Format("{0} 회", tBoxData.i문개폐회수);
                tBoxData.h영업회수 = String.Format("{0} 회", tBoxData.i영업회수);


             // SalesDays;
                tBoxData.h영업시간 = String.Format(SalesDays.ToString() + "일" + salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                tBoxData.h공차시간 = String.Format(emptytime_total.Days.ToString() + "일" + emptytime_total.Hours.ToString() + "시간 " + emptytime_total.Minutes.ToString() + "분");
                tBoxData.h키사용회수 = String.Format("{0} 회", tBoxData.i키사용회수);
                tBoxData.h주행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i주행시간 / 60), (tBoxData.i주행시간 % 60));
                tBoxData.h정차시간 = String.Format("{0:D}시간 {1:D2}분", (int)(tBoxData.i정차시간 / 60), (tBoxData.i정차시간 % 60));
                tBoxData.h공차거리 = String.Format("{0:N} Km", tBoxData.i공차거리);
                tBoxData.h승차율 = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (tBoxData.i영업거리 / tBoxData.i주행거리) * 100) : "0.00 %";

                int driveTIme = (((tBoxData.i영업시간.Days * 24) + tBoxData.i영업시간.Hours) * 60) + tBoxData.i영업시간.Minutes;

                tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i운행시간) : "0.00 %";
                //tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";

                tBoxData.h수입Km = (tBoxData.i영업거리 > 0) ? String.Format("{0:C} 원", (double)tBoxData.i미터수입 / tBoxData.i영업거리) : "0.00 원";


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
                m_strTitle = "♣ 영업 상세 데이터 ♣" + " <차번호 : " + compareObject + ">";
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
                    curPageNumber = 1; //아래에 ++있음
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

         

                m_strTitle = "♣ 영업 상세 데이터 ♣" + " <차번호 : " + compareObject + ">";
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
                    curPageNumber = 1; //아래에 ++있음
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

            // 전에 선택했던 컬럼과 다르면 오름 차순 정렬 
            if (columnsorter.previousColumn != columnsorter.currentColumn)
            {
                columnsorter.sort = Sorting.Ascending;
            }
            else    // 전에 선택했던 컬럼과 같을때 
            {
                switch (columnsorter.sort)
                {
                    case Sorting.Ascending:// 오름차순이였다면 내림 차순으로 바꾼다. 
                        columnsorter.sort = Sorting.Descending;
                        break;
                    case Sorting.Descending:
                        columnsorter.sort = Sorting.Ascending;
                        break;
                }
            }

            if (flag == 0)
            {
                listView1.ListViewItemSorter = columnsorter; // 자동으로 listvHeader.Sort()함수가 수행된다. 
                flag = 1;
            }
            else
            {
                listView1.Sort();
            }

            // 현재 선택했던 컬럼을 기억해 둔다. 
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

            if (!this.click)   // 여기서 this.click 는 bool click 입니다. 전역변수로 선언해 주세요.
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