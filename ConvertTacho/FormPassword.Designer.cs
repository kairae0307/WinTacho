namespace ConvertTacho
{
	partial class FormPassword
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.radioButton_use = new System.Windows.Forms.RadioButton();
			this.radioButton_use1 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(91, 49);
			this.textBox1.MaxLength = 4;
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new System.Drawing.Size(85, 21);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(91, 84);
			this.textBox2.MaxLength = 4;
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(85, 21);
			this.textBox2.TabIndex = 1;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "비밀번호 :";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "확   인 :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 47);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 27);
			this.button1.TabIndex = 4;
			this.button1.Text = "입력";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 27);
			this.button2.TabIndex = 5;
			this.button2.Text = "비밀번호 변경";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// radioButton_use
			// 
			this.radioButton_use.AutoSize = true;
			this.radioButton_use.Location = new System.Drawing.Point(91, 23);
			this.radioButton_use.Name = "radioButton_use";
			this.radioButton_use.Size = new System.Drawing.Size(73, 16);
			this.radioButton_use.TabIndex = 20;
			this.radioButton_use.TabStop = true;
			this.radioButton_use.Text = "1. 차번호";
			this.radioButton_use.UseVisualStyleBackColor = true;
			// 
			// radioButton_use1
			// 
			this.radioButton_use1.AutoSize = true;
			this.radioButton_use1.Location = new System.Drawing.Point(192, 23);
			this.radioButton_use1.Name = "radioButton_use1";
			this.radioButton_use1.Size = new System.Drawing.Size(73, 16);
			this.radioButton_use1.TabIndex = 21;
			this.radioButton_use1.TabStop = true;
			this.radioButton_use1.Text = "2. 차번호";
			this.radioButton_use1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 12);
			this.label3.TabIndex = 22;
			this.label3.Text = "선  택 :";
			// 
			// FormPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ClientSize = new System.Drawing.Size(299, 154);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.radioButton_use);
			this.Controls.Add(this.radioButton_use1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "FormPassword";
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.RadioButton radioButton_use;
		public System.Windows.Forms.RadioButton radioButton_use1;
		private System.Windows.Forms.Label label3;
	}
}