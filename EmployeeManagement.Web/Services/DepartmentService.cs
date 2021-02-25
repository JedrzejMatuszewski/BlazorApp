using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _httpClient.GetJsonAsync<Department>($"api/departments/{departmentId}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetJsonAsync<Department[]>($"api/departments");
        }
    }
}
