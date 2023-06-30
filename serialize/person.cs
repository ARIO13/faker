using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace serialize
{

   public class User
    {
        private int v1;
        private string v2;

        public User(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Int32 Id { get; set; }
        public Guid CartId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 SomethingUnique { get; set; }
        public Int32 Age { get; set; }
        public String[] Phone { get; set; }
        public Int64 BirthDate { get; set; }
        public double Salary { get; set; }
        public Boolean IsMarried { get; set; }
        public Gender Gender { get; set; }
        public Order[] Orders { get; set; }

    }
    public class Order
    {
        public Int32 OrderId { get; set; }
        public string Item { get; set; }
        public int LotNumber { get; set; }
        public Int64 Quantity { get; set; }
    }
   public enum Gender 
    {
        Male,Female
    }
    class progr
    {
        static void Main(string[] args)
        {

            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            var orderIds = 0;
            var testOrders = new Faker<Order>()
                //Ensure all properties have rules. By default, StrictMode is false
                //Set a global policy by using Faker.DefaultStrictMode
                .StrictMode(true)
                //OrderId is deterministic
                .RuleFor(o => o.OrderId, f => orderIds++)
                //Pick some fruit from a basket
                .RuleFor(o => o.Item, f => f.PickRandom(fruit))
                //A random quantity from 1 to 10
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
                //A nullable int? with 80% probability of being null.
                //The .OrNull extension is in the Bogus.Extensions namespace.
                .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));


            var userIds = 0;
            var testUsers = new Faker<User>()
                //Optional: Call for objects that have complex initialization
                .CustomInstantiator(f => new User(userIds++, f.Random.Replace("###-##-####")))

                //Use an enum outside scope.
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())

                //Basic rules using built-in generators
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())

                //Use a method outside scope.
                .RuleFor(u => u.CartId, f => Guid.NewGuid())
                //Compound property with context, use the first/last name properties
                //And composability of a complex collection.
                .RuleFor(u => u.Orders, f => testOrders.Generate(4).ToList())
                //Optional: After all rules are applied finish with the following action
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("User Created! Id={0}", u.Id);
                });

            var user = testUsers.Generate();
            Console.WriteLine(user.DumpAsJson());
        }
    }
}/*
    Faker<Person> generatorPerson = getGeneratorPerson();
            // генерируем 3 объекта класса Person
            List<Person> persons = generatorPerson.Generate(5);
            // выводим полученные объекты на консоль
            PrintPersons(persons);
            Console.ReadKey();
            

        }


        private static Faker<Person> getGeneratorPerson()

        {
            DateTime dateChild = new DateTime(2000, 02, 6);
            var orderIds = 0;
            var testOrders = new Faker<Child>()
       //Ensure all properties have rules. By default, StrictMode is false
       //Set a global policy by using Faker.DefaultStrictMode
       //OrderId is deterministic
       .RuleFor(c => c.Id, f => orderIds++)
       //Pick some fruit from a basket
       .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
       //A random quantity from 1 to 10
       .RuleFor(c => c.FirstName, (f, x) => f.Name.FirstName(f.Person.Gender))

       .RuleFor(c => c.LastName, f => f.Name.LastName(f.Person.Gender));
       //.RuleFor(c => c.BirthDate, f => f.Random.Int(dateChild, DateTime.Now).OrNull(f, .8f));

            var Id = 0;
            // создаём экземпляр класса Faker<Person> и указываем,
            return new Faker<Person>("en")

                .RuleFor(x => x.Id, f => Id++)
                .RuleFor(x => x.SequenceId, f => Id++)
                .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
                .RuleFor(x => x.FirstName, (f, x) => f.Name.FirstName (f.Person.Gender))
                .RuleFor(x => x.LastName, f => f.Name.LastName(f.Person.Gender))
                .RuleFor(x => x.IsMarried, f => f.Random.Bool())
                .RuleFor(x => x.TransportId, f => f.Random.Guid())
                .RuleFor(x => x.Salary, f => f.Random.Int(15000, 100000))
                //.RuleFor(c => c.BirthDate, f => f.Date.Past(dateChild, DateTime.Now))

                .RuleFor(x => x.Age, f => f.Random.Byte(16, 60))
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Children, f => testOrders.Generate(3).ToList().OrNull(f, .2f))          

                .RuleFor(x => x.Salary, f => f.Random.Int(15000, 100000));

        }

        private static void PrintPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {

                Console.WriteLine($"Основная информация:\n{person.Id}\n{person.FirstName}\n{person.LastName}\n{person.Gender}\n{person.Age}\n{person.IsMarried}\n{person.Phone}\n{person.Salary}\n{person.TransportId}");
                Console.WriteLine($"Информация о работе:\n{person.Children}\n");
                //Serialize
              //  string jsonString = JsonSerializer.Serialize(person);
               // Console.WriteLine(jsonString);
            }
        }














 return new Faker <Child>("en")
                    
                        .RuleFor(x => x.Id, f => Id++)            
                        .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
                        .RuleFor(x => x.FirstName, (f, x) => f.Name.FirstName (f.Person.Gender))
                        .RuleFor(x => x.LastName, f => f.Name.LastName(f.Person.Gender))
                       

                        Position = f.Random.ListItem
                        (new List<string>
                        {
                            "Программист",
                            "Менеджер",
                            "Бизнес-аналитик",
                            "Дизайнер",
                            "Тестировщик"
                        })
                    };             
}*/