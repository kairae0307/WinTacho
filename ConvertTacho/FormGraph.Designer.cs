namespace ConvertTacho
{
    partial class FormGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraph));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.포인트값보이기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그래프저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.클립보드로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그림파일로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인쇄ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.페이지설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.미리보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인쇄ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.그래프보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.확대실행취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모든확대실행취소ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.초기상태로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자르기모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.zg3 = new ZedGraph.ZedGraphControl();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.포인트값보이기ToolStripMenuItem,
            this.그래프저장ToolStripMenuItem,
            this.인쇄ToolStripMenuItem1,
            this.그래프보기ToolStripMenuItem,
            this.자르기모드ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 114);
            // 
            // 포인트값보이기ToolStripMenuItem
            // 
            this.포인트값보이기ToolStripMenuItem.Checked = true;
            this.포인트값보이기ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.포인트값보이기ToolStripMenuItem.Name = "포인트값보이기ToolStripMenuItem";
            this.포인트값보이기ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.포인트값보이기ToolStripMenuItem.Text = "포인트 값 보기";
            this.포인트값보이기ToolStripMenuItem.Click += new System.EventHandler(this.포인트값보이기ToolStripMenuItem_Click);
            // 
            // 그래프저장ToolStripMenuItem
            // 
            this.그래프저장ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.클립보드로저장ToolStripMenuItem,
            this.그림파일로저장ToolStripMenuItem});
            this.그래프저장ToolStripMenuItem.Name = "그래프저장ToolStripMenuItem";
            this.그래프저장ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.그래프저장ToolStripMenuItem.Text = "그래프 저장";
            // 
            // 클립보드로저장ToolStripMenuItem
            // 
            this.클립보드로저장ToolStripMenuItem.Name = "클립보드로저장ToolStripMenuItem";
            this.클립보드로저장ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.클립보드로저장ToolStripMenuItem.Text = "클립보드에 복사";
            this.클립보드로저장ToolStripMenuItem.Click += new System.EventHandler(this.클립보드로저장ToolStripMenuItem_Click);
            // 
            // 그림파일로저장ToolStripMenuItem
            // 
            this.그림파일로저장ToolStripMenuItem.Name = "그림파일로저장ToolStripMenuItem";
            this.그림파일로저장ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.그림파일로저장ToolStripMenuItem.Text = "그림파일로 저장";
            this.그림파일로저장ToolStripMenuItem.Click += new System.EventHandler(this.그림파일로저장ToolStripMenuItem_Click);
            // 
            // 인쇄ToolStripMenuItem1
            // 
            this.인쇄ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.페이지설정ToolStripMenuItem,
            this.미리보기ToolStripMenuItem,
            this.인쇄ToolStripMenuItem2});
            this.인쇄ToolStripMenuItem1.Name = "인쇄ToolStripMenuItem1";
            this.인쇄ToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.인쇄ToolStripMenuItem1.Text = "그래프 인쇄";
            // 
            // 페이지설정ToolStripMenuItem
            // 
            this.페이지설정ToolStripMenuItem.Name = "페이지설정ToolStripMenuItem";
            this.페이지설정ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.페이지설정ToolStripMenuItem.Text = "페이지 설정";
            this.페이지설정ToolStripMenuItem.Click += new System.EventHandler(this.페이지설정ToolStripMenuItem_Click);
            // 
            // 미리보기ToolStripMenuItem
            // 
            this.미리보기ToolStripMenuItem.Name = "미리보기ToolStripMenuItem";
            this.미리보기ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.미리보기ToolStripMenuItem.Text = "미리 보기";
            this.미리보기ToolStripMenuItem.Click += new System.EventHandler(this.미리보기ToolStripMenuItem_Click);
            // 
            // 인쇄ToolStripMenuItem2
            // 
            this.인쇄ToolStripMenuItem2.Name = "인쇄ToolStripMenuItem2";
            this.인쇄ToolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            this.인쇄ToolStripMenuItem2.Text = "인쇄";
            this.인쇄ToolStripMenuItem2.Click += new System.EventHandler(this.인쇄ToolStripMenuItem2_Click);
            // 
            // 그래프보기ToolStripMenuItem
            // 
            this.그래프보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.확대실행취소ToolStripMenuItem,
            this.모든확대실행취소ToolStripMenuItem1,
            this.초기상태로ToolStripMenuItem});
            this.그래프보기ToolStripMenuItem.Name = "그래프보기ToolStripMenuItem";
            this.그래프보기ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.그래프보기ToolStripMenuItem.Text = "그래프 보기";
            // 
            // 확대실행취소ToolStripMenuItem
            // 
            this.확대실행취소ToolStripMenuItem.Name = "확대실행취소ToolStripMenuItem";
            this.확대실행취소ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.확대실행취소ToolStripMenuItem.Text = "확대 실행 취소";
            this.확대실행취소ToolStripMenuItem.Click += new System.EventHandler(this.확대실행취소ToolStripMenuItem_Click);
            // 
            // 모든확대실행취소ToolStripMenuItem1
            // 
            this.모든확대실행취소ToolStripMenuItem1.Name = "모든확대실행취소ToolStripMenuItem1";
            this.모든확대실행취소ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.모든확대실행취소ToolStripMenuItem1.Text = "모든 확대 실행 취소";
            this.모든확대실행취소ToolStripMenuItem1.Click += new System.EventHandler(this.모든확대실행취소ToolStripMenuItem1_Click);
            // 
            // 초기상태로ToolStripMenuItem
            // 
            this.초기상태로ToolStripMenuItem.Name = "초기상태로ToolStripMenuItem";
            this.초기상태로ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.초기상태로ToolStripMenuItem.Text = "초기상태로...";
            this.초기상태로ToolStripMenuItem.Click += new System.EventHandler(this.초기상태로ToolStripMenuItem_Click);
            // 
            // 자르기모드ToolStripMenuItem
            // 
            this.자르기모드ToolStripMenuItem.Name = "자르기모드ToolStripMenuItem";
            this.자르기모드ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.자르기모드ToolStripMenuItem.Text = "자르기 모드";
            this.자르기모드ToolStripMenuItem.Click += new System.EventHandler(this.자르기모드ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(52, -24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 48);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(119, -24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 48);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(896, 420);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 48);
            this.button3.TabIndex = 10;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "속도";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "엔진";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "도어";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "영업";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "거리";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.printPreviewDialog1_FormClosing);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(826, 420);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 48);
            this.button4.TabIndex = 16;
            this.button4.Text = "초기화";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "      ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "      ";
            // 
            // zg3
            // 
            this.zg3.AutoScroll = true;
            this.zg3.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.zg3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zg3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zg3.ContextMenuStrip = this.contextMenuStrip1;
            this.zg3.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg3.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zg3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.zg3.IsEnableVPan = false;
            this.zg3.IsEnableVZoom = false;
            this.zg3.IsShowPointValues = true;
            this.zg3.Location = new System.Drawing.Point(5, 7);
            this.zg3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.zg3.Name = "zg3";
            this.zg3.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg3.ScrollGrace = 0;
            this.zg3.ScrollMaxX = 400;
            this.zg3.ScrollMaxY = 0;
            this.zg3.ScrollMaxY2 = 0;
            this.zg3.ScrollMinX = 0;
            this.zg3.ScrollMinY = 0;
            this.zg3.ScrollMinY2 = 0;
            this.zg3.Size = new System.Drawing.Size(1047, 400);
            this.zg3.TabIndex = 7;
            this.zg3.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zg3_MouseDownEvent);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(759, 420);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 48);
            this.button5.TabIndex = 19;
            this.button5.Text = "자르기";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(318, 438);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(9, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(31, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Shift + Mouse Left button : 그래프 좌우 이동";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(31, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(229, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Mouse wheel UP or Down : 그래프 확대";
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 473);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.zg3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormGraph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGraph_FormClosing);
            this.Resize += new System.EventHandler(this.FormGraph_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private ZedGraph.ZedGraphControl zg3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 포인트값보이기ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 그래프저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 클립보드로저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 그림파일로저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 인쇄ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 페이지설정ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 미리보기ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 인쇄ToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 그래프보기ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 확대실행취소ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 모든확대실행취소ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 초기상태로ToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem 자르기모드ToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

    }
}