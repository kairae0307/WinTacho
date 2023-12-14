namespace ConvertTacho
{
	partial class ScheduleTimerForm
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
			this.numSec = new System.Windows.Forms.NumericUpDown();
			this.numMin = new System.Windows.Forms.NumericUpDown();
			this.numHour = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numSec1 = new System.Windows.Forms.NumericUpDown();
			this.numMin1 = new System.Windows.Forms.NumericUpDown();
			this.numHour1 = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.radioButton_use = new System.Windows.Forms.RadioButton();
			this.radioButton_notuse = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.numSec)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSec1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMin1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "1. 실행 예약시간 :";
			// 
			// numSec
			// 
			this.numSec.Location = new System.Drawing.Point(227, 34);
			this.numSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numSec.Name = "numSec";
			this.numSec.Size = new System.Drawing.Size(50, 21);
			this.numSec.TabIndex = 8;
			// 
			// numMin
			// 
			this.numMin.Location = new System.Drawing.Point(171, 34);
			this.numMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numMin.Name = "numMin";
			this.numMin.Size = new System.Drawing.Size(50, 21);
			this.numMin.TabIndex = 7;
			// 
			// numHour
			// 
			this.numHour.Location = new System.Drawing.Point(115, 34);
			this.numHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.numHour.Name = "numHour";
			this.numHour.Size = new System.Drawing.Size(50, 21);
			this.numHour.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(296, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 59);
			this.button1.TabIndex = 9;
			this.button1.Text = "설정하기";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(225, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 12;
			this.label4.Text = "초";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(169, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "분";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(113, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "시";
			// 
			// numSec1
			// 
			this.numSec1.Location = new System.Drawing.Point(227, 70);
			this.numSec1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numSec1.Name = "numSec1";
			this.numSec1.Size = new System.Drawing.Size(50, 21);
			this.numSec1.TabIndex = 16;
			// 
			// numMin1
			// 
			this.numMin1.Location = new System.Drawing.Point(171, 70);
			this.numMin1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numMin1.Name = "numMin1";
			this.numMin1.Size = new System.Drawing.Size(50, 21);
			this.numMin1.TabIndex = 15;
			// 
			// numHour1
			// 
			this.numHour1.Location = new System.Drawing.Point(115, 70);
			this.numHour1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.numHour1.Name = "numHour1";
			this.numHour1.Size = new System.Drawing.Size(50, 21);
			this.numHour1.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 12);
			this.label5.TabIndex = 13;
			this.label5.Text = "2. 실행 예약시간 :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 114);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 12);
			this.label6.TabIndex = 17;
			this.label6.Text = "3. 타코 파싱       :";
			// 
			// radioButton_use
			// 
			this.radioButton_use.AutoSize = true;
			this.radioButton_use.Location = new System.Drawing.Point(132, 112);
			this.radioButton_use.Name = "radioButton_use";
			this.radioButton_use.Size = new System.Drawing.Size(47, 16);
			this.radioButton_use.TabIndex = 18;
			this.radioButton_use.TabStop = true;
			this.radioButton_use.Text = "사용";
			this.radioButton_use.UseVisualStyleBackColor = true;
			// 
			// radioButton_notuse
			// 
			this.radioButton_notuse.AutoSize = true;
			this.radioButton_notuse.Location = new System.Drawing.Point(197, 112);
			this.radioButton_notuse.Name = "radioButton_notuse";
			this.radioButton_notuse.Size = new System.Drawing.Size(59, 16);
			this.radioButton_notuse.TabIndex = 19;
			this.radioButton_notuse.TabStop = true;
			this.radioButton_notuse.Text = "불사용";
			this.radioButton_notuse.UseVisualStyleBackColor = true;
			// 
			// ScheduleTimerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(374, 158);
			this.Controls.Add(this.radioButton_use);
			this.Controls.Add(this.radioButton_notuse);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numSec1);
			this.Controls.Add(this.numMin1);
			this.Controls.Add(this.numHour1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.numSec);
			this.Controls.Add(this.numMin);
			this.Controls.Add(this.numHour);
			this.Controls.Add(this.label1);
			this.Name = "ScheduleTimerForm";
			this.Text = "판독기 수신시간 설정";
			((System.ComponentModel.ISupportInitialize)(this.numSec)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSec1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMin1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numSec;
		private System.Windows.Forms.NumericUpDown numMin;
		private System.Windows.Forms.NumericUpDown numHour;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numSec1;
		private System.Windows.Forms.NumericUpDown numMin1;
		private System.Windows.Forms.NumericUpDown numHour1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.RadioButton radioButton_use;
		public System.Windows.Forms.RadioButton radioButton_notuse;
	}
}