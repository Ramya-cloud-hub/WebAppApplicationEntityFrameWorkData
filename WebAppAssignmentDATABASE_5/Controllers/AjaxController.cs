using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models;
using WebAppAssignmentDATABASE_5.Models.ViewModel;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    public class AjaxController : Controller
    {

        //Deendency Injection
        IPeopleService _peopleService;

           public AjaxController(IPeopleService peopleService){

            _peopleService =peopleService;

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

        [HttpGet]
        public IActionResult PeoplePartial(int id)
        {
         

            return PartialView("PeoplePartial", _peopleService.All().PeopleListView);

        }

        [HttpPost]
        private IActionResult PersonPartial(int id)
        {
            Person person = _peopleService.FindBy(id);
            return PartialView("PersonPartial", person);
        }

  
        [HttpPost]
        public IActionResult Delete(int id)
        {
            
            bool success = _peopleService.Remove(id);
            string result = "";

            if (success)
                result = "Deleated Successfully!";
            else
                result = "Not Deleted Successfully!";

            return Content(result);
        }

       


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {

                _peopleService.Add(createPersonViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(createPersonViewModel);
        }
    }
}
