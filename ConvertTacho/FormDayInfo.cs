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
using PrintableListView;
using ZedGraph;


namespace ConvertTacho
{


	public partial class FormDayInfo : Form
	{

		FormData formData;
        private iniClass inicls = new iniClass();
		private int m_nPageNumber = 2;
		private int m_nStartRow = 0;
		private int m_nStartCol = 0;
		public double x_backup = 0;
		public double xbase_backup = 0;
		private bool m_bPrintSel = false;
        public bool first_empty_dist = false;
		private bool m_bFitToPage = false;

		private float m_fListWidth = 0.0f;
		private float[] m_arColsWidth;

		private float m_fDpi = 96.0f;

		private string m_strTitle = "";

		public bool printstart = false;
		public int tapX = 996;

		public Boolean m_bStart;
	
		private string strTitle = "";
		public DateTime OutTime_info = new DateTime();
		public DateTime InTime_info = new DateTime();
		public DateTime Sales_Time = new DateTime();
		public DateTime Over_Time = new DateTime();
		public TimeSpan salestime_total = new TimeSpan();
		public TimeSpan emptytime_total = new TimeSpan();
		public TimeSpan overtime_total = new TimeSpan();

		public string Time_Temp;
		public byte[] Speed_Temp = new byte[65535];
		public byte[] Distance_Temp = new byte[65535];
		public string Engine_Temp ;
		public string Sales_Temp ;
		public string Door_Temp;
		public string CarNumber;
    
        public double Distance_empty = new double();
       

		public int BasicMoney = 0;
		public int AfterMoney = 0;
		public int BasicDistance = 0;
		public int AfterDistance = 0;
		public Total total;
        public string TACHO2_path = "";
      
		public struct Total
		{
			public uint tMoney;
			public double tDistS;
			public double tDisteD;

		}
		struct DD
		{
			
			public DateTime OutTime;		
			public string Time_Temp;
			public byte[] Speed_Temp;
			public byte[] Distance_Temp;
			public string Engine_Temp;
			public string Sales_Temp;
			

			public DD( DateTime _OutTime, string _Time_Temp, byte[] _Speed_Temp, byte[] _Distance_Temp, string _Engine_Temp,
							string _Sales_Temp) 
			{
				OutTime = _OutTime;
				Time_Temp = _Time_Temp;
				Speed_Temp = _Speed_Temp;
				Distance_Temp = _Distance_Temp;
				Engine_Temp = _Engine_Temp;
				Sales_Temp = _Sales_Temp;
			}
		}



		public class myReverserClass : IComparer
		{
			// Calls CaseInsensitiveComparer.Compare with the parameters reversed.
			int IComparer.Compare(Object _x, Object _y)
			{
				DD x = (DD)_x;
				DD y = (DD)_y;

				return x.OutTime.CompareTo(y.OutTime);
			}
		}

		private struct Graph_temp
		{
		
			public DateTime OutTime;
			public string Time_Temp;
			public byte[] Speed_Temp;
			public byte[] Distance_Temp ;
			public string Engine_Temp;
			public string Sales_Temp;
			public string Door_Temp;
			public int key;
			
			
		}
			
		private string compareObject = "";
		//GraphPane myPane1;
		GraphPane myPane2;
		GraphPane myPane3;
		Graph_temp[] graphcopy;
		textBoxData tBoxData = new textBoxData();

