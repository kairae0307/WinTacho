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
using Excel = Microsoft.Office.Interop.Excel;
using ZedGraph;
using ListViewEx;
using System.Drawing.Printing;


namespace ConvertTacho
{
    public partial class FormCarTotal : Form
    {
        FormData formData;

        private iniClass inicls = new iniClass();
        public FormCarTotal(FormData f )
        {
            InitializeComponent();
            formData = f;
            m_list = new PrintableListView.PrintableListView();
            ImageList dummyImageList = new ImageList();
            dummyImageList.ImageSize = new System.Drawing.Size(1, 18);
            listView1.SmallImageList = dummyImageList;
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
        public void FillList(ListView list, ListView table)
        {
            list.SuspendLayout();

            // Clear list
            list.Items.Clear();
            list.Columns.Clear();

            // Columns
            int nCol = 0;
         


            int a = 11;

      

            for (int i = 0; i < a; i++)
            {


                ColumnHeader[] col = new ColumnHeader[a];
                ColumnHeader ch = new ColumnHeader();

                col[i] = table.Columns[i];
                ch.Text = col[i].Text;
                ch.TextAlign = HorizontalAlignment.Right;
                switch (nCol)
                {
                        
                    case 0: ch.Width = 30; break;       // id   

                    case 1: ch.Width = 80; break;       // 차량번호

                    case 2: ch.Width = 50; break;       // 기사번호
               
                    case 3:
                        ch.TextAlign = HorizontalAlignment.Left;    // 출고 
                        ch.Width = 180;
                        break;
                    case 4:
                        ch.TextAlign = HorizontalAlignment.Left;
                        ch.Width = 180;
                        break;              // 입고
                    case 5: ch.Width = 100; break;               // 미터 수입
              
                    case 6:  ch.Width = 100; break;               // 영업거리
                    case 7:  ch.Width = 100; break;                 // 주행거리
                    case 8:  ch.Width = 80; break;
                    case 9:  ch.Width = 80; break;
                    case 10: ch.Width = 60; break;
                    
/*
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
                    case 10: ch.Width = 80; break;*/



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
                        if (table.Items[n].SubItems.Count == 11)
                        {
                            item.SubItems.Add(table.Items[n].SubItems[i].Text);
                        }
                        else
                        {
                            item.SubItems.Add("");
                        }

                    }
                
                list.Height = 100;
                list.Items.Add(item);
            }



            list.ResumeLayout();
        }


        int mdbDate = 0;
        int SearchDate = 0;
        public void FillMonth(string carnum, DateTime searchtime)  // 년도 + 월 + 차 번호 
        {
            string path = Application.StartupPath + "\\WinTacho.ini";


            label1.Text = "근무 현황표(" + carnum + ")" ;


            string TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path); // 타코 루트



            string RValue = "";
            RValue = inicls.GetIniValue("Tacho Init", "Tacho Send Select", path);  // 타코 전송방식 읽어 오기 
            int Tacho_Sel = Convert.ToInt32(RValue);


            if (listView1.Items.Count > 0)
                listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;                   //   리스트 뷰 라인생성
            listView1.FullRowSelect = true;               // 라인 선택 
            string Dirname = "";

           
            listView1.Columns[0].Text = "일자";
            listView1.Columns[2].Width = 90;
            listView1.Columns[3].Width = 90;
            if (formData.Dayseach_tacho == true)
            {
                Dirname = formData.TACHO2_path + "타코";
            }
            else if (formData.Dayseach_tachoday == true)
            {
                Dirname = formData.TACHO2_path + "타코 일별";
            }
            else if (formData.Dayseach_tacho2day == true)
            {
                Dirname = formData.TACHO2_path + "타코 교대분리";
            }
            else if (formData.Dayseach_tachoauto == true)
            {
                Dirname = formData.TACHO2_path + "타코 자동분리";
            }

            DateTime SearchTime = new DateTime(searchtime.Year, searchtime.Month, searchtime.Day, 0, 0, 0);



            formData.yymmdd = SearchTime.ToString("yyyy년MM월");

            label2.Text = "작업월 : " +SearchTime.ToString("yyyy년MM월");

            string SearchTime_str = string.Format("{00:D2}", (searchtime.Year - 2000)) + string.Format("{00:D2}", searchtime.Month);
         

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
            int Total_DriveTime = 0;
            int Total_SlaesTime = 0;
              int MonthDay =0;


              //////////////////////////////////////  윤달 계산 

              int[] daynum = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

              if ((searchtime.Year % 4 == 0 && (searchtime.Year % 100) != 0) || (searchtime.Year % 400) == 0)  // 윤년
              {
                  if (searchtime.Month == 2)  // 윤달
                  {
                      MonthDay = 29;
                  }

              }
              else
              {
                  MonthDay = daynum[searchtime.Month];
              }


              ListViewItem[] k = new ListViewItem[MonthDay];


              for (int g = 0; g < MonthDay; g++)
              {
                  int d = g + 1;
                  k[g] = new ListViewItem(d.ToString());

                 
                  listView1.Items.Add(k[g]);
              }


              ////////////////////////////////////// 
            for (int i = 0; i < file_str.Length; i++)
            {
                int temp = 0, start_int = 0, end_int = 0;


                string DBstring = "";
                if (file_str[i] == null)
                {
                    continue;
                }

                /*
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
                }*/
               
            
                 mdbDate = Int32.Parse(file_str[i])/100;  // mdb yymm
                 SearchDate = (((searchtime.Year - 2000) * 100) + searchtime.Month); // search yymm


                 if (mdbDate != SearchDate)
                 {
                     continue;   //검색  년,월 과 다른 mdb 는 걸러낸다.
                 }

                DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";

                string queryRead = "select * from TblTacho";

                OleDbConnection conn1 = new OleDbConnection(@DBstring);
                conn1.Open();
                OleDbCommand commRead = new OleDbCommand(queryRead, conn1);
                OleDbDataReader srRead = commRead.ExecuteReader();

          

                while (srRead.Read())
                {
                    /////////
                    string tooltip_str = id.ToString();

                    string day_str = srRead.GetDateTime(4).ToString("dd");
                    int intday = Int32.Parse(day_str);


                    if ((srRead.GetString(1).Contains(carnum) == false))
                        continue;   //  타 차량번호 거르기



                    for (int g = 0; g < MonthDay; g++)      // 운행 일자 찾아가가기
                    {
                        if (listView1.Items[g].Text == intday.ToString())  // 같은 일짜
                        {
                            if (listView1.Items[g].SubItems.Count == 10) // 같은 날 영업한 데이타 있으므로  또다른 데이터를 합여야 한다.!!!
                            {
                                string CarNostr = srRead.GetString(1);  // 차량번호
                                listView1.Items[g].SubItems[1].Text = CarNostr;


                                ////////////////////////////////////////////////////////////// 출고시간 비교 
                                string old_outTime = listView1.Items[g].SubItems[2].Text;
                                bool hourchek = false;

                                int Old_Time = 0;
                                int New_Time = 0;

                                string day = "";
                                string hour = "";
                                string min = "";
                                int oldday = 0;
                                int oldhour = 0;
                                int oldmin = 0;


                                for (int b = 0; b < old_outTime.Length; b++)
                                {



                                    if (old_outTime[b] == ':')
                                    {
                                        hourchek = true;
                                    }


                                    if (old_outTime[b] != ':')
                                    {
                                        if (hourchek == false)
                                        {
                                            hour += old_outTime[b];
                                        }
                                        else
                                        {
                                            min += old_outTime[b];
                                        }

                                    }

                                }

                                oldhour = Int32.Parse(hour);
                                oldmin = Int32.Parse(min);
                                Old_Time = (oldhour * 60) + oldmin;
                              
                               DateTime newTime = srRead.GetDateTime(4);
                               New_Time = (newTime.Hour * 60) + newTime.Minute;

                               if (Old_Time > New_Time)  // 새로운 시간이 작으므로 갱신한다. 더 과거의 시간이 출고가 된다.
                                {
                                    listView1.Items[g].SubItems[2].Text = srRead.GetDateTime(4).ToString(" HH:mm"); // new Time
                                }
                               

                                ////////////////////////////////////////////////////////////// 입고시간 비교 
                                old_outTime = listView1.Items[g].SubItems[3].Text;
                                 hourchek = false;
                                
                                 Old_Time = 0;
                                 New_Time = 0;


                                  Old_Time = 0;
                                  New_Time = 0;

                                  day = "";
                                  hour = "";
                                  min = "";
                                  oldday = 0;
                                  oldhour = 0;
                                  oldmin = 0;

                                for (int b = 0; b < old_outTime.Length; b++)
                                {



                                    if (old_outTime[b] == ':')
                                    {
                                        hourchek = true;
                                    }


                                    if (old_outTime[b] != ':')
                                    {
                                        if (hourchek == false)
                                        {
                                            hour += old_outTime[b];
                                        }
                                        else
                                        {
                                            min += old_outTime[b];
                                        }

                                    }

                                }
                                oldhour = Int32.Parse(hour);
                                oldmin = Int32.Parse(min);
                                Old_Time = (oldhour * 60) + oldmin;

                                newTime = srRead.GetDateTime(5);
                                New_Time = (newTime.Hour * 60) + newTime.Minute;

                                if (Old_Time < New_Time)  //  입고시간
                                {
                                    listView1.Items[g].SubItems[3].Text = srRead.GetDateTime(5).ToString(" HH:mm");
                                }



                                //////////////////////////////////////////////////////////////  // 미터 수입                       
                                string oldmoney = listView1.Items[g].SubItems[4].Text;


                                oldmoney = oldmoney.Replace(",", "");
                                oldmoney = oldmoney.Replace("₩", "");
                                oldmoney = oldmoney.Replace(@"₩", "");
                                oldmoney = oldmoney.Replace("\\", "");
                                
                                int Oldmoney = Int32.Parse(oldmoney);


                                uint uuu = (uint)srRead.GetDecimal(6);
                                MoneyTotal += (int)uuu;

                                uuu += (uint)Oldmoney;
                                string money = string.Format("{0:C}", uuu);
                                money = money.Replace("₩", "");
                                money = money.Replace(@"₩", "");
                                money = money.Replace("\\", "");
                                listView1.Items[g].SubItems[4].Text = money;


                                //////////////////////////////////////////////////////////////  // 영업거리 
                                string SalesDistance = listView1.Items[g].SubItems[5].Text;
                                double SalesDist = 0;
                                SalesDistance = SalesDistance.Replace(",", "");
                                SalesDistance = SalesDistance.Replace(".", "");
                                SalesDistance = SalesDistance.Replace("Km", "");

                               SalesDist= (double)Int32.Parse(SalesDistance) / 100;

                                 double ddd = srRead.GetDouble(8);
                                SalesDistTotal += ddd;

                                ddd += SalesDist;
                                string dist = string.Format("{0:N}", ddd);
                                listView1.Items[g].SubItems[5].Text = dist;


                                //////////////////////////////////////////////////////////////  // 주행거리
                                string driveDistance = listView1.Items[g].SubItems[6].Text;
                                double driveDist = 0;
                                driveDistance = driveDistance.Replace(",", "");
                                driveDistance = driveDistance.Replace(".", "");
                                driveDistance = driveDistance.Replace("Km", "");

                                driveDist = (double)Int32.Parse(driveDistance) / 100;

                                ddd = srRead.GetDouble(9);
                                DistTotal += ddd;

                                ddd += driveDist;
                                dist = string.Format("{0:N}", ddd);
                                listView1.Items[g].SubItems[6].Text = dist;




                                //////////////////////////////////////////////////////////////  // 운행시간
                                        DateTime srTime = srRead.GetDateTime(11);
                                        DateTime stTime = new DateTime(srTime.Year, srTime.Month, srTime.Day, 0, 0, 0);
                                        TimeSpan stSpan = srTime - stTime;

                                        string Engine_Temp = srRead.GetString(25);   // 엔진
                                        string Sales_Temp = srRead.GetString(26);   // 영업
                                        string Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기

                                        char[] time_char = new char[Time_Temp.Length];
                                        char[] Engine_char = new char[Engine_Temp.Length];
                                        char[] Sales_char = new char[Sales_Temp.Length];

                                        int enginecnt = 0;

                                        for (int b = 0; b < Engine_Temp.Length; b++)    //Engine db : string  -> char 
                                        {
                                            Engine_char[b] = Engine_Temp[b];

                                            if (Engine_char[b] == '0')
                                            {
                                                enginecnt++;
                                            }

                                        }


                                        int timecnt = 0;

                                        for (int b = 0; b < Time_Temp.Length; b++)    // time db : string  -> char 
                                        {
                                            time_char[b] = Time_Temp[b];

                                            if (Time_Temp[b] == '#')
                                            {
                                                timecnt++;
                                            }
                                        }

                                        int cnt1 = 0;
                                        string[] time = new string[timecnt];
                                        for (int b = 0; b < time_char.Length; b++)   // 데이터 갯수 파확 및 -> 다시 string  변환
                                        {


                                            if (time_char[b] != '#')
                                            {
                                                time[cnt1] += time_char[b];
                                            }
                                            else
                                            {
                                                cnt1++;			// 데이터 카운트
                                            }


                                        }

                                        long[] time_long = new long[cnt1];

                                        DateTime[] datetime = new DateTime[cnt1];
                                        int totaltimecnt = 0;

                                        for (int b = 0; b < time.Length; b++)
                                        {
                                            time_long[b] = Int64.Parse(time[b]);		// string  -> long 변환 
                                            datetime[b] = DateTime.FromBinary(time_long[b]); // long -> DateTime 변환

                                            if (b != 0)
                                            {
                                                if (Engine_char[b] == '1' && Engine_char[b - 1] == '0')
                                                {
                                                }
                                                else
                                                {

                                                    TimeSpan datetime1 = datetime[b] - datetime[b - 1];
                                                    totaltimecnt += datetime1.Minutes;
                                                }
                                            }

                                        }


                                        int  driveday = 0;
                                         int drivehour = 0;
                                        int drivemin = 0;

                                        Total_DriveTime += totaltimecnt;

                                       


                               // old 운행시간을 읽어오자
                                 old_outTime = listView1.Items[g].SubItems[7].Text;
                                 hourchek = false;
                             
                                 Old_Time = 0;
                                 New_Time = 0;

                                 day = "";
                                 hour = "";
                                 min = "";
                                 oldday = 0;
                                 oldhour = 0;
                                 oldmin = 0;

                                 for (int b = 0; b < old_outTime.Length; b++)
                                 {



                                     if (old_outTime[b] == ':')
                                     {
                                         hourchek = true;
                                     }


                                     if (old_outTime[b] != ':')
                                     {
                                         if (hourchek == false)
                                         {
                                             hour += old_outTime[b];
                                         }
                                         else
                                         {
                                             min += old_outTime[b];
                                         }

                                     }

                                 }
                                 oldhour = Int32.Parse(hour);
                                 oldmin = Int32.Parse(min);
                                 Old_Time = (oldhour * 60) + oldmin;

                                 totaltimecnt += Old_Time;  // 리스트뷰 데이터 + mdb data

                                 int Day_calc = (totaltimecnt / 1440);
                                 int hour_calc = ((totaltimecnt - (Day_calc * 1440)) / 60);
                                 int min_calc = (totaltimecnt % 60);

                                 
                                        //    drivehour = totaltimecnt / 60;
                                        //    drivemin = totaltimecnt % 60;


                                         //   listView1.Items[g].SubItems[7].Text = drivehour.ToString() + ":" + drivemin.ToString();
                                 if (totaltimecnt / 1440 != 0)
                                 {
                                     listView1.Items[g].SubItems[7].Text = String.Format("{0:D}일 {1:D}시간 {2:D2}분", Day_calc, hour_calc, min_calc);
                                 }
                                 else
                                 {
                                     listView1.Items[g].SubItems[7].Text = String.Format("{0:D}시간 {1:D2}분", hour_calc, min_calc);
                                 }



                                /////////////////////// 영업시간///////////////////////////

                                            DateTime SalesT = srRead.GetDateTime(19);                                           
                                            Total_SlaesTime += (SalesT.Day *1440)+(SalesT.Hour * 60) + SalesT.Minute;

                                            // old 영업시간을 읽어오자
                                            old_outTime = listView1.Items[g].SubItems[8].Text;
                                            hourchek = false;

                                            Old_Time = 0;
                                            New_Time = 0;

                                            day = "";
                                            hour = "";
                                            min = "";
                                            oldday = 0;
                                            oldhour = 0;
                                            oldmin = 0;

                                            for (int b = 0; b < old_outTime.Length; b++)
                                            {



                                                if (old_outTime[b] == ':')
                                                {
                                                    hourchek = true;
                                                }


                                                if (old_outTime[b] != ':')
                                                {
                                                    if (hourchek == false)
                                                    {
                                                        hour += old_outTime[b];
                                                    }
                                                    else
                                                    {
                                                        min += old_outTime[b];
                                                    }

                                                }

                                            }
                                            oldhour = Int32.Parse(hour);
                                            oldmin = Int32.Parse(min);
                                            Old_Time = (oldhour * 60) + oldmin;


                                            Old_Time += (SalesT.Hour * 60) + SalesT.Minute;  // 리스트뷰 데이터 + mdb data

                                            Day_calc = (Old_Time / 1440);
                                            hour_calc = ((Old_Time - (Day_calc * 1440)) / 60);
                                            min_calc = (Old_Time % 60);

                                            if (Old_Time / 1440 != 0)
                                            {
                                                listView1.Items[g].SubItems[7].Text = String.Format("{0:D}일 {1:D}시간 {2:D2}분", Day_calc, hour_calc, min_calc);
                                            }
                                            else
                                            {
                                                listView1.Items[g].SubItems[7].Text = String.Format("{0:D}시간 {1:D2}분", hour_calc, min_calc);
                                            }

                                          //  drivehour = Old_Time / 60;
                                         //   drivemin = Old_Time % 60;


                                         //   listView1.Items[g].SubItems[8].Text = drivehour.ToString() + ":" + drivemin.ToString();
                                //



                                            /////////////////////// 영업회수///////////////////////////
                                            if (Tacho_Sel == 1)
                                            {
                                                uuu = (uint)srRead.GetInt32(18);     //영업회수

                                                string salescntstr = listView1.Items[g].SubItems[9].Text;  // lisetview data

                                                uuu += (uint)Int32.Parse(salescntstr);

                                                listView1.Items[g].SubItems[9].Text = uuu.ToString();
                                               
                                            }
                                            else
                                            {
                                                int slaescnt = 0;

                                                slaescnt = srRead.GetInt32(13); // 주행기본
                                                slaescnt += srRead.GetInt32(15);// 할증기본


                                                string salescntstr = listView1.Items[g].SubItems[9].Text;  // lisetview data


                                                slaescnt += Int32.Parse(salescntstr);
                                                listView1.Items[g].SubItems[9].Text = slaescnt.ToString();

                                                

                                            }


                            }
                            else
                            {

                                string CarNostr = srRead.GetString(1);  // 차량번호
                                listView1.Items[g].SubItems.Add(CarNostr);
                                listView1.Items[g].SubItems.Add(srRead.GetDateTime(4).ToString(" HH:mm"));            // 출고시간
                                listView1.Items[g].SubItems.Add(srRead.GetDateTime(5).ToString(" HH:mm"));           // 입고시간



                                uint uuu = (uint)srRead.GetDecimal(6);
                                MoneyTotal += (int)uuu;
                                string money = string.Format("{0:C}", uuu);

                                money = money.Replace("₩", "");
                                money = money.Replace(@"₩", "");
                                money = money.Replace("\\", "");
                                
                                listView1.Items[g].SubItems.Add(money);                                                  // 미터수입


                                // 실입금액

                                double ddd = srRead.GetDouble(8);
                                SalesDistTotal += ddd;
                                string dist = string.Format("{0:N}", ddd);
                                listView1.Items[g].SubItems.Add(dist);                                                   // 영업거리

                                ddd = srRead.GetDouble(9);
                                DistTotal += ddd;
                                dist = string.Format("{0:N}", ddd);
                                listView1.Items[g].SubItems.Add(dist);                                                   // 주행거리


                                DateTime srTime = srRead.GetDateTime(11);
                                DateTime stTime = new DateTime(srTime.Year, srTime.Month, srTime.Day, 0, 0, 0);
                                TimeSpan stSpan = srTime - stTime;




                                string Engine_Temp = srRead.GetString(25);   // 엔진
                                string Sales_Temp = srRead.GetString(26);   // 영업
                                string Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기

                                char[] time_char = new char[Time_Temp.Length];
                                char[] Engine_char = new char[Engine_Temp.Length];
                                char[] Sales_char = new char[Sales_Temp.Length];

                                int enginecnt = 0;

                                for (int b = 0; b < Engine_Temp.Length; b++)    //Engine db : string  -> char 
                                {
                                    Engine_char[b] = Engine_Temp[b];

                                    if (Engine_char[b] == '0')
                                    {
                                        enginecnt++;
                                    }

                                }


                                int timecnt = 0;

                                for (int b = 0; b < Time_Temp.Length; b++)    // time db : string  -> char 
                                {
                                    time_char[b] = Time_Temp[b];

                                    if (Time_Temp[b] == '#')
                                    {
                                        timecnt++;
                                    }
                                }

                                int cnt1 = 0;
                                string[] time = new string[timecnt];
                                for (int b = 0; b < time_char.Length; b++)   // 데이터 갯수 파확 및 -> 다시 string  변환
                                {


                                    if (time_char[b] != '#')
                                    {
                                        time[cnt1] += time_char[b];
                                    }
                                    else
                                    {
                                        cnt1++;			// 데이터 카운트
                                    }


                                }

                                long[] time_long = new long[cnt1];

                                DateTime[] datetime = new DateTime[cnt1];
                                int totaltimecnt = 0;

                                for (int b = 0; b < time.Length; b++)
                                {
                                    time_long[b] = Int64.Parse(time[b]);		// string  -> long 변환 
                                    datetime[b] = DateTime.FromBinary(time_long[b]); // long -> DateTime 변환

                                    if (b != 0)
                                    {
                                        if (Engine_char[b] == '1' && Engine_char[b - 1] == '0')
                                        {
                                        }
                                        else
                                        {

                                            TimeSpan datetime1 = datetime[b] - datetime[b - 1];
                                            totaltimecnt += datetime1.Minutes;
                                        }
                                    }

                                }


                                int day = 0, hour = 0, min = 0;

                                Total_DriveTime += totaltimecnt;

                                if (totaltimecnt > 1439)  // 1day
                                {
                                    day = totaltimecnt / 1440;
                                    hour = (totaltimecnt - (1440 * day)) / 60;
                                    min = (totaltimecnt - (1440 * day) - (hour * 60));

                                }
                                else
                                {
                                    hour = totaltimecnt / 60;
                                    min = totaltimecnt % 60;
                                }


                                if (day != 0)
                                {
                                    listView1.Items[g].SubItems.Add(day.ToString() + "일 " + hour.ToString() + "시간 " + min.ToString() + "분 ");  // 운행시간
                                }
                                else
                                {
                                    listView1.Items[g].SubItems.Add(hour.ToString() + ":" + min.ToString());  // 운행시간
                                }
                                DateTime SalesT = srRead.GetDateTime(19);
                                listView1.Items[g].SubItems.Add(SalesT.ToString("HH:mm"));    // 영업시간

                                Total_SlaesTime += (SalesT.Day * 1440)+(SalesT.Hour * 60) + SalesT.Minute;

                                if (Tacho_Sel == 1)
                                {
                                    uuu = (uint)srRead.GetInt32(18);     //영업회수
                                    listView1.Items[g].SubItems.Add(uuu.ToString());
                                }
                                else
                                {
                                    int slaescnt = 0;

                                    slaescnt = srRead.GetInt32(13); // 주행기본
                                    slaescnt += srRead.GetInt32(15);// 할증기본

                                    listView1.Items[g].SubItems.Add(slaescnt.ToString());

                                }
                            }
                        }
                    }
                  

              
                }
                //     conn.Close();
                conn1.Close();

            }
            ListViewItem c = new ListViewItem("합계");
            c.SubItems.Add("");                             ///   공백 3 만들기
            c.SubItems.Add("");
            c.SubItems.Add("");

            string mm = string.Format("{0:C}", MoneyTotal);     // 미터수입
            mm = mm.Replace("₩", "");
            mm = mm.Replace(@"₩", "");
            mm = mm.Replace("\\", "");
            c.SubItems.Add(mm);
            //     mm = string.Format("{0:C}", RealMoney);
            //     b.SubItems.Add(mm);                              // 실입금액
            mm = string.Format("{0:N}", SalesDistTotal);
            c.SubItems.Add(mm);                                                         // 영업거리
            mm = string.Format("{0:N}", DistTotal);
            c.SubItems.Add(mm);    // 주행거리
            ///////////////////////////
            int tday = 0, thour = 0, tmin = 0;                                 // 운행시간
            if (Total_DriveTime > 1439)  // 1day
            {
                tday = Total_DriveTime / 1440;

                thour = (Total_DriveTime - (1440 * tday)) / 60;
                tmin = (Total_DriveTime - (1440 * tday) - (thour * 60));
            }
            else
            {
                thour = Total_DriveTime / 60;
                tmin = Total_DriveTime % 60;
            }


            if (tday != 0)
            {
                c.SubItems.Add(tday.ToString() + "일 " + thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            else
            {
                c.SubItems.Add(thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            /////////////////////////////////////////
             tday = 0;
             thour = 0;
            tmin = 0;      
            if (Total_SlaesTime > 1439)  // 1day
            {
                tday = Total_SlaesTime / 1440;
                thour = (Total_SlaesTime - (1440 * tday)) / 60;
                tmin = (Total_SlaesTime - (1440 * tday) - (thour * 60));
            }
            else
            {
                thour = Total_SlaesTime / 60;
                tmin = Total_SlaesTime % 60;
            }


            if (tday != 0)
            {
                c.SubItems.Add(tday.ToString() + "일 " + thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 영업시간
            }
            else
            {
                c.SubItems.Add(thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 영업시간
            }
            c.SubItems.Add("");                                              // 주행기본
          

            c.BackColor = System.Drawing.Color.LightGray;
            listView1.Items.Add(c);

 
            FillList(this.m_list, listView1);

        }

        public void FillDays(string carnum, DateTime starttime, DateTime Endtime,int sel)
        {

            string path = Application.StartupPath + "\\WinTacho.ini";

            label2.Text = "";

           string  TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path); // 타코 루트

          

            string RValue = "";
            RValue = inicls.GetIniValue("Tacho Init", "Tacho Send Select", path);  // 타코 전송방식 읽어 오기 
           int  Tacho_Sel = Convert.ToInt32(RValue);


            if (listView1.Items.Count > 0)
                listView1.Items.Clear();

            listView1.View = View.Details;
            listView1.GridLines = true;                   //   리스트 뷰 라인생성
            listView1.FullRowSelect = true;               // 라인 선택 
            string Dirname = "";

            if (formData.Dayseach_tacho == true)
            {
                Dirname = formData.TACHO2_path + "타코";
            }
            else if (formData.Dayseach_tachoday == true)
            {
                Dirname = formData.TACHO2_path + "타코 일별";
            }
            else if (formData.Dayseach_tacho2day == true)
            {
                Dirname = formData.TACHO2_path + "타코 교대분리";
            }
            else if (formData.Dayseach_tachoauto == true)
            {
                Dirname = formData.TACHO2_path + "타코 자동분리";
            }

            DateTime StartTime = new DateTime(starttime.Year, starttime.Month, starttime.Day, 0, 0, 0);
            DateTime EndTime = new DateTime(Endtime.Year, Endtime.Month, Endtime.Day, 23, 59, 59);


            formData.yymmdd = StartTime.ToString("yyyy년MM월dd일") + "~" + EndTime.ToString("yyyy년MM월dd일");

           string StartTime_str = string.Format("{00:D2}", (starttime.Year - 2000)) + string.Format("{00:D2}", starttime.Month) + string.Format("{00:D2}", starttime.Day);
           string EndTime_str = string.Format("{00:D2}", (Endtime.Year - 2000)) + string.Format("{00:D2}", Endtime.Month) + string.Format("{00:D2}", Endtime.Day);

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
         /*   for (int i = 0; i < files.Length; i++)
            {

                if (files[i].Extension != ".ldb")
                {

                    file_str[i] = files[i].ToString();
                    file_str[i] = file_str[i].TrimEnd(trimChars);

                }

            }*/
            int j = 0;
            bool start = false;
            int id = 1;

            int MoneyTotal = 0, RealMoney = 0; ;
            double SalesDistTotal = 0;
            double DistTotal = 0;
            int Total_DriveTime = 0;
            int Total_SlaesTime = 0;


            for (int i = 0; i < file_str.Length; i++)
            {
                int temp = 0, start_int = 0, end_int = 0;


                string DBstring = "";
                if (file_str[i] == null)
                {
                    continue;
                }

                /*
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
                }*/




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

                    if (sel == 0)
                    {
                        if ((srRead.GetString(1).Contains(carnum) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                            continue;   // 차량번호별 집계시 타 차량번호 거르기
                    }
                    else if (sel == 1)
                    {
                       // if ((srRead.GetString(2).Contains(carnum) == false) || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                         //   continue;   // 기사번호별 집계시 타 차량번호 거르기
                         string tt =  srRead.GetString(2);
                         if (tt != carnum || (srRead.GetDateTime(4) < StartTime) || (srRead.GetDateTime(4) > EndTime))
                         {
                             continue; 
                         }
                    }

                    if (sel == 0)
                    {
                        if (carnum != strCarNo)
                        {
                            continue;

                        }
                    }

              /*      if (radioButton전체보기.Checked && !bIsDetail)
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
                    }*/

                    a.SubItems.Add(strCarNo);                                               // 차량번호

                    a.SubItems.Add(srRead.GetString(2));                                  // 기사번호

                    /*   string strDriverNo = srRead.GetString(2);

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
                       */
              
                    a.SubItems.Add(srRead.GetDateTime(4).ToString("yyyy-MM-dd tt HH:mm:ss"));            // 출고시간
                    a.SubItems.Add(srRead.GetDateTime(5).ToString("yyyy-MM-dd tt HH:mm:ss"));           // 입고시간

                    uint uuu = (uint)srRead.GetDecimal(6);
                    MoneyTotal += (int)uuu;
                    string money = string.Format("{0:C}", uuu);
                    a.SubItems.Add(money);                                                  // 미터수입

                    /*    uuu = (uint)srRead.GetDecimal(7);                                       // 실입금액
                        RealMoney += (int)uuu;
                        money = string.Format("{0:C}", uuu);
                        a.SubItems.Add(money);    */


                    // 실입금액

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

                    //    a.SubItems.Add(stSpan.ToString());                                      // 과속시간

                    //    uuu = (uint)srRead.GetInt32(12); // 급제동
                    //    a.SubItems.Add(uuu.ToString()); 

                 
                  string  Engine_Temp = srRead.GetString(25);   // 엔진
                  string  Sales_Temp = srRead.GetString(26);   // 영업
                 string   Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기

                 char[] time_char = new char[Time_Temp.Length];
                 char[] Engine_char = new char[Engine_Temp.Length];
                 char[] Sales_char = new char[Sales_Temp.Length];

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

                 for (int g = 0; g < Time_Temp.Length; g++)    // time db : string  -> char 
                 {
                     time_char[g] = Time_Temp[g];

                     if (Time_Temp[g] == '#')
                     {
                         timecnt++;
                     }
                 }

                 int cnt1 = 0;
                 string[] time = new string[timecnt];
                 for (int g= 0; g < time_char.Length; g++)   // 데이터 갯수 파확 및 -> 다시 string  변환
                 {


                     if (time_char[g] != '#')
                     {
                         time[cnt1] += time_char[g];
                     }
                     else
                     {
                         cnt1++;			// 데이터 카운트
                     }


                 }

                 long[] time_long = new long[cnt1];
              
                 DateTime[] datetime = new DateTime[cnt1];
                 int totaltimecnt = 0;

                 for (int g = 0; g < time.Length; g++)
                 {
                     time_long[g] = Int64.Parse(time[g]);		// string  -> long 변환 
                     datetime[g] = DateTime.FromBinary(time_long[g]); // long -> DateTime 변환

                     if (g != 0)
                     {
                         if (Engine_char[g] == '1' && Engine_char[g - 1] == '0')
                         {
                         }
                         else
                         {

                             TimeSpan datetime1 = datetime[g] - datetime[g - 1];
                             totaltimecnt += datetime1.Minutes;
                         }
                     }
                                    
                 }
 
                    int day=0,hour=0,min=0;

                    Total_DriveTime += totaltimecnt;  // 운행시간 합계
                    int Day_calc = (totaltimecnt / 1440);
                    int hour_calc = ((totaltimecnt - (Day_calc * 1440)) / 60);
                    int min_calc = (totaltimecnt % 60);


                    //    drivehour = totaltimecnt / 60;
                    //    drivemin = totaltimecnt % 60;


                    //   listView1.Items[g].SubItems[7].Text = drivehour.ToString() + ":" + drivemin.ToString();
                    if (totaltimecnt / 1440 != 0)
                    {
                         a.SubItems.Add( String.Format("{0:D}일 {1:D}시간 {2:D2}분", Day_calc, hour_calc, min_calc));
                    }
                    else
                    {
                         a.SubItems.Add( String.Format("{0:D}시간 {1:D2}분", hour_calc, min_calc));
                    }

                    /*
                    if (totaltimecnt > 1439)  // 1day
                    {
                        day = totaltimecnt / 1440;
                    }
                    else
                    {
                        hour = totaltimecnt / 60;
                        min = totaltimecnt % 60;
                    }


                    if (day != 0)
                    {
                        a.SubItems.Add(day.ToString() + "일 " + hour.ToString() + "시간 " + min.ToString() + "분 ");  // 운행시간
                    }
                    else
                    {
                        a.SubItems.Add( hour.ToString() + "시간 " + min.ToString() + "분 ");  // 운행시간
                    }*/


                      DateTime SalesT = srRead.GetDateTime(19);

                      if (SalesT.Year != 1899)
                      {
                          a.SubItems.Add(String.Format("{0:D}일 {1:D}시간 {2:D2}분", SalesT.Day, SalesT.Hour, SalesT.Minute));    // 영업시간
                          Total_SlaesTime += (SalesT.Day * 1440) + (SalesT.Hour * 60) + SalesT.Minute;
                         
                      }
                      else
                      {
                         
                              a.SubItems.Add(SalesT.ToString("HH시간 mm분 "));    // 영업시간
                              Total_SlaesTime +=   (SalesT.Hour * 60) + SalesT.Minute;
                        
                      }

                     
                     


                    if (Tacho_Sel == 1)
                    {
                        uuu = (uint)srRead.GetInt32(18);     //영업회수
                        a.SubItems.Add(uuu.ToString());     
                    }
                    else
                    {
                        int slaescnt = 0;

                        slaescnt = srRead.GetInt32(13); // 주행기본
                        slaescnt += srRead.GetInt32(15);// 할증기본

                        a.SubItems.Add(slaescnt.ToString());     

                    }
                  

          

              /*          uuu = (uint)srRead.GetInt32(13);     // 주행기본
                        a.SubItems.Add(uuu.ToString());     

                    uuu = (uint)srRead.GetInt32(14);    // 주행이후
                    a.SubItems.Add(uuu.ToString());

                    uuu = (uint)srRead.GetInt32(15);   // 할증기본
                    a.SubItems.Add(uuu.ToString());
                   
                    uuu = (uint)srRead.GetInt32(16);  // 할증이후
                    a.SubItems.Add(uuu.ToString());*/
                  
                    //a.SubItems.Add(srRead.GetInt32(17).ToString());                         // 문개폐

               //     int isOpenedDBNum = srRead.GetInt32(18);

                 //   string fuel = string.Format("{0:N} L", srRead.GetDouble(10));
                //    a.SubItems.Add(fuel);                                                   // 연료량

                    listView1.Items.Add(a);

                    id++;

                    //	nReadDBCnt++;
                    ///////////
                }
                //     conn.Close();
                conn1.Close();



            }
            ListViewItem b = new ListViewItem("합계");
            b.SubItems.Add("");                             ///   공백 3 만들기
            b.SubItems.Add("");
            b.SubItems.Add("");
            b.SubItems.Add("");
        
            string mm = string.Format("{0:C}", MoneyTotal);     // 미터수입
            b.SubItems.Add(mm);
       //     mm = string.Format("{0:C}", RealMoney);
       //     b.SubItems.Add(mm);                              // 실입금액
            mm = string.Format("{0:N} Km", SalesDistTotal);
            b.SubItems.Add(mm);                                                         // 영업거리
            mm = string.Format("{0:N} Km", DistTotal);
            b.SubItems.Add(mm);    // 주행거리
        ///////////////////////////
            int tday = 0, thour = 0, tmin = 0;                                 // 운행시간
            if (Total_DriveTime > 1439)  // 1day
            {
                tday = Total_DriveTime / 1440;

                thour = (Total_DriveTime - (1440 * tday)) / 60;
                tmin =  (Total_DriveTime - (1440 * tday)-(thour *60));
            }
            else 
            {
                thour = Total_DriveTime / 60;
                tmin = Total_DriveTime % 60;
            }


            if (tday != 0)
            {
                b.SubItems.Add(tday.ToString() + "일 " + thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            else
            {
                b.SubItems.Add(thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            /////////////////////////////////////////
            tday = 0;
            thour = 0;
            tmin = 0; 
            if (Total_SlaesTime > 1439)  // 1day
            {
                tday = Total_SlaesTime / 1440;
                thour = (Total_SlaesTime - (1440 * tday)) / 60;
                tmin = (Total_SlaesTime - (1440 * tday) - (thour * 60));
            }
            else
            {
                thour = Total_SlaesTime / 60;
                tmin = Total_SlaesTime % 60;
            }


            if (tday != 0)
            {
                b.SubItems.Add(tday.ToString() + "일 " + thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            else
            {
                b.SubItems.Add(thour.ToString() + "시간 " + tmin.ToString() + "분 ");  // 운행시간
            }
            b.SubItems.Add("");                                              // 주행기본
         

            b.BackColor = System.Drawing.Color.LightGray;
            listView1.Items.Add(b);


            //    yymmdd = listView1.Items[0].SubItems[4].Text + "~" + listView1.Items[listView1.Items.Count-2].SubItems[5].Text;
            FillList(this.m_list, listView1);


        }
        public void PrintPreview_FormData()
        {
            m_list.Title = label1.Text + "\n";
              
            m_list.Title +="                                                                                              "+ label2.Text;

           
          

            //m_list.FitToPage = m_cbFitToPage.Checked;

            //	m_list.PageSetup();

            m_list.FitToPage = true;

            m_list.PrintPreview();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            m_list.PageSetup();
            PrintPreview_FormData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel_print();
        }
        public void Excel_print()
        {
            string filePath = "c:\\test.xlsx";
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            int colIndex = 0;
            int rowIndex = 1;
            excel.Application.Workbooks.Add(true);

            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                colIndex++;
                excel.Cells[1, colIndex] = listView1.Columns[i].Text;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                rowIndex++;
                colIndex = 0;
                for (int j = 0; j <listView1.Items[i].SubItems.Count; j++)
                {
                    colIndex++;
                    excel.Cells[rowIndex, colIndex] = listView1.Items[i].SubItems[j].Text;
                    //     excel.Cells.AutoOutline();

                }
            }
            excel.Visible = true;


            //excel.Save(filePath);
        }
    }
}