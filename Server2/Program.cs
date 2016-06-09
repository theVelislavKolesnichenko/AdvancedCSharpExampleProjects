using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(8998);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Remoting), "MyRemoting", WellKnownObjectMode.SingleCall);
            Console.ReadLine();
        }
    }

    public interface IRemoting
    {
        int retg(int clientId);
        string chek(int clientId);
    }

    public class Remoting : MarshalByRefObject, IRemoting
    {
        Dictionary<int, int> client = new Dictionary<int, int>();

        public int retg(int clientId)
        {
            Console.WriteLine("Client call");
            client.Add(clientId, 3);
            return 3;
        }

        public string chek(int clientId)
        {
            if (client.ContainsKey(clientId))
                return "Yes";
            else
                return "NO";
        }
    }
}
