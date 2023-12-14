namespace ConvertTacho
{
	partial class FormDayInfoCal
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
            this.Run = new System.Windows.Forms.Button();
            this.checkedListBoxCar = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Carcnt_label = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(114, 12);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(40, 23);
            this.Run.TabIndex = 51;
            this.Run.Text = "정렬";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
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
            this.button1.Location = new System.Drawing.Point(124, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 30);
            this.button1.TabIndex = 52;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 30);
            this.button2.TabIndex = 53;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Carcnt_label);
            this.groupBox3.Controls.Add(this.checkedListBoxCar);
            this.groupBox3.Controls.Add(this.Run);
            this.groupBox3.Location = new System.Drawing.Point(9, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 198);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "차량 선택";
            // 
            // Carcnt_label
            // 
            this.Carcnt_label.AutoSize = true;
            this.Carcnt_label.Location = new System.Drawing.Point(6, 23);
            this.Carcnt_label.Name = "Carcnt_label";
            this.Carcnt_label.Size = new System.Drawing.Size(65, 12);
            this.Carcnt_label.TabIndex = 53;
            this.Carcnt_label.Text = "총 차량수 :";
            // 
            // FormDayInfoCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 250);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormDayInfoCal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "일보";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Run;
		private System.Windows.Forms.CheckedListBox checkedListBoxCar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Carcnt_label;
	}
}