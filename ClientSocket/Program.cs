using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //IPAddress addr = IPAddress.Parse("127.0.0.1");
            //IPEndPoint remoteEP = new IPEndPoint(addr, 9999);

            //Socket
            /*Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(remoteEP);
            byte[] msg = new byte[1024];
            int byteREceived = clientSocket.Receive(msg);
            string strMsg = Encoding.ASCII.GetString(msg);

            //NetworkStream ns = new NetworkStream(clientSocket);
            //StreamReader sw = new StreamReader(ns, Encoding.ASCII);
            //string strMsg =  sw.ReadLine();

            Console.WriteLine(strMsg);
            Console.ReadLine();*/

            /*TcpClient client = new TcpClient();
            client.Connect(remoteEP);
            NetworkStream ns = client.GetStream();
            StreamReader sw = new StreamReader(ns, Encoding.ASCII);
            string strMsg =  sw.ReadLine();

            Console.WriteLine(strMsg);
            Console.ReadLine();*/


            EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string clMsg = "new Client";
            byte[] serMsg = Encoding.ASCII.GetBytes(clMsg);
            clientSocket.SendTo(serMsg, ep);

            
            byte[] msg = new byte[1024];
            int byteCount = clientSocket.ReceiveFrom(msg, ref ep);
            string newMsg = Encoding.ASCII.GetString(msg, 0, byteCount);
            Console.WriteLine(newMsg);

            clientSocket.SendTo(serMsg, ep);
        }
    }
}
