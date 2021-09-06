using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models;
using WebAppAssignmentDATABASE_5.Models.ViewModel;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    public class PeopleController : Controller
    {

       private readonly IPeopleService _peopleService;
       
        //Dependency Injection to the constructor
        public PeopleController(IPeopleService peopleService)
        { 
            _peopleService = peopleService;
        }


        [HttpGet]
        public IActionResult Index()
        {
     
           PeopleService checkListView = new PeopleService();
            PeopleViewModel peopleList = new PeopleViewModel();

            InMemoryPeopleRepo makeBaseList = new InMemoryPeopleRepo();

            peopleList.PeopleListView = checkListView.All().PeopleListView;

            if (peopleList.PeopleListView.Count == 0 || peopleList.PeopleListView == null)
            {
                makeBaseList.CreateBasePersons();
            }

            return View(peopleList);
        }



        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleviewModel)
        {
            PeopleService filterString = new PeopleService();

            peopleviewModel = filterString.FindBy(peopleviewModel);
            return View(peopleviewModel);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel) 
        {

            if (ModelState.IsValid)
            {

                _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(personViewModel);
        }


        public IActionResult DeletePerson(int id)
        {
            PeopleService deleteById = new PeopleService();
            deleteById.Remove(id);

            return RedirectToAction("Index");
        }
    

    }
}
