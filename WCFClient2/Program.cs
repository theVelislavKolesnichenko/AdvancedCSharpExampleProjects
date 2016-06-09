using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyServiceClient ms = new MyServiceClient("BasicHttpBinding_IMyService");
            Console.WriteLine(ms.sum(2,2));
            MyService2Client ms2 = new MyService2Client("NetTcpBinding_IMyService2");
            Console.WriteLine(ms2.pro(2,2));
            Console.ReadLine();
        }
    }
}
