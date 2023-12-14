namespace ConvertTacho
{
    partial class FormDataSetting
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxNcount = new System.Windows.Forms.TextBox();
			this.checkBoxAnytime = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonTotal = new System.Windows.Forms.RadioButton();
			this.radioButtonYear = new System.Windows.Forms.RadioButton();
			this.radioButtonTerm = new System.Windows.Forms.RadioButton();
			this.radioButtonMonth = new System.Windows.Forms.RadioButton();
			this.radioButtonWeek = new System.Windows.Forms.RadioButton();
			this.radioButtonRecent = new System.Windows.Forms.RadioButton();
			this.buttonDefault = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBoxChange1Hour = new System.Windows.Forms.ComboBox();
			this.comboBoxChange2Hour = new System.Windows.Forms.ComboBox();
			this.checkBoxChangeSet = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "최근 자료 보기 갯수:";
			// 
			// textBoxNcount
			// 
			this.textBoxNcount.Location = new System.Drawing.Point(150, 24);
			this.textBoxNcount.Name = "textBoxNcount";
			this.textBoxNcount.Size = new System.Drawing.Size(62, 21);
			this.textBoxNcount.TabIndex = 1;
			this.textBoxNcount.Text = "25";
			this.textBoxNcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// checkBoxAnytime
			// 
			this.checkBoxAnytime.AutoSize = true;
			this.checkBoxAnytime.Location = new System.Drawing.Point(218, 27);
			this.checkBoxAnytime.Name = "checkBoxAnytime";
			this.checkBoxAnytime.Size = new System.Drawing.Size(132, 16);
			this.checkBoxAnytime.TabIndex = 2;
			this.checkBoxAnytime.Text = "볼 때마다 갯수 입력";
			this.checkBoxAnytime.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonTotal);
			this.groupBox1.Controls.Add(this.radioButtonYear);
			this.groupBox1.Controls.Add(this.radioButtonTerm);
			this.groupBox1.Controls.Add(this.radioButtonMonth);
			this.groupBox1.Controls.Add(this.radioButtonWeek);
			this.groupBox1.Controls.Add(this.radioButtonRecent);
			this.groupBox1.Location = new System.Drawing.Point(29, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(325, 50);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "기본 정렬 방식";
			// 
			// radioButtonTotal
			// 
			this.radioButtonTotal.AutoSize = true;
			this.radioButtonTotal.Checked = true;
			this.radioButtonTotal.Location = new System.Drawing.Point(254, 20);
			this.radioButtonTotal.Name = "radioButtonTotal";
			this.radioButtonTotal.Size = new System.Drawing.Size(47, 16);
			this.radioButtonTotal.TabIndex = 5;
			this.radioButtonTotal.TabStop = true;
			this.radioButtonTotal.Text = "전체";
			this.radioButtonTotal.UseVisualStyleBackColor = true;
			// 
			// radioButtonYear
			// 
			this.radioButtonYear.AutoSize = true;
			this.radioButtonYear.Location = new System.Drawing.Point(213, 20);
			this.radioButtonYear.Name = "radioButtonYear";
			this.radioButtonYear.Size = new System.Drawing.Size(35, 16);
			this.radioButtonYear.TabIndex = 4;
			this.radioButtonYear.Text = "년";
			this.radioButtonYear.UseVisualStyleBackColor = true;
			// 
			// radioButtonTerm
			// 
			this.radioButtonTerm.AutoSize = true;
			this.radioButtonTerm.Location = new System.Drawing.Point(160, 20);
			this.radioButtonTerm.Name = "radioButtonTerm";
			this.radioButtonTerm.Size = new System.Drawing.Size(47, 16);
			this.radioButtonTerm.TabIndex = 3;
			this.radioButtonTerm.Text = "분기";
			this.radioButtonTerm.UseVisualStyleBackColor = true;
			// 
			// radioButtonMonth
			// 
			this.radioButtonMonth.AutoSize = true;
			this.radioButtonMonth.Location = new System.Drawing.Point(119, 20);
			this.radioButtonMonth.Name = "radioButtonMonth";
			this.radioButtonMonth.Size = new System.Drawing.Size(35, 16);
			this.radioButtonMonth.TabIndex = 2;
			this.radioButtonMonth.Text = "월";
			this.radioButtonMonth.UseVisualStyleBackColor = true;
			// 
			// radioButtonWeek
			// 
			this.radioButtonWeek.AutoSize = true;
			this.radioButtonWeek.Location = new System.Drawing.Point(78, 20);
			this.radioButtonWeek.Name = "radioButtonWeek";
			this.radioButtonWeek.Size = new System.Drawing.Size(35, 16);
			this.radioButtonWeek.TabIndex = 1;
			this.radioButtonWeek.Text = "주";
			this.radioButtonWeek.UseVisualStyleBackColor = true;
			// 
			// radioButtonRecent
			// 
			this.radioButtonRecent.AutoSize = true;
			this.radioButtonRecent.Location = new System.Drawing.Point(25, 20);
			this.radioButtonRecent.Name = "radioButtonRecent";
			this.radioButtonRecent.Size = new System.Drawing.Size(47, 16);
			this.radioButtonRecent.TabIndex = 0;
			this.radioButtonRecent.Text = "최근";
			this.radioButtonRecent.UseVisualStyleBackColor = true;
			// 
			// buttonDefault
			// 
			this.buttonDefault.Location = new System.Drawing.Point(29, 276);
			this.buttonDefault.Name = "buttonDefault";
			this.buttonDefault.Size = new System.Drawing.Size(75, 33);
			this.buttonDefault.TabIndex = 8;
			this.buttonDefault.Text = "초기화";
			this.buttonDefault.UseVisualStyleBackColor = true;
			this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(198, 276);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 33);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "저장하기";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(279, 276);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 33);
			this.button1.TabIndex = 10;
			this.button1.Text = "종료";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBoxChange1Hour
			// 
			this.comboBoxChange1Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxChange1Hour.FormattingEnabled = true;
			this.comboBoxChange1Hour.Items.AddRange(new object[] {
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
			this.comboBoxChange1Hour.Location = new System.Drawing.Point(114, 45);
			this.comboBoxChange1Hour.Name = "comboBoxChange1Hour";
			this.comboBoxChange1Hour.Size = new System.Drawing.Size(64, 20);
			this.comboBoxChange1Hour.TabIndex = 5;
			this.comboBoxChange1Hour.SelectedIndexChanged += new System.EventHandler(this.comboBoxChange1Hour_SelectedIndexChanged);
			// 
			// comboBoxChange2Hour
			// 
			this.comboBoxChange2Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxChange2Hour.Enabled = false;
			this.comboBoxChange2Hour.FormattingEnabled = true;
			this.comboBoxChange2Hour.Items.AddRange(new object[] {
            "12시",
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
			this.comboBoxChange2Hour.Location = new System.Drawing.Point(114, 71);
			this.comboBoxChange2Hour.Name = "comboBoxChange2Hour";
			this.comboBoxChange2Hour.Size = new System.Drawing.Size(64, 20);
			this.comboBoxChange2Hour.TabIndex = 5;
			// 
			// checkBoxChangeSet
			// 
			this.checkBoxChangeSet.AutoSize = true;
			this.checkBoxChangeSet.Location = new System.Drawing.Point(11, 20);
			this.checkBoxChangeSet.Name = "checkBoxChangeSet";
			this.checkBoxChangeSet.Size = new System.Drawing.Size(76, 16);
			this.checkBoxChangeSet.TabIndex = 8;
			this.checkBoxChangeSet.Text = "개별 설정";
			this.checkBoxChangeSet.UseVisualStyleBackColor = true;
			this.checkBoxChangeSet.CheckedChanged += new System.EventHandler(this.checkBoxChangeSet_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "교대시간 오후:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "교대시간 오전:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.checkBoxChangeSet);
			this.groupBox2.Controls.Add(this.comboBoxChange2Hour);
			this.groupBox2.Controls.Add(this.comboBoxChange1Hour);
			this.groupBox2.Location = new System.Drawing.Point(29, 149);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(201, 103);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "근무 교대";
			// 
			// FormDataSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 322);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonDefault);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkBoxAnytime);
			this.Controls.Add(this.textBoxNcount);
			this.Controls.Add(this.label1);
			this.Name = "FormDataSetting";
			this.Text = "기본 환경 설정";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNcount;
        private System.Windows.Forms.CheckBox checkBoxAnytime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTotal;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonTerm;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.RadioButton radioButtonRecent;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxChange1Hour;
		private System.Windows.Forms.ComboBox comboBoxChange2Hour;
		private System.Windows.Forms.CheckBox checkBoxChangeSet;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
    }
}