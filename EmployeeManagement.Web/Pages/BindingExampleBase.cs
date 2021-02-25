using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class BindingExampleBase : ComponentBase
    {
        protected string TextBox { get; set; } = string.Empty;

        private static string _style = "width: 100px; height: 100px; background-color: ";

        public string MyStyle { get; set; } = _style + "red" ;

        private string _color = "red";
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                MyStyle = _style + _color;
            }
        }
    }
}
