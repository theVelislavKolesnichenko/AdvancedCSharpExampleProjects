using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socketa
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPHostEntry host = Dns.GetHostEntry("tu-varna.bg");
            //foreach (IPAddress address in host.AddressList)
            //{
            //    Console.WriteLine(address.Address);
            //}

            //IPAddress addr = IPAddress.Parse("127.0.0.1");
            //IPEndPoint ep = new IPEndPoint(addr, 9999);

            //Socket
            /*Socket sevrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,  ProtocolType.Tcp);
            sevrSocket.Bind(ep);
            sevrSocket.Listen(10);

            for (;;)
            {
                Socket clientSocket = sevrSocket.Accept();
                byte[] msg = new byte[1024];
                msg = System.Text.Encoding.ASCII.GetBytes("KOKO");
                //clientSocket.Send(msg);

                NetworkStream ns = new NetworkStream(clientSocket);
                StreamWriter sw = new StreamWriter(ns, Encoding.ASCII);
                sw.WriteLine("LOLO");
                sw.AutoFlush = true;

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }*/

            /*
            TcpListener server = new TcpListener(ep);
            server.Start(10);
            for (;;)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns, Encoding.ASCII);
                sw.WriteLine("{0:dd.MM.yyyy}", DateTime.Now);
                sw.AutoFlush = true;
                ns.Close();
            }*/

            
            EndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            Socket sevrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,  ProtocolType.Udp);
            
            byte[] msg = new byte[1024];
            int byteCount = sevrSocket.ReceiveFrom(msg, ref ep);
            string newMsg = Encoding.ASCII.GetString(msg, 0, byteCount);
            Console.WriteLine(newMsg);
            byte[] serMsg = Encoding.ASCII.GetBytes("LOLO");
            sevrSocket.SendTo(serMsg, ep);
        }
    }
}
