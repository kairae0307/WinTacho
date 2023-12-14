using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using ZedGraph;
using System.Threading;
using System.Drawing.Printing;
//using System.Windows.Forms.DataVisualization.Charting;


namespace ConvertTacho
{
    public partial class FormGraph : Form
    {
        public Boolean m_bStart;
		FormData formData;
        private string strTitle = "";

        public bool GraphCut = false;
		public string Time_Temp = "";
		 public byte[] Speed_Temp = new byte[120000];
		public byte[] Distance_Temp = new byte[120000];
		public string Engine_Temp = "";
		public string Sales_Temp = "";
		public string Door_Temp = "";
		public double x_backup = 0;
		public double xbase_backup = 0;
		public int printindex = 1;
		public int graphint = 0;
        public string TACHO2_path = "";
        private iniClass inicls = new iniClass();


		GraphPane myPane1;
		GraphPane myPane2;
		GraphPane myPane3;

	/*	private ToolTip pointToolTip;
		private MasterPane masterPane;
		private string pointValueFormat;
		private bool isShowPointValues;
		private string pointDateFormat;
		private bool isZooming = false;
		private bool isPanning = false;
		private bool isEnableZoom = true;
		private bool isEnablePan = true;
		private GraphPane dragPane = null;
		private Rectangle dragRect;
		private ZoomState zoomState;*/

        public FormGraph(FormData f)
        {
            InitializeComponent();
            m_bStart = true;
			formData = f;
			//Rectangle rect = new Rectangle( 0, 0, this.Size.Width, this.Size.Height );			
		
			//masterPane = new MasterPane("", rect);

		
			//zg1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);

            string path1 = Application.StartupPath + "\\WinTacho.ini";
            TACHO2_path = inicls.GetIniValue("Tacho Init", "path", path1); // 타코 루트
            button1.Visible = false;
            button2.Visible = false;
		
        }

        public void FillData(int index)
        {
           // zg2.GraphPane.CurveList.Clear();
         //   CreateChart(zg2, index);
          //  zg2.RestoreScale(zg2.GraphPane);    // "Set Scale to Default"
           // zg2.IsShowPointValues = true;       // "Show Point Values"
            //zg2.IsShowCursorValues = true;
            SetSize();
			graphint = index;
		//	zg1.GraphPane.CurveList.Clear();
		//	CreateChart(zg1, index);
		//	zg1.RestoreScale(zg1.GraphPane);    // "Set Scale to Default"
		//	zg1.IsShowPointValues = true;       // "Show Point Values"
			//zg2.IsShowCursorValues = true;
			SetSize();


			zg3.GraphPane.CurveList.Clear();
			CreateChart(zg3, index);
			//	zg1.RestoreScale(zg1.GraphPane);    // "Set Scale to Default"
		//	zg3.IsShowPointValues = true;       // "Show Point Values"
			//zg2.IsShowCursorValues = true;
			SetSize();
	

        }

