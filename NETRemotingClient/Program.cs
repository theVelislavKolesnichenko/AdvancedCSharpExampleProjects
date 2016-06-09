using NETRmotingCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace NETRemotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            IRemoting proxy = (IRemoting)Activator.GetObject(typeof(IRemoting), "http://localhost:9999/Remoting");
            Console.WriteLine("result from remote call: {0}", proxy.RetSomeValue());
            Console.ReadLine();
        }
    }
}
