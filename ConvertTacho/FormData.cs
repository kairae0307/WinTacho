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
using ZedGraph;
using ListViewEx;
using System.Drawing.Printing;


namespace ConvertTacho
{
    public partial class FormData : Form
    {

        public string combo_car_str = "";
        public string combo_driver_str = "";
        FormDayInfo formDayInfo;
        public bool Carilbo = false;
        public bool Driverilbo = false;
        public bool Car_Driverilbo = false;
        public bool car_driverCheck = false;
        public bool driverCheck = false;
        public bool CarCheck = false;
        private iniClass inicls = new iniClass();
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
        public bool Db_backup = false;
        private Control[] Editors;
        public bool print_start = false;
        public int ID = 1;
        public int indexid = 1;
        public int OverSpeed = 0;

        public double xval = 0;
        public string xval_str = "";
        public int StandardCnt = 0;


        public bool PremiumBasicChk = false;
        public bool PremiumAfterChk = false;
        public bool DriveBasicChk = false;
        public bool DriveAfterChk = false;
        public bool SalesChk = false;
        public bool KeyChk = false;
        public bool breakstopChk = false;
        public bool TachoMove = false;
        public bool TachoCut = false;
        public bool DayInfoEdit = false;


        public bool TotalRec_print = false;
        public bool TotalRec = false;
        public bool Dayseach_tacho = false;
        public bool Dayseach_tachoday = false;
        public bool Dayseach_tacho2day = false;
        public bool Dayseach_tachoauto = false;
        public bool opendlg = false;
        public bool columnclick = false;
        public bool MonthSeach = false;
        public string TACHO2_path = "";
        public bool daysearchcar = false;

        private OleDbConnection conn;
        private OpenedDBInfo openDBInfo;

        public string MdbFileName = "";
        public string Mdb_CutNameA = "";
        public string Mdb_CutNameB = "";
        public string MdbMove_file = "";
        public string CarArea = "";
        public string CarNumber = "";
        public char CarSign;
        public string yymmdd = "";


        public bool Repaet_btn = false;


        public struct TachoData_ORG
        {
            public string CarNo;
            public string DrvNo;
            public string DrvName;
            public string door;
            public string Graph_Time;
            public byte[] Graph_Speed;
            public byte[] Graph_Dist;
            public string Graph_Engine;
            public string Graph_Sales;
            public byte[] Sales_Detail;
            public int PremiumBasic;
            public int PremiumAfter;
            public int DriveBasic;
            public int DriveAfter;
            public int SalesCnt;
            public int breakstop;
            public int KeyCnt;
            public TimeSpan SalesTime;
            public TimeSpan SalesTimeTotalA;
            public DateTime OutTime;
            public DateTime InTime;
            public int MeterMoney;
            public int RealMoney;
            public double SalesDist;
            public double TotalDist;
            public double fuel;
            public DateTime OverTime;
            public int QuickBreak;
            public byte[] QuickStopData;




        }

        public struct TachoData_A
        {
            public string CarNo;
            public string DrvNo;
            public string DrvName;
            public string door;
            public string Graph_Time;
            public byte[] Graph_Speed;
            public byte[] Graph_Dist;
            public string Graph_Engine;
            public string Graph_Sales;
            public byte[] Sales_Detail;
            public int PremiumBasic;
            public int PremiumAfter;
            public int DriveBasic;
            public int DriveAfter;
            public int SalesCnt;
            public int breakstop;
            public int KeyCnt;
            public int SalesTime;
            public TimeSpan SalesTimeTotalA;
        }
        public struct TachoData_B
        {
            public string CarNo;
            public string DrvNo;
            public string DrvName;
            public string door;
            public string Graph_Time;
            public byte[] Graph_Speed;
            public byte[] Graph_Dist;
            public string Graph_Engine;
            public string Graph_Sales;
            public byte[] Sales_Detail;
            public int PremiumBasic;
            public int PremiumAfter;
            public int DriveBasic;
            public int DriveAfter;
            public int SalesCnt;
            public int breakstop;
            public int KeyCnt;
            public int SalesTime;
            public TimeSpan SalesTimeTotalB;
        }



        private struct OpenedDBInfo
        {
            public string CarNo;
            public string DriverNo;
            //public string DriverName;
            public DateTime OutTime;
            public DateTime InTime;
            public string Title;
        }

        public Boolean m_bStart;
        public Boolean isFormDataDetailFormShow = false;
        public FormInfo formInfo;
        public FormGraph formGraph;
        public FormOpenMonth formOpenMonth;

        public FormDayInfo formdayInfo;
        public FormDayInfoCal formDayInfoCal;
        public FormMonthTacho formMonthTacho;
        //	public ChartForm chartform;


        public ListView listViewSel;

        public int nOpenedindex = 0;

        public int selectedColumnIndex = 4;
        public int selectedOrder = 1;


        //  마지막 디비 리브뷰에 추가
        public bool Last_db_cnt = false;

        // 세부 검색창 활성화 여부
        public bool bIsDetail = false;
        // 수입
        public bool bCompareMoneySel;
        public bool bCompareMoneyUpper;
        public int nCompareMoney;
        // 차량 선택
        public bool bCarSel;
        public bool bCarTotalSel;
        public List<int> nlCarSel;
        // 기사 선택
        public bool bDrvSel;
        public bool bDrvTotalSel;
        public List<int> nlDrvSel;
        // 과속
        public bool bOverDriveSel;
        // 급제동
        public bool bEmerBreakSel;
        // 출고일
        public bool bOutDaySel;
        public DateTime dtOutDay;
        // 입고일
        public bool bInDaySel;
        public DateTime dtInDay;
        // 주행 기본
        public bool bDriveBasicSel;
        public bool bDriveBasicUpper;
        public int nDriveBasic;
        // 주행 이후
        public bool bDriveAfterSel;
        public bool bDriveAfterUpper;
        public int nDriveAfter;
        // 할증 기본
        public bool bAddBasicSel;
        public bool bAddBasicUpper;
        public int nAddBasic;
        // 할증 이후
        public bool bAddAfterSel;
        public bool bAddAfterUpper;
        public int nAddAfter;
        // 검색 시작일
        public bool bSearchStartSel;
        public DateTime dtSearchStartDay;
        public bool bSearchStartAM;
        public int nSearchStartHour;
        // 검색 종료일
        public bool bSearchEndSel;
        public DateTime dtSearchEndDay;
        public bool bSearchEndAM;
        public int nSearchEndHour;
        public bool SortCheck = false;


        private struct DataSetting
        {
            public int nRecentDataCount;
            public bool bInputNumberAnytime;
            public int nIndexOfDefaultViewItem;
            public bool bCheckedChangeSet;
            public int nIndexOfChangeAMHour;
            public int nIndexOfChangePMHour;
        }

        public struct Total
        {
            public int tMoney;
            public int tB;
            public int tDB;
            public int tDA;
            public int tAB;
            public int tAA;
            public double tDistS;
            public double tDistD;
            public TimeSpan tOverD;
        }
        public struct TotalA
        {
            public int tMoney;
            public double tDistS;
            public double tDisteD;

        }
        public struct TotalB
        {
            public int tMoney;
            public double tDistS;
            public double tDisteD;

        }


        private DataSetting ds;
        public Total total;
        public TotalA totalA;
        public TotalB totalB;

        public int nUserRecentDataCount = -1;
        Form1 form1;
        public void LoadingWork()    // LoadThread Funtion
        {
            bool _shouldStop;

            //	tmf_data(strFname);

            Repeat_Data();
            _shouldStop = true;


        }


        public class Worker
        {
            // This method will be called when the thread is started.			
            FormLoad formload = new FormLoad();
            public void DoWork()                             // Loading Form
            {

                formload.StartPosition = FormStartPosition.Manual;

                formload.Location = new Point(800, 400);
                formload.ShowDialog();

            }
            public void RequestStop()
            {
                _shouldStop = true;
                formload.Close();

            }
            private volatile bool _shouldStop;
        }


        public FormData(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            m_bStart = true;

            m_list = new PrintableListView.PrintableListView();

            formInfo = new FormInfo(this);
            formInfo.OnNotifyParent += new ChildFormEventHandler(formInfo_OnNotifyParent);

            formGraph = new FormGraph(this);

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트


            total = new Total();
            totalA = new TotalA();
            ds = new DataSetting();

            listViewSel = new ListView();

            listSelectedIndex = new List<int>();
            listIndexAndID = new List<int>();
            listCrashID = new List<int>();
            nSelectedIndex = -1;

            ToolTip toolTip1 = new ToolTip();

            buttonDataAdd.Visible = false;

            ImageList dummyImageList = new ImageList();
            dummyImageList.ImageSize = new System.Drawing.Size(1, 18);
            listView1.SmallImageList = dummyImageList;

            button11.Visible = false;  // 총량제
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;


            if (form1.radioButton_타코.Checked)
            {
                Dayseach_tacho = true;
                Dayseach_tacho2day = false;
                Dayseach_tachoday = false;
                Dayseach_tachoauto = false;
            }
            else if (form1.radioButton_1day.Checked)
            {
                Dayseach_tacho = false;
                Dayseach_tacho2day = false;
                Dayseach_tachoday = true;
                Dayseach_tachoauto = false;
            }
            else if (form1.radioButton_2day.Checked)
            {
                Dayseach_tacho = false;
                Dayseach_tacho2day = true;
                Dayseach_tachoday = false;
                Dayseach_tachoauto = false;
            }
            else if (form1.radioButton_auto.Checked)
            {
                Dayseach_tacho = false;
                Dayseach_tacho2day = false;
                Dayseach_tachoday = false;
                Dayseach_tachoauto = true;
            }

            /*	this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
             * 
             * 


                // 폼을 화면의 위치하도록 설정
                this.Left = 0;
                this.Top = 0;*/

            this.Height = form1.Height - 200;

            InputDefaultDataSetting();
        }

