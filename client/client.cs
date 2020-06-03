using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }
        Socket socketsend;
        /// <summary>
        /// 与服务器建立连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connect_Click(object sender, EventArgs e)
        {
            socketsend = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(ip.Text);
            IPEndPoint point = new IPEndPoint(ipaddress, Convert.ToInt32(port.Text));
            //连接服务器
            socketsend.Connect(point);
            ShowMessage("连接成功");
            //后台线程开启监听
            Thread th = new Thread(listen);
            th.IsBackground = true;
            th.Start(socketsend);
        }
        void ShowMessage(string s)
        {
            receive.AppendText(s + "\r\n");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //允许控件跨线程之间的资源访问。
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 接受服务器的信息
        /// </summary>
        /// <param name="o"></param>
        void listen(object o)
        {
            Socket socket = o as Socket;
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int l = socket.Receive(buffer);
                    string s = socket.RemoteEndPoint.ToString() + ":";
                    s += Encoding.UTF8.GetString(buffer, 0, l);
                    ShowMessage(s);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_Click(object sender, EventArgs e)
        {
            string str = sendText.Text.Trim();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            socketsend.Send(buffer);
            sendText.Text = "";
        }
    }
}
