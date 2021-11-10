using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentDATABASE_5.Models
{
    public class Person
    {

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(10, 14)]
        public int Phone { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string City { get; set; }

        [Required]
        public int Id { get; set; }

        public Person(string name, int phone, string city, int id)
        {
            Name = name;
            Phone = phone;
            City = city;
            Id = id;
        }

    }
}
