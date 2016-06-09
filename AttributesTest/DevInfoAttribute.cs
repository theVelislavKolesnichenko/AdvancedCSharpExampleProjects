using System;

namespace AttributesTest
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class DevInfoAttribute : Attribute
    {
        private string name;
        public string Name { get { return name; } }

        public string Date { get; set; }

        public DevInfoAttribute(string name)
        {
            this.name = name;
        }
    }
}
