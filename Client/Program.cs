using Server1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            IRemoting proxy = (IRemoting)Activator.GetObject(typeof(IRemoting), "http://localhost:8999/MyRemoting");
            int t = proxy.RetSomeValue(12);
            Console.ReadLine();

            HttpChannel channel1 = new HttpChannel();
            ChannelServices.RegisterChannel(channel1, false);

            Server2.IRemoting proxy1 = (Server2.IRemoting)Activator.GetObject(typeof(Server2.IRemoting), "http://localhost:8998/MyRemoting");
            Console.WriteLine("result from remote call: {0}", proxy1.chek(12));
            Console.ReadLine();
        }
    }
}
