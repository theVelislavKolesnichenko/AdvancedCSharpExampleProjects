using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncThread
{
    class Program
    {

        delegate string DoSomeWorkAsync(int sleepTime, out int timeSlept);

        static string DoSomeWork(int sleepTime, out int timeSlept)
        {
            Thread.Sleep(sleepTime);
            timeSlept = sleepTime;
            return sleepTime.ToString();
        }

        static void CallBack(IAsyncResult ar)
        {
            int time3;

            string str3 = ((DoSomeWorkAsync)((AsyncResult)ar).AsyncDelegate).EndInvoke(out time3, ar);

            Console.WriteLine("callback: Async end work str = {0} time = {1}", str3, time3);
        }

        static void CallBack1(IAsyncResult ar)
        {
            int time;

            string str = ((DoSomeWorkAsync)ar.AsyncState).EndInvoke(out time, ar);

            Console.WriteLine("AsyncStatus: Async end work str = {0} time = {1}", str, time);
        }

        static void Main(string[] args)
        {
            DoSomeWorkAsync dswa = new DoSomeWorkAsync(DoSomeWork);

            //Directno izvikvane
            int time;
            IAsyncResult obj0 = dswa.BeginInvoke(1000, out time, null, null);

            Console.WriteLine("Main Work");

            string str = dswa.EndInvoke(out time, obj0);

            Console.WriteLine("Async end work str = {0} int = {1}", str, time);

            //waittable
            int time1;
            IAsyncResult obj1 = dswa.BeginInvoke(2000, out time1, null, null);

            Console.WriteLine("Main Work");

            obj1.AsyncWaitHandle.WaitOne();

            string str1 = dswa.EndInvoke(out time1, obj1);

            Console.WriteLine("waittable: Async end work str = {0} int = {1} int1 = {2}", str1, time, time1);

            //polling
            int time2;
            IAsyncResult obj2 = dswa.BeginInvoke(3000, out time, null, null);

            Console.WriteLine("Main Work");

            while (!obj2.IsCompleted) { Console.WriteLine("polling"); }

            string str2 = dswa.EndInvoke(out time2, obj2);

            Console.WriteLine("waittable: Async end work str = {0} time = {1} time1 = {2}", str2, time, time2);

            ////callback
            int time3;
            IAsyncResult obj3 = dswa.BeginInvoke(4000, out time3, new AsyncCallback(CallBack), null);
            Console.WriteLine("Main Work");

            ////AsyncStatus
            int time4;
            IAsyncResult obj4 = dswa.BeginInvoke(4000, out time4, new AsyncCallback(CallBack1), dswa);
            Console.WriteLine("Main Work");


            Thread.Sleep(10000);

        }


    }


}
