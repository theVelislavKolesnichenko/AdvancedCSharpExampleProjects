using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    // This code produces the following output:
    //
    // Magnus:         Daisy
    // Terry:          Barley
    // Terry:          Boots
    // Terry:          Blue Moon
    // Charlotte:      Whiskers
    // Arlene:

    class Program
    {
        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person.FirstName equals pet.Owner.FirstName into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = (subpet == null ? String.Empty : subpet.Name) };

            foreach (var v in query)
            {
                Console.WriteLine("{0,-15}{1}", v.FirstName + ":", v.PetName);
            }
        }

        public static void JoinEx1()
        {
            Person magnus = new Person { Id = 1, FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { Id = 2, FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { Id = 3, FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { Id = 4, FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Id = 2, Name = "Barley", Owner = terry };
            Pet boots = new Pet { Id = 2, Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Id = 3, Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Id = 2, Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Id = 1, Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list of Person-Pet pairs where 
            // each element is an anonymous type that contains a
            // Pet's name and the name of the Person that owns the Pet.
            var query =
                people.Join(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, pet) =>
                                new { OwnerName = person.FirstName, Pet = (pet == null ? String.Empty : pet.Name) });


            //foreach (var obj in query)
            //{
            //    Console.WriteLine(
            //        "{0} - {1}",
            //        obj.OwnerName,
            //        obj.Pet);
            //}

            var result = people.GroupJoin(pets,
                person => person.Id, 
                pet => pet.Id, 
                (person, pet) => new { Key = person.FirstName, Persons = pet.Select(w =>w.Name).DefaultIfEmpty() });

            foreach (var language in result)
            {
                Console.WriteLine(String.Format("Persons speaking {0}:", language.Key));
                if(language.Persons != null)
                    foreach (var person in language.Persons)
                    {
                        Console.WriteLine(person);
                    }
            }

        }


        static void Main(string[] args)
        {
            //LeftOuterJoinExample();
            JoinEx1();
        }
    }
}
