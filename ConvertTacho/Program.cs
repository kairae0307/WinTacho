using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ConvertTacho
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



         //   FormLogin formLogin = new FormLogin();
          //  formLogin.MdiParent = this.ParentForm;
         //  formLogin.BringToFront();
         //   formLogin.Show();


        /*    Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formLogin = new FormLogin();

            DialogResult dialog = formLogin.ShowDialog();

            if (dialog == DialogResult.OK)
            {

                formLogin.Close();

           
                 Application.Run(new Form1());

            }*/


          /*   중복 실행 방지 
            
             bool bNew;
            Mutex mutex = new Mutex(true, Application.ProductName, out bNew);
            if (bNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("윈타코 프로그램이 실행중입니다.");
                Application.Exit();
            }*/

        }
    }
}