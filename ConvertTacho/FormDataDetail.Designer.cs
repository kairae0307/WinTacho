namespace ConvertTacho
{
    partial class FormDataDetail
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
			this.checkedListBoxDriver = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxCar = new System.Windows.Forms.CheckedListBox();
			this.checkBox차량구분 = new System.Windows.Forms.CheckBox();
			this.checkBox기사구분 = new System.Windows.Forms.CheckBox();
			this.checkBox수입 = new System.Windows.Forms.CheckBox();
			this.textBox수입 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton수입이상 = new System.Windows.Forms.RadioButton();
			this.radioButton수입이하 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox과속 = new System.Windows.Forms.CheckBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.checkBox전체차량 = new System.Windows.Forms.CheckBox();
			this.checkBox전체기사 = new System.Windows.Forms.CheckBox();
			this.tabControl날짜 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkBox입고일 = new System.Windows.Forms.CheckBox();
			this.checkBox출고일 = new System.Windows.Forms.CheckBox();
			this.dateTimePicker출고일 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker입고일 = new System.Windows.Forms.DateTimePicker();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox검색종료일AMPM = new System.Windows.Forms.ComboBox();
			this.checkBox기간검색 = new System.Windows.Forms.CheckBox();
			this.comboBox검색시작일AMPM = new System.Windows.Forms.ComboBox();
			this.dateTimePicker검색시작일 = new System.Windows.Forms.DateTimePicker();
			this.comboBox검색종료시 = new System.Windows.Forms.ComboBox();
			this.dateTimePicker검색종료일 = new System.Windows.Forms.DateTimePicker();
			this.comboBox검색시작시 = new System.Windows.Forms.ComboBox();
			this.textBox주행기본 = new System.Windows.Forms.TextBox();
			this.radioButton주행기본이하 = new System.Windows.Forms.RadioButton();
			this.radioButton주행기본이상 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox주행기본 = new System.Windows.Forms.CheckBox();
			this.checkBox주행이후 = new System.Windows.Forms.CheckBox();
			this.radioButton주행이후이하 = new System.Windows.Forms.RadioButton();
			this.radioButton주행이후이상 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox주행이후 = new System.Windows.Forms.TextBox();
			this.checkBox할증이후 = new System.Windows.Forms.CheckBox();
			this.radioButton할증이후이하 = new System.Windows.Forms.RadioButton();
			this.radioButton할증이후이상 = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox할증이후 = new System.Windows.Forms.TextBox();
			this.checkBox할증기본 = new System.Windows.Forms.CheckBox();
			this.radioButton할증기본이하 = new System.Windows.Forms.RadioButton();
			this.radioButton할증기본이상 = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox할증기본 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.checkBox급제동 = new System.Windows.Forms.CheckBox();
			this.Run = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioButton_타코 = new System.Windows.Forms.RadioButton();
			this.radioButton_일별 = new System.Windows.Forms.RadioButton();
			this.radioButton_교대분리 = new System.Windows.Forms.RadioButton();
			this.radioButton_자동분리 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.tabControl날짜.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkedListBoxDriver
			// 
			this.checkedListBoxDriver.CheckOnClick = true;
			this.checkedListBoxDriver.Enabled = false;
			this.checkedListBoxDriver.FormattingEnabled = true;
			this.checkedListBoxDriver.Location = new System.Drawing.Point(169, 56);
			this.checkedListBoxDriver.Name = "checkedListBoxDriver";
			this.checkedListBoxDriver.Size = new System.Drawing.Size(120, 132);
			this.checkedListBoxDriver.TabIndex = 1;
			this.checkedListBoxDriver.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDriver_ItemCheck);
			// 
			// checkedListBoxCar
			// 
			this.checkedListBoxCar.CheckOnClick = true;
			this.checkedListBoxCar.Enabled = false;
			this.checkedListBoxCar.FormattingEnabled = true;
			this.checkedListBoxCar.Location = new System.Drawing.Point(21, 56);
			this.checkedListBoxCar.Name = "checkedListBoxCar";
			this.checkedListBoxCar.Size = new System.Drawing.Size(120, 132);
			this.checkedListBoxCar.TabIndex = 2;
			this.checkedListBoxCar.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCar_ItemCheck);
			// 
			// checkBox차량구분
			// 
			this.checkBox차량구분.AutoSize = true;
			this.checkBox차량구분.Location = new System.Drawing.Point(21, 18);
			this.checkBox차량구분.Name = "checkBox차량구분";
			this.checkBox차량구분.Size = new System.Drawing.Size(76, 16);
			this.checkBox차량구분.TabIndex = 7;
			this.checkBox차량구분.Text = "차량 구분";
			this.checkBox차량구분.UseVisualStyleBackColor = true;
			this.checkBox차량구분.CheckedChanged += new System.EventHandler(this.checkBox차량구분_CheckedChanged);
			// 
			// checkBox기사구분
			// 
			this.checkBox기사구분.AutoSize = true;
			this.checkBox기사구분.Location = new System.Drawing.Point(169, 18);
			this.checkBox기사구분.Name = "checkBox기사구분";
			this.checkBox기사구분.Size = new System.Drawing.Size(76, 16);
			this.checkBox기사구분.TabIndex = 7;
			this.checkBox기사구분.Text = "기사 구분";
			this.checkBox기사구분.UseVisualStyleBackColor = true;
			this.checkBox기사구분.CheckedChanged += new System.EventHandler(this.checkBox기사구분_CheckedChanged);
			// 
			// checkBox수입
			// 
			this.checkBox수입.AutoSize = true;
			this.checkBox수입.Location = new System.Drawing.Point(8, 20);
			this.checkBox수입.Name = "checkBox수입";
			this.checkBox수입.Size = new System.Drawing.Size(48, 16);
			this.checkBox수입.TabIndex = 8;
			this.checkBox수입.Text = "수입";
			this.checkBox수입.UseVisualStyleBackColor = true;
			this.checkBox수입.CheckedChanged += new System.EventHandler(this.checkBox수입_CheckedChanged);
			// 
			// textBox수입
			// 
			this.textBox수입.Enabled = false;
			this.textBox수입.Location = new System.Drawing.Point(67, 18);
			this.textBox수입.MaxLength = 10;
			this.textBox수입.Name = "textBox수입";
			this.textBox수입.Size = new System.Drawing.Size(78, 21);
			this.textBox수입.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "원";
			// 
			// radioButton수입이상
			// 
			this.radioButton수입이상.AutoSize = true;
			this.radioButton수입이상.Checked = true;
			this.radioButton수입이상.Enabled = false;
			this.radioButton수입이상.Location = new System.Drawing.Point(167, 12);
			this.radioButton수입이상.Name = "radioButton수입이상";
			this.radioButton수입이상.Size = new System.Drawing.Size(47, 16);
			this.radioButton수입이상.TabIndex = 11;
			this.radioButton수입이상.TabStop = true;
			this.radioButton수입이상.Text = "이상";
			this.radioButton수입이상.UseVisualStyleBackColor = true;
			// 
			// radioButton수입이하
			// 
			this.radioButton수입이하.AutoSize = true;
			this.radioButton수입이하.Enabled = false;
			this.radioButton수입이하.Location = new System.Drawing.Point(167, 31);
			this.radioButton수입이하.Name = "radioButton수입이하";
			this.radioButton수입이하.Size = new System.Drawing.Size(47, 16);
			this.radioButton수입이하.TabIndex = 11;
			this.radioButton수입이하.Text = "이하";
			this.radioButton수입이하.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton수입이하);
			this.groupBox1.Controls.Add(this.radioButton수입이상);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox수입);
			this.groupBox1.Controls.Add(this.checkBox수입);
			this.groupBox1.Location = new System.Drawing.Point(308, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(222, 52);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// checkBox과속
			// 
			this.checkBox과속.AutoSize = true;
			this.checkBox과속.Location = new System.Drawing.Point(316, 133);
			this.checkBox과속.Name = "checkBox과속";
			this.checkBox과속.Size = new System.Drawing.Size(76, 16);
			this.checkBox과속.TabIndex = 13;
			this.checkBox과속.Text = "과속 여부";
			this.checkBox과속.UseVisualStyleBackColor = true;
			// 
			// buttonSearch
			// 
			this.buttonSearch.Location = new System.Drawing.Point(433, 119);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(97, 69);
			this.buttonSearch.TabIndex = 14;
			this.buttonSearch.Text = "검색 시작";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// checkBox전체차량
			// 
			this.checkBox전체차량.AutoSize = true;
			this.checkBox전체차량.Enabled = false;
			this.checkBox전체차량.Location = new System.Drawing.Point(24, 40);
			this.checkBox전체차량.Name = "checkBox전체차량";
			this.checkBox전체차량.Size = new System.Drawing.Size(76, 16);
			this.checkBox전체차량.TabIndex = 15;
			this.checkBox전체차량.Text = "전체 차량";
			this.checkBox전체차량.UseVisualStyleBackColor = true;
			this.checkBox전체차량.CheckedChanged += new System.EventHandler(this.checkBox전체차량_CheckedChanged);
			// 
			// checkBox전체기사
			// 
			this.checkBox전체기사.AutoSize = true;
			this.checkBox전체기사.Enabled = false;
			this.checkBox전체기사.Location = new System.Drawing.Point(172, 40);
			this.checkBox전체기사.Name = "checkBox전체기사";
			this.checkBox전체기사.Size = new System.Drawing.Size(76, 16);
			this.checkBox전체기사.TabIndex = 15;
			this.checkBox전체기사.Text = "전체 기사";
			this.checkBox전체기사.UseVisualStyleBackColor = true;
			this.checkBox전체기사.CheckedChanged += new System.EventHandler(this.checkBox전체기사_CheckedChanged);
			// 
			// tabControl날짜
			// 
			this.tabControl날짜.Controls.Add(this.tabPage1);
			this.tabControl날짜.Controls.Add(this.tabPage2);
			this.tabControl날짜.Location = new System.Drawing.Point(17, 206);
			this.tabControl날짜.Name = "tabControl날짜";
			this.tabControl날짜.SelectedIndex = 1;
			this.tabControl날짜.Size = new System.Drawing.Size(279, 210);
			this.tabControl날짜.TabIndex = 25;
			this.tabControl날짜.SelectedIndexChanged += new System.EventHandler(this.tabControl날짜_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.checkBox입고일);
			this.tabPage1.Controls.Add(this.checkBox출고일);
			this.tabPage1.Controls.Add(this.dateTimePicker출고일);
			this.tabPage1.Controls.Add(this.dateTimePicker입고일);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(271, 185);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "입/출고일 검색";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBox입고일
			// 
			this.checkBox입고일.AutoSize = true;
			this.checkBox입고일.Location = new System.Drawing.Point(57, 71);
			this.checkBox입고일.Name = "checkBox입고일";
			this.checkBox입고일.Size = new System.Drawing.Size(60, 16);
			this.checkBox입고일.TabIndex = 7;
			this.checkBox입고일.Text = "입고일";
			this.checkBox입고일.UseVisualStyleBackColor = true;
			this.checkBox입고일.CheckedChanged += new System.EventHandler(this.checkBox입고일_CheckedChanged_1);
			// 
			// checkBox출고일
			// 
			this.checkBox출고일.AutoSize = true;
			this.checkBox출고일.Location = new System.Drawing.Point(57, 18);
			this.checkBox출고일.Name = "checkBox출고일";
			this.checkBox출고일.Size = new System.Drawing.Size(60, 16);
			this.checkBox출고일.TabIndex = 7;
			this.checkBox출고일.Text = "출고일";
			this.checkBox출고일.UseVisualStyleBackColor = true;
			this.checkBox출고일.CheckedChanged += new System.EventHandler(this.checkBox출고일_CheckedChanged_1);
			// 
			// dateTimePicker출고일
			// 
			this.dateTimePicker출고일.Checked = false;
			this.dateTimePicker출고일.Enabled = false;
			this.dateTimePicker출고일.Location = new System.Drawing.Point(57, 40);
			this.dateTimePicker출고일.Name = "dateTimePicker출고일";
			this.dateTimePicker출고일.Size = new System.Drawing.Size(157, 21);
			this.dateTimePicker출고일.TabIndex = 3;
			// 
			// dateTimePicker입고일
			// 
			this.dateTimePicker입고일.Enabled = false;
			this.dateTimePicker입고일.Location = new System.Drawing.Point(57, 93);
			this.dateTimePicker입고일.Name = "dateTimePicker입고일";
			this.dateTimePicker입고일.Size = new System.Drawing.Size(157, 21);
			this.dateTimePicker입고일.TabIndex = 4;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.comboBox검색종료일AMPM);
			this.tabPage2.Controls.Add(this.checkBox기간검색);
			this.tabPage2.Controls.Add(this.comboBox검색시작일AMPM);
			this.tabPage2.Controls.Add(this.dateTimePicker검색시작일);
			this.tabPage2.Controls.Add(this.comboBox검색종료시);
			this.tabPage2.Controls.Add(this.dateTimePicker검색종료일);
			this.tabPage2.Controls.Add(this.comboBox검색시작시);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(271, 185);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "기간 검색";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 140);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 12);
			this.label7.TabIndex = 20;
			this.label7.Text = "검색 종료일";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 87);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 12);
			this.label6.TabIndex = 20;
			this.label6.Text = "검색 시작일";
			// 
			// comboBox검색종료일AMPM
			// 
			this.comboBox검색종료일AMPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox검색종료일AMPM.Enabled = false;
			this.comboBox검색종료일AMPM.FormattingEnabled = true;
			this.comboBox검색종료일AMPM.Items.AddRange(new object[] {
            "오전",
            "오후"});
			this.comboBox검색종료일AMPM.Location = new System.Drawing.Point(137, 155);
			this.comboBox검색종료일AMPM.Name = "comboBox검색종료일AMPM";
			this.comboBox검색종료일AMPM.Size = new System.Drawing.Size(50, 20);
			this.comboBox검색종료일AMPM.TabIndex = 18;
			this.comboBox검색종료일AMPM.SelectedIndexChanged += new System.EventHandler(this.comboBox검색종료일AMPM_SelectedIndexChanged);
			// 
			// checkBox기간검색
			// 
			this.checkBox기간검색.AutoSize = true;
			this.checkBox기간검색.Location = new System.Drawing.Point(7, 4);
			this.checkBox기간검색.Name = "checkBox기간검색";
			this.checkBox기간검색.Size = new System.Drawing.Size(76, 16);
			this.checkBox기간검색.TabIndex = 7;
			this.checkBox기간검색.Text = "기간 검색";
			this.checkBox기간검색.UseVisualStyleBackColor = true;
			this.checkBox기간검색.CheckedChanged += new System.EventHandler(this.checkBox기간검색_CheckedChanged);
			// 
			// comboBox검색시작일AMPM
			// 
			this.comboBox검색시작일AMPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox검색시작일AMPM.Enabled = false;
			this.comboBox검색시작일AMPM.FormattingEnabled = true;
			this.comboBox검색시작일AMPM.Items.AddRange(new object[] {
            "오전",
            "오후"});
			this.comboBox검색시작일AMPM.Location = new System.Drawing.Point(137, 102);
			this.comboBox검색시작일AMPM.Name = "comboBox검색시작일AMPM";
			this.comboBox검색시작일AMPM.Size = new System.Drawing.Size(50, 20);
			this.comboBox검색시작일AMPM.TabIndex = 19;
			this.comboBox검색시작일AMPM.SelectedIndexChanged += new System.EventHandler(this.comboBox검색시작일AMPM_SelectedIndexChanged);
			// 
			// dateTimePicker검색시작일
			// 
			this.dateTimePicker검색시작일.Checked = false;
			this.dateTimePicker검색시작일.Enabled = false;
			this.dateTimePicker검색시작일.Location = new System.Drawing.Point(16, 102);
			this.dateTimePicker검색시작일.Name = "dateTimePicker검색시작일";
			this.dateTimePicker검색시작일.Size = new System.Drawing.Size(115, 21);
			this.dateTimePicker검색시작일.TabIndex = 3;
			// 
			// comboBox검색종료시
			// 
			this.comboBox검색종료시.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox검색종료시.Enabled = false;
			this.comboBox검색종료시.FormattingEnabled = true;
			this.comboBox검색종료시.Items.AddRange(new object[] {
            "0시",
            "1시",
            "2시",
            "3시",
            "4시",
            "5시",
            "6시",
            "7시",
            "8시",
            "9시",
            "10시",
            "11시"});
			this.comboBox검색종료시.Location = new System.Drawing.Point(193, 155);
			this.comboBox검색종료시.Name = "comboBox검색종료시";
			this.comboBox검색종료시.Size = new System.Drawing.Size(48, 20);
			this.comboBox검색종료시.TabIndex = 16;
			// 
			// dateTimePicker검색종료일
			// 
			this.dateTimePicker검색종료일.Enabled = false;
			this.dateTimePicker검색종료일.Location = new System.Drawing.Point(16, 155);
			this.dateTimePicker검색종료일.Name = "dateTimePicker검색종료일";
			this.dateTimePicker검색종료일.Size = new System.Drawing.Size(115, 21);
			this.dateTimePicker검색종료일.TabIndex = 4;
			// 
			// comboBox검색시작시
			// 
			this.comboBox검색시작시.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox검색시작시.Enabled = false;
			this.comboBox검색시작시.FormattingEnabled = true;
			this.comboBox검색시작시.Items.AddRange(new object[] {
            "0시",
            "1시",
            "2시",
            "3시",
            "4시",
            "5시",
            "6시",
            "7시",
            "8시",
            "9시",
            "10시",
            "11시"});
			this.comboBox검색시작시.Location = new System.Drawing.Point(193, 102);
			this.comboBox검색시작시.Name = "comboBox검색시작시";
			this.comboBox검색시작시.Size = new System.Drawing.Size(48, 20);
			this.comboBox검색시작시.TabIndex = 17;
			// 
			// textBox주행기본
			// 
			this.textBox주행기본.Enabled = false;
			this.textBox주행기본.Location = new System.Drawing.Point(84, 19);
			this.textBox주행기본.MaxLength = 8;
			this.textBox주행기본.Name = "textBox주행기본";
			this.textBox주행기본.Size = new System.Drawing.Size(61, 21);
			this.textBox주행기본.TabIndex = 26;
			// 
			// radioButton주행기본이하
			// 
			this.radioButton주행기본이하.AutoSize = true;
			this.radioButton주행기본이하.Enabled = false;
			this.radioButton주행기본이하.Location = new System.Drawing.Point(167, 30);
			this.radioButton주행기본이하.Name = "radioButton주행기본이하";
			this.radioButton주행기본이하.Size = new System.Drawing.Size(47, 16);
			this.radioButton주행기본이하.TabIndex = 13;
			this.radioButton주행기본이하.Text = "이하";
			this.radioButton주행기본이하.UseVisualStyleBackColor = true;
			// 
			// radioButton주행기본이상
			// 
			this.radioButton주행기본이상.AutoSize = true;
			this.radioButton주행기본이상.Checked = true;
			this.radioButton주행기본이상.Enabled = false;
			this.radioButton주행기본이상.Location = new System.Drawing.Point(167, 11);
			this.radioButton주행기본이상.Name = "radioButton주행기본이상";
			this.radioButton주행기본이상.Size = new System.Drawing.Size(47, 16);
			this.radioButton주행기본이상.TabIndex = 14;
			this.radioButton주행기본이상.TabStop = true;
			this.radioButton주행기본이상.Text = "이상";
			this.radioButton주행기본이상.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 12;
			this.label2.Text = "회";
			// 
			// checkBox주행기본
			// 
			this.checkBox주행기본.AutoSize = true;
			this.checkBox주행기본.Location = new System.Drawing.Point(8, 22);
			this.checkBox주행기본.Name = "checkBox주행기본";
			this.checkBox주행기본.Size = new System.Drawing.Size(76, 16);
			this.checkBox주행기본.TabIndex = 27;
			this.checkBox주행기본.Text = "주행 기본";
			this.checkBox주행기본.UseVisualStyleBackColor = true;
			this.checkBox주행기본.CheckedChanged += new System.EventHandler(this.checkBox주행기본_CheckedChanged);
			// 
			// checkBox주행이후
			// 
			this.checkBox주행이후.AutoSize = true;
			this.checkBox주행이후.Location = new System.Drawing.Point(8, 24);
			this.checkBox주행이후.Name = "checkBox주행이후";
			this.checkBox주행이후.Size = new System.Drawing.Size(76, 16);
			this.checkBox주행이후.TabIndex = 32;
			this.checkBox주행이후.Text = "주행 이후";
			this.checkBox주행이후.UseVisualStyleBackColor = true;
			this.checkBox주행이후.CheckedChanged += new System.EventHandler(this.checkBox주행이후_CheckedChanged);
			// 
			// radioButton주행이후이하
			// 
			this.radioButton주행이후이하.AutoSize = true;
			this.radioButton주행이후이하.Enabled = false;
			this.radioButton주행이후이하.Location = new System.Drawing.Point(167, 32);
			this.radioButton주행이후이하.Name = "radioButton주행이후이하";
			this.radioButton주행이후이하.Size = new System.Drawing.Size(47, 16);
			this.radioButton주행이후이하.TabIndex = 29;
			this.radioButton주행이후이하.Text = "이하";
			this.radioButton주행이후이하.UseVisualStyleBackColor = true;
			// 
			// radioButton주행이후이상
			// 
			this.radioButton주행이후이상.AutoSize = true;
			this.radioButton주행이후이상.Checked = true;
			this.radioButton주행이후이상.Enabled = false;
			this.radioButton주행이후이상.Location = new System.Drawing.Point(167, 13);
			this.radioButton주행이후이상.Name = "radioButton주행이후이상";
			this.radioButton주행이후이상.Size = new System.Drawing.Size(47, 16);
			this.radioButton주행이후이상.TabIndex = 30;
			this.radioButton주행이후이상.TabStop = true;
			this.radioButton주행이후이상.Text = "이상";
			this.radioButton주행이후이상.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(150, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 12);
			this.label3.TabIndex = 28;
			this.label3.Text = "회";
			// 
			// textBox주행이후
			// 
			this.textBox주행이후.Enabled = false;
			this.textBox주행이후.Location = new System.Drawing.Point(84, 21);
			this.textBox주행이후.MaxLength = 8;
			this.textBox주행이후.Name = "textBox주행이후";
			this.textBox주행이후.Size = new System.Drawing.Size(61, 21);
			this.textBox주행이후.TabIndex = 31;
			// 
			// checkBox할증이후
			// 
			this.checkBox할증이후.AutoSize = true;
			this.checkBox할증이후.Location = new System.Drawing.Point(8, 24);
			this.checkBox할증이후.Name = "checkBox할증이후";
			this.checkBox할증이후.Size = new System.Drawing.Size(76, 16);
			this.checkBox할증이후.TabIndex = 42;
			this.checkBox할증이후.Text = "할증 이후";
			this.checkBox할증이후.UseVisualStyleBackColor = true;
			this.checkBox할증이후.CheckedChanged += new System.EventHandler(this.checkBox할증이후_CheckedChanged);
			// 
			// radioButton할증이후이하
			// 
			this.radioButton할증이후이하.AutoSize = true;
			this.radioButton할증이후이하.Enabled = false;
			this.radioButton할증이후이하.Location = new System.Drawing.Point(167, 32);
			this.radioButton할증이후이하.Name = "radioButton할증이후이하";
			this.radioButton할증이후이하.Size = new System.Drawing.Size(47, 16);
			this.radioButton할증이후이하.TabIndex = 39;
			this.radioButton할증이후이하.Text = "이하";
			this.radioButton할증이후이하.UseVisualStyleBackColor = true;
			// 
			// radioButton할증이후이상
			// 
			this.radioButton할증이후이상.AutoSize = true;
			this.radioButton할증이후이상.Checked = true;
			this.radioButton할증이후이상.Enabled = false;
			this.radioButton할증이후이상.Location = new System.Drawing.Point(167, 13);
			this.radioButton할증이후이상.Name = "radioButton할증이후이상";
			this.radioButton할증이후이상.Size = new System.Drawing.Size(47, 16);
			this.radioButton할증이후이상.TabIndex = 40;
			this.radioButton할증이후이상.TabStop = true;
			this.radioButton할증이후이상.Text = "이상";
			this.radioButton할증이후이상.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(150, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 38;
			this.label4.Text = "회";
			// 
			// textBox할증이후
			// 
			this.textBox할증이후.Enabled = false;
			this.textBox할증이후.Location = new System.Drawing.Point(84, 21);
			this.textBox할증이후.MaxLength = 8;
			this.textBox할증이후.Name = "textBox할증이후";
			this.textBox할증이후.Size = new System.Drawing.Size(61, 21);
			this.textBox할증이후.TabIndex = 41;
			// 
			// checkBox할증기본
			// 
			this.checkBox할증기본.AutoSize = true;
			this.checkBox할증기본.Location = new System.Drawing.Point(8, 24);
			this.checkBox할증기본.Name = "checkBox할증기본";
			this.checkBox할증기본.Size = new System.Drawing.Size(76, 16);
			this.checkBox할증기본.TabIndex = 37;
			this.checkBox할증기본.Text = "할증 기본";
			this.checkBox할증기본.UseVisualStyleBackColor = true;
			this.checkBox할증기본.CheckedChanged += new System.EventHandler(this.checkBox할증기본_CheckedChanged);
			// 
			// radioButton할증기본이하
			// 
			this.radioButton할증기본이하.AutoSize = true;
			this.radioButton할증기본이하.Enabled = false;
			this.radioButton할증기본이하.Location = new System.Drawing.Point(167, 32);
			this.radioButton할증기본이하.Name = "radioButton할증기본이하";
			this.radioButton할증기본이하.Size = new System.Drawing.Size(47, 16);
			this.radioButton할증기본이하.TabIndex = 34;
			this.radioButton할증기본이하.Text = "이하";
			this.radioButton할증기본이하.UseVisualStyleBackColor = true;
			// 
			// radioButton할증기본이상
			// 
			this.radioButton할증기본이상.AutoSize = true;
			this.radioButton할증기본이상.Checked = true;
			this.radioButton할증기본이상.Enabled = false;
			this.radioButton할증기본이상.Location = new System.Drawing.Point(167, 13);
			this.radioButton할증기본이상.Name = "radioButton할증기본이상";
			this.radioButton할증기본이상.Size = new System.Drawing.Size(47, 16);
			this.radioButton할증기본이상.TabIndex = 35;
			this.radioButton할증기본이상.TabStop = true;
			this.radioButton할증기본이상.Text = "이상";
			this.radioButton할증기본이상.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(150, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 33;
			this.label5.Text = "회";
			// 
			// textBox할증기본
			// 
			this.textBox할증기본.Enabled = false;
			this.textBox할증기본.Location = new System.Drawing.Point(84, 21);
			this.textBox할증기본.MaxLength = 8;
			this.textBox할증기본.Name = "textBox할증기본";
			this.textBox할증기본.Size = new System.Drawing.Size(61, 21);
			this.textBox할증기본.TabIndex = 36;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox주행기본);
			this.groupBox2.Controls.Add(this.radioButton주행기본이하);
			this.groupBox2.Controls.Add(this.radioButton주행기본이상);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBox주행기본);
			this.groupBox2.Location = new System.Drawing.Point(308, 206);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(222, 51);
			this.groupBox2.TabIndex = 43;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox주행이후);
			this.groupBox3.Controls.Add(this.radioButton주행이후이하);
			this.groupBox3.Controls.Add(this.radioButton주행이후이상);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.textBox주행이후);
			this.groupBox3.Location = new System.Drawing.Point(308, 258);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(222, 51);
			this.groupBox3.TabIndex = 44;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkBox할증기본);
			this.groupBox4.Controls.Add(this.radioButton할증기본이하);
			this.groupBox4.Controls.Add(this.radioButton할증기본이상);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.textBox할증기본);
			this.groupBox4.Location = new System.Drawing.Point(308, 309);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(222, 51);
			this.groupBox4.TabIndex = 45;
			this.groupBox4.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.checkBox할증이후);
			this.groupBox5.Controls.Add(this.radioButton할증이후이하);
			this.groupBox5.Controls.Add(this.radioButton할증이후이상);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.textBox할증이후);
			this.groupBox5.Location = new System.Drawing.Point(308, 360);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(222, 51);
			this.groupBox5.TabIndex = 46;
			this.groupBox5.TabStop = false;
			// 
			// checkBox급제동
			// 
			this.checkBox급제동.AutoSize = true;
			this.checkBox급제동.Location = new System.Drawing.Point(316, 166);
			this.checkBox급제동.Name = "checkBox급제동";
			this.checkBox급제동.Size = new System.Drawing.Size(88, 16);
			this.checkBox급제동.TabIndex = 13;
			this.checkBox급제동.Text = "급제동 여부";
			this.checkBox급제동.UseVisualStyleBackColor = true;
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(103, 27);
			this.Run.Name = "Run";
			this.Run.Size = new System.Drawing.Size(40, 23);
			this.Run.TabIndex = 47;
			this.Run.Text = "정렬";
			this.Run.UseVisualStyleBackColor = true;
			this.Run.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioButton_자동분리);
			this.groupBox6.Controls.Add(this.radioButton_교대분리);
			this.groupBox6.Controls.Add(this.radioButton_일별);
			this.groupBox6.Controls.Add(this.radioButton_타코);
			this.groupBox6.Location = new System.Drawing.Point(3, 24);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(262, 60);
			this.groupBox6.TabIndex = 25;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "타코 선택";
			// 
			// radioButton_타코
			// 
			this.radioButton_타코.AutoSize = true;
			this.radioButton_타코.Location = new System.Drawing.Point(4, 14);
			this.radioButton_타코.Name = "radioButton_타코";
			this.radioButton_타코.Size = new System.Drawing.Size(51, 16);
			this.radioButton_타코.TabIndex = 11;
			this.radioButton_타코.TabStop = true;
			this.radioButton_타코.Text = "타코 ";
			this.radioButton_타코.UseVisualStyleBackColor = true;
			// 
			// radioButton_일별
			// 
			this.radioButton_일별.AutoSize = true;
			this.radioButton_일별.Location = new System.Drawing.Point(76, 14);
			this.radioButton_일별.Name = "radioButton_일별";
			this.radioButton_일별.Size = new System.Drawing.Size(71, 16);
			this.radioButton_일별.TabIndex = 12;
			this.radioButton_일별.TabStop = true;
			this.radioButton_일별.Text = "일별타코";
			this.radioButton_일별.UseVisualStyleBackColor = true;
			// 
			// radioButton_교대분리
			// 
			this.radioButton_교대분리.AutoSize = true;
			this.radioButton_교대분리.Location = new System.Drawing.Point(161, 14);
			this.radioButton_교대분리.Name = "radioButton_교대분리";
			this.radioButton_교대분리.Size = new System.Drawing.Size(95, 16);
			this.radioButton_교대분리.TabIndex = 13;
			this.radioButton_교대분리.TabStop = true;
			this.radioButton_교대분리.Text = "교대분리타코";
			this.radioButton_교대분리.UseVisualStyleBackColor = true;
			// 
			// radioButton_자동분리
			// 
			this.radioButton_자동분리.AutoSize = true;
			this.radioButton_자동분리.Location = new System.Drawing.Point(4, 36);
			this.radioButton_자동분리.Name = "radioButton_자동분리";
			this.radioButton_자동분리.Size = new System.Drawing.Size(95, 16);
			this.radioButton_자동분리.TabIndex = 14;
			this.radioButton_자동분리.TabStop = true;
			this.radioButton_자동분리.Text = "자동분리타코";
			this.radioButton_자동분리.UseVisualStyleBackColor = true;
			// 
			// FormDataDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 430);
			this.Controls.Add(this.Run);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tabControl날짜);
			this.Controls.Add(this.checkBox전체기사);
			this.Controls.Add(this.checkBox전체차량);
			this.Controls.Add(this.buttonSearch);
			this.Controls.Add(this.checkBox급제동);
			this.Controls.Add(this.checkBox과속);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkBox기사구분);
			this.Controls.Add(this.checkBox차량구분);
			this.Controls.Add(this.checkedListBoxCar);
			this.Controls.Add(this.checkedListBoxDriver);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDataDetail";
			this.Text = "세부정보 검색";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataDetail_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl날짜.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxDriver;
        private System.Windows.Forms.CheckedListBox checkedListBoxCar;
        private System.Windows.Forms.CheckBox checkBox차량구분;
        private System.Windows.Forms.CheckBox checkBox기사구분;
        private System.Windows.Forms.CheckBox checkBox수입;
        private System.Windows.Forms.TextBox textBox수입;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton수입이상;
        private System.Windows.Forms.RadioButton radioButton수입이하;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox과속;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckBox checkBox전체차량;
        private System.Windows.Forms.CheckBox checkBox전체기사;
        private System.Windows.Forms.TabControl tabControl날짜;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox입고일;
        private System.Windows.Forms.CheckBox checkBox출고일;
        private System.Windows.Forms.DateTimePicker dateTimePicker출고일;
        private System.Windows.Forms.DateTimePicker dateTimePicker입고일;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox검색종료일AMPM;
        private System.Windows.Forms.CheckBox checkBox기간검색;
        private System.Windows.Forms.ComboBox comboBox검색시작일AMPM;
        private System.Windows.Forms.DateTimePicker dateTimePicker검색시작일;
        private System.Windows.Forms.ComboBox comboBox검색종료시;
        private System.Windows.Forms.DateTimePicker dateTimePicker검색종료일;
        private System.Windows.Forms.ComboBox comboBox검색시작시;
        private System.Windows.Forms.TextBox textBox주행기본;
        private System.Windows.Forms.RadioButton radioButton주행기본이하;
        private System.Windows.Forms.RadioButton radioButton주행기본이상;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox주행기본;
        private System.Windows.Forms.CheckBox checkBox주행이후;
        private System.Windows.Forms.RadioButton radioButton주행이후이하;
        private System.Windows.Forms.RadioButton radioButton주행이후이상;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox주행이후;
        private System.Windows.Forms.CheckBox checkBox할증이후;
        private System.Windows.Forms.RadioButton radioButton할증이후이하;
        private System.Windows.Forms.RadioButton radioButton할증이후이상;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox할증이후;
        private System.Windows.Forms.CheckBox checkBox할증기본;
        private System.Windows.Forms.RadioButton radioButton할증기본이하;
        private System.Windows.Forms.RadioButton radioButton할증기본이상;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox할증기본;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox급제동;
		private System.Windows.Forms.Button Run;
		private System.Windows.Forms.GroupBox groupBox6;
		public System.Windows.Forms.RadioButton radioButton_자동분리;
		public System.Windows.Forms.RadioButton radioButton_교대분리;
		public System.Windows.Forms.RadioButton radioButton_일별;
		public System.Windows.Forms.RadioButton radioButton_타코;
    }
}