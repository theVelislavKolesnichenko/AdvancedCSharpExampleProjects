using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices
{
    [ServiceContract(Namespace = "WCFServices")]
    public interface IMyService
    {
        [OperationContract]
        int RetSomeValue();

        [OperationContract]
        int sum(int a, int b);

        [OperationContract]
        int minus(int a, int b);
    }

    [ServiceContract(Namespace = "WCFServices")]
    public interface IMyService2
    {
        [OperationContract]
        int pro(int a, int b);

        [OperationContract]
        int del(int a, int b);
    }

    public class MyService : IMyService, IMyService2
    {
        public int RetSomeValue()
        {
            return 15;
        }
        
        public int sum(int a, int b)
        {
            return a + b;
        }

        public int minus(int a, int b)
        {
            return a - b;
        }

        public int pro(int a, int b)
        {
            return a * b;
        }

        public int del(int a, int b)
        {
            return a / b;
        }
    }
}
