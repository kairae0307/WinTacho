using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ConvertTacho
{
    public partial class FormCarDriveRec : Form
    {
        private bool m_bStart;
        private Color savColor;

        public FormCarDriveRec()
        {
            InitializeComponent();
            m_bStart = true;

            savColor = this.BackColor;
            this.BackColor = System.Drawing.Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void FormCarDriveRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;

            if (m_bStart)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            s.Width -= 20;
            s.Height -= 50;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width-20, this.ClientRectangle.Height-50, dc1, 10, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.White;
            CaptureScreen();
            //this.BackColor = savColor;

          
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Color savColor = this.BackColor;
            this.BackColor = System.Drawing.Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.BackColor = savColor;
        }
	

    }
}