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

namespace Public
{
    public partial class Clients : Form
    {
        public Socket ClientSocket { get; set; }//global variable
        public Clients()
        {
            InitializeComponent();
        }
        
        private void run_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Connected");
            
            var ip = new List<string>(){
            "127.1.1.0",
            "127.1.1.1",
            "127.1.1.2",
            "127.1.1.3",
            "127.1.1.4"
            };
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket = socket;
            var a = ip[0]; // 暂时定为只链接127.1.1.0
            try
            {
                socket.Connect(IPAddress.Parse(a), int.Parse("2023"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect Fail, Please try again");
                return;
            }
            Thread thread = new Thread(new ParameterizedThreadStart(ReceiveData));//create new thread
            thread.IsBackground = true;//the foreground thread end, it end directly.
            thread.Start(ClientSocket);
            this.AppendText(String.Format("{0}\nConnect to the server (IP:{1}) successfully", GetCurrentTime(), a));
        }
        public void ReceiveData(object socket)
        {
            var proxSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proxSocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    return;
                }
                string str = Encoding.Default.GetString(data, 0, len);
                if (str.Contains("***Client,"))
                {
                    string[] parts = str.Split(',');
                }
                else
                    this.AppendText(String.Format("{0} {1}", GetCurrentTime(), str));
            }
        }
        private void StopConnect()
        {
            if (ClientSocket.Connected)
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close(100);
            }
        }
        DateTime GetCurrentTime()
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            return time;
        }
        public void AppendText(string txt)
        {
            if (windows.InvokeRequired)//determine the thread now whether is the thread that creat the ui
            {
                if (windows.Text == "")//it is not
                {
                    windows.BeginInvoke(new Action<string>(s =>//avoid accorss thread is invalid
                    {
                        this.windows.Text = string.Format("{0}", txt);
                    }), txt);
                }
                else
                {
                    windows.BeginInvoke(new Action<string>(s =>
                    {
                        this.windows.Text = string.Format("{0}\r\n{1}", windows.Text, txt);
                    }), txt);
                }

            }
            else
            {
                if (windows.Text == "")
                    this.windows.Text = string.Format("{0}", txt);
                else
                    this.windows.Text = string.Format("{0}\r\n{1}", windows.Text, txt);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                byte[] data = Encoding.Default.GetBytes(tMsg.Text);
                ClientSocket.Send(data, 0, data.Length, SocketFlags.None);
                tMsg.Text = "";
            }
            else
            {
                MessageBox.Show("You do not connect any server now!");
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                StopConnect();
                this.AppendText(String.Format("{0}\n You stop the connect", GetCurrentTime()));
            }
            else
                MessageBox.Show("You do not connect any server now!");
        }

        private void windows_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }
    }
}
