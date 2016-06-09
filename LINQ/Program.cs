using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] arr = new double[] { 1.0, -2.0, 3.0, -3.0 };

            ////IEnumerable<double> res = from i in arr
            ////                          where i < 0.0
            ////                          select i;

            ////res = arr.Where(k => k < 0.0).Select(k => k);

            //var res = from i in arr
            //          where i < 0.0
            //          select new { Id = i };

            ////foreach (double d in res)
            ////{
            ////    Console.WriteLine("{0} ", d);
            ////}

            //Console.WriteLine("{0} ", res.ElementAt(0).Id);

            //Person[] person = new Person[] 
            //{
            //    new Person { Name="Name1", Id=1 },
            //    new Person { Name="Name2", Id=2 },
            //    new Person { Name="Name3", Id=3 }
            //};

            //XNamespace ns = "tu-varna.bg";

            //XDocument document = new XDocument(
            //    new XElement("Persons", new XComment("Same Person"), new XAttribute(XNamespace.Xmlns + "tu-varna", ns),
            //    new XElement("Person", new XAttribute("ID", person[0].Id), new XElement("Name", person[0].Name)),
            //    new XElement("Person", new XAttribute("ID", person[1].Id), new XElement("Name", person[1].Name)),
            //    new XElement("Person", new XAttribute("ID", person[2].Id), new XElement("Name", person[2].Name)))
            //    );

            //document.Declaration = new XDeclaration("1.0", "UTF-8", "standalone");
            //Console.WriteLine(document);
            //document.Save("Persons.xtml");

            //XElement element = new XElement("Name", "Ivan");
            //XAttribute attribut = new XAttribute("Id", 1);

            //Console.WriteLine(element);
            //Console.WriteLine(attribut);
            //Console.WriteLine((string) element);
            //Console.WriteLine((int) attribut);


            //XStreamingElement element0 = new XStreamingElement("Persons", new XComment("Same Person"), new XAttribute(XNamespace.Xmlns + "tu-varna", ns),
            //    from p in person
            //    select new XElement("Person", new XAttribute("Id", p.Id), new XElement("Name", p.Name)));
            //person[0].Id = 5;
            //XDocument document0 = new XDocument(element0);
            //Console.WriteLine(document0);
            //document.Save("Persons0.xtml");

            //XDocument document1 = XDocument.Load("Persons0.xtml");

            //var restord = from p in document1.Descendants("Person")
            //              select new Person { Id = (int) p.Attribute("Id"), Name = (string) p.Element("Name") };

            //foreach (var p in restord)
            //{
            //    Console.WriteLine("{0} {1}", p.Id, p.Name);
            //}

            Student[] student = new Student[] {
                new Student { fnum=1, name="S Name1" },
                new Student { fnum=2, name="S Name2" },
                new Student { fnum=3, name="S Name3" },
                new Student { fnum=4, name="S Name4" },
            };

            D[] d = new D[] {
                new D { number=1, name="D Name1" },
                new D { number=2, name="D Name2" },
                new D { number=3, name="D Name3" },
                new D { number=4, name="D Name4" },
            };

            O[] o = new O[] {
                new O {fnum=1, number=1, bal=4 },
                new O {fnum=2, number=1, bal=3 },
                new O {fnum=3, number=3, bal=5 },
                new O {fnum=2, number=4, bal=6 },
            };

            //1
            Console.WriteLine( student.Where(s => s.fnum == o.Where(o1 => o1.bal == 6).FirstOrDefault().fnum).FirstOrDefault().name );

            //2

            o.Where(o1 => o1.bal == 6).Where(o2 => d.Any(d1 => d1.number == o2.number));

            //3
            Console.WriteLine(student.Where(s => s.fnum == o.Where(o1 => o1.bal == 6).FirstOrDefault().fnum).FirstOrDefault().name);
        }
    }
    
    public static class ExtensionClass
    {
        public static void ExtensionString(this string a, int b)
        {
        }

    }

    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    class Student
    {
        public int fnum { get; set; }
        public string name { get; set; }
    }

    class D
    {
        public int number { get; set; }
        public string name { get; set; }
    }

    class O
    {
        public int fnum { get; set; }
        public int number { get; set; }
        public int bal { get; set; }
    }
}
