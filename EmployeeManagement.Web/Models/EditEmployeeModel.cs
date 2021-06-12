using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel : Employee
    {
        [EmailAddress]
        [CompareProperty("Email", ErrorMessage ="Email and Confirm Email must match!")]
        public string EmailConfirm { get; set; }


        public EditEmployeeModel()
        {
            Department = new Department();
        }
    }
}
