using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using PrintableListView;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConvertTacho
{
    public delegate void ChildFormEventHandler(object sender, ChildFormEventArgs e);

    public partial class FormInfo : Form
    {
        public event ChildFormEventHandler OnNotifyParent;
        public string Sales_Temp_str = "";
        public Boolean m_bStart;
        public bool first_empty_dist = false;
        public int nCalledIndex;
        public List<int> listSelectedIndex;
        public List<string> listSelectedDriver;
        private List<int> listIndexAndID;
        private List<int> listCrashID;
        private int nSelectedIndex;
        private bool bIsFirstIDGet;
        private int[] nFirstAndLastID;
        private int nLastID;
        public int changedAMTime;
        public int changedPMTime;
        public Total total;
        private OleDbConnection conn;
        private OpenedDBInfo openDBInfo;
        FormData formData;
        public byte[] Distance_Temp = new byte[125000];
        public double Distance_empty = new double();
        public int Index_backup;
        public string Time_Temp = "";
        public string Sales_Temp = "";
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();
        public byte test = 0;
        private struct OpenedDBInfo
        {
            public string CarNo;
            public string DriverNo;
            //public string DriverName;
            public DateTime OutTime;
            public DateTime InTime;
            public string Title;
        }


        public struct Total
        {
            public uint tMoney;
            public double tDistS;
            public double tDisteD;

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
        int BinToBcd8(int n)
        {
            return ((int)((n / 10) << 4) + (n % 10));
        }
        public FormInfo(FormData f)
        {
            InitializeComponent();
            formData = f;
            m_list = new PrintableListView.PrintableListView();
            openDBInfo = new OpenedDBInfo();
            total = new Total();

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트

            m_bStart = true;
            nCalledIndex = 0;
            listSelectedIndex = new List<int>();
            listIndexAndID = new List<int>();
            listCrashID = new List<int>();
            nSelectedIndex = -1;
            bIsFirstIDGet = false;
            nFirstAndLastID = new int[2];
            nLastID = 0;
            changedAMTime = 4;
            changedPMTime = 16;
            ImageList dummyImageList = new ImageList();
            dummyImageList.ImageSize = new System.Drawing.Size(1, 18);
            listView1.SmallImageList = dummyImageList;
        }

        protected virtual void NotifyParent(ChildFormEventArgs e)
        {
            ChildFormEventHandler handler = OnNotifyParent;

            if (handler != null)
                handler(this, e);
        }

        public void FillDataEx(int index, int changeAM, int changePM)
        {
            changedAMTime = changeAM;
            changedPMTime = changePM + 12;
            FillData(index);
        }
        public int BcdToDecimal(byte bTemp)
        {
            return (((bTemp >> 4) * 10) + (bTemp & 0x0F));
        }

        public void FillData(int index)
        {
            DateTime StartTime = new DateTime(2015, 1, 1, 1, 1, 1);
            DateTime EndTime = new DateTime(2051, 1, 1, 1, 1, 1);
            try
            {
                Index_backup = index;
                nSelectedIndex = -1;
                listSelectedIndex.Clear();
                listIndexAndID.Clear();
                listCrashID.Clear();

                ///////////
                string DBstring = "";
                string NameDB = "";
                byte[] Sales_Temp = new byte[125000];
                if (formData.Db_backup == true)
                {

                    NameDB = TACHO2_path + formData.MdbFileName;

                    /*if ((opendlg == true || form1.tmpopen == true) && !columnclick)
                    {
                        //	MdbFileName = Application.StartupPath + "\\" + MdbFileName;
                        //	MdbFileName = "C:\\TACHO2" + "\\" + MdbFileName;
                    }*/

                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                    //					 Db_backup = false;


                }
                else
                {
                    //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////




                conn = new OleDbConnection(@DBstring);
                conn.Open();

                //  string queryRead = "SELECT * FROM TaxiInfor WHERE 인덱스=" + index.ToString() + " ORDER BY 날짜";
                // OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                //  OleDbDataReader srRead = commRead.ExecuteReader();

                string queryRead1 = "SELECT * FROM TblTacho WHERE ID=" + index.ToString();
                OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
                OleDbDataReader srRead1 = commRead1.ExecuteReader();

                //	string queryRead1 = "SELECT * FROM TblTacho ORDER BY ID";
                //	OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
                //	OleDbDataReader srRead1 = commRead1.ExecuteReader();

              

                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);


                while (srRead1.Read())
                {
                    Time_Temp = srRead1.GetString(22);  // 그래프 시간 읽기
                    stTime = srRead1.GetDateTime(4);
                    srRead1.GetBytes(27, 0, Sales_Temp, 0, 125000);  // 상세영업
                    Sales_Temp_str = srRead1.GetString(26);   // 영업
                    srRead1.GetBytes(24, 0, Distance_Temp, 0, 125000);  // 거리

                }
                double[] distance_double = new double[Sales_Temp_str.Length];
                char[] Sales_char = new char[Sales_Temp_str.Length];
                char[] time_char = new char[Time_Temp.Length];
                Distance_empty = 0;
                first_empty_dist = false;

                int timecnt = 0;

                for (int i = 0; i < Time_Temp.Length; i++)    // time db : string  -> char 
                {
                    time_char[i] = Time_Temp[i];

                    if (Time_Temp[i] == '#')
                    {
                        timecnt++;
                    }
                }
                int cnt = 0;
                string[] time = new string[timecnt];
                //	string[] speed = new string[timecnt];
                //	string[] distance = new string[timecnt];

                for (int i = 0; i < time_char.Length; i++)   // 데이터 갯수 파확 및 -> 다시 string  변환
                {


                    if (time_char[i] != '#')
                    {
                        time[cnt] += time_char[i];
                    }
                    else
                    {
                        cnt++;			// 데이터 카운트
                    }

                }

                long[] time_long = new long[cnt];

                DateTime[] datetime = new DateTime[cnt];

                for (int i = 0; i < time.Length; i++)
                {
                    time_long[i] = Int64.Parse(time[i]);		// string  -> long 변환 
                    datetime[i] = DateTime.FromBinary(time_long[i]); // long -> DateTime 변환
                    //	speed_long[i] = Int32.Parse(speed[i]);			// string -> long  변환

                }


                //////////////////////////////////

                for (int i = 0; i < Sales_Temp_str.Length; i++)    //Sales db : string  -> char 
                {
                    Sales_char[i] = Sales_Temp_str[i];

                }
                for (int i = 0; i < Sales_Temp_str.Length; i++)
                {

                    distance_double[i] = (double)(Distance_Temp[i]) / 10.0;

                    if (Sales_char[i] == '0')
                    {
                        if (first_empty_dist == false)
                        {
                            Distance_empty += distance_double[i];
                        }

                    }
                    else
                    {
                        first_empty_dist = true;
                    }
                }



                first_empty_dist = false;

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                int nCnt = 1;

                nCalledIndex = index;

                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.Columns.Add("번호", 60, HorizontalAlignment.Left);
                listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("승차시간", 80, HorizontalAlignment.Left);
                listView1.Columns.Add("하차시간", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("영업 (Km)", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("요금 (원)", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("빈차 (Km)", 110, HorizontalAlignment.Right);
                listView1.Columns.Add("빈차시간", 80, HorizontalAlignment.Right);

                bIsFirstIDGet = false;
                nFirstAndLastID[0] = nFirstAndLastID[1] = 0;

                total.tDisteD = 0;
                total.tDistS = 0;
                total.tMoney = 0;

                int DAtacnt = 0;


                //int hour = 0;

                int fdcnt = 0;
                for (int i = 0; i < Sales_Temp.Length; i++)
                {
                    if (Sales_Temp[i] == 0xfd)
                        fdcnt++;
                }

                byte[] Sales_Data = new byte[fdcnt * 34];

                for (int i = 0; i < Sales_Data.Length; i++)
                {
                    Sales_Data[i] = Sales_Temp[i];
                }

                

                int sales_cnt = 0;
                bool Year_chk = false;
                bool year_ = false;
                int year = 0;
                int empty_backup = 0;

                for (int j = 0; j < fdcnt; j++)
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
                  
                    /*stTachoDataCode.salesKm = (double)((BcdToDecimal(bArrTachoData[cnt + 3]) * 10000)
                                                                        + (BcdToDecimal(bArrTachoData[cnt + 2]) * 100)
                                                                        + BcdToDecimal(bArrTachoData[cnt + 1])) / 1000.0;

                    stTachoDataCode.money = ((BcdToDecimal(bArrTachoData[cnt + 8]) * 10000)
                                                            + (BcdToDecimal(bArrTachoData[cnt + 7]) * 100)
                                                            + BcdToDecimal(bArrTachoData[cnt + 6]));*/


                    for (int i = 0; i < 34; i++)
                    {

                        switch (i)
                        {


                            case 0:
                                Month_int = Sales_Data[i + j + sales_cnt];

                                if (Month_int == 0 || Month_int >12)
                                {
                                    i = 33;
                                    key = 0;
                                        break_stop=1;
                                    break;

                                }
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
                                Day_int = Sales_Data[i + j + sales_cnt];
                                string str = "";

                                if (year_ == false)
                                {
                                    str = string.Format("{0}.{1}.{2}", datetime[0].Year.ToString(), Month_int.ToString(), Day_int.ToString());
                                }
                                else
                                {
                                    str = string.Format("{0}.{1}.{2}", year.ToString(), Month_int.ToString(), Day_int.ToString());
                                }

                                a.SubItems.Add(str);

                                break;


                            case 2:
                                in_hour = Sales_Data[i + j + sales_cnt];
                                break;

                            case 3:
                                 in_str = string.Format("{0:D2}:{1:D2}", in_hour, Sales_Data[i + j + sales_cnt]); //승차
                                 if (year_ == false)
                                 {
                                     StartTime = new DateTime(datetime[0].Year, Month_int, Day_int, in_hour, Sales_Data[i + j + sales_cnt], 0);
                                 }
                                 else
                                 {
                                     StartTime = new DateTime(year, Month_int, Day_int, in_hour, Sales_Data[i + j + sales_cnt], 0);
                                 }

                               
                               

                               

                                a.SubItems.Add(in_str);
                                break;

                            case 4:
                                out_hour = Sales_Data[i + j + sales_cnt];
                                break;

                            case 5:
                               
                                TimeSpan tempTime = StartTime - EndTime;

                                if (EndTime < StartTime)
                                {
                                    empty_backup = (tempTime.Days * 1440) + (tempTime.Hours * 60) + tempTime.Minutes;
                                }

                                if (year_ == false)
                                {
                                    EndTime = new DateTime(datetime[0].Year, Month_int, Day_int, out_hour, Sales_Data[i + j + sales_cnt], 0);
                                }
                                else
                                {
                                    EndTime = new DateTime(year  , Month_int, Day_int, out_hour, Sales_Data[i + j + sales_cnt], 0);
                                }

                              
                                out_str = string.Format("{0:D2}:{1:D2}", out_hour, Sales_Data[i + j + sales_cnt]);  //하차
                                a.SubItems.Add(out_str);
                                break;

                            case 6:
                                Sales_Distance[0] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 7:
                                Sales_Distance[1] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 8:																	// 영업거리
                                Sales_Distance[2] = Sales_Data[i + j + sales_cnt];

                                distance = (double)((BcdToDecimal(Sales_Distance[0]) * 10000)
                                            + (BcdToDecimal(Sales_Distance[1]) * 100)
                                            + BcdToDecimal(Sales_Distance[2])) / 1000.0;

                                //	total.tDistS += distance;

                                string distance_str = string.Format("{0:N1} Km", distance.ToString());
                                a.SubItems.Add(distance_str);
                                break;

                            case 9:
                                Money[0] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 10:
                                Money[1] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 11:																	// 요금
                                Money[2] = Sales_Data[i + j + sales_cnt];

                                money = ((BcdToDecimal(Money[0]) * 10000)
                                                            + (BcdToDecimal(Money[1]) * 100)
                                                            + BcdToDecimal(Money[2]));
                                //	total.tMoney += (uint)money;
                                string money_str = string.Format("{0:C}", money);

                                a.SubItems.Add(money_str);
                                break;

                            case 12:
                                Empty_Distance[0] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 13:
                                Empty_Distance[1] = Sales_Data[i + j + sales_cnt];
                                break;

                            case 14:																	// 빈차거리
                                Empty_Distance[2] = Sales_Data[i + j + sales_cnt];

                                byte[] empty_byte = new byte[3];
                                int emppty_temp = 0;

                                if (first_empty_dist == false) //11.09.01 첫번째 빈차 계산 1분데이터 거리 합계 영업이 나오기전까지 -> 그래프와 동일값표현
                                {

                                    emppty_temp = (int)(Distance_empty * 1000);

                                    empty_byte = BinToBcd24P(empty_byte, emppty_temp);

                                    empty = (double)((BcdToDecimal(empty_byte[2]) * 10000)
                                            + (BcdToDecimal(empty_byte[1]) * 100)
                                            + BcdToDecimal(empty_byte[0])) / 1000.0;


                                }
                                else // 이후 빈차 상세 영업 빈거리 세바이트로 사용 
                                {


                                    empty = (double)((BcdToDecimal(Empty_Distance[2]) * 10000)
                                                + (BcdToDecimal(Empty_Distance[1]) * 100)
                                                + BcdToDecimal(Empty_Distance[0])) / 1000.0;
                                }




                                //	total.tDisteD += empty;

                                string empty_str = empty.ToString();
                                a.SubItems.Add(empty_str);
                                break;

                            case 15:
                                // 빈차 시간

                                int emptytime = Sales_Data[i + j + sales_cnt];

                                if (emptytime == 255)
                                {
                                   emptytime = empty_backup;
                                  //  MessageBox.Show("Test");
                                   // TimeSpan tempTime = StartTime - EndTime;
                                }
                                string empty_time = string.Format("{0:D2}:{1:D2}", emptytime / 60, emptytime % 60);
                                a.SubItems.Add(empty_time);
                                break;

                            case 18:



                                key = Sales_Data[i + j + sales_cnt];

                                break;
                            case 19:



                                break_stop = Sales_Data[i + j + sales_cnt];

                                if (key != 0 && break_stop != 1)
                                {
                                    first_empty_dist = true;
                                }

                                break;





                        }


                    }
                    sales_cnt += 33;

                    if (key != 0 && break_stop != 1)
                    {
                        nCnt++;
                        total.tMoney += (uint)money;
                        total.tDisteD += empty;
                        total.tDistS += distance;

                        listView1.Items.Add(a);
                    }

                }


                ListViewItem b = new ListViewItem("합계");
                b.SubItems.Add("");                             ///   공백 만들기
                b.SubItems.Add("");
                b.SubItems.Add("");

                string aa = string.Format("{0:N} Km", total.tDistS);  // 영업거리
                b.SubItems.Add(aa);
                aa = string.Format("{0:C}", total.tMoney);     // 미터수입
                b.SubItems.Add(aa);

                aa = string.Format("{0:#.##} Km", total.tDisteD);     // 빈차거리

                b.SubItems.Add(aa);
                b.SubItems.Add("");

                b.BackColor = System.Drawing.Color.LightGray;
                listView1.Items.Add(b);

                #region 열린 DB 정보 추출 -> 폼 제목 & 프린트 제목용
                {
                    string queryTbl = "SELECT * FROM TblTacho WHERE ID=" + nCalledIndex.ToString();
                    OleDbCommand commReadTbl = new OleDbCommand(queryTbl, conn);
                    OleDbDataReader srReadTbl = commReadTbl.ExecuteReader();

                    while (srReadTbl.Read())
                    {
                        openDBInfo.CarNo = srReadTbl.GetString(1);
                        openDBInfo.DriverNo = srReadTbl.GetString(2);
                        //openDBInfo.DriverName = srReadTbl.GetString(3);
                        openDBInfo.OutTime = srReadTbl.GetDateTime(4);
                        openDBInfo.InTime = srReadTbl.GetDateTime(5);
                    }
                }
                #endregion

                openDBInfo.Title = "영업";
                this.Text = "차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 상세 영업 정보";

                FillList(this.m_list, listView1);
                Year_chk = false;
                year_ = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                listView1.ContextMenuStrip = contextMenuStrip1;
                conn.Close();

            }

        }

        private void FormInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillData(nCalledIndex);
            buttonAutoCut.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonAutoCut.Enabled = false;

            try
            {

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //   string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryRead = "SELECT * FROM TaxiInfor WHERE 인덱스=" + nCalledIndex.ToString() + " ORDER BY 날짜";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);

                int nCnt = 1;

                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.Columns.Add("번호", 60, HorizontalAlignment.Left);
                listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("승차시간", 80, HorizontalAlignment.Left);
                listView1.Columns.Add("하차시간", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("영업 (Km)", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("요금 (원)", 80, HorizontalAlignment.Right);

                while (srRead.Read())
                {
                    if (!srRead.GetBoolean(8))
                        continue;

                    // ID
                    ListViewItem a = new ListViewItem(nCnt.ToString());
                    nCnt++;

                    // 날짜
                    string str = string.Format("{0}.{1}.{2}", srRead.GetDateTime(1).Year.ToString(), srRead.GetDateTime(1).Month.ToString(), srRead.GetDateTime(1).Day.ToString());
                    a.SubItems.Add(str);

                    // 승차시간
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(2).Hour, srRead.GetDateTime(2).Minute);
                    a.SubItems.Add(str);

                    // 하차시간
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(3).Hour, srRead.GetDateTime(3).Minute);
                    a.SubItems.Add(str);

                    // 영업
                    str = string.Format("{0:N} Km", srRead.GetDouble(4));
                    a.SubItems.Add(str);

                    // 요금
                    str = string.Format("{0:C}", srRead.GetDecimal(5));
                    a.SubItems.Add(str);

                    listView1.Items.Add(a);
                }

                openDBInfo.Title = "불사용";
                this.Text = "차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 상세 불사용 정보";

                FillList(this.m_list, listView1);
            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/
            }
            finally
            {
                listView1.ContextMenuStrip = null;
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonAutoCut.Enabled = false;

            try
            {

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //  string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryRead = "SELECT * FROM TaxiInfor WHERE 인덱스=" + nCalledIndex.ToString() + " ORDER BY 날짜";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);

                int nCnt = 1;

                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.Columns.Add("번호", 60, HorizontalAlignment.Left);
                listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("승차시간", 80, HorizontalAlignment.Left);
                listView1.Columns.Add("하차시간", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("영업 (Km)", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("요금 (원)", 80, HorizontalAlignment.Right);

                while (srRead.Read())
                {
                    if (!srRead.GetBoolean(9))
                        continue;

                    // ID
                    ListViewItem a = new ListViewItem(nCnt.ToString());
                    nCnt++;

                    // 날짜
                    string str = string.Format("{0}.{1}.{2}", srRead.GetDateTime(1).Year.ToString(), srRead.GetDateTime(1).Month.ToString(), srRead.GetDateTime(1).Day.ToString());
                    a.SubItems.Add(str);

                    // 승차시간
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(2).Hour, srRead.GetDateTime(2).Minute);
                    a.SubItems.Add(str);

                    // 하차시간
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(3).Hour, srRead.GetDateTime(3).Minute);
                    a.SubItems.Add(str);

                    // 영업
                    str = string.Format("{0:N} Km", srRead.GetDouble(4));
                    a.SubItems.Add(str);

                    // 요금
                    str = string.Format("{0:C}", srRead.GetDecimal(5));
                    a.SubItems.Add(str);

                    listView1.Items.Add(a);
                }

                openDBInfo.Title = "합승";
                this.Text = "차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 상세 합승 정보";

                FillList(this.m_list, listView1);
            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/
            }
            finally
            {
                listView1.ContextMenuStrip = null;
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonAutoCut.Enabled = false;

            try
            {

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //  string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryRead = "SELECT * FROM TaxiInfor WHERE 인덱스=" + nCalledIndex.ToString() + " ORDER BY 날짜";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);

                int nCnt = 1;

                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.Columns.Add("번호", 60, HorizontalAlignment.Left);
                listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
                listView1.Columns.Add("키 Off", 80, HorizontalAlignment.Left);
                listView1.Columns.Add("키 On", 80, HorizontalAlignment.Right);

                while (srRead.Read())
                {
                    if (srRead.GetBoolean(10))
                        continue;

                    // ID
                    ListViewItem a = new ListViewItem(nCnt.ToString());
                    nCnt++;

                    // 날짜
                    string str = string.Format("{0}.{1}.{2}", srRead.GetDateTime(1).Year.ToString(), srRead.GetDateTime(1).Month.ToString(), srRead.GetDateTime(1).Day.ToString());
                    a.SubItems.Add(str);

                    // 키 OFF
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(2).Hour, srRead.GetDateTime(2).Minute);
                    a.SubItems.Add(str);

                    // 키 ON
                    str = string.Format("{0:D2}:{1:D2}", srRead.GetDateTime(3).Hour, srRead.GetDateTime(3).Minute);
                    a.SubItems.Add(str);

                    listView1.Items.Add(a);
                }

                openDBInfo.Title = "엔진키";
                this.Text = "차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 상세 엔진키 정보";

                FillList(this.m_list, listView1);
            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/
            }
            finally
            {
                listView1.ContextMenuStrip = null;
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                nSelectedIndex = -1;
                listSelectedIndex.Clear();
                listIndexAndID.Clear();
                listCrashID.Clear();

                ///////////
                string DBstring = "";
                string NameDB = "";
                byte[] Emer_Temp = new byte[50000];
                if (formData.Db_backup == true)
                {

                    NameDB = TACHO2_path + formData.MdbFileName;


                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                    //					 Db_backup = false;


                }
                else
                {


                }

                conn = new OleDbConnection(@DBstring);
                conn.Open();



                string queryRead1 = "SELECT * FROM TblTacho WHERE ID=" + Index_backup.ToString();
                OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
                OleDbDataReader srRead1 = commRead1.ExecuteReader();



                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);


                while (srRead1.Read())
                {

                    srRead1.GetBytes(28, 0, Emer_Temp, 0, 50000);  //급제동데이터

                }
                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                int nCnt = 1;

                nCalledIndex = Index_backup;

                listView1.Items.Clear();
                listView1.Columns.Clear();

                listView1.Columns.Add("번호", 60, HorizontalAlignment.Center);
                listView1.Columns.Add("시간", 300, HorizontalAlignment.Center);
                listView1.Columns.Add("속도", 100, HorizontalAlignment.Center);
                //	listView1.Columns.Add("", 200, HorizontalAlignment.Center);


                int DAtacnt = 0;


                //int hour = 0;

                int fdcnt = 0;
                for (int i = 0; i < Emer_Temp.Length; i++)
                {
                    if (Emer_Temp[i] == 0xfd)
                        fdcnt++;
                }

                byte[] Emer_Data = new byte[fdcnt * 23];

                for (int i = 0; i < Emer_Data.Length; i++)
                {
                    Emer_Data[i] = Emer_Temp[i];
                }
                int emer_cnt = 0;
                Color AliceBlue = Color.FromArgb(240, 248, 255);
                Color LightPink = Color.FromArgb(255, 182, 193);

                for (int j = 0; j < fdcnt; j++)
                {


                    //	string str = string.Format("{0}.{1}.{2}", stTime.Year.ToString(), stTime.Month.ToString(), stTime.Day.ToString());
                    //	a.SubItems.Add(str);



                    int Year = 0;
                    int Month = 0;
                    int Dayy = 0;
                    int Hour = 0;
                    int Minute = 0;
                    int Sec = 0;
                    int Speed = 0;


                    nCnt = 1;
                    for (int i = 0; i < 23; i++)
                    {
                        ListViewItem a;
                        /*	if (i == 22)
                            {
                                a = new ListViewItem("");
                            }
                            else
                            {
                                a = new ListViewItem(nCnt.ToString());
                            }*/

                        a = new ListViewItem(nCnt.ToString());
                        switch (i)
                        {


                            case 0:
                                Year = Emer_Data[i + j + emer_cnt];
                                Year += 2000;
                                break;
                            case 1:
                                Month = Emer_Data[i + j + emer_cnt];
                                break;
                            case 2:
                                Dayy = Emer_Data[i + j + emer_cnt];
                                break;

                            case 3:
                                Hour = Emer_Data[i + j + emer_cnt];
                                break;

                            case 4:
                                Minute = Emer_Data[i + j + emer_cnt];
                                break;

                            case 5:
                                Sec = Emer_Data[i + j + emer_cnt];
                                nCnt -= 6;
                                break;

                            case 6:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                TimeSpan tt = new TimeSpan(0, 0, 15);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 7:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 14);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 8:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 13);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 9:
                                Speed = Emer_Data[i + j + emer_cnt];

                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 12);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 10:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 11);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 11:																	// 요금
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 10);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());

                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);

                                break;

                            case 12:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 9);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 13:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 8);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 14:																	// 빈차거리
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 7);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 15:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 6);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;

                            case 16:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 5);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;
                            case 17:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 4);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());


                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;
                            case 18:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 3);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;
                            case 19:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 2);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;
                            case 20:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);
                                tt = new TimeSpan(0, 0, 1);
                                stTime = stTime.Subtract(tt);
                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                listView1.Items.Add(a);
                                break;
                            case 21:
                                Speed = Emer_Data[i + j + emer_cnt];
                                stTime = new DateTime(Year, Month, Dayy, Hour, Minute, Sec);

                                a.SubItems.Add(stTime.ToString());
                                a.SubItems.Add(Speed.ToString() + " Km");
                                a.SubItems.Add("급제동 발생시점");
                                a.BackColor = LightPink;
                                listView1.Items.Add(a);
                                break;
                            case 22:
                                //a.BackColor = LightPink;				
                                //	listView1.Items.Add(a);
                                break;

                        }

                        nCnt++;
                    }
                    emer_cnt += 22;

                }
                openDBInfo.Title = "급제동";
                this.Text = "차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 급제동 정보";

                FillList(this.m_list, listView1);
            }
            catch (Exception ex)
            {
          //      MessageBox.Show(ex.Message);
            }
            finally
            {
                listView1.ContextMenuStrip = null;
                conn.Close();

            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            nSelectedIndex = e.ItemIndex;
        }

        private void 자르기설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nSelectedIndex < 1)
                return;

            foreach (int n in listSelectedIndex)
            {
                if (n == nSelectedIndex)
                {
                    buttonCut.Focus();
                    return;
                }
            }

            listSelectedIndex.Add(nSelectedIndex);

            Color lvBackColor = Color.White;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listSelectedIndex.Count; j++)
                {
                    if (listSelectedIndex[j] == i)
                    {
                        if (lvBackColor == Color.White)
                            lvBackColor = Color.Silver;
                        else
                            lvBackColor = Color.White;
                    }
                }

                listView1.Items[i].BackColor = lvBackColor;
            }

            buttonCut.Enabled = true;
            buttonCut.Focus();
        }

        private void 선택해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listSelectedIndex.Remove(nSelectedIndex);

            Color lvBackColor = Color.White;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listSelectedIndex.Count; j++)
                {
                    if (listSelectedIndex[j] == i)
                    {
                        if (lvBackColor == Color.White)
                            lvBackColor = Color.Silver;
                        else
                            lvBackColor = Color.White;
                    }
                }

                listView1.Items[i].BackColor = lvBackColor;
            }

            if (listSelectedIndex.Count == 0)
                buttonCut.Enabled = false;
            buttonCut.Focus();
        }

        private void 전체해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nSelectedIndex = -1;
            listSelectedIndex.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
                listView1.Items[i].BackColor = Color.White;

            buttonCut.Enabled = false;
            buttonCut.Focus();
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            listSelectedIndex.Sort();
            FillUpdateData();
        }

        private void FillUpdateData()
        {
            bool bIsUpdateSuccess = false;

            try
            {
                bool bIsStart = true;


                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////

                //   string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                #region Detect ID
                // [Graph] 변경될 지점의 ID 찾아내기
                int[] nIDGraph = new int[listSelectedIndex.Count];
                for (int k = 0; k < listSelectedIndex.Count; k++)
                {
                    DateTime sTime = new DateTime();
                    string queryDate = "SELECT * FROM TaxiInfor WHERE ID=" + listIndexAndID[listSelectedIndex[k]].ToString();
                    OleDbCommand commReadDate = new OleDbCommand(queryDate, conn);
                    OleDbDataReader srReadDate = commReadDate.ExecuteReader();

                    while (srReadDate.Read())
                    {
                        sTime = srReadDate.GetDateTime(1);
                    }

                    string queryDetect = "SELECT * FROM Graph WHERE 인덱스=" + nCalledIndex.ToString()
                    + " AND 날짜='" + sTime.ToString() + "'";
                    OleDbCommand commDetect = new OleDbCommand(queryDetect, conn);
                    OleDbDataReader srDetect = commDetect.ExecuteReader();

                    while (srDetect.Read())
                    {
                        nIDGraph[k] = srDetect.GetInt32(0);
                        break;
                    }
                }
                #endregion // Detect ID

                #region Detect TblTacho Last ID
                {
                    string queryTblTacho = "SELECT * FROM TblTacho ORDER BY ID DESC";
                    OleDbCommand commReadTblTachoLastID = new OleDbCommand(queryTblTacho, conn);
                    OleDbDataReader srReadTblTachoLastID = commReadTblTachoLastID.ExecuteReader();

                    while (srReadTblTachoLastID.Read())
                    {
                        nLastID = srReadTblTachoLastID.GetInt32(0);
                        nLastID++;
                        break;
                    }
                }
                #endregion // Detect TblTacho Last ID

                for (int i = 0; i < listSelectedIndex.Count; i++)
                {
                    int k = nLastID + i + 1;
                    string queryUpdate = "";

                    if (bIsStart)
                    {
                        bIsStart = false;

                        // [TaxiInfor] Data 시작지점부터 의미있는 Data 시작지점까지 채우기
                        queryUpdate = "UPDATE TaxiInfor SET detail=" + nLastID.ToString()
                            + " WHERE ID BETWEEN " + nFirstAndLastID[0].ToString()
                            + " AND " + listIndexAndID[listSelectedIndex[0]].ToString();
                        OleDbCommand commFisrtUpdate = new OleDbCommand(queryUpdate, conn);
                        commFisrtUpdate.ExecuteNonQuery();

                        // [Graph] Data 시작지점부터 의미있는 Data 시작지점까지 채우기
                        queryUpdate = "UPDATE Graph SET detail=" + nLastID.ToString()
                            + " WHERE 인덱스=" + nCalledIndex.ToString() + " AND ID<" + nIDGraph[0].ToString();
                        OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                        commFisrtDateUpdate.ExecuteNonQuery();
                    }

                    if (i == (listSelectedIndex.Count - 1))
                    {
                        // [TaxiInfor] 의미있는 Data 종료지점부터 Data 종료지점까지 채우기
                        queryUpdate = "UPDATE TaxiInfor SET detail=" + k.ToString()
                                            + " WHERE ID BETWEEN " + listIndexAndID[listSelectedIndex[i]].ToString()
                                            + " AND " + nFirstAndLastID[1].ToString();
                        OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                        commUpdate.ExecuteNonQuery();

                        // [Graph] 의미있는 Data 종료지점부터 Data 종료지점까지 채우기
                        queryUpdate = "UPDATE Graph SET detail=" + k.ToString()
                            + " WHERE 인덱스=" + nCalledIndex.ToString() + " AND ID>=" + nIDGraph[i].ToString();
                        OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                        commFisrtDateUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        //[TaxiInfor] 사이값 채우기
                        queryUpdate = "UPDATE TaxiInfor SET detail=" + k.ToString()
                                            + " WHERE ID BETWEEN " + listIndexAndID[listSelectedIndex[i]].ToString()
                                            + " AND " + listIndexAndID[listSelectedIndex[i + 1]].ToString();
                        OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                        commUpdate.ExecuteNonQuery();

                        // [Graph] 사이값 채우기
                        queryUpdate = "UPDATE Graph SET detail=" + k.ToString()
                            + " WHERE 인덱스=" + nCalledIndex.ToString()
                            + " AND ID>=" + nIDGraph[i].ToString()
                            + " AND ID<" + nIDGraph[i + 1].ToString();
                        OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                        commFisrtDateUpdate.ExecuteNonQuery();
                    }

                    bIsUpdateSuccess = true;
                }

                for (int i = 0; i <= listSelectedIndex.Count; i++)
                {
                    int k = nLastID + i;
                    string queryUpdate = "";
                    //[TaxiInfor] 사이값 채우기
                    queryUpdate = "UPDATE TaxiInfor SET 인덱스=" + k.ToString()
                                + " WHERE detail=" + k.ToString();
                    OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                    commUpdate.ExecuteNonQuery();

                    // [Graph] 사이값 채우기
                    queryUpdate = "UPDATE Graph SET 인덱스=" + k.ToString()
                                + " WHERE detail=" + k.ToString();
                    OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtDateUpdate.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 분리하는데 에러가 발생했습니다.", "오류");
                bIsUpdateSuccess = false;

                listSelectedIndex.Clear();
                listIndexAndID.Clear();
                nSelectedIndex = -1;
                bIsFirstIDGet = false;
                nFirstAndLastID = new int[2];
                nLastID = 0;
            }
            finally
            {
                listView1.ContextMenuStrip = contextMenuStrip1;
                conn.Close();

                if (bIsUpdateSuccess)
                {
                    UpdateTblTacho(nLastID);
                }
            }
        }

        private void UpdateTblTacho(int nLastID)
        {
            bool bIsUpdateSuccess = false;
            // Update & Insert용 변수 설정
            string CarNumber = "";
            string DriverNumber = "";
            //string DriverName = "";
            DateTime OutWarehouseTime = new DateTime();
            DateTime InWarehouseTime = new DateTime();
            double TodayTotalTradeDistance = 0.0;
            double TodayTotalEmptyDistance = 0.0;
            double TodayTotalDriveDistance = 0.0;
            decimal TodayIncomeMoney = 0;
            //double Fuel = 0.0;
            DateTime overrunTime = new DateTime(2010, 1, 1, 0, 0, 0);
            TimeSpan orT = new TimeSpan();
            int emerBreakCnt = 0;
            int driveBasicCnt = 0;
            int driveAfterCnt = 0;
            int premiumBasicCnt = 0;
            int premiumAfterCnt = 0;
            int doorOpenCnt = 0;
            int salesCnt = 0;
            int salesTime = 0;
            int carEmptyTime = 0;
            int keyUseCnt = 0;

            try
            {
                // Fill Data

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //  string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryTblTacho = "SELECT * FROM TblTacho WHERE ID=" + nCalledIndex.ToString();
                OleDbCommand commTblTacho = new OleDbCommand(queryTblTacho, conn);
                OleDbDataReader srRead = commTblTacho.ExecuteReader();

                while (srRead.Read())
                {
                    CarNumber = srRead.GetString(1);
                    DriverNumber = srRead.GetString(2);
                    //DriverName = srRead.GetString(3);
                }

                // Insert New Table
                for (int i = 0; i <= listSelectedIndex.Count; i++)
                {
                    int idx = nLastID + i;

                    // Calculate TblTacho form TaxiInfor
                    queryTblTacho = "SELECT * FROM TaxiInfor WHERE detail=" + idx.ToString();
                    commTblTacho = new OleDbCommand(queryTblTacho, conn);
                    srRead = commTblTacho.ExecuteReader();

                    bool bReadFirst = true;

                    while (srRead.Read())
                    {
                        if (bReadFirst)
                        {
                            OutWarehouseTime = srRead.GetDateTime(1);
                            bReadFirst = false;
                        }

                        if (srRead.GetBoolean(8) || srRead.GetBoolean(9) || !srRead.GetBoolean(10) || srRead.GetBoolean(11))
                            continue;


                        InWarehouseTime = srRead.GetDateTime(3);
                        TodayTotalTradeDistance += srRead.GetDouble(4);
                        TodayIncomeMoney += srRead.GetDecimal(5);
                        TodayTotalEmptyDistance += (srRead.GetDouble(6));
                        DateTime dt = srRead.GetDateTime(24);
                        DateTime bt = new DateTime(2010, 1, 1, 0, 0, 0);
                        orT += (dt - bt);
                        emerBreakCnt += srRead.GetInt32(23);
                        driveBasicCnt += srRead.GetInt32(15);
                        driveAfterCnt += srRead.GetInt32(16);
                        premiumBasicCnt += srRead.GetInt32(17);
                        premiumAfterCnt += srRead.GetInt32(18);
                        doorOpenCnt = 0;
                        salesCnt += srRead.GetInt32(19);
                        salesTime += srRead.GetInt32(20);
                        carEmptyTime += srRead.GetInt32(21);
                        keyUseCnt += srRead.GetInt32(22);
                    }
                    TodayTotalDriveDistance = TodayTotalTradeDistance + (TodayTotalEmptyDistance / 100);
                    overrunTime = overrunTime.AddMinutes(orT.Minutes);
                    overrunTime = overrunTime.AddHours(orT.Hours);
                    overrunTime = overrunTime.AddDays(orT.Days);

                    // Fill DB - TblTacho
                    queryTblTacho = "Insert into TblTacho (ID, 차량No, 기사No, 출고시간, 입고시간, "
                                    + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                                    + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                                    + "영업회수, 영업시간, 공차시간, 키사용"
                                    + ") values(?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?)";
                    commTblTacho = new OleDbCommand(queryTblTacho, conn);

                    commTblTacho.Parameters.Add("ID", OleDbType.Integer).Value = idx;
                    commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = CarNumber;
                    commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = DriverNumber;
                    //commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = "";
                    commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = OutWarehouseTime;
                    commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = InWarehouseTime;
                    commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = TodayIncomeMoney;
                    commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = 0;
                    commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = TodayTotalTradeDistance;
                    commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = TodayTotalDriveDistance;
                    commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = 0;// Fuel;
                    commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = overrunTime;
                    commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = emerBreakCnt;
                    commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = driveBasicCnt;
                    commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = driveAfterCnt;
                    commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = premiumBasicCnt;
                    commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = premiumAfterCnt;
                    commTblTacho.Parameters.Add("문개폐", OleDbType.Decimal).Value = doorOpenCnt;
                    commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = salesCnt;
                    commTblTacho.Parameters.Add("영업시간", OleDbType.Decimal).Value = salesTime;
                    commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = carEmptyTime;
                    commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = keyUseCnt;

                    commTblTacho.ExecuteNonQuery();

                    #region 변수 초기화
                    {
                        TodayTotalTradeDistance = 0;
                        TodayIncomeMoney = 0;
                        TodayTotalEmptyDistance = 0;

                        orT = new TimeSpan();
                        emerBreakCnt = 0;
                        driveBasicCnt = 0;
                        driveAfterCnt = 0;
                        premiumBasicCnt = 0;
                        premiumAfterCnt = 0;
                        salesCnt = 0;
                        salesTime = 0;
                        carEmptyTime = 0;
                        keyUseCnt = 0;
                    }
                    #endregion // 변수 초기화
                }

                bIsUpdateSuccess = true;
            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 업데이트 하는데 에러가 발생했습니다.", "오류");
                bIsUpdateSuccess = false;

                listSelectedIndex.Clear();
                listIndexAndID.Clear();
                nSelectedIndex = -1;
                bIsFirstIDGet = false;
                nFirstAndLastID = new int[2];
                nLastID = 0;
            }
            finally
            {
                conn.Close();

                if (bIsUpdateSuccess)
                {
                    DeleteDB();
                    //MessageBox.Show("데이터를 성공적으로 업데이트 했습니다.", listIndexAndID.Count.ToString() + " 분할");
                }
            }
        }

        private void DeleteDB()
        {
            bool bIsDeleteSuccess = false;

            try
            {
                // Fill Data

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //    string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryDelTblTacho = "DELETE * FROM TblTacho WHERE ID=" + nCalledIndex.ToString();
                OleDbCommand commDelTblTacho = new OleDbCommand(queryDelTblTacho, conn);
                commDelTblTacho.ExecuteNonQuery();
                bIsDeleteSuccess = true;
            }
            catch (Exception ex)
            {
                /* string path = Application.StartupPath + "\\ErrorLog.jie";
                 using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                 {
                     sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                 }*/

                MessageBox.Show("데이터를 삭제하는데 오류가 발생했습니다.", "오류");
                bIsDeleteSuccess = false;
            }
            finally
            {
                conn.Close();

                listSelectedIndex.Clear();
                listIndexAndID.Clear();
                nSelectedIndex = -1;
                bIsFirstIDGet = false;
                nFirstAndLastID = new int[2];
                nLastID = 0;

                if (bIsDeleteSuccess)
                {
                    ChildFormEventArgs evt = new ChildFormEventArgs("CCC");
                    NotifyParent(evt);

                    MessageBox.Show("데이터를 성공적으로 업데이트 했습니다.", listIndexAndID.Count.ToString() + " 분할");
                }
            }
        }

        private void buttonAutoCut_Click(object sender, EventArgs e)
        {
            listSelectedIndex.Clear();
            //listIndexAndID.Clear();
            listCrashID.Clear();
            nSelectedIndex = -1;

            CheckINISetting();

            // 저장된 교대시간1, 2
            bool bIsRotate1 = true;
            bool bIsOK = false;

            try
            {
                // Fill Data

                ///////////
                string DBstring = "";
                if (formData.Db_backup == true)
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
                    //					 Db_backup = false;


                }
                else
                {
                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }

                ///////////
                //   string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryAutoCut = "SELECT * FROM TaxiInfor WHERE 인덱스=" + nCalledIndex.ToString() + " ORDER BY 날짜";
                OleDbCommand commAutoCut = new OleDbCommand(queryAutoCut, conn);
                OleDbDataReader srRead = commAutoCut.ExecuteReader();

                bool bIsInFirstData = true;
                int cnt = 0;

                DateTime beforeInTime = new DateTime();
                DateTime beforeOutTime = new DateTime();

                while (srRead.Read())
                {
                    if (srRead.GetBoolean(8) || srRead.GetBoolean(9) || !srRead.GetBoolean(10) || srRead.GetBoolean(11))
                        continue;

                    cnt++;
                    DateTime InTime = srRead.GetDateTime(2);
                    DateTime OutTime = srRead.GetDateTime(3);

                    if (bIsInFirstData)
                    {
                        if ((OutTime.Hour >= changedAMTime) && (OutTime.Hour < changedPMTime))
                            bIsRotate1 = true;
                        else
                            bIsRotate1 = false;

                        beforeInTime = InTime;
                        beforeOutTime = OutTime;
                        bIsInFirstData = false;
                    }

                    TimeSpan tsInTime = InTime - beforeInTime;
                    TimeSpan tsOutTime = OutTime - beforeOutTime;

                    beforeInTime = InTime;
                    beforeOutTime = OutTime;

                    // 이건 다시한번 생각해보자.
                    if (tsInTime.Hours >= 12)
                    {
                        if ((OutTime.Hour >= changedAMTime) && (OutTime.Hour < changedPMTime))
                            bIsRotate1 = true;
                        else
                            bIsRotate1 = false;

                        nSelectedIndex = cnt - 1;
                        listSelectedIndex.Add(nSelectedIndex);
                    }

                    if (bIsRotate1)
                    {
                        if ((OutTime.Hour >= changedAMTime) && (OutTime.Hour < changedPMTime)
                            && (InTime.Hour >= changedAMTime) && (InTime.Hour < changedPMTime))
                        {
                            continue;
                        }
                        else
                        {
                            if ((OutTime.Hour < changedAMTime) || (OutTime.Hour >= changedPMTime)
                                && (InTime.Hour >= changedAMTime) && (InTime.Hour < changedPMTime))
                            {
                                listCrashID.Add(cnt - 1);
                                continue;
                            }
                            else
                            {
                                nSelectedIndex = cnt - 1;
                                listSelectedIndex.Add(nSelectedIndex);
                                bIsRotate1 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((OutTime.Hour < changedAMTime) || (OutTime.Hour >= changedPMTime)
                            && (InTime.Hour < changedAMTime) || (InTime.Hour >= changedPMTime))
                        {
                            continue;
                        }
                        else
                        {
                            if ((InTime.Hour < changedAMTime) || (InTime.Hour >= changedPMTime)
                                && (OutTime.Hour >= changedAMTime) && (OutTime.Hour < changedPMTime))
                            {
                                listCrashID.Add(cnt - 1);
                                continue;
                            }
                            else
                            {
                                nSelectedIndex = cnt - 1;
                                listSelectedIndex.Add(nSelectedIndex);
                                bIsRotate1 = true;
                            }
                        }
                    }
                }

                bIsOK = true;
            }
            catch (Exception ex)
            {
                /* string path = Application.StartupPath + "\\ErrorLog.jie";
                 using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                 {
                     sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                 }*/

                bIsOK = false;
            }
            finally
            {
                conn.Close();

                if (bIsOK)
                {
                    //자르기설정ToolStripMenuItem_Click(sender, e);
                    AutoCutDecoration();

                    if (listCrashID.Count > 0)
                    {
                        string msg = "교대시간으로 자르기 진행중에 총 (" + listCrashID.Count.ToString() + ")개의 충돌이 발견되었습니다."
                                    + "\r\n\r\n자동적으로 교대시간에 걸치는 데이터는 앞 기사님의 데이터로 분류됩니다.";
                        MessageBox.Show(msg, "자동 자르기 충돌");
                    }
                }
            }
        }

        private void AutoCutDecoration()
        {
            //listSelectedIndex.Remove(nSelectedIndex);

            Color lvBackColor = Color.White;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listSelectedIndex.Count; j++)
                {
                    if (listSelectedIndex[j] == i)
                    {
                        if (lvBackColor == Color.White)
                            lvBackColor = Color.Silver;
                        else
                            lvBackColor = Color.White;
                    }
                }

                listView1.Items[i].BackColor = lvBackColor;

                for (int k = 0; k < listCrashID.Count; k++)
                {
                    if (listCrashID[k] == i)
                    {
                        listView1.Items[i].BackColor = Color.Red;
                    }
                }
            }

            if (listSelectedIndex.Count == 0)
                buttonCut.Enabled = false;
            else
                buttonCut.Enabled = true;

            buttonCut.Focus();
        }

        private void CheckINISetting()
        {
            bool isDataFull = false;
            string path = Application.StartupPath + "\\datasetting.ini";

            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string line, destStr = "";
                    char[] dest = new char[20];
                    line = sr.ReadLine();

                    if (line.CompareTo("WinTacho Data Setting") == 0)
                    {
                        // 공백 Line 건너뛰기
                        line = sr.ReadLine();

                        // 최근자료보기(N)
                        line = sr.ReadLine();
                        // 볼 때마다 갯수 입력(1: Checked, 0: Uncheck)
                        line = sr.ReadLine();
                        // 자료 기본 보기 형태(0:최근, 1:주, 2:월, 3:분기, 4:년, 5:전체)
                        line = sr.ReadLine();
                        // 교대시간 개별설정
                        line = sr.ReadLine();

                        // 교대시간 오전
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        changedAMTime = Convert.ToInt32(destStr);
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        // 교대시간 오후
                        line = sr.ReadLine();
                        line.CopyTo(5, dest, 0, (line.Length - 5));

                        for (int i = 0; i < 20; i++)
                        {
                            if (dest[i] == '\0')
                                break;
                            destStr += dest[i];
                        }
                        changedPMTime = Convert.ToInt32(destStr) + 12;
                        destStr = "";
                        for (int j = 0; j < 20; j++) dest[j] = '\0';

                        isDataFull = true;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                    sw.Write("WinTacho Data Setting\r\n\r\n");
                    sw.Write("RC = 25\r\n");
                    sw.Write("CA = 0\r\n");
                    sw.Write("DV = 5\r\n");
                    sw.Write("CC = 0\r\n");
                    sw.Write("AM = 4\r\n");
                    sw.Write("PM = 4\r\n");
                }

                /*  string errpath = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(errpath, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/
            }
            finally
            {
                if (!isDataFull)
                {
                    changedAMTime = 4;
                    changedAMTime = 16;
                }
            }
        }

        private void buttonPrintSetting_Click(object sender, EventArgs e)
        {
            PrintPageSetup_FormInfo();
        }

        private void buttonPrintPreview_Click(object sender, EventArgs e)
        {

            PrintPreview_FormInfo();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

            //  Print_FormInfo();
            PrintPreview_FormInfo();
        }

        public void PrintPageSetup_FormInfo()
        {
            m_list.PageSetup();
        }

        public void PrintPreview_FormInfo()
        {
           // openDBInfo.OutTime.ToString("yyyy-MM-dd tt HH:mm:ss");
            m_list.Title = "[(" + openDBInfo.OutTime.ToString("yyyy-MM-dd tt HH:mm:ss") + ") ~ (" + openDBInfo.InTime.ToString("yyyy-MM-dd tt HH:mm:ss") + ")]"
                        + "\r\n차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 (" + openDBInfo.Title + ") 정보";

         //   m_list.Title = "[(" + openDBInfo.OutTime.ToString() + ") ~ (" + openDBInfo.InTime.ToString() + ")]"
         //              + "\r\n차량: [" + formData.CarArea + " " + formData.CarSign + " " + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 (" + openDBInfo.Title + ") 정보";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.PrintPreview();
        }

        public void Print_FormInfo()
        {
            m_list.Title = "[(" + openDBInfo.OutTime.ToString("yyyy-MM-dd tt HH:mm:ss") + ") ~ (" + openDBInfo.InTime.ToString("yyyy-MM-dd tt HH:mm:ss") + ")]"
                        + "\r\n차량: [" + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 (" + openDBInfo.Title + ") 정보";

         //   m_list.Title = "[(" + openDBInfo.OutTime.ToString() + ") ~ (" + openDBInfo.InTime.ToString() + ")]"
          //             + "\r\n차량: [" + formData.CarArea + " " + formData.CarSign + " " + openDBInfo.CarNo + "], 기사번호: [" + openDBInfo.DriverNo + "] 의 (" + openDBInfo.Title + ") 정보";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.Print();
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
                ch.TextAlign = HorizontalAlignment.Center;
                switch (nCol)
                {
                    case 0: ch.Width = 60; break;

                    case 1: ch.Width = 300; break;
                    case 3: ch.Width = 100; break;
                    case 4:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 150;
                        break;
                    case 5: ch.Width = 130; break;
                    case 6: ch.Width = 130; break;
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
        private void FillList1(ListView list, ListView table)
        {
            try
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
                        case 0: ch.Width = 60; break;

                        case 1: ch.Width = 250; break;
                        case 2: ch.Width = 100; break;
                        case 3: ch.Width = 200; break;

                        default:
                            //	ch.Width = 100;
                            break;
                    }
                    list.Columns.Add(ch);
                    nCol++;
                }
                int temp = 16;
                // Rows
                for (int n = 0; n < table.Items.Count; n++)
                {
                    ListViewItem item = new ListViewItem();
                    //item.Text = row[0].ToString();

                    if (n != temp)
                    {
                        item.Text = table.Items[n].Text;
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            if (i < 3)
                            {
                                item.SubItems.Add(table.Items[n].SubItems[i].Text);
                            }


                        }
                    }
                    else
                    {
                        item.Text = "";
                        temp += 17;
                    }


                    list.Items.Add(item);
                }

                list.ResumeLayout();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void button6_Click_1(object sender, EventArgs e)
        {
            string filePath = "c:\\test.xlsx";
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            int colIndex = 0;
            int rowIndex = 1;
            excel.Application.Workbooks.Add(true);

            for (int i = 0; i < this.listView1.Columns.Count; i++)
            {
                colIndex++;
                excel.Cells[1, colIndex] = this.listView1.Columns[i].Text;
            }
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                rowIndex++;
                colIndex = 0;
                for (int j = 0; j < this.listView1.Items[i].SubItems.Count; j++)
                {
                    colIndex++;
                    excel.Cells[rowIndex, colIndex] = this.listView1.Items[i].SubItems[j].Text;
                    //     excel.Cells.AutoOutline();

                }
            }
            excel.Visible = true;
        }
    }

    public class ChildFormEventArgs : EventArgs
    {
        private readonly string message;

        public ChildFormEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return this.message; }
        }
    }
}