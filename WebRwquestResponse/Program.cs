using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRwquestResponse
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://tu-varna.bg");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);

            string html = string.Empty;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                html += line;
            }
            Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
