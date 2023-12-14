using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ConvertTacho
{
    public partial class FormDayDirveRec : Form
    {
        private bool m_bStart;
        textBoxData tBoxData = new textBoxData();

        private bool isDriver = false;
        private bool isCarNum = false;
        private string compareObject = "";
		FormData formData;
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
            public int i과속시간;
            public int i급제동회수;
            public int i주행기본회수;
            public int i주행이후회수;
            public int i할증기본회수;
            public int i할증이후회수;
            public int i문개폐회수;
            public int i영업회수;
            public int i영업시간;
            public int i공차시간;
            public int i키사용회수;
            public int i주행시간;
            public int i정차시간;
            public double i공차거리;
        }

        public FormDayDirveRec(FormData f)
        {
            InitializeComponent();
            m_bStart = true;
			formData = f;
        }

        public void FillData(DateTime todayDateTime)
        {
            try
            {

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

               // string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
                OleDbConnection conn = new OleDbConnection(@DBstring);
                conn.Open();

                string queryRead = "select * from TblTacho";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                while (srRead.Read())
                {
                    //if ((isDriver) && !((compareObject == srRead.GetString(3)) || (compareObject == srRead.GetString(2))))
                    if ((isDriver) && (compareObject != srRead.GetString(2)))
                    {
                        //if(compareObject != srRead.GetString(3))  // 아직 지원 안함
                            continue;   // 기사별 집계시 타 기사 거르기
                    }
                //    if ((isCarNum) && (srRead.GetString(1).CompareTo(compareObject) != 1)) 

					if ((isCarNum) && (srRead.GetString(1).Contains(compareObject) ==false)) 
                        continue;   // 차량번호별 집계시 타 차량번호 거르기

                    DateTime readToday = srRead.GetDateTime(5);

                    if ((todayDateTime.Year == readToday.Year)
                        && (todayDateTime.Month == readToday.Month)
                        && (todayDateTime.Day == readToday.Day))
                    {
                        tBoxData.totalCarNum++;

                        DateTime outT = srRead.GetDateTime(4);
                        //DateTime inT = srRead.GetDateTime(5);
                        DateTime inT = readToday;
                        TimeSpan dT = inT - outT;
						

                        int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
                        tBoxData.i운행시간 += driveT;

                        int meterImport = (int)srRead.GetDecimal(6);
                        tBoxData.i미터수입 += meterImport;

                        tBoxData.i실입금액 = 0;

                        double salesDistance = srRead.GetDouble(8);
                        tBoxData.i영업거리 += salesDistance;

                        double driveDistance = srRead.GetDouble(9);
                        tBoxData.i주행거리 += driveDistance;

                        double fuel = srRead.GetDouble(10);
                        tBoxData.i연료량 += fuel;

                        outT = new DateTime(2010, 1, 1, 0, 0, 0);
						inT = srRead.GetDateTime(11);
						dT = inT - outT;
                        int overDriveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
                        tBoxData.i과속시간 += overDriveT;

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

                        int doorOpenCnt = srRead.GetInt32(17);
                        tBoxData.i문개폐회수 += doorOpenCnt;

                        int salesCnt = srRead.GetInt32(18);
                        tBoxData.i영업회수 += salesCnt;

                        int salesT = srRead.GetInt32(19);
                        tBoxData.i영업시간 += salesT;

                        int emptyT = srRead.GetInt32(20);
                        tBoxData.i공차시간 += emptyT;

                        int keyUseCnt = srRead.GetInt32(21);
                        tBoxData.i키사용회수 += keyUseCnt;

                        int riderT = salesT + emptyT;
                        tBoxData.i주행시간 += riderT;

                        int stopT = ((driveT > riderT) ? driveT - riderT : 0);
                        tBoxData.i정차시간 += stopT;

                        double emptyDistance = driveDistance - salesDistance;
                        tBoxData.i공차거리 += emptyDistance;
                    }
                }

                if (tBoxData.totalCarNum > 0)
                {
                    tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
                    tBoxData.h미터수입 = String.Format("{0:C} 원", tBoxData.i미터수입);
                    tBoxData.h실입금액 = String.Format("0 원");
                    tBoxData.h영업거리 = String.Format("{0:N} Km", tBoxData.i영업거리);
                    tBoxData.h주행거리 = String.Format("{0:N} Km", tBoxData.i주행거리);
                    tBoxData.h연료량 = String.Format("{0} L", tBoxData.i연료량);


					
               //     tBoxData.h과속시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i과속시간 / 60), (tBoxData.i과속시간 % 60));

                    tBoxData.h급제동회수 = String.Format("{0} 회", tBoxData.i급제동회수);
                    tBoxData.h주행기본회수 = String.Format("{0} 회", tBoxData.i주행기본회수);
                    tBoxData.h주행이후회수 = String.Format("{0} 회", tBoxData.i주행이후회수);
                    tBoxData.h할증기본회수 = String.Format("{0} 회", tBoxData.i할증기본회수);
                    tBoxData.h할증이후회수 = String.Format("{0} 회", tBoxData.i할증이후회수);
                    tBoxData.h문개폐회수 = String.Format("{0} 회", tBoxData.i문개폐회수);
                    tBoxData.h영업회수 = String.Format("{0} 회", tBoxData.i영업회수);
                    tBoxData.h영업시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i영업시간 / 60), (tBoxData.i영업시간 % 60));
                    tBoxData.h공차시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i공차시간 / 60), (tBoxData.i공차시간 % 60));
                    tBoxData.h키사용회수 = String.Format("{0} 회", tBoxData.i키사용회수);
                    tBoxData.h주행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i주행시간 / 60), (tBoxData.i주행시간 % 60));
                    tBoxData.h정차시간 = String.Format("{0:D}시간 {1:D2}분", (int)(tBoxData.i정차시간 / 60), (tBoxData.i정차시간 % 60));
                    tBoxData.h공차거리 = String.Format("{0:N} Km", tBoxData.i공차거리);
                    tBoxData.h승차율 = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (tBoxData.i영업거리 / tBoxData.i주행거리) * 100) : "0.00 %";
                    tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";

                    tBoxData.h수입Km = (tBoxData.i영업거리 > 0) ? String.Format("{0:#.##} 원", (double)tBoxData.i미터수입 / tBoxData.i영업거리) : "0.00 원";

                    //totalCarNum
                    tBoxData.y운행시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i운행시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i운행시간 / tBoxData.totalCarNum) % 60));
                    tBoxData.y미터수입 = String.Format("{0:C} 원", (tBoxData.i미터수입 / tBoxData.totalCarNum));
                    tBoxData.y실입금액 = String.Format("0 원");
                    tBoxData.y영업거리 = String.Format("{0:N} Km", (tBoxData.i영업거리 / tBoxData.totalCarNum));
                    tBoxData.y주행거리 = String.Format("{0:N} Km", (tBoxData.i주행거리 / tBoxData.totalCarNum));
                    tBoxData.y연료량 = String.Format("{0} L", (tBoxData.i연료량 / tBoxData.totalCarNum));

					
           //         tBoxData.y과속시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i과속시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i과속시간 / tBoxData.totalCarNum) % 60));
					
                    tBoxData.y급제동회수 = String.Format("{0} 회", (tBoxData.i급제동회수 / tBoxData.totalCarNum));
                    tBoxData.y주행기본회수 = String.Format("{0} 회", (tBoxData.i주행기본회수 / tBoxData.totalCarNum));
                    tBoxData.y주행이후회수 = String.Format("{0} 회", (tBoxData.i주행이후회수 / tBoxData.totalCarNum));
                    tBoxData.y할증기본회수 = String.Format("{0} 회", (tBoxData.i할증기본회수 / tBoxData.totalCarNum));
                    tBoxData.y할증이후회수 = String.Format("{0} 회", (tBoxData.i할증이후회수 / tBoxData.totalCarNum));
                    tBoxData.y문개폐회수 = String.Format("{0} 회", (tBoxData.i문개폐회수 / tBoxData.totalCarNum));
                    tBoxData.y영업회수 = String.Format("{0} 회", (tBoxData.i영업회수 / tBoxData.totalCarNum));
                    tBoxData.y영업시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i영업시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i영업시간 / tBoxData.totalCarNum) % 60));
                    tBoxData.y공차시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i공차시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i공차시간 / tBoxData.totalCarNum) % 60));
                    tBoxData.y키사용회수 = String.Format("{0} 회", (tBoxData.i키사용회수 / tBoxData.totalCarNum));
                    tBoxData.y주행시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i주행시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i주행시간 / tBoxData.totalCarNum) % 60));
                    tBoxData.y정차시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i정차시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i정차시간 / tBoxData.totalCarNum) % 60));
                    tBoxData.y공차거리 = String.Format("{0:N} Km", (tBoxData.i공차거리 / tBoxData.totalCarNum));

                    textBox일일총운행수.Text = String.Format("{0}", tBoxData.totalCarNum);

                    FillDataSum();
                }

                conn.Close();

                this.Text = "일일 운행 기록";
            }
            catch (Exception ex)
            {
             /*   string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                }*/
            }
            finally
            {

            }
        }

        // 전체 데이터 - 집계 시작일과 종료일이 다른 경우 (일 기준)
        public void FillDataDiffSETotal(DateTime startDateTime, DateTime endDateTime)
        {
            DateTime nowDateTime = startDateTime;
            TimeSpan diffT = endDateTime - startDateTime;
            int iDate = (int)diffT.TotalDays;

            for (int i = 0; i < iDate; i++)
            {
                FillData(nowDateTime.AddDays(i));
            }

            label1.Visible = true;
            label2.Visible = false;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + endDateTime.Year.ToString() + "년 "
                            + endDateTime.Month.ToString() + "월 "
                            + endDateTime.Day.ToString() + "일";
            label41.Text = "전체차량 운행기록 집계";
            label42.Text = "월간 총 운행수";

            this.Text = "전체 데이터 보기";
        }

        // 전체 데이터 - 집계 시작일과 종료일이 같은 경우 (일 기준)
        public void FillDataSameSETotal(DateTime startDateTime)
        {
            FillData(startDateTime);

            label1.Visible = true;
            label2.Visible = false;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일";
            label41.Text = "전체차량 운행기록 집계";
            label42.Text = "월간 총 운행수";

            this.Text = "전체 데이터 보기";
        }

        // 기사별 데이터 - 집계 시작일과 종료일이 다른 경우 (일 기준)
        public void FillDataDiffSEDriver(DateTime startDateTime, DateTime endDateTime, string driver)
        {
            DateTime nowDateTime = startDateTime;
            TimeSpan diffT = endDateTime - startDateTime;
            int iDate = (int)diffT.TotalDays;

            isDriver = true;
            compareObject = driver;

            for (int i = 0; i < iDate; i++)
            {
                FillData(nowDateTime.AddDays(i));
            }

            label1.Visible = true;
            label2.Visible = true;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + endDateTime.Year.ToString() + "년 "
                            + endDateTime.Month.ToString() + "월 "
                            + endDateTime.Day.ToString() + "일";
            label2.Text = "기사: " + driver;
            label41.Text = "기사별 운행기록 집계";
            label42.Text = "월간 총 운행수";
            isDriver = false;

            this.Text = "[" + driver + "] 기사님 데이터 보기";
        }

        // 기사별 데이터 - 집계 시작일과 종료일이 같은 경우 (일 기준)
        public void FillDataSameSEDriver(DateTime startDateTime, string driver)
        {
            isDriver = true;
            compareObject = driver;
            FillData(startDateTime);

            label1.Visible = true;
            label2.Visible = true;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일";
            label2.Text = "기사: " + driver;
            label41.Text = "기사별 운행기록 집계";
            label42.Text = "월간 총 운행수";
            isDriver = false;

            this.Text = "[" + driver + "] 기사님 데이터 보기";
        }

        // 차량별 데이터 - 집계 시작일과 종료일이 다른 경우 (일 기준)
        public void FillDataDiffSECar(DateTime startDateTime, DateTime endDateTime, string carNum)
        {
            DateTime nowDateTime = startDateTime;
            TimeSpan diffT = endDateTime - startDateTime;
            int iDate = (int)diffT.TotalDays;

            isCarNum = true;
            compareObject = carNum;

            for (int i = 0; i < iDate+1; i++)
            {
                FillData(nowDateTime.AddDays(i));
            }

            label1.Visible = true;
            label2.Visible = true;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + endDateTime.Year.ToString() + "년 "
                            + endDateTime.Month.ToString() + "월 "
                            + endDateTime.Day.ToString() + "일";
            label2.Text = "차량: " + carNum;
            label41.Text = "차량별 운행기록 집계";
            label42.Text = "월간 총 운행수";
            isCarNum = false;

            this.Text = "[" + carNum + "] 차량 데이터 보기";
        }

        // 차량별 데이터 - 집계 시작일과 종료일이 같은 경우 (일 기준)
        public void FillDataSameSECar(DateTime startDateTime, string carNum)
        {
            isCarNum = true;
            compareObject = carNum;
            FillData(startDateTime);

            label1.Visible = true;
            label2.Visible = true;
            label1.Text = startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일 - "
                            + startDateTime.Year.ToString() + "년 "
                            + startDateTime.Month.ToString() + "월 "
                            + startDateTime.Day.ToString() + "일";
            label2.Text = "차량: " + carNum;
            label41.Text = "차량별 운행기록 집계";
            label42.Text = "월간 총 운행수";
            isCarNum = false;

            this.Text = "[" + carNum + "] 차량 데이터 보기";
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
            textBox주행시간.Text = tBoxData.h주행시간;
            textBox정차시간.Text = tBoxData.h정차시간;
            textBox공차거리.Text = tBoxData.h공차거리;
            textBox승차율.Text = tBoxData.h승차율;
            textBox운행률.Text = tBoxData.h운행률;
            textBox수입Km.Text = tBoxData.h수입Km;

            textBox불사용시간.Text = "0시간 00분";
            textBox합승시간.Text = "0시간 00분";
            textBox수입리터.Text = "**.** 원";
            textBox인정금액.Text = "0 원";
            textBox합승회수.Text = "0 회";
            textBox합승거리.Text = "0 Km";
            textBox지출금액.Text = "0 원";
            textBox불사용거리.Text = "0 Km";
            textBoxKm리터.Text = "**.** Km";
            textBox합승요금.Text = "0 원";
            textBox연료금액.Text = "0 원";
            textBox불사용요금.Text = "0 원";
            textBox불사용회수.Text = "0 회";
        }

        public void FillDataAverage()
        {
            textBox운행시간.Text = tBoxData.y운행시간;
            textBox미터수입.Text = tBoxData.y미터수입;
            textBox실입금액.Text = tBoxData.y실입금액;
            textBox영업거리.Text = tBoxData.y영업거리;
            textBox주행거리.Text = tBoxData.y주행거리;
            textBox연료량.Text = tBoxData.y연료량;
            textBox과속시간.Text = tBoxData.y과속시간;
            textBox급제동회수.Text = tBoxData.y급제동회수;
            textBox주행기본회수.Text = tBoxData.y주행기본회수;
            textBox주행이후회수.Text = tBoxData.y주행이후회수;
            textBox할증기본회수.Text = tBoxData.y할증기본회수;
            textBox할증이후회수.Text = tBoxData.y할증이후회수;
            textBox문개폐회수.Text = tBoxData.y문개폐회수;
            textBox영업회수.Text = tBoxData.y영업회수;
            textBox영업시간.Text = tBoxData.y영업시간;
            textBox공차시간.Text = tBoxData.y공차시간;
            textBox키사용회수.Text = tBoxData.y키사용회수;
            textBox주행시간.Text = tBoxData.y주행시간;
            textBox정차시간.Text = tBoxData.y정차시간;
            textBox공차거리.Text = tBoxData.y공차거리;
            /*
            textBox승차율.Text = tBoxData.y승차율;
            textBox운행률.Text = tBoxData.y운행률;
            textBox수입Km.Text = tBoxData.y수입Km;
            
            textBox불사용시간.Text = "0시간 00분";
            textBox합승시간.Text = "0시간 00분";
            textBox수입리터.Text = "**.** 원";
            textBox인정금액.Text = "0 원";
            textBox합승회수.Text = "0 회";
            textBox합승거리.Text = "0 Km";
            textBox지출금액.Text = "0 원";
            textBox불사용거리.Text = "0 Km";
            textBoxKm리터.Text = "**.** Km";
            textBox합승요금.Text = "0 원";
            textBox연료금액.Text = "0 원";
            textBox불사용요금.Text = "0 원";
            textBox불사용회수.Text = "0 회";
            */
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //labelDebug.Text = "Msg: " + "합계";
                FillDataSum();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                //labelDebug.Text = "Msg: " + "평균";
                FillDataAverage();
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            s.Width -= 20;
            s.Height -= 50;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50, dc1, 10, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.White;
            CaptureScreen();
            //this.BackColor = savColor;

            printPreviewDialog1.ShowDialog();

            printDialog1.AllowSomePages = true;

            // Show the help button.
            printDialog1.ShowHelp = true;

            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDayDirveRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
    }
}
