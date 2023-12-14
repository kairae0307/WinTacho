using System;
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
    public partial class FormTachoReceive1 : Form
    {
       
        private iniClass inicls = new iniClass();
		Form1 form1;
        public Boolean m_bStart;
        private Boolean isStartTimer = false;
        private Boolean isTimerUse = false;
        private Boolean isFirstDataGet = false;
        SerialPort SP = new SerialPort();
        private List<byte> rcvList = new List<byte>();
        private int rcvCnt = 0;

        public string TACHO2_path = "";

        public int saveFDCnt1 = 0;
        private int nLastTblTachoID = 0;

        System.Timers.Timer spTimer;

        public string SP_PortName = "COM1";
        public int SP_BaudRate = 38400;
        public int SP_DataBits = 8;
        public Parity SP_Parity = Parity.None;
        public StopBits SP_StopBits = StopBits.One;
		public bool opendlg = false;

        public string NowReceiveTMF = "\\NowReceive.TMF";

        private decimal totalMoney = 0;

        delegate void textCallbak(String txt);
        private string strInfoMsg = "";
        private int nNowFDCount = 0;

        private int rcvSPCnt = 0;
        int tstN = 0;

       

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

        void SP_DataRecieved(Object sender, SerialDataReceivedEventArgs e)
        {
            if (SP.IsOpen)
            {
                
                if (SP.BytesToRead > 0)
                {
                    isStartTimer = true;
                    spTimer.Enabled = false;
                    tstN = 0;

                    byte[] bt = new byte[SP.BytesToRead];
                    SP.Read(bt, 0, bt.Length);
                    rcvList.AddRange(bt);
                }

                //while (SP.BytesToRead > 0)
                //{
                //    //rcvList.Add((byte)SP.ReadByte());
                //    tstN = 0;
                //    //if (!isStartTimer)
                //    //    isStartTimer = true;
                //}
                spTimer.Enabled = true;
                isFirstDataGet = true;
                //isStartTimer = false;
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
                    TransperAndSaveFile();
                    label1_Ani_0.Visible = false;
                    label1_Base.Visible = true;
                }
                else if (isFirstDataGet)
                {
                    label1_Base.Visible = false;
                    label1_Ani_0.Visible = true;

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

        public FormTachoReceive1(Form1 f)
        {
            InitializeComponent();
            m_bStart = true;
            spTimer = new System.Timers.Timer();
            spTimer.Interval = 5000;
    
      //      groupBox2.Enabled = false;

            ImageList dummyImageList = new ImageList();
            dummyImageList.ImageSize = new System.Drawing.Size(1, 18);
            listView1.SmallImageList = dummyImageList;
        
			form1 = f;

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트

            spTimer.Enabled = false;
            SP.DataReceived += new SerialDataReceivedEventHandler(SP_DataRecieved);

            radioButton수집기.Checked = true;

           
			if (form1.radioButton_타코.Checked == true) 
			{
				radioButton_타코.Checked = true;
			}
			else if(form1.radioButton_1day.Checked==true)
			{
				radioButton_일별자르기.Checked = true;
			}
			else if(form1.radioButton_2day.Checked==true)
			{
				radioButton_교대시간.Checked = true;
				AMtextBox.Text =form1.AMtextBox.Text;
				PMtextBox.Text = form1.PMtextBox.Text;
			}
			else if (form1.radioButton_auto.Checked == true)
			{

				radioButton_타코자동분리.Checked = true;
			}

            if (form1.UserTime ==false && (form1.SungSil == 1 && form1.AutoDisplay ==true))
            {
                radioButton_타코.Checked = true;
                this.ControlBox = false;
                groupBox2.Enabled = false;
                panel1.Enabled = false;



            }
            else
            {
                if (form1.AutoDisplay != true)
                {
                    this.Width = 300;
                    listView1.Visible = false;
                }
            }

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
          
            DetectLastID();

            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 100;
            progressBar1.Value = 1;
            progressBar1.Step = 1;

            string path = Application.StartupPath + "\\WinTacho.ini";

            string RValue = "";
            RValue = inicls.GetIniValue("Serial Setting", "SP", path);
            SP.PortName = RValue;
            SP_PortName = RValue;

            RValue = inicls.GetIniValue("Serial Setting", "BS", path);
            SP.BaudRate = Convert.ToInt32(RValue);

         

 
            //label9.Text = "";
            strInfoMsg = "";
			AMtextBox.Text =f.AMtextBox.Text;
			PMtextBox.Text = f.PMtextBox.Text;
            AppendText(strInfoMsg);

            label11.Text = SP.PortName + " | Closed";

            //DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day

            if (form1.UserTime == true)
            {
                radioButton_UserTime.Checked = true;
                radioButton_타코.Enabled = false;
                radioButton_교대시간.Enabled = false;
                radioButton_일별자르기.Enabled = false;
                radioButton_타코자동분리.Enabled = false;

                AMtextBox.Enabled = false;
                PMtextBox.Enabled = false;
            }
            else
            {
                radioButton_UserTime.Enabled = false;
                radioButton_OneDay.Enabled = false;
                radioButton_AM.Enabled = false;
                radioButton_PM.Enabled = false;
                numericUpDown_Year.Enabled = false;
                numericUpDown_Month.Enabled = false;
                numericUpDown_Day.Enabled = false;
            }

                 radioButton_OneDay.Checked = true;
                numericUpDown_Year.Value = DateTime.Now.Year;
                numericUpDown_Month.Value = DateTime.Now.Month;
                numericUpDown_Day.Value = DateTime.Now.Day;


                if (form1.UserTime == false)
                {
                    panel1.Enabled = false;
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
            FormCommunicationSetting formCommunicationSetting = new FormCommunicationSetting(this);
            formCommunicationSetting.StartPosition = FormStartPosition.CenterParent;
            formCommunicationSetting.ShowDialog();
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
                else if (radioButton_UserTime.Checked)
                {
                    form1.TAcho_tong = true;
                }
                else
                {
                    MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                    return;
                }
           


            if (SP.IsOpen)
                return;

            rcvList.Clear();

            SP.PortName = SP_PortName;
            //SP.BaudRate = SP_BaudRate;
            //SP.DataBits = SP_DataBits;
            //SP.Parity = SP_Parity;
            //SP.StopBits = SP_StopBits;
//
            SP.BaudRate = (int)38400;
            SP.DataBits = (int)8;
            SP.Parity = Parity.None;
            SP.StopBits = StopBits.One;
//
            SP.ReadTimeout = (int)2000;
            SP.WriteTimeout = (int)2000;
            SP.ReadBufferSize = 0x10000;

          

            string str = Application.StartupPath + NowReceiveTMF;
            if (File.Exists(str))
            {
                File.Delete(str);
            }

            try
            {
                SP.Open();

                if (SP.IsOpen)
                {
                    isTimerUse = true;
                    //label9.Text = "Data Receiving...";
                    strInfoMsg = "데이터 수신 대기중";
                    AppendText(strInfoMsg);

                    string parity = "E", stopbits = "N";
                    switch (SP.Parity)
                    {
                        case Parity.Even: parity = "E"; break;
                        case Parity.Mark: parity = "M"; break;
                        case Parity.None: parity = "N"; break;
                        case Parity.Odd: parity = "O"; break;
                        case Parity.Space: parity = "S"; break;
                    }
                    switch (SP.StopBits)
                    {
                        case StopBits.None: stopbits = "0"; break;
                        case StopBits.One: stopbits = "1"; break;
                        case StopBits.OnePointFive: stopbits = "1.5"; break;
                        case StopBits.Two: stopbits = "2"; break;
                    }
                    label11.Text = SP.PortName + " | " + SP.BaudRate.ToString() + "," + SP.DataBits + "," + parity + "," + stopbits;
                }
                else
                {
                    //label9.Text = "";
                    strInfoMsg = "";
                    AppendText(strInfoMsg);

                    label11.Text = SP.PortName + " | 열기 실패";
                }
            }
            catch (Exception ex)
            {
                //label9.Text = SP_PortName + " 열기 실패";
                strInfoMsg = SP_PortName + " 열기 실패";
                AppendText(strInfoMsg);

               /* string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                }*/
            }
        }


        public void Step1()
        {

            FillDataToDB(saveFDCnt1);
        }


        private void TransperAndSaveFile()
        {

            string dir = Directory.GetCurrentDirectory();       // sound 
            dir += "\\notify.wav";
            WPlaySound.PlaySound(dir);

            int saveFDCnt = 0;
            bool bResult = false;
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
            else if (radioButton_UserTime.Checked)
            {
                form1.TAcho_tong = true;
            }
            else
            {
                MessageBox.Show("타코 전송 방식을 선택하여 주세요!");
                return;
            }


            try
            {
               // if(SP.IsOpen)
              //      SP.Close();

              //  label11.Text = SP.PortName + " | 닫혔음";             
             //   strInfoMsg = "데이터 분석중...";
            //    AppendText(strInfoMsg);

           /*     for (int a = 0; a < rcvList.Count; a++)
                {
                    if (rcvList[a] == 0xff)
                    {
                        rcvList.Remove(0xff);
                    }
                }*/


                rcvCnt = rcvList.Count;

                bool DataError = false;

                if (rcvList[80] == 0x55 && rcvList[81] == 0x15 && rcvList[82] == 0xA5)
                {
                  //  MessageBox.Show("데이터 중복 에러 발생 !");
                    DataError = true;
                    rcvCnt -= 80;
                    

                }
             

                byte[] rcvByte = new byte[rcvCnt];


                   

                    if (DataError == false)
                    {
                       rcvList.CopyTo(rcvByte);

                       
                    }
                    else
                    {
                        int r=0;
                        for (int q = 80; q < rcvList.Count; q++)
                        {
                            rcvByte[r] = rcvList[q];
                            r++;
                        }

                    }

                
               
              
///
                //Create a new subfolder under the current active folder
                string newPath = System.IO.Path.Combine(TACHO2_path, "TMP");
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
                newPath = System.IO.Path.Combine(TACHO2_path, "TMF");
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath);

                NowReceiveTMF = NowReceiveTime + "TMF";
                str = newPath + NowReceiveTMF;
                FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                //bw.Write(rcvStr);
                byte checkSum = 0x00;
                int sofSave = 0, sof = 0, i = 0, j = 0;
                int sofCnt = 0;


              /*  if (rcvByte[80] == 0x55 && rcvByte[81] == 0x15 && rcvByte[82] == 0xA5)
                {
                    MessageBox.Show("test");


            

                }*/


                do
                {
                    try                                                                                                                                                                                                                                                                                                                                                                                                     
                    {
                        sofSave = sof;

                        if (rcvCnt < (sof + 12))    // SOF 길이 체크
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

                           //     continue;
                            }

                            int nowBlockCnt = (sof + (11 + 384 + nDataNum) + (((384 + nDataNum) - 1) / 512 + 1));
                            if (rcvCnt < nowBlockCnt)
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

                        //MessageBox.Show(ex.Message, "FormTachoReceive.TransperAndSaveFile()");
                     /*   string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                        }*/
                    }
                } while (sofSave != sof);

                bw.Close();
                fs.Close();

         //       bResult = true;
            }
            catch (Exception ex)
            {
              
            }
            finally
            {
                //if (saveFDCnt > 0)
             //   if (bResult)
             //   {

					if (form1.tmpopen == true)
					{
						string	path = TACHO2_path +"TMF";

						MessageBox.Show(path + NowReceiveTMF + " 변환이 완료 되었습니다.");
					}
					else
					{
					//	FillDataToDB(saveFDCnt);

                        saveFDCnt1 = saveFDCnt;
                        Thread DataDB1 = new Thread(Step1);
                        DataDB1.Start();
					}
					
                    strInfoMsg = "데이터 처리 완료";
                    AppendText(strInfoMsg);
              //  }
             //   else
            //    {
             //       strInfoMsg = "처리할 데이터가 없습니다";
             //       AppendText(strInfoMsg);
             //   }
                    try
                    {
                        //serialPort1.Open();

                        if (SP.IsOpen)
                        {
                            rcvList.Clear();
                            isTimerUse = true;
                            //label9.Text = "Data Receiving...";
                            strInfoMsg = "데이터 수신 대기중";
                            AppendText(strInfoMsg);

                            string parity = "E", stopbits = "N";
                            switch (SP.Parity)
                            {
                                case Parity.Even: parity = "E"; break;
                                case Parity.Mark: parity = "M"; break;
                                case Parity.None: parity = "N"; break;
                                case Parity.Odd: parity = "O"; break;
                                case Parity.Space: parity = "S"; break;
                            }
                            switch (SP.StopBits)
                            {
                                case StopBits.None: stopbits = "0"; break;
                                case StopBits.One: stopbits = "1"; break;
                                case StopBits.OnePointFive: stopbits = "1.5"; break;
                                case StopBits.Two: stopbits = "2"; break;
                            }
                            //  label11.Text = serialPort1.PortName + " | " + serialPort1.BaudRate.ToString() + "," + serialPort1.DataBits + "," + parity + "," + stopbits;
                            label11.Text = SP.PortName + " | Open";
                        }
                        else
                        {
                            //label9.Text = "";
                            strInfoMsg = "";
                            AppendText(strInfoMsg);

                            label11.Text = SP.PortName + " | 열기 실패";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);


                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SP.IsOpen)
            {
                SP.Close();
                label11.Text = SP.PortName + " | 닫혔음";

                if (!SP.IsOpen)
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

        private void FormTachoReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            SP.Close();
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void   FillDataToDB(int nTotalFDCount)
        {
            bool bOpenFileData = true;
            int IndexNumber = 1;
            DateTime standardTime = new DateTime(1, 1, 1, 0, 0, 0);
            Color AliceBlue = Color.FromArgb(240, 248, 255);
            Color Blue = Color.FromArgb(0, 255, 255);
            Color LightPink = Color.FromArgb(255, 223, 223);


            long oldFdPosition = 0, newFdPosition = 0;
            int bReadData = 0;

            byte[][] bArrEmergencyData = new byte[16][];

            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(TACHO2_path, "TMF");
            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);

            string strFilePath = newPath + NowReceiveTMF;

            if (form1.ParsingMode == true)
            {
                // 1. tmf 읽어 차량 검색한다.
                // 2. 차량에 따른 파싱 모드를 검색 한다.
                // 3. 모드에 따라 파싱한다.
                form1.Tmf_Position = 0;
                form1.Tmf_ParsingMode(strFilePath);
                form1.Tmf_Position = 0;

               if (form1.ExternalCon == true)
                {
                    // form1.tmfSave_data(strFilePath);

                    form1.externalProg = true;
                    form1.ExProg1 = true;
                    form1.tmf_data(strFilePath);
                    form1.externalProg = false;
                    form1.ExProg1 = false;
                    // tmfSave_data(dirName);
                }
                
                return;
            }

			if(form1.TAcho_tong == true)
			{

                if (form1.UserTime == true)
                {
                    form1.User_Year = (int)numericUpDown_Year.Value;
                    form1.User_Month = (int)numericUpDown_Month.Value;
                    form1.User_Day = (int)numericUpDown_Day.Value;

                    if (radioButton_AM.Checked)
                    {
                        form1.UserAM = true;

                    }
                    else
                    {
                        form1.UserAM = false;
                    }


                    if (radioButton_PM.Checked)
                    {
                        form1.UserPM = true;
                    }
                    else
                    {
                        form1.UserPM = false;
                    }


                }
              
                if (form1.SungSil == 1)
                {

                 //   MessageBox.Show("성실 교통 테스트");
                    form1.SungSil_tmf_data(strFilePath);

                    if (listView1.Items.Count != 0)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items.Count - 1 != i)
                            {
                                listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                            }
                        }

                        listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                    }

                 
                }
                else if(form1.TongYoung ==1)
                {
                    form1.TongYoung_tmf_data(strFilePath);
                }
                else if (form1.AutoDisplay == true)
                {
                    form1.tmf_data(strFilePath);
                    if (listView1.Items.Count != 0)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items.Count - 1 != i)
                            {
                                listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                            }
                        }

                        listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                    }
                }
                else
                {
                    form1.tmf_data(strFilePath);
                }
				form1.TAcho_tong = false;

               

                if (form1.ExternalCon == true)
                {
                   // form1.tmfSave_data(strFilePath);

                    form1.externalProg = true;
                    form1.ExProg1 = true;
                    form1.tmf_data(strFilePath);
                    form1.externalProg = false;
                    form1.ExProg1 = false;
                    // tmfSave_data(dirName);
                }
			}
			else if(form1.Tacho_dailly == true)
			{
			//	form1.Dayilly_tmf_data(strFilePath);
                if (form1.TongYoung != 1)
                {
                    form1.TongYoungTime = 0;
                }
               




                if (form1.AutoDisplay == true)
                {
                    form1.TongYoung_tmf_data(strFilePath);
                    form1.Tacho_dailly = false;
                    if (listView1.Items.Count != 0)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items.Count - 1 != i)
                            {
                                listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                            }
                        }

                        listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                    }
                }
                else
                {
                    form1.TongYoung_tmf_data(strFilePath);
                    form1.Tacho_dailly = false;
                }
               
                if (form1.ExternalCon == true)
                {

                   form1.ExProg1 = true;
                   form1.tmf_data(strFilePath);
                   form1.ExProg1 = false;
                }
			}
			else if (form1.Tacho_2dailly == true)
			{
                if (form1.AutoDisplay == true)
                {
                    form1.Dayilly2_tmf_data(strFilePath);
                    form1.Tacho_2dailly = false;
                    if (listView1.Items.Count != 0)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items.Count - 1 != i)
                            {
                                listView1.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                            }
                        }

                        listView1.Items[listView1.Items.Count - 2].BackColor = LightPink;
                    }
                }
                else
                {

                    form1.Dayilly2_tmf_data(strFilePath);
                    form1.Tacho_2dailly = false;
                }
                if (form1.ExternalCon == true)
                {

                    form1.ExProg1 = true;
                    form1.tmf_data(strFilePath);
                    form1.ExProg1 = false;
                }
			}
			else if (form1.Tacho_auto == true)
			{
				form1.Atuo_tmf_data(strFilePath);
				form1.Tacho_auto = false;
                if (form1.ExternalCon == true)
                {

                    form1.ExProg1 = true;
                    form1.tmf_data(strFilePath);
                    form1.ExProg1 = false;
                }
			}
			
         

        //    FillDataListView();

			
        }

        public void FillDataListView()
        {
            try
            {
				string DBstring = "";

				if (form1.mdbfilesel == true)
				{
					DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + form1.mdbfilename;
					//					 Db_backup = false;


				}
				else
				{
				//	DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

				}
				
              
                OleDbConnection conn = new OleDbConnection(@DBstring);
                conn.Open();

                //string queryRead = "SELECT * FROM TblTacho WHERE ID>'" + nLastTblTachoID.ToString() + "'";
                string queryRead = "SELECT * FROM TblTacho WHERE ID>" + nLastTblTachoID.ToString();
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                if (listView1.Items.Count > 0)
                    listView1.Items.Clear();

                listView1.View = View.Details;
                listView1.GridLines = true;
                listView1.FullRowSelect = true;

                //TimeSpan stSpan = new TimeSpan();
                int listViewCnt = 1;

                totalMoney = 0;

                while (srRead.Read())
                {
                    //stSpan = srRead.GetDateTime(5) - rcvDateTime;

                    //if ((stSpan.Seconds) > 0)
                    {
                        ListViewItem a = new ListViewItem(listViewCnt.ToString());              // ID

                        //a.SubItems.Add(srRead.GetString(3));
                        a.SubItems.Add("");                                                     // 기사이름

                        a.SubItems.Add(srRead.GetString(2));                                    // 기사번호
                        a.SubItems.Add(srRead.GetString(1));                                    // 차량번호
    
                        totalMoney += srRead.GetDecimal(6);
                        string money = string.Format("{0:C}", srRead.GetDecimal(6));
                        a.SubItems.Add(money);                                                  // 미터수입

                        listView1.Items.Add(a);
                        listViewCnt++;
                    }
                }

             //   textBoxTotalMoney.Text = string.Format("{0:C}", totalMoney);
                totalMoney = 0;

                conn.Close();
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
            }
        }

        private byte DecimalToBCD(int n)
        {
            n = n % 100;

            return (byte)(((n / 10) << 4) + (n % 10));
        }

        private void RepeatedDataDelete()
        {
            try
            {
                List<int> lnDelID = new List<int>();

                // DB에서 중복 데이터 삭제
                string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                OleDbConnection conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryRead;
                OleDbCommand acomRead;
                OleDbDataReader asRead;
                for (int c = 0; c < lnNowAddedData.Count; c++)
                {
                    try
                    {
                        queryRead = "select * from TblTacho WHERE 차량No = '" + lsNowAddedCarNo[c] + "'";
                        queryRead += " AND 입고시간 = @InT";
                        queryRead += " AND 출고시간 = @OutT";
                        acomRead = new OleDbCommand(queryRead, conn);
                        acomRead.Parameters.Add(new OleDbParameter("@InT", ldtNowAddedInTime[c]));
                        acomRead.Parameters.Add(new OleDbParameter("@OutT", ldtNowAddedOutTime[c]));
                        asRead = acomRead.ExecuteReader();

                        while (asRead.Read())
                        {
                            int tmpN = asRead.GetInt32(0);
                            if (lnNowAddedData[c] != tmpN)
                                lnDelID.Add(tmpN);
                        }
                    }
                    catch (Exception ex)
                    {
                      /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                        }*/

                        //MessageBox.Show("중복 데이터를 삭제하지 못했습니다.");
                    }
                }

                if (lnDelID.Count > 0)
                {
                    for (int n = 0; n < lnDelID.Count; n++)
                    {
                        string queryDelTblTacho = "DELETE FROM TblTacho where ID = " + lnDelID[n].ToString();
                        OleDbCommand comDelDelTblTacho = new OleDbCommand(queryDelTblTacho, conn);
                        comDelDelTblTacho.ExecuteNonQuery();

                        string queryDelTaxiInfor = "DELETE FROM TaxiInfor where 인덱스 = " + lnDelID[n].ToString();
                        OleDbCommand comDelDelTaxiInfor = new OleDbCommand(queryDelTaxiInfor, conn);
                        comDelDelTaxiInfor.ExecuteNonQuery();

                        string queryDelGraph = "DELETE FROM Graph where 인덱스 = " + lnDelID[n].ToString();
                        OleDbCommand comDelDelGraph = new OleDbCommand(queryDelGraph, conn);
                        comDelDelGraph.ExecuteNonQuery();

                        DrawProgressBar((int)(80 + ((double)(n + 1) / (double)lnDelID.Count) * 20));
                    }
                }
                else
                {
                    DrawProgressBar(100);
                }

                conn.Close();
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
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isTimerUse = true;
            spTimer.Enabled = true;
            isStartTimer = true;
            isFirstDataGet = true;
        }

        private void DetectLastID()
        {
            string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
            OleDbConnection conn = new OleDbConnection(@DBstring);
            conn.Open();
            string queryOpen = "SELECT * FROM TblTacho ORDER BY ID DESC";
            OleDbCommand commOpen = new OleDbCommand(queryOpen, conn);
            OleDbDataReader srRead = commOpen.ExecuteReader();

            while (srRead.Read())
            {
                nLastTblTachoID = srRead.GetInt32(0);
                break;
            }
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
			NowReceiveTMF = "\\2010115_155329.TMF";
			FillDataToDB(100);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_UserTime.Checked == true)
            {
                numericUpDown_Year.Enabled = true;
                numericUpDown_Month.Enabled = true;
                numericUpDown_Day.Enabled = true;
            }
            else
            {
                numericUpDown_Year.Enabled = false;
                numericUpDown_Month.Enabled = false;
                numericUpDown_Day.Enabled = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
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