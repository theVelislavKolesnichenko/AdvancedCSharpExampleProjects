using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class BankAccount
    {
        public BankAccount() { }
        public BankAccount(string s, int i, double b, DateTime d)
        {
            owner = s;
            Id = i;
            balance = b;
            date = d;
        }

        [DataMember]
        public string owner { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        protected double balance;
        [DataMember]
        public DateTime date;

    }

    [KnownType("Student")]
    [DataContract]
    [Serializable]
    public class Person : ISerializable
    {
        public Person() { }
        [DataMember]
        [XmlAttribute]
        public string Name { get; set; }
        [DataMember]
        [XmlIgnore]
        public int Id { get; set; }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Id = (int)info.GetValue("Id", typeof(int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name+";");
            info.AddValue("Id", Id);
        }
    }

    public class Student
    {
        public Student() { }
    }

    class Program
    {
        static void Soap()
        {
            Person person = new Person();
            person.Name = "Koko";
            person.Id = 1;

            Stream s = File.Open("serialization", FileMode.Create);
            IFormatter fmt = new SoapFormatter();
            fmt.Serialize(s, person);
            s.Close();

            Stream file = File.Open("serialization", FileMode.Open);
            Person restored = (Person)fmt.Deserialize(file);
            Console.WriteLine("{0}", restored.Name);
        }

        static void Soap2()
        {
            List<BankAccount> bank = new List<BankAccount>();
            bank.Add(new BankAccount("Owner1", 1, 125, DateTime.Now));
            bank.Add(new BankAccount("Owner2", 2, 125, DateTime.Now));
            bank.Add(new BankAccount("Owner3", 3, 125, DateTime.Now));


            Stream s = File.Open("serializationB", FileMode.Create);
            IFormatter fmt = new SoapFormatter();
            fmt.Serialize(s, bank);
            s.Close();

            Stream file = File.Open("serializationB", FileMode.Open);
            List<BankAccount> restored = (List<BankAccount>)fmt.Deserialize(file);
            Console.WriteLine("{0}", string.Join(" ", restored.Select(b => b.owner)));
        }

        static void XML()
        {
            Person person = new Person();
            person.Name = "Koko";
            person.Id = 1;

            StreamWriter s = new StreamWriter("xmlserializable.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            serializer.Serialize(s, person);
            s.Close();

            Stream file = File.Open("serialization", FileMode.Open);

            StreamReader sr = new StreamReader("xmlserializable.xml");
            Person restore = (Person)serializer.Deserialize(sr);
            Console.WriteLine("{0}", restore.Name);
        }

        static void XML2()
        {
            List<BankAccount> bank = new List<BankAccount>();
            bank.Add(new BankAccount("Owner1", 1, 125, DateTime.Now));
            bank.Add(new BankAccount("Owner2", 2, 125, DateTime.Now));
            bank.Add(new BankAccount("Owner3", 3, 125, DateTime.Now));

            StreamWriter s = new StreamWriter("xmlserializableBankAccount.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<BankAccount>));
            serializer.Serialize(s, bank);
            s.Close();

            Stream file = File.Open("serialization", FileMode.Open);

            StreamReader sr = new StreamReader("xmlserializableBankAccount.xml");
            List<BankAccount> restore = (List<BankAccount>)serializer.Deserialize(sr);

            Console.WriteLine("{0}", string.Join(" ", restore.Select(b => b.owner)));
        }

        static void DetaContract()
        {
            Person person = new Person();
            person.Name = "Koko";
            person.Id = 1;

            XmlWriter s = XmlWriter.Create("xmlDetaContractserializable.xml");
            DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
            serializer.WriteObject(s, person);
            s.Close();

            XmlReader file = XmlReader.Create("xmlDetaContractserializable.xml");
            Person restore = (Person)serializer.ReadObject(file);
            Console.WriteLine("{0}", restore.Name);
        }

        static void Custom()
        {
            Person person = new Person();
            person.Name = "Koko";
            person.Id = 1;

            Stream s = File.Open("serializationBinary", FileMode.Create);
            IFormatter fmt = new BinaryFormatter();
            fmt.Serialize(s, person);
            s.Close();

            Stream file = File.Open("serializationBinary", FileMode.Open);
            Person restored = (Person)fmt.Deserialize(file);
            Console.WriteLine("{0}", restored.Name);
        }

        static void Main(string[] args)
        {
            XML2();
        }
    }
}
