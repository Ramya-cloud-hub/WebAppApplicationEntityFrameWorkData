﻿using Microsoft.AspNetCore.Mvc;
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

        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_peopleService.All().PersonList.Count == 0)
            {
                _peopleService.CreateDefaultPeople();
            }

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

        public IActionResult Remove(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
