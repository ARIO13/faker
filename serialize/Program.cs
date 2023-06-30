using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomData
{
    public class Person
    {

        public Int32 Age { get; set; }
        public string Phone { get; set; }
      
        public string FirstName { get; private set; }               
        public Int32 Id { get; set; }
        public Guid TransportId { get; set; }
        public string LastName { get; set; }
        public Int32 SequenceId { get; set; }
        public String[] CreditCardNumber { get; set; }
        public Int64 BirthDate { get; set; }
        public double Salary { get; set; }
        public Boolean IsMarried { get; set; }
        public Child[]? Children { get; set; }

        public Gender Gender { get; set; }

    }



    public class Child
    {
        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 BirthDate { get; set; }
        public Gender Gender { get; set; }

        
    }
    public enum Gender
    {
        Male, Female
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Faker<Person> generatorPerson = getGeneratorPerson();           
            List<Person> persons = generatorPerson.Generate(5);
            PrintPersons(persons);
            Console.ReadKey();     
        }


        private static Faker<Person> getGeneratorPerson()
        {
            DateTime startDate = new DateTime(2000, 02, 6);
            DateTime endDate=new DateTime(2023, 06, 1);
            var childId = 0;
            var Childgen = new Faker<Child>()       
       .RuleFor(c => c.Id, f => childId++)       
       .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())       
       .RuleFor(c => c.FirstName, (f, x) => f.Name.FirstName(f.Person.Gender))
       .RuleFor(c => c.LastName, f => f.Name.LastName(f.Person.Gender));
      // .RuleFor(c => c.BirthDate, f => f.Date.Random(startDate, endDate));

            var Id = 0;
            return new Faker<Person>("en")

                .RuleFor(x => x.Id, f => Id++)
                .RuleFor(x => x.SequenceId, f => Id++)
                .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
                .RuleFor(x => x.FirstName, (f, x) => f.Name.FirstName(f.Person.Gender))
                .RuleFor(x => x.LastName, f => f.Name.LastName(f.Person.Gender))
                .RuleFor(x => x.IsMarried, f => f.Random.Bool())
                .RuleFor(x => x.TransportId, f => f.Random.Guid())
                .RuleFor(x => x.Salary, f => f.Random.Int(15000, 100000))
                //.RuleFor(c => c.BirthDate, f => f.Date.Past(dateChild, DateTime.Now))

                .RuleFor(x => x.Age, f => f.Random.Byte(16, 60))
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber().OrNull(f, .9f))
                .RuleFor(x => x.Salary, f => f.Random.Int(15000, 100000));

                //.RuleFor(x => x.Children, f => Childgen.Generate(3).ToString().OrNull(f, 0.15f))
                //.FinishWith((f, u) =>
                //{
                //    Console.WriteLine("User Created! Id={0}", u.Id);
                //});


        }

        private static void PrintPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {

               // Console.WriteLine($"Основная информация:\n{person.Id}\n{person.FirstName}\n{person.LastName}\n{person.Gender}\n{person.Age}\n{person.IsMarried}\n{person.Phone}\n{person.Salary}\n{person.TransportId}");
                //Console.WriteLine($"Информация о работе:\n{person.Children}\n");
                //Serialize
                string jsonString = JsonSerializer.Serialize(person);
                Console.WriteLine(jsonString);
            }
        }
    }
}