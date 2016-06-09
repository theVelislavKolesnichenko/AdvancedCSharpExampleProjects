using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyService));
            host.Open();
            Console.WriteLine("Start Service...");
            Console.ReadLine();
            host.Close();
        }
    }
}
