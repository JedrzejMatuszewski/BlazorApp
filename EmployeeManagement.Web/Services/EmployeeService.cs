﻿using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _httpClient.GetJsonAsync<Employee>($"api/Employees/{employeeId}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/Employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await _httpClient.PutJsonAsync<Employee>($"api/Employees/{updatedEmployee.EmployeeId}", updatedEmployee);
        }
    }
}
