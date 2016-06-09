using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyService ms = new MyServiceClient("BasicHttpBinding_IMyService");
            Console.WriteLine(ms.RetSomeValue());
            Console.ReadLine();
        }
    }
}
