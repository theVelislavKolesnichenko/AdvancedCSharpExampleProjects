#define Debug

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AttributesTest
{
    class Program
    {
        [Conditional("Debug")]
        private static void print(int a, [CallerFilePath] string path="", [CallerMemberName] string member = "", [CallerLineNumber] int lineNumber = 0)
        {
            Console.WriteLine("Print: \n{0}\n{1}\n{2}\n{3}",a, path,member,lineNumber);
        }

        static void Main(string[] args)
        {
            print(5);

            TestClass tc = new TestClass();

            Type type = tc.GetType();

            object[] attributes = type.GetCustomAttributes(typeof(DevInfoAttribute), true);
            
            if (attributes.Length != 0)
            {
                foreach (object attribute in attributes)
                {
                    DevInfoAttribute devInfoAttribute = attribute as DevInfoAttribute;

                    if (devInfoAttribute != null)
                    {
                        Console.WriteLine(devInfoAttribute.Date);
                        Console.WriteLine(devInfoAttribute.Name);
                        Console.WriteLine(devInfoAttribute.TypeId);
                    }
                    else
                    {
                        Console.WriteLine("DevInfoAttribute is null");
                    }
                }
            }
        }
    }
}
