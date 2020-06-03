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

namespace SocketBase
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开启监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_listen_Click(object sender, EventArgs e)
        {
            //创建监听 IPV4版本 字节流 协议TCP
            Socket socketlisten = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Any;//ipaddress.parse(ip.Text)
            IPEndPoint point = new IPEndPoint(ipaddress, Convert.ToInt32(port.Text));
            //给监听绑定ip与端口
            socketlisten.Bind(point);
            ShowMessage("开启监听:"+ip.Text+":"+port.Text);
            //设置最大监听数量
            socketlisten.Listen(10);
            //因为监听的Accept会一直等待，所以要在后台开多线程
            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketlisten);
            
        }
        Socket socket_listen;
        //将所有的连接socket保存，以便服务器给指定的客户端发消息
        Dictionary<string, Socket> socketAll = new Dictionary<string, Socket>();
        /// <summary>
        /// 监听客户端的连接请求
        /// </summary>
        /// <param name="o"></param>
        void Listen(object o)
        {
            Socket socketlisten = o as Socket;
            while (true)
            {
                //等待连接，建立通信的socket
                socket_listen = socketlisten.Accept();
                //添加到socketAll里面
                socketAll.Add(socket_listen.RemoteEndPoint.ToString(), socket_listen);
                comboBox1.Items.Add(socket_listen.RemoteEndPoint.ToString());
                ShowMessage(socket_listen.RemoteEndPoint.ToString() + "：连接成功");
                //要一直监听后台发送的消息，所以多开线程
                Thread th = new Thread(ReceiveMsg);
                th.IsBackground = true;
                th.Start(socket_listen);
            }
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="o"></param>
        void ReceiveMsg(object o)
        {
            //获得与客户端建立的socket
            Socket socket_listen = o as Socket;
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int l = socket_listen.Receive(buffer);
                    if (l == 0)
                        break;
                    string s = socket_listen.RemoteEndPoint.ToString() + ":";
                    s += Encoding.UTF8.GetString(buffer, 0, l);
                    ShowMessage(s);
                }
            }
            catch
            {
            }
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
        /// 服务端发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_send_Click(object sender, EventArgs e)
        {
            string ip = comboBox1.Text;
            string s = send.Text;
            if(ip=="All")
            {
                sendAll(s);
                send.Text = "";
            }
            else
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s);
                socketAll[ip].Send(buffer);
                string str = socketAll[ip].RemoteEndPoint.ToString() + ":" + s;
                ShowMessage(str);
                send.Text = "";
            }
        }
        /// <summary>
        /// 给所有的客户端通知
        /// </summary>
        /// <param name="s"></param>
        void sendAll(string s)
        {
            foreach(var item in socketAll)
            {
                if(item.Key=="All")
                {
                    continue;
                }
                byte[] buffer = Encoding.UTF8.GetBytes(s);
                item.Value.Send(buffer);
                string str = item.Value.RemoteEndPoint + ":" + s;
                ShowMessage(str);
            }
        }
    }
}
