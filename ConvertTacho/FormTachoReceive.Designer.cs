namespace ConvertTacho
{
    partial class FormTachoReceive
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTachoReceive));
            this.spTimer = new System.Timers.Timer();
            this.radioButton수집기 = new System.Windows.Forms.RadioButton();
            this.radioButton자동수신 = new System.Windows.Forms.RadioButton();
            this.radioButton유선수신 = new System.Windows.Forms.RadioButton();
            this.radioButton판독기직렬 = new System.Windows.Forms.RadioButton();
            this.radioButton판독기병렬 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button통신설정 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonOldFileLoad = new System.Windows.Forms.Button();
            this.button수신시작 = new System.Windows.Forms.Button();
            this.button수신종료 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1_Ani_0 = new System.Windows.Forms.Label();
            this.label1_Base = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2_Base = new System.Windows.Forms.Label();
            this.comboBoxPort2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1_Ani_1 = new System.Windows.Forms.Label();
            this.spTimer1 = new System.Timers.Timer();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTotalMoney = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label3_Base = new System.Windows.Forms.Label();
            this.comboBoxPort3 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2_Ani_1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label4_Base = new System.Windows.Forms.Label();
            this.comboBoxPort4 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label3_Ani_1 = new System.Windows.Forms.Label();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort4 = new System.IO.Ports.SerialPort(this.components);
            this.spTimer2 = new System.Timers.Timer();
            this.spTimer3 = new System.Timers.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.PMtextBox = new System.Windows.Forms.TextBox();
            this.radioButton_타코 = new System.Windows.Forms.RadioButton();
            this.radioButton_일별자르기 = new System.Windows.Forms.RadioButton();
            this.AMtextBox = new System.Windows.Forms.TextBox();
            this.radioButton_교대시간 = new System.Windows.Forms.RadioButton();
            this.radioButton_타코자동분리 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer3)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.radioButton판독기직렬.Location = new System.Drawing.Point(15, 122);
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
            this.radioButton판독기병렬.Location = new System.Drawing.Point(15, 101);
            this.radioButton판독기병렬.Name = "radioButton판독기병렬";
            this.radioButton판독기병렬.Size = new System.Drawing.Size(93, 16);
            this.radioButton판독기병렬.TabIndex = 9;
            this.radioButton판독기병렬.Text = "판독기(병렬)";
            this.radioButton판독기병렬.UseVisualStyleBackColor = true;
            this.radioButton판독기병렬.CheckedChanged += new System.EventHandler(this.radioButton판독기병렬_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox1.Location = new System.Drawing.Point(85, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.radioButton판독기병렬);
            this.groupBox2.Controls.Add(this.button통신설정);
            this.groupBox2.Controls.Add(this.radioButton판독기직렬);
            this.groupBox2.Controls.Add(this.radioButton유선수신);
            this.groupBox2.Controls.Add(this.radioButton자동수신);
            this.groupBox2.Controls.Add(this.radioButton수집기);
            this.groupBox2.Location = new System.Drawing.Point(693, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 140);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "수신장치 선택";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(5, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "(0: 모든 데이터 수신)";
            // 
            // button통신설정
            // 
            this.button통신설정.Location = new System.Drawing.Point(-26, -11);
            this.button통신설정.Name = "button통신설정";
            this.button통신설정.Size = new System.Drawing.Size(91, 32);
            this.button통신설정.TabIndex = 14;
            this.button통신설정.Text = "통신설정";
            this.button통신설정.UseVisualStyleBackColor = true;
            this.button통신설정.Visible = false;
            this.button통신설정.Click += new System.EventHandler(this.button2_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(211, 20);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(72, 43);
            this.button9.TabIndex = 42;
            this.button9.Text = " 판독기    삭제";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(111, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 43);
            this.button3.TabIndex = 13;
            this.button3.Text = "판독기   수신";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 43);
            this.button6.TabIndex = 14;
            this.button6.Text = "IRD 수신";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonOldFileLoad
            // 
            this.buttonOldFileLoad.Location = new System.Drawing.Point(500, -11);
            this.buttonOldFileLoad.Name = "buttonOldFileLoad";
            this.buttonOldFileLoad.Size = new System.Drawing.Size(67, 43);
            this.buttonOldFileLoad.TabIndex = 12;
            this.buttonOldFileLoad.Text = "TMP 파일 변환";
            this.buttonOldFileLoad.UseVisualStyleBackColor = true;
            this.buttonOldFileLoad.Click += new System.EventHandler(this.buttonOldFileLoad_Click);
            // 
            // button수신시작
            // 
            this.button수신시작.Location = new System.Drawing.Point(9, 18);
            this.button수신시작.Name = "button수신시작";
            this.button수신시작.Size = new System.Drawing.Size(110, 27);
            this.button수신시작.TabIndex = 15;
            this.button수신시작.Text = "수신시작";
            this.button수신시작.UseVisualStyleBackColor = true;
            this.button수신시작.Click += new System.EventHandler(this.button3_Click);
            // 
            // button수신종료
            // 
            this.button수신종료.Location = new System.Drawing.Point(9, 49);
            this.button수신종료.Name = "button수신종료";
            this.button수신종료.Size = new System.Drawing.Size(110, 27);
            this.button수신종료.TabIndex = 17;
            this.button수신종료.Text = "수신종료";
            this.button수신종료.UseVisualStyleBackColor = true;
            this.button수신종료.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "처 리:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 651);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "수신상태";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "수 신:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 36;
            this.label11.Text = "1";
            // 
            // label1_Ani_0
            // 
            this.label1_Ani_0.Image = ((System.Drawing.Image)(resources.GetObject("label1_Ani_0.Image")));
            this.label1_Ani_0.Location = new System.Drawing.Point(42, 82);
            this.label1_Ani_0.Name = "label1_Ani_0";
            this.label1_Ani_0.Size = new System.Drawing.Size(100, 31);
            this.label1_Ani_0.TabIndex = 39;
            this.label1_Ani_0.Visible = false;
            // 
            // label1_Base
            // 
            this.label1_Base.Image = ((System.Drawing.Image)(resources.GetObject("label1_Base.Image")));
            this.label1_Base.Location = new System.Drawing.Point(42, 82);
            this.label1_Base.Name = "label1_Base";
            this.label1_Base.Size = new System.Drawing.Size(100, 31);
            this.label1_Base.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.comboBoxPort);
            this.groupBox1.Controls.Add(this.label1_Base);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button수신종료);
            this.groupBox1.Controls.Add(this.button수신시작);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1_Ani_0);
            this.groupBox1.Location = new System.Drawing.Point(4, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 117);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터 수신_1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(135, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 44;
            this.label17.Text = "Port :";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(174, 18);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(93, 20);
            this.comboBoxPort.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label2_Base);
            this.groupBox3.Controls.Add(this.comboBoxPort2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label1_Ani_1);
            this.groupBox3.Location = new System.Drawing.Point(4, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 121);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "데이터 수신_2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(165, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 12);
            this.label26.TabIndex = 46;
            this.label26.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(138, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 46;
            this.label13.Text = "Port :";
            // 
            // label2_Base
            // 
            this.label2_Base.Image = ((System.Drawing.Image)(resources.GetObject("label2_Base.Image")));
            this.label2_Base.Location = new System.Drawing.Point(45, 81);
            this.label2_Base.Name = "label2_Base";
            this.label2_Base.Size = new System.Drawing.Size(100, 31);
            this.label2_Base.TabIndex = 38;
            // 
            // comboBoxPort2
            // 
            this.comboBoxPort2.FormattingEnabled = true;
            this.comboBoxPort2.Location = new System.Drawing.Point(176, 17);
            this.comboBoxPort2.Name = "comboBoxPort2";
            this.comboBoxPort2.Size = new System.Drawing.Size(92, 20);
            this.comboBoxPort2.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 12);
            this.label14.TabIndex = 18;
            this.label14.Text = "수 신:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "처 리:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 27);
            this.button1.TabIndex = 17;
            this.button1.Text = "수신종료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 27);
            this.button2.TabIndex = 15;
            this.button2.Text = "수신시작";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1_Ani_1
            // 
            this.label1_Ani_1.Image = ((System.Drawing.Image)(resources.GetObject("label1_Ani_1.Image")));
            this.label1_Ani_1.Location = new System.Drawing.Point(45, 81);
            this.label1_Ani_1.Name = "label1_Ani_1";
            this.label1_Ani_1.Size = new System.Drawing.Size(100, 31);
            this.label1_Ani_1.TabIndex = 41;
            this.label1_Ani_1.Visible = false;
            // 
            // spTimer1
            // 
            this.spTimer1.Enabled = true;
            this.spTimer1.SynchronizingObject = this;
            this.spTimer1.Elapsed += new System.Timers.ElapsedEventHandler(this.spTimer1_Elapsed);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(316, 191);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 12);
            this.label16.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "총수입금(원)";
            this.label5.Visible = false;
            // 
            // textBoxTotalMoney
            // 
            this.textBoxTotalMoney.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTotalMoney.Location = new System.Drawing.Point(0, -6);
            this.textBoxTotalMoney.Name = "textBoxTotalMoney";
            this.textBoxTotalMoney.ReadOnly = true;
            this.textBoxTotalMoney.Size = new System.Drawing.Size(91, 21);
            this.textBoxTotalMoney.TabIndex = 21;
            this.textBoxTotalMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTotalMoney.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, -1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 10);
            this.progressBar1.TabIndex = 40;
            this.progressBar1.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label3_Base);
            this.groupBox4.Controls.Add(this.comboBoxPort3);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.label2_Ani_1);
            this.groupBox4.Location = new System.Drawing.Point(2, 342);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(281, 124);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "데이터 수신_3";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(167, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(11, 12);
            this.label27.TabIndex = 47;
            this.label27.Text = "3";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(138, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 12);
            this.label21.TabIndex = 48;
            this.label21.Text = "Port :";
            // 
            // label3_Base
            // 
            this.label3_Base.Image = ((System.Drawing.Image)(resources.GetObject("label3_Base.Image")));
            this.label3_Base.Location = new System.Drawing.Point(47, 82);
            this.label3_Base.Name = "label3_Base";
            this.label3_Base.Size = new System.Drawing.Size(100, 31);
            this.label3_Base.TabIndex = 38;
            // 
            // comboBoxPort3
            // 
            this.comboBoxPort3.FormattingEnabled = true;
            this.comboBoxPort3.Location = new System.Drawing.Point(178, 16);
            this.comboBoxPort3.Name = "comboBoxPort3";
            this.comboBoxPort3.Size = new System.Drawing.Size(92, 20);
            this.comboBoxPort3.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(167, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 43;
            this.label18.Text = "3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 12);
            this.label19.TabIndex = 18;
            this.label19.Text = "수 신:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 101);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 12);
            this.label20.TabIndex = 18;
            this.label20.Text = "처 리:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 27);
            this.button4.TabIndex = 17;
            this.button4.Text = "수신종료";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 27);
            this.button5.TabIndex = 15;
            this.button5.Text = "수신시작";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label2_Ani_1
            // 
            this.label2_Ani_1.Image = ((System.Drawing.Image)(resources.GetObject("label2_Ani_1.Image")));
            this.label2_Ani_1.Location = new System.Drawing.Point(47, 82);
            this.label2_Ani_1.Name = "label2_Ani_1";
            this.label2_Ani_1.Size = new System.Drawing.Size(100, 31);
            this.label2_Ani_1.TabIndex = 41;
            this.label2_Ani_1.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label4_Base);
            this.groupBox5.Controls.Add(this.comboBoxPort4);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.label3_Ani_1);
            this.groupBox5.Location = new System.Drawing.Point(4, 478);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(279, 123);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "데이터 수신_4";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(168, 64);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(11, 12);
            this.label28.TabIndex = 49;
            this.label28.Text = "4";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(138, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 12);
            this.label22.TabIndex = 50;
            this.label22.Text = "Port :";
            // 
            // label4_Base
            // 
            this.label4_Base.Image = ((System.Drawing.Image)(resources.GetObject("label4_Base.Image")));
            this.label4_Base.Location = new System.Drawing.Point(42, 86);
            this.label4_Base.Name = "label4_Base";
            this.label4_Base.Size = new System.Drawing.Size(100, 31);
            this.label4_Base.TabIndex = 38;
            // 
            // comboBoxPort4
            // 
            this.comboBoxPort4.FormattingEnabled = true;
            this.comboBoxPort4.Location = new System.Drawing.Point(179, 18);
            this.comboBoxPort4.Name = "comboBoxPort4";
            this.comboBoxPort4.Size = new System.Drawing.Size(89, 20);
            this.comboBoxPort4.TabIndex = 49;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(168, 91);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 43;
            this.label23.Text = "4";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 86);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 12);
            this.label24.TabIndex = 18;
            this.label24.Text = "수 신:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 105);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 12);
            this.label25.TabIndex = 18;
            this.label25.Text = "처 리:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 49);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 27);
            this.button7.TabIndex = 17;
            this.button7.Text = "수신종료";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 18);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(110, 27);
            this.button8.TabIndex = 15;
            this.button8.Text = "수신시작";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3_Ani_1
            // 
            this.label3_Ani_1.Image = ((System.Drawing.Image)(resources.GetObject("label3_Ani_1.Image")));
            this.label3_Ani_1.Location = new System.Drawing.Point(42, 86);
            this.label3_Ani_1.Name = "label3_Ani_1";
            this.label3_Ani_1.Size = new System.Drawing.Size(100, 31);
            this.label3_Ani_1.TabIndex = 41;
            this.label3_Ani_1.Visible = false;
            // 
            // spTimer2
            // 
            this.spTimer2.Enabled = true;
            this.spTimer2.SynchronizingObject = this;
            this.spTimer2.Elapsed += new System.Timers.ElapsedEventHandler(this.spTimer2_Elapsed);
            // 
            // spTimer3
            // 
            this.spTimer3.Enabled = true;
            this.spTimer3.SynchronizingObject = this;
            this.spTimer3.Elapsed += new System.Timers.ElapsedEventHandler(this.spTimer3_Elapsed);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(387, 547);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(735, 326);
            this.label1.TabIndex = 41;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(708, 592);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(272, 279);
            this.groupBox6.TabIndex = 46;
            this.groupBox6.TabStop = false;
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
            this.radioButton_일별자르기.Location = new System.Drawing.Point(120, 6);
            this.radioButton_일별자르기.Name = "radioButton_일별자르기";
            this.radioButton_일별자르기.Size = new System.Drawing.Size(129, 16);
            this.radioButton_일별자르기.TabIndex = 14;
            this.radioButton_일별자르기.Text = "2. 타코 일별 자르기";
            this.radioButton_일별자르기.UseVisualStyleBackColor = true;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButton_타코자동분리);
            this.panel1.Controls.Add(this.radioButton_교대시간);
            this.panel1.Controls.Add(this.AMtextBox);
            this.panel1.Controls.Add(this.radioButton_일별자르기);
            this.panel1.Controls.Add(this.radioButton_타코);
            this.panel1.Controls.Add(this.PMtextBox);
            this.panel1.Location = new System.Drawing.Point(327, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 127);
            this.panel1.TabIndex = 12;
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
            this.listView1.Location = new System.Drawing.Point(302, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(716, 583);
            this.listView1.TabIndex = 47;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "구분";
            this.columnHeader4.Width = 45;
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
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1036, 18);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(78, 43);
            this.button10.TabIndex = 48;
            this.button10.Text = "데이터 삭제";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // FormTachoReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1030, 668);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.buttonOldFileLoad);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxTotalMoney);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTachoReceive";
            this.Text = "타코 데이터 수신";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTachoReceive_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.spTimer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTimer3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOldFileLoad;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2_Base;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.IO.Ports.SerialPort serialPort2;
		private System.Timers.Timer spTimer1;
		private System.Windows.Forms.Label label1_Ani_1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox textBoxTotalMoney;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label2_Ani_1;
		private System.Windows.Forms.Label label3_Base;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label3_Ani_1;
		private System.Windows.Forms.Label label4_Base;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.IO.Ports.SerialPort serialPort3;
		private System.IO.Ports.SerialPort serialPort4;
		private System.Timers.Timer spTimer2;
		private System.Timers.Timer spTimer3;
		private System.Windows.Forms.ComboBox comboBoxPort;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox comboBoxPort2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox comboBoxPort3;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox comboBoxPort4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_타코자동분리;
        private System.Windows.Forms.RadioButton radioButton_교대시간;
        private System.Windows.Forms.TextBox AMtextBox;
        private System.Windows.Forms.RadioButton radioButton_일별자르기;
        private System.Windows.Forms.RadioButton radioButton_타코;
        private System.Windows.Forms.TextBox PMtextBox;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button10;
    }
}