        private void formInfo_OnNotifyParent(object sender, ChildFormEventArgs e)
        {
            if (e.Message == "CCC")
            {
                formGraph.Visible = false;
                formInfo.Visible = false;

                FillData(selectedColumnIndex, selectedOrder);
            }
        }
        public void DellWork()    // LoadThread Funtion
        {
            bool _shouldStop;

            List<int> liID = new List<int>();


            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));
                listView1.SelectedItems[i].Remove();

            }

            //	liID.Sort();

            if (DeleteDB(liID))
            {
                //	FillData(0, 1);

                MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");
            }



            _shouldStop = true;
        }
        private void InputDefaultDataSetting()
        {
            bool isDataFull = false;
            ds.nRecentDataCount = 100000;
            ds.bInputNumberAnytime = false;
            ds.nIndexOfDefaultViewItem = 5;
            ds.bCheckedChangeSet = true;
            ds.nIndexOfChangeAMHour = 11;
            ds.nIndexOfChangePMHour = 11;


        }



        public void FillData(int ColumnIdx, int Order)
        {


            InputDefaultDataSetting();
            string NameDB = "";

            listView1.Columns[4].Text = "출고 시간";
            listView1.Columns[5].Text = "입고 시간";
            try
            {
                string DBstring = "";


                if (Db_backup == true)
                {

                    NameDB = form1.TACHO2_path + "\\" + MdbFileName;
                    /*if ((opendlg == true || form1.tmpopen == true) && !columnclick)
                    {
                        //	MdbFileName = Application.StartupPath + "\\" + MdbFileName;
                        //	MdbFileName = "C:\\TACHO2" + "\\" + MdbFileName;
                    }*/

                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                    //					 Db_backup = false;
                    if (columnclick == true)
                    {
                        columnclick = false;
                    }

                }
                else
                {
                    //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

                }
                OleDbConnection conn = new OleDbConnection(@DBstring);
                conn.Open();
                string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + form1.TACHO2_path + "\\Information.mdb";
                Infostring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + form1.TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";

                OleDbConnection connInfo = new OleDbConnection(Infostring);
                connInfo.Open();






                string formname = "";
                FileInfo file = new FileInfo(MdbFileName);

                formname = file.Name;
                char[] trimChars = { '.', 'm', 'd', 'b' };

                formname = formname.TrimEnd(trimChars);

                this.Text = yymmdd;


                string queryRead = "SELECT * FROM TblTacho";

                int[] RecentID = new int[ds.nRecentDataCount];
                if (!bIsDetail)
                {
                    if (ds.nIndexOfDefaultViewItem == 0)        // 최근 자료
                    {
                        if (ds.bInputNumberAnytime)
                        {
                            FormInputDBCount fiDBC = new FormInputDBCount(this);
                            fiDBC.StartPosition = FormStartPosition.CenterParent;
                            fiDBC.ShowDialog();
                            if (nUserRecentDataCount != -1)
                                ds.nRecentDataCount = nUserRecentDataCount;
                        }

                        string queryReadRecent = "SELECT * FROM TblTacho ORDER BY 입고시간 DESC";
                        OleDbCommand commReadRecent = new OleDbCommand(queryReadRecent, conn);
                        OleDbDataReader srReadRecent = commReadRecent.ExecuteReader();

                        int rCnt = 0;
                        while (srReadRecent.Read())
                        {
                            RecentID[rCnt++] = srReadRecent.GetInt32(0);

                            if (rCnt >= ds.nRecentDataCount)
                                break;
                        }

                        string sss = " WHERE";

                        for (int i = 0; i < ds.nRecentDataCount; i++)
                        {
                            sss += " ID=" + RecentID[i].ToString();

                            if (i != (ds.nRecentDataCount - 1))
                                sss += " OR";
                        }

                        queryRead += sss;
                    }

                }

                if (Order == -1)    // 정렬 없음
                {
                    queryRead += " ORDER BY 입고시간";
                }
                else if (Order == 0) // 내림 차순
                {
                    switch (ColumnIdx)
                    {
                        case 0: queryRead += " ORDER BY ID DESC"; break;
                        case 1: queryRead += " ORDER BY 차량No DESC"; break;
                        case 2: queryRead += " ORDER BY 기사No DESC"; break;
                        case 3: queryRead += " ORDER BY 기사이름 DESC"; break;
                        case 4: queryRead += " ORDER BY 출고시간 DESC"; break;
                        case 5: queryRead += " ORDER BY 입고시간 DESC"; break;
                        case 6: queryRead += " ORDER BY 미터수입 DESC"; break;
                        case 7: queryRead += " ORDER BY 실입금액 DESC"; break;
                        case 8: queryRead += " ORDER BY 영업거리 DESC"; break;
                        case 9: queryRead += " ORDER BY 주행거리 DESC"; break;
                        case 10: queryRead += " ORDER BY 과속시간 DESC"; break;
                        case 11: queryRead += " ORDER BY 급제동 DESC"; break;
                        case 12: queryRead += " ORDER BY 주행기본 DESC"; break;
                        case 13: queryRead += " ORDER BY 주행이후 DESC"; break;
                        case 14: queryRead += " ORDER BY 할증기본 DESC"; break;
                        case 15: queryRead += " ORDER BY 할증이후 DESC"; break;
                        default: queryRead += " ORDER BY 입고시간"; break;
                    }
                }
                else
                {
                    switch (ColumnIdx)
                    {
                        case 0: queryRead += " ORDER BY ID"; break;
                        case 1: queryRead += " ORDER BY 차량No"; break;
                        case 2: queryRead += " ORDER BY 기사No"; break;
                        case 3: queryRead += " ORDER BY 기사이름"; break;
                        case 4: queryRead += " ORDER BY 출고시간"; break;
                        case 5: queryRead += " ORDER BY 입고시간"; break;
                        case 6: queryRead += " ORDER BY 미터수입"; break;
                        case 7: queryRead += " ORDER BY 실입금액"; break;
                        case 8: queryRead += " ORDER BY 영업거리"; break;
                        case 9: queryRead += " ORDER BY 주행거리"; break;
                        case 10: queryRead += " ORDER BY 과속시간"; break;
                        case 11: queryRead += " ORDER BY 급제동"; break;
                        case 12: queryRead += " ORDER BY 주행기본"; break;
                        case 13: queryRead += " ORDER BY 주행이후"; break;
                        case 14: queryRead += " ORDER BY 할증기본"; break;
                        case 15: queryRead += " ORDER BY 할증이후"; break;
                        default: queryRead += " ORDER BY 입고시간"; break;
                    }
                }
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();



                // string formCaption = "타코 데이터";

                //  this.Text = formCaption;

                if (listView1.Items.Count > 0)
                    listView1.Items.Clear();

                listView1.View = View.Details;
                listView1.GridLines = true;                   //   리스트 뷰 라인생성
                listView1.FullRowSelect = true;               // 라인 선택 


                int isOpenedDBNum = 0;
                DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
                DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
                TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);

                uint tMoney = 0, tB = 0, tDB = 0, tDA = 0, tAB = 0, tAA = 0;
                double tDistS = 0, tDistD = 0;
                TimeSpan tOverD = new TimeSpan();

                bool bIsMatched = false;

                int nReadDBCnt = 0;         // 읽어들인 데이터 갯수 파악용





                while (srRead.Read())
                {

                    #region 데이터 정렬
                    if (bIsDetail)
                    {
                        if (bCarSel && !bCarTotalSel)
                        {
                            bool bIsCorrectCar = false;

                            for (int i = 0; i < nlCarSel.Count; i++)
                            {
                                if (srRead.GetString(1) == comboBox차량번호.Items[nlCarSel[i]].ToString())
                                    bIsCorrectCar = true;
                            }

                            if (!bIsCorrectCar)
                                continue;
                        }

                        if (bDrvSel && !bDrvTotalSel)
                        {
                            bool bIsCorrectDrv = false;

                            for (int i = 0; i < nlDrvSel.Count; i++)
                            {
                                if (srRead.GetString(2) == comboBox기사번호.Items[nlDrvSel[i]].ToString())
                                    bIsCorrectDrv = true;
                            }

                            if (!bIsCorrectDrv)
                                continue;
                        }

                        if (bCompareMoneySel && bCompareMoneyUpper)
                        {
                            if ((int)srRead.GetDecimal(6) < nCompareMoney)
                                continue;
                        }
                        else if (bCompareMoneySel && !bCompareMoneyUpper)
                        {
                            if ((int)srRead.GetDecimal(6) >= nCompareMoney)
                                continue;
                        }

                        if (bOverDriveSel)
                        {
                            DateTime baseT = new DateTime(1899, 12, 30, 0, 0, 0);
                            TimeSpan overT = (srRead.GetDateTime(11) - baseT);
                            if (overT.TotalMinutes == 0)
                                continue;
                        }

                        if (bEmerBreakSel)
                        {
                            if (srRead.GetInt32(12) == 0)
                                continue;
                        }

                        if (bOutDaySel)
                        {
                            if (!((srRead.GetDateTime(4).Year == dtOutDay.Year)
                                && (srRead.GetDateTime(4).Month == dtOutDay.Month)
                                && (srRead.GetDateTime(4).Day == dtOutDay.Day)))
                                continue;
                        }

                        if (bInDaySel)
                        {
                            if (!((srRead.GetDateTime(5).Year == dtInDay.Year)
                                && (srRead.GetDateTime(5).Month == dtInDay.Month)
                                && (srRead.GetDateTime(5).Day == dtInDay.Day)))
                                continue;
                        }

                        // 기간 검색
                        if (bSearchStartSel)
                        {
                            DateTime dSeartStartTime = new DateTime(dtSearchStartDay.Year, dtSearchStartDay.Month, dtSearchStartDay.Day,
                                (bSearchStartAM ? nSearchStartHour : nSearchStartHour + 12), 0, 0);

                            TimeSpan tsCompareTime = srRead.GetDateTime(5) - dSeartStartTime;

                            if (tsCompareTime.TotalSeconds < 0)
                                continue;
                        }

                        if (bSearchEndSel)
                        {
                            DateTime dSeartEndTime = new DateTime(dtSearchEndDay.Year, dtSearchEndDay.Month, dtSearchEndDay.Day,
                                (bSearchEndAM ? nSearchEndHour : nSearchEndHour + 12), 0, 0);

                            TimeSpan tsCompareTime = dSeartEndTime - srRead.GetDateTime(4);

                            if (tsCompareTime.TotalSeconds < 0)
                                continue;
                        }

                        // 주행 기본
                        if (bDriveBasicSel)
                        {
                            if (bDriveBasicUpper)
                            {
                                if (srRead.GetInt32(13) < nDriveBasic)
                                    continue;
                            }
                            else
                            {
                                if (srRead.GetInt32(13) > nDriveBasic)
                                    continue;
                            }
                        }

                        // 주행 이후
                        if (bDriveAfterSel)
                        {
                            if (bDriveAfterUpper)
                            {
                                if (srRead.GetInt32(14) < nDriveAfter)
                                    continue;
                            }
                            else
                            {
                                if (srRead.GetInt32(14) > nDriveAfter)
                                    continue;
                            }
                        }

                        // 할증 기본
                        if (bAddBasicSel)
                        {
                            if (bAddBasicUpper)
                            {
                                if (srRead.GetInt32(15) < nAddBasic)
                                    continue;
                            }
                            else
                            {
                                if (srRead.GetInt32(15) > nAddBasic)
                                    continue;
                            }
                        }

                        // 할증 이후
                        if (bAddAfterSel)
                        {
                            if (bAddAfterUpper)
                            {
                                if (srRead.GetInt32(16) < nAddAfter)
                                    continue;
                            }
                            else
                            {
                                if (srRead.GetInt32(16) > nAddAfter)
                                    continue;
                            }
                        }
                    }
                    else
                    {
                        if (ds.nIndexOfDefaultViewItem == 0)        // 최근 자료
                        {
                            if (nReadDBCnt >= ds.nRecentDataCount)
                                break;
                        }
                        else if (ds.nIndexOfDefaultViewItem == 1)   // 주간 자료
                        {
                            TimeSpan tsWeek = DateTime.Now - srRead.GetDateTime(5);
                            if (tsWeek.TotalDays >= 7)
                                continue;
                        }
                        else if (ds.nIndexOfDefaultViewItem == 2)   // 월간 자료
                        {
                            if (DateTime.Now.Month != srRead.GetDateTime(5).Month)
                                continue;
                        }
                        else if (ds.nIndexOfDefaultViewItem == 3)   // 분기 자료
                        {
                            if (DateTime.Now.Year != srRead.GetDateTime(5).Year)
                                continue;

                            if (DateTime.Now.Month <= 3)
                            {
                                if (srRead.GetDateTime(5).Month > 3)
                                    continue;
                            }
                            else if (DateTime.Now.Month <= 6)
                            {
                                if ((srRead.GetDateTime(5).Month <= 3) || (srRead.GetDateTime(5).Month > 6))
                                    continue;
                            }
                            else if (DateTime.Now.Month <= 9)
                            {
                                if ((srRead.GetDateTime(5).Month <= 6) || (srRead.GetDateTime(5).Month > 9))
                                    continue;
                            }
                            else
                            {
                                if (srRead.GetDateTime(5).Month <= 9)
                                    continue;
                            }
                        }
                        else if (ds.nIndexOfDefaultViewItem == 4)   // 년간 자료
                        {
                            if (DateTime.Now.Year != srRead.GetDateTime(5).Year)
                                continue;
                        }
                        else    // 전체 자료
                        {
                        }

                      //  if (radioButton차량별보기.Checked)
                        if(CarCheck)
                        {
                            if (comboBox차량번호.SelectedItem.ToString() != srRead.GetString(1))
                                continue;
                        }
                      //  else if (radioButton기사별보기.Checked)
                        else if (driverCheck)
                        {
                            if (comboBox기사번호.SelectedItem.ToString() != srRead.GetString(2))
                                continue;
                        }
                        else if (car_driverCheck)
                        {

                            if (comboBox차량번호.SelectedItem.ToString() != srRead.GetString(1))
                                continue;

                            if (comboBox기사번호.SelectedItem.ToString() != srRead.GetString(2))
                                continue;


                        }
                        else if (radioButton출고일별보기.Checked)
                        {
                            if ((srRead.GetDateTime(4).Year != dateTimePicker출고일별보기.Value.Year)
                                || (srRead.GetDateTime(4).Month != dateTimePicker출고일별보기.Value.Month)
                                || (srRead.GetDateTime(4).Day != dateTimePicker출고일별보기.Value.Day))
                                continue;
                        }
                        else if (radioButton입고일별보기.Checked)
                        {
                            if ((srRead.GetDateTime(5).Year != dateTimePicker입고일별보기.Value.Year)
                                || (srRead.GetDateTime(5).Month != dateTimePicker입고일별보기.Value.Month)
                                || (srRead.GetDateTime(5).Day != dateTimePicker입고일별보기.Value.Day))
                                continue;
                        }
                    }

                    string tooltip_str = srRead.GetInt32(0).ToString();



                    ListViewItem a = new ListViewItem(tooltip_str);       // ID


                    a.ToolTipText = " 영업 상세정보 \n ID 더블클릭!";

                    string strCarNo = srRead.GetString(1);  // 차량번호


                    if (radioButton전체보기.Checked && !bIsDetail)
                    {
                        bIsMatched = false;
                        for (int i = 0; i < comboBox차량번호.Items.Count; i++)
                        {
                            if (comboBox차량번호.Items[i].ToString() == strCarNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox차량번호.Items.Add(strCarNo);


                        }
                    }
                    else if (radioButton차량별보기.Checked && !bIsDetail)
                    {
                        bIsMatched = false;
                        for (int i = 0; i < comboBox차량번호.Items.Count; i++)
                        {
                            if (comboBox차량번호.Items[i].ToString() == strCarNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox차량번호.Items.Add(strCarNo);


                        }
                    }
                    #endregion


                    a.SubItems.Add(strCarNo);                                               // 차량번호

                    //a.SubItems.Add(srRead.GetString(2));      
                    
                    // 기사번호
                  //  String.Format("{0:d4}", srRead.GetString(2));

                    string strDriverNo = srRead.GetString(2);

                    //int driver_int = Convert.ToInt32(strDriverNo);
                   // strDriverNo = driver_int.ToString("D4");

                 //   string strDriverNo = String.Format("{0:0000}", srRead.GetString(2));
                    if (radioButton전체보기.Checked)
                    {
                        bIsMatched = false;
                        for (int i = 0; i < comboBox기사번호.Items.Count; i++)
                        {
                            if (comboBox기사번호.Items[i].ToString() == strDriverNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox기사번호.Items.Add(strDriverNo);
                        }
                    }
                    else if(radioButton기사별보기.Checked)
                    {
                        if (comboBox기사번호.Items.Count != 0)
                        {
                            bool chk = false;
                            string str = "";
                            for (int q = 0; q < comboBox기사번호.Items.Count; q++)
                            {
                                str = (string)comboBox기사번호.Items[q];
                                if( str ==strDriverNo)
                                {
                                    chk = true;
                                }
                               /* if (strDriverNo == comboBox기사번호.Items[q])
                                {
                                    chk = true;
                                }*/
                            }

                            if (chk == false)
                            {
                                comboBox기사번호.Items.Add(strDriverNo);
                            }

                        }
                        else
                        {
                            comboBox기사번호.Items.Add(strDriverNo);
                        }
                       // comboBox기사번호.Items.Add(strDriverNo);
                    }
                    a.SubItems.Add(strDriverNo);                                            // 기사번호

                    string strDriverName = "";



                    if (srRead.IsDBNull(3) == false)
                    {
                        strDriverName = srRead.GetString(3);
                        a.SubItems.Add(strDriverName);

                    }
                    else
                    {
                        a.SubItems.Add(strDriverName);
                    }

                    // 기사이름
                    //	    a.SubItems.Add("");                                                      // 기사이름

                    a.SubItems.Add(srRead.GetDateTime(4).ToString("yyyy-MM-dd tt HH:mm:ss"));                       // 출고시간
                    a.SubItems.Add(srRead.GetDateTime(5).ToString("yyyy-MM-dd tt HH:mm:ss"));


                    uint uuu = (uint)srRead.GetDecimal(6);
                    tMoney += uuu;

                    string money = string.Format("{0:C}", uuu);
                    a.SubItems.Add(money);                                                  // 미터수입

                    //    money = string.Format("{0:C}", srRead.GetDecimal(7));   // 실입금액
                 //   a.SubItems.Add(money);  

                    DateTime SalesT = srRead.GetDateTime(19);

                    if (SalesT.Year != 1899)
                    {
                        a.SubItems.Add(String.Format("{0:D}-{1:D}:{2:D2}", SalesT.Day, SalesT.Hour, SalesT.Minute));    // 영업시간
                       

                    }
                    else
                    {

                        a.SubItems.Add(SalesT.ToString("HH:mm"));    // 영업시간
                      
                    }
                  

                    double ddd = srRead.GetDouble(8);
                    tDistS += ddd;
                    string dist = string.Format("{0:N} Km", ddd);
                    a.SubItems.Add(dist);


                    ddd = srRead.GetDouble(9);
                    tDistD += ddd;
                    dist = string.Format("{0:N} Km", ddd);
                    a.SubItems.Add(dist);                                                   // 주행거리

                    //	string fuel = string.Format("{0:N} L", srRead.GetDouble(10));
                    //	a.SubItems.Add(fuel);                                                   // 연료량

                    srTime = srRead.GetDateTime(11);
                    stTime = new DateTime(srTime.Year, srTime.Month, srTime.Day, 0, 0, 0);
                    stSpan = srTime - stTime;
                    tOverD += stSpan;
                    a.SubItems.Add(stSpan.ToString());                                      // 과속시간

                    uuu = (uint)srRead.GetInt32(12);
                    tB += uuu;
                    a.SubItems.Add(uuu.ToString());                                         // 급제동
                    uuu = (uint)srRead.GetInt32(13);
                    tDB += uuu;
                    a.SubItems.Add(uuu.ToString());                                         // 주행기본
                    uuu = (uint)srRead.GetInt32(14);
                    tDA += uuu;
                    a.SubItems.Add(uuu.ToString());                                         // 주행이후
                    uuu = (uint)srRead.GetInt32(15);
                    tAB += uuu;
                    a.SubItems.Add(uuu.ToString());                                         // 할증기본
                    uuu = (uint)srRead.GetInt32(16);
                    tAA += uuu;
                    a.SubItems.Add(uuu.ToString());                                         // 할증이후
                    //a.SubItems.Add(srRead.GetInt32(17).ToString());                         // 문개폐
                    isOpenedDBNum = srRead.GetInt32(18);


                    string fuel = string.Format("{0:N} L", srRead.GetDouble(10));
                    a.SubItems.Add(fuel);                                                   // 연료량


                    //	string fuel = "";

                    /*	if (srRead.IsDBNull(22) == false)
                        {
                            fuel = srRead.GetString(22);
                            a.SubItems.Add(fuel);
                        }
                        else
                        {
                            a.SubItems.Add(fuel);
                        } */

                    listView1.Items.Add(a);

                    total.tMoney = (int)tMoney;   //미터수입 합
                    total.tDistS = (int)tDistS;	// 영업거리 합
                    total.tDistD = (int)tDistD;  // 주행거리 합
                    total.tDB = (int)tDB;		// 급제동 합
                    total.tDA = (int)tDA;		// 주행기본 합
                    total.tAA = (int)tAA;		// 주행이후 합
                    total.tAB = (int)tAB;		// 할증기본 합
                    total.tB = (int)tB;			// 급제동 합
                    total.tOverD = tOverD;   // 과속시간 합


                    nReadDBCnt++;
                }

                if (radioButton전체보기.Checked)
                {
                    if (listView1.Items.Count != 0)
                    {


                        comboBox차량번호.SelectedIndex = 0;
                        comboBox기사번호.SelectedIndex = 0;
                    }
                }

                int nTotalItems = listView1.Items.Count;

                if (nTotalItems != 0)
                {



                    ListViewItem b = new ListViewItem("합계");
                    b.SubItems.Add("");                             ///   공백 다섯칸 만들기
                    b.SubItems.Add("");
                    b.SubItems.Add("");
                    b.SubItems.Add("");
                    b.SubItems.Add("");
                    string mm = string.Format("{0:C}", tMoney);     // 미터수입
                    b.SubItems.Add(mm);
                    b.SubItems.Add("");                              // 공백
                    mm = string.Format("{0:N} Km", tDistS);
                    b.SubItems.Add(mm);                                                         // 영업거리
                    mm = string.Format("{0:N} Km", tDistD);
                    b.SubItems.Add(mm);                                                         // 주행거리
                    //b.SubItems.Add("");
                    b.SubItems.Add(tOverD.ToString());                                          // 과속시간
                    b.SubItems.Add(tB.ToString());                                              // 급제동
                    b.SubItems.Add(tDB.ToString());                                             // 주행기본
                    b.SubItems.Add(tDA.ToString());                                             // 주행이후
                    b.SubItems.Add(tAB.ToString());                                             // 할증기본
                    b.SubItems.Add(tAA.ToString());                                             // 할증이후
                    b.SubItems.Add("");

                    b.BackColor = System.Drawing.Color.LightGray;
                    listView1.Items.Add(b);

                    ListViewItem c = new ListViewItem("평균");
                    c.SubItems.Add("");
                    c.SubItems.Add("");
                    c.SubItems.Add("");
                    c.SubItems.Add("");
                    c.SubItems.Add("");
                    mm = string.Format("{0:C}", tMoney / nTotalItems);
                    c.SubItems.Add(mm);
                    c.SubItems.Add("");
                    mm = string.Format("{0:N} Km", tDistS / nTotalItems);
                    c.SubItems.Add(mm);                                                         // 영업거리
                    mm = string.Format("{0:N} Km", tDistD / nTotalItems);
                    c.SubItems.Add(mm);                                                         // 주행거리
                    //c.SubItems.Add("");

                    DateTime dt = new DateTime();   // DateTime 기준일로부터 과속시간 총합을 더한 시간
                    DateTime bt = new DateTime();   // DateTime 기준일
                    dt = dt.AddMilliseconds((double)(tOverD.TotalMilliseconds / nTotalItems));
                    TimeSpan aOverD = dt - bt;      // 구지 이런 복잡한 계산을 한 이유는, 00:00:00 방식으로 표시하기 위함
                    mm = string.Format("{0:D2}:{1:D2}:{2:D2}", aOverD.Hours, aOverD.Minutes, aOverD.Seconds);
                    c.SubItems.Add(mm);                                                         // 과속시간
                    c.SubItems.Add((tB / nTotalItems).ToString());                                // 급제동
                    c.SubItems.Add((tDB / nTotalItems).ToString());                               // 주행기본
                    c.SubItems.Add((tDA / nTotalItems).ToString());                               // 주행이후
                    c.SubItems.Add((tAB / nTotalItems).ToString());                               // 할증기본
                    c.SubItems.Add((tAA / nTotalItems).ToString());                             // 할증이후
                    c.SubItems.Add("");

                    c.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    listView1.Items.Add(c);
                }
                conn.Close();

                FillList(this.m_list, listView1);


                if (form1.nodeclick == true)
                {

                    form1.nodeclick = false;
                }
                else
                {
                    //  Thread LoadingThread = new Thread(LoadingWork);
                    //  LoadingThread.Start();
                }

                int CarCount = 0;
                Carcnt_label.Text = "총 차량수 :";

                ArrayList list = new ArrayList();

                for (int j = 0; j < listView1.Items.Count - 2; j++)
                {
                    string cbc = listView1.Items[j].SubItems[1].Text;   // listview Id -> string

                    if (list.Contains(cbc)) continue;
                    list.Add(cbc);


                }
                CarCount = list.Count;
                Carcnt_label.Text += " " + CarCount.ToString();




            }
            catch (Exception ex)
            {
                /*   string path = Application.StartupPath + "\\ErrorLog.jie";
                   using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                   {
                       sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                   ;
                   }*/
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //	connInfo.Close();
                //	bIsDetail = false;
            }

        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            /*ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

            foreach(ListViewItem item in items)
            {
                if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                {
                    nOpenedindex = 0;
                    return;
                }
                else
                {
                    nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                }
            }

            formGraph.FillData(nOpenedindex);
            formGraph.MdiParent = this.ParentForm;
            formGraph.BringToFront();
            formGraph.Show();

            formInfo.FillDataEx(nOpenedindex, ds.nIndexOfChangeAMHour, ds.nIndexOfChangePMHour);
            formInfo.MdiParent = this.ParentForm;
            formInfo.BringToFront();
            formInfo.Show();
            formInfo.Focus();

            isFormDataDetailFormShow = true;*/

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                {
                    nOpenedindex = 0;
                }
                else
                {
                    nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (selectedColumnIndex == e.Column)
            {
                if (selectedOrder == 1)
                    selectedOrder = 0;
                else
                    selectedOrder = 1;
            }
            else
            {
                selectedColumnIndex = e.Column;

                selectedOrder = 1;
            }

            FillData(selectedColumnIndex, selectedOrder);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Enabled = true;
        }

        private void ToolStripMenuItemUp_Click(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItemDown_Click(object sender, EventArgs e)
        {
        }

        private void 구분ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 0;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 차량번호ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            selectedColumnIndex = 1;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);

        }

        private void 기사번호ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 2;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 기사이름ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 3;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 출고시간ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 4;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 입고시간ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 5;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 미터수입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 6;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 실입금액ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 7;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 영업거리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 8;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행거리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 9;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 연료량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 10;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 과속시간ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 11;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 급제동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 12;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행기본ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 13;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행이후ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 14;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 할증기본ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 15;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 할증이후ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 16;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 문개폐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 17;
            selectedOrder = 1;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 구분ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 0;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 차량번호ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 1;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 기사번호ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 2;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 기사이름ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 3;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 출고시간ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 4;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 입고시간ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 5;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 미터수입ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 6;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 실입금액ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 7;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 영업거리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 8;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행거리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 9;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 연료량ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 10;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 과속시간ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 11;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 급제동ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 12;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행기본ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 13;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 주행이후ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 14;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 할증기본ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 15;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 할증이후ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 16;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void 문개폐ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedColumnIndex = 17;
            selectedOrder = 0;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("마우스 오른쪽 버튼을 누른후 정렬 방식을 선택하여 주세요!");
        }

        private void radioButton전체보기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton전체보기.Checked)
            {
                comboBox기사번호.Enabled = false;
                comboBox차량번호.Enabled = false;
                dateTimePicker출고일별보기.Enabled = false;
                dateTimePicker입고일별보기.Enabled = false;
                bIsDetail = false;								// 11. 06.20
            }
        }

        private void radioButton차량별보기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton차량별보기.Checked)
            {
               // comboBox차량번호.Items.Clear();
                comboBox기사번호.Enabled = false;
                comboBox차량번호.Enabled = true;
               // FillData(1, 0);
                dateTimePicker출고일별보기.Enabled = false;
                dateTimePicker입고일별보기.Enabled = false;
            }
        }

        private void radioButton기사별보기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton기사별보기.Checked)
            {
                comboBox기사번호.Items.Clear();
                comboBox기사번호.Enabled = true;
               
                FillData(2, 0);
                comboBox기사번호.SelectedItem = comboBox기사번호.Items[0];
                comboBox차량번호.Enabled = false;
                dateTimePicker출고일별보기.Enabled = false;
                dateTimePicker입고일별보기.Enabled = false;
            }
        }

        private void radioButton출고일별보기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton출고일별보기.Checked)
            {
                comboBox기사번호.Enabled = false;
                comboBox차량번호.Enabled = false;
                dateTimePicker출고일별보기.Enabled = true;
                dateTimePicker입고일별보기.Enabled = false;
            }
        }

        private void radioButton입고일별보기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton입고일별보기.Checked)
            {
                comboBox기사번호.Enabled = false;
                comboBox차량번호.Enabled = false;
                dateTimePicker출고일별보기.Enabled = false;
                dateTimePicker입고일별보기.Enabled = true;
            }
        }

        private void button실행_Click(object sender, EventArgs e)
        {
            bIsDetail = false;
          
            if (radioButton기사별보기.Checked == true)
            {
                selectedColumnIndex = 2;
                driverCheck = true;
            }
            else if (radioButton차량기사.Checked ==true)
            {
                selectedColumnIndex = 2;
                car_driverCheck = true;
            }
            else if (radioButton차량별보기.Checked == true)
            {
                selectedColumnIndex = 1;
                CarCheck = true;
            }
            else
            {
                driverCheck = false;
                selectedColumnIndex = 1;
            }
            FillData(selectedColumnIndex, selectedOrder);
            driverCheck = false;
            CarCheck = false;
            car_driverCheck = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDataDetail fdd = new FormDataDetail(this);
            //fdd.ShowDialog();
            fdd.Show();
        }

        private void buttonPageSetup_Click(object sender, EventArgs e)
        {
            PrintPageSetup_FormData();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            //	FillList(m_list, listView1);
            PrintPreview_FormData();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //FillList(m_list, listView1);
            // Print_FormData();

            //   m_list.PageSetup();

            PrintPreview_FormData();
        }

        public void PrintPageSetup_FormData()
        {
            m_list.PageSetup();



        }

        public void PrintPreview_FormData()
        {
            m_list.Title = "차 량 운 행 일 보  " + yymmdd + "\n";


            //m_list.FitToPage = m_cbFitToPage.Checked;
            //	m_list.PageSetup();

            m_list.FitToPage = true;
            m_list.PrintPreview();
        }

        public void Print_FormData()
        {
            m_list.Title = "타코 데이터 출력";
            //m_list.FitToPage = m_cbFitToPage.Checked;
            m_list.FitToPage = true;
            m_list.Print();
        }

        public void FillList(ListView list, ListView table)
        {
            list.SuspendLayout();

            // Clear list
            list.Items.Clear();
            list.Columns.Clear();

            // Columns
            int nCol = 0;
            /*   foreach (ColumnHeader col in table.Columns)
               {
                   ColumnHeader ch = new ColumnHeader();
                   ch.Text = col.Text;
                   ch.TextAlign = HorizontalAlignment.Right;
				
                   switch (nCol)
                   {
                       case 0: ch.Width = 50; break;

                       case 1: ch.Width = 80; break;
                       case 2: ch.Width = 50; break;
                       case 3: ch.Width = 50; break;
                       case 4:
                           ch.TextAlign = HorizontalAlignment.Left;
                           ch.Width = 180;
                           break;
                       case 5: ch.Width = 180; break;
                       case 6: ch.Width = 90; break;
                       case 7: ch.Width = 90; break;
                       case 8: ch.Width = 90; break;
                       case 9: ch.Width = 120; break;
                      // case 10: ch.Width = 35; break;

                    
                  
                   //    case 11:
                    //   case 12:
                    //   case 13:
                    //   case 14:
                    //   case 15: ch.Width = 40; break;
                   //	case 16:
                   //	case 17: 
                       default:
                           ch.Width = 0;
						
                           break;
                   }
                   list.Columns.Add(ch);
                   nCol++;
               }*/


            int a = 0;

            if (TotalRec_print == true)
            {
                a = 11;
                TotalRec_print = false;
            }
            else
            {
                a = 10;
            }

            for (int i = 0; i < a; i++)
            {


                ColumnHeader[] col = new ColumnHeader[a];
                ColumnHeader ch = new ColumnHeader();

                col[i] = table.Columns[i];
                ch.Text = col[i].Text;
                ch.TextAlign = HorizontalAlignment.Right;
                switch (nCol)
                {
                    case 0: ch.Width = 40; break;       // id   

                    case 1: ch.Width = 80; break;       // 차량번호
                    case 2: ch.Width = 50; break;       // 기사
                    case 3: ch.Width = 50; break;       // 기사..
                    case 4:
                        ch.TextAlign = HorizontalAlignment.Left;    // 출고 
                        ch.Width = 180;
                        break;
                    case 5: ch.Width = 180; break;              // 입고
                    case 6: ch.Width = 120; break;               // 미터 수입
                    case 7: ch.Width = 90; break;               // 실입금
                    case 8: ch.Width = 120; break;               // 영업거리
                    case 9: ch.Width = 120; break;                 // 주행거리
                    case 10: ch.Width = 80; break;



                    //    case 11:
                    //   case 12:
                    //   case 13:
                    //   case 14:
                    //   case 15: ch.Width = 40; break;
                    //	case 16:
                    //	case 17: 
                    default:
                        ch.Width = 0;

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
                list.Height = 100;
                list.Items.Add(item);
            }



            list.ResumeLayout();
        }

        private void buttonDataAdd_Click(object sender, EventArgs e)
        {
            // 0. 차량번호 같은지 확인
            for (int i = 1; i < listView1.SelectedItems.Count; i++)
            {
                if (listView1.SelectedItems[0].SubItems[1].Text != listView1.SelectedItems[i].SubItems[1].Text)
                {
                    string str = "합치려는 데이터가 서로 다른 차량입니다."
                                + "\r\n데이터를 합치게되면 무결성을 보장하지 못하게 됩니다."
                                + "\r\n\r\n그래도 합치시겠습니까?"
                                + "\r\n(첫 데이터의 정보로 합쳐집니다)";
                    if (MessageBox.Show(str, "차량번호 충돌", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        break;
                    else
                        return;
                }
            }

            // 1. 데이터의 날짜 유효성 검사
            // listView 에서 날짜 데이터를 뽑아 와서..
            DateTime[] InTime = new DateTime[listView1.SelectedItems.Count];
            DateTime[] OutTime = new DateTime[listView1.SelectedItems.Count];

            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                string str = listView1.SelectedItems[i].SubItems[4].Text;
                InTime[i] = Convert.ToDateTime(str);
                str = listView1.SelectedItems[i].SubItems[5].Text;
                OutTime[i] = Convert.ToDateTime(str);
            }

            int crashCnt = 0;

            for (int i = 0; i < listView1.SelectedItems.Count - 1; i++)
            {
                for (int j = i + 1; j < listView1.SelectedItems.Count; j++)
                {
                    if ((OutTime[i] < InTime[j]) || (OutTime[j] < InTime[i]))
                    {
                        // 안충돌
                    }
                    else
                    {
                        // 충돌
                        crashCnt++;
                    }
                }
            }

            // 1.1. 날짜 중복 발생시 경고
            if (crashCnt > 0)
            {
                string str = "합치려는 타코 데이터에 겹치는 시간대가 있습니다."
                            + "\r\n데이터를 합치게되면 무결성을 보장하지 못하게 됩니다."
                            + "\r\n\r\n그래도 합치시겠습니까?"
                            + "\r\n(첫 데이터의 정보로 합쳐집니다)";
                if (MessageBox.Show(str, "데이터 충돌", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
                    return;
            }


            // 1.2. 날짜 중복이 없다면, 데이터를 합침
            List<int> liID = new List<int>();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));
            }

            liID.Sort();

            TachoDataMux(liID);

            FillData(0, 1);
        }

        private void TachoDataMux(List<int> liID)
        {
            FillUpdateData(liID);
        }

        private void FillUpdateData(List<int> liID)
        {
            bool bIsUpdateSuccess = false;
            int nID = 0;


            ///////////
            string DBstring = "";
            if (Db_backup == true)
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + MdbFileName;
                //					 Db_backup = false;


            }
            else
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }

            ///////////
            //    string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
            OleDbConnection conn = new OleDbConnection(@DBstring);

            try
            {
                conn.Open();

                // 합쳐져서 새로이 생성될 TblTacho ID 알아내기
                string queryRead = "SELECT * FROM TblTacho ORDER BY ID DESC";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                while (srRead.Read())
                {
                    nID = srRead.GetInt32(0);
                    nID++;
                    break;
                }

                string queryUpdate = "";
                // 합치기 전 TblTacho ID에 해당하는 TaxiInfor, Graph 인덱스 필드들의 detail에 업데이트될 ID 값 채우기
                for (int i = 0; i < liID.Count; i++)
                {
                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE TaxiInfor SET detail=" + nID.ToString()
                        + " WHERE 인덱스=" + liID[i].ToString();
                    OleDbCommand commFisrtUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtUpdate.ExecuteNonQuery();

                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE Graph SET detail=" + nID.ToString()
                        + " WHERE 인덱스=" + liID[i].ToString();
                    OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtDateUpdate.ExecuteNonQuery();
                }

                // 바뀐 detail 값을 기준으로 인덱스 업데이트
                {
                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE TaxiInfor SET 인덱스=" + nID.ToString()
                        + " WHERE detail=" + nID.ToString();
                    OleDbCommand commFisrtUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtUpdate.ExecuteNonQuery();

                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE Graph SET 인덱스=" + nID.ToString()
                        + " WHERE detail=" + nID.ToString();
                    OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtDateUpdate.ExecuteNonQuery();
                }

                // detail 값 '0'으로 초기화
                {
                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE TaxiInfor SET detail=0"
                        + " WHERE 인덱스=" + nID.ToString();
                    OleDbCommand commFisrtUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtUpdate.ExecuteNonQuery();

                    // [TaxiInfor] 해당 인덱스 데이터들의 detail에 변경될 값 채우기
                    queryUpdate = "UPDATE Graph SET detail=0"
                        + " WHERE 인덱스=" + nID.ToString();
                    OleDbCommand commFisrtDateUpdate = new OleDbCommand(queryUpdate, conn);
                    commFisrtDateUpdate.ExecuteNonQuery();
                }

                bIsUpdateSuccess = true;
            }
            catch (Exception ex)
            {
                /*   string path = Application.StartupPath + "\\ErrorLog.jie";
                   using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                   {
                       sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                   }*/

                MessageBox.Show("데이터를 합치는데 에러가 발생했습니다.", "오류");
                bIsUpdateSuccess = false;
            }
            finally
            {
                conn.Close();

                if (bIsUpdateSuccess)
                {
                    UpdateTblTacho(nID, liID);
                }
            }
        }

        private void UpdateTblTacho(int nID, List<int> liID)
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

            string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
            OleDbConnection conn = new OleDbConnection(@DBstring);

            try
            {
                // Fill Data
                conn.Open();

                string queryTblTacho = "SELECT * FROM TblTacho WHERE ID=" + liID[0].ToString();
                OleDbCommand commTblTacho = new OleDbCommand(queryTblTacho, conn);
                OleDbDataReader srRead = commTblTacho.ExecuteReader();

                while (srRead.Read())
                {
                    CarNumber = srRead.GetString(1);
                    DriverNumber = srRead.GetString(2);
                    //DriverName = srRead.GetString(3);
                }

                // Insert New Table
                //for (int i = 0; i <= listSelectedIndex.Count; i++)
                {
                    // Calculate TblTacho form TaxiInfor
                    queryTblTacho = "SELECT * FROM TaxiInfor WHERE 인덱스=" + nID.ToString();
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
                        TodayTotalEmptyDistance += srRead.GetDouble(6);
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

                    commTblTacho.Parameters.Add("ID", OleDbType.Integer).Value = nID;
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
            }
            finally
            {
                conn.Close();

                if (bIsUpdateSuccess)
                {
                    if (DeleteDB(liID))
                    {
                        FillData(0, 1);
                        MessageBox.Show("데이터를 성공적으로 합쳤습니다.", "성공");
                    }
                }
            }
        }

        public bool DeleteDB(List<int> liID)
        {
            bool bIsDeleteSuccess = false;


            string DBstring = "";
            string NameDB = "";
            if (Db_backup == true)
            {

                NameDB = form1.TACHO2_path + @"\" + MdbFileName;
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

            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            string queryDelTblTacho;
            try
            {
                conn1.Open();


                for (int i = 0; i < liID.Count; i++)
                {
                    queryDelTblTacho = "DELETE * FROM TblTacho WHERE ID=" + liID[i].ToString();
                    OleDbCommand commDelTblTacho = new OleDbCommand(queryDelTblTacho, conn1);
                    commDelTblTacho.ExecuteNonQuery();


                }

                bIsDeleteSuccess = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


                bIsDeleteSuccess = false;
                // Fill Data		
            }
            finally
            {
                conn1.Close();

            }

            return bIsDeleteSuccess;
        }


        private void buttonDBDel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("선택한 데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                List<int> liID = new List<int>();
                int cnt = 0;

                cnt = listView1.SelectedItems.Count;

                string Selmetermoney = "";  // 미터 수입 
                string SalesDistance = ""; // 영업거리
                string TotalDistance = "";
                string tBreaek = "";		// 급제동
                string DriveBasic = "";		//주행기본
                string tDA = "";			//주행이후
                string tAB = "";			//할증기본
                string tAA = "";					// 할증이후

                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));


                    Selmetermoney = listView1.SelectedItems[i].SubItems[6].Text;  // 미터 수입 추출
                    SalesDistance = listView1.SelectedItems[i].SubItems[8].Text; // 영업거리
                    TotalDistance = listView1.SelectedItems[i].SubItems[9].Text;  // 주행거리
                    tBreaek = listView1.SelectedItems[i].SubItems[11].Text;  // 급제동
                    DriveBasic = listView1.SelectedItems[i].SubItems[12].Text;  //주행기본
                    tDA = listView1.SelectedItems[i].SubItems[13].Text;
                    tAB = listView1.SelectedItems[i].SubItems[14].Text;
                    tAA = listView1.SelectedItems[i].SubItems[15].Text;

                    Selmetermoney = Selmetermoney.Replace(",", "");
                    Selmetermoney = Selmetermoney.Replace("₩", "");
                    Selmetermoney = Selmetermoney.Replace(@"₩", "");
                    Selmetermoney = Selmetermoney.Replace("\\", "");
                    Selmetermoney = Selmetermoney.Replace(".", "");



                    SalesDistance = SalesDistance.Replace(",", "");
                    SalesDistance = SalesDistance.Replace(".", "");
                    SalesDistance = SalesDistance.Replace("Km", "");

                    TotalDistance = TotalDistance.Replace(",", "");
                    TotalDistance = TotalDistance.Replace(".", "");
                    TotalDistance = TotalDistance.Replace("Km", "");




                    /*	
                            tB    // 급제동
							
                            tDB   // 주행기본
							
                            tDA   // 주행이후
							
                            tAB   // 할증기본
							
                            tAA ;// 할증이후 */


                    try
                    {
                        total.tMoney -= Int32.Parse(Selmetermoney);  // 미터 수입 
                        total.tDistS -= (double)Int32.Parse(SalesDistance) / 100;  // 영업거리
                        total.tDistD -= (double)Int32.Parse(TotalDistance) / 100;  // 주행거리
                        total.tB -= Int32.Parse(tBreaek);					// 급제동
                        total.tDB -= Int32.Parse(DriveBasic);             // 주행기본
                        total.tDA -= Int32.Parse(tDA);					//주행이후
                        total.tAB -= Int32.Parse(tAB);					//할증기본
                        total.tAA -= Int32.Parse(tAA);					//할증이후
                    }
                    catch (Exception eee)
                    {

                    }
                }


                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    //	liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));
                    //	listView1.SelectedItems[i].Remove();

                }


                //  liID.Sort();
                //	Thread DellThread = new Thread(DellWork);
                //	DellThread.Start();


                if (DeleteDB(liID))
                {
                    FillData(1, 1);
                    MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");

                    if (listView1.Items.Count == 1)
                    {
                        //	MessageBox.Show("listView1.Items[0].Remove();");
                        listView1.Items[0].Remove();
                    }
                }
                //FillData(0, 1);
            }

        }

        private void buttonChangeCar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("하나의 데이터만 선택하고 실행해 주십시오.", "경고");
            }
            else
            {
                //listView1.SelectedItems[0].Index
                try
                {
                    int nSelIdx = listView1.SelectedItems[0].Index;

                    if (nSelIdx >= 0)
                    {
                        Point pt = new Point(listView1.Items[nSelIdx].SubItems[1].Bounds.Location.X, listView1.Items[nSelIdx].SubItems[1].Bounds.Location.Y + 63);
                        //textBoxInput.Location = listView1.Items[nSelIdx].SubItems[1].Bounds.Location;
                        textBoxCarInput.Location = pt;
                        textBoxCarInput.Size = new Size(listView1.Items[nSelIdx].SubItems[1].Bounds.Width,
                                                    listView1.Items[nSelIdx].SubItems[1].Bounds.Height);
                        textBoxCarInput.Visible = true;
                        textBoxCarInput.Focus();
                    }
                }
                catch
                {
                }
            }
        }

        private void textBoxCarInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textBoxCarInput.Visible = false;
                textBoxCarInput.Text = "";
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {
                //// Update listView1
                //if (textBoxCarInput.Text.Length == 7)
                //{
                //    if (CarNumIntegrityCheck(textBoxCarInput.Text))
                //    {
                //        // Update listView1
                //        listView1.SelectedItems[0].SubItems[1].Text = textBoxCarInput.Text;
                //    }
                //    else
                //    {
                //        MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
                //    }
                //}

                this.textBoxCarInput.Visible = false;
                //this.textBoxCarInput.Text = "";

                // Update DB
            }
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        private void textBoxCarInput_Leave(object sender, EventArgs e)
        {
            if (textBoxCarInput.Text.Length == 7)
            {
                if (CarNumIntegrityCheck(textBoxCarInput.Text))
                {
                    // Update listView1
                    listView1.SelectedItems[0].SubItems[1].Text = textBoxCarInput.Text;
                    UpdateDB(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), "차량No", textBoxCarInput.Text);
                }
                else
                {
                    MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
                }
            }

            this.textBoxCarInput.Visible = false;
            this.textBoxCarInput.Text = "";
        }

        private bool CarNumIntegrityCheck(string str)
        {
            if (str.Length != 7)
                return false;

            if (((str[0] >= '0') && (str[0] <= '9'))
                && ((str[1] >= '0') && (str[1] <= '9'))
                && ((str[2] == '-'))
                && ((str[3] >= '0') && (str[3] <= '9'))
                && ((str[4] >= '0') && (str[4] <= '9'))
                && ((str[5] >= '0') && (str[5] <= '9'))
                && ((str[6] >= '0') && (str[6] <= '9')))
                return true;
            else
                return false;
        }

        private void buttonChangeDrv_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("하나의 데이터만 선택하고 실행해 주십시오.", "경고");
            }
            else
            {
                //listView1.SelectedItems[0].Index
                try
                {
                    int nSelIdx = listView1.SelectedItems[0].Index;

                    if (nSelIdx >= 0)
                    {
                        Point pt = new Point(listView1.Items[nSelIdx].SubItems[2].Bounds.Location.X, listView1.Items[nSelIdx].SubItems[2].Bounds.Location.Y + 63);
                        textBoxDrvInput.Location = pt;
                        textBoxDrvInput.Size = new Size(listView1.Items[nSelIdx].SubItems[2].Bounds.Width,
                                                    listView1.Items[nSelIdx].SubItems[2].Bounds.Height);
                        textBoxDrvInput.Visible = true;
                        textBoxDrvInput.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }
        }

        private void textBoxDrvInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textBoxDrvInput.Visible = false;
                textBoxDrvInput.Text = "";
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {
                //// Update listView1
                //if (textBoxDrvInput.Text.Length != 0)
                //{
                //    // Update listView1
                //    int nTmp = Convert.ToInt32(textBoxDrvInput.Text);
                //    listView1.SelectedItems[0].SubItems[2].Text = nTmp.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
                //}

                this.textBoxDrvInput.Visible = false;
                //this.textBoxDrvInput.Text = "";

                // Update DB
            }
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBoxDrvInput_Leave(object sender, EventArgs e)
        {
            Decimal nTmp=0;
            if (textBoxDrvInput.Text.Length != 0)
            {
                // Update listView1
                //       int nTmp = Convert.ToInt32(textBoxDrvInput.Text);
                string Temp = "";
                /*
                if (textBoxDrvInput.Text.Length < 4)
                {
                    if (textBoxDrvInput.Text.Length == 1)
                    {
                        Temp = "000";
                        Temp +=textBoxDrvInput.Text;
                        nTmp = Convert.ToDecimal(Temp);
                        listView1.SelectedItems[0].SubItems[2].Text = Temp;

                    }
                    else  if (textBoxDrvInput.Text.Length == 2)
                    {
                        Temp = "00";
                        Temp +=textBoxDrvInput.Text;
                        nTmp = Convert.ToDecimal(Temp);
                        listView1.SelectedItems[0].SubItems[2].Text = Temp;

                    }
                    else if (textBoxDrvInput.Text.Length == 3)
                    {
                        Temp = "0";
                        Temp += textBoxDrvInput.Text;
                        nTmp = Convert.ToDecimal(Temp);
                        listView1.SelectedItems[0].SubItems[2].Text = Temp;

                    }
                }
                else
                {

                    nTmp = Convert.ToDecimal(textBoxDrvInput.Text);
                    listView1.SelectedItems[0].SubItems[2].Text = nTmp.ToString();
                    Temp = textBoxDrvInput.Text;
                }*/


                nTmp = Convert.ToDecimal(textBoxDrvInput.Text);
                listView1.SelectedItems[0].SubItems[2].Text = nTmp.ToString();
                Temp = textBoxDrvInput.Text;
                UpdateDB(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), "기사No", Temp);


            }
            else
            {
                MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
            }

            this.textBoxDrvInput.Visible = false;
            this.textBoxDrvInput.Text = "";
        }

        private void UpdateDB(int nID, string strColName, string strValue)
        {

            //////
            string DBstring = "";

            string NameDB = "";

            if (Db_backup == true)
            {

                NameDB = TACHO2_path + MdbFileName;


                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                //					 Db_backup = false;


            }
            else
            {
                //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            /////

            OleDbConnection conn = new OleDbConnection(@DBstring);

            //   string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + TACHO2_path + "Information.mdb";
            string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            OleDbConnection connInfo = new OleDbConnection(Infostring);


            try
            {
                conn.Open();
                connInfo.Open();
                string queryUpdate = "UPDATE TblTacho SET " + strColName + "='" + strValue
                    + "' WHERE ID=" + nID.ToString();
                OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                commUpdate.ExecuteNonQuery();

                string strDriverName = "";


                try
                {

                    string queryReadDriver = "SELECT * FROM DriverInfo WHERE 기사No='" + strValue + "'";
                    OleDbCommand commReadDriver = new OleDbCommand(queryReadDriver, connInfo);
                    OleDbDataReader srReadDriver = commReadDriver.ExecuteReader();

                    	System.Threading.Thread.Sleep(10);

                    while (srReadDriver.Read())
                    {

                        strDriverName = srReadDriver.GetString(2);
                    }

                    strDriverName = strDriverName.Trim();

                    if (strDriverName == "")
                    {
                        strDriverName = "";
                    }

                    
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    queryUpdate = "UPDATE TblTacho SET " + "기사이름" + "='" + strDriverName
                     + "' WHERE ID=" + nID.ToString();
                    OleDbCommand commUpdate1 = new OleDbCommand(queryUpdate, conn);
                    commUpdate1.ExecuteNonQuery();

                }



            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 업데이트 하는데 오류가 발생했습니다.", "오류");
            }
            finally
            {
                conn.Close();

                FillData(1, selectedOrder);
            }
        }

        private void UpdateDB_money(int nID, string strColName, int strValue)
        {



            ///////
            string DBstring = "";
            string NameDB = "";

            if (Db_backup == true)
            {

                NameDB = form1.TACHO2_path + "\\" + MdbFileName;
                /*if ((opendlg == true || form1.tmpopen == true) && !columnclick)
                {
                    //	MdbFileName = Application.StartupPath + "\\" + MdbFileName;
                    //	MdbFileName = "C:\\TACHO2" + "\\" + MdbFileName;
                }*/

                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                //					 Db_backup = false;
                if (columnclick == true)
                {
                    columnclick = false;
                }

            }
            else
            {
                //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            ///////

            OleDbConnection conn = new OleDbConnection(@DBstring);

            try
            {
                conn.Open();

                string queryUpdate = "UPDATE TblTacho SET " + strColName + "='" + strValue
                    + "' WHERE ID=" + nID.ToString();
                OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                commUpdate.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 업데이트 하는데 오류가 발생했습니다.", "오류");
            }
            finally
            {
                conn.Close();

                FillData(0, selectedOrder);
            }
        }
        private void UpdateDB_fuel(int nID, string strColName, double strValue)
        {
            ///////
            string DBstring = "";

            string NameDB = "";

            if (Db_backup == true)
            {

                NameDB = form1.TACHO2_path + "\\" + MdbFileName;
                /*if ((opendlg == true || form1.tmpopen == true) && !columnclick)
                {
                    //	MdbFileName = Application.StartupPath + "\\" + MdbFileName;
                    //	MdbFileName = "C:\\TACHO2" + "\\" + MdbFileName;
                }*/

                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                //					 Db_backup = false;
                if (columnclick == true)
                {
                    columnclick = false;
                }

            }
            else
            {
                //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            ////////

            OleDbConnection conn = new OleDbConnection(@DBstring);

            try
            {
                conn.Open();

                string queryUpdate = "UPDATE TblTacho SET " + strColName + "='" + strValue
                    + "' WHERE ID=" + nID.ToString();
                OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                commUpdate.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 업데이트 하는데 오류가 발생했습니다.", "오류");
            }
            finally
            {
                conn.Close();

                FillData(0, selectedOrder);
            }
        }

        public void SetAlternatingRowColors(ListView lst, Color color1, Color color2)
        {
            //loop through each ListViewItem in the ListView control 
            foreach (ListViewItem item in lst.Items)
            {
                if ((item.Index % 2) == 0)
                    item.BackColor = color1;
                else
                    item.BackColor = color2;

            }
        }
        private void button3_Click(object sender, EventArgs e)   // repeat
        {
            Repaet_btn = true;

            Thread LoadingThread = new Thread(LoadingWork);
            LoadingThread.Start();




        }

        public T[] GEtDistinctValues<T>(T[] array)   // 배열 중복 검사 제거
        {
            List<T> tmp = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                if (tmp.Contains(array[i]))
                    continue;
                tmp.Add(array[i]);
            }
            return tmp.ToArray();
        }
        public void Repeat_Data()
        {


            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
            workerThread.Start();

            Color AliceBlue = Color.FromArgb(240, 248, 255);
            Color LightPink = Color.FromArgb(255, 182, 193);

            int cnt = 0;
            string NameDB = "";
            //	SetAlternatingRowColors(listView1, a, b);

            try
            {

                //	selectedColumnIndex = 4;   // 출고 시간별 정렬
                //	selectedOrder = 1;
                //	FillData(selectedColumnIndex, selectedOrder);

                string DBstring = "";

                if (Db_backup == true)
                {



                    NameDB = form1.TACHO2_path + "\\" + MdbFileName;
                    /*if ((opendlg == true || form1.tmpopen == true) && !columnclick)
                    {
                        //	MdbFileName = Application.StartupPath + "\\" + MdbFileName;
                        //	MdbFileName = "C:\\TACHO2" + "\\" + MdbFileName;
                    }*/

                    DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;

                    //					 Db_backup = false;
                    if (columnclick == true)
                    {
                        columnclick = false;
                    }

                }

                else
                {
                    //DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                    MessageBox.Show("타코파일 선택 되지 않았습니다.!");

                }

                // Fill Data

                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryTblTacho = "SELECT * FROM TblTacho ORDER BY ID DESC";
                OleDbCommand commTblTacho = new OleDbCommand(queryTblTacho, conn);
                OleDbDataReader srRead = commTblTacho.ExecuteReader();


                cnt = listView1.Items.Count - 2;
                string[] dbId = new string[cnt];
                DateTime[] dbOuttime = new DateTime[cnt];
                DateTime[] dbIntime = new DateTime[cnt];
                string[] dbCarnumber = new string[cnt];
                string[] dbCarDriverNo = new string[cnt];
                int[] intdbId = new int[cnt * 3];
                int[] RepeatId = new int[cnt * 3];
                bool RepeatCheck = false;
                int ii = 0;


                while (srRead.Read())   // db 데이터 읽어 오기 아이디 , 차량 번호 ,출고 시간 ,입고시간
                {
                    intdbId[ii] = srRead.GetInt32(0);
                    dbCarnumber[ii] = srRead.GetString(1);
                    dbCarDriverNo[ii] =  srRead.GetString(2);
                    dbOuttime[ii] = srRead.GetDateTime(4);
                    dbIntime[ii] = srRead.GetDateTime(5);
                    ii++;

                }

                int k = 0;
                int[] temp = new int[cnt * 3];
                bool pass = false;


                for (int i = 0; i < cnt; i++)
                {


                    for (int j = 0; j < cnt; j++)
                    {

                        for (int u = 0; u < temp.Length; u++)  // 지운 아이디의 인덱스 루틴패스시킴
                        {
                            if (i != 0)
                            {
                                if (i == temp[u])
                                    pass = true;
                            }

                        }


                        if (i == j || pass == true)  // 자기 자신 건너뛰고 지운데이터 인덱스 건너 뛰기
                        {
                            pass = false;
                            continue;

                        }


                        if (  (dbCarnumber[i] == dbCarnumber[j]) && (dbOuttime[i] == dbOuttime[j]) && (dbCarDriverNo[i] == dbCarDriverNo[j])  )  // 차번호 입고 출고 시간 중복 검사
                        {
                            RepeatId[k] = intdbId[j];
                            temp[k] = j;
                            RepeatCheck = true;


                            k++;

                        }

                    }

                }
                RepeatId = GEtDistinctValues<int>(RepeatId);  // 배열 중복 제거 하기

                //	string aA = listView1.Items[0].SubItems[0].Text;  // 리스트 뷰 id를 텍스트로 얻어오기	

                int[] listviewindex = new int[cnt];

                // 현재의 데이터를 리스트뷰를 읽어 파확한다	
                if (cnt != -2)
                {

                    for (int i = 0; i < RepeatId.Length; i++)  // 중복데이터 라인 색 칠하기
                    {

                        for (int j = 0; j < cnt; j++)
                        {
                            dbId[j] = listView1.Items[j].SubItems[0].Text;   // listview Id -> string
                            intdbId[j] = Int32.Parse(dbId[j]);              //  listview id -> int

                            if (RepeatId[i] == intdbId[j])
                            {

                                listView1.Items[j].BackColor = LightPink;

                            }


                        }

                    }
                    //	workerObject.RequestStop();

                    if (RepeatCheck == true)
                    {
                        string datacnt = (RepeatId.Length - 1).ToString();
                        DialogResult result = MessageBox.Show(datacnt + "개의 중복데이터가 있습니다.삭제 하시겠습니까?", "선택 삭제", MessageBoxButtons.YesNoCancel);
                        //	DialogResult result = MessageBox.Show("중복된 데이터를 삭제 하시겠습니까?", "중복 체크", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < RepeatId.Length; i++)
                            {



                                string queryDelTblTacho = "DELETE FROM TblTacho where ID = " + RepeatId[i].ToString();
                                OleDbCommand comDelDelTblTacho = new OleDbCommand(queryDelTblTacho, conn);
                                comDelDelTblTacho.ExecuteNonQuery();



                            }

                            selectedColumnIndex = 1;   // 출고 시간별 정렬
                            selectedOrder = 1;
                            FillData(selectedColumnIndex, selectedOrder);

                        }
                    }
                    else
                    {
                        if (Repaet_btn == true)
                        {
                            MessageBox.Show("중복된 데이터가 없습니다.", "중복체크");
                        }
                    }


                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                workerObject.RequestStop();
                conn.Close();
            }
            finally
            {
                workerObject.RequestStop();
                conn.Close();



                //		selectedColumnIndex = 4;   // 출고 시간별 정렬
                //		selectedOrder = 1;
                //		FillData(selectedColumnIndex, selectedOrder);


                if (Repaet_btn == true)
                {
                    Repaet_btn = false;
                }
            }
        }




        public void Auto_Repeat_Data()
        {


            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
            workerThread.Start();

            Color AliceBlue = Color.FromArgb(240, 248, 255);
            Color LightPink = Color.FromArgb(255, 182, 193);

            int cnt = 0;
            string NameDB = "";
            //	SetAlternatingRowColors(listView1, a, b);

            try
            {

                //	selectedColumnIndex = 4;   // 출고 시간별 정렬
                //	selectedOrder = 1;
                //	FillData(selectedColumnIndex, selectedOrder);

                string DBstring = "";

                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + form1.CarSum_Path + "\\" + form1.CarSum_DBName;



                //					 Db_backup = false;
                if (columnclick == true)
                {
                    columnclick = false;
                }



                // Fill Data

                conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryTblTacho = "SELECT * FROM TblTacho ORDER BY ID DESC";
                OleDbCommand commTblTacho = new OleDbCommand(queryTblTacho, conn);
                OleDbDataReader srRead = commTblTacho.ExecuteReader();


                cnt = listView1.Items.Count - 2;
                string[] dbId = new string[cnt];
                DateTime[] dbOuttime = new DateTime[cnt];
                DateTime[] dbIntime = new DateTime[cnt];
                string[] dbCarnumber = new string[cnt];

                int[] intdbId = new int[cnt * 3];
                int[] RepeatId = new int[cnt * 3];
                bool RepeatCheck = false;
                int ii = 0;


                while (srRead.Read())   // db 데이터 읽어 오기 아이디 , 차량 번호 ,출고 시간 ,입고시간
                {
                    intdbId[ii] = srRead.GetInt32(0);
                    dbCarnumber[ii] = srRead.GetString(1);
                    dbOuttime[ii] = srRead.GetDateTime(4);
                    dbIntime[ii] = srRead.GetDateTime(5);
                    ii++;

                }

                int k = 0;
                int[] temp = new int[cnt * 3];
                bool pass = false;


                for (int i = 0; i < cnt; i++)
                {


                    for (int j = 0; j < cnt; j++)
                    {

                        for (int u = 0; u < temp.Length; u++)  // 지운 아이디의 인덱스 루틴패스시킴
                        {
                            if (i != 0)
                            {
                                if (i == temp[u])
                                    pass = true;
                            }

                        }


                        if (i == j || pass == true)  // 자기 자신 건너뛰고 지운데이터 인덱스 건너 뛰기
                        {
                            pass = false;
                            continue;

                        }


                        if (dbCarnumber[i] == dbCarnumber[j] && dbOuttime[i] == dbOuttime[j])  // 차번호 입고 출고 시간 중복 검사
                        {
                            RepeatId[k] = intdbId[j];
                            temp[k] = j;
                            RepeatCheck = true;


                            k++;

                        }

                    }

                }
                RepeatId = GEtDistinctValues<int>(RepeatId);  // 배열 중복 제거 하기

                //	string aA = listView1.Items[0].SubItems[0].Text;  // 리스트 뷰 id를 텍스트로 얻어오기	

                int[] listviewindex = new int[cnt];

                // 현재의 데이터를 리스트뷰를 읽어 파확한다	
                if (cnt != -2)
                {

                    for (int i = 0; i < RepeatId.Length; i++)  // 중복데이터 라인 색 칠하기
                    {

                        for (int j = 0; j < cnt; j++)
                        {
                            dbId[j] = listView1.Items[j].SubItems[0].Text;   // listview Id -> string
                            intdbId[j] = Int32.Parse(dbId[j]);              //  listview id -> int

                            if (RepeatId[i] == intdbId[j])
                            {

                                listView1.Items[j].BackColor = LightPink;

                            }


                        }

                    }
                    //	workerObject.RequestStop();

                    if (RepeatCheck == true)
                    {
                        string datacnt = (RepeatId.Length - 1).ToString();
                        //  DialogResult result = MessageBox.Show(datacnt + "개의 중복데이터가 있습니다.삭제 하시겠습니까?", "선택 삭제", MessageBoxButtons.YesNoCancel);
                        //	DialogResult result = MessageBox.Show("중복된 데이터를 삭제 하시겠습니까?", "중복 체크", MessageBoxButtons.YesNo);

                        for (int i = 0; i < RepeatId.Length; i++)
                        {



                            string queryDelTblTacho = "DELETE FROM TblTacho where ID = " + RepeatId[i].ToString();
                            OleDbCommand comDelDelTblTacho = new OleDbCommand(queryDelTblTacho, conn);
                            comDelDelTblTacho.ExecuteNonQuery();



                        }

                        selectedColumnIndex = 1;   // 
                        selectedOrder = 1;
                        FillData(selectedColumnIndex, selectedOrder);


                    }



                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                workerObject.RequestStop();
                conn.Close();
            }
            finally
            {
                workerObject.RequestStop();
                conn.Close();



                //		selectedColumnIndex = 4;   // 출고 시간별 정렬
                //		selectedOrder = 1;
                //		FillData(selectedColumnIndex, selectedOrder);


                if (Repaet_btn == true)
                {
                    Repaet_btn = false;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("데이터를 선택해주세요");
                return;
            }
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                {
                    nOpenedindex = 0;
                    return;
                }
                else
                {
                    nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                }
            }



            formInfo.FillDataEx(nOpenedindex, ds.nIndexOfChangeAMHour, ds.nIndexOfChangePMHour);
            formInfo.MdiParent = this.ParentForm;
            formInfo.BringToFront();
            formInfo.Show();
            formInfo.Focus();




            formGraph.FillData(nOpenedindex);
            formGraph.MdiParent = this.ParentForm;
            formGraph.BringToFront();
            formGraph.Show();
            formGraph.Focus();
            isFormDataDetailFormShow = true;
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                {
                    nOpenedindex = 0;
                }
                else
                {
                    nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                }
            }
        }

        private void listView1_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            if (selectedColumnIndex == e.Column)
            {
                if (selectedOrder == 1)
                    selectedOrder = 0;
                else
                    selectedOrder = 1;
            }
            else
            {
                selectedColumnIndex = e.Column;

                selectedOrder = 1;
            }
            //	opendlg = false;
            columnclick = true;
            FillData(selectedColumnIndex, selectedOrder);
        }

        private void listView1_SubItemClicked(object sender, SubItemEventArgs e)
        {


            try
            {
                if (e.SubItem == 7)
                {
                    //e.Item.SubItems[e.SubItem].Text = e.Item.Tag.ToString();

                  //  listView1.StartEditing(textBox1, e.Item, e.SubItem);
                   // textBox1.Clear();

                }
                if (e.SubItem == 2)
                {
                    //e.Item.SubItems[e.SubItem].Text = e.Item.Tag.ToString();

                    listView1.StartEditing(textBoxDrvInput, e.Item, e.SubItem);

                }
                if (e.SubItem == 3)
                {
                    listView1.StartEditing(textBox3, e.Item, e.SubItem);


                    /*  for (int i = index; i < listView1.Items.Count; i++)
                      {

                          listView1.StartEditing(textBox3, listView1.Items[i], e.SubItem);
                      }*/

                }
                if (e.SubItem == 0)
                {

                    if (listView1.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("데이터를 선택해주세요");
                        return;
                    }
                    ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

                    foreach (ListViewItem item in items)
                    {
                        if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                        {
                            nOpenedindex = 0;
                            return;
                        }
                        else
                        {
                            nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                        }
                    }

                    OverSpeed = form1.OverSpeed;

                    formGraph.FillData(nOpenedindex);
                    formGraph.MdiParent = this.ParentForm;
                    formGraph.BringToFront();
                    formGraph.Show();
                    formGraph.Refresh();

                    //formChart.MdiParent = this.ParentForm;
                    //	formChart.BringToFront();
                    //formChart.Show();

                    formInfo.FillDataEx(nOpenedindex, ds.nIndexOfChangeAMHour, ds.nIndexOfChangePMHour);
                    formInfo.MdiParent = this.ParentForm;
                    formInfo.BringToFront();
                    formInfo.Show();
                    formInfo.Focus();




                    isFormDataDetailFormShow = true;

                }
                if (e.SubItem == 16)
                {

                    listView1.StartEditing(textBox2, e.Item, e.SubItem);
                    textBox2.Clear();

                }
                if (e.SubItem == 1)
                {
                    //MessageBox.Show(e.Item.SubItems[1].Text);

                    string formName = "FormOpenMonth";
                    foreach (System.Windows.Forms.Form theForm in form1.MdiChildren)
                    {
                        if (formName.Equals(theForm.Name))
                        {
                            //해당form의 인스턴스가 존재하면 해당 창을 활성시킨다.
                            theForm.BringToFront();
                            theForm.Focus();

                            CarNumber = e.Item.SubItems[1].Text;
                            formOpenMonth.textBox1.Text = CarNumber;


                            // return;
                        }
                    }

                    formName = "FormMonthTacho";
                    foreach (System.Windows.Forms.Form theForm in form1.MdiChildren)
                    {
                        if (formName.Equals(theForm.Name))
                        {
                            //해당form의 인스턴스가 존재하면 해당 창을 활성시킨다.
                            theForm.BringToFront();
                            theForm.Focus();

                            CarNumber = e.Item.SubItems[1].Text;
                            formMonthTacho.textBox1.Text = CarNumber;


                            // return;
                        }
                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textBox1.Visible = false;
                textBox1.Text = "";
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {


                this.textBox1.Visible = false;
                //this.textBoxDrvInput.Text = "";

                // Update DB
            }
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0)
                {


                    Int32 nTmp = Convert.ToInt32(textBox1.Text);

                    //	listView1.SelectedItems[0].SubItems[7].Text = nTmp.ToString();
                    listView1.SelectedItems[0].SubItems[7].Text = textBox1.Text;

                    UpdateDB_money(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), "실입금액", nTmp);


                }
                else
                {
                    MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
                }

                this.textBox1.Visible = false;
                this.textBox1.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textBox2.Visible = false;
                textBox2.Text = "";
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
            {


                this.textBox2.Visible = false;
                //this.textBoxDrvInput.Text = "";

                // Update DB
            }
            else if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length != 0)
                {


                    double nTmp = Convert.ToDouble(textBox2.Text);

                    //	listView1.SelectedItems[0].SubItems[7].Text = nTmp.ToString();
                    listView1.SelectedItems[0].SubItems[16].Text = textBox2.Text;

                    UpdateDB_fuel(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), "연료량", nTmp);


                }
                else
                {
                    MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
                }

                this.textBox2.Visible = false;
                this.textBox2.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("데이터를 선택해주세요");
                return;
            }

            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                if ((item.SubItems[0].Text.CompareTo("합계") == 0) || (item.SubItems[0].Text.CompareTo("평균") == 0))
                {
                    nOpenedindex = 0;
                    return;
                }
                else
                {
                    nOpenedindex = Convert.ToInt32(item.SubItems[0].Text);
                }
            }*/

            if (radioButton기사별보기.Checked == true)
            {
                Driverilbo = true;
                formDayInfoCal = new FormDayInfoCal(this);
                formDayInfoCal.MdiParent = this.ParentForm;
                formDayInfoCal.BringToFront();
                formDayInfoCal.Show();
            }
            else if (radioButton차량별보기.Checked == true)
            {
                Carilbo = true;
                formDayInfoCal = new FormDayInfoCal(this);
                formDayInfoCal.MdiParent = this.ParentForm;
                formDayInfoCal.BringToFront();
                formDayInfoCal.Show();
            }
            else if (radioButton차량기사.Checked == true)
            {
                Car_Driverilbo = true;
                int indexcount = 0;
                for (int j = 0; j < listView1.Items.Count - 2; j++)
                {
                    string car = "";
                    string driver = "";

                    driver = listView1.Items[j].SubItems[2].Text;
                    car = listView1.Items[j].SubItems[1].Text;

                    if (combo_driver_str == driver && combo_car_str == car)
                    {
                        indexcount++;
                    }




                }
                formDayInfo = new FormDayInfo(this);
                formDayInfo.FillData(combo_car_str, indexcount);
                formDayInfo.MdiParent = this.ParentForm;
                formDayInfo.BringToFront();
                formDayInfo.Show();
            }
            else
            {
                Driverilbo = false;
                Car_Driverilbo = false;
                Carilbo = false;
                formDayInfoCal = new FormDayInfoCal(this);
                formDayInfoCal.MdiParent = this.ParentForm;
                formDayInfoCal.BringToFront();
                formDayInfoCal.Show();
            }

           



            /*formdayInfo = new FormDayInfo(this);

            formdayInfo.FillData(nOpenedindex);
            formdayInfo.MdiParent = this.ParentForm;
            formdayInfo.BringToFront();
            formdayInfo.Show();*/


        }




        private void button6_Click(object sender, EventArgs e)
        {
            //CaptureScreen();
            //	CaptureScreen1();
            // pd = new PrintDocument();
            /*	ID = 1;
                indexid = 1;
                print_start = false;
		
                 PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = true;
                PrintPreviewDialog ppd = new PrintPreviewDialog();
			
                pd.PrintPage += new PrintPageEventHandler(DayTotal_PrintPage);
			
            //	PageSettings ps = new PageSettings();
            //	ps.Landscape = false;
                ppd.Document = pd;
		
                ppd.ShowDialog();*/


            DB_Print();
            ID = 1;
            indexid = 1;
            print_start = false;

            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();

            printDialog1.AllowSomePages = true;

            // Show the help button.
            printDialog1.ShowHelp = true;

            printDialog1.Document = printDocument1;






        }


        private void DayTotal_PrintPage(object sender, PrintPageEventArgs e)
        {


            float linesPerPage = 0;
            float yPos = 0;
            int count1 = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float x = e.MarginBounds.Left - 10;
            float y = e.MarginBounds.Top + 80;
            float width = 50.0F;
            float height = 50.0F;
            int cnt = 0;

            String drawString = "";
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            RectangleF drawRect = new RectangleF(x, y, width, height);

            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Black);
            //e.Graphics.DrawRectangle(blackPen, x, y, 40, 40);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            if (print_start == false)
            {



                drawFont = new Font("Arial", 16);
                drawString = "♣ 전 차 량  운 행 일 보 ♣";
                drawRect = new RectangleF(x - 100, y - 140, width + 300, height);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);






            }
            drawFont = new Font("Arial", 10);
            //e.Graphics.DrawLine(blackPen, 20,100  ,1100,100);
            e.Graphics.DrawRectangle(blackPen, 25, 90, 1000, 25);
            //	e.Graphics.DrawRectangle(blackPen, 25, 115, 1000, 25);



            drawString = "구분";
            drawRect = new RectangleF(15, 92, 50, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


            drawString = "차량번호";
            drawRect = new RectangleF(60, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

            drawString = "기사번호";
            drawRect = new RectangleF(144, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

            drawString = "미터요금";
            drawRect = new RectangleF(238, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

            drawString = "영업거리";
            drawRect = new RectangleF(338, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


            drawString = "운행거리";
            drawRect = new RectangleF(438, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


            drawString = "운행시간";
            drawRect = new RectangleF(538, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


            drawString = "영업시간";
            drawRect = new RectangleF(638, 92, 92, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

            drawString = "출고시간";
            drawRect = new RectangleF(708, 92, 202, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


            drawString = "입고시간";
            drawRect = new RectangleF(838, 92, 202, 30);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

            for (int i = 0; i < 28; i++)
            {
                e.Graphics.DrawRectangle(blackPen, 25, 90 + cnt, 1000, 25);
                e.Graphics.DrawLine(blackPen, 60, 90, 60, 790);
                e.Graphics.DrawLine(blackPen, 145, 90, 145, 790);
                e.Graphics.DrawLine(blackPen, 230, 90, 230, 790);
                e.Graphics.DrawLine(blackPen, 330, 90, 330, 790);
                e.Graphics.DrawLine(blackPen, 430, 90, 430, 790);
                e.Graphics.DrawLine(blackPen, 535, 90, 535, 790);
                e.Graphics.DrawLine(blackPen, 630, 90, 630, 790);
                e.Graphics.DrawLine(blackPen, 730, 90, 730, 790);
                e.Graphics.DrawLine(blackPen, 870, 90, 870, 790);

                cnt += 25;
            }

            int count = 0;

            string IDstr = "";
            string CarNum = "";
            string DriverNum = "";
            string MeterMoney = "";
            string SalesDistance = "";
            string TotalDistance = "";
            string TotalTime = "";
            string SalesTime = "";
            string Outtimestr = "";
            string InTimestr = "";
            float yypos = 92;

            string DBstring = "";

            if (Db_backup == true)
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + MdbFileName;
                //					 Db_backup = false;


            }
            else
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            string queryRead = "select * from TblTacho";

            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            conn1.Open();


            OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
            OleDbDataReader srRead = commRead.ExecuteReader();

            while (srRead.Read() && count < 675)
            {

                if (print_start)
                {
                    if (indexid != ID)
                    {
                        indexid++;
                        continue;
                    }
                }

                DateTime readToday = srRead.GetDateTime(5);
                DateTime outT = srRead.GetDateTime(4);



                //DateTime inT = srRead.GetDateTime(5);
                DateTime inT = readToday;
                TimeSpan dT = inT - outT;
                TimeSpan eT = dT;

                int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;

                TotalTime = String.Format("{0:D}시간 {1:D2}분", (driveT / 60), (driveT % 60));


                count += 25;
                IDstr = ID.ToString();
                drawRect = new RectangleF(15, yypos + count, 50, 30);
                e.Graphics.DrawString(IDstr, drawFont, drawBrush, drawRect, drawFormat);


                CarNum = srRead.GetString(1);
                drawRect = new RectangleF(50, yypos + count, 100, 30);
                e.Graphics.DrawString(CarNum, drawFont, drawBrush, drawRect, drawFormat);

                DriverNum = srRead.GetString(2);
                drawRect = new RectangleF(130, yypos + count, 100, 30);
                e.Graphics.DrawString(DriverNum, drawFont, drawBrush, drawRect, drawFormat);

                int money = 0;
                money = (int)srRead.GetDecimal(6);

                MeterMoney = String.Format("{0:C}", money);
                drawRect = new RectangleF(230, yypos + count, 100, 30);
                e.Graphics.DrawString(MeterMoney, drawFont, drawBrush, drawRect, drawFormat);

                double salesDistance = srRead.GetDouble(8);
                SalesDistance = String.Format("{0:N} Km", salesDistance);
                drawRect = new RectangleF(330, yypos + count, 100, 30);
                e.Graphics.DrawString(SalesDistance, drawFont, drawBrush, drawRect, drawFormat);


                double totalDistance = srRead.GetDouble(9);
                TotalDistance = String.Format("{0:N} Km", totalDistance);
                drawRect = new RectangleF(430, yypos + count, 110, 30);
                e.Graphics.DrawString(TotalDistance, drawFont, drawBrush, drawRect, drawFormat);


                drawRect = new RectangleF(530, yypos + count, 100, 30);
                e.Graphics.DrawString(TotalTime, drawFont, drawBrush, drawRect, drawFormat);

                DateTime Sales_Time = new DateTime();
                TimeSpan salesT = new TimeSpan();
                Sales_Time = srRead.GetDateTime(19);
                DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
                salesT = Sales_Time - Sales_Time_t;
                SalesTime = String.Format(salesT.Hours.ToString() + "시간 " + salesT.Minutes.ToString() + "분");

                drawRect = new RectangleF(630, yypos + count, 100, 30);
                e.Graphics.DrawString(SalesTime, drawFont, drawBrush, drawRect, drawFormat);

                DateTime OutTime = new DateTime();
                DateTime InTime = new DateTime();

                OutTime = srRead.GetDateTime(4);
                InTime = srRead.GetDateTime(5);


                Outtimestr = String.Format(@"{0:HH시mm분}", OutTime);
                drawRect = new RectangleF(750, yypos + count, 100, 30);
                e.Graphics.DrawString(Outtimestr, drawFont, drawBrush, drawRect, drawFormat);


                InTimestr = String.Format(@"{0:HH시mm분}", InTime);
                drawRect = new RectangleF(880, yypos + count, 100, 30);
                e.Graphics.DrawString(InTimestr, drawFont, drawBrush, drawRect, drawFormat);


                ID++;



            }
            if (print_start == false)
            {
                print_start = true;
            }

            if (srRead.Read())
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                ID = 1;
                indexid = 1;
            }

        }
        //	    private StreamReader streamToPrint;
        //  static string filePath;

        int dbcnt = 0;
        int qq = 0;
        string[] str;

        public void DB_Print()
        {
            string DBstring = "";

            if (Db_backup == true)
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + MdbFileName;
                //					 Db_backup = false;


            }
            else
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            string queryRead = "select * from TblTacho";

            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            conn1.Open();


            OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
            OleDbDataReader srRead = commRead.ExecuteReader();
            int j = 0;
            while (srRead.Read())
            {
                j++;

            }
            dbcnt = j;
            str = new string[dbcnt];
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count1 = 0;
            //float leftMargin = e.MarginBounds.Left;
            //float topMargin = e.MarginBounds.Top;
            string line = null;
            float x = e.MarginBounds.Left - 10;
            float y = e.MarginBounds.Top + 80;
            float width = 50.0F;
            float height = 50.0F;
            int cnt = 0;

            String drawString = "";
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            RectangleF drawRect = new RectangleF(x, y, width, height);

            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Black);
            //e.Graphics.DrawRectangle(blackPen, x, y, 40, 40);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            /*	if (print_start == false)
                {

				

                    drawFont = new Font("Arial", 16);
                    drawString = "♣ 전 차 량  운 행 일 보 ♣";
                    drawRect = new RectangleF(x - 100, y - 140, width + 300, height);
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                    print_start = true;


			

                }
                    drawFont = new Font("Arial", 10);
                    //e.Graphics.DrawLine(blackPen, 20,100  ,1100,100);
                    e.Graphics.DrawRectangle(blackPen, 25, 90, 1000, 25);
                    //	e.Graphics.DrawRectangle(blackPen, 25, 115, 1000, 25);
				
		

                drawString = "구분";
                drawRect = new RectangleF(15, 92, 50, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

			
                drawString = "차량번호";
                drawRect = new RectangleF(60, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                drawString = "기사번호";
                drawRect = new RectangleF(144, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                drawString = "미터요금";
                drawRect = new RectangleF(238, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                drawString = "영업거리";
                drawRect = new RectangleF(338, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


                drawString = "운행거리";
                drawRect = new RectangleF(438, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


                drawString = "운행시간";
                drawRect = new RectangleF(538, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


                drawString = "영업시간";
                drawRect = new RectangleF(638, 92, 92, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                drawString = "출고시간";
                drawRect = new RectangleF(708, 92, 202, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


                drawString = "입고시간";
                drawRect = new RectangleF(838, 92, 202, 30);
                e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                for (int i = 0; i < 28; i++)
                {
                    e.Graphics.DrawRectangle(blackPen, 25, 90 + cnt, 1000, 25);
                    e.Graphics.DrawLine(blackPen, 60, 90, 60, 790);
                    e.Graphics.DrawLine(blackPen, 145, 90, 145, 790);
                    e.Graphics.DrawLine(blackPen, 230, 90, 230, 790);
                    e.Graphics.DrawLine(blackPen, 330, 90, 330, 790);
                    e.Graphics.DrawLine(blackPen, 430, 90, 430, 790);
                    e.Graphics.DrawLine(blackPen, 535, 90, 535, 790);
                    e.Graphics.DrawLine(blackPen, 630, 90, 630, 790);
                    e.Graphics.DrawLine(blackPen, 730, 90, 730, 790);
                    e.Graphics.DrawLine(blackPen, 870, 90, 870, 790);

                    cnt += 25;
                }		

                int count = 0;
		
                string IDstr = "";
                string CarNum = "";
                string DriverNum = "";
                string MeterMoney = "";
                string SalesDistance = "";
                string TotalDistance = "";
                string TotalTime = "";
                string SalesTime = "";
                string Outtimestr = "";
                string InTimestr = "";*/
            float yypos = 92;




            for (int i = 0; i < dbcnt; i++)
            {
                int a = i + 1;
                str[i] = a.ToString();
            }

            while (qq < 675)
            {
                qq += 25;
                drawRect = new RectangleF(15, yypos + qq, 50, 30);
                e.Graphics.DrawString(str[str.Length - dbcnt], drawFont, drawBrush, drawRect, drawFormat);
                dbcnt--;
            }

            if (dbcnt < 1)
            {
                e.HasMorePages = false;
                dbcnt = 0;


            }
            else
            {
                qq = 0;
                e.HasMorePages = true;


            }



            string DBstring = "";

            /*if (Db_backup == true)
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + MdbFileName;
                //					 Db_backup = false;


            }
            else
            {
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            string queryRead = "select * from TblTacho";

            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            conn1.Open();


            OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
            OleDbDataReader srRead = commRead.ExecuteReader();
	
            while (srRead.Read()&& count <675)
            {

                if (print_start)
                {
                    if (indexid != ID)
                    {
                        indexid++;
                        continue;
                    }
                }

                DateTime readToday = srRead.GetDateTime(5);
                DateTime outT = srRead.GetDateTime(4);



                //DateTime inT = srRead.GetDateTime(5);
                DateTime inT = readToday;
                TimeSpan dT = inT - outT;
                TimeSpan eT = dT;

                int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes; 

                TotalTime = String.Format("{0:D}시간 {1:D2}분", (driveT / 60), (driveT % 60));


                count += 25;
                IDstr = ID.ToString();
                drawRect = new RectangleF(15, yypos + count, 50, 30);
                e.Graphics.DrawString(IDstr, drawFont, drawBrush, drawRect, drawFormat);
		

                CarNum = srRead.GetString(1);
                drawRect = new RectangleF(50, yypos + count, 100, 30);
                e.Graphics.DrawString(CarNum, drawFont, drawBrush, drawRect, drawFormat);

                DriverNum = srRead.GetString(2);
                drawRect = new RectangleF(130, yypos + count, 100, 30);
                e.Graphics.DrawString(DriverNum, drawFont, drawBrush, drawRect, drawFormat);

                int money = 0;
                money = (int)srRead.GetDecimal(6);

                MeterMoney = String.Format("{0:C}", money);
                drawRect = new RectangleF(230, yypos + count, 100, 30);
                e.Graphics.DrawString(MeterMoney, drawFont, drawBrush, drawRect, drawFormat);

                double salesDistance = srRead.GetDouble(8);
                SalesDistance = String.Format("{0:N} Km", salesDistance);
                drawRect = new RectangleF(330, yypos + count, 100, 30);
                e.Graphics.DrawString(SalesDistance, drawFont, drawBrush, drawRect, drawFormat);


                double totalDistance = srRead.GetDouble(9);
                TotalDistance = String.Format("{0:N} Km", totalDistance);
                drawRect = new RectangleF(430, yypos + count, 110, 30);
                e.Graphics.DrawString(TotalDistance, drawFont, drawBrush, drawRect, drawFormat);


                drawRect = new RectangleF(530, yypos + count, 100, 30);
                e.Graphics.DrawString(TotalTime, drawFont, drawBrush, drawRect, drawFormat);

                DateTime Sales_Time = new DateTime();
                TimeSpan salesT = new TimeSpan();
                Sales_Time = srRead.GetDateTime(19);
                DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
                salesT = Sales_Time - Sales_Time_t;
                SalesTime = String.Format(salesT.Hours.ToString() + "시간 " + salesT.Minutes.ToString() + "분");

                drawRect = new RectangleF(630, yypos + count, 100, 30);
                e.Graphics.DrawString(SalesTime, drawFont, drawBrush, drawRect, drawFormat);

                DateTime OutTime = new DateTime();
                DateTime InTime = new DateTime();

                OutTime = srRead.GetDateTime(4);
                InTime = srRead.GetDateTime(5);


                Outtimestr = String.Format(@"{0:HH시mm분}", OutTime);
                drawRect = new RectangleF(750, yypos + count, 100, 30);
                e.Graphics.DrawString(Outtimestr, drawFont, drawBrush, drawRect, drawFormat);


                InTimestr = String.Format(@"{0:HH시mm분}", InTime);
                drawRect = new RectangleF(880, yypos + count, 100, 30);
                e.Graphics.DrawString(InTimestr, drawFont, drawBrush, drawRect, drawFormat);
		

                ID++;
			


            }
            if (print_start == false)
            {
                print_start = true;
            }

            if (srRead.Read())
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                ID = 1;
                indexid = 1;
            }*/
            //	conn.Close();
            //	e.HasMorePages = true;
            // Draw string to screen.
            //	e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
            workerThread.Start();

            List<int> liID = new List<int>();
            int cnt = 0;
            Color AliceBlue = Color.FromArgb(240, 248, 255);
            Color LightPink = Color.FromArgb(255, 182, 193);


            int CarCount = 0;
            ArrayList list = new ArrayList();

            for (int j = 0; j < listView1.Items.Count - 2; j++)     // 차량 리스트 가져오기
            {
                string cbc = listView1.Items[j].SubItems[1].Text;

                if (list.Contains(cbc)) continue;
                list.Add(cbc);


            }
            string[] Carlist = new string[list.Count];
            cnt = CarCount = list.Count;


            if (listView1.Items.Count == 0 || listView1.Items.Count == 1)
                return;

            for (int n = 0; n < list.Count; n++)
            {
                liID.Clear();

                for (int j = 0; j < listView1.Items.Count - 2; j++)
                {
                    string cbc = listView1.Items[j].SubItems[1].Text;
                    if ((string)list[n] == cbc)                                 //차량에 관한 중복 아이뒤 차기
                    {
                        int id = Convert.ToInt32(listView1.Items[j].SubItems[0].Text);
                        listView1.Items[j].BackColor = LightPink;

                        listView1.Items[j].Selected = true;
                        liID.Add(id);
                    }
                }
                cnt = liID.Count;

                if (cnt < 2)
                {
                    FillData(0, 1);
                    continue;

                }

                string[] CarNo = new string[cnt];
                DateTime[] OutTime = new DateTime[cnt];
                DateTime[] InTime = new DateTime[cnt];
                int[] Money = new int[cnt];
                double[] SalesDist = new double[cnt];
                double[] TotalDist = new double[cnt];
                DateTime[] OverSpeed = new DateTime[cnt];
                int[] QuickStop = new int[cnt];
                int[] DriveBasic = new int[cnt];
                int[] DriveAfter = new int[cnt];
                int[] PremiumBasic = new int[cnt];
                int[] PremiumAfter = new int[cnt];
                string[] Door = new string[cnt];
                int[] SalesCnt = new int[cnt];

                DateTime[] SalesTime = new DateTime[cnt];
                int[] KongChaTime = new int[cnt];
                int[] Key = new int[cnt];

                string[] GraphTime = new string[cnt];
                byte[,] GraphSpeed = new byte[125000, cnt];
                byte[,] GraphDistance = new byte[125000, cnt];
                string[] GraphEngine = new string[cnt];
                string[] GraphSaleds = new string[cnt];
                byte[,] SalesDetail = new byte[125000, cnt];
                byte[,] QucikStopData = new byte[125000, cnt];


                // DateTime OutTime = new DateTime();
                //  DateTime InTime = new DateTime();
                /////////

                string DBstring = "";
                string NameDB = "";

                NameDB = TACHO2_path + MdbFileName;
                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;

                OleDbConnection conn = new OleDbConnection(@DBstring);
                conn.Open();

                int q = 0;
                int h = 0;
                int[] fdcnt = new int[cnt];
                int[] Qfdcnt = new int[cnt];


                for (int k = 0; k < liID.Count; k++)
                {
                    //  System.Threading.Thread.Sleep(1000);
                    string queryRead1 = "SELECT * FROM TblTacho WHERE ID=" + liID[k].ToString();
                    OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
                    OleDbDataReader srRead = commRead1.ExecuteReader();

                    while (srRead.Read())
                    {

                        byte[] Speed_Temp = new byte[125000];
                        byte[] Distance_Temp = new byte[125000];
                        byte[] SalesDetail_Temp = new byte[125000];
                        byte[] QuickStopTemp = new byte[125000];

                        CarNo[k] = srRead.GetString(1);             // CarNumber
                        OutTime[k] = srRead.GetDateTime(4);         // 출고
                        InTime[k] = srRead.GetDateTime(5);          // 입고
                        Money[k] = (int)srRead.GetDecimal(6);       // 미터 수입
                        SalesDist[k] = srRead.GetDouble(8);         // 영업거리
                        TotalDist[k] = srRead.GetDouble(9);         // 주행거리
                        OverSpeed[k] = srRead.GetDateTime(11);      // 과속시간
                        QuickStop[k] = srRead.GetInt32(12);
                        DriveBasic[k] = srRead.GetInt32(13);
                        DriveAfter[k] = srRead.GetInt32(14);
                        PremiumBasic[k] = srRead.GetInt32(15);
                        PremiumAfter[k] = srRead.GetInt32(16);
                        Door[k] = srRead.GetString(17);
                        SalesCnt[k] = srRead.GetInt32(18);
                        SalesTime[k] = srRead.GetDateTime(19);
                        KongChaTime[k] = srRead.GetInt32(20);
                        Key[k] = srRead.GetInt32(21);
                        GraphTime[k] = srRead.GetString(22);


                        srRead.GetBytes(23, 0, Speed_Temp, 0, 125000);

                        srRead.GetBytes(24, 0, Distance_Temp, 0, 125000);

                        for (int a = 0; a < Speed_Temp.Length; a++)
                        {
                            GraphSpeed[a, k] = Speed_Temp[a];
                            GraphDistance[a, k] = Distance_Temp[a];
                        }

                        GraphEngine[k] = srRead.GetString(25);   // 엔진
                        GraphSaleds[k] = srRead.GetString(26);   // 영업

                        srRead.GetBytes(27, 0, SalesDetail_Temp, 0, 125000);



                        for (int a = 0; a < SalesDetail_Temp.Length; a++)
                        {
                            if (SalesDetail_Temp[a] == 0xfd)
                            {
                                fdcnt[q]++;
                            }

                            SalesDetail[a, k] = SalesDetail_Temp[a];

                        }
                        fdcnt[q] *= 34;
                        q++;

                        srRead.GetBytes(28, 0, QuickStopTemp, 0, 125536);

                        for (int a = 0; a < QuickStopTemp.Length; a++)
                        {
                            if (QuickStopTemp[a] == 0xfd)
                            {
                                Qfdcnt[h]++;
                            }
                            QucikStopData[a, k] = QuickStopTemp[a];
                        }
                        Qfdcnt[h] *= 24;
                        h++;



                    }
                }


                //  if (MessageBox.Show(CarNo[0].ToString() + "  차량 데이터를 합치 시겠습니까?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                // {

                DateTime TTOutTime = new DateTime();
                DateTime TTInTime = new DateTime();
                int TTMoney = 0;
                double TTSalesDist = 0;
                double TTTotalDist = 0;
                DateTime TTOverSpeed = new DateTime();
                int OverSpeedHour = 0;
                int OverSpeedMinute = 0;
                int TTQuikStop = 0;
                int TTDriveBasic = 0;
                int TTDriveAfter = 0;
                int TTPremiumBasic = 0;
                int TTPremiumAfter = 0;
                string TTDoor = "";
                int TTSalesCnt = 0;
                TimeSpan TTSalesTime = new TimeSpan();
                int TTKongChaTime = 0;
                int TTKey = 0;
                int SalesTimeHour = 0;
                int SalesTimeMinute = 0;
                int[] index = new int[cnt];
                string TTGraphTime = "";
                byte[] TTGraphSpeed = new byte[125000];
                byte[] TTGraphDistance = new byte[125000];
                string TTGraphEngine = "";
                string TTGraphSales = "";
                byte[] TTSalesDetail = new byte[125000];
                byte[] TTQucikStopData = new byte[125000];



                for (int i = 0; i < cnt; i++)
                {
                    for (int j = 0; j < cnt; j++)
                    {
                        /* if (OutTime[i] < OutTime[j])      // 최초 출고 시간
                         {

                             TTOutTime = OutTime[i];
                         }*/
                        if (InTime[i] > InTime[j])        // 마지막  입고 시간 
                        {
                            //     TTInTime = InTime[i];
                            index[i]++;                   //각각 시간의 순서를 결정한다.
                        }
                    }
                    TTMoney += Money[i];
                    TTSalesDist += SalesDist[i];
                    TTTotalDist += TotalDist[i];
                    OverSpeedHour += OverSpeed[i].Hour;
                    OverSpeedMinute += OverSpeed[i].Minute;
                    TTQuikStop += QuickStop[i];
                    TTDriveBasic += DriveBasic[i];
                    TTDriveAfter += DriveAfter[i];
                    TTPremiumBasic += PremiumBasic[i];
                    TTPremiumAfter += PremiumAfter[i];
                    TTDoor += Door[i];
                    TTSalesCnt += SalesCnt[i];
                    SalesTimeHour += SalesTime[i].Hour;
                    SalesTimeMinute += SalesTime[i].Minute;
                    TTKongChaTime += KongChaTime[i];
                    TTKey += Key[i];


                }

                for (int i = 0; i < index.Length; i++)
                {
                    if (index[i] == 0)
                    {
                        TTOutTime = OutTime[i];
                    }
                    else if (index[i] == (index.Length - 1))
                    {
                        TTInTime = InTime[i];
                    }
                }
                if (TTInTime.Year < 2000)
                {
                    MessageBox.Show("중복 데이터 입니다. 합칠수 없습니다.!!");
                    FillData(0, 1);
                    continue;
                }

                bool repeatdata = false;
                for (int i = 0; i < InTime.Length; i++)
                {
                    for (int j = 0; j < InTime.Length; j++)
                    {
                        if (i != j)
                        {
                            if (InTime[i] == InTime[j])
                            {
                                //     MessageBox.Show("중복 데이터 입니다. 합칠수 없습니다.!!");
                                repeatdata = true;
                            }
                        }
                    }
                }

                if (repeatdata == true)
                {
                    FillData(0, 1);
                    MessageBox.Show("중복 데이터 입니다. 합칠수 없습니다.!!");
                    continue;
                }

                if (OverSpeedMinute >= 60)
                {
                    OverSpeedMinute -= 60;
                    OverSpeedHour += 1;

                }
                int dayy = 1;

                if (OverSpeedHour > 12)
                {
                    dayy = OverSpeedHour / 12;

                    OverSpeedHour = OverSpeedHour - (dayy * 12);
                }


                TTOverSpeed = new DateTime(2012, 1, dayy, OverSpeedHour, OverSpeedMinute, 0);
                //    TTOverSpeed = new DateTime(2012, 1, 1, 0, 0, 0);
                //   TTOverSpeed.AddHours(OverSpeedHour);
                //   TTOverSpeed.AddMinutes(OverSpeedMinute);

                TTSalesTime = new TimeSpan(SalesTimeHour, SalesTimeMinute, 0);
                int ccnt = 0;
                int qcnt = 0;
                int zcnt = 0;


                for (int i = 0; i < cnt; i++)
                {
                    for (int j = 0; j < cnt; j++)
                    {
                        if (i == index[j])                        // 시간 순서대로 합치기
                        {
                            TTGraphTime += GraphTime[j];
                            TTGraphEngine += GraphEngine[j];
                            TTGraphSales += GraphSaleds[j];
                            for (int a = 0; a < GraphEngine[j].Length; a++)
                            {
                                TTGraphSpeed[ccnt] = GraphSpeed[a, j];
                                TTGraphDistance[ccnt] = GraphDistance[a, j];
                                ccnt++;
                            }
                            for (int u = 0; u < fdcnt[j]; u++)
                            {
                                TTSalesDetail[qcnt] = SalesDetail[u, j];
                                qcnt++;
                            }
                            for (int u = 0; u < Qfdcnt[j]; u++)
                            {
                                TTQucikStopData[zcnt] = QucikStopData[u, j];
                                zcnt++;
                            }

                        }
                    }
                }


                try
                {


                    OleDbCommand commTblTacho = new OleDbCommand();

                    // Fill DB - TblTacho
                    string queryTblTacho = "Insert into TblTacho ( 차량No, 기사No,기사이름,출고시간, 입고시간, "
                                            + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                                            + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                                            + "영업회수, 영업시간, 공차시간, 키사용,그래프시간,그래프속도,그래프거리,그래프엔진,그래프영업,상세영업,급제동데이터"
                                            + ") values(?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?)";

                    commTblTacho = new OleDbCommand(queryTblTacho, conn);

                    commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = CarNo[0];
                    commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = 0;
                    commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = "";
                    commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = TTOutTime;
                    commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = TTInTime;
                    commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = TTMoney;  // 11.06.27 추가
                    commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = 0;
                    commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = TTSalesDist;  // 총 영업거리

                    commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = TTTotalDist;
                    commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = 0;

                    commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = TTOverSpeed;
                    commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = TTQuikStop;
                    commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = TTDriveBasic;
                    commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = TTDriveAfter;
                    commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = TTPremiumBasic;
                    commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = TTPremiumAfter;
                    commTblTacho.Parameters.Add("문개폐", OleDbType.Char).Value = TTDoor;
                    commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = TTSalesCnt;


                    commTblTacho.Parameters.Add("영업시간", OleDbType.DBTime).Value = TTSalesTime;
                    commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = TTKongChaTime;
                    commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = TTKey;


                    commTblTacho.Parameters.Add("그래프시간", OleDbType.Char).Value = TTGraphTime;
                    commTblTacho.Parameters.Add("그래프속도", OleDbType.Binary).Value = TTGraphSpeed;
                    commTblTacho.Parameters.Add("그래프거리", OleDbType.Binary).Value = TTGraphDistance;
                    commTblTacho.Parameters.Add("그래프엔진", OleDbType.Char).Value = TTGraphEngine;
                    commTblTacho.Parameters.Add("그래프영업", OleDbType.Char).Value = TTGraphSales;

                    commTblTacho.Parameters.Add("상세영업", OleDbType.Binary).Value = TTSalesDetail;
                    commTblTacho.Parameters.Add("급제동데이터", OleDbType.Binary).Value = TTQucikStopData;
                    conn.ResetState();
                    commTblTacho.ExecuteNonQuery();
                    conn.Close();
                    //	}
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //   MessageBox.Show("데이터 합치기 완료!");

                // if (MessageBox.Show("합치기 예전 데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                //  {
                //  List<int> liID = new List<int>();
                cnt = 0;

                cnt = listView1.SelectedItems.Count;

                string Selmetermoney = "";  // 미터 수입 
                string SalesDistance = ""; // 영업거리
                string TotalDistance = "";
                string tBreaek = "";		// 급제동
                string DriveBasic1 = "";		//주행기본
                string tDA = "";			//주행이후
                string tAB = "";			//할증기본
                string tAA = "";					// 할증이후

                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    //liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));


                    Selmetermoney = listView1.SelectedItems[i].SubItems[6].Text;  // 미터 수입 추출
                    SalesDistance = listView1.SelectedItems[i].SubItems[8].Text; // 영업거리
                    TotalDistance = listView1.SelectedItems[i].SubItems[9].Text;  // 주행거리
                    tBreaek = listView1.SelectedItems[i].SubItems[11].Text;  // 급제동
                    DriveBasic1 = listView1.SelectedItems[i].SubItems[12].Text;  //주행기본
                    tDA = listView1.SelectedItems[i].SubItems[13].Text;
                    tAB = listView1.SelectedItems[i].SubItems[14].Text;
                    tAA = listView1.SelectedItems[i].SubItems[15].Text;

                    Selmetermoney = Selmetermoney.Replace(",", "");
                    Selmetermoney = Selmetermoney.Replace("₩", "");
                    Selmetermoney = Selmetermoney.Replace(@"₩", "");
                    Selmetermoney = Selmetermoney.Replace("\\", "");
                    Selmetermoney = Selmetermoney.Replace(".", "");



                    SalesDistance = SalesDistance.Replace(",", "");
                    SalesDistance = SalesDistance.Replace(".", "");
                    SalesDistance = SalesDistance.Replace("Km", "");

                    TotalDistance = TotalDistance.Replace(",", "");
                    TotalDistance = TotalDistance.Replace(".", "");
                    TotalDistance = TotalDistance.Replace("Km", "");

                    total.tMoney -= (int)Int32.Parse(Selmetermoney);  // 미터 수입 
                    total.tDistS -= (double)Int32.Parse(SalesDistance) / 100;  // 영업거리
                    total.tDistD -= (double)Int32.Parse(TotalDistance) / 100;  // 주행거리
                    total.tB -= (int)Int32.Parse(tBreaek);					// 급제동
                    total.tDB -= (int)Int32.Parse(DriveBasic1);             // 주행기본
                    total.tDA -= (int)Int32.Parse(tDA);					//주행이후
                    total.tAB -= (int)Int32.Parse(tAB);					//할증기본
                    total.tAA -= (int)Int32.Parse(tAA);					//할증이후
                    //   }


                    //  Thread LoadingThread = new Thread(DeleteDB(liID));
                    // LoadingThread.Start();

                    if (DeleteDB(liID))
                    {
                        //  FillData(0, 1);

                        //     MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");

                        if (listView1.Items.Count == 1)
                        {
                            //	MessageBox.Show("listView1.Items[0].Remove();");
                            listView1.Items[0].Remove();
                        }
                        System.Threading.Thread.Sleep(1000);
                    }

                }

                //  }

                FillData(0, 1);

            }

            workerObject.RequestStop();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<int> liID = new List<int>();       //선택한 ID 추출
            int cnt = 0;



            cnt = listView1.SelectedItems.Count;

            if (cnt == 0 || cnt == 1)
                return;

            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));

            }

            string[] CarNo = new string[cnt];
            DateTime[] OutTime = new DateTime[cnt];
            DateTime[] InTime = new DateTime[cnt];
            int[] Money = new int[cnt];
            double[] SalesDist = new double[cnt];
            double[] TotalDist = new double[cnt];
            DateTime[] OverSpeed = new DateTime[cnt];
            int[] QuickStop = new int[cnt];
            int[] DriveBasic = new int[cnt];
            int[] DriveAfter = new int[cnt];
            int[] PremiumBasic = new int[cnt];
            int[] PremiumAfter = new int[cnt];
            string[] Door = new string[cnt];
            int[] SalesCnt = new int[cnt];

            DateTime[] SalesTime = new DateTime[cnt];
            int[] KongChaTime = new int[cnt];
            int[] Key = new int[cnt];

            string[] GraphTime = new string[cnt];
            byte[,] GraphSpeed = new byte[125000, cnt];
            byte[,] GraphDistance = new byte[125000, cnt];
            string[] GraphEngine = new string[cnt];
            string[] GraphSaleds = new string[cnt];
            byte[,] SalesDetail = new byte[125000, cnt];
            byte[,] QucikStopData = new byte[125000, cnt];


            // DateTime OutTime = new DateTime();
            //  DateTime InTime = new DateTime();
            /////////

            string DBstring = "";
            string NameDB = "";

            NameDB = TACHO2_path + MdbFileName;
            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;

            OleDbConnection conn = new OleDbConnection(@DBstring);
            conn.Open();

            int q = 0;
            int h = 0;
            int[] fdcnt = new int[cnt];
            int[] Qfdcnt = new int[cnt];


            for (int k = 0; k < liID.Count; k++)
            {
                string queryRead1 = "SELECT * FROM TblTacho WHERE ID=" + liID[k].ToString();
                OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
                OleDbDataReader srRead = commRead1.ExecuteReader();

                while (srRead.Read())
                {

                    byte[] Speed_Temp = new byte[125000];
                    byte[] Distance_Temp = new byte[125000];
                    byte[] SalesDetail_Temp = new byte[125000];
                    byte[] QuickStopTemp = new byte[125000];

                    CarNo[k] = srRead.GetString(1);             // CarNumber
                    OutTime[k] = srRead.GetDateTime(4);         // 출고
                    InTime[k] = srRead.GetDateTime(5);          // 입고
                    Money[k] = (int)srRead.GetDecimal(6);       // 미터 수입
                    SalesDist[k] = srRead.GetDouble(8);         // 영업거리
                    TotalDist[k] = srRead.GetDouble(9);         // 주행거리
                    OverSpeed[k] = srRead.GetDateTime(11);      // 과속시간
                    QuickStop[k] = srRead.GetInt32(12);
                    DriveBasic[k] = srRead.GetInt32(13);
                    DriveAfter[k] = srRead.GetInt32(14);
                    PremiumBasic[k] = srRead.GetInt32(15);
                    PremiumAfter[k] = srRead.GetInt32(16);
                    Door[k] = srRead.GetString(17);
                    SalesCnt[k] = srRead.GetInt32(18);
                    SalesTime[k] = srRead.GetDateTime(19);
                    KongChaTime[k] = srRead.GetInt32(20);
                    Key[k] = srRead.GetInt32(21);
                    GraphTime[k] = srRead.GetString(22);


                    srRead.GetBytes(23, 0, Speed_Temp, 0, 125000);

                    srRead.GetBytes(24, 0, Distance_Temp, 0, 125000);

                    for (int a = 0; a < Speed_Temp.Length; a++)
                    {
                        GraphSpeed[a, k] = Speed_Temp[a];
                        GraphDistance[a, k] = Distance_Temp[a];
                    }

                    GraphEngine[k] = srRead.GetString(25);   // 엔진
                    GraphSaleds[k] = srRead.GetString(26);   // 영업

                    srRead.GetBytes(27, 0, SalesDetail_Temp, 0, 125000);



                    for (int a = 0; a < SalesDetail_Temp.Length; a++)
                    {
                        if (SalesDetail_Temp[a] == 0xfd)
                        {
                            fdcnt[q]++;
                        }

                        SalesDetail[a, k] = SalesDetail_Temp[a];

                    }
                    fdcnt[q] *= 34;
                    q++;

                    srRead.GetBytes(28, 0, QuickStopTemp, 0, 125536);

                    for (int a = 0; a < QuickStopTemp.Length; a++)
                    {
                        if (QuickStopTemp[a] == 0xfd)
                        {
                            Qfdcnt[h]++;
                        }
                        QucikStopData[a, k] = QuickStopTemp[a];
                    }
                    Qfdcnt[h] *= 24;
                    h++;


                }


            }

            for (int a = 0; a < cnt; a++)
            {

                for (int j = 0; j < cnt; j++)
                {
                    if (a != j)
                    {
                        if (CarNo[a] != CarNo[j])
                        {
                            MessageBox.Show("같은 차량만 합칠 수 있습니다!");
                            return;
                        }
                        else if (OutTime[a] == OutTime[j])
                        {
                            MessageBox.Show("중복된 데이터는 합칠수 없습니다!");
                            return;
                        }
                    }
                }


            }
            if (MessageBox.Show(CarNo[0].ToString() + "  차량 데이터를 합치 시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                DateTime TTOutTime = new DateTime();
                DateTime TTInTime = new DateTime();
                int TTMoney = 0;
                double TTSalesDist = 0;
                double TTTotalDist = 0;
                DateTime TTOverSpeed = new DateTime();
                int OverSpeedHour = 0;
                int OverSpeedMinute = 0;
                int TTQuikStop = 0;
                int TTDriveBasic = 0;
                int TTDriveAfter = 0;
                int TTPremiumBasic = 0;
                int TTPremiumAfter = 0;
                string TTDoor = "";
                int TTSalesCnt = 0;
                TimeSpan TTSalesTime = new TimeSpan();
                int TTKongChaTime = 0;
                int TTKey = 0;
                int SalesTimeHour = 0;
                int SalesTimeMinute = 0;
                int[] index = new int[cnt];
                string TTGraphTime = "";
                byte[] TTGraphSpeed = new byte[125000];
                byte[] TTGraphDistance = new byte[125000];
                string TTGraphEngine = "";
                string TTGraphSales = "";
                byte[] TTSalesDetail = new byte[125000];
                byte[] TTQucikStopData = new byte[125000];



                for (int i = 0; i < cnt; i++)
                {
                    for (int j = 0; j < cnt; j++)
                    {
                        /* if (OutTime[i] < OutTime[j])      // 최초 출고 시간
                         {

                             TTOutTime = OutTime[i];
                         }*/
                        if (InTime[i] > InTime[j])        // 마지막  입고 시간 
                        {
                            //     TTInTime = InTime[i];
                            index[i]++;                   //각각 시간의 순서를 결정한다.
                        }
                    }
                    TTMoney += Money[i];
                    TTSalesDist += SalesDist[i];
                    TTTotalDist += TotalDist[i];
                    OverSpeedHour += OverSpeed[i].Hour;
                    OverSpeedMinute += OverSpeed[i].Minute;
                    TTQuikStop += QuickStop[i];
                    TTDriveBasic += DriveBasic[i];
                    TTDriveAfter += DriveAfter[i];
                    TTPremiumBasic += PremiumBasic[i];
                    TTPremiumAfter += PremiumAfter[i];
                    TTDoor += Door[i];
                    TTSalesCnt += SalesCnt[i];
                    SalesTimeHour += SalesTime[i].Hour;
                    SalesTimeMinute += SalesTime[i].Minute;
                    TTKongChaTime += KongChaTime[i];
                    TTKey += Key[i];



                }

                for (int i = 0; i < index.Length; i++)
                {
                    if (index[i] == 0)
                    {
                        TTOutTime = OutTime[i];
                    }
                    else if (index[i] == (index.Length - 1))
                    {
                        TTInTime = InTime[i];
                    }
                }


                if (OverSpeedMinute >= 60)
                {
                    OverSpeedMinute -= 60;
                    OverSpeedHour += 1;

                }
                int dayy = 1;

                if (OverSpeedHour > 12)
                {
                    dayy = OverSpeedHour / 12;

                    OverSpeedHour = OverSpeedHour - (dayy * 12);
                }

                TTOverSpeed = new DateTime(2012, 1, dayy, OverSpeedHour, OverSpeedMinute, 0);




                TTSalesTime = new TimeSpan(SalesTimeHour, SalesTimeMinute, 0);
                int ccnt = 0;
                int qcnt = 0;
                int zcnt = 0;


                for (int i = 0; i < cnt; i++)
                {
                    for (int j = 0; j < cnt; j++)
                    {
                        if (i == index[j])                        // 시간 순서대로 합치기
                        {
                            TTGraphTime += GraphTime[j];
                            TTGraphEngine += GraphEngine[j];
                            TTGraphSales += GraphSaleds[j];
                            for (int a = 0; a < GraphEngine[j].Length; a++)
                            {
                                TTGraphSpeed[ccnt] = GraphSpeed[a, j];
                                TTGraphDistance[ccnt] = GraphDistance[a, j];
                                ccnt++;
                            }
                            for (int u = 0; u < fdcnt[j]; u++)
                            {
                                TTSalesDetail[qcnt] = SalesDetail[u, j];
                                qcnt++;
                            }
                            for (int u = 0; u < Qfdcnt[j]; u++)
                            {
                                TTQucikStopData[zcnt] = QucikStopData[u, j];
                                zcnt++;
                            }

                        }
                    }
                }



                try
                {


                    OleDbCommand commTblTacho = new OleDbCommand();

                    // Fill DB - TblTacho
                    string queryTblTacho = "Insert into TblTacho ( 차량No, 기사No,기사이름,출고시간, 입고시간, "
                                            + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                                            + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                                            + "영업회수, 영업시간, 공차시간, 키사용,그래프시간,그래프속도,그래프거리,그래프엔진,그래프영업,상세영업,급제동데이터"
                                            + ") values(?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?)";

                    commTblTacho = new OleDbCommand(queryTblTacho, conn);

                    commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = CarNo[0];
                    commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = 0;
                    commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = "";
                    commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = TTOutTime;
                    commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = TTInTime;
                    commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = TTMoney;  // 11.06.27 추가
                    commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = 0;
                    commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = TTSalesDist;  // 총 영업거리

                    commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = TTTotalDist;
                    commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = 0;

                    commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = TTOverSpeed;
                    commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = TTQuikStop;
                    commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = TTDriveBasic;
                    commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = TTDriveAfter;
                    commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = TTPremiumBasic;
                    commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = TTPremiumAfter;
                    commTblTacho.Parameters.Add("문개폐", OleDbType.Char).Value = TTDoor;
                    commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = TTSalesCnt;


                    commTblTacho.Parameters.Add("영업시간", OleDbType.DBTime).Value = TTSalesTime;
                    commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = TTKongChaTime;
                    commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = TTKey;


                    commTblTacho.Parameters.Add("그래프시간", OleDbType.Char).Value = TTGraphTime;
                    commTblTacho.Parameters.Add("그래프속도", OleDbType.Binary).Value = TTGraphSpeed;
                    commTblTacho.Parameters.Add("그래프거리", OleDbType.Binary).Value = TTGraphDistance;
                    commTblTacho.Parameters.Add("그래프엔진", OleDbType.Char).Value = TTGraphEngine;
                    commTblTacho.Parameters.Add("그래프영업", OleDbType.Char).Value = TTGraphSales;

                    commTblTacho.Parameters.Add("상세영업", OleDbType.Binary).Value = TTSalesDetail;
                    commTblTacho.Parameters.Add("급제동데이터", OleDbType.Binary).Value = TTQucikStopData;
                    conn.ResetState();
                    commTblTacho.ExecuteNonQuery();
                    //	}
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("데이터 합치기 완료!");

                if (MessageBox.Show("합치기 예전 데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    //  List<int> liID = new List<int>();
                    cnt = 0;

                    cnt = listView1.SelectedItems.Count;

                    string Selmetermoney = "";  // 미터 수입 
                    string SalesDistance = ""; // 영업거리
                    string TotalDistance = "";
                    string tBreaek = "";		// 급제동
                    string DriveBasic1 = "";		//주행기본
                    string tDA = "";			//주행이후
                    string tAB = "";			//할증기본
                    string tAA = "";					// 할증이후

                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));


                        Selmetermoney = listView1.SelectedItems[i].SubItems[6].Text;  // 미터 수입 추출
                        SalesDistance = listView1.SelectedItems[i].SubItems[8].Text; // 영업거리
                        TotalDistance = listView1.SelectedItems[i].SubItems[9].Text;  // 주행거리
                        tBreaek = listView1.SelectedItems[i].SubItems[11].Text;  // 급제동
                        DriveBasic1 = listView1.SelectedItems[i].SubItems[12].Text;  //주행기본
                        tDA = listView1.SelectedItems[i].SubItems[13].Text;
                        tAB = listView1.SelectedItems[i].SubItems[14].Text;
                        tAA = listView1.SelectedItems[i].SubItems[15].Text;

                        Selmetermoney = Selmetermoney.Replace(",", "");
                        Selmetermoney = Selmetermoney.Replace("₩", "");
                        Selmetermoney = Selmetermoney.Replace(@"₩", "");
                        Selmetermoney = Selmetermoney.Replace("\\", "");
                        Selmetermoney = Selmetermoney.Replace(".", "");



                        SalesDistance = SalesDistance.Replace(",", "");
                        SalesDistance = SalesDistance.Replace(".", "");
                        SalesDistance = SalesDistance.Replace("Km", "");

                        TotalDistance = TotalDistance.Replace(",", "");
                        TotalDistance = TotalDistance.Replace(".", "");
                        TotalDistance = TotalDistance.Replace("Km", "");

                        total.tMoney -= (int)Int32.Parse(Selmetermoney);  // 미터 수입 
                        total.tDistS -= (double)Int32.Parse(SalesDistance) / 100;  // 영업거리
                        total.tDistD -= (double)Int32.Parse(TotalDistance) / 100;  // 주행거리
                        total.tB -= (int)Int32.Parse(tBreaek);					// 급제동
                        total.tDB -= (int)Int32.Parse(DriveBasic1);             // 주행기본
                        total.tDA -= (int)Int32.Parse(tDA);					//주행이후
                        total.tAB -= (int)Int32.Parse(tAB);					//할증기본
                        total.tAA -= (int)Int32.Parse(tAA);					//할증이후
                    }

                    if (DeleteDB(liID))
                    {
                        FillData(0, 1);
                        MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");

                        if (listView1.Items.Count == 1)
                        {
                            //	MessageBox.Show("listView1.Items[0].Remove();");
                            listView1.Items[0].Remove();
                        }
                    }


                }

            }


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0)
            {
                // Update listView1
                //       int nTmp = Convert.ToInt32(textBoxDrvInput.Text);
                //  Decimal nTmp = Convert.ToDecimal(textBox3.Text);
                listView1.SelectedItems[0].SubItems[3].Text = textBox3.Text;

                UpdateDriveName(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text), "기사이름", textBox3.Text);


            }
            else
            {
                MessageBox.Show("잘못된 값을 입력하셨습니다.", "경고");
            }


            this.textBox3.Visible = false;
            this.textBox3.Text = "";
        }
        private void UpdateDriveName(int nID, string strColName, string strValue)
        {
            //////
            string DBstring = "";

            string NameDB = "";

            if (Db_backup == true)
            {

                NameDB = TACHO2_path + MdbFileName;


                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;
                //					 Db_backup = false;


            }
            else
            {
                //	 DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

            }
            /// //

            OleDbConnection conn = new OleDbConnection(@DBstring);

            //  string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + TACHO2_path + "Information.mdb";
            string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            OleDbConnection connInfo = new OleDbConnection(Infostring);


            try
            {
                conn.Open();
                connInfo.Open();
                string queryUpdate = "UPDATE TblTacho SET " + strColName + "='" + strValue
                    + "' WHERE ID=" + nID.ToString();
                OleDbCommand commUpdate = new OleDbCommand(queryUpdate, conn);
                commUpdate.ExecuteNonQuery();

                string strDriverNo = "";


                try
                {

                    string queryReadDriver = "SELECT * FROM DriverInfo WHERE 이름='" + strValue + "'";
                    OleDbCommand commReadDriver = new OleDbCommand(queryReadDriver, connInfo);
                    OleDbDataReader srReadDriver = commReadDriver.ExecuteReader();

                    //	System.Threading.Thread.Sleep(10);

                 /*   while (srReadDriver.Read())
                    {

                        strDriverNo = srReadDriver.GetString(1);
                    }

                    strDriverNo = strDriverNo.Trim();

                    if (strDriverNo == "")
                    {
                        strDriverNo = "   ";
                    }*/


                }
                catch (Exception ex)
                {

                }
                finally
                {
                  /*  queryUpdate = "UPDATE TblTacho SET " + "기사No" + "='" + strDriverNo
                     + "' WHERE ID=" + nID.ToString(); ;
                    OleDbCommand commUpdate1 = new OleDbCommand(queryUpdate, conn);
                    commUpdate1.ExecuteNonQuery();
                    */
                }



            }
            catch (Exception ex)
            {
                /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                  using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                  {
                      sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                  }*/

                MessageBox.Show("데이터를 업데이트 하는데 오류가 발생했습니다.", "오류");
            }
            finally
            {
                conn.Close();


                FillData(1, selectedOrder);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //  daysearchcar = true;
            //  FormOpenMonth formOpenMonth = new FormOpenMonth(this);

            //   formOpenMonth.checkBox1.Checked = true;

            //   formOpenMonth.Show();


            daysearchcar = true;

            formOpenMonth = new FormOpenMonth(this);
       
            string formName = "FormOpenMonth";

            foreach (System.Windows.Forms.Form theForm in form1.MdiChildren)
            {
                if (formName.Equals(theForm.Name))
                {
                    //해당form의 인스턴스가 존재하면 해당 창을 활성시킨다.
                    theForm.BringToFront();
                    theForm.Focus();
                    return;
                }
            }

            //	FormTachoReceive formTachoReceive = new FormTachoReceive(this);
            formOpenMonth.MdiParent = form1;
            formOpenMonth.Show();
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        string StartTime_str = "";
        string EndTime_str = "";
        public void FillDays(string carnum, DateTime starttime, DateTime Endtime)
        {
            if (listView1.Items.Count > 0)
                listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;                   //   리스트 뷰 라인생성
            listView1.FullRowSelect = true;               // 라인 선택 
            string Dirname = "";

            if (Dayseach_tacho == true)
            {
                Dirname = TACHO2_path + "타코";
            }
            else if (Dayseach_tachoday == true)
            {
                Dirname = TACHO2_path + "타코 일별";
            }
            else if (Dayseach_tacho2day == true)
            {
                Dirname = TACHO2_path + "타코 교대분리";
            }
            else if (Dayseach_tachoauto == true)
            {
                Dirname = TACHO2_path + "타코 자동분리";
            }

            DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
            DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);


            yymmdd = StartTime.ToString("yyyy년MM월dd일") + "~" + EndTime.ToString("yyyy년MM월dd일");

            StartTime_str = string.Format("{00:D2}", (starttime.Year - 2000)) + string.Format("{00:D2}", starttime.Month) + string.Format("{00:D2}", starttime.Day);
            EndTime_str = string.Format("{00:D2}", (Endtime.Year - 2000)) + string.Format("{00:D2}", Endtime.Month) + string.Format("{00:D2}", Endtime.Day);

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
            int id = 1;

            int MoneyTotal = 0, RealMoney = 0; ;
            double SalesDistTotal = 0;
            double DistTotal = 0;


            for (int i = 0; i < file_str.Length; i++)
            {
                int temp = 0, start_int = 0, end_int = 0;


                string DBstring = "";
                if (file_str[i] == null)
                {
                    continue;
                }
                string file_str_temp = "";
                file_str_temp = file_str[i].Replace("AM", "");
                file_str_temp = file_str_temp.Replace("PM", "");
                //   if (form1.SungSil != 1 && form1.outtime == true)
                if (form1.SungSil != 1 && form1.outtime == true)
                {
                    temp = Int32.Parse(file_str_temp);
                    start_int = Int32.Parse(StartTime_str);
                    end_int = Int32.Parse(EndTime_str);
                    if (temp < start_int || temp > end_int)
                    {
                        continue;
                    }
                }




                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";

                string queryRead = "select * from TblTacho";

                OleDbConnection conn1 = new OleDbConnection(@DBstring);
                conn1.Open();
                OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
                OleDbDataReader srRead = commRead.ExecuteReader();

                //if ((srRead.GetString(1).Contains(compareObject) == false))
                //	continue;   // 차량번호별 집계시 타 차량번호 거르기
                bool bIsMatched = false;

                while (srRead.Read())
                {
                    /////////
                    string tooltip_str = id.ToString();


                    ListViewItem a = new ListViewItem(tooltip_str);       // ID

                    a.ToolTipText = " 영업 상세정보 \n ID 더블클릭!";

                    string strCarNo = srRead.GetString(1);  // 차량번호

                    DateTime TimeSeach = new DateTime();
                    //   DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
                    //    DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);

                    if ((srRead.GetString(1).Contains(carnum) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                        continue;   // 차량번호별 집계시 타 차량번호 거르기

                    if (carnum != strCarNo)
                    {
                        continue;

                    }

                    if (radioButton전체보기.Checked && !bIsDetail)
                    {
                        bIsMatched = false;
                        for (int g = 0; g < comboBox차량번호.Items.Count; g++)
                        {
                            if (comboBox차량번호.Items[g].ToString() == strCarNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox차량번호.Items.Add(strCarNo);


                        }
                    }

                    a.SubItems.Add(strCarNo);                                               // 차량번호

                    //a.SubItems.Add(srRead.GetString(2));                                  // 기사번호

                    string strDriverNo = srRead.GetString(2);

                    if (radioButton전체보기.Checked)
                    {
                        bIsMatched = false;
                        for (int d = 0; d < comboBox기사번호.Items.Count; d++)
                        {
                            if (comboBox기사번호.Items[d].ToString() == strDriverNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox기사번호.Items.Add(strDriverNo);
                        }
                    }
                    a.SubItems.Add(strDriverNo);                                            // 기사번호

                    string strDriverName = "";



                    if (srRead.IsDBNull(3) == false)
                    {
                        strDriverName = srRead.GetString(3);
                        a.SubItems.Add(strDriverName);
                    }
                    else
                    {
                        a.SubItems.Add(strDriverName);
                    }

                    // 기사이름
                    //	    a.SubItems.Add("");                                                      // 기사이름

                    a.SubItems.Add(srRead.GetDateTime(4).ToString());                       // 출고시간
                    a.SubItems.Add(srRead.GetDateTime(5).ToString());                       // 입고시간

                    uint uuu = (uint)srRead.GetDecimal(6);
                    MoneyTotal += (int)uuu;
                    string money = string.Format("{0:C}", uuu);
                    a.SubItems.Add(money);                                                  // 미터수입

                    uuu = (uint)srRead.GetDecimal(7);                                       // 실입금액
                    RealMoney += (int)uuu;
                    money = string.Format("{0:C}", uuu);
                    a.SubItems.Add(money);                                                  // 실입금액

                    double ddd = srRead.GetDouble(8);
                    SalesDistTotal += ddd;
                    string dist = string.Format("{0:N} Km", ddd);
                    a.SubItems.Add(dist);                                                   // 영업거리

                    ddd = srRead.GetDouble(9);
                    DistTotal += ddd;
                    dist = string.Format("{0:N} Km", ddd);
                    a.SubItems.Add(dist);                                                   // 주행거리

                    //	string fuel = string.Format("{0:N} L", srRead.GetDouble(10));
                    //	a.SubItems.Add(fuel);                                                   // 연료량

                    DateTime srTime = srRead.GetDateTime(11);
                    DateTime stTime = new DateTime(srTime.Year, srTime.Month, srTime.Day, 0, 0, 0);
                    TimeSpan stSpan = srTime - stTime;

                    a.SubItems.Add(stSpan.ToString());                                      // 과속시간

                    uuu = (uint)srRead.GetInt32(12);

                    a.SubItems.Add(uuu.ToString());                                         // 급제동
                    uuu = (uint)srRead.GetInt32(13);

                    a.SubItems.Add(uuu.ToString());                                         // 주행기본
                    uuu = (uint)srRead.GetInt32(14);

                    a.SubItems.Add(uuu.ToString());                                         // 주행이후
                    uuu = (uint)srRead.GetInt32(15);

                    a.SubItems.Add(uuu.ToString());                                         // 할증기본
                    uuu = (uint)srRead.GetInt32(16);

                    a.SubItems.Add(uuu.ToString());                                         // 할증이후
                    //a.SubItems.Add(srRead.GetInt32(17).ToString());                         // 문개폐
                    int isOpenedDBNum = srRead.GetInt32(18);

                    string fuel = string.Format("{0:N} L", srRead.GetDouble(10));
                    a.SubItems.Add(fuel);                                                   // 연료량

                    listView1.Items.Add(a);

                    id++;

                    //	nReadDBCnt++;
                    ///////////
                }
                //     conn.Close();
                conn1.Close();



            }
            ListViewItem b = new ListViewItem("합계");
            b.SubItems.Add("");                             ///   공백 다섯칸 만들기
            b.SubItems.Add("");
            b.SubItems.Add("");
            b.SubItems.Add("");
            b.SubItems.Add("");
            string mm = string.Format("{0:C}", MoneyTotal);     // 미터수입
            b.SubItems.Add(mm);
            mm = string.Format("{0:C}", RealMoney);
            b.SubItems.Add(mm);                              // 실입금액
            mm = string.Format("{0:N} Km", SalesDistTotal);
            b.SubItems.Add(mm);                                                         // 영업거리
            mm = string.Format("{0:N} Km", DistTotal);
            b.SubItems.Add(mm);                                                         // 주행거리

            b.SubItems.Add("");                                           // 과속시간
            b.SubItems.Add("");                                                // 급제동
            b.SubItems.Add("");                                              // 주행기본
            b.SubItems.Add("");                                               // 주행이후
            b.SubItems.Add("");                                              // 할증기본
            b.SubItems.Add("");                                             // 할증이후
            b.SubItems.Add("");

            b.BackColor = System.Drawing.Color.LightGray;
            listView1.Items.Add(b);


            //    yymmdd = listView1.Items[0].SubItems[4].Text + "~" + listView1.Items[listView1.Items.Count-2].SubItems[5].Text;
            FillList(this.m_list, listView1);


        }

        public void TotalSeachData(DateTime starttime, DateTime Endtime)
        {

            form1.CarListInit();
            form1.CarListInit1();
            form1.CarListInit2();
            form1.CarListInit3();

            TachoData_ORG[] tachoData = new TachoData_ORG[form1.CarList.Length];

            Carcnt_label.Text = "";

            if (listView1.Items.Count > 0)
                listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;                   //   리스트 뷰 라인생성
            listView1.FullRowSelect = true;               // 라인 선택 
            string Dirname = "";

            if (Dayseach_tacho == true)
            {
                Dirname = TACHO2_path + "타코";
            }
            else if (Dayseach_tachoday == true)
            {
                Dirname = TACHO2_path + "타코 일별";
            }
            else if (Dayseach_tacho2day == true)
            {
                Dirname = TACHO2_path + "타코 교대분리";
            }
            else if (Dayseach_tachoauto == true)
            {
                Dirname = TACHO2_path + "타코 자동분리";
            }

            DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
            DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);



            StartTime_str = string.Format("{00:D2}", (starttime.Year - 2000)) + string.Format("{00:D2}", starttime.Month) + string.Format("{00:D2}", starttime.Day);
            EndTime_str = string.Format("{00:D2}", (Endtime.Year - 2000)) + string.Format("{00:D2}", Endtime.Month) + string.Format("{00:D2}", Endtime.Day);

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
            int id = 1;

            int MoneyTotal = 0, RealMoney = 0; ;
            double SalesDistTotal = 0;
            double DistTotal = 0;


            for (int i = 0; i < file_str.Length; i++)
            {
                int temp = 0, start_int = 0, end_int = 0;


                string DBstring = "";
                if (file_str[i] == null)
                {
                    continue;
                }

                //  if (form1.SungSil != 1 && form1.outtime == true)
                string file_str_temp = "";
                file_str_temp = file_str[i].Replace("AM", "");
                file_str_temp = file_str_temp.Replace("PM", "");

                if (form1.SungSil != 1)
                {
                    temp = Int32.Parse(file_str_temp);
                    start_int = Int32.Parse(StartTime_str);
                    end_int = Int32.Parse(EndTime_str);
                    if (temp < start_int || temp > end_int)
                    {
                        continue;
                    }
                }




                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";

                string queryRead = "select * from TblTacho";

                OleDbConnection conn1 = new OleDbConnection(@DBstring);
                conn1.Open();
                OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
                OleDbDataReader srRead = commRead.ExecuteReader();

                //if ((srRead.GetString(1).Contains(compareObject) == false))
                //	continue;   // 차량번호별 집계시 타 차량번호 거르기
                bool bIsMatched = false;



                while (srRead.Read())
                {
                    /////////
                    string tooltip_str = id.ToString();


                    ListViewItem a = new ListViewItem(tooltip_str);       // ID

                    a.ToolTipText = " 영업 상세정보 \n ID 더블클릭!";

                    string strCarNo = srRead.GetString(1);  // 차량번호

                    DateTime TimeSeach = new DateTime();

                    //   DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
                    //    DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);

                    /* if ((srRead.GetString(1).Contains(carnum) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                         continue;   // 차량번호별 집계시 타 차량번호 거르기

                     if (carnum != strCarNo)
                     {
                         continue;

                     }*/


                    if ((srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                        continue;   // 날짜 거르기

                    if (radioButton전체보기.Checked && !bIsDetail)
                    {
                        bIsMatched = false;
                        for (int g = 0; g < comboBox차량번호.Items.Count; g++)
                        {
                            if (comboBox차량번호.Items[g].ToString() == strCarNo)
                            {
                                bIsMatched = true;
                            }
                        }
                        if (!bIsMatched)
                        {
                            comboBox차량번호.Items.Add(strCarNo);


                        }
                    }
                    for (int c = 0; c < form1.CarList.Length; c++)
                    {

                        if (form1.CarList[c] == strCarNo)
                        {

                            tachoData[c].CarNo = strCarNo;
                            tachoData[c].DrvNo = srRead.GetString(2);

                            string strDriverName = "";



                            if (srRead.IsDBNull(3) == false)
                            {
                                strDriverName = srRead.GetString(3);
                                a.SubItems.Add(strDriverName);
                            }
                            else
                            {
                                a.SubItems.Add(strDriverName);
                            }
                            tachoData[c].DrvNo = strDriverName;

                            tachoData[c].OutTime = StartTime;
                            tachoData[c].InTime = EndTime;


                            int moneytemp = (int)srRead.GetDecimal(6);
                            tachoData[c].MeterMoney += moneytemp;       // 미터수입
                            MoneyTotal += moneytemp;


                            moneytemp = (int)srRead.GetDecimal(7);
                            tachoData[c].RealMoney += moneytemp;       // 실 입금액 
                            RealMoney += moneytemp;

                            double disttemp = srRead.GetDouble(8);

                            tachoData[c].SalesDist += disttemp;                        // 영업거리
                            SalesDistTotal += disttemp;

                            disttemp = srRead.GetDouble(9);
                            tachoData[c].TotalDist += disttemp;                        // 주행거리
                            DistTotal += disttemp;

                            tachoData[c].fuel = 1;

                            int salescnt = (int)srRead.GetInt32(18);                // 영업횟수

                            tachoData[c].SalesCnt += salescnt;


                            id++;
                        } // if carno
                    }   // for Carlist

                    //	nReadDBCnt++;
                    ///////////
                }
                //     conn.Close();
                conn1.Close();

            }
            id = 1;
            for (int c = 0; c < tachoData.Length; c++)
            {
                if (tachoData[c].fuel == 1)
                {

                    ListViewItem a = new ListViewItem(id.ToString());

                    string start_t = listView1.Columns[4].Text;
                    string end_t = listView1.Columns[5].Text;

                    listView1.Columns[4].Text = "시작일";
                    listView1.Columns[5].Text = "마지막일";
                    listView1.Columns[10].Text = "영업횟수";
                    a.SubItems.Add(tachoData[c].CarNo);                                               // 차량번호
                    a.SubItems.Add(tachoData[c].DrvNo);                                            // 기사번호             
                    a.SubItems.Add(tachoData[c].DrvName);                                    // 기사이름


                    a.SubItems.Add(tachoData[c].OutTime.ToString("yyyy-MM-dd"));                       // 출고시간

                    a.SubItems.Add(tachoData[c].InTime.ToString("yyyy-MM-dd"));                       // 입고시간

                    // 실입금액



                    string money = string.Format("{0:C}", tachoData[c].MeterMoney);
                    a.SubItems.Add(money);
                    // 미터수입


                    money = string.Format("{0:C}", tachoData[c].RealMoney);
                    a.SubItems.Add(money);                                                  // 실입금액


                    string dist = string.Format("{0:N} Km", tachoData[c].SalesDist);
                    a.SubItems.Add(dist);                                                   // 영업거리


                    dist = string.Format("{0:N} Km", tachoData[c].TotalDist);
                    a.SubItems.Add(dist);

                    string salescnt = string.Format(tachoData[c].SalesCnt.ToString() + " 회");  // 영업횟수
                    a.SubItems.Add(salescnt);

                    a.SubItems.Add("");                                      // 과속시간


                    a.SubItems.Add("");                                      // 급제동

                    a.SubItems.Add("");                                        // 주행기본

                    a.SubItems.Add("");                                         // 주행이후

                    a.SubItems.Add("");                                         // 할증기본

                    a.SubItems.Add("");                                          // 할증이후
                    // 문개폐




                    a.SubItems.Add("");                                                  // 연료량// 주행거리

                    listView1.Items.Add(a);
                    id++;
                }

            }

            ListViewItem b = new ListViewItem("합계");
            b.SubItems.Add("");                             ///   공백 다섯칸 만들기
            b.SubItems.Add("");
            b.SubItems.Add("");
            b.SubItems.Add("");
            b.SubItems.Add("");
            string mm = string.Format("{0:C}", MoneyTotal);     // 미터수입
            b.SubItems.Add(mm);
            mm = string.Format("{0:C}", RealMoney);
            b.SubItems.Add(mm);                              // 실입금액
            mm = string.Format("{0:N} Km", SalesDistTotal);
            b.SubItems.Add(mm);                                                         // 영업거리
            mm = string.Format("{0:N} Km", DistTotal);
            b.SubItems.Add(mm);                                                         // 주행거리

            b.SubItems.Add("");                                           // 과속시간
            b.SubItems.Add("");                                                // 급제동
            b.SubItems.Add("");                                              // 주행기본
            b.SubItems.Add("");                                               // 주행이후
            b.SubItems.Add("");                                              // 할증기본
            b.SubItems.Add("");                                             // 할증이후
            b.SubItems.Add("");

            b.BackColor = System.Drawing.Color.LightGray;
            listView1.Items.Add(b);
            FillList(this.m_list, listView1);


        }

        XDate x;
        DateTime Xtime = new DateTime();
        public void ReadTacho_Cut()
        {

            TachoData_A tachodata_a = new TachoData_A();
            TachoData_B tachodata_b = new TachoData_B();

            totalA.tDistS = 0;
            totalA.tMoney = 0;
            totalA.tDisteD = 0;

            totalB.tMoney = 0;
            totalB.tDistS = 0;
            totalB.tDisteD = 0;

            tachodata_a.PremiumBasic = 0;
            tachodata_a.PremiumAfter = 0;
            tachodata_a.PremiumBasic = 0;
            tachodata_a.PremiumAfter = 0;
            tachodata_a.SalesCnt = 0;
            tachodata_a.breakstop = 0;
            tachodata_a.KeyCnt = 0;
            tachodata_a.SalesTime = 0;
            tachodata_a.SalesTimeTotalA = new TimeSpan();

            tachodata_b.PremiumBasic = 0;
            tachodata_b.PremiumAfter = 0;
            tachodata_b.PremiumBasic = 0;
            tachodata_b.PremiumAfter = 0;
            tachodata_b.SalesCnt = 0;
            tachodata_b.breakstop = 0;
            tachodata_b.KeyCnt = 0;
            tachodata_b.SalesTime = 0;
            tachodata_b.SalesTimeTotalB = new TimeSpan();


            StandardCnt = 0;
            string NameDB = "";
            string DBstring = "";
            NameDB = form1.TACHO2_path + "\\" + MdbFileName;
            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;

            OleDbConnection conn = new OleDbConnection(@DBstring);
            conn.Open();


            string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + form1.TACHO2_path + "\\Information.mdb";
            Infostring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + form1.TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            OleDbConnection connInfo = new OleDbConnection(Infostring);
            connInfo.Open();

            string queryRead = "SELECT * FROM TblTacho WHERE ID=" + nOpenedindex.ToString();
            //  string queryRead = "SELECT * FROM TblTacho";                          
            OleDbCommand commRead = new OleDbCommand(queryRead, conn);
            OleDbDataReader srRead = commRead.ExecuteReader();

            TachoData_ORG tachodata_org = new TachoData_ORG();

            tachodata_org.Graph_Speed = new byte[120000];
            tachodata_org.Graph_Dist = new byte[120000];
            tachodata_org.Sales_Detail = new byte[100000];

            while (srRead.Read())
            {
                tachodata_org.CarNo = srRead.GetString(1);
                tachodata_org.DrvNo = srRead.GetString(2);


                tachodata_org.door = srRead.GetString(17);
                tachodata_org.Graph_Time = srRead.GetString(22);  // 그래프 시간 읽기


                srRead.GetBytes(23, 0, tachodata_org.Graph_Speed, 0, 120000); // 그래프 속도 일기         
                srRead.GetBytes(24, 0, tachodata_org.Graph_Dist, 0, 120000);// 거리
                tachodata_org.Graph_Engine = srRead.GetString(25);   // 엔진
                tachodata_org.Graph_Sales = srRead.GetString(26);
                srRead.GetBytes(27, 0, tachodata_org.Sales_Detail, 0, 100000);  // 상세영업


            }
            char[] time_char = new char[tachodata_org.Graph_Time.Length];

            char[] Engine_char = new char[tachodata_org.Graph_Engine.Length];
            char[] Sales_char = new char[tachodata_org.Sales_Detail.Length];
            char[] Door_char = new char[tachodata_org.door.Length];

            int timecnt = 0;

            for (int i = 0; i < tachodata_org.Graph_Time.Length; i++)    // time db : string  -> char 
            {
                time_char[i] = tachodata_org.Graph_Time[i];

                if (tachodata_org.Graph_Time[i] == '#')
                {
                    timecnt++;
                }
            }

            for (int i = 0; i < tachodata_org.door.Length; i++)         // door
            {
                Door_char[i] = tachodata_org.door[i];
            }

            for (int i = 0; i < tachodata_org.Graph_Engine.Length; i++)    //Engine db : string  -> char 
            {
                Engine_char[i] = tachodata_org.Graph_Engine[i];

            }


            for (int i = 0; i < tachodata_org.Graph_Sales.Length; i++)    //Sales db : string  -> char 
            {
                Sales_char[i] = tachodata_org.Graph_Sales[i];

            }

            int cnt = 0;
            string[] time = new string[timecnt];

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
            //	long[] speed_long = new long[cnt];
            double[] distance_double = new double[cnt];
            DateTime[] datetime = new DateTime[cnt];
            // XDate[] xdatetime = new XDate[cnt];
            x = new XDate(xval);
            for (int i = 0; i < time.Length; i++)
            {
                time_long[i] = Int64.Parse(time[i]);		// string  -> long 변환 
                datetime[i] = DateTime.FromBinary(time_long[i]); // long -> DateTime 변환

                if (x == datetime[i])
                {
                    StandardCnt = i;        // 기준 시간 -> 카운트 수 알아오기
                    Xtime = datetime[i];
                }

                //xdatetime[i] = datetime[i];


            }
            ////////////////////////////////////
            int fdcnt = 0;
            for (int i = 0; i < tachodata_org.Sales_Detail.Length; i++)
            {
                if (tachodata_org.Sales_Detail[i] == 0xfd)
                    fdcnt++;
            }

            byte[] Sales_Data = new byte[fdcnt * 34];

            for (int i = 0; i < Sales_Data.Length; i++)
            {
                Sales_Data[i] = tachodata_org.Sales_Detail[i];
            }

            int sales_cnt = 0;
            int sales_chkA_cnt = 0;//    기준시간 과 비교 하여 카운트를 센다
            int sales_chkB_cnt = 0;
            bool Year_chk = false;
            bool year_ = false;
            int year = 0;

            for (int j = 0; j < fdcnt; j++)     // 영업상세데이터 시간 비교 하기 
            {
                int Year_int = 0;
                int Month_int = 0;
                int Day_int = 0;

                string Year_str = "";
                string Month_str = "";
                string Day_str = "";


                int in_hour = 0;
                int out_hour = 0;
                int Minute_Out = 0;
                int Minute_In = 0;
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
                int dbf = 0;
                int pbf = 0;
                int breakcnt = 0;

                DateTime salestime_Out = new DateTime();
                DateTime salestime_In = new DateTime();



                for (int i = 0; i < 34; i++)
                {

                    switch (i)
                    {


                        case 0:
                            Month_int = Sales_Data[i + j + sales_cnt];
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
                            break;


                        case 2:
                            out_hour = Sales_Data[i + j + sales_cnt];
                            break;

                        case 3:
                            out_str = string.Format("{0:D2}:{1:D2}", in_hour, Sales_Data[i + j + sales_cnt]); //승차   
                            Minute_In = Sales_Data[i + j + sales_cnt];

                            if (Month_int == 0) continue;

                            if (year_ == false)
                            {
                                salestime_In = new DateTime(datetime[0].Year, Month_int, Day_int, in_hour, Minute_In, 0);
                            }
                            else
                            {
                                salestime_In = new DateTime(year, Month_int, Day_int, in_hour, Minute_In, 0);
                            }
                            break;

                        case 4:
                            in_hour = Sales_Data[i + j + sales_cnt];
                            break;

                        case 5:
                            in_str = string.Format("{0:D2}:{1:D2}", out_hour, Sales_Data[i + j + sales_cnt]);  //하차
                            Minute_Out = Sales_Data[i + j + sales_cnt];

                            if (Month_int == 0) continue;

                            if (in_hour > out_hour)
                            {
                                //      Day_int++;
                            }

                            if (year_ == false)
                            {
                                salestime_Out = new DateTime(datetime[0].Year, Month_int, Day_int, out_hour, Minute_Out, 0);
                            }
                            else
                            {
                                salestime_Out = new DateTime(year, Month_int, Day_int, out_hour, Minute_Out, 0);
                            }
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
                            break;

                        case 18:
                            key = Sales_Data[i + j + sales_cnt];        // key
                            if (key > 0)
                            {
                                KeyChk = true;
                            }

                            break;

                        case 19:                                            // 급제동 유뮤
                            break_stop = Sales_Data[i + j + sales_cnt];
                            break;

                        case 22:
                            int db = Sales_Data[i + j + sales_cnt];     //주행기본

                            if (db == 1)
                            {
                                DriveBasicChk = true;
                            }
                            break;

                        case 23:
                            dbf = Sales_Data[i + j + sales_cnt];      //주행이후

                            if (dbf > 0)
                            {
                                DriveAfterChk = true;
                            }
                            break;

                        case 24:
                            int pb = Sales_Data[i + j + sales_cnt];        // 할증기본

                            if (pb == 1)
                            {
                                PremiumBasicChk = true;
                            }
                            break;

                        case 25:
                            pbf = Sales_Data[i + j + sales_cnt];      //할증이후

                            if (pbf > 0)
                            {
                                PremiumAfterChk = true;
                            }
                            break;

                        case 26:
                            int sc = Sales_Data[i + j + sales_cnt];        //영업회수

                            if (sc == 1)
                            {
                                SalesChk = true;
                            }
                            break;

                        case 30:
                            breakcnt = Sales_Data[i + j + sales_cnt];      //급제동      

                            if (break_stop > 0)
                            {
                                breakstopChk = true;
                            }
                            break;

                    }

                }
                if (salestime_Out <= x)  // 기준시간과 비교하자
                {
                    sales_chkA_cnt++;
                    if (key != 0 && break_stop != 1)
                    {

                        totalA.tMoney += money;
                        totalA.tDistS += distance;

                        if (DriveBasicChk == true)
                        {
                            tachodata_a.DriveBasic++;
                            DriveBasicChk = false;
                        }
                        if (DriveAfterChk == true)
                        {
                            tachodata_a.DriveAfter += dbf;
                            DriveAfterChk = false;
                            dbf = 0;
                        }
                        if (PremiumBasicChk == true)
                        {
                            tachodata_a.PremiumBasic++;
                            PremiumBasicChk = false;
                        }
                        if (PremiumAfterChk == true)
                        {
                            tachodata_a.PremiumAfter += pbf;
                            PremiumAfterChk = false;
                            pbf = 0;
                        }
                        if (SalesChk == true)
                        {
                            tachodata_a.SalesCnt++;
                            SalesChk = false;
                        }
                        if (breakstopChk == true)
                        {
                            tachodata_a.breakstop += breakcnt;
                            breakstopChk = false;
                            breakcnt = 0;
                        }
                        if (KeyChk == true)
                        {
                            tachodata_a.KeyCnt += key;
                            KeyChk = false;
                            key = 0;
                        }

                        tachodata_a.SalesTimeTotalA += salestime_Out - salestime_In;
                    }
                }
                else
                {
                    sales_chkB_cnt++;
                    if (key != 0 && break_stop != 1)
                    {

                        totalB.tMoney += money;
                        totalB.tDistS += distance;

                        if (DriveBasicChk == true)
                        {
                            tachodata_b.DriveBasic++;
                            DriveBasicChk = false;
                        }
                        if (DriveAfterChk == true)
                        {
                            tachodata_b.DriveAfter += dbf;
                            DriveAfterChk = false;
                            dbf = 0;
                        }
                        if (PremiumBasicChk == true)
                        {
                            tachodata_b.PremiumBasic++;
                            PremiumBasicChk = false;
                        }
                        if (PremiumAfterChk == true)
                        {
                            tachodata_b.PremiumAfter += pbf;
                            PremiumAfterChk = false;
                            pbf = 0;
                        }
                        if (SalesChk == true)
                        {
                            tachodata_b.SalesCnt++;
                            SalesChk = false;
                        }
                        if (breakstopChk == true)
                        {
                            tachodata_b.breakstop += breakcnt;
                            breakstopChk = false;
                            breakcnt = 0;
                        }
                        if (KeyChk == true)
                        {
                            tachodata_b.KeyCnt += key;
                            KeyChk = false;
                            key = 0;
                        }
                        tachodata_b.SalesTimeTotalB += salestime_Out - salestime_In;
                    }
                }

                sales_cnt += 33;
            }

            tachodata_a.Sales_Detail = new byte[sales_chkA_cnt * 34];
            tachodata_b.Sales_Detail = new byte[sales_chkB_cnt * 34];

            sales_cnt = 0;
            int jcnt = 0;
            for (int j = 0; j < fdcnt; j++)
            {
                if (j < sales_chkA_cnt)
                {
                    for (int i = 0; i < 34; i++)
                    {
                        tachodata_a.Sales_Detail[i + j + sales_cnt] = Sales_Data[i + j + sales_cnt];

                    }
                }
                else
                {

                    for (int i = 0; i < 34; i++)
                    {
                        tachodata_b.Sales_Detail[jcnt] = Sales_Data[i + j + sales_cnt];
                        jcnt++;
                    }
                }
                sales_cnt += 33;
            }



            ///////////////////////////////////////                  

            tachodata_a.Graph_Speed = new byte[time.Length];
            tachodata_a.Graph_Dist = new byte[time.Length];
            tachodata_b.Graph_Speed = new byte[time.Length];
            tachodata_b.Graph_Dist = new byte[time.Length];

            for (int i = 0; i < time.Length; i++)                       // 자른 데이터 넣기
            {
                if (i <= StandardCnt)
                {
                    tachodata_a.door += Door_char[i]; // door
                    tachodata_a.Graph_Time += time_long[i].ToString() + "#";     // Time
                    tachodata_a.Graph_Speed[i] = tachodata_org.Graph_Speed[i]; // speed
                    tachodata_a.Graph_Dist[i] = tachodata_org.Graph_Dist[i];    // dist

                    totalA.tDisteD += (double)(tachodata_org.Graph_Dist[i]) / 10.0;
                    tachodata_a.Graph_Engine += Engine_char[i];
                    tachodata_a.Graph_Sales += Sales_char[i];

                }
                else
                {
                    tachodata_b.door += Door_char[i]; // door
                    tachodata_b.Graph_Time += time_long[i].ToString() + "#";     // Time
                    tachodata_b.Graph_Speed[i - StandardCnt - 1] = tachodata_org.Graph_Speed[i]; // speed
                    tachodata_b.Graph_Dist[i - StandardCnt - 1] = tachodata_org.Graph_Dist[i];    // dist

                    totalB.tDisteD += (double)(tachodata_org.Graph_Dist[i]) / 10.0;
                    tachodata_b.Graph_Engine += Engine_char[i];
                    tachodata_b.Graph_Sales += Sales_char[i];
                }
            }
            conn.Close();
            ///////////////////////////////////////     


            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Mdb_CutNameA;
            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            conn1.Open();
            //////////////////////////////// A시간 구하기 //////////////////////////////////////////
            timecnt = 0;
            time_char = new char[tachodata_a.Graph_Time.Length];
            for (int i = 0; i < tachodata_a.Graph_Time.Length; i++)    // time db : string  -> char 
            {
                time_char[i] = tachodata_a.Graph_Time[i];

                if (tachodata_a.Graph_Time[i] == '#')
                {
                    timecnt++;
                }
            }
            cnt = 0;
            time = new string[timecnt];

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

            time_long = new long[cnt];
            datetime = new DateTime[cnt];


            for (int i = 0; i < time.Length; i++)
            {
                time_long[i] = Int64.Parse(time[i]);		// string  -> long 변환 
                datetime[i] = DateTime.FromBinary(time_long[i]); // long -> DateTime 변환

            }
            /////////////////////////////////////////////////////////////////////////////////////
            try
            {
                OleDbCommand commTblTacho = new OleDbCommand();

                // Fill DB - TblTacho
                string queryTblTacho = "Insert into TblTacho ( 차량No, 기사No,기사이름,출고시간, 입고시간, "
                      + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                      + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                      + "영업회수, 영업시간, 공차시간, 키사용,그래프시간,그래프속도,그래프거리,그래프엔진,그래프영업,상세영업,급제동데이터"
                      + ") values(?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?)";

                commTblTacho = new OleDbCommand(queryTblTacho, conn1);



                commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = tachodata_org.CarNo;
                commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = tachodata_org.DrvNo;
                commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = "";
                commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = datetime[0];
                commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = datetime[datetime.Length - 1];

                commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = totalA.tMoney;  // 11.06.27 추가
                commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = 0;


                commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = totalA.tDistS;
                commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = totalA.tDisteD;


                commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = 0;

                commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = datetime[0];
                commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = 0;
                commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = tachodata_a.DriveBasic;
                commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = tachodata_a.DriveAfter;
                commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = tachodata_a.PremiumBasic;
                commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = tachodata_a.PremiumAfter;
                commTblTacho.Parameters.Add("문개폐", OleDbType.Char).Value = tachodata_a.door;
                commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = 0;

                commTblTacho.Parameters.Add("영업시간", OleDbType.DBTime).Value = tachodata_a.SalesTimeTotalA;
                commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = 0;
                commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = 0;

                commTblTacho.Parameters.Add("그래프시간", OleDbType.Char).Value = tachodata_a.Graph_Time;
                commTblTacho.Parameters.Add("그래프속도", OleDbType.Binary).Value = tachodata_a.Graph_Speed;
                commTblTacho.Parameters.Add("그래프거리", OleDbType.Binary).Value = tachodata_a.Graph_Dist;

                commTblTacho.Parameters.Add("그래프엔진", OleDbType.Char).Value = tachodata_a.Graph_Engine;
                commTblTacho.Parameters.Add("그래프영업", OleDbType.Char).Value = tachodata_a.Graph_Sales;

                commTblTacho.Parameters.Add("상세영업", OleDbType.Binary).Value = tachodata_a.Sales_Detail;
                commTblTacho.Parameters.Add("급제동데이터", OleDbType.Binary).Value = tachodata_a.Sales_Detail;
                commTblTacho.ExecuteNonQuery();


                //     conn1.Close();


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //////////////////////////////// B시간 구하기 //////////////////////////////////////////
            timecnt = 0;
            time_char = new char[tachodata_b.Graph_Time.Length];
            for (int i = 0; i < tachodata_b.Graph_Time.Length; i++)    // time db : string  -> char 
            {
                time_char[i] = tachodata_b.Graph_Time[i];

                if (tachodata_b.Graph_Time[i] == '#')
                {
                    timecnt++;
                }
            }
            cnt = 0;
            time = new string[timecnt];

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

            time_long = new long[cnt];
            datetime = new DateTime[cnt];


            for (int i = 0; i < time.Length; i++)
            {
                time_long[i] = Int64.Parse(time[i]);		// string  -> long 변환 
                datetime[i] = DateTime.FromBinary(time_long[i]); // long -> DateTime 변환

            }
            ///////////////////////////////////////////////////////////////////////////////////// b Tacho


            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Mdb_CutNameB;
            OleDbConnection conn2 = new OleDbConnection(@DBstring);
            conn2.Open();
            try
            {
                OleDbCommand commTblTacho = new OleDbCommand();

                // Fill DB - TblTacho
                string queryTblTacho = "Insert into TblTacho ( 차량No, 기사No,기사이름,출고시간, 입고시간, "
                      + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                      + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                      + "영업회수, 영업시간, 공차시간, 키사용,그래프시간,그래프속도,그래프거리,그래프엔진,그래프영업,상세영업,급제동데이터"
                      + ") values(?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?)";

                commTblTacho = new OleDbCommand(queryTblTacho, conn2);


                commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = tachodata_org.CarNo;
                commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = tachodata_org.DrvNo;
                commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = "";
                commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = datetime[0];
                commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = datetime[datetime.Length - 1];

                commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = totalB.tMoney;  // 11.06.27 추가
                commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = 0;


                commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = totalB.tDistS;
                commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = totalB.tDisteD;


                commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = 0;

                commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = datetime[0];
                commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = 0;
                commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = tachodata_b.DriveBasic;
                commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = tachodata_b.DriveAfter;
                commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = tachodata_b.PremiumBasic;
                commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = tachodata_b.PremiumAfter;
                commTblTacho.Parameters.Add("문개폐", OleDbType.Char).Value = tachodata_b.door;
                commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = 0;

                commTblTacho.Parameters.Add("영업시간", OleDbType.DBTime).Value = tachodata_b.SalesTimeTotalB;
                commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = 0;
                commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = 0;

                commTblTacho.Parameters.Add("그래프시간", OleDbType.Char).Value = tachodata_b.Graph_Time;
                commTblTacho.Parameters.Add("그래프속도", OleDbType.Binary).Value = tachodata_b.Graph_Speed;
                commTblTacho.Parameters.Add("그래프거리", OleDbType.Binary).Value = tachodata_b.Graph_Dist;

                commTblTacho.Parameters.Add("그래프엔진", OleDbType.Char).Value = tachodata_b.Graph_Engine;
                commTblTacho.Parameters.Add("그래프영업", OleDbType.Char).Value = tachodata_b.Graph_Sales;

                commTblTacho.Parameters.Add("상세영업", OleDbType.Binary).Value = tachodata_b.Sales_Detail;
                commTblTacho.Parameters.Add("급제동데이터", OleDbType.Binary).Value = tachodata_b.Sales_Detail;
                commTblTacho.ExecuteNonQuery();


                conn1.Close();
                conn2.Close();


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("타코 자르기 완료");

            /////////////////////////////////////////////////////////////////////// 원본 지우기 




            if (MessageBox.Show("원본 데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                List<int> liID = new List<int>();
                int cnt1 = 0;

                cnt1 = listView1.SelectedItems.Count;

                string Selmetermoney = "";  // 미터 수입 
                string SalesDistance = ""; // 영업거리
                string TotalDistance = "";
                string tBreaek = "";		// 급제동
                string DriveBasic = "";		//주행기본
                string tDA = "";			//주행이후
                string tAB = "";			//할증기본
                string tAA = "";					// 할증이후

                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));


                    Selmetermoney = listView1.SelectedItems[i].SubItems[6].Text;  // 미터 수입 추출
                    SalesDistance = listView1.SelectedItems[i].SubItems[8].Text; // 영업거리
                    TotalDistance = listView1.SelectedItems[i].SubItems[9].Text;  // 주행거리
                    tBreaek = listView1.SelectedItems[i].SubItems[11].Text;  // 급제동
                    DriveBasic = listView1.SelectedItems[i].SubItems[12].Text;  //주행기본
                    tDA = listView1.SelectedItems[i].SubItems[13].Text;
                    tAB = listView1.SelectedItems[i].SubItems[14].Text;
                    tAA = listView1.SelectedItems[i].SubItems[15].Text;

                    Selmetermoney = Selmetermoney.Replace(",", "");
                    Selmetermoney = Selmetermoney.Replace("₩", "");
                    Selmetermoney = Selmetermoney.Replace(@"₩", "");
                    Selmetermoney = Selmetermoney.Replace("\\", "");
                    Selmetermoney = Selmetermoney.Replace(".", "");


                    SalesDistance = SalesDistance.Replace(",", "");
                    SalesDistance = SalesDistance.Replace(".", "");
                    SalesDistance = SalesDistance.Replace("Km", "");

                    TotalDistance = TotalDistance.Replace(",", "");
                    TotalDistance = TotalDistance.Replace(".", "");
                    TotalDistance = TotalDistance.Replace("Km", "");


                    total.tMoney -= Int32.Parse(Selmetermoney);  // 미터 수입 
                    total.tDistS -= (double)Int32.Parse(SalesDistance) / 100;  // 영업거리
                    total.tDistD -= (double)Int32.Parse(TotalDistance) / 100;  // 주행거리
                    total.tB -= Int32.Parse(tBreaek);					// 급제동
                    total.tDB -= Int32.Parse(DriveBasic);             // 주행기본
                    total.tDA -= Int32.Parse(tDA);					//주행이후
                    total.tAB -= Int32.Parse(tAB);					//할증기본
                    total.tAA -= Int32.Parse(tAA);					//할증이후
                }


                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    //	liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));
                    //	listView1.SelectedItems[i].Remove();

                }


                //  liID.Sort();
                //	Thread DellThread = new Thread(DellWork);
                //	DellThread.Start();


                if (DeleteDB(liID))
                {
                    FillData(1, 1);
                    MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");

                    if (listView1.Items.Count == 1)
                    {
                        //	MessageBox.Show("listView1.Items[0].Remove();");
                        listView1.Items[0].Remove();
                    }
                }
                //FillData(0, 1);
            }
            /////////////////////////////////////////////////////////////////////// 원본 지우기 

        }
        private int BcdToDecimalByLsb(byte[] arr, int cnt)
        {
            int rtValue = 0, mulValue = 0;

            for (int i = 0; i < cnt; i++)
            {
                if (i == 0) mulValue = 1;
                else if (i == 1) mulValue = 100;
                else if (i == 2) mulValue = 10000;
                else if (i == 3) mulValue = 1000000;
                else mulValue = 0;

                rtValue += (((arr[i] >> 4) * 10) + (arr[i] & 0x0F)) * mulValue;
            }

            return rtValue;
        }

        private int BcdToDecimal(byte bTemp)
        {
            return (((bTemp >> 4) * 10) + (bTemp & 0x0F));
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("타코 데이터 한개만 이동 가능합니다. 한개만 선택하여 주세요");
                return;
            }

            if (MessageBox.Show("선택한 데이터를 이동 하시겠습니까?", "이동", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                FormMdbList formMdbList = new FormMdbList(this);

                TachoMove = true;

                if (TachoMove == true)
                {
                    formMdbList.checkedListBox1.Enabled = false;
                }

                formMdbList.Show();
            }
        }
        public void TachoMovefunc()
        {


            TachoData_ORG tachodata_org = new TachoData_ORG();

            tachodata_org.CarNo = "";
            tachodata_org.DrvNo = "";
            tachodata_org.DrvName = "";
            tachodata_org.OutTime = new DateTime(2013, 1, 1, 1, 1, 1);
            tachodata_org.InTime = new DateTime(2013, 1, 1, 1, 1, 1);
            tachodata_org.MeterMoney = 0;
            tachodata_org.RealMoney = 0;
            tachodata_org.SalesDist = 0;
            tachodata_org.TotalDist = 0;
            tachodata_org.fuel = 0;
            tachodata_org.OverTime = new DateTime(1, 1, 1, 1, 1, 1);
            tachodata_org.QuickBreak = 0;
            tachodata_org.DriveBasic = 0;
            tachodata_org.DriveAfter = 0;
            tachodata_org.PremiumBasic = 0;
            tachodata_org.PremiumAfter = 0;
            tachodata_org.door = "";
            tachodata_org.SalesCnt = 0;
            tachodata_org.SalesTime = new TimeSpan(1, 1, 1);
            tachodata_org.KeyCnt = 0;
            tachodata_org.Graph_Time = "";
            tachodata_org.Graph_Speed = new byte[120000];
            tachodata_org.Graph_Dist = new byte[120000];
            tachodata_org.Graph_Engine = "";

            tachodata_org.Graph_Sales = "";
            tachodata_org.Sales_Detail = new byte[50000];
            tachodata_org.QuickStopData = new byte[50000];

            string NameDB = "";
            string DBstring = "";
            NameDB = form1.TACHO2_path + "\\" + MdbFileName;
            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + NameDB;



            OleDbConnection conn = new OleDbConnection(@DBstring);
            conn.Open();


            //  string Infostring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + form1.TACHO2_path + "\\Information.mdb";
            //  Infostring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + form1.TACHO2_path + "\\Information.mdb;Jet OLEDB:Database Password=1111";
            //  OleDbConnection connInfo = new OleDbConnection(Infostring);
            //  connInfo.Open();

            string queryRead = "SELECT * FROM TblTacho WHERE ID=" + nOpenedindex.ToString();
            //  string queryRead = "SELECT * FROM TblTacho";                          
            OleDbCommand commRead = new OleDbCommand(queryRead, conn);
            OleDbDataReader srRead = commRead.ExecuteReader();


            while (srRead.Read())
            {
                tachodata_org.CarNo = srRead.GetString(1);
                tachodata_org.DrvNo = srRead.GetString(2);
                tachodata_org.DrvName = srRead.GetString(3);

                tachodata_org.OutTime = srRead.GetDateTime(4);
                tachodata_org.InTime = srRead.GetDateTime(5);
                tachodata_org.MeterMoney = (int)srRead.GetDecimal(6);
                tachodata_org.RealMoney = (int)srRead.GetDecimal(7);
                tachodata_org.SalesDist = srRead.GetDouble(8);
                tachodata_org.TotalDist = srRead.GetDouble(9);
                tachodata_org.fuel = srRead.GetDouble(10);
                tachodata_org.OverTime = srRead.GetDateTime(11);
                tachodata_org.QuickBreak = srRead.GetInt32(12);
                tachodata_org.DriveBasic = srRead.GetInt32(13);
                tachodata_org.DriveAfter = srRead.GetInt32(14);
                tachodata_org.PremiumBasic = srRead.GetInt32(15);
                tachodata_org.PremiumAfter = srRead.GetInt32(16);
                tachodata_org.door = srRead.GetString(17);
                tachodata_org.SalesCnt = srRead.GetInt32(18);
                DateTime Sales_Time_t = srRead.GetDateTime(19);
                tachodata_org.SalesTime = new TimeSpan(Sales_Time_t.Hour, Sales_Time_t.Minute, Sales_Time_t.Second);
                // 공차시간
                tachodata_org.KeyCnt = srRead.GetInt32(21);
                tachodata_org.Graph_Time = srRead.GetString(22);  // 그래프 시간 읽기
                srRead.GetBytes(23, 0, tachodata_org.Graph_Speed, 0, 120000); // 그래프 속도 일기         
                srRead.GetBytes(24, 0, tachodata_org.Graph_Dist, 0, 120000);// 거리
                tachodata_org.Graph_Engine = srRead.GetString(25);   // 엔진
                tachodata_org.Graph_Sales = srRead.GetString(26);
                srRead.GetBytes(27, 0, tachodata_org.Sales_Detail, 0, 50000);  // 상세영업
                srRead.GetBytes(27, 0, tachodata_org.QuickStopData, 0, 50000);  // 급제동
            }
            conn.Close();
            /////////////////////////////////////////////////////////////////////////////////////


            DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Mdb_CutNameA;
            OleDbConnection conn1 = new OleDbConnection(@DBstring);
            conn1.Open();

            if (Dayseach_tacho == true)
            {
                form1.CarSum_DBName = "타코";
            }
            else if (Dayseach_tachoday == true)
            {
                form1.CarSum_DBName = "타코 일별";
            }
            else if (Dayseach_tacho2day == true)
            {
                form1.CarSum_DBName = "타코 교대분리";
            }
            else if (Dayseach_tachoauto == true)
            {
                form1.CarSum_DBName = "타코 자동분리";
            }


            form1.CarSum_Path = form1.TACHO2_path;
            form1.CarSum_DBName += "\\" + MdbMove_file;
            form1.Car_Num = tachodata_org.CarNo;




            ///////////////////////////////////////     

            try
            {
                OleDbCommand commTblTacho = new OleDbCommand();

                // Fill DB - TblTacho
                string queryTblTacho = "Insert into TblTacho ( 차량No, 기사No,기사이름,출고시간, 입고시간, "
                      + "미터수입, 실입금액, 영업거리, 주행거리, 연료량, 과속시간, "
                      + "급제동, 주행기본, 주행이후, 할증기본, 할증이후, 문개폐, "
                      + "영업회수, 영업시간, 공차시간, 키사용,그래프시간,그래프속도,그래프거리,그래프엔진,그래프영업,상세영업,급제동데이터"
                      + ") values(?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?,?, ?,?,?,?)";

                commTblTacho = new OleDbCommand(queryTblTacho, conn1);


                commTblTacho.Parameters.Add("차량No", OleDbType.Char).Value = tachodata_org.CarNo;
                commTblTacho.Parameters.Add("기사No", OleDbType.Char).Value = tachodata_org.DrvNo;
                commTblTacho.Parameters.Add("기사이름", OleDbType.Char).Value = tachodata_org.DrvName;
                commTblTacho.Parameters.Add("출고시간", OleDbType.Date).Value = tachodata_org.OutTime;
                commTblTacho.Parameters.Add("입고시간", OleDbType.Date).Value = tachodata_org.InTime;

                commTblTacho.Parameters.Add("미터수입", OleDbType.Currency).Value = tachodata_org.MeterMoney;  // 11.06.27 추가
                commTblTacho.Parameters.Add("실입금액", OleDbType.Currency).Value = tachodata_org.RealMoney;


                commTblTacho.Parameters.Add("영업거리", OleDbType.Double).Value = tachodata_org.SalesDist;
                commTblTacho.Parameters.Add("주행거리", OleDbType.Double).Value = tachodata_org.TotalDist;


                commTblTacho.Parameters.Add("연료량", OleDbType.Double).Value = tachodata_org.fuel;

                commTblTacho.Parameters.Add("과속시간", OleDbType.Date).Value = tachodata_org.OutTime;
                commTblTacho.Parameters.Add("급제동", OleDbType.Decimal).Value = tachodata_org.QuickBreak;
                commTblTacho.Parameters.Add("주행기본", OleDbType.Decimal).Value = tachodata_org.DriveBasic;
                commTblTacho.Parameters.Add("주행이후", OleDbType.Decimal).Value = tachodata_org.DriveAfter;
                commTblTacho.Parameters.Add("할증기본", OleDbType.Decimal).Value = tachodata_org.PremiumBasic;
                commTblTacho.Parameters.Add("할증이후", OleDbType.Decimal).Value = tachodata_org.PremiumAfter;
                commTblTacho.Parameters.Add("문개폐", OleDbType.Char).Value = tachodata_org.door;
                commTblTacho.Parameters.Add("영업회수", OleDbType.Decimal).Value = tachodata_org.SalesCnt;

                commTblTacho.Parameters.Add("영업시간", OleDbType.DBTime).Value = tachodata_org.SalesTime;
                commTblTacho.Parameters.Add("공차시간", OleDbType.Decimal).Value = 0;
                commTblTacho.Parameters.Add("키사용", OleDbType.Decimal).Value = tachodata_org.KeyCnt;

                commTblTacho.Parameters.Add("그래프시간", OleDbType.Char).Value = tachodata_org.Graph_Time;
                commTblTacho.Parameters.Add("그래프속도", OleDbType.Binary).Value = tachodata_org.Graph_Speed;
                commTblTacho.Parameters.Add("그래프거리", OleDbType.Binary).Value = tachodata_org.Graph_Dist;

                commTblTacho.Parameters.Add("그래프엔진", OleDbType.Char).Value = tachodata_org.Graph_Engine;
                commTblTacho.Parameters.Add("그래프영업", OleDbType.Char).Value = tachodata_org.Graph_Sales;

                commTblTacho.Parameters.Add("상세영업", OleDbType.Binary).Value = tachodata_org.Sales_Detail;
                commTblTacho.Parameters.Add("급제동데이터", OleDbType.Binary).Value = tachodata_org.QuickStopData;
                commTblTacho.ExecuteNonQuery();


                conn1.Close();


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }



            // if (MessageBox.Show("원본 데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)

            List<int> liID = new List<int>();
            int cnt1 = 0;

            cnt1 = listView1.SelectedItems.Count;

            string Selmetermoney = "";  // 미터 수입 
            string SalesDistance = ""; // 영업거리
            string TotalDistance = "";
            string tBreaek = "";		// 급제동
            string DriveBasic = "";		//주행기본
            string tDA = "";			//주행이후
            string tAB = "";			//할증기본
            string tAA = "";					// 할증이후

            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));


                Selmetermoney = listView1.SelectedItems[i].SubItems[6].Text;  // 미터 수입 추출
                SalesDistance = listView1.SelectedItems[i].SubItems[8].Text; // 영업거리
                TotalDistance = listView1.SelectedItems[i].SubItems[9].Text;  // 주행거리
                tBreaek = listView1.SelectedItems[i].SubItems[11].Text;  // 급제동
                DriveBasic = listView1.SelectedItems[i].SubItems[12].Text;  //주행기본
                tDA = listView1.SelectedItems[i].SubItems[13].Text;
                tAB = listView1.SelectedItems[i].SubItems[14].Text;
                tAA = listView1.SelectedItems[i].SubItems[15].Text;

                Selmetermoney = Selmetermoney.Replace(",", "");
                Selmetermoney = Selmetermoney.Replace("₩", "");
                Selmetermoney = Selmetermoney.Replace(@"₩", "");
                Selmetermoney = Selmetermoney.Replace("\\", "");
                Selmetermoney = Selmetermoney.Replace(".", "");


                SalesDistance = SalesDistance.Replace(",", "");
                SalesDistance = SalesDistance.Replace(".", "");
                SalesDistance = SalesDistance.Replace("Km", "");

                TotalDistance = TotalDistance.Replace(",", "");
                TotalDistance = TotalDistance.Replace(".", "");
                TotalDistance = TotalDistance.Replace("Km", "");


                total.tMoney -= Int32.Parse(Selmetermoney);  // 미터 수입 
                total.tDistS -= (double)Int32.Parse(SalesDistance) / 100;  // 영업거리
                total.tDistD -= (double)Int32.Parse(TotalDistance) / 100;  // 주행거리
                total.tB -= Int32.Parse(tBreaek);					// 급제동
                total.tDB -= Int32.Parse(DriveBasic);             // 주행기본
                total.tDA -= Int32.Parse(tDA);					//주행이후
                total.tAB -= Int32.Parse(tAB);					//할증기본
                total.tAA -= Int32.Parse(tAA);					//할증이후
            }


            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                //	liID.Add(Convert.ToInt32(listView1.SelectedItems[i].SubItems[0].Text));
                //	listView1.SelectedItems[i].Remove();

            }


            //  liID.Sort();
            //	Thread DellThread = new Thread(DellWork);
            //	DellThread.Start();


            if (DeleteDB(liID))
            {
                FillData(1, 1);
                // MessageBox.Show("데이터를 성공적으로 삭제 하였습니다.", "성공");

                if (listView1.Items.Count == 1)
                {
                    //	MessageBox.Show("listView1.Items[0].Remove();");
                    listView1.Items[0].Remove();
                }
            }
            //FillData(0, 1);

            // form1.Car_Sum();
            MessageBox.Show("타코 이동 완료");
            /////////////////////////////////////////////////////////////////////// 원본 지우기 
        }

        private void button11_Click(object sender, EventArgs e)
        {


            formMonthTacho = new FormMonthTacho(this);
            //  formMonthTacho.MdiParent = this.ParentForm;
            // formMonthTacho.BringToFront();
            //   formMonthTacho.Show();




            string formName = "FormMonthTacho";

            foreach (System.Windows.Forms.Form theForm in form1.MdiChildren)
            {
                if (formName.Equals(theForm.Name))
                {
                    //해당form의 인스턴스가 존재하면 해당 창을 활성시킨다.
                    theForm.BringToFront();
                    theForm.Focus();
                    return;
                }
            }

            //	FormTachoReceive formTachoReceive = new FormTachoReceive(this);
            formMonthTacho.MdiParent = form1;
            formMonthTacho.Show();
            LayoutMdi(MdiLayout.TileHorizontal);






        }

        private void radioButton차량기사_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton차량기사.Checked == true)
            {
                comboBox차량번호.Enabled = true;
                comboBox기사번호.Enabled = true;
            }
        }

        private void comboBox차량번호_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = comboBox차량번호.SelectedIndex;
           combo_car_str = comboBox차량번호.SelectedItem as String; // 아래 2가지는 안됨....


        }

        private void comboBox기사번호_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = comboBox기사번호.SelectedIndex;
            combo_driver_str = comboBox기사번호.SelectedItem as String; // 아래 2가지는 안됨....
        }

      
    }
}