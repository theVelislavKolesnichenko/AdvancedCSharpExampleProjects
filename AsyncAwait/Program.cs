using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async void AAsync()
        {
            Console.WriteLine("start AAsync {0}", Thread.CurrentThread.GetHashCode());
            Task<int> task = Task<int>.Run( () => BAsync());
            Console.WriteLine("affter AAsync await {0}", Thread.CurrentThread.GetHashCode());
            await task;
            Thread.Sleep(1000);
            Console.WriteLine("beffor AAsync await {0}", Thread.CurrentThread.GetHashCode());
        }

        static int BAsync()
        {
            Console.WriteLine("BAsync {0}", Thread.CurrentThread.GetHashCode());
            return 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start Main {0}", Thread.CurrentThread.GetHashCode());
            AAsync();
            Console.WriteLine("End Main {0}", Thread.CurrentThread.GetHashCode());
        }
    }
}
