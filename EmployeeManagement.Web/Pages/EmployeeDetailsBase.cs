using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        protected string Coordinates { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(EmployeeId));
        }

        protected string BtnText { get; set; } = "Hide footer";
        protected string FooterCssClass { get; set; } = null;
        protected void HideCardFooter()
        {
            if(BtnText == "Hide footer")
            {
                FooterCssClass = "hideElement";
                BtnText = "Show footer";
            }
            else
            {
                FooterCssClass = null ;
                BtnText = "Hide footer";
            }
        }
    }
}
