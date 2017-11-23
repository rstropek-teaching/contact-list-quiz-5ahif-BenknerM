using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;


namespace WebApplication1.Services
{
    public interface IPersonRepository
    {
        void AddPerson(Person p);
        IEnumerable<Person> GetAll();
        bool DeleteById(int id);
        IEnumerable<Person> FindByName(string name);
        Person GetLast();
    }
}
