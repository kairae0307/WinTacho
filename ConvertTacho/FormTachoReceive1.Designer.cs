namespace ConvertTacho
{
    partial class FormTachoReceive1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTachoReceive1));
            this.spTimer = new System.Timers.Timer();
            this.radioButton수집기 = new System.Windows.Forms.RadioButton();
            this.radioButton자동수신 = new System.Windows.Forms.RadioButton();
            this.radioButton유선수신 = new System.Windows.Forms.RadioButton();
            this.radioButton판독기직렬 = new System.Windows.Forms.RadioButton();
            this.radioButton판독기병렬 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOldFileLoad = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button통신설정 = new System.Windows.Forms.Button();
            this.button수신시작 = new System.Windows.Forms.Button();
            this.button수신종료 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1_Ani_0 = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1_Base = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_타코 = new System.Windows.Forms.RadioButton();
            this.radioButton_일별자르기 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_OneDay = new System.Windows.Forms.RadioButton();
            this.radioButton_PM = new System.Windows.Forms.RadioButton();
            this.radioButton_AM = new System.Windows.Forms.RadioButton();
            this.numericUpDown_Day = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_Month = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_Year = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton_UserTime = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_타코자동분리 = new System.Windows.Forms.RadioButton();
            this.radioButton_교대시간 = new System.Windows.Forms.RadioButton();
            this.AMtextBox = new System.Windows.Forms.TextBox();
            this.PMtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).BeginInit();
            this.SuspendLayout();
            // 
            // spTimer
            // 
            this.spTimer.Enabled = true;
            this.spTimer.SynchronizingObject = this;
            this.spTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.spTimer_Elapsed);
            // 
            // radioButton수집기
            // 
            this.radioButton수집기.AutoSize = true;
            this.radioButton수집기.Location = new System.Drawing.Point(15, 20);
            this.radioButton수집기.Name = "radioButton수집기";
            this.radioButton수집기.Size = new System.Drawing.Size(93, 16);
            this.radioButton수집기.TabIndex = 5;
            this.radioButton수집기.Text = "수집기(신형)";
            this.radioButton수집기.UseVisualStyleBackColor = true;
            this.radioButton수집기.CheckedChanged += new System.EventHandler(this.radioButton수집기_CheckedChanged);
            // 
            // radioButton자동수신
            // 
            this.radioButton자동수신.AutoSize = true;
            this.radioButton자동수신.Location = new System.Drawing.Point(15, 42);
            this.radioButton자동수신.Name = "radioButton자동수신";
            this.radioButton자동수신.Size = new System.Drawing.Size(100, 16);
            this.radioButton자동수신.TabIndex = 6;
            this.radioButton자동수신.Text = "자동수신(IRD)";
            this.radioButton자동수신.UseVisualStyleBackColor = true;
            this.radioButton자동수신.CheckedChanged += new System.EventHandler(this.radioButton자동수신_CheckedChanged);
            // 
            // radioButton유선수신
            // 
            this.radioButton유선수신.AutoSize = true;
            this.radioButton유선수신.Location = new System.Drawing.Point(15, 65);
            this.radioButton유선수신.Name = "radioButton유선수신";
            this.radioButton유선수신.Size = new System.Drawing.Size(71, 16);
            this.radioButton유선수신.TabIndex = 7;
            this.radioButton유선수신.Text = "유선수신";
            this.radioButton유선수신.UseVisualStyleBackColor = true;
            this.radioButton유선수신.CheckedChanged += new System.EventHandler(this.radioButton유선수신_CheckedChanged);
            // 
            // radioButton판독기직렬
            // 
            this.radioButton판독기직렬.AutoSize = true;
            this.radioButton판독기직렬.Location = new System.Drawing.Point(152, 20);
            this.radioButton판독기직렬.Name = "radioButton판독기직렬";
            this.radioButton판독기직렬.Size = new System.Drawing.Size(93, 16);
            this.radioButton판독기직렬.TabIndex = 8;
            this.radioButton판독기직렬.Text = "판독기(직렬)";
            this.radioButton판독기직렬.UseVisualStyleBackColor = true;
            this.radioButton판독기직렬.CheckedChanged += new System.EventHandler(this.radioButton판독기직렬_CheckedChanged);
            // 
            // radioButton판독기병렬
            // 
            this.radioButton판독기병렬.AutoSize = true;
            this.radioButton판독기병렬.Location = new System.Drawing.Point(152, 42);
            this.radioButton판독기병렬.Name = "radioButton판독기병렬";
            this.radioButton판독기병렬.Size = new System.Drawing.Size(93, 16);
            this.radioButton판독기병렬.TabIndex = 9;
            this.radioButton판독기병렬.Text = "판독기(병렬)";
            this.radioButton판독기병렬.UseVisualStyleBackColor = true;
            this.radioButton판독기병렬.CheckedChanged += new System.EventHandler(this.radioButton판독기병렬_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(85, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOldFileLoad);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.radioButton판독기병렬);
            this.groupBox2.Controls.Add(this.radioButton판독기직렬);
            this.groupBox2.Controls.Add(this.radioButton유선수신);
            this.groupBox2.Controls.Add(this.radioButton자동수신);
            this.groupBox2.Controls.Add(this.radioButton수집기);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 102);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "수신장치 선택";
            // 
            // buttonOldFileLoad
            // 
            this.buttonOldFileLoad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonOldFileLoad.Location = new System.Drawing.Point(147, 65);
            this.buttonOldFileLoad.Name = "buttonOldFileLoad";
            this.buttonOldFileLoad.Size = new System.Drawing.Size(113, 31);
            this.buttonOldFileLoad.TabIndex = 12;
            this.buttonOldFileLoad.Text = "TMP 파일 변환";
            this.buttonOldFileLoad.UseVisualStyleBackColor = false;
            this.buttonOldFileLoad.Click += new System.EventHandler(this.buttonOldFileLoad_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(13, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "(0: 모든 데이터 수신)";
            // 
            // button통신설정
            // 
            this.button통신설정.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button통신설정.Location = new System.Drawing.Point(168, 16);
            this.button통신설정.Name = "button통신설정";
            this.button통신설정.Size = new System.Drawing.Size(91, 32);
            this.button통신설정.TabIndex = 14;
            this.button통신설정.Text = "통신설정";
            this.button통신설정.UseVisualStyleBackColor = false;
            this.button통신설정.Click += new System.EventHandler(this.button2_Click);
            // 
            // button수신시작
            // 
            this.button수신시작.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button수신시작.Location = new System.Drawing.Point(14, 16);
            this.button수신시작.Name = "button수신시작";
            this.button수신시작.Size = new System.Drawing.Size(133, 32);
            this.button수신시작.TabIndex = 15;
            this.button수신시작.Text = "수신시작";
            this.button수신시작.UseVisualStyleBackColor = false;
            this.button수신시작.Click += new System.EventHandler(this.button3_Click);
            // 
            // button수신종료
            // 
            this.button수신종료.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button수신종료.Location = new System.Drawing.Point(168, 61);
            this.button수신종료.Name = "button수신종료";
            this.button수신종료.Size = new System.Drawing.Size(91, 30);
            this.button수신종료.TabIndex = 17;
            this.button수신종료.Text = "수신종료";
            this.button수신종료.UseVisualStyleBackColor = false;
            this.button수신종료.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "처 리:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1113, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 651);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "수 신:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 656);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 36;
            // 
            // label1_Ani_0
            // 
            this.label1_Ani_0.Image = ((System.Drawing.Image)(resources.GetObject("label1_Ani_0.Image")));
            this.label1_Ani_0.Location = new System.Drawing.Point(55, 60);
            this.label1_Ani_0.Name = "label1_Ani_0";
            this.label1_Ani_0.Size = new System.Drawing.Size(100, 31);
            this.label1_Ani_0.TabIndex = 39;
            this.label1_Ani_0.Visible = false;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "구분";
            this.columnHeader4.Width = 45;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.Location = new System.Drawing.Point(291, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(820, 577);
            this.listView1.TabIndex = 37;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "차량번호";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "출고 일시";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "입고 일시";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "주행Km";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "영업Km";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "미터금";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "실입금";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 100;
            // 
            // label1_Base
            // 
            this.label1_Base.Image = ((System.Drawing.Image)(resources.GetObject("label1_Base.Image")));
            this.label1_Base.Location = new System.Drawing.Point(55, 60);
            this.label1_Base.Name = "label1_Base";
            this.label1_Base.Size = new System.Drawing.Size(100, 31);
            this.label1_Base.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label1_Base);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button수신종료);
            this.groupBox1.Controls.Add(this.button수신시작);
            this.groupBox1.Controls.Add(this.button통신설정);
            this.groupBox1.Controls.Add(this.label1_Ani_0);
            this.groupBox1.Location = new System.Drawing.Point(14, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 99);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터 수신";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 134);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 10);
            this.progressBar1.TabIndex = 40;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(14, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 218);
            this.label1.TabIndex = 41;
            this.label1.Text = "                         ";
            // 
            // radioButton_타코
            // 
            this.radioButton_타코.AutoSize = true;
            this.radioButton_타코.Location = new System.Drawing.Point(4, 5);
            this.radioButton_타코.Name = "radioButton_타코";
            this.radioButton_타코.Size = new System.Drawing.Size(65, 16);
            this.radioButton_타코.TabIndex = 6;
            this.radioButton_타코.Text = "1. 타코 ";
            this.radioButton_타코.UseVisualStyleBackColor = true;
            // 
            // radioButton_일별자르기
            // 
            this.radioButton_일별자르기.AutoSize = true;
            this.radioButton_일별자르기.Location = new System.Drawing.Point(120, 5);
            this.radioButton_일별자르기.Name = "radioButton_일별자르기";
            this.radioButton_일별자르기.Size = new System.Drawing.Size(129, 16);
            this.radioButton_일별자르기.TabIndex = 14;
            this.radioButton_일별자르기.Text = "2. 타코 일별 자르기";
            this.radioButton_일별자르기.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.numericUpDown_Day);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.numericUpDown_Month);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.numericUpDown_Year);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radioButton_UserTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButton_타코자동분리);
            this.panel1.Controls.Add(this.radioButton_교대시간);
            this.panel1.Controls.Add(this.AMtextBox);
            this.panel1.Controls.Add(this.radioButton_일별자르기);
            this.panel1.Controls.Add(this.radioButton_타코);
            this.panel1.Controls.Add(this.PMtextBox);
            this.panel1.Location = new System.Drawing.Point(13, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 181);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton_OneDay);
            this.panel2.Controls.Add(this.radioButton_PM);
            this.panel2.Controls.Add(this.radioButton_AM);
            this.panel2.Location = new System.Drawing.Point(120, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 20);
            this.panel2.TabIndex = 58;
            // 
            // radioButton_OneDay
            // 
            this.radioButton_OneDay.AutoSize = true;
            this.radioButton_OneDay.Location = new System.Drawing.Point(3, 6);
            this.radioButton_OneDay.Name = "radioButton_OneDay";
            this.radioButton_OneDay.Size = new System.Drawing.Size(53, 16);
            this.radioButton_OneDay.TabIndex = 58;
            this.radioButton_OneDay.Text = "None";
            this.radioButton_OneDay.UseVisualStyleBackColor = true;
            // 
            // radioButton_PM
            // 
            this.radioButton_PM.AutoSize = true;
            this.radioButton_PM.Location = new System.Drawing.Point(98, 6);
            this.radioButton_PM.Name = "radioButton_PM";
            this.radioButton_PM.Size = new System.Drawing.Size(42, 16);
            this.radioButton_PM.TabIndex = 57;
            this.radioButton_PM.Text = "PM";
            this.radioButton_PM.UseVisualStyleBackColor = true;
            // 
            // radioButton_AM
            // 
            this.radioButton_AM.AutoSize = true;
            this.radioButton_AM.Location = new System.Drawing.Point(56, 6);
            this.radioButton_AM.Name = "radioButton_AM";
            this.radioButton_AM.Size = new System.Drawing.Size(42, 16);
            this.radioButton_AM.TabIndex = 56;
            this.radioButton_AM.Text = "AM";
            this.radioButton_AM.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Day
            // 
            this.numericUpDown_Day.Location = new System.Drawing.Point(188, 146);
            this.numericUpDown_Day.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_Day.Name = "numericUpDown_Day";
            this.numericUpDown_Day.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown_Day.TabIndex = 55;
            this.numericUpDown_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label14.Location = new System.Drawing.Point(243, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 54;
            this.label14.Text = "일";
            // 
            // numericUpDown_Month
            // 
            this.numericUpDown_Month.Location = new System.Drawing.Point(103, 146);
            this.numericUpDown_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_Month.Name = "numericUpDown_Month";
            this.numericUpDown_Month.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown_Month.TabIndex = 53;
            this.numericUpDown_Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label13.Location = new System.Drawing.Point(160, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 52;
            this.label13.Text = "월";
            // 
            // numericUpDown_Year
            // 
            this.numericUpDown_Year.Location = new System.Drawing.Point(13, 146);
            this.numericUpDown_Year.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_Year.Name = "numericUpDown_Year";
            this.numericUpDown_Year.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown_Year.TabIndex = 51;
            this.numericUpDown_Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label7.Location = new System.Drawing.Point(70, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 50;
            this.label7.Text = "년";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(-1, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "--------------------------------------";
            // 
            // radioButton_UserTime
            // 
            this.radioButton_UserTime.AutoSize = true;
            this.radioButton_UserTime.Location = new System.Drawing.Point(4, 121);
            this.radioButton_UserTime.Name = "radioButton_UserTime";
            this.radioButton_UserTime.Size = new System.Drawing.Size(117, 16);
            this.radioButton_UserTime.TabIndex = 47;
            this.radioButton_UserTime.Text = "5. 날짜입력 타코 ";
            this.radioButton_UserTime.UseVisualStyleBackColor = true;
            this.radioButton_UserTime.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(-2, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "--------------------------------------";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label12.Location = new System.Drawing.Point(131, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "교대시간(AM) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label3.Location = new System.Drawing.Point(131, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "교대시간(PM) :";
            // 
            // radioButton_타코자동분리
            // 
            this.radioButton_타코자동분리.AutoSize = true;
            this.radioButton_타코자동분리.Location = new System.Drawing.Point(120, 34);
            this.radioButton_타코자동분리.Name = "radioButton_타코자동분리";
            this.radioButton_타코자동분리.Size = new System.Drawing.Size(113, 16);
            this.radioButton_타코자동분리.TabIndex = 23;
            this.radioButton_타코자동분리.Text = "4. 타코 자동분리";
            this.radioButton_타코자동분리.UseVisualStyleBackColor = true;
            // 
            // radioButton_교대시간
            // 
            this.radioButton_교대시간.AutoSize = true;
            this.radioButton_교대시간.Location = new System.Drawing.Point(4, 66);
            this.radioButton_교대시간.Name = "radioButton_교대시간";
            this.radioButton_교대시간.Size = new System.Drawing.Size(125, 16);
            this.radioButton_교대시간.TabIndex = 15;
            this.radioButton_교대시간.Text = "3.교대 시간별 분리";
            this.radioButton_교대시간.UseVisualStyleBackColor = true;
            // 
            // AMtextBox
            // 
            this.AMtextBox.Location = new System.Drawing.Point(224, 63);
            this.AMtextBox.MaxLength = 2;
            this.AMtextBox.Name = "AMtextBox";
            this.AMtextBox.Size = new System.Drawing.Size(39, 21);
            this.AMtextBox.TabIndex = 22;
            this.AMtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AMtextBox_KeyPress);
            // 
            // PMtextBox
            // 
            this.PMtextBox.Location = new System.Drawing.Point(224, 87);
            this.PMtextBox.MaxLength = 2;
            this.PMtextBox.Name = "PMtextBox";
            this.PMtextBox.Size = new System.Drawing.Size(39, 21);
            this.PMtextBox.TabIndex = 23;
            this.PMtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PMtextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 646);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(291, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "데이터 삭제";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // FormTachoReceive1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 668);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTachoReceive1";
            this.Text = "타코 데이터 수신";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTachoReceive_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.spTimer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.RadioButton radioButton수집기;
        private System.Windows.Forms.RadioButton radioButton자동수신;
        private System.Windows.Forms.RadioButton radioButton유선수신;
        private System.Windows.Forms.RadioButton radioButton판독기직렬;
        private System.Windows.Forms.RadioButton radioButton판독기병렬;
        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button통신설정;
        private System.Windows.Forms.Button button수신시작;
        private System.Windows.Forms.Button button수신종료;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1_Ani_0;
        private System.Windows.Forms.Label label1_Base;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOldFileLoad;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButton_일별자르기;
		private System.Windows.Forms.RadioButton radioButton_타코;
		private System.Windows.Forms.RadioButton radioButton_교대시간;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox AMtextBox;
		private System.Windows.Forms.TextBox PMtextBox;
		private System.Windows.Forms.RadioButton radioButton_타코자동분리;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_UserTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_Year;
        private System.Windows.Forms.NumericUpDown numericUpDown_Day;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_Month;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_PM;
        private System.Windows.Forms.RadioButton radioButton_AM;
        private System.Windows.Forms.RadioButton radioButton_OneDay;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button1;
    }
}