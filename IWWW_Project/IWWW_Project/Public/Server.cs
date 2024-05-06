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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Public
{
    public partial class Server : Form
    {
        List<Socket> ClientList = new List<Socket>();
        public Socket socket;
        private int clientCount = 0;
        private int status = 0;//indicate the sataus for the server
        public Server()
        {
            InitializeComponent();
        }

        private void tIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void Server_Load(object sender, EventArgs e)
        {

        }
        public int getCounter()
        {
            return clientCount;
        }

        public int getStatus()
        {
            return status;
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
        private void button1_Click(object sender, EventArgs e)
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

        //When the user send the request for connection
        public void AcceptClientConnect(object socket)
        {
            var serverSocket = socket as Socket;//change socket to Socket type
            this.AppendText(string.Format("{0}\nServer starts to allow the clients to connect.", GetCurrentTime()));
            status = 1;//set successfully
            while (true)
            {
                var blobalSocket = serverSocket.Accept();//global variable
                clientCount++;
                this.AppendText(string.Format("{0}\nClient ：{1} connected，there are {2} clients online now", GetCurrentTime(), blobalSocket.RemoteEndPoint.ToString(), getCounter()));
                ClientList.Add(blobalSocket);//add a client to the list
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), blobalSocket);
                update_list();
            }
        }
        public void update_list()
        {
            string clientListStr = "***Client,";
            foreach (var item in ClientList)
            {
                clientListStr += item.RemoteEndPoint.ToString() + "\n";
                byte[] data = Encoding.Default.GetBytes(clientListStr);
                item.Send(data, 0, data.Length, SocketFlags.None);//socketFlags :flag for send
            }
            if (ClientList.Count > 1)
            {
                byte[] data1 = Encoding.Default.GetBytes(clientListStr);
                ClientList[0].Send(data1, 0, data1.Length, SocketFlags.None);
            }
        }
        //receive the data from clients
        public void ReceiveData(object socket)
        {
            var receiveSocket = socket as Socket;
            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = receiveSocket.Receive(data, 0, data.Length, SocketFlags.None);//return the lenth for the data received
                }
                catch
                {
                    clientCount--;
                    AppendText(String.Format("{0}\nClient：{1} quit unnormally, there are {2} clients online now", GetCurrentTime(), receiveSocket.RemoteEndPoint.ToString(), getCounter()));
                    ClientList.Remove(receiveSocket);//remove form the list
                    update_list();
                    return;
                }
                if (len <= 0)
                {
                    //the client exit normally
                    clientCount--;
                    AppendText(String.Format("{0}\nClient：{1} quit normally, there are {2} clients online now", GetCurrentTime(), receiveSocket.RemoteEndPoint.ToString(), getCounter()));
                    ClientList.Remove(receiveSocket);//remove form the list 
                    update_list();
                    return;
                }
                string s = Encoding.Default.GetString(data, 0, len);
                this.AppendText(String.Format("{0}\r\nReceive form clients：{1} state message：\r\n    {2}\r\nForward successfully", GetCurrentTime(), receiveSocket.RemoteEndPoint.ToString(), s));
                //s = receiveSocket.RemoteEndPoint.ToString()+ '\n' + s;
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

        //set the data to the text frame
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
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var clientSocket in ClientList)
            {
                byte[] data = Encoding.Default.GetBytes("Server\n" + tMsg.Text);
                clientSocket.Send(data, 0, data.Length, SocketFlags.None);//socketFlags :flag for send
            }
            this.AppendText(String.Format("{0}\nYou send a message to all the user：：{1}\nForward successfully", GetCurrentTime(), tMsg.Text));
            tMsg.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void clist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
        private void tMsg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
