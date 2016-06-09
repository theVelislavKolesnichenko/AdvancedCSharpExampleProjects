using NETRmotingCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NETRemoting
{
    public class Program : ServiceBase
    { 
        static void Main(string[] args)
        {
            //HttpChannel channel = new HttpChannel(9999);
            //ChannelServices.RegisterChannel(channel, false);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(Remoting), "MyRemoting", WellKnownObjectMode.SingleCall);
            //Console.ReadLine();

            Program.Run(new Program());
            Console.ReadLine();
        }

        protected override void OnStart(string[] args)
        {
            HttpChannel channel = new HttpChannel(9999);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Remoting), "MyRemoting", WellKnownObjectMode.SingleCall);
            Console.ReadLine();
        }

        protected override void OnStop()
        {
            //base.OnStop();
        }
    }
}
