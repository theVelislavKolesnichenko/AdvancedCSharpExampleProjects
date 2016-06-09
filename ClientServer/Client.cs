using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    class Client
    {
        public string id { get; set; }

        public Client(string id)
        {
            this.id = id;
        }

        public void ClientRegister(Server server)
        {
            //server.Register(new Server.MsgSend(PrintMessage));
            //server.msgSend += new Server.MsgSendEventHandler(PrintMessage);
            server.sendingMessageEventHandler += new EventHandler<string>(PrintMessage);
            server.sendingMessageEventHandler_1 += new EventHandler<MessageEventArgs>(PrintMessage);
        }

        public void ClientUnregister(Server server)
        {
            //server.Unregister(new Server.MsgSend(PrintMessage));
            //server.msgSend -= new Server.MsgSendEventHandler(PrintMessage);
            server.sendingMessageEventHandler -= new EventHandler<string>(PrintMessage);
            server.sendingMessageEventHandler_1 += new EventHandler<MessageEventArgs>(PrintMessage);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(object sender, string message)
        {
            Console.WriteLine("{0}:{1}", id , message);
        }

        public void PrintMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("{0}:{1}", id, e.message);
        }
    }
}
