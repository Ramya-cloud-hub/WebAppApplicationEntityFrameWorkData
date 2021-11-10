using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Controllers;

namespace WebAppAssignmentDATABASE_5.Models
{
   public interface IPeopleRepo
    {
        Person Create(string name, string city, int phoneNumber);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
    }
}