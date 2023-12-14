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
    public partial class FormOpenCalendar : Form
    {
        enum Seperate { AM, PM, ALL };
        DateTime collectionDay = DateTime.Now;
        Seperate collectionSeperate = Seperate.AM;
		FormData formData;

		public FormOpenCalendar(FormData f)
        {
            InitializeComponent();
            //monthCalendar1.TodayDate
            DateRangeEventArgs dre = new DateRangeEventArgs(DateTime.Today, DateTime.Today);
            object sender = new object();
            monthCalendar1_DateChanged(sender, dre);
			formData = f;
        }

        private void radioButtonAM_CheckedChanged(object sender, EventArgs e)
        {
            collectionSeperate = Seperate.AM;
            DateRangeEventArgs dre = new DateRangeEventArgs(collectionDay, collectionDay);
            object so = new object();
            monthCalendar1_DateChanged(so, dre);
        }

        private void radioButtonPM_CheckedChanged(object sender, EventArgs e)
        {
            collectionSeperate = Seperate.PM;
            DateRangeEventArgs dre = new DateRangeEventArgs(collectionDay, collectionDay);
            object so = new object();
            monthCalendar1_DateChanged(so, dre);
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            collectionSeperate = Seperate.ALL;
            DateRangeEventArgs dre = new DateRangeEventArgs(collectionDay, collectionDay);
            object so = new object();
            monthCalendar1_DateChanged(so, dre);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                collectionDay = e.Start;

                int dataNum = 0;


				string DBstring = "";
				if (formData.Db_backup == true)
				{
					DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + formData.MdbFileName;
					//					 Db_backup = false;


				}
				else
				{
					DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";

				}



				OleDbConnection conn = new OleDbConnection(@DBstring);
				conn.Open();

             //   string DBstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\Tacho.mdb";
             //   OleDbConnection conn = new OleDbConnection(@DBstring);
            //    conn.Open();

                string queryRead = "select * from TblTacho";
                OleDbCommand commRead = new OleDbCommand(queryRead, conn);
                OleDbDataReader srRead = commRead.ExecuteReader();

                while (srRead.Read())
                {
                    DateTime readToday = srRead.GetDateTime(5);

                    switch (collectionSeperate)
                    {
                        case Seperate.AM:
                            if ((collectionDay.Year == readToday.Year)
                                && (collectionDay.Month == readToday.Month)
                                && (collectionDay.Day == readToday.Day)
                                && (collectionDay.Hour < 12))
                            {
                                dataNum++;
                            }
                            break;

                        case Seperate.PM:
                            if ((collectionDay.Year == readToday.Year)
                                && (collectionDay.Month == readToday.Month)
                                && (collectionDay.Day == readToday.Day)
                                && (collectionDay.Hour >= 12))
                            {
                                dataNum++;
                            }
                            break;

                        case Seperate.ALL:
                            if ((collectionDay.Year == readToday.Year)
                                && (collectionDay.Month == readToday.Month)
                                && (collectionDay.Day == readToday.Day))
                            {
                                dataNum++;
                            }
                            break;
                    }
                }

                textBoxData.Text = dataNum.ToString() + " 개의 데이터 존재";

                conn.Close();
            }
            catch (Exception ex)
            {
              /*  string path = Application.StartupPath + "\\ErrorLog.jie";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + ex.Message);
                }*/
            }
            finally
            {
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
            //DateTime dt = new DateTime(2010, 4, 12, 1, 0, 0);

            FormDayDirveRec formDayDriveRec = new FormDayDirveRec(formData);
            //formDayDriveRec.FillData(dt);
            formDayDriveRec.FillData(collectionDay);
            formDayDriveRec.StartPosition = FormStartPosition.CenterScreen;
            formDayDriveRec.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}