using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> persons = new List<Person>()
        {
            new Person {Id = 1, FirstName = "Matthias", LastName = "Benkner", Email = "matzi.done@gmail.com" },
            new Person {Id = 2, FirstName = "Niklas", LastName = "Benkner", Email ="niklas.done@gmx.at" },
        };

        public void AddPerson(Person p)
        {
            persons.Add(p);
        }

        public IEnumerable<Person> GetAll()
        {
            return persons.ToArray();
        }

        public bool DeleteById(int id)
        {
            try
            {
                persons.RemoveAt(id - 1);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("not found");
            }
            return false;

        }

        public Person GetById(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> FindByName(string name)
        {
            List<Person> list = new List<Person>();

            foreach (Person p in this.persons)
            {
                if (p.FirstName.Contains(name) || p.LastName.Contains(name))
                {
                    list.Add(p);
                }
            }
            return list;


        }

        public List<Person> GetList()
        {
            return this.persons;
        }

        public Person GetLast()
        {
            return this.persons.Last();
        }
    }
}