        // Call this method from the Form_Load method, passing your ZedGraphControl
        public void CreateChart(ZedGraphControl zgc, int index)
        {
            try
            {
                string CarNo = "";
                string DriverNo = "";
                DateTime OutTime = new DateTime();
                DateTime InTime = new DateTime();
				/////////

				string DBstring = "";

				string NameDB = "";
				if (formData.Db_backup == true)
				{

                    NameDB = TACHO2_path + "\\" + formData.MdbFileName;
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

                #region 열린 DB 정보 추출 -> 폼 제목 & 프린트 제목용
                {
                    string queryTbl = "SELECT * FROM TblTacho WHERE ID=" + index.ToString();
                    OleDbCommand commReadTbl = new OleDbCommand(queryTbl, conn);
                    OleDbDataReader srReadTbl = commReadTbl.ExecuteReader();

                    while (srReadTbl.Read())
                    {
                        CarNo = srReadTbl.GetString(1);
                        DriverNo = srReadTbl.GetString(2);
                        OutTime = srReadTbl.GetDateTime(4);
                        InTime = srReadTbl.GetDateTime(5);
                    }

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

				string queryRead1 = "SELECT * FROM TblTacho WHERE ID=" + index.ToString();
				OleDbCommand commRead1 = new OleDbCommand(queryRead1, conn);
				OleDbDataReader srRead1 = commRead1.ExecuteReader();

	

				while (srRead1.Read())
				{
					Door_Temp = srRead1.GetString(17);
					Time_Temp = srRead1.GetString(22);  // 그래프 시간 읽기

				//	Speed_Temp = srRead1.GetString(23); // 그래프 속도 일기
					srRead1.GetBytes(23, 0, Speed_Temp, 0, 120000);

				//	Distance_Temp = srRead1.GetString(24); // 거리
					srRead1.GetBytes(24, 0, Distance_Temp, 0, 120000);

					Engine_Temp = srRead1.GetString(25);   // 엔진
					Sales_Temp = srRead1.GetString(26);   // 영업
				}

				char[] time_char = new char[Time_Temp.Length];
			//	char[] Speed_char = new char[Speed_Temp.Length];
				//char[] Distance_char = new char[Distance_Temp.Length];
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

				for(int i=0; i<Door_Temp.Length; i++)
				{
					Door_char[i] = Door_Temp[i];
				}
			
				for (int i = 0; i < Engine_Temp.Length; i++)    //Engine db : string  -> char 
				{
					Engine_char[i] = Engine_Temp[i];
								
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
					distance_double[i] = (double)(Distance_Temp[i]) / 10.0f;
				}

					


                TimeSpan ts = new TimeSpan(0, 0, 0, 0);
                DateTime dt = new DateTime(1, 1, 1, 0, 0, 0);
                bool isDtFilled = false;

                double timeLine = 0;

				
                GraphPane myPane = zgc.GraphPane;

				
                // Set up the title and axis labels

              //  myPane.Title.Text = strTitle;

				/*if (zgc == zg1)
				{
					myPane.Title.Text = strTitle;
					myPane.YAxis.Title.Text = "속도(Km/h)";
					myPane.XAxis.Title.Text = "";
				}*/
			/*	else if (zgc == zg2)
				{
					myPane.Title.Text = "";
					myPane.YAxis.Title.Text = "거리(Km/h)";
					myPane.XAxis.Title.Text = "시간";
				
				}*/
				 if (zgc == zg3)
				{
					myPane.Title.Text = "차번호 :" + CarNo +"  "+ "기사번호 :" +DriverNo;
                 //   myPane.Title.Text = "차번호 :" + CarNo;
                 //   myPane.Title.Text = "차번호 :" + formData.CarArea + " " + formData.CarSign + " " + CarNo; ;
				//	myPane.YAxis.Title.Text = " 영업 / 도어 / 엔진";
					myPane.Y2Axis.Title.Text = "거리(Km/h)";
					myPane.XAxis.Title.Text = "시간";
				}
				
              //  myPane.XAxis.Title.Text = "시간";
                //myPane.XAxis.Title.FontSpec.FontColor = Color.LightPink;
              //  myPane.YAxis.Title.Text = "속도(Km/h)";
                //myPane.YAxis.Title.FontSpec.FontColor = Color.LightSalmon;

                // Make up some data arrays based on the Sine function

			

                PointPairList list1 = new PointPairList();
				PointPairList list2 = new PointPairList();
                PointPairList list3 = new PointPairList();
                PointPairList list4 = new PointPairList();
				PointPairList list5 = new PointPairList();
                PointPairList list6 = new PointPairList();

				bool isFirstGraph = true, isY3Up = false, isY4Up = false, isY5Up = false;

                double x = 0.0, y1 = 0.0, y2 = 0.0, y3 = 0.0, y4 = 0.0, y5 =0.0;
				double a = 0.0f;

				// Enable the Y2 axis display

				double xBase = new XDate(datetime[0]);
				xbase_backup = xBase;
				Engine_char[Engine_char.Length - 1] = '0';
				myPane.XAxis.Scale.Min = xBase;
			
			
				for (int i = 0; i < datetime.Length; i++)
				{
					
					x = new XDate(datetime[i]);   // Time
			

					y1 = (double)Speed_Temp[i];   // 속도


					a += distance_double[i];      // 거리

					int Value = (int)a / 20;

					if(Value %2 ==0)
					{
						y2 = a - (Value*20);

					}
					else
					{
						y2 = 20 - (a-(Value * 20));
					}

			//		y2 = y2 + 150;
				//	double disty = y2 ;
				//	string dist_time = datetime[i].Hour.ToString()+"시" + datetime[i].Minute.ToString() +"분";
					string dist_tag = a.ToString() +"Km";
				dist_tag =  String.Format("{0:#.#}Km", a.ToString());
					if (zgc == zg3)
					{
						list1.Add(x, y1);   // 속도

                        if (y1 >= formData.OverSpeed)
                        {
                            list6.Add(x, y1);
                        }


						list2.Add(x, y2, 0, dist_tag);
						//list2.Add(x, a);
						
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
				if(zgc == zg3)
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
                LineItem myCurve6 = myPane.AddCurve("과속", list6, Color.Red, SymbolType.Circle);
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
			//	YAxis yAxis2 = new YAxis("Distance");
			//	myPane.YAxisList.Add(yAxis2);
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				// Align the Y2 axis labels so they are flush to the axis
				myPane.Y2Axis.Scale.Align = AlignP.Inside;
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				myPane.Y2Axis.MajorGrid.IsVisible = true;
				myPane.Y2Axis.MajorGrid.Color = Color.Black;
				myPane.Y2Axis.MajorGrid.Color = Color.Black;
				myPane.Y2Axis.Scale.Min = -50;
				myPane.Y2Axis.Scale.Max = 50;


				// Create a second Y Axis, green
			/*	YAxis yAxis3 = new YAxis("Break-signal");
				myPane.YAxisList.Add(yAxis3);
				yAxis3.Scale.FontSpec.FontColor = Color.Green;
				yAxis3.Title.FontSpec.FontColor = Color.Green;
				yAxis3.Color = Color.Green;
				// turn off the opposite tics so the Y2 tics don't show up on the Y axis
				yAxis3.MajorTic.IsInside = false;
				yAxis3.MinorTic.IsInside = false;
				yAxis3.MajorTic.IsOpposite = false;
				yAxis3.MinorTic.IsOpposite = false;
				// Align the Y2 axis labels so they are flush to the axis
				yAxis3.Scale.Align = AlignP.Inside;

				yAxis3.Scale.Min = 0;
				yAxis3.Scale.Max = 1000;*/
				
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
			//	myCurve3.Line.Fill = new Fill(Color.White, Color.Red, 45F);
				//myCurve4.Line.Fill = new Fill(Color.White, Color.White, 45F);
				//myCurve5.Line.Fill = new Fill(Color.White, Color.White, 45F);

                // Increase the symbol sizes, and fill them with solid white
                myCurve1.Symbol.Size = 0.5F;
                myCurve2.Symbol.Size = 0.5F;
                myCurve3.Symbol.Size = 0.5F;
                myCurve4.Symbol.Size = 0.5F;
				myCurve5.Symbol.Size = 0.5F;
                myCurve6.Symbol.Size = 5.0F;

                myCurve1.Symbol.Fill = new Fill(Color.White);
                myCurve2.Symbol.Fill = new Fill(Color.White);
                myCurve3.Symbol.Fill = new Fill(Color.White);
                myCurve4.Symbol.Fill = new Fill(Color.White);
				myCurve5.Symbol.Fill = new Fill(Color.White);
                myCurve6.Symbol.Fill = new Fill(Color.Red);

                // Add a background gradient fill to the axis frame
				myPane.Chart.Fill = new Fill(Color.White, Color.AliceBlue, -45F);


                // Set the XAxis to date type
                myPane.XAxis.Type = AxisType.Date;
				 myPane.XAxis.Scale.Max = x;
				x_backup = x;

				/*if (zgc == zg1)
				{
					myPane1 = myPane;
				}*/
			/*	else if (zgc == zg2)
				{
					myPane2 = myPane;
				}*/
				 if (zgc == zg3)
				{
					myPane3 = myPane;
				}

                // Calculate the Axis Scale Ranges
                zgc.AxisChange();

                conn.Close();
			
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

        private void FormGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
			//zg1.RestoreScale(zg1.GraphPane);
			//zg3.RestoreScale(zg3.GraphPane);
		//	zg3.Size = new Size(985, 250);
			//zg1.Size = new Size(985, 250)

			zg3.Width -= 10;
			zg3.RestoreScale(zg3.GraphPane);
			zg3.Size = new Size(1047, 400);
			myPane3.YAxis.Scale.Min = 0;
			myPane3.YAxis.Scale.Max = 300;
			myPane3.Y2Axis.Scale.Min = -50;
			myPane3.Y2Axis.Scale.Max = 50; ;
            label8.Text = "";
            GraphCut = false;

        }

        private void FormGraph_Resize(object sender, EventArgs e)
        {
            //SetSize();
        }

        private void 포인트값보이기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (포인트값보이기ToolStripMenuItem.Checked)
            {
                zg3.IsShowPointValues = false;       // "Show Point Values"
                포인트값보이기ToolStripMenuItem.Checked = false;
            }
            else
            {
                zg3.IsShowPointValues = true;       // "Show Point Values"
                포인트값보이기ToolStripMenuItem.Checked = true;
            }
		
        }
		private Image ImageRender()
		{
		//	return _masterPane.GetImage( _masterPane.IsAntiAlias );
			return zg3.GetImage();
		}
		private void ClipboardCopyThread()
		{
			Clipboard.SetDataObject(ImageRender(), true);
		}

        private void 클립보드로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Copy"
          
			zg3.Copy(true);

		/*	Thread ct = new Thread(new ThreadStart(this.ClipboardCopyThread));
			ct.SetApartmentState(ApartmentState.STA);
			ct.Start();
			ct.Join();*/
        }

        private void 그림파일로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Save Image As..."
          //  zg1.SaveAsBitmap();
			zg3.SaveAsBitmap();
        }

        private void 페이지설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Page Setup..."
            PrintPageSetup_FormGraph();
        }

        private void 미리보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Preview"
            PrintPreview_FormGraph();
        }

