using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Data.OleDb;



namespace ConvertTacho
{

    public partial class FormTachoReceive : Form
    {


        private iniClass inicls = new iniClass();
        Form1 form1;
        public Boolean m_bStart;
        private Boolean isStartTimer = false;
        private Boolean isStartTimer1 = false;
        private Boolean isStartTimer2 = false;
        private Boolean isStartTimer3 = false;

        private Boolean isTimerUse = false;
        private Boolean isTimerUse1 = false;
        private Boolean isTimerUse2 = false;
        private Boolean isTimerUse3 = false;

        private Boolean isFirstDataGet = false;
        private Boolean isFirstDataGet1 = false;
        private Boolean isFirstDataGet2 = false;
        private Boolean isFirstDataGet3 = false;

        // SerialPort SP = new SerialPort();

        private List<byte> rcvList = new List<byte>();
        private List<byte> rcvList1 = new List<byte>();
        private List<byte> rcvList2 = new List<byte>();
        private List<byte> rcvList3 = new List<byte>();

        private int rcvCnt = 0;
        private int rcvCnt1 = 0;
        private int rcvCnt2 = 0;
        private int rcvCnt3 = 0;

        public AutoResetEvent areStep1 = new AutoResetEvent(false);
        public AutoResetEvent areStep2 = new AutoResetEvent(false);
        public AutoResetEvent areStep3 = new AutoResetEvent(false);
        public AutoResetEvent areStep4 = new AutoResetEvent(false);

        private int nLastTblTachoID = 0;

        System.Timers.Timer spTimer;
        string[] ports;
        public int saveFDCnt1 = 0;
        public int saveFDCnt2 = 0;
        public int saveFDCnt3 = 0;
        public int saveFDCnt4 = 0;

        public int hh = 0;
        public int mm = 0;
        public int ss = 0;

        public int hh1 = 0;
        public int mm1 = 0;
        public int ss1 = 0;

        public Queue DBPasingQueue;
        public bool pasing = false;
        public bool Serial1Call = false;
        public bool Serial2Call = false;
        public bool Serial3Call = false;
        public bool Serial4Call = false;
        public bool Data_Rcv1 = false;
        public bool Data_Rcv2 = false;
        public bool Data_Rcv3 = false;
        public bool Data_Rcv4 = false;


        public int Step_count = 0;
        public int Serial1No = 0;
        public int Serial2No = 0;
        public int Serial3No = 0;
        public int Serial4No = 0;


        public string SP_PortName = "COM1";
        public int SP_BaudRate = 38400;
        public int SP_DataBits = 8;
        public Parity SP_Parity = Parity.None;
        public StopBits SP_StopBits = StopBits.One;
        public bool opendlg = false;

        public string NowReceiveTMF1 = "\\NowReceive.TMF";
        public string NowReceiveTMF2 = "\\NowReceive.TMF";
        public string NowReceiveTMF3 = "\\NowReceive.TMF";
        public string NowReceiveTMF4 = "\\NowReceive.TMF";

        Color AliceBlue = Color.FromArgb(240, 248, 255);
        Color Blue = Color.FromArgb(0, 255, 255);
        Color LightPink = Color.FromArgb(255, 223, 223);


        private decimal totalMoney = 0;

        delegate void textCallbak(String txt);
        private string strInfoMsg = "";
        private int nNowFDCount = 0;

        private int rcvSPCnt = 0;
        private int rcvSPCnt1 = 0;
        private int rcvSPCnt2 = 0;
        private int rcvSPCnt3 = 0;
        int tstN = 0;
        int tstN1 = 0;
        int tstN2 = 0;
        int tstN3 = 0;
        public int P_delete_use = 0;
        public TimeSpan timeset;
        ScheduledTimer st;

        public TimeSpan timeset1;
        ScheduledTimer st1;

        //> 10.11.03 추가
        List<int> lnNowAddedData = new List<int>();
        List<DateTime> ldtNowAddedInTime = new List<DateTime>();
        List<DateTime> ldtNowAddedOutTime = new List<DateTime>();
        List<string> lsNowAddedCarNo = new List<string>();

        delegate void progressCallBack(int nProgressBar);
        //< 10.11.03 추가





        public struct TachoRamData
        {
            public int PremiumBasicDistance;
            public int PremiumAfterDistance;
            public int DriveBasicDistance;
            public int DriveAfterDistance;
            public int PremiumBasicMoney;
            public int PremiumAfterMoney;
            public int DriveBasicMoney;
            public int DriveAfterMoney;
            public int CallMoney;
            public int FreightMoney;
            public int DiscountMoney;
            public int TotalDriveDistance;
            public int TotalTradeDistance;
            public int TodayIncomeMoney;
            public int DistanceBy1Pulse;
            public int TodayTotalDriveDistance;
            public int TodayTotalTradeDistance;
            public DateTime InWarehouseTime;
            public DateTime OutWarehouseTime;
            public int RealIncomeMoney;
            public int DriverNumber;
            public double Fuel;
            public string CarNumber;
            public ushort _start;
            public ushort _size;
            public ushort _pointer;
            public byte _overflag;
            public int VersionNumber;
            public int TachoSavedTime;
        }

        public struct TachoDataCode
        {
            public int moneyTblTacho;
            public double salesKmTblTacho;
            public double driveDistanceTblTacho;
            public DateTime overrunTime;
            public int emerBreakCnt;
            public int driveBasicCnt;
            public int driveAfterCnt;
            public int premiumBasicCnt;
            public int premiumAfterCnt;
            public int doorOpenCnt;

            public int driveCount;
            public DateTime yymmdd;
            public DateTime beforeTime;
            public DateTime afterTime;
            public double salesKm;
            public int money;
            public double empty;
            public int emptyTime;
            public bool notuse;
            public bool add;
            public bool key;
            public bool emerBreak;
            public DateTime emerTime;
            public DateTime emptyStartTime;
            public int emerSpeed;

            // '10. 7.19 추가
            public int celldriveBasicCnt;
            public int celldriveAfterCnt;
            public int cellpremiumBasicCnt;
            public int cellpremiumAfterCnt;
            public int cellsalesCnt;
            public int cellsalesTime;
            public int cellcarEmptyTime;
            public int cellkeyUseCnt;
            public int cellemerBreakCnt;
            public DateTime celloverrunTime;
            //

            public bool MKdoor;
            public double TotalDriveDistanceSaved;
            public double TotalDriveDistance;
            public int speed;
            public double distance;
            public bool sales;
            public bool engine;

            public int salesCnt;        // 영업회수
            public int carEmptyTime;    // 공차시간
            public int keyUseCnt;       // 키사용회수
            public int salesTime;       // 영업시간


        }

        [STAThread]
        private void AppendText(String str)
        {
            if (this.label9.InvokeRequired)
            {
                textCallbak d = new textCallbak(AppendText);
                this.Invoke(d, new object[] { str });
            }
            else
            {
                this.label9.Text = str;
            }
        }

        [STAThread]
        private void DrawProgressBar(int nProgressBar)
        {
            if (this.progressBar1.InvokeRequired)
            {
                progressCallBack d = new progressCallBack(DrawProgressBar);
                this.Invoke(d, new object[] { nProgressBar });
            }
            else
            {
                this.progressBar1.Value = nProgressBar;
            }
        }

        [STAThread]
        void SP_DataRecieved(Object sender, SerialDataReceivedEventArgs e)
        {

           

            if (serialPort1.IsOpen)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    isStartTimer = true;
                    spTimer.Enabled = false;
                    tstN = 0;


                    byte[] bt = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(bt, 0, bt.Length);
                    rcvList.AddRange(bt);
                    Serial1Call = true;
                }