		public int BcdToDecimal(byte bTemp)
		{
			return (((bTemp >> 4) * 10) + (bTemp & 0x0F));
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
			public TimeSpan i공차시간;
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
		//	textBox주행시간.Text = tBoxData.y주행시간;
		//	textBox정차시간.Text = tBoxData.y정차시간;
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

		public FormDayInfo(FormData f)
		{
			InitializeComponent();
			
		
			formData = f;
			//label1.Visible = false;

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트

			total = new Total();
			  string path = Application.StartupPath + "\\WinTacho.ini";

			  m_list = new PrintableListView.PrintableListView();

              string RValue = "";
              RValue = inicls.GetIniValue("Meter Money Data Setting", "DriveBasicMoney", path);
              BasicMoney = Convert.ToInt32(RValue);

              RValue = inicls.GetIniValue("Meter Money Data Setting", "DriveBasicDistance", path);
              BasicDistance = Convert.ToInt32(RValue);

              RValue = inicls.GetIniValue("Meter Money Data Setting", "DriveAfterMoney", path);
              AfterMoney = Convert.ToInt32(RValue);

              RValue = inicls.GetIniValue("Meter Money Data Setting", "PremiumBasicMoney", path);

              radioButton_전체인쇄.Checked = true;
              AfterDistance = Convert.ToInt32(RValue);

              textBox_carnum.Visible = false;


              if (formData.DayInfoEdit == true)
              {
                  edit_button.Visible = true;
              }
              else
              {
                  edit_button.Visible = false;
              }
           
		}
		

		public void FillData_graph()
		{
			//zg2.GraphPane.CurveList.Clear();
			
			
			//  zg2.RestoreScale(zg2.GraphPane);    // "Set Scale to Default"
			// zg2.IsShowPointValues = true;       // "Show Point Values"
			//zg2.IsShowCursorValues = true;
			//SetSize();

		//	zg1.GraphPane.CurveList.Clear();
		//	CreateChart(zg1);
			//	zg1.RestoreScale(zg1.GraphPane);    // "Set Scale to Default"
			//	zg1.IsShowPointValues = true;       // "Show Point Values"
			//zg2.IsShowCursorValues = true;
		//	SetSize();


			zg3.GraphPane.CurveList.Clear();
			CreateChart(zg3);
			//	zg1.RestoreScale(zg1.GraphPane);    // "Set Scale to Default"
			//	zg3.IsShowPointValues = true;       // "Show Point Values"
			//zg2.IsShowCursorValues = true;
		//	SetSize();


		}
		public void CreateChart(ZedGraphControl zgc)
		{

			try
			{
				string CarNo = "";
				string DriverNo = "";
				int[] oldindex = new int[graphcopy.Length];
				DateTime OutTime = new DateTime();
				DateTime InTime = new DateTime();
				/////////
				
			//	IComparer myComparer = new myReverserClass();
			//	Array.Sort(graphcopy, myComparer);



				string DBstring = "";
				
				#region 열린 DB 정보 추출 -> 폼 제목 & 프린트 제목용
				{
										

					strTitle = "[" + CarNo + " / " + DriverNo + "] 의 운행 기록"
								+ "(" + OutTime.Year + "."
								+ OutTime.Month + "."
								+ OutTime.Day + " "
								+ OutTime.Hour + ":"
								+ OutTime.Minute + " ~ "
								+ InTime.Year + "."
								+ InTime.Month + "."
								+ InTime.Day + " "
								+ InTime.Hour + ":"
								+ InTime.Minute
								+ ")";

					this.Text = strTitle;

				}
				#endregion

				int index = 0;

				Time_Temp = "";
				Engine_Temp = "";
				Sales_Temp = "";
				Door_Temp = "";
				for (int i = 0; i < graphcopy.Length; i++)				// 시간별 순서를 매긴다
				{
					graphcopy[i].key = 0;
				}

				for (int i = 0; i < graphcopy.Length; i++)				// 시간별 순서를 매긴다
				{
					for (int j = 0; j < graphcopy.Length; j++)
					{
						if (i != j)
						{
							if (graphcopy[i].OutTime > graphcopy[j].OutTime)
							{
								graphcopy[i].key++;
							}
						}

					}

				}



				for(int i=0; i<graphcopy.Length; i++)							// 구조체 배열을 시간별로 정렬!!!
				{

					for (int k = 0; k < graphcopy.Length; k++)
					{


						if (i == graphcopy[k].key)
						{


							oldindex[i] = graphcopy[k].Engine_Temp.Length - 1;
							Time_Temp += graphcopy[k].Time_Temp;
							Engine_Temp += graphcopy[k].Engine_Temp;
							Sales_Temp += graphcopy[k].Sales_Temp;
							Door_Temp += graphcopy[k].Door_Temp;

							for (int j = 0; j < graphcopy[k].Distance_Temp.Length; j++)
							{
								Distance_Temp[index] = graphcopy[k].Distance_Temp[j];
								Speed_Temp[index] = graphcopy[k].Speed_Temp[j];
								index++;
							}
						}
					}
				
				}
						
				
				char[] time_char = new char[Time_Temp.Length];
				char[] Engine_char = new char[Engine_Temp.Length];
				char[] Sales_char = new char[Sales_Temp.Length];
				char[] Door_char = new char[Door_Temp.Length];


				int timecnt = 0;

				for (int i = 0; i < Time_Temp.Length; i++)    // time db : string  -> char 
				{
					time_char[i] = Time_Temp[i];

					if (Time_Temp[i] == '#')
					{
						timecnt++;
					}
				}
			

				for (int i = 0; i < Engine_Temp.Length; i++)    //Engine db : string  -> char 
				{
					
						Engine_char[i] = Engine_Temp[i];
						Door_char[i] = Engine_Temp[i];

				}

				for (int i = 0; i < Door_Temp.Length; i++)    //door db : string  -> char 
				{

					
					Door_char[i] = Door_Temp[i];

				}


					for (int i = 0; i < oldindex.Length - 1; i++)
					{
						Engine_char[oldindex[i]] = '0';
					}

				for (int i = 0; i < Sales_Temp.Length; i++)    //Sales db : string  -> char 
				{
					Sales_char[i] = Sales_Temp[i];

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
				//	long[] speed_long = new long[cnt];
				double[] distance_double = new double[cnt];
				DateTime[] datetime = new DateTime[cnt];

				for (int i = 0; i < time.Length; i++)
				{
					time_long[i] = Int64.Parse(time[i]);		// string  -> long 변환 
					datetime[i] = DateTime.FromBinary(time_long[i]); // long -> DateTime 변환
					//	speed_long[i] = Int32.Parse(speed[i]);			// string -> long  변환
					distance_double[i] = (double)(Distance_Temp[i]) / 10.0;
				}


				////////////////////////////////////////////////////////////////////////////////////
				if (zgc == zg3)
				{


					int Notusecount = 0;
					int doorstart = 0;
					int doorend = 0;
					int Notusemoney = 0;
					TimeSpan Notusetime = new TimeSpan();
					bool start = false;
					double NotuseDistance = 0;
					for (int i = 0; i < Door_char.Length; i++)   // 불사용
					{
					
						if (Door_char[i] == '1')
						{

						if (start == false)
							{
								if (i + 3 < Door_char.Length && i-2 >=0)
								{
																		
									if (Sales_char[i - 1] == '0' && Sales_char[i - 2]=='1')
										continue;

									if (Sales_char[i - 1] == '1')
										continue;
									if (Sales_char[i] == '1')
										continue;
									else if (Sales_char[i + 1] == '1')
										continue;
									else if (Sales_char[i + 2] == '1')
										continue;
									else if (Sales_char[i + 3] == '1')
										continue;
									else
									{
										Notusecount++;
										doorstart = i;
										tBoxData.i불사용회수 = Notusecount;
									}


								}
								start = true;
							}
							else
							{
								doorend = i;
								
								
								Notusetime += datetime[doorend] - datetime[doorstart];
								for (int j = doorstart; j <= doorend; j++ )
								{
									NotuseDistance += distance_double[j];
								}
									
								if(start == true)
								{
									
									if (i + 3 < Door_char.Length && i - 2 >= 0)
									{



										if (Sales_char[i - 1] == '0' && Sales_char[i - 2] == '1')
										{
											start = false;
											continue;
										}

										if (Sales_char[i - 1] == '1')
										{
											start = false;
											continue;
										}
										if (Sales_char[i] == '1')
										{
											start = false;
											continue;
										}
										else if (Sales_char[i + 1] == '1')
										{
											start = false;
											continue;
										}
										else if (Sales_char[i + 2] == '1')
										{
											start = false;
											continue;
										}
										else if (Sales_char[i + 3] == '1')
										{
											start = false;
											continue;
										}
										else
										{
											doorstart = doorend;

											Notusecount++;
											tBoxData.i불사용회수 = Notusecount;
										}


									}


								}
								
							}


						}
					}
					textBox불사용회수.Text = tBoxData.i불사용회수.ToString() + "회";
					textBox불사용시간.Text = String.Format(Notusetime.Hours.ToString() + "시간 " + Notusetime.Minutes.ToString() + "분");

					textBox불사용거리.Text = String.Format("{0:N} Km", NotuseDistance.ToString());
					
					/* BasicMoney = 0;
					 AfterMoney = 0;
					 BasicDistance = 0;
					 AfterDistance = 0;Notusemoney*/

					if (tBoxData.i불사용회수 != 0)
					{


						double dist = (NotuseDistance - (BasicDistance / 1000));
						dist = dist * 1000;
						double money = (dist / AfterDistance) * AfterMoney;

						int Money = (int)money + BasicMoney;

						Notusemoney += (Money / 100) * 100;
						textBox불사용요금.Text = String.Format("{0:C} 원", Notusemoney.ToString());
					}
					else
					{
						textBox불사용요금.Text = String.Format("{0:C} 원", Notusemoney.ToString());
					}
				}

				////////////////////////////////////////////////////////////////////////////////////

				TimeSpan ts = new TimeSpan(0, 0, 0, 0);
				DateTime dt = new DateTime(1, 1, 1, 0, 0, 0);
				bool isDtFilled = false;

				double timeLine = 0;


				GraphPane myPane = zgc.GraphPane;



				// Set up the title and axis labels

				//  myPane.Title.Text = strTitle;

			/*	if (zgc == zg1)
				{
					myPane.Title.Text = strTitle;
					myPane.YAxis.Title.Text = "속도(Km/h)";
					myPane.XAxis.Title.Text = "";
				}*/
				
				 if (zgc == zg3)
				{
					myPane.Title.Text = "";
					myPane.YAxis.Title.Text = " 영업 / 도어 / 엔진";
					myPane.XAxis.Title.Text = "";
				}

				//  myPane.XAxis.Title.Text = "시간";
				//  myPane.XAxis.Title.FontSpec.FontColor = Color.LightPink;
				//  myPane.YAxis.Title.Text = "속도(Km/h)";
				//  myPane.YAxis.Title.FontSpec.FontColor = Color.LightSalmon;

				// Make up some data arrays based on the Sine function



				PointPairList list1 = new PointPairList();
				PointPairList list2 = new PointPairList();
				PointPairList list3 = new PointPairList();
				PointPairList list4 = new PointPairList();
				PointPairList list5 = new PointPairList();

				bool isFirstGraph = true, isY3Up = false, isY4Up = false, isY5Up = false;

				double x = 0.0, y1 = 0.0, y2 = 0.0, y3 = 0.0, y4 = 0.0, y5 = 0.0;
				double a = 0;
				Engine_char[Engine_char.Length - 1] = '0';
				double xBase = new XDate(datetime[0]);
				xbase_backup = xBase;
				myPane.XAxis.Scale.Min = xBase;
				for (int i = 0; i < datetime.Length; i++)
				{
					
					x = new XDate(datetime[i]);   // Time
				//	x = x - xBase;
					y1 = (double)Speed_Temp[i];    // 속도
				//	y2 += distance_double[i];          // 거리

					a += distance_double[i];          // 거리

					int Value = (int)a / 20;

					if (Value % 2 == 0)
					{
						y2 = a - (Value * 20);

					}
					else
					{
						y2 = 20 - (a - (Value * 20));
					}




					
					
					//list1.Add(x, y1);
					//	list2.Add(x, y2);
				//		y2 = y2 + 150;
				//	double disty = y2 - 150;
				//	string dist_tag = disty.ToString();
					string dist_tag = String.Format("{0:#.#}Km", a.ToString());
					if (zgc == zg3)
					{
						list1.Add(x, y1);   // 속도
						list2.Add(x, y2, 0, dist_tag);

						if (Door_char[i] == '1')			// door
						{
							y5 = 270;
							list5.Add(x, y5);
							list5.Add(x, 250);
							isY5Up = true;
						}
						else
						{
							y5 = 250;
							list5.Add(x, y5);
							isY5Up = false;
						}
					}

					if (isFirstGraph)
					{
						//영업 = srRead.GetBoolean(3);      // 영업

						if (zgc == zg3)
						{
							//list5.Add(x, 130);
							if (Engine_char[i] == '1')   // engine
							{
								y4 = 290;
								list4.Add(x, 270);
								list4.Add(x, y4);
								isY4Up = true;
							}
							else
							{
								y4 = 270;
								list4.Add(x, y4);
								isY4Up = false;
							}
							/////////////	


							////////////////////
							if (Sales_char[i] == '1')
							{
								y3 = 240;
								list3.Add(x, 220);
								list3.Add(x, y3);
								isY3Up = true;
							}
							else
							{
								y3 = 220;
								list3.Add(x, y3);
								isY3Up = false;
							}

							isFirstGraph = false;


						}
					}
					else
					{
						//영업 = srRead.GetBoolean(3);      // 영업
						if (zgc == zg3)
						{
							//	list5.Add(x, 130);

							if (Engine_char[i] == '1')
							{
								if (!isY4Up)
								{
									y4 = 290;
									list4.Add(x, 270);
									list4.Add(x, y4);
									isY4Up = true;
								}
							}
							else
							{
								if (isY4Up)
								{
									y4 = 270;
									list4.Add(x, 290);
									list4.Add(x, y4);
									isY4Up = false;
								}
							}
							////////////////

							/*	if (Door_char[i] == '1')			// door
								{
									if (!isY5Up)
									{
										y5 = 150;
										list5.Add(x, 130);
										list5.Add(x, y5);
										isY5Up = true;
									}
								}
								else
								{
									if (isY5Up)
									{
										y5 = 130;
										list5.Add(x, 150);
										list5.Add(x, y5);
										isY5Up = false;
									}
								}*/
							//////////////



							if (Sales_char[i] == '1')
							{
								if (!isY3Up)
								{
									y3 = 240;
									list3.Add(x, 220);
									list3.Add(x, y3);
									isY3Up = true;
								}
							}
							else
							{
								if (isY3Up)
								{
									y3 = 220;
									list3.Add(x, 240);
									list3.Add(x, y3);
									isY3Up = false;
								}
							}



						}
					}

				}
				if (zgc == zg3)
				{
					list3.Add(x, y3);
					list4.Add(x, y4);
					list5.Add(x, y5);
				}
				/*	if (zgc == zg3)
					{
						list4.Add(x, y4); 
						list5.Add(x, y5);
					
					}*/


				// Generate a Blue curve with circle
				LineItem myCurve1 = myPane.AddCurve("속도", list1, Color.Blue, SymbolType.Diamond);
				// Generate a Black curve with circle
				LineItem myCurve2 = myPane.AddCurve("거리", list2, Color.Green, SymbolType.Circle);
				myCurve2.IsY2Axis = true;
				// Generate a Magenta curve with circle
				LineItem myCurve3 = myPane.AddCurve("영업", list3, Color.Red, SymbolType.Square);
				// Generate a Olive curve with circle
				LineItem myCurve4 = myPane.AddCurve("엔진", list4, Color.Black, SymbolType.Square);
				LineItem myCurve5 = myPane.AddCurve(" ", list5, Color.Black, SymbolType.Square);

				// Change the color of the title
				myPane.Title.FontSpec.FontColor = Color.Green;

				// Add gridlines to the plot, and make them gray
				myPane.XAxis.MajorGrid.IsVisible = true;
				myPane.YAxis.MajorGrid.IsVisible = true;
				myPane.XAxis.MajorGrid.Color = Color.Black;
				myPane.YAxis.MajorGrid.Color = Color.Black;
				myPane.XAxis.Type = AxisType.Date;
				myPane.XAxis.Scale.Format = " MMM월dd일 HH:mm"; // 24 hour clock for HH

				myPane.YAxis.Scale.Min = 0;
				myPane.YAxis.Scale.Max = 300;


				myPane.Y2Axis.IsVisible = true;
				// Make the Y2 axis scale blue
				myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Green;
				myPane.Y2Axis.Title.FontSpec.FontColor = Color.Green;
				// turn off the opposite tics so the Y2 tics don't show up on the Y axis

				// Display the Y2 axis grid lines
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				// Align the Y2 axis labels so they are flush to the axis
				myPane.Y2Axis.Scale.Align = AlignP.Inside;
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				myPane.Y2Axis.MajorGrid.Color = Color.Black;
				myPane.Y2Axis.MajorGrid.Color = Color.Black;
				myPane.Y2Axis.Scale.Min = -50;
				myPane.Y2Axis.Scale.Max = 50;

				// Move the legend location
				myPane.Legend.Position = ZedGraph.LegendPos.Bottom;

				// Make both curves thicker
				myCurve1.Line.Width = 1.0F;
				myCurve2.Line.Width = 1.0F;
				myCurve3.Line.Width = 1.0F;
				myCurve4.Line.Width = 1.0F;
				myCurve5.Line.Width = 1.0F;

				// Fill the area under the curves
				//myCurve1.Line.Fill = new Fill(Color.White, Color.Red, 45F);
				//myCurve2.Line.Fill = new Fill(Color.White, Color.Blue, 45F);
				//myCurve3.Line.Fill = new Fill(Color.White, Color.White, 45F);
				//myCurve4.Line.Fill = new Fill(Color.White, Color.White, 45F);
				//myCurve5.Line.Fill = new Fill(Color.White, Color.White, 45F);

				// Increase the symbol sizes, and fill them with solid white
				myCurve1.Symbol.Size = 0.5F;
				myCurve2.Symbol.Size = 0.5F;
				myCurve3.Symbol.Size = 0.5F;
				myCurve4.Symbol.Size = 0.5F;
				myCurve5.Symbol.Size = 0.5F;
				myCurve1.Symbol.Fill = new Fill(Color.White);
				myCurve2.Symbol.Fill = new Fill(Color.White);
				myCurve3.Symbol.Fill = new Fill(Color.White);
				myCurve4.Symbol.Fill = new Fill(Color.White);
				myCurve5.Symbol.Fill = new Fill(Color.White);

				// Add a background gradient fill to the axis frame
				myPane.Chart.Fill = new Fill(Color.White, Color.AliceBlue, -45F);

				// Set the XAxis to date type
				myPane.XAxis.Type = AxisType.Date;


				/*if (zgc == zg1)
				{
					myPane1 = myPane;
				}*/
				myPane.XAxis.Scale.Max = x;
				x_backup = x;
				if (zgc == zg3)
				{
					myPane3 = myPane;
				}

				// Calculate the Axis Scale Ranges
				zgc.AxisChange();

				
			}
			catch (Exception ex)
			{
				/* string path = Application.StartupPath + "\\ErrorLog.jie";
				 using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
				 {
					 sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
				 }*/
				MessageBox.Show(ex.Message);
			}
			finally
			{

			}
		}

		private void SetSize()
		{
			//  zg2.Location = new Point(0, 0);
			// Leave a small margin around the outside of the control
			//  zg2.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);


			//zg1.Location = new Point(0, 0);
			// Leave a small margin around the outside of the control
			//	zg1.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
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

		    
			BitBlt(dc2, 0, 0, this.ClientRectangle.Width , this.ClientRectangle.Height - 260, dc1, 10, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);
		}

		private void CaptureScreen1()
		{

			Graphics mygraphics1 = this.CreateGraphics();
			Size s = this.Size;
			//s.Width -= 200;
		//	s.Height -= 200;
			memoryImage1 = new Bitmap(s.Width, s.Height-500, mygraphics1);
			Graphics memoryGraphics1 = Graphics.FromImage(memoryImage1);
			IntPtr dc1 = mygraphics1.GetHdc();
			IntPtr dc2 = memoryGraphics1.GetHdc();


			BitBlt(dc2, this.ClientRectangle.Top-700, this.ClientRectangle.Bottom, this.ClientRectangle.Width - 600, this.ClientRectangle.Height - 600, dc1, 10, 0, 13369376);
			mygraphics1.ReleaseHdc(dc1);
			memoryGraphics1.ReleaseHdc(dc2);
		}

	

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(memoryImage, 0, 0);
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

		public int curPageNumber;
		private void button4_Click_1(object sender, EventArgs e)
		{


			curPageNumber = 1;
			CaptureScreen();
			image = zg3.GetImage();
				PrintDocument pd = new PrintDocument();
			//	PrintPreviewDialog ppd = new PrintPreviewDialog();
				pd.DefaultPageSettings.Landscape = false;
				pd.PrintPage += new PrintPageEventHandler(Graph_PrintPage);
				
			//	m_list.PageSetup();
		         
			    
				printPreviewDialog1.Document = pd ;
				
				printPreviewDialog1.ShowDialog();
				

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

		private void Graph_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;

			float x = e.MarginBounds.Left - 10;
			float y = e.MarginBounds.Top + 400;
			float width = 50.0F;
			float height = 50.0F;
			PrintDocument pd = sender as PrintDocument;
		
			RectangleF saveRect = myPane3.Rect;
			SizeF newSize = myPane3.Rect.Size;

			float xRatio = (float)e.MarginBounds.Width / (float)newSize.Width;
			float yRatio = (float)e.MarginBounds.Height / (float)newSize.Height;
			float ratio = Math.Min(xRatio, yRatio);

			newSize.Width *= ratio;
			String drawString = "속도(Km/h)";
			Font drawFont = new Font("Arial", 8);
			SolidBrush drawBrush = new SolidBrush(Color.Black);

			StringFormat sfmt = new StringFormat();

			RectangleF drawRect = new RectangleF(x, y, width, height);

			// Draw rectangle to screen.
			Pen blackPen = new Pen(Color.Black);
			//e.Graphics.DrawRectangle(blackPen, x, y, 40, 40);

			// Set format of string.
			StringFormat drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Center;
				//newSize.Height *= ratio;


			int imagey = 20;
			if (image.Width < 1647)
			{
				num = 2;
			}
			else if (image.Width > 1646 && image.Width < 2048)
			{
				num = 3;
			}
			//else if (image.Width >2047 && image.Width < 3048)
			else if (image.Width > 2047 )
			{
				num = 4;
			}
			int Width = image.Width;
			int Height = image.Height;
			int LefrSetp = Width / num;
			int TopStep = Height;
			Rectangle rect;

			int Nunmber = 0;
			if (curPageNumber == 1)
			{
				g.DrawImage(memoryImage, 0, 0);

                if (radioButton_종합정보인쇄.Checked)
                {
                    return;
                }

				Bitmap[] Target = new Bitmap[num];
				Graphics TargetG;
				imagea = new Image[num];

                if (radioButton_영업상세.Checked)
                {

                }
                else
                {

                    if (image.Width < 1048)
                    {

                        myPane3.ReSize(g, new RectangleF(e.MarginBounds.Left - 68,
                        e.MarginBounds.Top + 400, newSize.Width + 125, newSize.Height));
                        myPane3.Draw(g);

                    }
                    else
                    {

                        for (int j = 0; j < num; j++)
                        {

                            Target[j] = new Bitmap(LefrSetp, TopStep);

                            TargetG = Graphics.FromImage(Target[j]);
                            rect = new Rectangle(0, 0, LefrSetp, TopStep);

                            Nunmber = (0 + j) + 0;
                            TargetG.DrawImage(image, rect, LefrSetp * j, TopStep * 0, LefrSetp, TopStep, GraphicsUnit.Pixel);

                            //	Target.Save("c:\\" + Nunmber.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Target[j] = new Bitmap(Target[j], 720, 300);
                            imagea[j] = Target[j];



                        }

                        for (int i = 0; i < num; i++)
                        {
                            //	imagea[i] = Image.FromFile("c:\\" + i.ToString() + ".jpg");
                            if (i == 0)
                                e.Graphics.DrawImage(imagea[i], e.MarginBounds.Left - 70, e.MarginBounds.Top + 260);
                            if (i == 1)
                                e.Graphics.DrawImage(imagea[i], e.MarginBounds.Left - 70, e.MarginBounds.Top + 570);
                            //imagey += 410;


                        }
                        if (num == 2)
                        {


                            curPageNumber++;
                        }


                    }
                }
                if (radioButton_부분인쇄.Checked)
                {

                   
                    
                    e.HasMorePages = false;
                  
                }
                else
                {
                    if (radioButton_영업상세.Checked)
                    {
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

                        rectFull.Y += 380;
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
                        rectBody.Y += 400;

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

                        if (m_list.Items.Count < 27)
                        {
                            e.HasMorePages = false;
                            return;
                        }


                    }
                   
                    curPageNumber++;
                    e.HasMorePages = true;
                }
			}
			else if (curPageNumber == 2&& (num==3 || num==4))
			{
				if(num==3)
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
				m_strTitle = "♣ 영업 상세 데이터 ♣" + " <차번호 : " + compareObject+">";
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
		//	♣ 운행 그래프 ♣
		//	curPageNumber++;
			
		}
		

		private void button5_Click(object sender, EventArgs e)
		{
		//	zg1.Width -= 50;
		
		//	zg3.Width -= 200;
			if (tapX > 1052 )
			{
				tapX -= 200;
				zg3.Width -= 200;
			}
			else if (zg3.Width > 1247 && tapX < 1053)
			{
				zg3.Width -= 200;
			}
			tapPage1.Size = new System.Drawing.Size(tapX, 565);

		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			//zg1.Width += 50;
			if (zg3.Width < 4848)
			{


				zg3.Width += 200;
				tapX += 200;
				tapPage1.Size = new System.Drawing.Size(tapX, 565);
			}
		}
		public void FillDaySearchData(string carnum,DateTime starttime,DateTime Endtime)
		{
			string Dirname = "";

			if (formData.Dayseach_tacho == true)
			{
				Dirname = TACHO2_path +"타코";
			}
			else if (formData.Dayseach_tachoday == true)
			{
				Dirname = TACHO2_path +"타코 일별";
			}
			else if (formData.Dayseach_tacho2day == true)
			{
				Dirname = TACHO2_path +"타코 교대분리";
			}
			else if (formData.Dayseach_tachoauto == true)
			{
				Dirname = TACHO2_path+"타코 자동분리";
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

			
			for (int i = 0; i < file_str.Length; i++)
			{


				string DBstring = "";

				if (formData.Db_backup == true)
				{
					DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Dirname + "\\" + file_str[i] + ".mdb";
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

				//if ((srRead.GetString(1).Contains(compareObject) == false))
				//	continue;   // 차량번호별 집계시 타 차량번호 거르기

				while (srRead.Read())
				{
					compareObject = carnum;


					차번label.Visible = true;
					차번label.Text = "차 번 : " + compareObject;

					if ((srRead.GetString(1).Contains(compareObject) == false) || (srRead.GetDateTime(4) < starttime) || (srRead.GetDateTime(4) >Endtime))
						continue;   // 차량번호별 집계시 타 차량번호 거르기

					string driverNo = srRead.GetString(2);
					string driverName = srRead.GetString(3);

					운전자label.Visible = true;
					운전자label.Text = "운 전 자 : " + driverNo + " ( " + driverName + ")";

					DateTime readToday = srRead.GetDateTime(5);

					tBoxData.totalCarNum++;

					DateTime outT = srRead.GetDateTime(4);
					bool start = false;
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
					출고label.Visible = true;
					입고label.Visible = true;

					출고label.Text = "출 고 : " + starttime;
					입고label.Text = "입 고 : " + Endtime;
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
					salestime_total += salesT;
					tBoxData.i영업시간 = salestime_total;




					TimeSpan emptyT = new TimeSpan();					// 공차 시간
					emptyT = eT - salesT;
					emptytime_total += emptyT;
					tBoxData.i공차시간 += emptytime_total;

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
				tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
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



				tBoxData.h영업시간 = String.Format(salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
				tBoxData.h공차시간 = String.Format(emptytime_total.Hours.ToString() + "시간 " + emptytime_total.Minutes.ToString() + "분");
				tBoxData.h키사용회수 = String.Format("{0} 회", tBoxData.i키사용회수);
				tBoxData.h주행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i주행시간 / 60), (tBoxData.i주행시간 % 60));
				tBoxData.h정차시간 = String.Format("{0:D}시간 {1:D2}분", (int)(tBoxData.i정차시간 / 60), (tBoxData.i정차시간 % 60));
				tBoxData.h공차거리 = String.Format("{0:N} Km", tBoxData.i공차거리);
				tBoxData.h승차율 = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (tBoxData.i영업거리 / tBoxData.i주행거리) * 100) : "0.00 %";
				int driveTIme = (((tBoxData.i영업시간.Days * 24) + tBoxData.i영업시간.Hours) * 60) + tBoxData.i영업시간.Minutes;

				tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i운행시간) : "0.00 %";
			//	tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";

				tBoxData.h수입Km = (tBoxData.i영업거리 > 0) ? String.Format("{0:C} 원", (double)tBoxData.i미터수입 / tBoxData.i영업거리) : "0.00 원";

			
				FillDataSum();
				//FillData_graph();
			}
		

		}
	
		public void FillData(string carnum,int indexcount)
		{
			try
			{
				//label41.Text = "test";
				string DBstring = "";
				string NameDB = "";

				listView1.View = View.Details;
				listView1.GridLines = true;
				listView1.FullRowSelect = true;

				int nCnt = 1;

				total.tDisteD = 0;
				total.tDistS = 0;
				total.tMoney = 0;

				DateTime stTime = new DateTime(1, 1, 1, 0, 0, 0);
				DateTime srTime = new DateTime(1, 1, 1, 0, 0, 0);
				TimeSpan stSpan = new TimeSpan(0, 0, 0, 0);

				listView1.Items.Clear();
				listView1.Columns.Clear();

				listView1.Columns.Add("번호", 50, HorizontalAlignment.Left);
				listView1.Columns.Add("날짜", 80, HorizontalAlignment.Right);
				listView1.Columns.Add("승차시간", 75, HorizontalAlignment.Left);
				listView1.Columns.Add("하차시간", 75, HorizontalAlignment.Right);
				listView1.Columns.Add("영업 (Km)", 100, HorizontalAlignment.Right);
				listView1.Columns.Add("요금 (원)", 80, HorizontalAlignment.Right);
				listView1.Columns.Add("빈차 (Km)", 100, HorizontalAlignment.Right);
				listView1.Columns.Add("빈차시간", 75, HorizontalAlignment.Right);
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
		
				OleDbConnection conn = new OleDbConnection(@DBstring);
				conn.Open();

				string queryRead = "select * from TblTacho";
				OleDbCommand commRead = new OleDbCommand(queryRead, conn);
				OleDbDataReader srRead = commRead.ExecuteReader();
				int count = 0;

				Graph_temp[] graph = new Graph_temp[indexcount];

				graphcopy = new Graph_temp[indexcount];
				

				for (int i = 0; i < indexcount; i++ )
				{
					graph[i].Distance_Temp = new byte[65535];
					graph[i].Speed_Temp = new byte[65535];
					graph[i].Engine_Temp = "";
					graph[i].Sales_Temp = "";
					graph[i].Time_Temp = "";
					graph[i].OutTime = new DateTime(1, 1, 1, 0, 0, 0);


				}

				bool start = false;

				
				while (srRead.Read())
				{

					 
						compareObject = carnum;

						byte[] Sales_Detail = new byte[50000];
						차번label.Visible = true;
					//	차번label.Text = "차 번 : " + compareObject;


                        if (formData.Driverilbo == true)
                        {

                            if ((srRead.GetString(2).Contains(compareObject) == false))
                                continue;   // 
                        }
                        else if (formData.Car_Driverilbo == true)
                        {
                            if ((srRead.GetString(1).Contains(formData.combo_car_str) == false))
                                continue;   // 차량번호별 집계시 타 차량번호 거르기

                            if ((srRead.GetString(2).Contains(formData.combo_driver_str) == false))
                                continue;   // 
                        }
                        else if (formData.Carilbo == true)
                        {
                            차번label.Text = "차 번 : " + compareObject;
                            if ((srRead.GetString(1).Contains(compareObject) == false))
                                continue;   // 차량번호별 집계시 타 차량번호 거르기
                        }
                        else
                        {
                            차번label.Text = "차 번 : " + compareObject;
                            if ((srRead.GetString(1).Contains(compareObject) == false))
                                continue;   // 차량번호별 집계시 타 차량번호 거르기
                        }

                        차번label.Text = "차 번 : " + srRead.GetString(1);
						string driverNo = srRead.GetString(2);
						string driverName = srRead.GetString(3);

						운전자label.Visible = true;
						운전자label.Text= "운 전 자 : " + driverNo + " ( " + driverName + ")";

						DateTime readToday = srRead.GetDateTime(5);

						tBoxData.totalCarNum++;

						DateTime outT = srRead.GetDateTime(4);


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
						출고label.Visible = true;
						입고label.Visible = true;

					//	출고label.Text = "출 고 : " + OutTime_info;
                        출고label.Text = "출 고 : " + OutTime_info.ToString("yyyy-MM-dd tt HH:mm:ss");
                     //   a.SubItems.Add(srRead.GetDateTime(4).ToString("yyyy-MM-dd tt HH:mm:ss")); 


					//	입고label.Text = "입 고 : " + InTime_info;
                        입고label.Text = "입 고 : " + InTime_info.ToString("yyyy-MM-dd tt HH:mm:ss"); ;
						graph[count].OutTime = outT;

						m_list.Title = "[(" + OutTime_info + ") ~ (" + InTime_info + ")]"
						   + "\r\n차량: [" + compareObject + "], 기사번호: [" + driverNo + "] 의 정보";

						//DateTime inT = srRead.GetDateTime(5);
						DateTime inT = readToday;
						TimeSpan dT = inT - outT;
					//	TimeSpan eT = dT;
                    //////////////////////////////////////////////////////////////

                        string Engine_Temp = srRead.GetString(25);   // 엔진
                        string Sales_Temp = srRead.GetString(26);   // 영업
                        string Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기

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
                        for (int g = 0; g < time_char.Length; g++)   // 데이터 갯수 파확 및 -> 다시 string  변환
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
                    ///////////////////////////////////////

						int driveT = (((dT.Days * 24) + dT.Hours) * 60) + dT.Minutes;
                        tBoxData.i운행시간 += totaltimecnt;

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



					/*	TimeSpan salesT = new TimeSpan();
						Sales_Time = srRead.GetDateTime(19);
						DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
						salesT = Sales_Time - Sales_Time_t;
						salestime_total += salesT;
						tBoxData.i영업시간 = salestime_total;*/

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

						graph[count].Door_Temp = srRead.GetString(17);  //door
					//	int doorOpenCnt = srRead.GetInt32(17);
					//	tBoxData.i문개폐회수 += doorOpenCnt;

						int salesCnt = srRead.GetInt32(18);
						tBoxData.i영업회수 += salesCnt;



					  	TimeSpan salesT = new TimeSpan();
                      
						 Sales_Time = srRead.GetDateTime(19);


                         if (Sales_Time.Year == 1899)
                         {
                             DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
                             salesT = Sales_Time - Sales_Time_t;
                             salestime_total += salesT;
                             tBoxData.i영업시간 = salestime_total;

                         }
                         else
                         {
                             DateTime Sales_Time_t = new DateTime(Sales_Time.Year, Sales_Time.Month, Sales_Time.Day, 0, 0, 0); // 영업시간 
                            // salesT = Sales_Time - Sales_Time_t;

                             salesT = new TimeSpan(Sales_Time.Day, Sales_Time.Hour, Sales_Time.Minute,0);

                             salestime_total += salesT;
                             tBoxData.i영업시간 = salestime_total;
                         }

                         TimeSpan eT =new TimeSpan(0,(totaltimecnt / 60), (totaltimecnt%60),0);	


					   
						 TimeSpan emptyT = new TimeSpan();					// 공차 시간
						 emptyT = eT - salesT;
						 emptytime_total += emptyT;
						tBoxData.i공차시간 += emptytime_total;

						int keyUseCnt = srRead.GetInt32(21);
						tBoxData.i키사용회수 += keyUseCnt;

						int riderT =  0;
						tBoxData.i주행시간 += riderT;

						int stopT = ((driveT > riderT) ? driveT - riderT : 0);
						tBoxData.i정차시간 += stopT;

						double emptyDistance = driveDistance - salesDistance;
						tBoxData.i공차거리 += emptyDistance;

					    					 
					  
						 graph[count].Time_Temp = srRead.GetString(22);  // 그래프 시간 읽기

						//	Speed_Temp = srRead1.GetString(23); // 그래프 속도 일기
						srRead.GetBytes(23, 0,  graph[count].Speed_Temp, 0, 65530);
					
						//	Distance_Temp = srRead1.GetString(24); // 거리
						srRead.GetBytes(24, 0, graph[count].Distance_Temp, 0, 65530);

						graph[count].Engine_Temp = srRead.GetString(25);   // 엔진
						graph[count].Sales_Temp = srRead.GetString(26);   // 영업


						int gcnt = 0;
						for (int i = 0; i < graph[count].Time_Temp.Length; i++ )
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
					
						for (int i = 0; i < gcnt; i++ )
						{
							graphcopy[count].Speed_Temp[i] = graph[count].Speed_Temp[i];
							graphcopy[count].Distance_Temp[i] = graph[count].Distance_Temp[i];
						}

						srRead.GetBytes(27, 0, Sales_Detail, 0, 50000);  // 상세영업
						stTime = srRead.GetDateTime(4); 
							//graphcopy[count] = graph[count];


                        double[] distance_double = new double[graph[count].Sales_Temp.Length];
                        Sales_char = new char[graph[count].Sales_Temp.Length];
                        for (int i = 0; i < graph[count].Sales_Temp.Length; i++)    //Sales db : string  -> char 
                        {
                            Sales_char[i] = graph[count].Sales_Temp[i];

                        }

                        for (int i = 0; i < graph[count].Sales_Temp.Length; i++)
                        {

                            distance_double[i] = (double)(graph[count].Distance_Temp[i]) / 10.0;

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


						int DAtacnt = 0;


						//int hour = 0;

						int fdcnt = 0;
						for (int i = 0; i < Sales_Detail.Length; i++)
						{
							if (Sales_Detail[i] == 0xfd)
								fdcnt++;
						}

						byte[] Sales_Data = new byte[fdcnt * 34];

						for (int i = 0; i < Sales_Data.Length; i++)
						{
							Sales_Data[i] = Sales_Detail[i];
						}

						int sales_cnt = 0;

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
										break;

									case 1:
										Day_int = Sales_Data[i + j + sales_cnt];
										string str = string.Format("{0}.{1}.{2}", stTime.Year.ToString(), Month_int.ToString(), Day_int.ToString());
										a.SubItems.Add(str);

										break;


									case 2:
										in_hour = Sales_Data[i + j + sales_cnt];
										break;

									case 3:
										in_str = string.Format("{0:D2}:{1:D2}", in_hour, Sales_Data[i + j + sales_cnt]); //승차
										a.SubItems.Add(in_str);
										break;

									case 4:
										out_hour = Sales_Data[i + j + sales_cnt];
										break;

									case 5:
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

										string distance_str = string.Format("{0:N} Km", distance.ToString());
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

									/*	empty = (double)((BcdToDecimal(Empty_Distance[2]) * 10000)
													+ (BcdToDecimal(Empty_Distance[1]) * 100)
													+ BcdToDecimal(Empty_Distance[0])) / 1000.0;


										

										string empty_str = empty.ToString();
										a.SubItems.Add(empty_str);
										break;*/

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

										int emptytime = Sales_Data[i + j + sales_cnt];
										string empty_time = string.Format("{0:D2}:{1:D2}", emptytime / 60, emptytime % 60);
										a.SubItems.Add(empty_time);
										break;

									case 18:

										key = Sales_Data[i + j + sales_cnt];

										break;
									case 19:

										break_stop = Sales_Data[i + j + sales_cnt];

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
					

							count++;
					
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
					if (tBoxData.totalCarNum > 0)
					{
						tBoxData.h운행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i운행시간 / 60), (tBoxData.i운행시간 % 60));
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

						
						 
					//	tBoxData.h영업시간 = String.Format(salestime_total.Hours.ToString()+"시간 " + salestime_total.Minutes.ToString() +"분");
					//	tBoxData.h공차시간 = String.Format(emptytime_total.Hours.ToString() + "시간 " + emptytime_total.Minutes.ToString() + "분");

                        if (salestime_total.Days == 0)
                        {
                            tBoxData.h영업시간 = String.Format( salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                        }
                        else
                        {
                            tBoxData.h영업시간 = String.Format(salestime_total.Days.ToString() + "일" + salestime_total.Hours.ToString() + "시간 " + salestime_total.Minutes.ToString() + "분");
                        }
                        tBoxData.h공차시간 = String.Format(emptytime_total.Days.ToString() + "일" + emptytime_total.Hours.ToString() + "시간 " + emptytime_total.Minutes.ToString() + "분");



						tBoxData.h키사용회수 = String.Format("{0} 회", tBoxData.i키사용회수);
						tBoxData.h주행시간 = String.Format("{0:D}시간 {1:D2}분", (tBoxData.i주행시간 / 60), (tBoxData.i주행시간 % 60));
						tBoxData.h정차시간 = String.Format("{0:D}시간 {1:D2}분", (int)(tBoxData.i정차시간 / 60), (tBoxData.i정차시간 % 60));
						tBoxData.h공차거리 = String.Format("{0:N} Km", tBoxData.i공차거리);
						tBoxData.h승차율 = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (tBoxData.i영업거리 / tBoxData.i주행거리) * 100) : "0.00 %";

						int driveTIme = (((tBoxData.i영업시간.Days * 24) + tBoxData.i영업시간.Hours) * 60) + tBoxData.i영업시간.Minutes;

						tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)driveTIme) * 100 / (double)tBoxData.i운행시간) : "0.00 %";
					//	tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";

						tBoxData.h수입Km = (tBoxData.i영업거리 > 0) ? String.Format("{0:C} 원", (double)tBoxData.i미터수입 / tBoxData.i영업거리) : "0.00 원";

						//totalCarNum
					/*	tBoxData.y운행시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i운행시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i운행시간 / tBoxData.totalCarNum) % 60));
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
					//	tBoxData.y영업시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i영업시간 ) ), ((tBoxData.i영업시간 ) ));
						tBoxData.y공차시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i공차시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i공차시간 / tBoxData.totalCarNum) % 60));
						tBoxData.y키사용회수 = String.Format("{0} 회", (tBoxData.i키사용회수 / tBoxData.totalCarNum));
						tBoxData.y주행시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i주행시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i주행시간 / tBoxData.totalCarNum) % 60));
						tBoxData.y정차시간 = String.Format("{0:D}시간 {1:D2}분", ((tBoxData.i정차시간 / tBoxData.totalCarNum) / 60), ((tBoxData.i정차시간 / tBoxData.totalCarNum) % 60));
						tBoxData.y공차거리 = String.Format("{0:N} Km", (tBoxData.i공차거리 / tBoxData.totalCarNum));*/

						//	textBox일일총운행수.Text = String.Format("{0}", tBoxData.totalCarNum);

						FillDataSum();
						FillData_graph();
					}

				conn.Close();

				this.Text = "일일 운행 기록";
			}
			catch (Exception ex)
			{
				
				MessageBox.Show(ex.Message);
			}
			finally
			{
				FillList(this.m_list, listView1);
			}
		}

