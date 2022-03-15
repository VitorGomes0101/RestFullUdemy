using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Controllers.Model;

namespace RestWithASPNETUdemy.Controllers.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                Id = 1,
                FirstName = "Vitor",
                LastName = "Gomes",
                Gender = "Male",
                Address = "Rua José Ferreira da Silva - Monteiro - PB"
            };
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person Update(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "F_Name" + i,
                LastName = "L_Name" + i,
                Gender = "Male",
                Address = "Some address" + i
            };
            
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}