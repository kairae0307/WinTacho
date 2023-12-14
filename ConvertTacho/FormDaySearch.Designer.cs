namespace WinTacho
{
	partial class FormDaySearch
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.Run = new System.Windows.Forms.Button();
			this.checkedListBoxCar = new System.Windows.Forms.CheckedListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.Run);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.checkedListBoxCar);
			this.groupBox3.Controls.Add(this.dateTimePicker1);
			this.groupBox3.Controls.Add(this.dateTimePicker2);
			this.groupBox3.Location = new System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(303, 198);
			this.groupBox3.TabIndex = 60;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "차량 선택";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(114, 12);
			this.Run.Name = "Run";
			this.Run.Size = new System.Drawing.Size(40, 23);
			this.Run.TabIndex = 51;
			this.Run.Text = "정렬";
			this.Run.UseVisualStyleBackColor = true;
			// 
			// checkedListBoxCar
			// 
			this.checkedListBoxCar.CheckOnClick = true;
			this.checkedListBoxCar.FormattingEnabled = true;
			this.checkedListBoxCar.Location = new System.Drawing.Point(6, 40);
			this.checkedListBoxCar.Name = "checkedListBoxCar";
			this.checkedListBoxCar.Size = new System.Drawing.Size(149, 148);
			this.checkedListBoxCar.TabIndex = 48;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(241, 158);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 30);
			this.button1.TabIndex = 61;
			this.button1.Text = "확인";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(172, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 12);
			this.label1.TabIndex = 66;
			this.label1.Text = "검색 종료일";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(172, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 12);
			this.label2.TabIndex = 67;
			this.label2.Text = "검색 시작일";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Checked = false;
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Location = new System.Drawing.Point(174, 56);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(115, 21);
			this.dateTimePicker1.TabIndex = 64;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Enabled = false;
			this.dateTimePicker2.Location = new System.Drawing.Point(174, 109);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(115, 21);
			this.dateTimePicker2.TabIndex = 65;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(174, 158);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(48, 30);
			this.button2.TabIndex = 62;
			this.button2.Text = "닫기";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// FormDaySearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(330, 224);
			this.Controls.Add(this.groupBox3);
			this.Name = "FormDaySearch";
			this.Text = "FormDaySearch";
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button Run;
		private System.Windows.Forms.CheckedListBox checkedListBoxCar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
	}
}