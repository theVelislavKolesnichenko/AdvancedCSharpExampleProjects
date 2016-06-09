using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server server = new Server();

            //Client[] clients = new Client[3];

            //clients[0] = new Client("0000");
            //clients[1] = new Client("1111");
            //clients[2] = new Client("2222");

            //for (int i = 0; i < 3; i++)
            //{
            //    clients[i].ClientRegister(server);
            //}

            //server.SendMessage(null, "server messag");
            //server.SendMessage(null, new MessageEventArgs { message = "server messag" });

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("Client N: {0}", i);
            //    clients[i].PrintMessage(string.Format("Message client {0}", i));
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    clients[i].ClientUnregister(server);
            //}

            //Console.Read();

            List<int> li = new List<int>() { 1, 2, 3 };
            List<int> ll = new List<int>() { 2, 3 };

            Dictionary<int, List<string>> dd = new Dictionary<int, List<string>>();

            dd.Add(1, new string[] { "A" }.ToList() );
            dd.Add(2, new string[] { "B" }.ToList());
            dd.Add(3, new string[] { "A", "B"}.ToList());

            List<string> ss = new string[] { "A", "B" }.ToList();

            foreach (string s in ss)
            {
                dd.Where(i => i.Value.Contains(s));
            }
            Console.WriteLine(String.Join(", ", ll.Where(i => li.Contains(i)).Select(i => i.ToString())));
        }
    }
}