		private void printPreviewDialog1_FormClosing(object sender, FormClosingEventArgs e)
		{
			//zg1.RestoreScale(zg1.GraphPane);
		//	zg3.RestoreScale(zg3.GraphPane);

			tapX = 1052;
		//	tapPage1.Size = new System.Drawing.Size(tapX, 565);
			zg3.Width -= 10;
			zg3.RestoreScale(zg3.GraphPane);
		//	zg3.Size = new Size(1047, 400);
			myPane3.YAxis.Scale.Min = 0;
			myPane3.YAxis.Scale.Max = 300;
			myPane3.Y2Axis.Scale.Min = -50;
			myPane3.Y2Axis.Scale.Max = 50;
			printstart = false;
			zg3.Refresh();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			/*if (zg3.Width != 1047)
			{
				zg3.RestoreScale(zg3.GraphPane);
			}*/
			tapX = 1052;
			tapPage1.Size = new System.Drawing.Size(tapX, 565);
			zg3.Width -= 10;
		//	zg3.RestoreScale(zg3.GraphPane);
			zg3.Size = new Size(1047, 400);
			myPane3.YAxis.Scale.Min =0;
			myPane3.YAxis.Scale.Max = 300;
			myPane3.Y2Axis.Scale.Min = -50;
			myPane3.Y2Axis.Scale.Max = 50;
			myPane3.XAxis.Scale.Max = x_backup;
			myPane3.XAxis.Scale.Min = xbase_backup;



            //  myPane3.XAxis.MajorGrid.IsVisible = true;
            //  myPane3.YAxis.MajorGrid.IsVisible = true;

            myPane3.XAxis.Type = AxisType.Date;
            myPane3.XAxis.Scale.Format = " MMM월dd일 HH:mm"; // 24 hour clock for HH
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			
			m_list.FitToPage = true;
			m_list.PrintPreview();
		}

