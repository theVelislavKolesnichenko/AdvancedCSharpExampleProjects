using rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Servicce proxy = new Servicce();

            HttpWebRequest request = WebRequest.Create("http://localhost:9999/Servicce/MyMethod/10") as HttpWebRequest;

            request.Method = "PUT";
            request.ContentLength = 0;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            bool status = (response.StatusCode == HttpStatusCode.OK);
            int state = Convert.ToInt32(proxy.Get());
            Console.WriteLine("State {0}", state);
            Console.ReadLine();

        }
    }
}
