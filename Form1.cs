using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;           //匯入網路通訊協定相關函數
using System.Net.Sockets;   //匯入網路插座功能函數
using System.Threading;     //匯入多執行緒功能函數
using System.Collections;   //匯入集合物件功能

namespace ServerAP
{
    public partial class Form1 : Form
    {
        //公用變數宣告
        TcpListener Server;//伺服端網路監聽器(相當於電話總機)
        Socket Client;//給客戶用的連線物件(相當於電話分機)
        Thread Th_Svr;//伺服器監聽用執行緒(電話總機開放中)
        Thread Th_Clt;//客戶用的通話執行緒(電話分機連線中)
        Hashtable HT = new Hashtable();//客戶名稱與通訊物件的集合(雜湊表)(key:Name, Socket)
        Hashtable HT_num = new Hashtable();
        int num = 1;
        public Form1()
        {
            InitializeComponent();
        }
        #region 接受客戶連線要求的程式
        private void ServerSub()
        {
            //Server IP 和 Port
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(TextBox1.Text), int.Parse(TextBox2.Text));
            Server = new TcpListener(EP);
            Server.Start();
            while (true)
            {
                Client = Server.AcceptSocket();
                Th_Clt = new Thread(Listen); //建立監聽這個客戶連線的獨立執行緒
                Th_Clt.IsBackground = true; //設定為背景執行緒
                Th_Clt.Start(); //開始執行緒的運作
            }
        }
        #endregion
        #region 監聽客戶訊息的程式
        List<Socket> userlist = new List<Socket>();
        private void Listen()
        {
            Socket sck = Client;  //複製Client通訊物件到個別客戶專用物件Sck
            Thread Th = Th_Clt;   //複製執行緒Th_Clt到區域變數Th
            while (true) //持續監聽客戶傳來的訊息
            {
                byte[] B = new byte[1023];                            //建立接收資料用的陣列，長度須大於可能的訊息
                int inLen = sck.Receive(B);                           //接收網路資訊(Byte陣列)
                string Msg = Encoding.Default.GetString(B, 0, inLen); //翻譯實際訊息(長度inLen)
                string Cmd = Msg.Substring(0, 1);                     //取出命令碼 (第一個字)
                string Str = Msg.Substring(1);                        //取出命令碼之後的訊息(user name)

                byte[] DATA = new byte[1023];

                switch (Cmd)//依據命令碼執行功能
                {
                    case "i"://有新使用者上線：新增使用者到名單中
                        HT.Add(Str, sck); //連線加入雜湊表，Key:使用者，Value:連線物件(Socket)
                        HT_num.Add(num, Str);
                        Listbox1.Items.Add(Str); //加入上線者名單
                        listBox2.Items.Add("<< " + Str + " 已加入聊天室>>");
                        DATA = Encoding.Default.GetBytes("<< " + Str + " 已加入聊天室>>");
                        userlist.Add(sck);
                        /*foreach (Socket a in userlist) {
                            try
                            {                       
                                a.Send(DATA);
                            }
                            catch { }
                        }*/
                        for (int i = 1; i <= num; i++)
                        {
                            try
                            {
                                Socket user = (Socket)HT[HT_num[i]];
                                user.Send(DATA);
                            }
                            catch { }

                        }
                        num += 1;
                        break;
                    case "o":
                        HT.Remove(num);
                        HT.Remove(Str);             //移除使用者名稱為Name的連線物件
                        Listbox1.Items.Remove(Str); //自上線者名單移除Name
                        listBox2.Items.Add("<< " + Str + " 已離開聊天室>>");
                        DATA = Encoding.Default.GetBytes("<< " + Str + " 已離開聊天室>>");
                        for (int i = 1; i <= num; i++)
                        {
                            try
                            {
                                Socket user = (Socket)HT[HT_num[i]];
                                user.Send(DATA);
                            }
                            catch { }

                        }
                        Th.Abort();//結束此客戶的監聽執行緒
                        break;
                    default:

                        string l = Msg.Substring(0, 1); //3asdRRRRRR asdRRRRRR
                        string name = Msg.Substring(1).Substring(0, int.Parse(l));
                        string content = Msg.Substring(1).Substring(int.Parse(l));
                        listBox2.Items.Add(name + " : " + content);
                        DATA = Encoding.Default.GetBytes(name + " : " + content);
                        for (int i = 1; i <= num; i++)
                        {
                            try
                            {
                                Socket user = (Socket)HT[HT_num[i]];
                                user.Send(DATA);
                            }
                            catch { }

                        }
                        break;
                }
            }
        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;    //忽略跨執行緒處理的錯誤(允許跨執行緒存取變數)
            Th_Svr = new Thread(ServerSub);             //宣告監聽執行緒(副程式ServerSub)
            Th_Svr.IsBackground = true;                 //設定為背景執行緒
            Th_Svr.Start();                             //啟動監聽執行緒
            button1.Enabled = false;                    //讓按鍵無法使用(不能重複啟動伺服器)
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();//關閉所有執行緒
        }
    }
}
