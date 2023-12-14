namespace ConvertTacho
{
    partial class UserTimeForm
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
            this.radioButton_PM = new System.Windows.Forms.RadioButton();
            this.radioButton_AM = new System.Windows.Forms.RadioButton();
            this.numericUpDown_Day = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_Month = new System.Windows.Forms.NumericUpDown();
            this.radioButton_OneDay = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_Year = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button수신시작 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_PM
            // 
            this.radioButton_PM.AutoSize = true;
            this.radioButton_PM.Location = new System.Drawing.Point(362, 18);
            this.radioButton_PM.Name = "radioButton_PM";
            this.radioButton_PM.Size = new System.Drawing.Size(42, 16);
            this.radioButton_PM.TabIndex = 66;
            this.radioButton_PM.Text = "PM";
            this.radioButton_PM.UseVisualStyleBackColor = true;
            // 
            // radioButton_AM
            // 
            this.radioButton_AM.AutoSize = true;
            this.radioButton_AM.Location = new System.Drawing.Point(320, 18);
            this.radioButton_AM.Name = "radioButton_AM";
            this.radioButton_AM.Size = new System.Drawing.Size(42, 16);
            this.radioButton_AM.TabIndex = 65;
            this.radioButton_AM.Text = "AM";
            this.radioButton_AM.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Day
            // 
            this.numericUpDown_Day.Location = new System.Drawing.Point(184, 12);
            this.numericUpDown_Day.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_Day.Name = "numericUpDown_Day";
            this.numericUpDown_Day.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown_Day.TabIndex = 64;
            this.numericUpDown_Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label14.Location = new System.Drawing.Point(239, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 63;
            this.label14.Text = "일";
            // 
            // numericUpDown_Month
            // 
            this.numericUpDown_Month.Location = new System.Drawing.Point(99, 12);
            this.numericUpDown_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_Month.Name = "numericUpDown_Month";
            this.numericUpDown_Month.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown_Month.TabIndex = 62;
            this.numericUpDown_Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton_OneDay
            // 
            this.radioButton_OneDay.AutoSize = true;
            this.radioButton_OneDay.Location = new System.Drawing.Point(267, 18);
            this.radioButton_OneDay.Name = "radioButton_OneDay";
            this.radioButton_OneDay.Size = new System.Drawing.Size(53, 16);
            this.radioButton_OneDay.TabIndex = 67;
            this.radioButton_OneDay.Text = "None";
            this.radioButton_OneDay.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label13.Location = new System.Drawing.Point(156, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 61;
            this.label13.Text = "월";
            // 
            // numericUpDown_Year
            // 
            this.numericUpDown_Year.Location = new System.Drawing.Point(9, 12);
            this.numericUpDown_Year.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_Year.Name = "numericUpDown_Year";
            this.numericUpDown_Year.Size = new System.Drawing.Size(56, 21);
            this.numericUpDown_Year.TabIndex = 60;
            this.numericUpDown_Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 8.3F);
            this.label7.Location = new System.Drawing.Point(66, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "년";
            // 
            // button수신시작
            // 
            this.button수신시작.Location = new System.Drawing.Point(410, 8);
            this.button수신시작.Name = "button수신시작";
            this.button수신시작.Size = new System.Drawing.Size(72, 33);
            this.button수신시작.TabIndex = 68;
            this.button수신시작.Text = "입력";
            this.button수신시작.UseVisualStyleBackColor = true;
            this.button수신시작.Click += new System.EventHandler(this.button수신시작_Click);
            // 
            // UserTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 47);
            this.Controls.Add(this.button수신시작);
            this.Controls.Add(this.radioButton_PM);
            this.Controls.Add(this.radioButton_AM);
            this.Controls.Add(this.numericUpDown_Day);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDown_Month);
            this.Controls.Add(this.radioButton_OneDay);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDown_Year);
            this.Controls.Add(this.label7);
            this.Name = "UserTimeForm";
            this.Text = "날짜 입력";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserTimeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_PM;
        private System.Windows.Forms.RadioButton radioButton_AM;
        private System.Windows.Forms.NumericUpDown numericUpDown_Day;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_Month;
        private System.Windows.Forms.RadioButton radioButton_OneDay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_Year;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button수신시작;
    }
}