                if (rcvList.Count > 3)
                {
                    if (rcvList[0] == 0x38 && rcvList[1] == 0x95)
                    {
                        rcvList.Clear();
                        label6.Text = "IRD  수신대기중";



                    }
                    else if (rcvList[0] == 0x38 && rcvList[1] == 0x94)
                    {
                        rcvList.Clear();

                        System.Threading.Thread.Sleep(4000);

                        label6.Text = "판독기 데이터 삭제";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd1();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd1();
                    }
                    else if (rcvList[0] == 0x38 && rcvList[1] == 0x93)
                    {
                        if (pasing)
                        {
                            spTimer.Enabled = true;
                            isFirstDataGet = true;
                        }

                        rcvList.Clear();
                        label6.Text = "판독기 데이터 없음";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd1();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd1();
                    }
                    else if (rcvList[0] == 0x55 && rcvList[1] == 0x15 && rcvList[2] == 0xA5)
                    {
                        label6.Text = "판독기 데이터수신";
                        spTimer.Enabled = true;
                        isFirstDataGet = true;
                    }

                    else
                    {



                        rcvList.Clear();

                    }

                }

            }

        }
        [STAThread]
        void SP_DataRecieved1(Object sender, SerialDataReceivedEventArgs e)
        {
          

            if (serialPort2.IsOpen)
            {
                if (serialPort2.BytesToRead > 0)
                {
                    isStartTimer1 = true;
                    spTimer1.Enabled = false;
                    tstN1 = 0;

                    byte[] bt1 = new byte[serialPort2.BytesToRead];
                    serialPort2.Read(bt1, 0, bt1.Length);
                    rcvList1.AddRange(bt1);
                    Serial2Call = true;
                }

                if (rcvList1.Count > 3)
                {
                    if (rcvList1[0] == 0x38 && rcvList1[1] == 0x95)
                    {
                        rcvList1.Clear();
                        label26.Text = "IRD  수신대기중";

                    }
                    else if (rcvList1[0] == 0x38 && rcvList1[1] == 0x94)
                    {
                        rcvList1.Clear();

                        System.Threading.Thread.Sleep(4000);
                        //		MessageBox.Show("판독기 2 데이터 삭제 완료!");
                        label26.Text = "판독기 데이터 삭제";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd2();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd2();
                    }
                    else if (rcvList1[0] == 0x38 && rcvList1[1] == 0x93)
                    {
                        if (pasing)
                        {
                            spTimer1.Enabled = true;
                            isFirstDataGet1 = true;
                        }
                        rcvList1.Clear();
                        label26.Text = "판독기 데이터 없음";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd2();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd2();
                    }
                    else if (rcvList1[0] == 0x55 && rcvList1[1] == 0x15 && rcvList1[2] == 0xA5)
                    {
                        label26.Text = "판독기 데이터수신";
                        spTimer1.Enabled = true;
                        isFirstDataGet1 = true;
                    }

                    else
                    {


                        rcvList1.Clear();

                    }
                }

            }

        }
        [STAThread]
        void SP_DataRecieved2(Object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort3.IsOpen)
            {
                if (serialPort3.BytesToRead > 0)
                {

                    byte[] bt2 = new byte[serialPort3.BytesToRead];
                    serialPort3.Read(bt2, 0, bt2.Length);
                    rcvList2.AddRange(bt2);

                }
            }

            if (serialPort3.IsOpen)
            {
                if (serialPort3.BytesToRead > 0)
                {
                    isStartTimer2 = true;
                    spTimer2.Enabled = false;
                    tstN2 = 0;

                    byte[] bt2 = new byte[serialPort3.BytesToRead];
                    serialPort3.Read(bt2, 0, bt2.Length);
                    rcvList2.AddRange(bt2);
                    Serial3Call = true;
                }

                if (rcvList2.Count > 3)
                {
                    if (rcvList2[0] == 0x38 && rcvList2[1] == 0x95)
                    {
                        rcvList2.Clear();
                        label27.Text = "IRD  수신대기중";



                    }
                    else if (rcvList2[0] == 0x38 && rcvList2[1] == 0x94)
                    {
                        rcvList2.Clear();
                        System.Threading.Thread.Sleep(4000);
                        //	MessageBox.Show("판독기 3 데이터 삭제 완료!");
                        label27.Text = "판독기 데이터 삭제";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd3();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd3();
                    }
                    else if (rcvList2[0] == 0x38 && rcvList2[1] == 0x93)
                    {
                        if (pasing)
                        {
                            spTimer2.Enabled = true;
                            isFirstDataGet2 = true;
                        }
                        rcvList2.Clear();
                        label27.Text = "판독기 데이터 없음";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd3();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd3();
                    }
                    else if (rcvList2[0] == 0x55 && rcvList2[1] == 0x15 && rcvList2[2] == 0xA5)
                    {

                        label27.Text = "판독기 데이터수신";
                        spTimer2.Enabled = true;
                        isFirstDataGet2 = true;

                    }

                    else
                    {

                        rcvList2.Clear();
                    }
                }



            }

        }
        [STAThread]
        void SP_DataRecieved3(Object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort4.IsOpen)
            {
                if (serialPort4.BytesToRead > 0)
                {

                    byte[] bt3 = new byte[serialPort4.BytesToRead];
                    serialPort4.Read(bt3, 0, bt3.Length);
                    rcvList3.AddRange(bt3);
                }
            }

            if (serialPort4.IsOpen)
            {
                if (serialPort4.BytesToRead > 0)
                {
                    isStartTimer3 = true;
                    spTimer3.Enabled = false;
                    tstN3 = 0;

                    byte[] bt3 = new byte[serialPort4.BytesToRead];
                    serialPort4.Read(bt3, 0, bt3.Length);
                    rcvList3.AddRange(bt3);
                    Serial4Call = true;
                }

                if (rcvList3.Count > 3)
                {
                    if (rcvList3[0] == 0x38 && rcvList3[1] == 0x95)
                    {
                        rcvList3.Clear();
                        label28.Text = "IRD  수신대기중";


                    }
                    else if (rcvList3[0] == 0x38 && rcvList3[1] == 0x94)
                    {
                        rcvList3.Clear();
                        System.Threading.Thread.Sleep(4000);
                        //		MessageBox.Show("판독기 4 데이터 삭제 완료!");
                        label28.Text = "판독기 데이터 삭제";
                        System.Threading.Thread.Sleep(1000);

                        IRDReceiveStart_SendCmd4();
                    }
                    else if (rcvList3[0] == 0x38 && rcvList3[1] == 0x93)
                    {
                        if (pasing)
                        {
                            spTimer3.Enabled = true;
                            isFirstDataGet3 = true;
                        }
                        rcvList3.Clear();
                        label28.Text = "판독기 데이터 없음";
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd4();
                        System.Threading.Thread.Sleep(1000);
                        IRDReceiveStart_SendCmd4();
                    }
                    else if (rcvList3[0] == 0x55 && rcvList3[1] == 0x15 && rcvList3[2] == 0xA5)
                    {
                        label28.Text = "판독기 데이터수신";
                        spTimer3.Enabled = true;
                        isFirstDataGet3 = true;
                    }

                    else
                    {


                        rcvList3.Clear();

                    }
                }

            }

        }
        [STAThread]
        private void spTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isTimerUse)
            {
                if (!isStartTimer && isFirstDataGet && (tstN > 10))
                {
                    tstN = 0;
                    isTimerUse = false;
                    isFirstDataGet = false;
                    spTimer.Enabled = false;

                    //	Thread SaveFileThread1 = new Thread(TransperAndSaveFile);
                    //	SaveFileThread1.Start();
                  
                    if (rcvList[0] == 0x55 && rcvList[1] == 0x15 && rcvList[2] == 0xA5)
                    {
                        TransperAndSaveFile();
                        serialPort1.DiscardInBuffer();
                        serialPort1.DiscardOutBuffer();

                    }
                    else
                    {
                        //  MessageBox.Show("Test");

                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        string temp = "";
                    
                        for (int i = 0; i < rcvList.Count; i++)
                        {
                            temp += String.Format("{0:X2} ", rcvList[i]);
                        }


                        //MessageBox.Show("Data Error!!!!");
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("12.[" + DateTime.Now.ToString() + "rcvList Data Error :" + temp);
                        }
                        rcvList.Clear();

                        if (serialPort1.IsOpen)
                        {
                            isTimerUse = true;
                            //label9.Text = "Data Receiving...";
                            strInfoMsg = "데이터 수신 대기중";
                            label6.Text = "IRD  수신대기중";
                            AppendText(strInfoMsg);

                            serialPort1.DiscardInBuffer();
                            serialPort1.DiscardOutBuffer();

                            string parity = "E", stopbits = "N";
                            switch (serialPort1.Parity)
                            {
                                case Parity.Even: parity = "E"; break;
                                case Parity.Mark: parity = "M"; break;
                                case Parity.None: parity = "N"; break;
                                case Parity.Odd: parity = "O"; break;
                                case Parity.Space: parity = "S"; break;
                            }
                            switch (serialPort1.StopBits)
                            {
                                case StopBits.None: stopbits = "0"; break;
                                case StopBits.One: stopbits = "1"; break;
                                case StopBits.OnePointFive: stopbits = "1.5"; break;
                                case StopBits.Two: stopbits = "2"; break;
                            }
                            //  label11.Text = serialPort1.PortName + " | " + serialPort1.BaudRate.ToString() + "," + serialPort1.DataBits + "," + parity + "," + stopbits;
                            label11.Text = serialPort1.PortName + " | Open";
                        }
                        else
                        {
                            //label9.Text = "";
                            strInfoMsg = "";
                            AppendText(strInfoMsg);

                            label11.Text = serialPort1.PortName + " | 열기 실패";
                        }

                    }

                    label1_Ani_0.Visible = false;
                    label1_Base.Visible = true;
                    form1.ftplabel.Text = "";

                    button3.Enabled = true;
                    button6.Enabled = true;
                    button9.Enabled = true;
                }
                else if (isFirstDataGet)
                {
                    label1_Base.Visible = false;
                    label1_Ani_0.Visible = true;

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button9.Enabled = false;

                    form1.ftplabel.Text = "판독기 데이터 수신중....";

                    if (rcvSPCnt == 0)
                        strInfoMsg = "데이터 수신중";
                    else if (rcvSPCnt == 1)
                        strInfoMsg = "데이터 수신중.";
                    else if (rcvSPCnt == 2)
                        strInfoMsg = "데이터 수신중..";
                    else if (rcvSPCnt == 3)
                        strInfoMsg = "데이터 수신중...";

                    tstN++;

                    AppendText(strInfoMsg);

                    if (++rcvSPCnt > 3)
                        rcvSPCnt = 0;
                }

                isStartTimer = false;
                //spTimer.Enabled = false;


            }

        }
        [STAThread]
        private void spTimer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isTimerUse1)
            {
                if (!isStartTimer1 && isFirstDataGet1 && (tstN1 > 10))
                {
                    tstN1 = 0;
                    isTimerUse1 = false;
                    isFirstDataGet1 = false;
                    spTimer1.Enabled = false;
                    if (rcvList1[0] == 0x55 && rcvList1[1] == 0x15 && rcvList1[2] == 0xA5)
                    {
                        TransperAndSaveFile1();
                        serialPort2.DiscardInBuffer();
                        serialPort2.DiscardOutBuffer();
                    }
                    else
                    {
                        //  MessageBox.Show("Test");

                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        string temp = "";

                        for (int i = 0; i < rcvList1.Count; i++)
                        {
                            temp += String.Format("{0:X2} ", rcvList1[i]);
                        }


                        //MessageBox.Show("Data Error!!!!");
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("12.[" + DateTime.Now.ToString() + "rcvList1 Data Error :" + temp);
                        }
                        rcvList1.Clear();
                        if (serialPort2.IsOpen)
                        {
                            isTimerUse1 = true;


                            string parity = "E", stopbits = "N";
                            switch (serialPort2.Parity)
                            {
                                case Parity.Even: parity = "E"; break;
                                case Parity.Mark: parity = "M"; break;
                                case Parity.None: parity = "N"; break;
                                case Parity.Odd: parity = "O"; break;
                                case Parity.Space: parity = "S"; break;
                            }
                            switch (serialPort2.StopBits)
                            {
                                case StopBits.None: stopbits = "0"; break;
                                case StopBits.One: stopbits = "1"; break;
                                case StopBits.OnePointFive: stopbits = "1.5"; break;
                                case StopBits.Two: stopbits = "2"; break;
                            }
                            //	label7.Text = serialPort2.PortName + " | " + serialPort2.BaudRate.ToString() + "," + serialPort2.DataBits + "," + parity + "," + stopbits;
                            label7.Text = serialPort2.PortName + " | Open";
                        }
                        else
                        {
                            //label9.Text = "";
                            strInfoMsg = "";
                            //	AppendText(strInfoMsg);

                            label7.Text = serialPort2.PortName + " | 열기 실패";
                        }

                    }
                    label1_Ani_1.Visible = false;
                    label2_Base.Visible = true;
                    form1.ftplabel.Text = "";

                    button3.Enabled = true;
                    button6.Enabled = true;
                    button9.Enabled = true;
                }
                else if (isFirstDataGet1)
                {
                    button3.Enabled = false;
                    button6.Enabled = false;
                    button9.Enabled = false;

                    label2_Base.Visible = false;
                    label1_Ani_1.Visible = true;
                    form1.ftplabel.Text = "판독기 데이터 수신중....";
                    if (rcvSPCnt1 == 0)
                        strInfoMsg = "데이터 수신중";
                    else if (rcvSPCnt1 == 1)
                        strInfoMsg = "데이터 수신중.";
                    else if (rcvSPCnt1 == 2)
                        strInfoMsg = "데이터 수신중..";
                    else if (rcvSPCnt1 == 3)
                        strInfoMsg = "데이터 수신중...";

                    tstN1++;

                    //   AppendText(strInfoMsg);

                    if (++rcvSPCnt1 > 3)
                        rcvSPCnt1 = 0;
                }

                isStartTimer1 = false;
                //spTimer.Enabled = false;
            }
        }

        [STAThread]
        private void spTimer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isTimerUse2)
            {
                if (!isStartTimer2 && isFirstDataGet2 && (tstN2 > 10))
                {
                    tstN2 = 0;
                    isTimerUse2 = false;
                    isFirstDataGet2 = false;
                    spTimer2.Enabled = false;
                    if (rcvList2[0] == 0x55 && rcvList2[1] == 0x15 && rcvList2[2] == 0xA5)
                    {
                        TransperAndSaveFile2();
                        serialPort3.DiscardInBuffer();
                        serialPort3.DiscardOutBuffer();
                    }
                    else
                    {
                        //  MessageBox.Show("Test");

                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        string temp = "";

                        for (int i = 0; i < rcvList2.Count; i++)
                        {
                            temp += String.Format("{0:X2} ", rcvList2[i]);
                        }


                        //MessageBox.Show("Data Error!!!!");
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("12.[" + DateTime.Now.ToString() + "rcvList2 Data Error :" + temp);
                        }
                        rcvList2.Clear();
                        if (serialPort3.IsOpen)
                        {
                            isTimerUse2 = true;


                            string parity = "E", stopbits = "N";
                            switch (serialPort3.Parity)
                            {
                                case Parity.Even: parity = "E"; break;
                                case Parity.Mark: parity = "M"; break;
                                case Parity.None: parity = "N"; break;
                                case Parity.Odd: parity = "O"; break;
                                case Parity.Space: parity = "S"; break;
                            }
                            switch (serialPort3.StopBits)
                            {
                                case StopBits.None: stopbits = "0"; break;
                                case StopBits.One: stopbits = "1"; break;
                                case StopBits.OnePointFive: stopbits = "1.5"; break;
                                case StopBits.Two: stopbits = "2"; break;
                            }
                            //	label18.Text = serialPort3.PortName + " | " + serialPort3.BaudRate.ToString() + "," + serialPort3.DataBits + "," + parity + "," + stopbits;
                            label18.Text = serialPort3.PortName + " | Open";
                        }
                        else
                        {
                            //label9.Text = "";
                            strInfoMsg = "";
                            //	AppendText(strInfoMsg);

                            label18.Text = serialPort3.PortName + " | 열기 실패";
                        }

                    }

                    label2_Ani_1.Visible = false;
                    label3_Base.Visible = true;
                    form1.ftplabel.Text = "";

                    button3.Enabled = true;
                    button6.Enabled = true;
                    button9.Enabled = true;
                }
                else if (isFirstDataGet2)
                {

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button9.Enabled = false;

                    label3_Base.Visible = false;
                    label2_Ani_1.Visible = true;
                    form1.ftplabel.Text = "판독기 데이터 수신중....";
                    if (rcvSPCnt2 == 0)
                        strInfoMsg = "데이터 수신중";
                    else if (rcvSPCnt2 == 1)
                        strInfoMsg = "데이터 수신중.";
                    else if (rcvSPCnt2 == 2)
                        strInfoMsg = "데이터 수신중..";
                    else if (rcvSPCnt2 == 3)
                        strInfoMsg = "데이터 수신중...";

                    tstN2++;

                    //   AppendText(strInfoMsg);

                    if (++rcvSPCnt2 > 3)
                        rcvSPCnt2 = 0;
                }

                isStartTimer2 = false;
                //spTimer.Enabled = false;
            }
        }
        [STAThread]
        private void spTimer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isTimerUse3)
            {
                if (!isStartTimer3 && isFirstDataGet3 && (tstN3 > 10))
                {
                    tstN3 = 0;
                    isTimerUse3 = false;
                    isFirstDataGet3 = false;
                    spTimer3.Enabled = false;
                    if (rcvList3[0] == 0x55 && rcvList3[1] == 0x15 && rcvList3[2] == 0xA5)
                    {
                        TransperAndSaveFile3();
                        serialPort4.DiscardInBuffer();
                        serialPort4.DiscardOutBuffer();
                    }
                    else
                    {
                        //  MessageBox.Show("Test");

                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        string temp = "";

                        for (int i = 0; i < rcvList3.Count; i++)
                        {
                            temp += String.Format("{0:X2} ", rcvList3[i]);
                        }


                        //MessageBox.Show("Data Error!!!!");
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("12.[" + DateTime.Now.ToString() + "rcvList3 Data Error :" + temp);
                        }
                        rcvList3.Clear();
                        if (serialPort4.IsOpen)
                        {
                            isTimerUse3 = true;


                            string parity = "E", stopbits = "N";
                            switch (serialPort4.Parity)
                            {
                                case Parity.Even: parity = "E"; break;
                                case Parity.Mark: parity = "M"; break;
                                case Parity.None: parity = "N"; break;
                                case Parity.Odd: parity = "O"; break;
                                case Parity.Space: parity = "S"; break;
                            }
                            switch (serialPort4.StopBits)
                            {
                                case StopBits.None: stopbits = "0"; break;
                                case StopBits.One: stopbits = "1"; break;
                                case StopBits.OnePointFive: stopbits = "1.5"; break;
                                case StopBits.Two: stopbits = "2"; break;
                            }
                            //	label23.Text = serialPort4.PortName + " | " + serialPort4.BaudRate.ToString() + "," + serialPort4.DataBits + "," + parity + "," + stopbits;
                            label23.Text = serialPort4.PortName + " | Open";
                        }
                        else
                        {
                            //label9.Text = "";
                            strInfoMsg = "";
                            //	AppendText(strInfoMsg);

                            label23.Text = serialPort4.PortName + " | 열기 실패";
                        }

                    }
                    label3_Ani_1.Visible = false;
                    label4_Base.Visible = true;
                    form1.ftplabel.Text = "";

                    button3.Enabled = true;
                    button6.Enabled = true;
                    button9.Enabled = true;

                }
                else if (isFirstDataGet3)
                {
                    button3.Enabled = false;
                    button6.Enabled = false;
                    button9.Enabled = false;

                    label4_Base.Visible = false;
                    label3_Ani_1.Visible = true;
                    form1.ftplabel.Text = "판독기 데이터 수신중....";
                    if (rcvSPCnt3 == 0)
                        strInfoMsg = "데이터 수신중";
                    else if (rcvSPCnt3 == 1)
                        strInfoMsg = "데이터 수신중.";
                    else if (rcvSPCnt3 == 2)
                        strInfoMsg = "데이터 수신중..";
                    else if (rcvSPCnt3 == 3)
                        strInfoMsg = "데이터 수신중...";

                    tstN3++;

                    //   AppendText(strInfoMsg);

                    if (++rcvSPCnt3 > 3)
                        rcvSPCnt3 = 0;
                }

                isStartTimer3 = false;
                //spTimer.Enabled = false;
            }
        }
        public FormTachoReceive(Form1 f)
        {
            InitializeComponent();
            m_bStart = true;
            spTimer = new System.Timers.Timer();
            spTimer.Interval = 50000;

            spTimer1 = new System.Timers.Timer();
            spTimer1.Interval = 50000;

            spTimer2 = new System.Timers.Timer();
            spTimer2.Interval = 50000;

            spTimer3 = new System.Timers.Timer();
            spTimer3.Interval = 50000;
            ports = System.IO.Ports.SerialPort.GetPortNames();

            ImageList dummyImageList = new ImageList();
            dummyImageList.ImageSize = new System.Drawing.Size(1, 18);
            listView1.SmallImageList = dummyImageList;

            form1 = f;

            spTimer.Enabled = false;
            spTimer1.Enabled = false;
            spTimer2.Enabled = false;
            spTimer3.Enabled = false;

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SP_DataRecieved);
            serialPort2.DataReceived += new SerialDataReceivedEventHandler(SP_DataRecieved1);
            serialPort3.DataReceived += new SerialDataReceivedEventHandler(SP_DataRecieved2);
            serialPort4.DataReceived += new SerialDataReceivedEventHandler(SP_DataRecieved3);





            foreach (string port in ports)//PC 에 있는 시리얼 포트 찾아서 저장
            {
                comboBoxPort.Items.Add(port);
                comboBoxPort2.Items.Add(port);
                comboBoxPort3.Items.Add(port);
                comboBoxPort4.Items.Add(port);
            }


            radioButton수집기.Checked = true;

            if (form1.radioButton_타코.Checked == true)
            {
                radioButton_타코.Checked = true;
            }
            else if (form1.radioButton_1day.Checked == true)
            {
                radioButton_일별자르기.Checked = true;
            }
            else if (form1.radioButton_2day.Checked == true)
            {
                radioButton_교대시간.Checked = true;
                AMtextBox.Text = form1.AMtextBox.Text;
                PMtextBox.Text = form1.PMtextBox.Text;
            }
            else if (form1.radioButton_auto.Checked == true)
            {

                radioButton_타코자동분리.Checked = true;
            }


            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            int combo1 = 0;
            int combo2 = 1;
            int combo3 = 2;
            int combo4 = 3;

            //   progressBar1.Visible = true;
            //   progressBar1.Minimum = 1;
            //    progressBar1.Maximum = 100;
            //    progressBar1.Value = 1;
            //     progressBar1.Step = 1;

            //  string path = Application.StartupPath + "\\serialsetting.ini";

            string path = Application.StartupPath + "\\WinTacho.ini";

            string RValue = "";
            RValue = inicls.GetIniValue("Serial Setting", "SP", path);
            serialPort1.PortName = RValue;

            RValue = inicls.GetIniValue("Serial Setting", "BS", path);
            serialPort1.BaudRate = Convert.ToInt32(RValue);


            RValue = inicls.GetIniValue("Serial Setting", "combo1", path);
            combo1 = Convert.ToInt32(RValue);


            RValue = inicls.GetIniValue("Serial Setting", "combo2", path);
            combo2 = Convert.ToInt32(RValue);


            RValue = inicls.GetIniValue("Serial Setting", "combo3", path);
            combo3 = Convert.ToInt32(RValue);


            RValue = inicls.GetIniValue("Serial Setting", "combo4", path);
            combo4 = Convert.ToInt32(RValue);

            RValue = inicls.GetIniValue("Serial Setting", "Pasing use", path);
            int intpasing = 0;


            RValue = inicls.GetIniValue("Serial Setting", "Auto delete", path);
            P_delete_use = Convert.ToInt32(RValue);


            if (intpasing == 1)
            {
                pasing = true;
            }
            else
            {
                pasing = false;
            }




            if (comboBoxPort.Items.Count > 3)
            {

                comboBoxPort.SelectedIndex = combo1;
                comboBoxPort2.SelectedIndex = combo2;
                comboBoxPort3.SelectedIndex = combo3;
                comboBoxPort4.SelectedIndex = combo4;
            }

            //label9.Text = "";
            strInfoMsg = "";
            AMtextBox.Text = f.AMtextBox.Text;
            PMtextBox.Text = f.PMtextBox.Text;
            AppendText(strInfoMsg);
            if (comboBoxPort.Items.Count > 3)
            {
                label11.Text = comboBoxPort.Items[0] + " | Closed";
                label7.Text = comboBoxPort2.Items[1] + " | Closed";
                label18.Text = comboBoxPort3.Items[2] + " | Closed";
                label23.Text = comboBoxPort4.Items[3] + " | Closed";
            }

            if (form1.auto_serial)
            {

                Serial_Auto_Setting();
                IRDReceiveStart_SendCmd();
            }
            buttonOldFileLoad.Visible = false;
            groupBox2.Visible = false;
            panel1.Visible = false;
            label1.Visible = false;
            groupBox6.Visible = false;

        }
        private TimeSpan GetTimeSpan()
        {
            return new TimeSpan((int)hh, (int)mm, (int)ss);
        }

        private void ExecMethod()
        {
            //MessageBox.Show(DateTime.Now.ToLongTimeString() +"  예약시간 테스트");
            if (form1.FtpServerConnect.Visible == false)
            {

                TachoDataRecieve_SendCmd();
            }
            else
            {
                form1.Time_Set_ftpStart();
            }
        }
        private void ExecMethod1()
        {
            //MessageBox.Show(DateTime.Now.ToLongTimeString() + "  예약시간 테스트");


            if (form1.FtpServerConnect.Visible == false)
            {

                TachoDataRecieve_SendCmd();
            }
            else
            {
                form1.Time_Set_ftpStart();
            }
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

        private void radioButton수집기_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton수집기.Checked)
            {
                label8.Visible = false;
                //   panel1.Visible = false;

            }
        }

        private void radioButton자동수신_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton자동수신.Checked)
            {
                label8.Visible = false;
                //   panel1.Visible = false;

            }
        }

        private void radioButton유선수신_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton유선수신.Checked)
            {
                label8.Visible = true;
                panel1.Visible = true;

            }
        }

        private void radioButton판독기직렬_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton판독기직렬.Checked)
            {
                label8.Visible = false;
                //      panel1.Visible = false;

            }
        }

        private void radioButton판독기병렬_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton판독기병렬.Checked)
            {
                label8.Visible = false;
                //  panel1.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // FormCommunicationSetting formCommunicationSetting = new FormCommunicationSetting(this);
            //  formCommunicationSetting.StartPosition = FormStartPosition.CenterParent;
            // formCommunicationSetting.ShowDialog();
        }
        public void Serial_Auto_Setting()
        {
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            rcvList.Clear();

            //serialPort1.PortName = SP_PortName;

            if (comboBoxPort.Items.Count > 3)
            {
                if (!serialPort1.IsOpen)
                {


                    serialPort1.PortName = comboBoxPort.SelectedItem.ToString();

                    //
                    serialPort1.BaudRate = (int)38400;
                    serialPort1.DataBits = (int)8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                }


                string str = Application.StartupPath + NowReceiveTMF1;
                if (File.Exists(str))
                {
                    File.Delete(str);
                }

                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }

                    if (serialPort1.IsOpen)
                    {
                        isTimerUse = true;
                        //label9.Text = "Data Receiving...";
                        strInfoMsg = "데이터 수신 대기중";
                        AppendText(strInfoMsg);

                        string parity = "E", stopbits = "N";
                        switch (serialPort1.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort1.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //	label11.Text = serialPort1.PortName + " | " + serialPort1.BaudRate.ToString() + "," + serialPort1.DataBits + "," + parity + "," + stopbits;
                        label11.Text = serialPort1.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        AppendText(strInfoMsg);

                        label11.Text = serialPort1.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    //label9.Text = SP_PortName + " 열기 실패";
                    //  strInfoMsg = SP_PortName + " 열기 실패";
                    //  AppendText(strInfoMsg);
                    MessageBox.Show(ex.Message);

                }
                ////////////////
                rcvList1.Clear();
                if (!serialPort2.IsOpen)
                {
                    serialPort2.PortName = comboBoxPort2.SelectedItem.ToString();


                    serialPort2.BaudRate = (int)38400;
                    serialPort2.DataBits = (int)8;
                    serialPort2.Parity = Parity.None;
                    serialPort2.StopBits = StopBits.One;
                    //
                    serialPort2.ReadTimeout = (int)2000;
                    serialPort2.WriteTimeout = (int)2000;
                    serialPort2.ReadBufferSize = 0x10000;
                }

                string str1 = Application.StartupPath + NowReceiveTMF2;
                if (File.Exists(str1))
                {
                    File.Delete(str1);
                }


                if (!serialPort2.IsOpen)
                {
                    serialPort2.Open();
                }

                if (serialPort2.IsOpen)
                {
                    isTimerUse1 = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    //	AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (serialPort2.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (serialPort2.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    //	label7.Text = serialPort2.PortName + " | " + serialPort2.BaudRate.ToString() + "," + serialPort2.DataBits + "," + parity + "," + stopbits;
                    label7.Text = serialPort2.PortName + " | Open";
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    label7.Text = serialPort2.PortName + " | 열기 실패";
                }
                ///////////////////
                rcvList2.Clear();
                if (!serialPort3.IsOpen)
                {
                    serialPort3.PortName = comboBoxPort3.SelectedItem.ToString();

                    serialPort3.BaudRate = (int)38400;
                    serialPort3.DataBits = (int)8;
                    serialPort3.Parity = Parity.None;
                    serialPort3.StopBits = StopBits.One;
                    //
                    serialPort3.ReadTimeout = (int)2000;
                    serialPort3.WriteTimeout = (int)2000;
                    serialPort3.ReadBufferSize = 0x10000;
                }

                string str2 = Application.StartupPath + NowReceiveTMF3;
                if (File.Exists(str2))
                {
                    File.Delete(str2);
                }

                try
                {
                    if (!serialPort3.IsOpen)
                    {
                        serialPort3.Open();
                    }

                    if (serialPort3.IsOpen)
                    {
                        isTimerUse2 = true;
                        //label9.Text = "Data Receiving...";
                        strInfoMsg = "데이터 수신 대기중";
                        //	AppendText(strInfoMsg);

                        string parity = "E", stopbits = "N";
                        switch (serialPort3.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort3.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //label18.Text = serialPort3.PortName + " | " + serialPort3.BaudRate.ToString() + "," + serialPort3.DataBits + "," + parity + "," + stopbits;
                        label18.Text = serialPort3.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label18.Text = serialPort3.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }
                ////////////////
                rcvList2.Clear();
                if (!serialPort3.IsOpen)
                {
                    serialPort3.PortName = comboBoxPort3.SelectedItem.ToString();

                    serialPort3.BaudRate = (int)38400;
                    serialPort3.DataBits = (int)8;
                    serialPort3.Parity = Parity.None;
                    serialPort3.StopBits = StopBits.One;
                    //
                    serialPort3.ReadTimeout = (int)2000;
                    serialPort3.WriteTimeout = (int)2000;
                    serialPort3.ReadBufferSize = 0x10000;
                }

                string str3 = Application.StartupPath + NowReceiveTMF3;
                if (File.Exists(str3))
                {
                    File.Delete(str3);
                }

                try
                {
                    if (!serialPort3.IsOpen)
                    {
                        serialPort3.Open();
                    }

                    if (serialPort3.IsOpen)
                    {
                        isTimerUse2 = true;
                        //label9.Text = "Data Receiving...";
                        strInfoMsg = "데이터 수신 대기중";
                        //	AppendText(strInfoMsg);

                        string parity = "E", stopbits = "N";
                        switch (serialPort3.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort3.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //label18.Text = serialPort3.PortName + " | " + serialPort3.BaudRate.ToString() + "," + serialPort3.DataBits + "," + parity + "," + stopbits;
                        label18.Text = serialPort3.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label18.Text = serialPort3.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }
                ////////////////////
                rcvList3.Clear();
                if (!serialPort4.IsOpen)
                {
                    serialPort4.PortName = comboBoxPort4.SelectedItem.ToString();

                    serialPort4.BaudRate = (int)38400;
                    serialPort4.DataBits = (int)8;
                    serialPort4.Parity = Parity.None;
                    serialPort4.StopBits = StopBits.One;
                    //
                    serialPort4.ReadTimeout = (int)2000;
                    serialPort4.WriteTimeout = (int)2000;
                    serialPort4.ReadBufferSize = 0x10000;
                }

                string str4 = Application.StartupPath + NowReceiveTMF4;
                if (File.Exists(str4))
                {
                    File.Delete(str4);
                }

                try
                {
                    if (!serialPort4.IsOpen)
                    {
                        serialPort4.Open();
                    }

                    if (serialPort4.IsOpen)
                    {
                        isTimerUse3 = true;
                        //label9.Text = "Data Receiving...";
                        strInfoMsg = "데이터 수신 대기중";
                        //	AppendText(strInfoMsg);

                        string parity = "E", stopbits = "N";
                        switch (serialPort4.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort4.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //	label23.Text = serialPort4.PortName + " | " + serialPort4.BaudRate.ToString() + "," + serialPort4.DataBits + "," + parity + "," + stopbits;
                        label23.Text = serialPort4.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label23.Text = serialPort4.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            rcvList.Clear();

            //serialPort1.PortName = SP_PortName;
            if (!serialPort1.IsOpen)
            {

                serialPort1.PortName = comboBoxPort.SelectedItem.ToString();

                //
                serialPort1.BaudRate = (int)38400;
                serialPort1.DataBits = (int)8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
            }


            string str = Application.StartupPath + NowReceiveTMF1;
            if (File.Exists(str))
            {
                File.Delete(str);
            }

            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }

                if (serialPort1.IsOpen)
                {
                    isTimerUse = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (serialPort1.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (serialPort1.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    //	label11.Text = serialPort1.PortName + " | " + serialPort1.BaudRate.ToString() + "," + serialPort1.DataBits + "," + parity + "," + stopbits;
                    label11.Text = serialPort1.PortName + " | Open";
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    AppendText(strInfoMsg);

                    label11.Text = serialPort1.PortName + " | 열기 실패";
                }
            }
            catch (Exception ex)
            {
                //label9.Text = SP_PortName + " 열기 실패";
                //  strInfoMsg = SP_PortName + " 열기 실패";
                //  AppendText(strInfoMsg);
                MessageBox.Show(ex.Message);

            }
        }
        public void Step1()
        {
            //	Thread DataDB1 = new Thread(Parsing1);
            //	DataDB1.Start();
            //	System.Threading.Thread.Sleep(2000);


            // IRDReceiveStart_SendCmd1();
            //System.Threading.Thread.Sleep(1000);
            //IRDReceiveStart_SendCmd1();


            if (Data_Rcv1 == true)
            {
                Data_Rcv1 = false;


            }
            else
            {

                //  form1.Autotmf = true;
                FillDataToDB(saveFDCnt1);

            }


            if (pasing)
            {

                form1.CarListInit();

                FillDataToDB(saveFDCnt1);
            }
            if (form1.pasing1 == false)
                areStep1.Set();



        }
        public void Step2()
        {

            //IRDReceiveStart_SendCmd2();
            //	System.Threading.Thread.Sleep(1000);
            //	IRDReceiveStart_SendCmd2();


            if (Data_Rcv2 == true)
            {
                Data_Rcv2 = false;


            }
            else
            {
                //  form1.Autotmf = true;
                FillDataToDB1(saveFDCnt2);
            }

            //   form1.Autotmf = true;
            //      FillDataToDB1(saveFDCnt2);

            if (pasing)
            {

                areStep1.WaitOne();


                FillDataToDB1(saveFDCnt2);

            }
            else if (!pasing && P_delete_use == 1)
            {
                areStep1.WaitOne();
            }
            if (form1.pasing2 == false && form1.pasing1 == false && form1.pasing3 == false && form1.pasing4 == false)
                areStep2.Set();



        }
        public void Step3()
        {

            //IRDReceiveStart_SendCmd3();
            //	System.Threading.Thread.Sleep(1000);
            //	IRDReceiveStart_SendCmd3();

            if (Data_Rcv3 == true)
            {
                Data_Rcv3 = false;


            }
            else
            {
                //  form1.Autotmf = true;
                FillDataToDB2(saveFDCnt3);
            }

            //     form1.Autotmf = true;
            //     FillDataToDB2(saveFDCnt3);

            if (pasing)
            {

                areStep2.WaitOne();


                //	areStep2.WaitOne();
                FillDataToDB2(saveFDCnt3);
            }

            else if (!pasing && P_delete_use == 1)
            {
                areStep2.WaitOne();
            }
            if (form1.pasing2 == false && form1.pasing1 == false && form1.pasing3 == false && form1.pasing4 == false)

                areStep3.Set();



        }
        public void Step4()
        {

            //System.Threading.Thread.Sleep(2000);
            //	IRDReceiveStart_SendCmd4();
            //	System.Threading.Thread.Sleep(1000);
            //	IRDReceiveStart_SendCmd4();


            if (Data_Rcv4 == true)
            {
                Data_Rcv4 = false;


            }
            else
            {
                //  form1.Autotmf = true;
                FillDataToDB3(saveFDCnt4);
            }

            //  form1.Autotmf = true;
            //   FillDataToDB3(saveFDCnt4);

            if (pasing && P_delete_use == 0)
            {

                areStep3.WaitOne();



                //	areStep3.WaitOne();
                FillDataToDB3(saveFDCnt4);
            }
            else if (pasing && P_delete_use == 1)
            {
                areStep3.WaitOne();

                //	areStep3.WaitOne();
                FillDataToDB3(saveFDCnt4);
                Tacho_Delete();
                System.Threading.Thread.Sleep(3000);
                IRDReceiveStart_SendCmd();
            }
            else if (!pasing && P_delete_use == 1)
            {
                areStep3.WaitOne();
                if (P_delete_use == 1)
                {


                    Tacho_Delete();
                    System.Threading.Thread.Sleep(3000);
                    IRDReceiveStart_SendCmd();
                }
            }

            if (form1.pasing2 == false && form1.pasing1 == false && form1.pasing3 == false && form1.pasing4 == false)
                areStep4.Set();



        }
        bool Snedcheck = false;
        public void IRDReceiveStart_SendCmd()
        {
            Snedcheck = true;
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X95;
            if (comboBoxPort.Items.Count > 2)
            {

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(Tacho_Rececive, 0, 2);
                }
                if (serialPort2.IsOpen)
                {
                    serialPort2.Write(Tacho_Rececive, 0, 2);
                }
                if (serialPort3.IsOpen)
                {
                    serialPort3.Write(Tacho_Rececive, 0, 2);
                }
                if (serialPort4.IsOpen)
                {
                    serialPort4.Write(Tacho_Rececive, 0, 2);
                }
            }


        }
        public void IRDReceiveStart_SendCmd1()
        {
            Snedcheck = true;
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X95;

            serialPort1.Write(Tacho_Rececive, 0, 2);


        }
        public void IRDReceiveStart_SendCmd2()
        {
            Snedcheck = true;
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X95;

            serialPort2.Write(Tacho_Rececive, 0, 2);


        }
        public void IRDReceiveStart_SendCmd3()
        {
            Snedcheck = true;
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X95;

            serialPort3.Write(Tacho_Rececive, 0, 2);


        }
        public void IRDReceiveStart_SendCmd4()
        {
            Snedcheck = true;
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X95;

            serialPort4.Write(Tacho_Rececive, 0, 2);


        }
        public void TachoDataRecieve_SendCmd()
        {
            byte[] Tacho_Rececive = new byte[2];

            Tacho_Rececive[0] = 0X39;
            Tacho_Rececive[1] = 0X93;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(Tacho_Rececive, 0, 2);
            }
            if (serialPort2.IsOpen)
            {
                serialPort2.Write(Tacho_Rececive, 0, 2);
            }
            if (serialPort3.IsOpen)
            {
                serialPort3.Write(Tacho_Rececive, 0, 2);
            }
            if (serialPort4.IsOpen)
            {
                serialPort4.Write(Tacho_Rececive, 0, 2);
            }
            //	serialPort1.Write(Tacho_Rececive, 0, 2);
            //	serialPort2.Write(Tacho_Rececive, 0, 2);
            //	serialPort3.Write(Tacho_Rececive, 0, 2);
            //	serialPort4.Write(Tacho_Rececive, 0, 2);


        }
        public void Tacho_Delete()
        {

            bool Delete_complate = false;
            DialogResult result = MessageBox.Show("판독기 데이터를 삭제 하시겠습니까?", "선택 삭제", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                byte[] Tacho_Rececive = new byte[2];

                Tacho_Rececive[0] = 0X39;
                Tacho_Rececive[1] = 0X94;

                serialPort1.Write(Tacho_Rececive, 0, 2);
                serialPort2.Write(Tacho_Rececive, 0, 2);
                serialPort3.Write(Tacho_Rececive, 0, 2);
                serialPort4.Write(Tacho_Rececive, 0, 2);
                Delete_complate = true;
            }
            //System.Threading.Thread.Sleep(2000);
            //	if (Delete_complate)
            //	IRDReceiveStart_SendCmd();
        }
        public void Parsing1()
        {
            FillDataToDB(saveFDCnt1);
        }
        public void Parsing2()
        {
            FillDataToDB1(saveFDCnt2);
        }
        public void Parsing3()
        {
            FillDataToDB2(saveFDCnt3);
        }
        public void Parsing4()
        {
            FillDataToDB3(saveFDCnt4);
        }

        private void TransperAndSaveFile()
        {
            // if (Data_Rcv == true)
            //   {
            //  Data_Rcv = false;]


            int saveFDCnt = 0;
            bool bResult = false;


            string dir = Directory.GetCurrentDirectory();       // sound 
            dir += "\\notify.wav";
            WPlaySound.PlaySound(dir);

            try
            {


                //  rcvCnt = rcvList.Count;

                if (rcvList.Count < 1)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("5.[" + DateTime.Now.ToString() + "] rcvList.Count < 1 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;


                }

                if (rcvList.Count < 10)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("8.[" + DateTime.Now.ToString() + "] rcvList.Count < 10 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;
                }

                byte[] rcvByte = new byte[rcvList.Count];



                if (rcvList[11] == 0x55 && rcvList[12] == 0x15 && rcvList[13] == 0xa5)
                {
                    for (int q = 0; q < 11; q++)
                    {
                        rcvList.RemoveAt(0);

                    }
                    // rcvCnt = rcvList.Count;
                    rcvByte = new byte[rcvList.Count];

                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("0.[" + DateTime.Now.ToString() + "] rcvList[11] == 0x55 && rcvList[12] == 0x15 && rcvList[13] == 0xa5 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    //   return;


                }
                else if (rcvList[0] != 0x55 && rcvList[1] != 0x15 && rcvList[2] != 0xa5)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("6.[" + DateTime.Now.ToString() + "] rcvList[0] != 0x55 && rcvList[1] != 0x15 && rcvList[2] != 0xa5:" + form1.TACHO2_path + "\\", "TMP");
                    }

                    return;
                }
                else if (rcvList[80] == 0x55 && rcvList[81] == 0x15 && rcvList[82] == 0xa5)
                {
                    for (int q = 0; q < 80; q++)
                    {
                        rcvList.RemoveAt(0);

                    }
                    rcvByte = new byte[rcvList.Count];

                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("11.[" + DateTime.Now.ToString() + "] rcvList[80] == 0x55 && rcvList[81] == 0x15 && rcvList[82] == 0xa5 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    //    MessageBox.Show("Data Error!!!!");
                }



                if (rcvList.Count == rcvByte.Length)
                {
                    rcvList.CopyTo(rcvByte);
                }
                else
                {
                    //rcvCnt = rcvList.Count;
                    rcvByte = new byte[rcvList.Count];
                    rcvList.CopyTo(rcvByte);

                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("4.[" + DateTime.Now.ToString() + "]  데이터 갯수 에러!!!");
                    }
                    //  return;
                }

                ///
                //Create a new subfolder under the current active folder
                string newPath = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMP");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath);

                string NowReceiveTime = String.Format("\\{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.",
                                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                //  string str = newPath + NowReceiveTime + "TMP";
                string str = newPath + NowReceiveTime + "TMP";
                FileStream fsTMP = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bwTMP = new BinaryWriter(fsTMP);

                bwTMP.Write(rcvByte);

                bwTMP.Close();
                fsTMP.Close();
                ///

                //Create a new subfolder under the current active folder
                newPath = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath);

                NowReceiveTMF1 = NowReceiveTime + "TMF";
                str = newPath + NowReceiveTMF1;
                FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                //bw.Write(rcvStr);
                byte checkSum = 0x00;
                int sofSave = 0, sof = 0, i = 0, j = 0;
                int sofCnt = 0;
                do
                {
                    try
                    {
                        sofSave = sof;

                        if (rcvList.Count < (sof + 12))    // SOF 길이 체크
                        {
                            break;
                        }

                        if (rcvList[sof + 0] == 0x55 && rcvList[sof + 1] == 0x15 && rcvList[sof + 2] == 0xA5)
                        {
                            sofCnt++;
                            int nDataNum = (int)((rcvList[sof + 5] << 16) | (rcvList[sof + 4] << 8) | rcvList[sof + 3]);

                            checkSum = 0x00;
                            for (i = 3; i < 10; i++)
                                checkSum += rcvList[sof + i];

                            if (checkSum != rcvList[sof + 10])
                            {
                                sof += 3;

                                continue;
                            }

                            int nowBlockCnt = (sof + (11 + 384 + nDataNum) + (((384 + nDataNum) - 1) / 512 + 1));
                            if (rcvList.Count < nowBlockCnt)
                            {
                                break;
                            }

                            checkSum = 0x00;
                            int cnt = 0, arrCnt = 0;
                            byte[] savByte = new byte[384 + nDataNum];
                            for (j = 0, cnt = sof + 11; cnt < nowBlockCnt; j++, cnt++)
                            {
                                if (cnt == (nowBlockCnt - 1))
                                {
                                    bw.Write(savByte);
                                    saveFDCnt++;
                                    sof = nowBlockCnt;
                                    break;
                                }

                                if ((j != 0) && ((j % 512) == 0))
                                {
                                    if (checkSum != rcvList[cnt])
                                    {
                                        sof = nowBlockCnt;
                                        break;
                                    }
                                    else
                                    {
                                        checkSum = 0x00;
                                        j = -1;
                                    }
                                }
                                else
                                {
                                    checkSum += rcvList[cnt];
                                    savByte[arrCnt++] = rcvList[cnt];
                                }
                            }
                        }
                        else
                        {
                            sof++;
                            //MessageBox.Show("타코 수신 에러");
                        }
                    }
                    catch (Exception ex)
                    {
                        sof++;

                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("1.[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                        }
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                } while (sofSave != sof);

                bw.Close();
                fs.Close();

                //     bResult = true;
            }
            catch (Exception ex)
            {
                string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("2.[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                }

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally
            {
                //if (saveFDCnt > 0)
                //  if (bResult)
                //   {

                if (form1.tmpopen == true)
                {
                    string path = form1.TACHO2_path + "\\TMF";

                    MessageBox.Show(path + NowReceiveTMF1 + " 변환이 완료 되었습니다.");
                }
                else
                {
                    Step_count++;

                    Serial1No = Step_count;
                    saveFDCnt1 = saveFDCnt;
                    Thread DataDB1 = new Thread(Step1);
                    DataDB1.Start();
                    //   Step1();



                    //FillDataToDB(saveFDCnt);
                }

                strInfoMsg = "데이터 처리 완료";
                AppendText(strInfoMsg);
                rcvList.Clear();



                try
                {
                    //serialPort1.Open();

                    if (serialPort1.IsOpen)
                    {
                        isTimerUse = true;
                        //label9.Text = "Data Receiving...";
                        strInfoMsg = "데이터 수신 대기중";
                        label6.Text = "IRD  수신대기중";
                        AppendText(strInfoMsg);

                        serialPort1.DiscardInBuffer();
                        serialPort1.DiscardOutBuffer();

                        string parity = "E", stopbits = "N";
                        switch (serialPort1.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort1.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //  label11.Text = serialPort1.PortName + " | " + serialPort1.BaudRate.ToString() + "," + serialPort1.DataBits + "," + parity + "," + stopbits;
                        label11.Text = serialPort1.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        AppendText(strInfoMsg);

                        label11.Text = serialPort1.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("3.[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                    }


                }


            }

            //    } // Data_Rcv


        }

        private void TransperAndSaveFile1()
        {

            int saveFDCnt = 0;
            bool bResult = false;

            string dir = Directory.GetCurrentDirectory();       // sound 
            dir += "\\notify.wav";
            WPlaySound.PlaySound(dir);

            try
            {


                rcvCnt1 = rcvList1.Count;

                if (rcvList1.Count < 1)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("5.[" + DateTime.Now.ToString() + "] rcvList1.Count 1 < 0 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;


                }
                if (rcvList1.Count < 10)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("8.[" + DateTime.Now.ToString() + "] rcvList1.Count < 10 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;
                }

                byte[] rcvByte = new byte[rcvList1.Count];

                if (rcvList1[11] == 0x55 && rcvList1[12] == 0x15 && rcvList1[13] == 0xa5)
                {
                    for (int q = 0; q < 11; q++)
                    {
                        rcvList1.RemoveAt(0);
                    }
                    rcvByte = new byte[rcvList.Count];
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("0.[" + DateTime.Now.ToString() + "] rcvList1[11] == 0x55 && rcvLis1t[12] == 0x15 && rcvList1[13] == 0xa5 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    //   return;
                }
                else if (rcvList1[0] != 0x55 && rcvList1[1] != 0x15 && rcvList1[2] != 0xa5)
                {
                    //        MessageBox.Show("test");
                    return;
                }



                if (rcvList1.Count == rcvByte.Length)
                {
                    rcvList1.CopyTo(rcvByte);
                }
                else
                {
                    rcvByte = new byte[rcvList1.Count];
                    rcvList1.CopyTo(rcvByte);

                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("4.[" + DateTime.Now.ToString() + "]  데이터 갯수 에러!!!");
                    }
                    // return;
                }

                //   rcvList1.CopyTo(rcvByte);
                ///
                //Create a new subfolder under the current active folder
                string newPath1 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMP_1");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath1);

                string NowReceiveTime = String.Format("\\{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.",
                                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                //  string str = newPath + NowReceiveTime + "TMP";
                string str = newPath1 + NowReceiveTime + "TMP";
                FileStream fsTMP = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bwTMP = new BinaryWriter(fsTMP);

                bwTMP.Write(rcvByte);

                bwTMP.Close();
                fsTMP.Close();
                ///
                //Create a new subfolder under the current active folder
                newPath1 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_1");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath1);

                NowReceiveTMF2 = NowReceiveTime + "TMF";
                str = newPath1 + NowReceiveTMF2;
                FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                //bw.Write(rcvStr);
                byte checkSum = 0x00;
                int sofSave = 0, sof = 0, i = 0, j = 0;
                int sofCnt = 0;
                do
                {
                    try
                    {
                        sofSave = sof;

                        if (rcvList1.Count < (sof + 12))    // SOF 길이 체크
                        {
                            break;
                        }

                        if (rcvByte[sof + 0] == 0x55 && rcvByte[sof + 1] == 0x15 && rcvByte[sof + 2] == 0xA5)
                        {
                            sofCnt++;
                            int nDataNum = (int)((rcvByte[sof + 5] << 16) | (rcvByte[sof + 4] << 8) | rcvByte[sof + 3]);

                            checkSum = 0x00;
                            for (i = 3; i < 10; i++)
                                checkSum += rcvByte[sof + i];

                            if (checkSum != rcvByte[sof + 10])
                            {
                                sof += 3;

                                continue;
                            }

                            int nowBlockCnt = (sof + (11 + 384 + nDataNum) + (((384 + nDataNum) - 1) / 512 + 1));
                            if (rcvList1.Count < nowBlockCnt)
                            {
                                break;
                            }

                            checkSum = 0x00;
                            int cnt = 0, arrCnt = 0;
                            byte[] savByte = new byte[384 + nDataNum];
                            for (j = 0, cnt = sof + 11; cnt < nowBlockCnt; j++, cnt++)
                            {
                                if (cnt == (nowBlockCnt - 1))
                                {
                                    bw.Write(savByte);
                                    saveFDCnt++;
                                    sof = nowBlockCnt;
                                    break;
                                }

                                if ((j != 0) && ((j % 512) == 0))
                                {
                                    if (checkSum != rcvByte[cnt])
                                    {
                                        sof = nowBlockCnt;
                                        break;
                                    }
                                    else
                                    {
                                        checkSum = 0x00;
                                        j = -1;
                                    }
                                }
                                else
                                {
                                    checkSum += rcvByte[cnt];
                                    savByte[arrCnt++] = rcvByte[cnt];
                                }
                            }
                        }
                        else
                        {
                            sof++;
                            //MessageBox.Show("타코 수신 에러");
                        }
                    }
                    catch (Exception ex)
                    {
                        sof++;
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                        }

                    }
                } while (sofSave != sof);

                bw.Close();
                fs.Close();

                //	bResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                }

            }
            finally
            {


                if (form1.tmpopen == true)
                {
                    string path = form1.TACHO2_path + "\\TMF_1";

                    MessageBox.Show(path + NowReceiveTMF2 + " 변환이 완료 되었습니다.");
                }
                else
                {
                    Step_count++;

                    Serial2No = Step_count;
                    saveFDCnt2 = saveFDCnt;
                    //FillDataToDB(saveFDCnt);

                    //	Step2();

                    Thread DataDB2 = new Thread(Step2);
                    DataDB2.Start();
                }

                strInfoMsg = "데이터 처리 완료";
                AppendText(strInfoMsg);
                label26.Text = "IRD  수신대기중";
                //	}
                //	else
                //	{
                //		strInfoMsg = "처리할 데이터가 없습니다";
                //		AppendText(strInfoMsg);
                //	}
                rcvList1.Clear();

                /*	if (serialPort2.IsOpen)
                    {
                        serialPort2.Close();
                        label7.Text = serialPort2.PortName + " | 닫혔음";

                        if (!serialPort2.IsOpen)
                        {

                            isTimerUse1 = false;
                            spTimer1.Enabled = false;
                            isStartTimer1 = false;
                            isFirstDataGet1 = false;
                            label1_Ani_1.Visible = false;
                            label2_Base.Visible = true;
                        }
                    }
                    serialPort2.PortName = comboBoxPort2.SelectedItem.ToString();
                    //	SP_PortName = "C0M3";
                    //serialPort2.PortName = "COM3";
                    //SP.BaudRate = SP_BaudRate;
                    //SP.DataBits = SP_DataBits;
                    //SP.Parity = SP_Parity;
                    //SP.StopBits = SP_StopBits;
                    //
                    serialPort2.BaudRate = (int)38400;
                    serialPort2.DataBits = (int)8;
                    serialPort2.Parity = Parity.None;
                    serialPort2.StopBits = StopBits.One;
                    //
                    serialPort2.ReadTimeout = (int)2000;
                    serialPort2.WriteTimeout = (int)2000;
                    serialPort2.ReadBufferSize = 0x10000;

                    string str = Application.StartupPath + NowReceiveTMF2;
                    if (File.Exists(str))
                    {
                        File.Delete(str);
                    }*/

                try
                {
                    //	serialPort2.Open();

                    if (serialPort2.IsOpen)
                    {
                        isTimerUse1 = true;


                        string parity = "E", stopbits = "N";
                        switch (serialPort2.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort2.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //	label7.Text = serialPort2.PortName + " | " + serialPort2.BaudRate.ToString() + "," + serialPort2.DataBits + "," + parity + "," + stopbits;
                        label7.Text = serialPort2.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label7.Text = serialPort2.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                    }


                }

            }

        }
        private void TransperAndSaveFile2()
        {

            int saveFDCnt = 0;
            bool bResult = false;

            string dir = Directory.GetCurrentDirectory();       // sound 
            dir += "\\notify.wav";
            WPlaySound.PlaySound(dir);

            try
            {


                rcvCnt2 = rcvList2.Count;

                if (rcvList2.Count < 1)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("5.[" + DateTime.Now.ToString() + "] rcvList2.Count 1 < 0 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;


                }
                if (rcvList2.Count < 10)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("8.[" + DateTime.Now.ToString() + "] rcvList2.Count < 10 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;
                }
                byte[] rcvByte = new byte[rcvList2.Count];



                if (rcvList2[11] == 0x55 && rcvList2[12] == 0x15 && rcvList2[13] == 0xa5)
                {
                    for (int q = 0; q < 11; q++)
                    {
                        rcvList2.RemoveAt(0);
                    }
                    rcvByte = new byte[rcvList2.Count];

                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("0.[" + DateTime.Now.ToString() + "] rcvList2[11] == 0x55 && rcvList2[12] == 0x15 && rcvList2[13] == 0xa5 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    //  return;
                }
                else if (rcvList2[0] != 0x55 && rcvList2[1] != 0x15 && rcvList2[2] != 0xa5)
                {
                    //        MessageBox.Show("test");
                    return;
                }


                if (rcvList2.Count == rcvByte.Length)
                {
                    rcvList2.CopyTo(rcvByte);
                }
                else
                {
                    rcvByte = new byte[rcvList2.Count];
                    rcvList2.CopyTo(rcvByte);

                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("4.[" + DateTime.Now.ToString() + "]  데이터 갯수 에러!!!");
                    }
                    // return;
                }

                //  rcvList2.CopyTo(rcvByte);
                ///
                //Create a new subfolder under the current active folder
                string newPath2 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMP_2");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath2);

                string NowReceiveTime = String.Format("\\{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.",
                                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                //  string str = newPath + NowReceiveTime + "TMP";
                string str = newPath2 + NowReceiveTime + "TMP";
                FileStream fsTMP = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bwTMP = new BinaryWriter(fsTMP);

                bwTMP.Write(rcvByte);

                bwTMP.Close();
                fsTMP.Close();
                ///
                //Create a new subfolder under the current active folder
                newPath2 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_2");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath2);

                NowReceiveTMF3 = NowReceiveTime + "TMF";
                str = newPath2 + NowReceiveTMF3;
                FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                //bw.Write(rcvStr);
                byte checkSum = 0x00;
                int sofSave = 0, sof = 0, i = 0, j = 0;
                int sofCnt = 0;
                do
                {
                    try
                    {
                        sofSave = sof;

                        if (rcvList2.Count < (sof + 12))    // SOF 길이 체크
                        {
                            break;
                        }

                        if (rcvByte[sof + 0] == 0x55 && rcvByte[sof + 1] == 0x15 && rcvByte[sof + 2] == 0xA5)
                        {
                            sofCnt++;
                            int nDataNum = (int)((rcvByte[sof + 5] << 16) | (rcvByte[sof + 4] << 8) | rcvByte[sof + 3]);

                            checkSum = 0x00;
                            for (i = 3; i < 10; i++)
                                checkSum += rcvByte[sof + i];

                            if (checkSum != rcvByte[sof + 10])
                            {
                                sof += 3;

                                continue;
                            }

                            int nowBlockCnt = (sof + (11 + 384 + nDataNum) + (((384 + nDataNum) - 1) / 512 + 1));
                            if (rcvList2.Count < nowBlockCnt)
                            {
                                break;
                            }

                            checkSum = 0x00;
                            int cnt = 0, arrCnt = 0;
                            byte[] savByte = new byte[384 + nDataNum];
                            for (j = 0, cnt = sof + 11; cnt < nowBlockCnt; j++, cnt++)
                            {
                                if (cnt == (nowBlockCnt - 1))
                                {
                                    bw.Write(savByte);
                                    saveFDCnt++;
                                    sof = nowBlockCnt;
                                    break;
                                }

                                if ((j != 0) && ((j % 512) == 0))
                                {
                                    if (checkSum != rcvByte[cnt])
                                    {
                                        sof = nowBlockCnt;
                                        break;
                                    }
                                    else
                                    {
                                        checkSum = 0x00;
                                        j = -1;
                                    }
                                }
                                else
                                {
                                    checkSum += rcvByte[cnt];
                                    savByte[arrCnt++] = rcvByte[cnt];
                                }
                            }
                        }
                        else
                        {
                            sof++;

                        }
                    }
                    catch (Exception ex)
                    {
                        sof++;
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                        }

                    }
                } while (sofSave != sof);

                bw.Close();
                fs.Close();

                //	bResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                }

            }
            finally
            {


                if (form1.tmpopen == true)
                {
                    string path = form1.TACHO2_path + "\\TMF_1";

                    MessageBox.Show(path + NowReceiveTMF3 + " 변환이 완료 되었습니다.");
                }
                else
                {
                    Step_count++;

                    Serial3No = Step_count;
                    saveFDCnt3 = saveFDCnt;
                    //FillDataToDB(saveFDCnt);
                    //Step3();

                    Thread DataDB3 = new Thread(Step3);
                    DataDB3.Start();
                }

                strInfoMsg = "데이터 처리 완료";
                label27.Text = "IRD  수신대기중";
                AppendText(strInfoMsg);
                //	}
                //	else
                //	{
                //		strInfoMsg = "처리할 데이터가 없습니다";
                //		AppendText(strInfoMsg);
                //	}
                rcvList2.Clear();
                /*if (serialPort3.IsOpen)
                {
                    serialPort3.Close();
                    label18.Text = serialPort3.PortName + " | 닫혔음";

                    if (!serialPort3.IsOpen)
                    {

                        isTimerUse2 = false;
                        spTimer2.Enabled = false;
                        isStartTimer2 = false;
                        isFirstDataGet2 = false;
                        label2_Ani_1.Visible = false;
                        label3_Base.Visible = true;
                    }
                }
                serialPort3.PortName = comboBoxPort3.SelectedItem.ToString();
                //	SP_PortName = "C0M3";
                //	serialPort3.PortName = "COM4";
                //SP.BaudRate = SP_BaudRate;
                //SP.DataBits = SP_DataBits;
                //SP.Parity = SP_Parity;
                //SP.StopBits = SP_StopBits;
                //
                serialPort3.BaudRate = (int)38400;
                serialPort3.DataBits = (int)8;
                serialPort3.Parity = Parity.None;
                serialPort3.StopBits = StopBits.One;
                //
                serialPort3.ReadTimeout = (int)2000;
                serialPort3.WriteTimeout = (int)2000;
                serialPort3.ReadBufferSize = 0x10000;

                string str = Application.StartupPath + NowReceiveTMF3;
                if (File.Exists(str))
                {
                    File.Delete(str);
                }*/

                try
                {
                    //	serialPort3.Open();

                    if (serialPort3.IsOpen)
                    {
                        isTimerUse2 = true;


                        string parity = "E", stopbits = "N";
                        switch (serialPort3.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort3.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //	label18.Text = serialPort3.PortName + " | " + serialPort3.BaudRate.ToString() + "," + serialPort3.DataBits + "," + parity + "," + stopbits;
                        label18.Text = serialPort3.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label18.Text = serialPort3.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                    }


                }

            }

        }
        private void TransperAndSaveFile3()
        {

            int saveFDCnt = 0;
            bool bResult = false;

            string dir = Directory.GetCurrentDirectory();       // sound 
            dir += "\\notify.wav";
            WPlaySound.PlaySound(dir);

            try
            {


                rcvCnt3 = rcvList3.Count;


                if (rcvList3.Count < 1)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("5.[" + DateTime.Now.ToString() + "] rcvList1.Count 3 < 0 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;


                }
                if (rcvList3.Count < 10)
                {
                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("8.[" + DateTime.Now.ToString() + "] rcvList3.Count < 10 :" + form1.TACHO2_path + "\\", "TMP");
                    }
                    return;
                }
                byte[] rcvByte = new byte[rcvList3.Count];

                if (rcvList3[11] == 0x55 && rcvList3[12] == 0x15 && rcvList3[13] == 0xa5)
                {
                    for (int q = 0; q < 11; q++)
                    {
                        rcvList3.RemoveAt(0);
                    }
                    rcvByte = new byte[rcvList3.Count];

                    string path = Application.StartupPath + "\\ErrorLog.jie";

                    //MessageBox.Show("Data Error!!!!");
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("0.[" + DateTime.Now.ToString() + "] rcvList3[11] == 0x55 && rcvList3[12] == 0x15 && rcvList3[13] == 0xa5 :" + form1.TACHO2_path + "\\", "TMP");
                    }

                }
                else if (rcvList3[0] != 0x55 && rcvList3[1] != 0x15 && rcvList3[2] != 0xa5)
                {
                    //        MessageBox.Show("test");
                    return;
                }



                if (rcvList3.Count == rcvByte.Length)
                {
                    rcvList3.CopyTo(rcvByte);
                }
                else
                {

                    rcvByte = new byte[rcvList3.Count];
                    rcvList3.CopyTo(rcvByte);

                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("4.[" + DateTime.Now.ToString() + "]  데이터 갯수 에러!!!");
                    }
                    return;
                }

                //     rcvList3.CopyTo(rcvByte);
                ///
                //Create a new subfolder under the current active folder
                string newPath3 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMP_3");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath3);

                string NowReceiveTime = String.Format("\\{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.",
                                                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                //  string str = newPath + NowReceiveTime + "TMP";
                string str = newPath3 + NowReceiveTime + "TMP";
                FileStream fsTMP = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bwTMP = new BinaryWriter(fsTMP);

                bwTMP.Write(rcvByte);

                bwTMP.Close();
                fsTMP.Close();
                ///
                //Create a new subfolder under the current active folder
                newPath3 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_3");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath3);

                NowReceiveTMF4 = NowReceiveTime + "TMF";
                str = newPath3 + NowReceiveTMF4;
                FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                //bw.Write(rcvStr);
                byte checkSum = 0x00;
                int sofSave = 0, sof = 0, i = 0, j = 0;
                int sofCnt = 0;
                do
                {
                    try
                    {
                        sofSave = sof;

                        if (rcvList3.Count < (sof + 12))    // SOF 길이 체크
                        {
                            break;
                        }

                        if (rcvByte[sof + 0] == 0x55 && rcvByte[sof + 1] == 0x15 && rcvByte[sof + 2] == 0xA5)
                        {
                            sofCnt++;
                            int nDataNum = (int)((rcvByte[sof + 5] << 16) | (rcvByte[sof + 4] << 8) | rcvByte[sof + 3]);

                            checkSum = 0x00;
                            for (i = 3; i < 10; i++)
                                checkSum += rcvByte[sof + i];

                            if (checkSum != rcvByte[sof + 10])
                            {
                                sof += 3;

                                continue;
                            }

                            int nowBlockCnt = (sof + (11 + 384 + nDataNum) + (((384 + nDataNum) - 1) / 512 + 1));
                            if (rcvList3.Count < nowBlockCnt)
                            {
                                break;
                            }

                            checkSum = 0x00;
                            int cnt = 0, arrCnt = 0;
                            byte[] savByte = new byte[384 + nDataNum];
                            for (j = 0, cnt = sof + 11; cnt < nowBlockCnt; j++, cnt++)
                            {
                                if (cnt == (nowBlockCnt - 1))
                                {
                                    bw.Write(savByte);
                                    saveFDCnt++;
                                    sof = nowBlockCnt;
                                    break;
                                }

                                if ((j != 0) && ((j % 512) == 0))
                                {
                                    if (checkSum != rcvByte[cnt])
                                    {
                                        sof = nowBlockCnt;
                                        break;
                                    }
                                    else
                                    {
                                        checkSum = 0x00;
                                        j = -1;
                                    }
                                }
                                else
                                {
                                    checkSum += rcvByte[cnt];
                                    savByte[arrCnt++] = rcvByte[cnt];
                                }
                            }
                        }
                        else
                        {
                            sof++;
                            //MessageBox.Show("타코 수신 에러");
                        }
                    }
                    catch (Exception ex)
                    {
                        sof++;
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                        }

                    }
                } while (sofSave != sof);

                bw.Close();
                fs.Close();

                //	bResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                }

            }
            finally
            {


                if (form1.tmpopen == true)
                {
                    string path = form1.TACHO2_path + "\\TMF_3";

                    MessageBox.Show(path + NowReceiveTMF3 + " 변환이 완료 되었습니다.");
                }
                else
                {
                    Step_count++;

                    Serial4No = Step_count;
                    saveFDCnt4 = saveFDCnt;
                    //FillDataToDB(saveFDCnt);
                    //	Step4();

                    Thread DataDB4 = new Thread(Step4);
                    DataDB4.Start();
                }

                strInfoMsg = "데이터 처리 완료";
                label28.Text = "IRD  수신대기중";
                AppendText(strInfoMsg);
                //	}
                //	else
                //	{
                //		strInfoMsg = "처리할 데이터가 없습니다";
                //		AppendText(strInfoMsg);
                //	}
                rcvList3.Clear();
                /*
                if (serialPort4.IsOpen)
                {
                    serialPort4.Close();
                    label23.Text = serialPort4.PortName + " | 닫혔음";

                    if (!serialPort4.IsOpen)
                    {

                        isTimerUse3 = false;
                        spTimer3.Enabled = false;
                        isStartTimer3 = false;
                        isFirstDataGet3 = false;
                        label3_Ani_1.Visible = false;
                        label4_Base.Visible = true;
                    }
                }
                serialPort4.PortName = comboBoxPort4.SelectedItem.ToString();
                //	SP_PortName = "C0M3";
                //	serialPort4.PortName = "COM5";
                //SP.BaudRate = SP_BaudRate;
                //SP.DataBits = SP_DataBits;
                //SP.Parity = SP_Parity;
                //SP.StopBits = SP_StopBits;
                //
                serialPort4.BaudRate = (int)38400;
                serialPort4.DataBits = (int)8;
                serialPort4.Parity = Parity.None;
                serialPort4.StopBits = StopBits.One;
                //
                serialPort4.ReadTimeout = (int)2000;
                serialPort4.WriteTimeout = (int)2000;
                serialPort4.ReadBufferSize = 0x10000;

                string str = Application.StartupPath + NowReceiveTMF3;
                if (File.Exists(str))
                {
                    File.Delete(str);
                }*/

                try
                {
                    //	serialPort4.Open();

                    if (serialPort4.IsOpen)
                    {
                        isTimerUse3 = true;


                        string parity = "E", stopbits = "N";
                        switch (serialPort4.Parity)
                        {
                            case Parity.Even: parity = "E"; break;
                            case Parity.Mark: parity = "M"; break;
                            case Parity.None: parity = "N"; break;
                            case Parity.Odd: parity = "O"; break;
                            case Parity.Space: parity = "S"; break;
                        }
                        switch (serialPort4.StopBits)
                        {
                            case StopBits.None: stopbits = "0"; break;
                            case StopBits.One: stopbits = "1"; break;
                            case StopBits.OnePointFive: stopbits = "1.5"; break;
                            case StopBits.Two: stopbits = "2"; break;
                        }
                        //	label23.Text = serialPort4.PortName + " | " + serialPort4.BaudRate.ToString() + "," + serialPort4.DataBits + "," + parity + "," + stopbits;
                        label23.Text = serialPort4.PortName + " | Open";
                    }
                    else
                    {
                        //label9.Text = "";
                        strInfoMsg = "";
                        //	AppendText(strInfoMsg);

                        label23.Text = serialPort4.PortName + " | 열기 실패";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string path = Application.StartupPath + "\\ErrorLog.jie";
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.StackTrace);
                    }


                }

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                label11.Text = serialPort1.PortName + " | 닫혔음";

                if (!serialPort1.IsOpen)
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    AppendText(strInfoMsg);

                    isTimerUse = false;
                    spTimer.Enabled = false;
                    isStartTimer = false;
                    isFirstDataGet = false;
                    label1_Ani_0.Visible = false;
                    label1_Base.Visible = true;
                }
            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
                label7.Text = serialPort2.PortName + " | 닫혔음";

                if (!serialPort2.IsOpen)
                {
                    //label9.Text = "";
                    //	strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    isTimerUse1 = false;
                    spTimer1.Enabled = false;
                    isStartTimer1 = false;
                    isFirstDataGet1 = false;
                    label1_Ani_1.Visible = false;
                    label2_Base.Visible = true;
                }
            }
        }
        private void FormTachoReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* this.Visible = false;

             if (m_bStart)
                 e.Cancel = true;
             else
                 e.Cancel = false;*/
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
            if (serialPort3.IsOpen)
            {
                serialPort3.Close();
            }
            if (serialPort4.IsOpen)
            {
                serialPort4.Close();
            }
        }

        /*  ThreadStart ts1;
          ThreadStart ts2;
          ThreadStart ts3;
          ThreadStart ts4;

          Thread thread1;
          Thread thread2; 
          Thread thread3;
          Thread thread4; */

        private void FillDataToDB(int nTotalFDCount)
        {

            form1.pasing1 = true;
            bool bOpenFileData = true;
            int IndexNumber = 1;
            DateTime standardTime = new DateTime(1, 1, 1, 0, 0, 0);

            long oldFdPosition = 0, newFdPosition = 0;
            int bReadData = 0;

            byte[][] bArrEmergencyData = new byte[16][];
            string newPath = "";
            //Create a new subfolder under the current active folder

            newPath = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);

            string strFilePath1 = newPath + NowReceiveTMF1;
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }



            if (form1.TAcho_tong == true)
            {


                if (form1.AutoDisplay == true)
                {

                    //      form1.tmf_data(strFilePath1);
                    form1.Tacho_Run(strFilePath1);

                    newPath = System.IO.Path.Combine(form1.TACHO2_path + "\\TMF", "Auto");
                    // Create the subfolder
                    System.IO.Directory.CreateDirectory(newPath);
                    System.IO.Directory.Move(strFilePath1, newPath + NowReceiveTMF1);


                    /*   form1.isThread1 = true;
                       form1.ts1 = new ThreadStart(form1.LoadingWork);
                       form1.thread1 = new Thread(form1.ts1);
                        form1.Data_path1 = strFilePath1;
                        form1.thread1.Start();*/

                    //   form1.Tacho_Run(strFilePath1);

                    /*   if (listView1.Items.Count != 0)
                       {
                           for (int i = 0; i < listView1.Items.Count; i++)
                           {
                               if (listView1.Items.Count - 1 != i)
                               {
                                   listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                               }
                           }

                           listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                       }*/

                }
                else
                {
                    //    form1.tmf_data(strFilePath1);
                    //   form1.Tacho_Run(strFilePath1);
                }
                form1.TAcho_tong = false;

            }
            else if (form1.Tacho_dailly == true)
            {
                //	form1.Dayilly_tmf_data(strFilePath1);
                form1.TongYoung_tmf_data(strFilePath1);
                form1.Tacho_dailly = false;
            }
            else if (form1.Tacho_2dailly == true)
            {
                form1.Dayilly2_tmf_data(strFilePath1);
                form1.Tacho_2dailly = false;
            }
            else if (form1.Tacho_auto == true)
            {
                form1.Atuo_tmf_data(strFilePath1);
                form1.Tacho_auto = false;
            }

            //  FillDataListView();

        }
        private void FillDataToDB1(int nTotalFDCount)
        {
            form1.pasing2 = true;
            bool bOpenFileData = true;
            int IndexNumber = 1;
            DateTime standardTime = new DateTime(1, 1, 1, 0, 0, 0);

            long oldFdPosition = 0, newFdPosition = 0;
            int bReadData = 0;

            byte[][] bArrEmergencyData = new byte[16][];
            string newPath1 = "";
            //Create a new subfolder under the current active folder

            newPath1 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_1");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath1);

            string strFilePath2 = newPath1 + NowReceiveTMF2;
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }

            if (form1.TAcho_tong == true)
            {


                //  form1.tmf_data(strFilePath2);
                //  form1.Tacho_Run(strFilePath2);


                form1.Tacho_Run(strFilePath2);




                newPath1 = System.IO.Path.Combine(form1.TACHO2_path + "\\TMF_1", "Auto");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath1);
                System.IO.Directory.Move(strFilePath2, newPath1 + NowReceiveTMF2);


                /*    form1.isThread2 = true;
                    form1.ts2 = new ThreadStart(form1.LoadingWork);
                    form1.thread2 = new Thread(form1.ts2);
                    form1.Data_path2 = strFilePath2;
                    form1.thread2.Start();*/



                form1.TAcho_tong = false;

                /*   if (listView1.Items.Count != 0)
                   {
                       for (int i = 0; i < listView1.Items.Count; i++)
                       {
                           if (listView1.Items.Count - 1 != i)
                           {
                               listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                           }
                       }

                       listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                   }*/
            }
            else if (form1.Tacho_dailly == true)
            {
                form1.TongYoung_tmf_data(strFilePath2);
                form1.Tacho_dailly = false;
            }
            else if (form1.Tacho_2dailly == true)
            {
                form1.Dayilly2_tmf_data(strFilePath2);
                form1.Tacho_2dailly = false;
            }
            else if (form1.Tacho_auto == true)
            {
                form1.Atuo_tmf_data(strFilePath2);
                form1.Tacho_auto = false;
            }

            //  FillDataListView();

        }
        private void FillDataToDB2(int nTotalFDCount)
        {
            form1.pasing3 = true;
            bool bOpenFileData = true;
            int IndexNumber = 1;
            DateTime standardTime = new DateTime(1, 1, 1, 0, 0, 0);

            long oldFdPosition = 0, newFdPosition = 0;
            int bReadData = 0;

            byte[][] bArrEmergencyData = new byte[16][];
            string newPath2 = "";
            //Create a new subfolder under the current active folder

            newPath2 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_2");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath2);

            string strFilePath3 = newPath2 + NowReceiveTMF3;
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }


            if (form1.TAcho_tong == true)
            {


                // form1.tmf_data(strFilePath3);
                //  form1.Tacho_Run(strFilePath3);

                form1.Tacho_Run(strFilePath3);


                newPath2 = System.IO.Path.Combine(form1.TACHO2_path + "\\TMF_2", "Auto");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath2);
                System.IO.Directory.Move(strFilePath3, newPath2 + NowReceiveTMF3);

                /*  form1.isThread3 = true;
                  form1.ts3 = new ThreadStart(form1.LoadingWork);
                  form1.thread3 = new Thread(form1.ts3);
                  form1.Data_path3 = strFilePath3;
                  form1.thread3.Start();*/

                form1.TAcho_tong = false;
                /*  if (listView1.Items.Count != 0)
                  {
                      for (int i = 0; i < listView1.Items.Count; i++)
                      {
                          if (listView1.Items.Count - 1 != i)
                          {
                              listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                          }
                      }

                      listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                  }*/
            }
            else if (form1.Tacho_dailly == true)
            {
                form1.TongYoung_tmf_data(strFilePath3);
                form1.Tacho_dailly = false;
            }
            else if (form1.Tacho_2dailly == true)
            {
                form1.Dayilly2_tmf_data(strFilePath3);
                form1.Tacho_2dailly = false;
            }
            else if (form1.Tacho_auto == true)
            {
                form1.Atuo_tmf_data(strFilePath3);
                form1.Tacho_auto = false;
            }

            //  FillDataListView();

        }
        private void FillDataToDB3(int nTotalFDCount)
        {
            form1.pasing4 = true;
            bool bOpenFileData = true;
            int IndexNumber = 1;
            DateTime standardTime = new DateTime(1, 1, 1, 0, 0, 0);

            long oldFdPosition = 0, newFdPosition = 0;
            int bReadData = 0;

            byte[][] bArrEmergencyData = new byte[16][];
            string newPath3 = "";
            //Create a new subfolder under the current active folder

            newPath3 = System.IO.Path.Combine(form1.TACHO2_path + "\\", "TMF_3");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath3);

            string strFilePath4 = newPath3 + NowReceiveTMF4;
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }



            if (form1.TAcho_tong == true)
            {


                // form1.tmf_data(strFilePath4);
                //  form1.Tacho_Run(strFilePath4);

                form1.Tacho_Run(strFilePath4);

                newPath3 = System.IO.Path.Combine(form1.TACHO2_path + "\\TMF_3", "Auto");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath3);
                System.IO.Directory.Move(strFilePath4, newPath3 + NowReceiveTMF4);

                /*form1.isThread4 = true;
                form1.ts4 = new ThreadStart(form1.LoadingWork);
                form1.thread4 = new Thread(form1.ts4);
                form1.Data_path4 = strFilePath4;
                form1.thread4.Start();*/

                form1.TAcho_tong = false;
                /*  if (listView1.Items.Count != 0)
                  {
                      for (int i = 0; i < listView1.Items.Count; i++)
                      {
                          if (listView1.Items.Count - 1 != i)
                          {
                              listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                          }
                      }

                      listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                  }*/
            }
            else if (form1.Tacho_dailly == true)
            {
                form1.TongYoung_tmf_data(strFilePath4);
                form1.Tacho_dailly = false;
            }
            else if (form1.Tacho_2dailly == true)
            {
                form1.Dayilly2_tmf_data(strFilePath4);
                form1.Tacho_2dailly = false;
            }
            else if (form1.Tacho_auto == true)
            {
                form1.Atuo_tmf_data(strFilePath4);
                form1.Tacho_auto = false;
            }

            //  FillDataListView();

        }
        private byte DecimalToBCD(int n)
        {
            n = n % 100;

            return (byte)(((n / 10) << 4) + (n % 10));
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            isTimerUse = true;
            spTimer.Enabled = true;
            isStartTimer = true;
            isFirstDataGet = true;
        }



        private void buttonOldFileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.TMP)|*.tmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                rcvList.Clear();

                strInfoMsg = "데이터 처리중";
                AppendText(strInfoMsg);

                while (fs.Position < fs.Length)
                {
                    rcvList.Add(br.ReadByte());
                }
                form1.tmpopen = true;
                TransperAndSaveFile();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //	NowReceiveTMF = "\\2010115_155329.TMF";
            //	FillDataToDB(100);
        }

        private void AMtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (form1.textboxdig == true)
            {
                if (e.KeyChar > 0x31)
                {


                    form1.textboxdig = false;
                    e.Handled = true;
                }
            }


            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                char cKey = e.KeyChar;
                cKey = char.ToUpper(cKey);
                e.Handled = true;
            }
            else if (e.KeyChar == 0x31)
            {
                form1.textboxdig = true;
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void PMtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                char cKey = e.KeyChar;
                cKey = char.ToUpper(cKey);
                e.Handled = true;
            }
            else
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            //if (serialPort2.IsOpen)
            //	return;

            rcvList1.Clear();
            if (!serialPort2.IsOpen)
            {
                serialPort2.PortName = comboBoxPort2.SelectedItem.ToString();


                serialPort2.BaudRate = (int)38400;
                serialPort2.DataBits = (int)8;
                serialPort2.Parity = Parity.None;
                serialPort2.StopBits = StopBits.One;
                //
                serialPort2.ReadTimeout = (int)2000;
                serialPort2.WriteTimeout = (int)2000;
                serialPort2.ReadBufferSize = 0x10000;
            }

            string str = Application.StartupPath + NowReceiveTMF2;
            if (File.Exists(str))
            {
                File.Delete(str);
            }

            try
            {
                if (!serialPort2.IsOpen)
                {
                    serialPort2.Open();
                }

                if (serialPort2.IsOpen)
                {
                    isTimerUse1 = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    //	AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (serialPort2.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (serialPort2.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    //	label7.Text = serialPort2.PortName + " | " + serialPort2.BaudRate.ToString() + "," + serialPort2.DataBits + "," + parity + "," + stopbits;
                    label7.Text = serialPort2.PortName + " | Open";
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    label7.Text = serialPort2.PortName + " | 열기 실패";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            //if (serialPort2.IsOpen)
            //	return;

            rcvList2.Clear();
            if (!serialPort3.IsOpen)
            {
                serialPort3.PortName = comboBoxPort3.SelectedItem.ToString();

                serialPort3.BaudRate = (int)38400;
                serialPort3.DataBits = (int)8;
                serialPort3.Parity = Parity.None;
                serialPort3.StopBits = StopBits.One;
                //
                serialPort3.ReadTimeout = (int)2000;
                serialPort3.WriteTimeout = (int)2000;
                serialPort3.ReadBufferSize = 0x10000;
            }

            string str = Application.StartupPath + NowReceiveTMF3;
            if (File.Exists(str))
            {
                File.Delete(str);
            }

            try
            {
                if (!serialPort3.IsOpen)
                {
                    serialPort3.Open();
                }

                if (serialPort3.IsOpen)
                {
                    isTimerUse2 = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    //	AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (serialPort3.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (serialPort3.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    //label18.Text = serialPort3.PortName + " | " + serialPort3.BaudRate.ToString() + "," + serialPort3.DataBits + "," + parity + "," + stopbits;
                    label18.Text = serialPort3.PortName + " | Open";
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    label18.Text = serialPort3.PortName + " | 열기 실패";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton_일별자르기.Checked)
            {
                form1.Tacho_dailly = true;
            }
            else if (radioButton_타코.Checked)
            {
                form1.TAcho_tong = true;
            }
            else if (radioButton_교대시간.Checked)
            {
                /*if (!radioButton_입고시간.Checked && !radioButton_출고시간.Checked)	
                {
                    MessageBox.Show("분리시간 기분을 선택 하여 주세요!");
                }*/
                //		if
                //		{
                if (AMtextBox.Text == "" || PMtextBox.Text == "")
                {
                    MessageBox.Show("교대시간을 입력하여 주세요!");
                }
                else
                {
                    form1.AMText = AMtextBox.Text;
                    form1.PMText = PMtextBox.Text;
                    form1.Tacho_2dailly = true;
                }

                //		}

            }
            else if (radioButton_타코자동분리.Checked)
            {
                form1.Tacho_auto = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            //if (serialPort2.IsOpen)
            //	return;

            rcvList3.Clear();
            if (!serialPort4.IsOpen)
            {
                serialPort4.PortName = comboBoxPort4.SelectedItem.ToString();

                serialPort4.BaudRate = (int)38400;
                serialPort4.DataBits = (int)8;
                serialPort4.Parity = Parity.None;
                serialPort4.StopBits = StopBits.One;
                //
                serialPort4.ReadTimeout = (int)2000;
                serialPort4.WriteTimeout = (int)2000;
                serialPort4.ReadBufferSize = 0x10000;
            }

            string str = Application.StartupPath + NowReceiveTMF4;
            if (File.Exists(str))
            {
                File.Delete(str);
            }

            try
            {
                if (!serialPort4.IsOpen)
                {
                    serialPort4.Open();
                }

                if (serialPort4.IsOpen)
                {
                    isTimerUse3 = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    //	AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (serialPort4.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (serialPort4.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    //	label23.Text = serialPort4.PortName + " | " + serialPort4.BaudRate.ToString() + "," + serialPort4.DataBits + "," + parity + "," + stopbits;
                    label23.Text = serialPort4.PortName + " | Open";
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    label23.Text = serialPort4.PortName + " | 열기 실패";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (serialPort4.IsOpen)
            {
                serialPort4.Close();
                label23.Text = serialPort4.PortName + " | 닫혔음";

                if (!serialPort4.IsOpen)
                {
                    //label9.Text = "";
                    //	strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    isTimerUse3 = false;
                    spTimer3.Enabled = false;
                    isStartTimer3 = false;
                    isFirstDataGet3 = false;
                    label3_Ani_1.Visible = false;
                    label4_Base.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort3.IsOpen)
            {
                serialPort3.Close();
                label18.Text = serialPort3.PortName + " | 닫혔음";

                if (!serialPort3.IsOpen)
                {
                    //label9.Text = "";
                    //	strInfoMsg = "";
                    //	AppendText(strInfoMsg);

                    isTimerUse2 = false;
                    spTimer2.Enabled = false;
                    isStartTimer2 = false;
                    isFirstDataGet2 = false;
                    label2_Ani_1.Visible = false;
                    label3_Base.Visible = true;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Data_Rcv1 = true;
            Data_Rcv2 = true;
            Data_Rcv3 = true;
            Data_Rcv4 = true;
            TachoDataRecieve_SendCmd();


        }

        private void button6_Click(object sender, EventArgs e)
        {



            IRDReceiveStart_SendCmd();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Tacho_Delete();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("데이터를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                listView1.Items.Clear();
                form1.recvTotal_Dist = 0;
                form1.reevTotal_SalesDist = 0;
                form1.recvTotal_Money = 0;
                form1.recvTotal_Money = 0;

            }
        }










    }
}