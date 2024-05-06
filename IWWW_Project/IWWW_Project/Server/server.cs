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

namespace Server
{
    public partial class server : Form
    {
        List<Socket> ClientList = new List<Socket>();
        public Socket socket;
        public string u;
        public int f = 0;
        private int clientCount = 0;
        private int status = 0;//indicate the sataus for the server
        public server()
        {
            InitializeComponent();
        }
        public int getStatus()
        {
            return status;
        }
        public void AcceptClientConnect(object socket)
        {
            var serverSocket = socket as Socket;//change socket to Socket type
            this.AppendText(string.Format("{0}\n Connect successfully.", GetCurrentTime()));
            status = 1;//set successfully
            f = 1;
            while (true)
            {
                var blobalSocket = serverSocket.Accept();//global variable
                clientCount++;
                this.AppendText(string.Format("{0}\na client joined，there are {1} clients online now", GetCurrentTime()));
                ClientList.Add(blobalSocket);//add a client to the list
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), blobalSocket);
                update_list();
            }
        }
        public void ReceiveData(object socket)
        {
            var receiveSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;

                len = receiveSocket.Receive(data, 0, data.Length, SocketFlags.None);//return the lenth for the data received
                string s = Encoding.Default.GetString(data, 0, len);
                string[] parts = s.Split(new[] { "\n" }, StringSplitOptions.None);
                u = parts[0];
                string s1 = GetCurrentTime() + " " + s;
                this.AppendText(String.Format("{0}", s1));
                foreach (var clientSocket in ClientList)
                {
                    byte[] data1 = Encoding.Default.GetBytes(s);
                    clientSocket.Send(data1, 0, data1.Length, SocketFlags.None);//send for each one
                }
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
                if (windows.InvokeRequired)
                {
                    windows.Invoke((MethodInvoker)(() =>
                    {
                        AppendText(txt);
                    }));
                }
                else
                {
                    if (string.IsNullOrEmpty(windows.Text))
                    {
                        windows.Text = string.Format("{0}", txt);
                    }
                    else
                    {
                        windows.Text = string.Format("{0}\r\n{1}", windows.Text, txt);
                    }
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
        private void windows_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void tPort_TextChanged(object sender, EventArgs e)
        {

        }
        private void run_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(new IPEndPoint(IPAddress.Parse(tIP.Text), int.Parse(tPort.Text)));
            }
            catch
            {
                MessageBox.Show("You input a wrong IP address, Please input again");
                tIP.Text = "";
                tPort.Text = "";
                return;
            }
            socket.Listen(10);
            //Use ThreadPool.QueueUserWorkItem method to set AcceptClientConnect into the thread pool
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), socket);
        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (getStatus() == 1)
            {
                socket.Close();
                status = 0;
                tIP.Text = "";
                tPort.Text = "";
                MessageBox.Show("Close successfully, all the clients connect this server will log off");
            }
            else
            {
                MessageBox.Show("You do not support any server to clients");
            }
        }
        public void auto_run(int index)
        {
            var ip = new List<string>(){
            "127.1.1.0",
            "127.1.1.1",
            "127.1.1.2",
            "127.1.1.3",
            "127.1.1.4"
            };
            Socket asocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            switch (index)
            {
                case 1:
                    asocket.Bind(new IPEndPoint(IPAddress.Parse(ip[index - 1]), int.Parse("100")));
                    break;
                case 2:
                    asocket.Bind(new IPEndPoint(IPAddress.Parse(ip[index - 1]), int.Parse("100")));
                    break;
                case 3:
                    asocket.Bind(new IPEndPoint(IPAddress.Parse(ip[index - 1]), int.Parse("100")));
                    break;
                case 4:
                    asocket.Bind(new IPEndPoint(IPAddress.Parse(ip[index - 1]), int.Parse("100")));
                    break;
                case 5:
                    asocket.Bind(new IPEndPoint(IPAddress.Parse(ip[index - 1]), int.Parse("100")));
                    break;
            }
            asocket.Listen(10);
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.AcceptClientConnect), asocket);
        }
        public void update_list()
        {
            string clientListStr = "***Client,";
            if (f == 0)
            {
                foreach (var item in ClientList)
                {
                    clientListStr += item.RemoteEndPoint.ToString() + "\n";
                    byte[] data = Encoding.Default.GetBytes(clientListStr);
                    item.Send(data, 0, data.Length, SocketFlags.None);//socketFlags :flag for send
                }
            }
            else
            {
                int p = 0;
                foreach (var item in ClientList)
                {
                    if (++p == ClientList.Count())
                    {
                        clientListStr += "\n";
                    }
                    clientListStr += item.RemoteEndPoint.ToString() + "\n";
                    byte[] data = Encoding.Default.GetBytes(clientListStr);
                    item.Send(data, 0, data.Length, SocketFlags.None);//socketFlags :flag for send
                }
            }
            if (ClientList.Count > 1)
            {
                byte[] data1 = Encoding.Default.GetBytes(clientListStr);
                ClientList[0].Send(data1, 0, data1.Length, SocketFlags.None);
            }
        }
        private void tMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void server_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
