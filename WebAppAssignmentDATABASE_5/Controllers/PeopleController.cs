using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Data;
using WebAppAssignmentDATABASE_5.Models;
using WebAppAssignmentDATABASE_5.Models.Service;
using WebAppAssignmentDATABASE_5.Models.ViewModel;

namespace WebAppAssignmentDATABASE_5.Controllers
{
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;
        ICityService _cityService;
        PeopleDbContext _context;

        public PeopleController(IPeopleService peopleService, ICityService cityService, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            if (peopleViewModel.FilterText != null)
            {
                peopleViewModel = _peopleService.FindBy(peopleViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            vm.selectList = new SelectList(_context.Cities, "Name", "Name");

            return View(vm);
            //return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(createPersonViewModel);

                int cityId = _context.Cities.Where(c => c.Name == createPersonViewModel.City).First().CityId;

                _cityService.AddPersonToCity(cityId, person);

                return RedirectToAction(nameof(Index));
            }

            createPersonViewModel.selectList = new SelectList(_context.Cities, "Name", "Name");
            return View(createPersonViewModel);
        }

        public IActionResult Remove(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