        private void 인쇄ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // "Print"
            Print_FormGraph();
        }

        private void 확대실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Un-Zoom"
            zg3.ZoomOut(zg3.GraphPane);
        }

        private void 모든확대실행취소ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            zg3.ZoomOutAll(zg3.GraphPane);
        }

        private void 초기상태로ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
			//zg1.RestoreScale(zg1.GraphPane);
			zg3.RestoreScale(zg3.GraphPane); 
        }

        public void PrintPageSetup_FormGraph()
        {
            zg3.DoPageSetup();
        }

        public void PrintPreview_FormGraph()
        {
			//zg1.DoPrintPreview();
		
			zg3.DoPrintPreview();
		
        }

        public void Print_FormGraph()
        {
            zg3.DoPrint();
        }

	
		private void button1_Click_1(object sender, EventArgs e)
		{
				
			zg3.Width -= 200;
		//	zg3.Size = new Size(zg3.Width -= 200, 400); 


		   
		}

		private void button2_Click(object sender, EventArgs e)
		{

			if (zg3.Width <7047)
			zg3.Width += 200;
	
	//	CreateChart(zg3, graphint);
			//	zg3.Size = new Size(zg3.Width += 200, 400);
						
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DoPrintPreview1();

		
			//zg1.RestoreScale(zg1.GraphPane);
		//	zg3.RestoreScale(zg3.GraphPane); 
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


			BitBlt(dc2, 0, 0, this.ClientRectangle.Width-980, this.ClientRectangle.Height - 140, dc1, 10, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);
		}
		private void DoPrintPreview1()
		{
			
			CaptureScreen();
			curPageNumber = 1;
			 image = zg3.GetImage();
			PrintDocument pd = new PrintDocument();
		
			pd.DefaultPageSettings.Landscape = true;
			
			pd.PrintPage += new PrintPageEventHandler(Graph_PrintPage);
		
			printPreviewDialog1.Document = pd;
	 
			printPreviewDialog1.ShowDialog();
		
		}

		public int curPageNumber;
		public Image image;
		public Image[] imagea;
		int num = 2;
		private void Graph_PrintPage(object sender, PrintPageEventArgs e)
		{
			PrintDocument pd = sender as PrintDocument;

				/*RectangleF saveRect = myPane3.Rect;
				SizeF newSize = myPane3.Rect.Size;
		
				float xRatio = (float)e.MarginBounds.Width / (float)newSize.Width;
				float yRatio = (float)e.MarginBounds.Height / (float)newSize.Height;
				float ratio = Math.Min(xRatio, yRatio);

				String drawString = "속도(Km/h)";
				Font drawFont = new Font("Arial", 8);
				SolidBrush drawBrush = new SolidBrush(Color.Black);

				zg3.Width += 120;
				myPane3.Draw(e.Graphics);*/


		//	printindex++;
		//	CreateChart(zg3, graphint);			
		//	image = zg3.GetImage();
		//	e.Graphics.DrawImage(image, 10, 20);
			

				float x = e.MarginBounds.Left + 50;
				float y = e.MarginBounds.Top + 140;
				float width = 50.0F;
				float height = 50.0F;
				RectangleF drawRect = new RectangleF(x, y, width, height);
		
				int imagey = 20;
				
				//image.Save("c:\\Graph.jpg");
			//	Bitmap b = new Bitmap("c:\\Graph.jpg");
			//	Graphics g = Graphics.FromImage(b);

				
				if (image.Width < 2047)
				{
					num = 2;
				}
				else if(image.Width > 2046 && image.Width <3048)
				{
					num = 3;
				}
		//		else if (image.Width > 3047 && image.Width < 4048)
				else if (image.Width > 3047)
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
				//	Bitmap Target = new Bitmap(LefrSetp, TopStep);
					Bitmap[] Target = new Bitmap[num];


					Graphics TargetG;


					imagea = new Image[num];
					if (image.Width < 1048)
					{
						e.Graphics.DrawImage(image, 10, 20);
					
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
							Target[j] = new Bitmap(Target[j], 950, 400);
							imagea[j] = Target[j];
							
						}
					//	int k = 0;
						for (int i = 0; i < num; i++)
						{
						//	imagea[i] = Image.FromFile("c:\\" + i.ToString() + ".jpg");

							e.Graphics.DrawImage(imagea[i], 90, imagey);
							if (i == 1)
								e.Graphics.DrawImage(memoryImage,20, imagey + 5);
							imagey += 420;
						//	k = 100;
							
						}
						if(num >2)
						{
							e.HasMorePages = true;
							curPageNumber++;
						}

						
					}
				}
				else
				{
					if (num == 3)
					{


						e.Graphics.DrawImage(imagea[2], 90, imagey);
						e.Graphics.DrawImage(memoryImage, 20, imagey + 5);
					}
					else if(num ==4)
					{
						e.Graphics.DrawImage(imagea[2], 90, imagey);
						e.Graphics.DrawImage(memoryImage, 20, imagey+5);
						e.Graphics.DrawImage(imagea[3], 90, imagey+410);
						e.Graphics.DrawImage(memoryImage, 20, imagey + 415);
					}
					curPageNumber = 1;
				//	e.HasMorePages = false;
				
				}
			
				/*		
		
				// Draw rectangle to screen.
				Pen blackPen = new Pen(Color.Black);
				//e.Graphics.DrawRectangle(blackPen, x, y, 40, 40);

				// Set format of string.
				StringFormat drawFormat = new StringFormat();
				drawFormat.Alignment = StringAlignment.Center;

				// Draw string to screen.
				drawRect = new RectangleF(x-60 , y, width, height);
				e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

				drawString = "엔진";
				drawRect = new RectangleF(x-60, y-220 , width, height);
				e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

				drawString = "도어";
				drawRect = new RectangleF(x-60, y -190, width, height);
				e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


				drawString = "영업";
				drawRect = new RectangleF(x-60, y -160, width, height);
				e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);


				drawString = "거리(Km/h)";
				drawRect = new RectangleF(x-60, y - 130, width, height);
				e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);		
			 */
			
		}
		

		private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
				  ZoomState newState)
		{
			// Here we get notification everytime the user zooms
		}

		private void printPreviewDialog1_FormClosing(object sender, FormClosingEventArgs e)
		{

			zg3.Width -= 10;
			zg3.RestoreScale(zg3.GraphPane);
			//zg3.Size = new Size(1047, 400);
			myPane3.YAxis.Scale.Min = 0;
			myPane3.YAxis.Scale.Max = 300;
			myPane3.Y2Axis.Scale.Min = -50;
			myPane3.Y2Axis.Scale.Max = 50;
			zg3.Refresh();
			//button4_Click(sender, e);
					
		}
        string TImeStr = "";         // 그래프 x 값(시간)
        double doubleTime = 0;

		private void button4_Click(object sender, EventArgs e)
		{
           
		//	zg1.RestoreScale(zg1.GraphPane);
			

			/*if(zg3.Width !=1047)
			{
				zg3.RestoreScale(zg3.GraphPane);
			}*/
            myPane3.Chart.Fill = new Fill(Color.White, Color.AliceBlue, -45F);
			zg3.Width -= 10;
			zg3.RestoreScale(zg3.GraphPane);
			zg3.Size = new Size(1047, 400);
			myPane3.YAxis.Scale.Min = 0;
			myPane3.YAxis.Scale.Max = 300;
			myPane3.Y2Axis.Scale.Min = -50;
			myPane3.Y2Axis.Scale.Max = 50;
			myPane3.XAxis.Scale.Max = x_backup;
			myPane3.XAxis.Scale.Min = xbase_backup;
            GraphCut = false;
            label8.Text = "";

            myPane3.XAxis.MajorGrid.IsVisible = true;
            myPane3.YAxis.MajorGrid.IsVisible = true;
            myPane3.XAxis.MajorGrid.Color = Color.Black;
            myPane3.YAxis.MajorGrid.Color = Color.Black;
            myPane3.XAxis.Type = AxisType.Date;
            myPane3.XAxis.Scale.Format = " MMM월dd일 HH:mm"; // 24 hour clock for HH
          
         

		}
      //  double xval = 0;
      //  string xval_str = "";
        private bool zg3_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
           formData.xval = zg3.XValue;
           formData.xval_str = XDate.ToString(formData.xval, XDate.DefaultFormatStr);


           if (GraphCut == true)
           {
               label8.BackColor = Color.Yellow;
               label8.Text = "자르기 기준 시간 :" + formData.xval_str;
           }
        //    MessageBox.Show(xval_str);
            return default(bool);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime xtime = new XDate(formData.xval);
            if (xtime.Year < 2000)
            {
                MessageBox.Show("기준시간을 다시 설정하여 주세요");
                zg3.Width -= 10;
                zg3.RestoreScale(zg3.GraphPane);
                zg3.Size = new Size(1047, 400);
                myPane3.YAxis.Scale.Min = 0;
                myPane3.YAxis.Scale.Max = 300;
                myPane3.Y2Axis.Scale.Min = -50;
                myPane3.Y2Axis.Scale.Max = 50;
                myPane3.XAxis.Type = AxisType.Date;
              
                myPane3.XAxis.Scale.Max = x_backup;
                myPane3.XAxis.Scale.Min = xbase_backup;
                GraphCut = false;
                label8.Text = "";
                return;
            }
            formData.TachoCut = true;
            FormMdbList formMdbList = new FormMdbList(formData);

           // formMdbList.checkBox1.Checked = true;

            formMdbList.Show();
            label8.Text = "";
           
        }

        private void 자르기모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphCut = true;
            myPane3.Chart.Fill = new Fill(Color.White, Color.SeaShell, 0);
            zg3.Width += 1;
            /*
            myPane3.Chart.Fill = new Fill(Color.White, Color.SeaShell, 0);
            zg3.Size = new Size(1047, 400);
            zg3.Width -= 10;
            zg3.RestoreScale(zg3.GraphPane);
            zg3.Size = new Size(1047, 400);
            myPane3.YAxis.Scale.Min = 0;
            myPane3.YAxis.Scale.Max = 300;
            myPane3.Y2Axis.Scale.Min = -50;
            myPane3.Y2Axis.Scale.Max = 50;
            myPane3.XAxis.Type = AxisType.Date;
            myPane3.XAxis.Scale.Max = x_backup;
            myPane3.XAxis.Scale.Min = xbase_backup;

            myPane3.XAxis.MajorGrid.IsVisible = true;
            myPane3.YAxis.MajorGrid.IsVisible = true;
            myPane3.XAxis.MajorGrid.Color = Color.Black;
            myPane3.YAxis.MajorGrid.Color = Color.Black;
            myPane3.XAxis.Type = AxisType.Date;
            myPane3.XAxis.Scale.Format = " MMM월dd일 HH:mm"; // 24 hour clock for HH*/
         
        }
					
	}
}