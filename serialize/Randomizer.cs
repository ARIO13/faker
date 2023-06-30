/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace serialize
{
    class Randomizer
    {
        public string FirstName { get; private set; }

        private void RandName()
        public Int32 Id { get; set; }
        public Guid TransportId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 SequenceId { get; set; }
        public String[] CreditCardNumber { get; set; }
        public Int32 Age { get; set; }
        public String[] Phone { get; set; }
        public Int64 BirthDate { get; set; }
        public double Salary { get; set; }
        public Boolean IsMarried { get; set; }
        public Gender Gender { get; set; }
        public Child[] Children { get; set; }



       


     
            public static void Main(string[] args)
            {
            bool =false;
            if ( z == true)
            {
                String[] first = new String[] { "Ivan", "Petr", "Sergey" };

            }
            else
            {
                String[] first = new String[] { "Masha", "Dasha", "Sasha" };

            }
            String[] last = new String[] {"Ivanov", "Petrov", "Sergeev"};

                
                Random rnd = new Random();
                int x = -1;
                int y = -1;

                x = rnd.Next(0, first.Length);
                y = rnd.Next(0, last.Length);

                Console.WriteLine(first[x] + " " + last[y]);
            }
        
    }

















return new Faker<Child>("ru")
                        .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())

                        // заполняем свойство Company
                        .RuleFor(x => x.LastName, f => f.Name.LastName())
                        .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                        .RuleFor(x => x.Gender, f => f.Random.Enum<Gender>())
*/