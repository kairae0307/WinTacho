namespace ConvertTacho
{
    partial class FormInfo
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonCut = new System.Windows.Forms.Button();
            this.buttonAutoCut = new System.Windows.Forms.Button();
            this.buttonPrintPreview = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonPrintSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.자르기설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자르기해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선택해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.전체해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(0, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(696, 553);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "영업";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(438, 498);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "불사용";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 498);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "합승";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(505, 538);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "엔진키";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(289, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 21);
            this.button5.TabIndex = 6;
            this.button5.Text = "급제동";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonCut
            // 
            this.buttonCut.Enabled = false;
            this.buttonCut.Location = new System.Drawing.Point(569, 498);
            this.buttonCut.Name = "buttonCut";
            this.buttonCut.Size = new System.Drawing.Size(64, 34);
            this.buttonCut.TabIndex = 7;
            this.buttonCut.Text = "자르기 실행";
            this.buttonCut.UseVisualStyleBackColor = true;
            this.buttonCut.Visible = false;
            this.buttonCut.Click += new System.EventHandler(this.buttonCut_Click);
            // 
            // buttonAutoCut
            // 
            this.buttonAutoCut.Location = new System.Drawing.Point(438, 538);
            this.buttonAutoCut.Name = "buttonAutoCut";
            this.buttonAutoCut.Size = new System.Drawing.Size(64, 34);
            this.buttonAutoCut.TabIndex = 7;
            this.buttonAutoCut.Text = "교대시간 자르기";
            this.buttonAutoCut.UseVisualStyleBackColor = true;
            this.buttonAutoCut.Visible = false;
            this.buttonAutoCut.Click += new System.EventHandler(this.buttonAutoCut_Click);
            // 
            // buttonPrintPreview
            // 
            this.buttonPrintPreview.Location = new System.Drawing.Point(456, 4);
            this.buttonPrintPreview.Name = "buttonPrintPreview";
            this.buttonPrintPreview.Size = new System.Drawing.Size(72, 20);
            this.buttonPrintPreview.TabIndex = 6;
            this.buttonPrintPreview.Text = "미리 보기";
            this.buttonPrintPreview.UseVisualStyleBackColor = true;
            this.buttonPrintPreview.Visible = false;
            this.buttonPrintPreview.Click += new System.EventHandler(this.buttonPrintPreview_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(612, 4);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(72, 20);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "인쇄";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonPrintSetting
            // 
            this.buttonPrintSetting.Location = new System.Drawing.Point(534, 5);
            this.buttonPrintSetting.Name = "buttonPrintSetting";
            this.buttonPrintSetting.Size = new System.Drawing.Size(72, 19);
            this.buttonPrintSetting.TabIndex = 6;
            this.buttonPrintSetting.Text = "인쇄 설정";
            this.buttonPrintSetting.UseVisualStyleBackColor = true;
            this.buttonPrintSetting.Click += new System.EventHandler(this.buttonPrintSetting_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 24);
            this.label1.TabIndex = 297;
            this.label1.Text = "♣ 영업 상세정보 ♣";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 자르기설정ToolStripMenuItem
            // 
            this.자르기설정ToolStripMenuItem.Name = "자르기설정ToolStripMenuItem";
            this.자르기설정ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.자르기설정ToolStripMenuItem.Text = "자르기 설정";
            this.자르기설정ToolStripMenuItem.Visible = false;
            this.자르기설정ToolStripMenuItem.Click += new System.EventHandler(this.자르기설정ToolStripMenuItem_Click);
            // 
            // 자르기해제ToolStripMenuItem
            // 
            this.자르기해제ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.선택해제ToolStripMenuItem,
            this.전체해제ToolStripMenuItem});
            this.자르기해제ToolStripMenuItem.Name = "자르기해제ToolStripMenuItem";
            this.자르기해제ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.자르기해제ToolStripMenuItem.Text = "자르기 해제";
            this.자르기해제ToolStripMenuItem.Visible = false;
            // 
            // 선택해제ToolStripMenuItem
            // 
            this.선택해제ToolStripMenuItem.Name = "선택해제ToolStripMenuItem";
            this.선택해제ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.선택해제ToolStripMenuItem.Text = "선택 해제";
            this.선택해제ToolStripMenuItem.Click += new System.EventHandler(this.선택해제ToolStripMenuItem_Click);
            // 
            // 전체해제ToolStripMenuItem
            // 
            this.전체해제ToolStripMenuItem.Name = "전체해제ToolStripMenuItem";
            this.전체해제ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.전체해제ToolStripMenuItem.Text = "전체 해제";
            this.전체해제ToolStripMenuItem.Click += new System.EventHandler(this.전체해제ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.자르기설정ToolStripMenuItem,
            this.자르기해제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 48);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(367, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 21);
            this.button6.TabIndex = 299;
            this.button6.Text = "엑셀";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 604);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAutoCut);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonPrintPreview);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonPrintSetting);
            this.Name = "FormInfo";
            this.Text = "운행 세부정보";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInfo_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button buttonCut;
        private System.Windows.Forms.Button buttonAutoCut;
        private System.Windows.Forms.Button buttonPrintPreview;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonPrintSetting;

        private PrintableListView.PrintableListView m_list;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem 자르기설정ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 자르기해제ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 선택해제ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 전체해제ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button6;
    }
}