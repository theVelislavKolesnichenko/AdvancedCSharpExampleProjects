using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    class Server
    {
        public delegate void MsgSendEventHandler(string m);

        //private MsgSend msgSend;
        public event MsgSendEventHandler msgSend;

        public event EventHandler<string> sendingMessageEventHandler;

        public event EventHandler<MessageEventArgs> sendingMessageEventHandler_1;

        //public void Register(MsgSend m)
        //{
        //    msgSend += m;
        //}

        //public void Unregister(MsgSend m)
        //{
        //    msgSend -= m;
        //}

        public void SendMessage(object sender, string message)
        {
            //msgSend(message);
            sendingMessageEventHandler(sender, message);
        }

        public void SendMessage(object sender, MessageEventArgs e)
        {
            //msgSend(message);
            sendingMessageEventHandler_1(sender, e);
        }
    }
}
