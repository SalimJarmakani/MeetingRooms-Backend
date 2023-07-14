
using MeetingRoom.Services;
using MeetingRooms_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoom.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	[Authorize]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		// GET: api/employees
		[HttpGet]
		public IActionResult GetAllEmployees()
		{
			var employees = _employeeRepository.GetAllEmployees();
			return Ok(employees);
		}

		// GET: api/employees/{id}
		[HttpGet("{id}")]
		public IActionResult GetEmployeeById(int id)
		{
			var employee = _employeeRepository.GetEmployeeById(id);
			if (employee == null)
			{
				return NotFound();
			}
			return Ok(employee);
		}

		// POST: api/employees
		[HttpPost]
		public IActionResult AddEmployee(Employee employee)
		{
			_employeeRepository.AddEmployee(employee);
			return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
		}

		// PUT: api/employees/{id}
		[HttpPut("{id}")]
		public IActionResult UpdateEmployee(int id, Employee employee)
		{
			if (id != employee.Id)
			{
				return BadRequest();
			}

			_employeeRepository.UpdateEmployee(employee);
			return NoContent();
		}

		// DELETE: api/employees/{id}
		[HttpDelete("{id}")]
		public IActionResult DeleteEmployee(int id)
		{
			_employeeRepository.DeleteEmployee(id);
			return NoContent();
		}

		[HttpGet("{id}/companies")]
		public IActionResult GetEmployeeWithCompanies(int id)
		{
			var employee = _employeeRepository.GetEmployeeWithCompanies(id);

			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}
	}
}
