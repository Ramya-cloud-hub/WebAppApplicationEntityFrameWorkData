﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data;

namespace WebAppAssignmentDATABASE_5.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int idCounter = 0;
        private readonly PeopleDbContext _context;

        public DatabasePeopleRepo(PeopleDbContext context)
        {
            _context = context;
            if (_personList.Count == 0)
            {
                _personList = Read();
            }
        }

        public Person Create(string name, string stringCity, int phoneNumber)
        {
            List<City> cityList = _context.Cities.ToList();
            City selectedCity = null;

            // Define the query expression
            IEnumerable<City> cityQuery =
                from city in cityList
                where city.Name == stringCity
                select city;

            selectedCity = cityQuery.First();

            Person person = new Person(name, phoneNumber);
            person.City = selectedCity;
            idCounter++;

            _personList.Add(person);
            _context.People.Add(person);
            _context.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            bool deleted = _personList.Remove(person);
            if (deleted)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }

            return deleted;
        }

        public List<Person> Read()
        {
            if (_personList.Count == 0)
            {
                _personList = _context.People.ToList();
                if (_personList.Count != 0)
                    idCounter = _personList.Last().Id;
            }

            return _personList;
        }

        public Person Read(int id)
        {
            //LINQ expression
            if (_personList.Count == 0)
            {
                _personList = Read();
            }

            IEnumerable<Person> personQuery =
                from person in _personList
                where person.Id == id
                select person;

            Person person1 = personQuery.First();

            return person1;
        }

        public Person Update(Person person)
        {
            foreach (Person item in _personList)
            {
                if (item.Id == person.Id)
                {
                    item.Name = person.Name;
                    item.Phone = person.Phone;
                    item.City = person.City;

                    _context.People.Update(item);
                    _context.SaveChanges();
                }
            }

            return person;
        }
    }
}