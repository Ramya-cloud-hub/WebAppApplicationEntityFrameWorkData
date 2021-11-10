using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentDATABASE_5.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength =1)]
        [Required(ErrorMessage = "* Please enter name"), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string City { get; set; }

        public CreatePersonViewModel()
        {

        }
    }

}
