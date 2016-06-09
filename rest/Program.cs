using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace rest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Servicce));
            host.Open();
            Console.ReadLine();
            host.Close();
        }
    }

    [ServiceContract]
    public class Servicce
    {
        static int state;
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/MyMethod/{num}")]
        public void Set(string num)
        {
            state = Convert.ToInt32(num);
        }

        [OperationContract]
        public string Get()
        {
            return state.ToString();
        }
    }
}
