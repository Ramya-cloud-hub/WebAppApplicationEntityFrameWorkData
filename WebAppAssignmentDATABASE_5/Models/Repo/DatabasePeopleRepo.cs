using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int _idCounter;

        //Dependency Injection
     private readonly ExDbContext _exDBontext;
        public DatabasePeopleRepo(ExDbContext exDbContext)
        {
            _exDBontext = exDbContext;

            if (_personList.Count == 0)
            {
                _personList = Read();
            }
        }

       
        

        //Extra Code Added Last
        public Person Create(Person person)
        {
            List<Person> persons = new List<Person>();

            foreach (var item in persons)
            {
                _exDBontext.Peoples.Add(item);
            }
            _exDBontext.Peoples.Add(person);

            int result = _exDBontext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("Didn't manage to save to database :( :( :(");
            }

            return person;
        }



        public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(_idCounter, PersonName, PersonPhoneNumber, PersonCity);
            _personList.Add(newPerson);

            _idCounter++;

            return newPerson;
        }

        public bool Delete(Person person)
        {
            _personList.Remove(person);
            return true;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            Person findPersonById = _personList.Find(idNr => idNr.PersonId == id);

            return findPersonById;
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
