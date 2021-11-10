using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModel;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class PeopleService : IPeopleService
    {
        //Dependency Injection to the constructor
        IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            return _peopleRepo.Create(person.Name, person.City, person.Phone);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.PersonList = _peopleRepo.Read();

            return peopleViewModel;
        }

        public Person Edit(int id, Person person)
        {
            return _peopleRepo.Update(person); //ID?
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            List<Person> searchedPersonList = new List<Person>();

            foreach (Person item in _peopleRepo.Read())
            {
                if (item.City.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase) || item.Name.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase))
                {
                    searchedPersonList.Add(item);
                }
            }
            search.PersonList = searchedPersonList;

            return search;
        }

        public Person Findby(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            List<Person> listPersons = _peopleRepo.Read();
            bool deleted = false;

            foreach (Person item in listPersons)
            {
                if (item.Id == id)
                {
                    return _peopleRepo.Delete(item);
                }
            }

            return deleted;
        }

        public void CreateDefaultPeople()
        {
            _peopleRepo.Create("Ramya", "Göteborg", 017609856);
            _peopleRepo.Create("Srinivas", "Bangelore", 0987986785);
            _peopleRepo.Create("Mamatha", "Mysore", 009878967);
            _peopleRepo.Create("Kishore", "Hyderabad", 0987967851);
            _peopleRepo.Create("Saranya", "Stckholm", 091453147);
        }
    }
}
