using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace ConvertTacho
{
    public partial class FormCommunicationSetting : Form
    {
        FormTachoReceive1 formTR;
        private iniClass inicls = new iniClass();
        public FormCommunicationSetting(FormTachoReceive1 formTachoReceive)
        {
            InitializeComponent();

            formTR = formTachoReceive;

            foreach (string comport in SerialPort.GetPortNames())
            {
                comboBoxSerialPort.Items.Add(comport);
            }

            if (comboBoxSerialPort.Items.Count == 0)
            {
                comboBoxSerialPort.Items.Add("COM1");
            }
            comboBoxSerialPort.SelectedIndex = 0;

            string path = Application.StartupPath + "\\WinTacho.ini";



            string RValue = "";
            RValue = inicls.GetIniValue("Serial Setting", "SP", path);
            comboBoxSerialPort.Text = RValue;


            RValue = inicls.GetIniValue("Serial Setting", "BS", path);
            comboBoxBitPerSec.Text = RValue;


            RValue = inicls.GetIniValue("Serial Setting", "DB", path);
            comboBoxDataBit.Text = RValue;

            RValue = inicls.GetIniValue("Serial Setting", "PA", path);
            comboBoxParity.Text = RValue;

            RValue = inicls.GetIniValue("Serial Setting", "SB", path);
            comboBoxStopBit.Text = RValue;


            RValue = inicls.GetIniValue("Serial Setting", "FC", path);
            comboBoxFlowControl.Text = RValue;

            /*  try
              {
                  using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                  {
                      string line, destStr = "";
                      char[] dest = new char[20];
                      line = sr.ReadLine();

                      if (line.CompareTo("WinTacho Serial Setting") == 0)
                      {
                          // 공백 Line 건너뛰기
                          line = sr.ReadLine();

                          // SerialPort
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxSerialPort.Text = destStr;
                          destStr = "";
                          for (int j = 0; j < 20; j++) dest[j] = '\0';

                          // BaudRate
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxBitPerSec.Text = destStr;
                          destStr = "";
                          for (int j = 0; j < 20; j++) dest[j] = '\0';

                          // DataBit
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxDataBit.Text = destStr;
                          destStr = "";
                          for (int j = 0; j < 20; j++) dest[j] = '\0';

                          // Parity
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxParity.Text = destStr;
                          destStr = "";
                          for (int j = 0; j < 20; j++) dest[j] = '\0';

                          // StopBit
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxStopBit.Text = destStr;
                          destStr = "";
                          for (int j = 0; j < 20; j++) dest[j] = '\0';

                          // FlowControl
                          line = sr.ReadLine();
                          line.CopyTo(5, dest, 0, (line.Length - 5));

                          for (int i = 0; i < 20; i++)
                          {
                              if (dest[i] == '\0')
                                  break;
                              destStr += dest[i];
                          }
                          comboBoxFlowControl.Text = destStr;
                      }
                  }
              }
              catch (FileNotFoundException e)
              {
                  using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                  {
                      sw.Write("WinTacho Serial Setting\r\n\r\n");
                      sw.Write("SP = COM1\r\n");
                      sw.Write("BS = 38400\r\n");
                      sw.Write("DB = 8\r\n");
                      sw.Write("PA = 없음\r\n");
                      sw.Write("SB = 1\r\n");
                      sw.Write("FC = 하드웨어\r\n");
                  }

                  comboBoxSerialPort.SelectedIndex = 0;

                  string errMsg = e.ToString();
              }
              finally
              {
              }*/
        }

        private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboBoxBitPerSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboBoxDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboBoxParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboBoxStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void comboBoxFlowControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void buttonRecovery_Click(object sender, EventArgs e)
        {
            comboBoxSerialPort.SelectedIndex = 0;
            comboBoxBitPerSec.SelectedIndex = 3;
            comboBoxDataBit.SelectedIndex = 3;
            comboBoxParity.SelectedIndex = 2;
            comboBoxStopBit.SelectedIndex = 0;
            comboBoxFlowControl.SelectedIndex = 1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonApply_Click(sender, e);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\WinTacho.ini";


            inicls.SetIniValue("Serial Setting", "SP", comboBoxSerialPort.SelectedItem.ToString(), path);
            inicls.SetIniValue("Serial Setting", "BS", comboBoxBitPerSec.SelectedItem.ToString(), path);
            inicls.SetIniValue("Serial Setting", "DB", comboBoxDataBit.SelectedItem.ToString(), path);
            inicls.SetIniValue("Serial Setting", "PA", comboBoxParity.SelectedItem.ToString(), path);
            inicls.SetIniValue("Serial Setting", "SB", comboBoxStopBit.SelectedItem.ToString(), path);
            inicls.SetIniValue("Serial Setting", "FC", comboBoxFlowControl.SelectedItem.ToString(), path);

            /*  using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
              {
                  sw.Write("WinTacho Serial Setting\r\n\r\n");
                  sw.Write("SP = {0}\r\n", comboBoxSerialPort.SelectedItem.ToString());
                  sw.Write("BS = {0}\r\n", comboBoxBitPerSec.SelectedItem.ToString());
                  sw.Write("DB = {0}\r\n", comboBoxDataBit.SelectedItem.ToString());
                  sw.Write("PA = {0}\r\n", comboBoxParity.SelectedItem.ToString());
                  sw.Write("SB = {0}\r\n", comboBoxStopBit.SelectedItem.ToString());
                  sw.Write("FC = {0}\r\n", comboBoxFlowControl.SelectedItem.ToString());
              }*/

            formTR.SP_PortName = comboBoxSerialPort.SelectedItem.ToString();

            switch (comboBoxBitPerSec.SelectedIndex)
            {
                case 0: formTR.SP_BaudRate = 4800; break;
                case 1: formTR.SP_BaudRate = 9600; break;
                case 2: formTR.SP_BaudRate = 19200; break;
                case 3: formTR.SP_BaudRate = 38400; break;
                case 4: formTR.SP_BaudRate = 57600; break;
                case 5: formTR.SP_BaudRate = 115200; break;
                default: formTR.SP_BaudRate = 38400; break;
            }
            switch (comboBoxDataBit.SelectedIndex)
            {
                case 0: formTR.SP_DataBits = 5; break;
                case 1: formTR.SP_DataBits = 6; break;
                case 2: formTR.SP_DataBits = 7; break;
                case 3: formTR.SP_DataBits = 8; break;
                default: formTR.SP_DataBits = 8; break;
            }
            switch (comboBoxParity.SelectedIndex)
            {
                case 0: formTR.SP_Parity = Parity.Even; break;
                case 1: formTR.SP_Parity = Parity.Mark; break;
                case 2: formTR.SP_Parity = Parity.None; break;
                case 3: formTR.SP_Parity = Parity.Odd; break;
                case 4: formTR.SP_Parity = Parity.Space; break;
                default: formTR.SP_Parity = Parity.None; break;
            }
            switch (comboBoxStopBit.SelectedIndex)
            {
                case 0: formTR.SP_StopBits = StopBits.One; break;
                case 1: formTR.SP_StopBits = StopBits.OnePointFive; break;
                case 2: formTR.SP_StopBits = StopBits.Two; break;
                default: formTR.SP_StopBits = StopBits.One; break;
            }

            buttonApply.Enabled = false;
        }
    }
}