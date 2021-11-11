using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentDATABASE_5.Models.Repo
{
    public interface ICityRepo
    {
        Person AddPersonToCity(int id, Person person);
        City Create(string name);
        List<City> Read();
        City Read(int id);
        City Update(City city);
        bool Delete(City city);
    }
}