        private void button2_Click_1(object sender, EventArgs e)
        {
            string SalesTimestr = "";
            string DriveTimestr = "";
            string DriveDist = "";
            string SalesDist = "";

            if (edit_button.Text != "Enter")  // edit mode
            {

                textBox운행시간.ReadOnly = true;
                textBox영업시간.ReadOnly = false;
                textBox주행거리.ReadOnly = false;
                textBox영업거리.ReadOnly = false;
                textBox_carnum.Visible = true;

                textBox_carnum.Text = 차번label.Text;


                DriveTimestr = textBox운행시간.Text;
                textBox운행시간.Text = DriveTimestr.Replace("시간", "$");
                DriveTimestr = textBox운행시간.Text;
                textBox운행시간.Text = DriveTimestr.Replace("분", "");


                SalesTimestr = textBox영업시간.Text;
                textBox영업시간.Text = SalesTimestr.Replace("시간", "$");
                SalesTimestr = textBox영업시간.Text;
                textBox영업시간.Text = SalesTimestr.Replace("분", "");


              DriveDist =  textBox주행거리.Text;
              textBox주행거리.Text = DriveDist.Replace("Km","");
            


              SalesDist = textBox영업거리.Text;
              textBox영업거리.Text = SalesDist.Replace("Km", "");
            

                edit_button.Text = "Enter";
            }
            else
            {
               

             
                 string day="";
                 string hour="";              
                 string min="";
                 int drieday = 0;
                 int drivehour = 0;
                 int drivemin = 0;

    
                 DriveTimestr = textBox운행시간.Text;
                 SalesTimestr = textBox영업시간.Text;
///////////////////////  운행시간 edit
                 bool hourchek = false;
                
                 for (int i = 0; i < DriveTimestr.Length; i++)
                 {



                     if (DriveTimestr[i] == '$')
                     {
                         hourchek =true;
                     }


                     if (DriveTimestr[i] != '$')
                     {
                         if (hourchek == false)
                         {
                             hour += DriveTimestr[i];
                         }
                         else
                         {
                             min += DriveTimestr[i];
                         }
                        
                     }
                    
                 }

                 if (hourchek == false)
                 {
                     MessageBox.Show("운행시간 입력이 잘못 되었습니다.!");
                     return;
                 }



                 textBox운행시간.Text = hour + "시간" + min + "분";
                 drivehour = Int32.Parse(hour);
                 drivemin = Int32.Parse(min);

               
///////////////////////////// 영업시간 edit
                 hourchek = false;
                  day = "";
                  hour = "";
                   min = "";
                  
                   int salesday = 0;
                   int saleshour = 0;
                   int salesmin = 0;
                 for (int i = 0; i < SalesTimestr.Length; i++)
                 {



                     if (SalesTimestr[i] == '$')
                     {
                         hourchek = true;
                     }


                     if (SalesTimestr[i] != '$')
                     {
                         if (hourchek == false)
                         {
                             hour += SalesTimestr[i];
                         }
                         else
                         {
                             min += SalesTimestr[i];
                         }

                     }

                 }

                 if (hourchek == false)
                 {
                     MessageBox.Show("영업시간 입력이 잘못 되었습니다.!");

                     DriveTimestr = textBox운행시간.Text;
                     textBox운행시간.Text = DriveTimestr.Replace("시간", "$");
                     DriveTimestr = textBox운행시간.Text;
                     textBox운행시간.Text = DriveTimestr.Replace("분", "");
                     return;
                 }

                 saleshour = Int32.Parse(hour);
                 salesmin = Int32.Parse(min);


                 textBox영업시간.Text = hour + "시간" + min + "분";


                 int drivertotal = (drivehour * 60) + drivemin;
                 int salestotal = (saleshour * 60) + salesmin;
                 int konhchaTime = drivertotal - salestotal;

                 int khour = konhchaTime / 60;
                 int kmin = konhchaTime % 60;


                 textBox공차시간.Text = khour.ToString() + "시간" + kmin.ToString() + "분";

///////////////////////////////////

                 double drivedist = 0;
                 double salesdist = 0;

                 drivedist = double.Parse(textBox주행거리.Text);
                 salesdist = double.Parse(textBox영업거리.Text);

                 double kdist = drivedist - salesdist;
                 textBox주행거리.Text += " Km";
                 textBox영업거리.Text += " Km";
                 textBox공차거리.Text = string.Format("{0:#.##} Km", kdist.ToString()); 

/////////////////////////////////////////
                 textBox승차율.Text = (tBoxData.i주행거리 > 0) ? String.Format("{0:#.##} %", (salesdist / drivedist) * 100) : "0.00 %";
                 int driveTIme = (saleshour * 60) + salesmin;

                 textBox운행률.Text = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)salestotal) * 100 / (double)drivertotal) : "0.00 %";
                 //	tBoxData.h운행률 = (tBoxData.i운행시간 > 0) ? String.Format("{0:#.##} %", ((double)tBoxData.i주행시간 / (double)tBoxData.i운행시간) * 100) : "0.00 %";
              

                 
                 차번label.Text = textBox_carnum.Text;


                 edit_button.Text = "Edit";
                 textBox_carnum.Visible = false;
                 textBox운행시간.ReadOnly = true;
                 textBox영업시간.ReadOnly = true;
                 textBox주행거리.ReadOnly = true;
                 textBox영업거리.ReadOnly = true;
                
            }
        }

    }
}