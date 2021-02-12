using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{employeeId:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int employeeId)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(employeeId);

                if (result == null)
                {
                    return NotFound();
                }

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var employeeWithThatEmailAlreadyExist = await _employeeRepository.GetEmployeeByEmail(employee.Email);

                if (employeeWithThatEmailAlreadyExist != null)
                {
                    ModelState.AddModelError("email", "Employee eamil is already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { employeeId = createdEmployee.EmployeeId },
                    createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from the database");
            }
        }

        [HttpPost("{employeeId:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int employeeId, Employee employee)
        {
            try
            {
                if (employeeId != employee.EmployeeId)
                {
                    return BadRequest("Employee mismatch");
                }

                var employeeToUpdate = await _employeeRepository.GetEmployee(employeeId);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with id={employeeId} not found");
                }

                return await _employeeRepository.UpdateEmployee(employee);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error updating data");
            }
        }

        [HttpDelete("{employeeId:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int employeeId)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetEmployee(employeeId);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with id={employeeId} not found");
                }

                return await _employeeRepository.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error deleting data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await _employeeRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error retrieving data from the database");
            }
        }

    }
}