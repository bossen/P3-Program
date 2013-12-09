using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApplication5
{
    class Program
    {
        public class Creature
        {
            public int CreatureId { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Person : Creature
        {
            public List<Creature> Pets { get; set; }
        }

        public class Dog : Creature
        {
            public string WuffSound { get; set; }
        }

        public class Cat : Creature
        {
            public string MiavSound { get; set; }
        }

        public class AnimalContext : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Dog> Dogs { get; set; }
            public DbSet<Cat> Cats { get; set; }
        }

        static void Main(string[] args)
        {
            using (var db = new AnimalContext())
            {
                Cat c1 = new Cat() { Age = 2, Name = "snowy", MiavSound = "MIAAUVVV" };
                Dog d1 = new Dog() { Age = 13, Name = "Futte", WuffSound = "woof" };
                Person p1 = new Person() { Age = 2, Name = "jack", Pets = new List<Creature>() { c1, d1 } };

                foreach (Creature p in p1.Pets)
                {
                    Console.WriteLine(p.Name);
                }

                db.Cats.Add(c1);
                db.Dogs.Add(d1);
                db.People.Add(p1);
                db.SaveChanges();

                foreach (Person p in db.People)
                {
                    foreach (Creature c in p.Pets)
                    {
                        Console.WriteLine(c.Name);
                    }
                }
            }

            using (var db = new AnimalContext())
            {
                foreach (Person p in db.People)
                {
                    foreach (Creature c in p.Pets)
                    {
                        Console.WriteLine(c.Name);
                    }
                }
            }
        }
    }
}
