using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataLayer
{
    public class MyDataLayer : IDisposable
    {
        private PersonDbEntities _entities;

        public MyDataLayer()
        {
            _entities = new PersonDbEntities();
        }

        public IEnumerable<Car> GetCars()
        {
            return _entities.Cars.ToList();
        }

        public IEnumerable<Person> GetPersons()
        {
            return _entities.Persons.ToList();
        } 

        public void AddPerson(Person person)
        {
            _entities.Persons.Add(person);
        }

        public void Update(Person person)
        {
            _entities.Persons.Attach(person);
            
            _entities.Entry(person).State = EntityState.Modified;
            foreach (var order in person.Orders)
            {
                _entities.Entry(order).State = EntityState.Modified;
            }
            _entities.SaveChanges();
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            SaveChanges();
            _entities.Dispose();
        }
    }
}
