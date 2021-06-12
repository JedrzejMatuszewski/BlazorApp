using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="First name is mandatory! (custom err.)")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        //[EmailDomainValidator(AllowedDomain = "matuszewski.net", ErrorMessage ="Domain must be matuszewski.net")]
        public string Email { get; set; }

        public DateTime DateOfBrith { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; }

        public string PhotoPath { get; set; }
    }
}
