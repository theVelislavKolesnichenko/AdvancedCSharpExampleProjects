using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server1
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(8999);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Remoting), "MyRemoting", WellKnownObjectMode.SingleCall);
            Console.ReadLine();
        }
    }

    public interface IRemoting
    {
        int RetSomeValue(int clientId);
    }

    public class Remoting : MarshalByRefObject, IRemoting
    {
        public int RetSomeValue(int clientId)
        {
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            Server2.IRemoting proxy = (Server2.IRemoting)Activator.GetObject(typeof(Server2.IRemoting), "http://localhost:8998/MyRemoting");

            int t = proxy.retg(clientId);

            return t;
        }
    }
}
