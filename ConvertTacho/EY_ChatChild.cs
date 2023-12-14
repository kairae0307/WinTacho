using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;


namespace ConvertTacho
{

    class EY_ChatChild
    {
        private Socket ClientSocket = null;

        private string strClientID = null;
        private string strReceiveMsg = "";
        private string strSendMsg = "";
        private string strLog = "";
        private string strErr = "";
        private Form1 eyChatServer = null;
        private byte[] buff = new byte[4096];
        string saveFname = "";   // *.TXT 파일의 파일명
        string filesave = "Data 저장..";
        string strCurTime = "";
        private int intSize = 0;

        private byte[] byteReceiveMsg = new byte[1024];
        private byte[] byteSendMsg = new byte[1024];
        //	private bool bConnectServer = false;

        //	string dirName;
        ///	string saveFname2;	// Temporary TXT 파일명

        public EY_ChatChild(Socket soc, string strID, Form1 eyServer)
        {
            ClientSocket = soc;
            eyChatServer = eyServer;
            strClientID = strID;
            Receive();
        }

        private void Receive()
        {
            ClientSocket.BeginReceive(buff, 0, 4096, SocketFlags.None, new AsyncCallback(ReceiveCallBack), buff);
        }


        private void ReceiveCallBack(IAsyncResult ar)
        {
           
                try
                {

                    byte[] Ibuff = (byte[])ar.AsyncState;
                    int recv = ClientSocket.EndReceive(ar);

                    if (recv == 0)
                    {
                        Disconnet();
                        //   return;

                        strLog = string.Format("[{0}]번 클라이언트가 접속을 종료하였습니다.", strClientID);
                        eyChatServer.Add_Log(strLog);
                    }
                    else
                    {

                        strReceiveMsg = Encoding.Default.GetString(Ibuff, 0, recv);
                        strLog = string.Format("Client : [{0}] {1}", strClientID, strReceiveMsg);
                        eyChatServer.Add_Log(strLog);


                        /* eyChatServer.intCientID = (int)eyChatServer.que.Dequeue();

                         if (eyChatServer.intCientID == 1)
                         {
                            eyChatServer.Client1_Icon.Visible = true;

                         }
                         else if (eyChatServer.intCientID == 2)
                         {
                             eyChatServer.Client2_Icon.Visible = true;

                         }
                         else if (eyChatServer.intCientID == 3)
                         {
                             eyChatServer.Client3_Icon.Visible = true;

                         }
                         else if (eyChatServer.intCientID == 4)
                         {
                             eyChatServer.Client4_Icon.Visible = true;

                         }*/

                        /*if (buff[0] == 0x31)
                        {
                            strCurTime = string.Format("(Wifi){0:d2}월{1:d2}일{2:D2}시{3:D2}분{4:D2}초", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            saveFname = strCurTime;

                       
                            SendMassge();
                        }*/


                        Receive();
                    }
                }
                catch (Exception e)
                {
                    //  MessageBox.Show(e.Message);

                    //eyChatServer.Add_Log(e.Message);
                    strLog = string.Format("[{0}]종료", strClientID);
                    // eyChatServer.label8.Text = strLog;
                    //MessageBox.Show(strLog);
                    eyChatServer.Add_Log(strLog);

                    if (e.Message == "스레드 종료 또는 응용 프로그램 요청 때문에 I/O 작업이 취소되었습니다")
                    {

                    }
                    else
                    {

                        eyChatServer.IDList.Remove(strClientID);

                        if (strClientID == "1")
                        {
                            eyChatServer.Client1_Icon.Visible = false;

                            if (!eyChatServer.que.Contains(1))
                            {
                                eyChatServer.que.Enqueue(1);        // ID 반납
                                eyChatServer.ClientList.Remove(strClientID);
                            }





                        }
                        else if (strClientID == "2")
                        {
                            if (!eyChatServer.que.Contains(2))
                            {
                                eyChatServer.Client2_Icon.Visible = false;
                                eyChatServer.que.Enqueue(2);        // ID 반납]
                                eyChatServer.ClientList.Remove(strClientID);
                            }





                        }
                        else if (strClientID == "3")
                        {
                            if (!eyChatServer.que.Contains(3))
                            {
                                eyChatServer.Client3_Icon.Visible = false;
                                eyChatServer.que.Enqueue(3);        // ID 반납
                                eyChatServer.ClientList.Remove(strClientID);
                            }




                        }
                        else if (strClientID == "4")
                        {
                            if (!eyChatServer.que.Contains(4))
                            {
                                eyChatServer.Client4_Icon.Visible = false;
                                eyChatServer.que.Enqueue(4);        // ID 반납
                                eyChatServer.ClientList.Remove(strClientID);
                            }





                        }
                    }
                    //Disconnet();
                }
            
        }
        public void SendMassge()
        {
            byte[] Sendbuff = new byte[4096];
            Sendbuff = buff;
            ClientSocket.BeginSend(Sendbuff, 0, byteSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBack_SendMsg), ClientSocket);
            //EY_ChatClient.BeginSend(byteSendMsg, 0, byteSendMsg.Length, SocketFlags.None, new AsyncCallback(CallBack_SendMsg), EY_ChatClient);

            //  eyChatServer.ReceiveTachoOpen();
        }
        public void TachoReceive_connect()
        {
            //	eyChatServer.ReceiveTachoOpen();
        }

        private void CallBack_SendMsg(IAsyncResult ar)
        {

            ClientSocket = (Socket)ar.AsyncState;

            try
            {
                intSize = ClientSocket.EndSend(ar);
                if (intSize == 0)
                {
                    Disconnet();
                }
                else
                {
                    //	strSendMsg = Encoding.Default.GetString(byteSendMsg, 0, intSize);
                    //	ClientSocket.BeginReceive(byteReceiveMsg, 0, byteReceiveMsg.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), byteReceiveMsg);
                }
            }
            catch (Exception err)
            {
                strErr = string.Format("[SYSTEM] : {0}", err.Message);
                eyChatServer.Add_Log(strErr);
                Disconnet();
            }
        }


        public void ClientSend(string msg)
        {
            
                try
                {
                    byte[] Ibuff = Encoding.Default.GetBytes(msg);
                    ClientSocket.BeginSend(Ibuff, 0, Ibuff.Length, SocketFlags.None, new AsyncCallback(SendCallBack), Ibuff);
                }
                catch
                {
                    Disconnet();
                }
           
        }


        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                int send = ClientSocket.EndSend(ar);
                if (send == 0)
                {
                    Disconnet();
            //        MessageBox.Show("test");
                }
                else
                {
                    Receive();
                }
            }
            catch
            {
                Disconnet();
            }
        }

        private void Disconnet()
        {
            if (ClientSocket != null)
            {
                ClientSocket.Close();
                ClientSocket = null;
            }
        }
    }
}
