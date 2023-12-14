namespace ConvertTacho
{
	partial class FormDayInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDayInfo));
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printDialog2 = new System.Windows.Forms.PrintDialog();
            this.tapPage1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_carnum = new System.Windows.Forms.TextBox();
            this.edit_button = new System.Windows.Forms.Button();
            this.radioButton_영업상세 = new System.Windows.Forms.RadioButton();
            this.radioButton_종합정보인쇄 = new System.Windows.Forms.RadioButton();
            this.radioButton_전체인쇄 = new System.Windows.Forms.RadioButton();
            this.radioButton_부분인쇄 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.출고label = new System.Windows.Forms.Label();
            this.운전자label = new System.Windows.Forms.Label();
            this.차번label = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.입고label = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox수입Km = new System.Windows.Forms.TextBox();
            this.textBox운행시간 = new System.Windows.Forms.TextBox();
            this.textBox연료량 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox문개폐회수 = new System.Windows.Forms.TextBox();
            this.textBox미터수입 = new System.Windows.Forms.TextBox();
            this.textBox급제동회수 = new System.Windows.Forms.TextBox();
            this.textBox주행거리 = new System.Windows.Forms.TextBox();
            this.textBox불사용요금 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox주행기본회수 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox공차거리 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.textBox영업거리 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxKm리터 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox승차율 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox키사용회수 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox할증기본회수 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox불사용거리 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox할증이후회수 = new System.Windows.Forms.TextBox();
            this.textBox주행이후회수 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox실입금액 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox수입리터 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox운행률 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox영업회수 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox불사용회수 = new System.Windows.Forms.TextBox();
            this.textBox불사용시간 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox공차시간 = new System.Windows.Forms.TextBox();
            this.textBox과속시간 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox영업시간 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.zg3 = new ZedGraph.ZedGraphControl();
            this.button3 = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label57 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label60 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label63 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.panel25 = new System.Windows.Forms.Panel();
            this.label69 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.tapPage1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel26.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.printPreviewDialog1_FormClosing);
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Document = this.printDocument2;
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog1";
            this.printPreviewDialog2.Visible = false;
            // 
            // printDialog2
            // 
            this.printDialog2.UseEXDialog = true;
            // 
            // tapPage1
            // 
            this.tapPage1.Controls.Add(this.tabPage1);
            this.tapPage1.Controls.Add(this.tabPage2);
            this.tapPage1.Location = new System.Drawing.Point(1, 0);
            this.tapPage1.Name = "tapPage1";
            this.tapPage1.SelectedIndex = 0;
            this.tapPage1.Size = new System.Drawing.Size(1052, 660);
            this.tapPage1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.textBox_carnum);
            this.tabPage1.Controls.Add(this.edit_button);
            this.tabPage1.Controls.Add(this.radioButton_영업상세);
            this.tabPage1.Controls.Add(this.radioButton_종합정보인쇄);
            this.tabPage1.Controls.Add(this.radioButton_전체인쇄);
            this.tabPage1.Controls.Add(this.radioButton_부분인쇄);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.출고label);
            this.tabPage1.Controls.Add(this.운전자label);
            this.tabPage1.Controls.Add(this.차번label);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.입고label);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1044, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "일보";
            // 
            // textBox_carnum
            // 
            this.textBox_carnum.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_carnum.Location = new System.Drawing.Point(94, 111);
            this.textBox_carnum.Name = "textBox_carnum";
            this.textBox_carnum.Size = new System.Drawing.Size(126, 26);
            this.textBox_carnum.TabIndex = 319;
            // 
            // edit_button
            // 
            this.edit_button.Location = new System.Drawing.Point(768, 584);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(57, 28);
            this.edit_button.TabIndex = 318;
            this.edit_button.Text = "Edit";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // radioButton_영업상세
            // 
            this.radioButton_영업상세.AutoSize = true;
            this.radioButton_영업상세.Location = new System.Drawing.Point(769, 516);
            this.radioButton_영업상세.Name = "radioButton_영업상세";
            this.radioButton_영업상세.Size = new System.Drawing.Size(179, 16);
            this.radioButton_영업상세.TabIndex = 316;
            this.radioButton_영업상세.TabStop = true;
            this.radioButton_영업상세.Text = "4 .종합정보  + 영업상세 인쇄";
            this.radioButton_영업상세.UseVisualStyleBackColor = true;
            // 
            // radioButton_종합정보인쇄
            // 
            this.radioButton_종합정보인쇄.AutoSize = true;
            this.radioButton_종합정보인쇄.Location = new System.Drawing.Point(769, 489);
            this.radioButton_종합정보인쇄.Name = "radioButton_종합정보인쇄";
            this.radioButton_종합정보인쇄.Size = new System.Drawing.Size(117, 16);
            this.radioButton_종합정보인쇄.TabIndex = 315;
            this.radioButton_종합정보인쇄.TabStop = true;
            this.radioButton_종합정보인쇄.Text = "3 . 종합정보 인쇄";
            this.radioButton_종합정보인쇄.UseVisualStyleBackColor = true;
            // 
            // radioButton_전체인쇄
            // 
            this.radioButton_전체인쇄.AutoSize = true;
            this.radioButton_전체인쇄.Location = new System.Drawing.Point(768, 433);
            this.radioButton_전체인쇄.Name = "radioButton_전체인쇄";
            this.radioButton_전체인쇄.Size = new System.Drawing.Size(89, 16);
            this.radioButton_전체인쇄.TabIndex = 313;
            this.radioButton_전체인쇄.TabStop = true;
            this.radioButton_전체인쇄.Text = "1 . 전체인쇄";
            this.radioButton_전체인쇄.UseVisualStyleBackColor = true;
            // 
            // radioButton_부분인쇄
            // 
            this.radioButton_부분인쇄.AutoSize = true;
            this.radioButton_부분인쇄.Location = new System.Drawing.Point(768, 462);
            this.radioButton_부분인쇄.Name = "radioButton_부분인쇄";
            this.radioButton_부분인쇄.Size = new System.Drawing.Size(167, 16);
            this.radioButton_부분인쇄.TabIndex = 314;
            this.radioButton_부분인쇄.TabStop = true;
            this.radioButton_부분인쇄.Text = "2 . 종합정보 + 그래프 인쇄";
            this.radioButton_부분인쇄.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(38, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 23);
            this.label1.TabIndex = 312;
            this.label1.Text = "♣ 영업 상세 데이터 ♣";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(762, 386);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(118, 32);
            this.button8.TabIndex = 297;
            this.button8.Text = "영업 상세 데이터 인쇄";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listView1.Location = new System.Drawing.Point(34, 419);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(722, 202);
            this.listView1.TabIndex = 296;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // 출고label
            // 
            this.출고label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.출고label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.출고label.Location = new System.Drawing.Point(461, 103);
            this.출고label.Name = "출고label";
            this.출고label.Size = new System.Drawing.Size(295, 19);
            this.출고label.TabIndex = 295;
            this.출고label.Text = "출 고 :";
            this.출고label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.출고label.Visible = false;
            // 
            // 운전자label
            // 
            this.운전자label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.운전자label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.운전자label.Location = new System.Drawing.Point(227, 111);
            this.운전자label.Name = "운전자label";
            this.운전자label.Size = new System.Drawing.Size(209, 23);
            this.운전자label.TabIndex = 294;
            this.운전자label.Text = "운 전 자 :";
            this.운전자label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.운전자label.Visible = false;
            // 
            // 차번label
            // 
            this.차번label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.차번label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.차번label.Location = new System.Drawing.Point(33, 111);
            this.차번label.Name = "차번label";
            this.차번label.Size = new System.Drawing.Size(187, 23);
            this.차번label.TabIndex = 293;
            this.차번label.Text = "차 번 :";
            this.차번label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.차번label.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(768, 546);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 32);
            this.button4.TabIndex = 281;
            this.button4.Text = "인쇄(&P)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(831, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 32);
            this.button1.TabIndex = 280;
            this.button1.Text = "닫기(&C)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 입고label
            // 
            this.입고label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.입고label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.입고label.Location = new System.Drawing.Point(461, 130);
            this.입고label.Name = "입고label";
            this.입고label.Size = new System.Drawing.Size(295, 15);
            this.입고label.TabIndex = 207;
            this.입고label.Text = "입 고 :";
            this.입고label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.입고label.Visible = false;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.Font = new System.Drawing.Font("돋움", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label41.Location = new System.Drawing.Point(31, 55);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(726, 42);
            this.label41.TabIndex = 206;
            this.label41.Text = "♣ 차량 운행 일일 종합 정보 ♣";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.textBox수입Km, 5, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox운행시간, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox연료량, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox문개폐회수, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox미터수입, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox급제동회수, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox주행거리, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox불사용요금, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.label14, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox주행기본회수, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label39, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox공차거리, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label38, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox영업거리, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label31, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.label30, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKm리터, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.label24, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox승차율, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox키사용회수, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label36, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBox할증기본회수, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label35, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox불사용거리, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label22, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox할증이후회수, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox주행이후회수, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label28, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox실입금액, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label32, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox수입리터, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label27, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox운행률, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label19, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox영업회수, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox불사용회수, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox불사용시간, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label26, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox공차시간, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox과속시간, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label13, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox영업시간, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(34, 154);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 204);
            this.tableLayoutPanel1.TabIndex = 317;
            // 
            // textBox수입Km
            // 
            this.textBox수입Km.BackColor = System.Drawing.Color.White;
            this.textBox수입Km.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox수입Km.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox수입Km.Location = new System.Drawing.Point(600, 181);
            this.textBox수입Km.Name = "textBox수입Km";
            this.textBox수입Km.ReadOnly = true;
            this.textBox수입Km.Size = new System.Drawing.Size(116, 14);
            this.textBox수입Km.TabIndex = 272;
            this.textBox수입Km.TabStop = false;
            this.textBox수입Km.Text = ".....";
            this.textBox수입Km.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox운행시간
            // 
            this.textBox운행시간.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox운행시간.BackColor = System.Drawing.Color.White;
            this.textBox운행시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox운행시간.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox운행시간.Location = new System.Drawing.Point(124, 5);
            this.textBox운행시간.Name = "textBox운행시간";
            this.textBox운행시간.ReadOnly = true;
            this.textBox운행시간.Size = new System.Drawing.Size(111, 14);
            this.textBox운행시간.TabIndex = 230;
            this.textBox운행시간.TabStop = false;
            this.textBox운행시간.Text = ".....";
            this.textBox운행시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox연료량
            // 
            this.textBox연료량.BackColor = System.Drawing.Color.White;
            this.textBox연료량.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox연료량.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox연료량.Location = new System.Drawing.Point(600, 159);
            this.textBox연료량.Name = "textBox연료량";
            this.textBox연료량.ReadOnly = true;
            this.textBox연료량.Size = new System.Drawing.Size(116, 14);
            this.textBox연료량.TabIndex = 279;
            this.textBox연료량.TabStop = false;
            this.textBox연료량.Text = ".....";
            this.textBox연료량.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(481, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 20);
            this.label12.TabIndex = 249;
            this.label12.Text = "영업 거리";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox문개폐회수
            // 
            this.textBox문개폐회수.BackColor = System.Drawing.Color.White;
            this.textBox문개폐회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox문개폐회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox문개폐회수.Location = new System.Drawing.Point(600, 137);
            this.textBox문개폐회수.Name = "textBox문개폐회수";
            this.textBox문개폐회수.ReadOnly = true;
            this.textBox문개폐회수.Size = new System.Drawing.Size(116, 14);
            this.textBox문개폐회수.TabIndex = 274;
            this.textBox문개폐회수.TabStop = false;
            this.textBox문개폐회수.Text = ".....";
            this.textBox문개폐회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox미터수입
            // 
            this.textBox미터수입.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox미터수입.BackColor = System.Drawing.Color.White;
            this.textBox미터수입.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox미터수입.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox미터수입.Location = new System.Drawing.Point(362, 5);
            this.textBox미터수입.Name = "textBox미터수입";
            this.textBox미터수입.ReadOnly = true;
            this.textBox미터수입.Size = new System.Drawing.Size(111, 14);
            this.textBox미터수입.TabIndex = 270;
            this.textBox미터수입.TabStop = false;
            this.textBox미터수입.Text = ".....";
            this.textBox미터수입.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox급제동회수
            // 
            this.textBox급제동회수.BackColor = System.Drawing.Color.White;
            this.textBox급제동회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox급제동회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox급제동회수.Location = new System.Drawing.Point(600, 115);
            this.textBox급제동회수.Name = "textBox급제동회수";
            this.textBox급제동회수.ReadOnly = true;
            this.textBox급제동회수.Size = new System.Drawing.Size(116, 14);
            this.textBox급제동회수.TabIndex = 269;
            this.textBox급제동회수.TabStop = false;
            this.textBox급제동회수.Text = ".....";
            this.textBox급제동회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox주행거리
            // 
            this.textBox주행거리.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox주행거리.BackColor = System.Drawing.Color.White;
            this.textBox주행거리.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox주행거리.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox주행거리.Location = new System.Drawing.Point(600, 5);
            this.textBox주행거리.Name = "textBox주행거리";
            this.textBox주행거리.ReadOnly = true;
            this.textBox주행거리.Size = new System.Drawing.Size(116, 14);
            this.textBox주행거리.TabIndex = 278;
            this.textBox주행거리.TabStop = false;
            this.textBox주행거리.Text = ".....";
            this.textBox주행거리.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox불사용요금
            // 
            this.textBox불사용요금.BackColor = System.Drawing.Color.White;
            this.textBox불사용요금.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox불사용요금.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox불사용요금.Location = new System.Drawing.Point(600, 93);
            this.textBox불사용요금.Name = "textBox불사용요금";
            this.textBox불사용요금.ReadOnly = true;
            this.textBox불사용요금.Size = new System.Drawing.Size(116, 14);
            this.textBox불사용요금.TabIndex = 268;
            this.textBox불사용요금.TabStop = false;
            this.textBox불사용요금.Text = ".....";
            this.textBox불사용요금.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(481, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 20);
            this.label14.TabIndex = 219;
            this.label14.Text = "주행 기본 회수";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox주행기본회수
            // 
            this.textBox주행기본회수.BackColor = System.Drawing.Color.White;
            this.textBox주행기본회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox주행기본회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox주행기본회수.Location = new System.Drawing.Point(600, 71);
            this.textBox주행기본회수.Name = "textBox주행기본회수";
            this.textBox주행기본회수.ReadOnly = true;
            this.textBox주행기본회수.Size = new System.Drawing.Size(116, 14);
            this.textBox주행기본회수.TabIndex = 229;
            this.textBox주행기본회수.TabStop = false;
            this.textBox주행기본회수.Text = ".....";
            this.textBox주행기본회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(481, 178);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(111, 24);
            this.label39.TabIndex = 250;
            this.label39.Text = "수입(Km)";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox공차거리
            // 
            this.textBox공차거리.BackColor = System.Drawing.Color.White;
            this.textBox공차거리.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox공차거리.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox공차거리.Location = new System.Drawing.Point(600, 49);
            this.textBox공차거리.Name = "textBox공차거리";
            this.textBox공차거리.ReadOnly = true;
            this.textBox공차거리.Size = new System.Drawing.Size(116, 14);
            this.textBox공차거리.TabIndex = 276;
            this.textBox공차거리.TabStop = false;
            this.textBox공차거리.Text = ".....";
            this.textBox공차거리.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(481, 156);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(111, 20);
            this.label38.TabIndex = 244;
            this.label38.Text = "연료량(L)";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox영업거리
            // 
            this.textBox영업거리.BackColor = System.Drawing.Color.White;
            this.textBox영업거리.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox영업거리.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox영업거리.Location = new System.Drawing.Point(600, 27);
            this.textBox영업거리.Name = "textBox영업거리";
            this.textBox영업거리.ReadOnly = true;
            this.textBox영업거리.Size = new System.Drawing.Size(116, 14);
            this.textBox영업거리.TabIndex = 271;
            this.textBox영업거리.TabStop = false;
            this.textBox영업거리.Text = ".....";
            this.textBox영업거리.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(481, 134);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(111, 20);
            this.label31.TabIndex = 252;
            this.label31.Text = "문개폐 회수";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(481, 112);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(111, 20);
            this.label30.TabIndex = 247;
            this.label30.Text = "급제동 회수";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(5, 178);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 24);
            this.label33.TabIndex = 216;
            this.label33.Text = "수입/리터";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxKm리터
            // 
            this.textBoxKm리터.BackColor = System.Drawing.Color.White;
            this.textBoxKm리터.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKm리터.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxKm리터.Location = new System.Drawing.Point(362, 181);
            this.textBoxKm리터.Name = "textBoxKm리터";
            this.textBoxKm리터.ReadOnly = true;
            this.textBoxKm리터.Size = new System.Drawing.Size(111, 14);
            this.textBoxKm리터.TabIndex = 260;
            this.textBoxKm리터.TabStop = false;
            this.textBoxKm리터.Text = ".....";
            this.textBoxKm리터.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(481, 90);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 20);
            this.label24.TabIndex = 246;
            this.label24.Text = "도어분석 요금";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox승차율
            // 
            this.textBox승차율.BackColor = System.Drawing.Color.White;
            this.textBox승차율.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox승차율.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox승차율.Location = new System.Drawing.Point(362, 159);
            this.textBox승차율.Name = "textBox승차율";
            this.textBox승차율.ReadOnly = true;
            this.textBox승차율.Size = new System.Drawing.Size(111, 14);
            this.textBox승차율.TabIndex = 267;
            this.textBox승차율.TabStop = false;
            this.textBox승차율.Text = ".....";
            this.textBox승차율.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(481, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 20);
            this.label11.TabIndex = 254;
            this.label11.Text = "공차 거리";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox키사용회수
            // 
            this.textBox키사용회수.BackColor = System.Drawing.Color.White;
            this.textBox키사용회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox키사용회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox키사용회수.Location = new System.Drawing.Point(362, 137);
            this.textBox키사용회수.Name = "textBox키사용회수";
            this.textBox키사용회수.ReadOnly = true;
            this.textBox키사용회수.Size = new System.Drawing.Size(111, 14);
            this.textBox키사용회수.TabIndex = 257;
            this.textBox키사용회수.TabStop = false;
            this.textBox키사용회수.Text = ".....";
            this.textBox키사용회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(243, 178);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(111, 24);
            this.label36.TabIndex = 238;
            this.label36.Text = "Km/리터";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox할증기본회수
            // 
            this.textBox할증기본회수.BackColor = System.Drawing.Color.White;
            this.textBox할증기본회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox할증기본회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox할증기본회수.Location = new System.Drawing.Point(362, 115);
            this.textBox할증기본회수.Name = "textBox할증기본회수";
            this.textBox할증기본회수.ReadOnly = true;
            this.textBox할증기본회수.Size = new System.Drawing.Size(111, 14);
            this.textBox할증기본회수.TabIndex = 223;
            this.textBox할증기본회수.TabStop = false;
            this.textBox할증기본회수.Text = ".....";
            this.textBox할증기본회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(243, 156);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(111, 20);
            this.label35.TabIndex = 232;
            this.label35.Text = "승차율(%)";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox불사용거리
            // 
            this.textBox불사용거리.BackColor = System.Drawing.Color.White;
            this.textBox불사용거리.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox불사용거리.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox불사용거리.Location = new System.Drawing.Point(362, 93);
            this.textBox불사용거리.Name = "textBox불사용거리";
            this.textBox불사용거리.ReadOnly = true;
            this.textBox불사용거리.Size = new System.Drawing.Size(111, 14);
            this.textBox불사용거리.TabIndex = 256;
            this.textBox불사용거리.TabStop = false;
            this.textBox불사용거리.Text = ".....";
            this.textBox불사용거리.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(243, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 20);
            this.label22.TabIndex = 234;
            this.label22.Text = "도어분석 거리";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox할증이후회수
            // 
            this.textBox할증이후회수.BackColor = System.Drawing.Color.White;
            this.textBox할증이후회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox할증이후회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox할증이후회수.Location = new System.Drawing.Point(362, 71);
            this.textBox할증이후회수.Name = "textBox할증이후회수";
            this.textBox할증이후회수.ReadOnly = true;
            this.textBox할증이후회수.Size = new System.Drawing.Size(111, 14);
            this.textBox할증이후회수.TabIndex = 263;
            this.textBox할증이후회수.TabStop = false;
            this.textBox할증이후회수.Text = ".....";
            this.textBox할증이후회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox주행이후회수
            // 
            this.textBox주행이후회수.BackColor = System.Drawing.Color.White;
            this.textBox주행이후회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox주행이후회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox주행이후회수.Location = new System.Drawing.Point(362, 49);
            this.textBox주행이후회수.Name = "textBox주행이후회수";
            this.textBox주행이후회수.ReadOnly = true;
            this.textBox주행이후회수.Size = new System.Drawing.Size(111, 14);
            this.textBox주행이후회수.TabIndex = 258;
            this.textBox주행이후회수.TabStop = false;
            this.textBox주행이후회수.Text = ".....";
            this.textBox주행이후회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(243, 134);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(111, 20);
            this.label28.TabIndex = 235;
            this.label28.Text = "키 사용 회수";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(243, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 20);
            this.label15.TabIndex = 214;
            this.label15.Text = "할증 기본 회수";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox실입금액
            // 
            this.textBox실입금액.BackColor = System.Drawing.Color.White;
            this.textBox실입금액.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox실입금액.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox실입금액.Location = new System.Drawing.Point(362, 27);
            this.textBox실입금액.Name = "textBox실입금액";
            this.textBox실입금액.ReadOnly = true;
            this.textBox실입금액.Size = new System.Drawing.Size(111, 14);
            this.textBox실입금액.TabIndex = 275;
            this.textBox실입금액.TabStop = false;
            this.textBox실입금액.Text = ".....";
            this.textBox실입금액.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(5, 156);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(111, 20);
            this.label32.TabIndex = 208;
            this.label32.Text = "운행률(%)";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(243, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 20);
            this.label17.TabIndex = 239;
            this.label17.Text = "할증 이후 회수";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox수입리터
            // 
            this.textBox수입리터.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox수입리터.BackColor = System.Drawing.Color.White;
            this.textBox수입리터.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox수입리터.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox수입리터.Location = new System.Drawing.Point(124, 181);
            this.textBox수입리터.Name = "textBox수입리터";
            this.textBox수입리터.ReadOnly = true;
            this.textBox수입리터.Size = new System.Drawing.Size(111, 14);
            this.textBox수입리터.TabIndex = 226;
            this.textBox수입리터.TabStop = false;
            this.textBox수입리터.Text = ".....";
            this.textBox수입리터.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(243, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 20);
            this.label16.TabIndex = 236;
            this.label16.Text = "주행 이후 회수";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(5, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(111, 20);
            this.label27.TabIndex = 218;
            this.label27.Text = "도어분석  회수";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox운행률
            // 
            this.textBox운행률.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox운행률.BackColor = System.Drawing.Color.White;
            this.textBox운행률.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox운행률.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox운행률.Location = new System.Drawing.Point(124, 159);
            this.textBox운행률.Name = "textBox운행률";
            this.textBox운행률.ReadOnly = true;
            this.textBox운행률.Size = new System.Drawing.Size(111, 14);
            this.textBox운행률.TabIndex = 231;
            this.textBox운행률.TabStop = false;
            this.textBox운행률.Text = ".....";
            this.textBox운행률.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(243, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 20);
            this.label19.TabIndex = 253;
            this.label19.Text = "실 입금액";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox영업회수
            // 
            this.textBox영업회수.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox영업회수.BackColor = System.Drawing.Color.White;
            this.textBox영업회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox영업회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox영업회수.Location = new System.Drawing.Point(124, 137);
            this.textBox영업회수.Name = "textBox영업회수";
            this.textBox영업회수.ReadOnly = true;
            this.textBox영업회수.Size = new System.Drawing.Size(111, 14);
            this.textBox영업회수.TabIndex = 227;
            this.textBox영업회수.TabStop = false;
            this.textBox영업회수.Text = ".....";
            this.textBox영업회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(5, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 20);
            this.label20.TabIndex = 210;
            this.label20.Text = "도어분석 시간";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox불사용회수
            // 
            this.textBox불사용회수.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox불사용회수.BackColor = System.Drawing.Color.White;
            this.textBox불사용회수.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox불사용회수.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox불사용회수.Location = new System.Drawing.Point(124, 115);
            this.textBox불사용회수.Name = "textBox불사용회수";
            this.textBox불사용회수.ReadOnly = true;
            this.textBox불사용회수.Size = new System.Drawing.Size(111, 14);
            this.textBox불사용회수.TabIndex = 225;
            this.textBox불사용회수.TabStop = false;
            this.textBox불사용회수.Text = ".....";
            this.textBox불사용회수.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox불사용시간
            // 
            this.textBox불사용시간.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox불사용시간.BackColor = System.Drawing.Color.White;
            this.textBox불사용시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox불사용시간.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox불사용시간.Location = new System.Drawing.Point(124, 93);
            this.textBox불사용시간.Name = "textBox불사용시간";
            this.textBox불사용시간.ReadOnly = true;
            this.textBox불사용시간.Size = new System.Drawing.Size(111, 14);
            this.textBox불사용시간.TabIndex = 228;
            this.textBox불사용시간.TabStop = false;
            this.textBox불사용시간.Text = ".....";
            this.textBox불사용시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(5, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 241;
            this.label8.Text = "공차 시간";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(5, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(111, 20);
            this.label26.TabIndex = 212;
            this.label26.Text = "과속 시간";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox공차시간
            // 
            this.textBox공차시간.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox공차시간.BackColor = System.Drawing.Color.White;
            this.textBox공차시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox공차시간.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox공차시간.Location = new System.Drawing.Point(124, 49);
            this.textBox공차시간.Name = "textBox공차시간";
            this.textBox공차시간.ReadOnly = true;
            this.textBox공차시간.Size = new System.Drawing.Size(111, 14);
            this.textBox공차시간.TabIndex = 264;
            this.textBox공차시간.TabStop = false;
            this.textBox공차시간.Text = ".....";
            this.textBox공차시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox과속시간
            // 
            this.textBox과속시간.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox과속시간.BackColor = System.Drawing.Color.White;
            this.textBox과속시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox과속시간.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox과속시간.Location = new System.Drawing.Point(124, 71);
            this.textBox과속시간.Name = "textBox과속시간";
            this.textBox과속시간.ReadOnly = true;
            this.textBox과속시간.Size = new System.Drawing.Size(111, 14);
            this.textBox과속시간.TabIndex = 221;
            this.textBox과속시간.TabStop = false;
            this.textBox과속시간.Text = ".....";
            this.textBox과속시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(5, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 217;
            this.label5.Text = "영업 회수";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(481, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 245;
            this.label13.Text = "운행 거리";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 209;
            this.label6.Text = "운행 시간";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox영업시간
            // 
            this.textBox영업시간.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox영업시간.BackColor = System.Drawing.Color.White;
            this.textBox영업시간.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox영업시간.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox영업시간.Location = new System.Drawing.Point(124, 27);
            this.textBox영업시간.Name = "textBox영업시간";
            this.textBox영업시간.ReadOnly = true;
            this.textBox영업시간.Size = new System.Drawing.Size(111, 14);
            this.textBox영업시간.TabIndex = 259;
            this.textBox영업시간.TabStop = false;
            this.textBox영업시간.Text = ".....";
            this.textBox영업시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(243, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 20);
            this.label18.TabIndex = 248;
            this.label18.Text = "미터 수입";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(5, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 237;
            this.label9.Text = "영업 시간";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.zg3);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1044, 634);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "그래프";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(-3, 163);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 12);
            this.label25.TabIndex = 21;
            this.label25.Text = "거리(Km/h)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "영업";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 82);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 19;
            this.label21.Text = "도어";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 18;
            this.label23.Text = "엔진";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-6, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "속도(Km/h)";
            // 
            // zg3
            // 
            this.zg3.AutoScroll = true;
            this.zg3.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.zg3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zg3.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg3.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zg3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.zg3.IsEnableVPan = false;
            this.zg3.IsEnableVZoom = false;
            this.zg3.IsShowPointValues = true;
            this.zg3.Location = new System.Drawing.Point(-1, 19);
            this.zg3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zg3.Name = "zg3";
            this.zg3.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg3.ScrollGrace = 0D;
            this.zg3.ScrollMaxX = 400D;
            this.zg3.ScrollMaxY = 0D;
            this.zg3.ScrollMaxY2 = 0D;
            this.zg3.ScrollMinX = 0D;
            this.zg3.ScrollMinY = 0D;
            this.zg3.ScrollMinY2 = 0D;
            this.zg3.Size = new System.Drawing.Size(1047, 400);
            this.zg3.TabIndex = 23;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(846, 430);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 22;
            this.button3.Text = "초기화";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.label2);
            this.panel14.Controls.Add(this.textBox1);
            this.panel14.Controls.Add(this.label3);
            this.panel14.Controls.Add(this.textBox2);
            this.panel14.Controls.Add(this.label4);
            this.panel14.Controls.Add(this.textBox3);
            this.panel14.Location = new System.Drawing.Point(35, 321);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(723, 22);
            this.panel14.TabIndex = 292;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(23, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 211;
            this.label2.Text = "인정 금액";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(118, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(118, 21);
            this.textBox1.TabIndex = 224;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(273, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 242;
            this.label3.Text = "지출 금액";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(358, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(118, 21);
            this.textBox2.TabIndex = 265;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(514, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 255;
            this.label4.Text = "연료 금액";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(603, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(118, 21);
            this.textBox3.TabIndex = 277;
            this.textBox3.TabStop = false;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.label42);
            this.panel15.Controls.Add(this.textBox4);
            this.panel15.Controls.Add(this.label43);
            this.panel15.Controls.Add(this.textBox5);
            this.panel15.Controls.Add(this.label44);
            this.panel15.Controls.Add(this.textBox6);
            this.panel15.Location = new System.Drawing.Point(35, 300);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(723, 22);
            this.panel15.TabIndex = 290;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(23, 3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(59, 12);
            this.label42.TabIndex = 216;
            this.label42.Text = "수입/리터";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(118, -1);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(118, 21);
            this.textBox4.TabIndex = 226;
            this.textBox4.TabStop = false;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Location = new System.Drawing.Point(276, 3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(54, 12);
            this.label43.TabIndex = 238;
            this.label43.Text = "Km/리터";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(358, -1);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(118, 21);
            this.textBox5.TabIndex = 260;
            this.textBox5.TabStop = false;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(513, 5);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 12);
            this.label44.TabIndex = 250;
            this.label44.Text = "수입(Km)";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(603, -1);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(118, 21);
            this.textBox6.TabIndex = 272;
            this.textBox6.TabStop = false;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label45);
            this.panel16.Controls.Add(this.textBox7);
            this.panel16.Controls.Add(this.label46);
            this.panel16.Controls.Add(this.textBox8);
            this.panel16.Controls.Add(this.label47);
            this.panel16.Controls.Add(this.textBox9);
            this.panel16.Location = new System.Drawing.Point(35, 260);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(723, 22);
            this.panel16.TabIndex = 290;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label45.Location = new System.Drawing.Point(17, 3);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 12);
            this.label45.TabIndex = 218;
            this.label45.Text = "불사용 회수";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(118, -1);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(118, 21);
            this.textBox7.TabIndex = 225;
            this.textBox7.TabStop = false;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label46.Location = new System.Drawing.Point(273, 3);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(57, 12);
            this.label46.TabIndex = 243;
            this.label46.Text = "합승 회수";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.Location = new System.Drawing.Point(358, 0);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(118, 21);
            this.textBox8.TabIndex = 262;
            this.textBox8.TabStop = false;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label47.Location = new System.Drawing.Point(509, 5);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 12);
            this.label47.TabIndex = 252;
            this.label47.Text = "문개폐 회수";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(603, -1);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(118, 21);
            this.textBox9.TabIndex = 274;
            this.textBox9.TabStop = false;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.label48);
            this.panel17.Controls.Add(this.textBox10);
            this.panel17.Controls.Add(this.label49);
            this.panel17.Controls.Add(this.textBox11);
            this.panel17.Controls.Add(this.label50);
            this.panel17.Controls.Add(this.textBox12);
            this.panel17.Location = new System.Drawing.Point(35, 239);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(723, 22);
            this.panel17.TabIndex = 290;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label48.Location = new System.Drawing.Point(25, 5);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 12);
            this.label48.TabIndex = 212;
            this.label48.Text = "과속 시간";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.Location = new System.Drawing.Point(118, -1);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(118, 21);
            this.textBox10.TabIndex = 221;
            this.textBox10.TabStop = false;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label49.Location = new System.Drawing.Point(265, 5);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(73, 12);
            this.label49.TabIndex = 235;
            this.label49.Text = "키 사용 회수";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.Location = new System.Drawing.Point(358, -1);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(118, 21);
            this.textBox11.TabIndex = 257;
            this.textBox11.TabStop = false;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label50.Location = new System.Drawing.Point(510, 5);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(69, 12);
            this.label50.TabIndex = 247;
            this.label50.Text = "급제동 회수";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.Location = new System.Drawing.Point(603, -1);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(118, 21);
            this.textBox12.TabIndex = 269;
            this.textBox12.TabStop = false;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.label51);
            this.panel18.Controls.Add(this.textBox13);
            this.panel18.Controls.Add(this.label52);
            this.panel18.Controls.Add(this.textBox14);
            this.panel18.Controls.Add(this.label53);
            this.panel18.Controls.Add(this.textBox15);
            this.panel18.Location = new System.Drawing.Point(35, 218);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(723, 22);
            this.panel18.TabIndex = 291;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label51.Location = new System.Drawing.Point(25, 5);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(57, 12);
            this.label51.TabIndex = 213;
            this.label51.Text = "합승 시간";
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.White;
            this.textBox13.Location = new System.Drawing.Point(118, -1);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(118, 21);
            this.textBox13.TabIndex = 220;
            this.textBox13.TabStop = false;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(273, 5);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(57, 12);
            this.label52.TabIndex = 240;
            this.label52.Text = "합승 거리";
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.White;
            this.textBox14.Location = new System.Drawing.Point(358, 0);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(118, 21);
            this.textBox14.TabIndex = 261;
            this.textBox14.TabStop = false;
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(514, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(57, 12);
            this.label53.TabIndex = 251;
            this.label53.Text = "합승 요금";
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.White;
            this.textBox15.Location = new System.Drawing.Point(603, -1);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(118, 21);
            this.textBox15.TabIndex = 273;
            this.textBox15.TabStop = false;
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel19
            // 
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Location = new System.Drawing.Point(35, 218);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(723, 22);
            this.panel19.TabIndex = 290;
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.label54);
            this.panel20.Controls.Add(this.textBox16);
            this.panel20.Controls.Add(this.label55);
            this.panel20.Controls.Add(this.textBox17);
            this.panel20.Controls.Add(this.label56);
            this.panel20.Controls.Add(this.textBox18);
            this.panel20.Location = new System.Drawing.Point(35, 281);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(723, 22);
            this.panel20.TabIndex = 290;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label54.Location = new System.Drawing.Point(23, 3);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(61, 12);
            this.label54.TabIndex = 208;
            this.label54.Text = "운행률(%)";
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.White;
            this.textBox16.Location = new System.Drawing.Point(118, 0);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(118, 21);
            this.textBox16.TabIndex = 231;
            this.textBox16.TabStop = false;
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(269, 3);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(61, 12);
            this.label55.TabIndex = 232;
            this.label55.Text = "승차율(%)";
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.White;
            this.textBox17.Location = new System.Drawing.Point(358, 0);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(118, 21);
            this.textBox17.TabIndex = 267;
            this.textBox17.TabStop = false;
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label56.Location = new System.Drawing.Point(513, 4);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(58, 12);
            this.label56.TabIndex = 244;
            this.label56.Text = "연료량(L)";
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.White;
            this.textBox18.Location = new System.Drawing.Point(603, -2);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(118, 21);
            this.textBox18.TabIndex = 279;
            this.textBox18.TabStop = false;
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel21
            // 
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Controls.Add(this.label57);
            this.panel21.Controls.Add(this.textBox19);
            this.panel21.Controls.Add(this.label58);
            this.panel21.Controls.Add(this.textBox20);
            this.panel21.Controls.Add(this.textBox21);
            this.panel21.Controls.Add(this.label59);
            this.panel21.Location = new System.Drawing.Point(35, 197);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(723, 22);
            this.panel21.TabIndex = 289;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label57.Location = new System.Drawing.Point(13, 5);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(69, 12);
            this.label57.TabIndex = 210;
            this.label57.Text = "불사용 시간";
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.White;
            this.textBox19.Location = new System.Drawing.Point(118, -1);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(118, 21);
            this.textBox19.TabIndex = 228;
            this.textBox19.TabStop = false;
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label58.Location = new System.Drawing.Point(269, 5);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(69, 12);
            this.label58.TabIndex = 234;
            this.label58.Text = "불사용 거리";
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.White;
            this.textBox20.Location = new System.Drawing.Point(358, 0);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(118, 21);
            this.textBox20.TabIndex = 256;
            this.textBox20.TabStop = false;
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.White;
            this.textBox21.Location = new System.Drawing.Point(603, 0);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(118, 21);
            this.textBox21.TabIndex = 268;
            this.textBox21.TabStop = false;
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label59.Location = new System.Drawing.Point(507, 4);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(69, 12);
            this.label59.TabIndex = 246;
            this.label59.Text = "불사용 요금";
            // 
            // panel22
            // 
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Controls.Add(this.label60);
            this.panel22.Controls.Add(this.textBox22);
            this.panel22.Controls.Add(this.label61);
            this.panel22.Controls.Add(this.textBox23);
            this.panel22.Controls.Add(this.label62);
            this.panel22.Controls.Add(this.textBox24);
            this.panel22.Location = new System.Drawing.Point(35, 176);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(723, 22);
            this.panel22.TabIndex = 289;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label60.Location = new System.Drawing.Point(12, 5);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(85, 12);
            this.label60.TabIndex = 214;
            this.label60.Text = "할증 기본 회수";
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.White;
            this.textBox22.Location = new System.Drawing.Point(118, -1);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(118, 21);
            this.textBox22.TabIndex = 223;
            this.textBox22.TabStop = false;
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label61.Location = new System.Drawing.Point(257, 5);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(85, 12);
            this.label61.TabIndex = 239;
            this.label61.Text = "할증 이후 회수";
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.White;
            this.textBox23.Location = new System.Drawing.Point(358, -1);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(118, 21);
            this.textBox23.TabIndex = 263;
            this.textBox23.TabStop = false;
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label62.Location = new System.Drawing.Point(514, 3);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(57, 12);
            this.label62.TabIndex = 253;
            this.label62.Text = "실 입금액";
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.Color.White;
            this.textBox24.Location = new System.Drawing.Point(603, -1);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(118, 21);
            this.textBox24.TabIndex = 275;
            this.textBox24.TabStop = false;
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel23
            // 
            this.panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel23.Controls.Add(this.label63);
            this.panel23.Controls.Add(this.textBox25);
            this.panel23.Controls.Add(this.label64);
            this.panel23.Controls.Add(this.textBox26);
            this.panel23.Controls.Add(this.label65);
            this.panel23.Controls.Add(this.textBox27);
            this.panel23.Location = new System.Drawing.Point(35, 155);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(723, 22);
            this.panel23.TabIndex = 289;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label63.Location = new System.Drawing.Point(12, 4);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(85, 12);
            this.label63.TabIndex = 219;
            this.label63.Text = "주행 기본 회수";
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.White;
            this.textBox25.Location = new System.Drawing.Point(118, -1);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(118, 21);
            this.textBox25.TabIndex = 229;
            this.textBox25.TabStop = false;
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(257, 5);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(85, 12);
            this.label64.TabIndex = 236;
            this.label64.Text = "주행 이후 회수";
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.White;
            this.textBox26.Location = new System.Drawing.Point(358, 0);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(118, 21);
            this.textBox26.TabIndex = 258;
            this.textBox26.TabStop = false;
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label65.Location = new System.Drawing.Point(514, 3);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(57, 12);
            this.label65.TabIndex = 248;
            this.label65.Text = "미터 수입";
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.Color.White;
            this.textBox27.Location = new System.Drawing.Point(603, 0);
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(118, 21);
            this.textBox27.TabIndex = 270;
            this.textBox27.TabStop = false;
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel24
            // 
            this.panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel24.Controls.Add(this.label66);
            this.panel24.Controls.Add(this.textBox28);
            this.panel24.Controls.Add(this.label67);
            this.panel24.Controls.Add(this.textBox29);
            this.panel24.Controls.Add(this.label68);
            this.panel24.Controls.Add(this.textBox30);
            this.panel24.Location = new System.Drawing.Point(35, 134);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(723, 22);
            this.panel24.TabIndex = 288;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label66.Location = new System.Drawing.Point(25, 4);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(57, 12);
            this.label66.TabIndex = 215;
            this.label66.Text = "정차 시간";
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.Color.White;
            this.textBox28.Location = new System.Drawing.Point(118, -1);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(118, 21);
            this.textBox28.TabIndex = 222;
            this.textBox28.TabStop = false;
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label67.Location = new System.Drawing.Point(273, 4);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(57, 12);
            this.label67.TabIndex = 241;
            this.label67.Text = "공차 시간";
            // 
            // textBox29
            // 
            this.textBox29.BackColor = System.Drawing.Color.White;
            this.textBox29.Location = new System.Drawing.Point(358, 0);
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(118, 21);
            this.textBox29.TabIndex = 264;
            this.textBox29.TabStop = false;
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label68.Location = new System.Drawing.Point(514, 4);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(57, 12);
            this.label68.TabIndex = 254;
            this.label68.Text = "공차 거리";
            // 
            // textBox30
            // 
            this.textBox30.BackColor = System.Drawing.Color.White;
            this.textBox30.Location = new System.Drawing.Point(603, -1);
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(118, 21);
            this.textBox30.TabIndex = 276;
            this.textBox30.TabStop = false;
            this.textBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel25
            // 
            this.panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel25.Controls.Add(this.label69);
            this.panel25.Controls.Add(this.textBox31);
            this.panel25.Controls.Add(this.label70);
            this.panel25.Controls.Add(this.textBox32);
            this.panel25.Controls.Add(this.label71);
            this.panel25.Controls.Add(this.textBox33);
            this.panel25.Location = new System.Drawing.Point(35, 114);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(723, 22);
            this.panel25.TabIndex = 284;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label69.Location = new System.Drawing.Point(25, 4);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(57, 12);
            this.label69.TabIndex = 217;
            this.label69.Text = "영업 회수";
            // 
            // textBox31
            // 
            this.textBox31.BackColor = System.Drawing.Color.White;
            this.textBox31.Location = new System.Drawing.Point(118, -1);
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(118, 21);
            this.textBox31.TabIndex = 227;
            this.textBox31.TabStop = false;
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label70.Location = new System.Drawing.Point(273, 3);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(57, 12);
            this.label70.TabIndex = 237;
            this.label70.Text = "영업 시간";
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.Color.White;
            this.textBox32.Location = new System.Drawing.Point(358, -1);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(118, 21);
            this.textBox32.TabIndex = 259;
            this.textBox32.TabStop = false;
            this.textBox32.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label71.Location = new System.Drawing.Point(514, 4);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(57, 12);
            this.label71.TabIndex = 249;
            this.label71.Text = "영업 거리";
            // 
            // textBox33
            // 
            this.textBox33.BackColor = System.Drawing.Color.White;
            this.textBox33.Location = new System.Drawing.Point(603, -1);
            this.textBox33.Name = "textBox33";
            this.textBox33.ReadOnly = true;
            this.textBox33.Size = new System.Drawing.Size(118, 21);
            this.textBox33.TabIndex = 271;
            this.textBox33.TabStop = false;
            this.textBox33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel26
            // 
            this.panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel26.Controls.Add(this.textBox34);
            this.panel26.Controls.Add(this.label72);
            this.panel26.Controls.Add(this.label73);
            this.panel26.Controls.Add(this.textBox35);
            this.panel26.Controls.Add(this.textBox36);
            this.panel26.Controls.Add(this.label74);
            this.panel26.Location = new System.Drawing.Point(35, 93);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(723, 22);
            this.panel26.TabIndex = 283;
            // 
            // textBox34
            // 
            this.textBox34.BackColor = System.Drawing.Color.White;
            this.textBox34.Location = new System.Drawing.Point(358, 0);
            this.textBox34.Name = "textBox34";
            this.textBox34.ReadOnly = true;
            this.textBox34.Size = new System.Drawing.Size(118, 21);
            this.textBox34.TabIndex = 266;
            this.textBox34.TabStop = false;
            this.textBox34.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label72.Location = new System.Drawing.Point(514, 5);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(57, 12);
            this.label72.TabIndex = 245;
            this.label72.Text = "주행 거리";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label73.Location = new System.Drawing.Point(25, 5);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(57, 12);
            this.label73.TabIndex = 209;
            this.label73.Text = "운행 시간";
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.Color.White;
            this.textBox35.Location = new System.Drawing.Point(603, 0);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(118, 21);
            this.textBox35.TabIndex = 278;
            this.textBox35.TabStop = false;
            this.textBox35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox36
            // 
            this.textBox36.BackColor = System.Drawing.Color.White;
            this.textBox36.Location = new System.Drawing.Point(118, 0);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(118, 21);
            this.textBox36.TabIndex = 230;
            this.textBox36.TabStop = false;
            this.textBox36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label74.Location = new System.Drawing.Point(273, 4);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(57, 12);
            this.label74.TabIndex = 233;
            this.label74.Text = "주행 시간";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(573, 423);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 32);
            this.button6.TabIndex = 281;
            this.button6.Text = "인쇄(&P)";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(672, 423);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 32);
            this.button7.TabIndex = 280;
            this.button7.Text = "닫기(&C)";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label75.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label75.Location = new System.Drawing.Point(31, 58);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(395, 23);
            this.label75.TabIndex = 207;
            this.label75.Text = "2011년 7월 12일  00-0000 홍길동";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label75.Visible = false;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.Control;
            this.label76.Font = new System.Drawing.Font("돋움", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label76.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label76.Location = new System.Drawing.Point(31, 3);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(726, 42);
            this.label76.TabIndex = 206;
            this.label76.Text = "♣ 차량 운행 일일 종합 정보 ♣";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDayInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 664);
            this.Controls.Add(this.tapPage1);
            this.MaximizeBox = false;
            this.Name = "FormDayInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDayInfo";
            this.tapPage1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
		private System.Drawing.Printing.PrintDocument printDocument2;
		private System.Windows.Forms.PrintDialog printDialog2;
		private System.Windows.Forms.TabControl tapPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox문개폐회수;
		private System.Windows.Forms.TextBox textBox실입금액;
		private System.Windows.Forms.TextBox textBox공차거리;
		private System.Windows.Forms.TextBox textBox급제동회수;
        private System.Windows.Forms.TextBox textBox불사용요금;
		private System.Windows.Forms.TextBox textBox수입Km;
		private System.Windows.Forms.TextBox textBox영업거리;
		private System.Windows.Forms.TextBox textBox연료량;
		private System.Windows.Forms.TextBox textBox할증이후회수;
		private System.Windows.Forms.TextBox textBox공차시간;
		private System.Windows.Forms.TextBox textBox키사용회수;
		private System.Windows.Forms.TextBox textBox불사용거리;
		private System.Windows.Forms.TextBox textBox주행이후회수;
		private System.Windows.Forms.TextBox textBoxKm리터;
		private System.Windows.Forms.TextBox textBox영업시간;
		private System.Windows.Forms.TextBox textBox승차율;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox textBox불사용회수;
		private System.Windows.Forms.TextBox textBox할증기본회수;
		private System.Windows.Forms.TextBox textBox과속시간;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox textBox불사용시간;
		private System.Windows.Forms.TextBox textBox주행기본회수;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox textBox수입리터;
		private System.Windows.Forms.TextBox textBox영업회수;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox운행률;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label 운전자label;
		private System.Windows.Forms.Label 차번label;
		private System.Windows.Forms.Label 입고label;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Panel panel18;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Panel panel19;
		private System.Windows.Forms.Panel panel20;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.Panel panel21;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.TextBox textBox19;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.TextBox textBox20;
		private System.Windows.Forms.TextBox textBox21;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Panel panel22;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.TextBox textBox23;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.TextBox textBox24;
		private System.Windows.Forms.Panel panel23;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.TextBox textBox25;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TextBox textBox26;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.TextBox textBox27;
		private System.Windows.Forms.Panel panel24;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.TextBox textBox28;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TextBox textBox29;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.TextBox textBox30;
		private System.Windows.Forms.Panel panel25;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.TextBox textBox31;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.TextBox textBox32;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.TextBox textBox33;
		private System.Windows.Forms.Panel panel26;
		private System.Windows.Forms.TextBox textBox34;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.TextBox textBox35;
		private System.Windows.Forms.TextBox textBox36;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label 출고label;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button button3;
		public System.Windows.Forms.ListView listView1;

		private PrintableListView.PrintableListView m_list;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zg3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox주행거리;
        private System.Windows.Forms.TextBox textBox운행시간;
        private System.Windows.Forms.TextBox textBox미터수입;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.RadioButton radioButton_전체인쇄;
        public System.Windows.Forms.RadioButton radioButton_부분인쇄;
        public System.Windows.Forms.RadioButton radioButton_종합정보인쇄;
        public System.Windows.Forms.RadioButton radioButton_영업상세;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.TextBox textBox_carnum;
	}
}