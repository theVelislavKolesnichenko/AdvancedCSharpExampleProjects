using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETRmotingCL
{
    public interface IRemoting
    {
        int RetSomeValue();
    }

    public class Remoting : MarshalByRefObject, IRemoting
    {
        public int RetSomeValue()
        {
            return 3;
        }
    }
}
