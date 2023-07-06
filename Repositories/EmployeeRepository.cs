
using MeetingRoom.Services;
using MeetingRooms_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoom.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly MeetingRoomsContext _context;

		public EmployeeRepository(MeetingRoomsContext context)
		{
			_context = context;
		}

		public IEnumerable<Employee> GetAllEmployees()
		{
			return _context.Employees.ToList();
		}

		public Employee GetEmployeeById(int id)
		{
			return _context.Employees.Find(id);
		}

		public void AddEmployee(Employee employee)
		{
			int maxId = _context.Employees.Max(e => e.Id);
			employee.Id = maxId + 1;

			_context.Employees.Add(employee);
			_context.SaveChanges();
		}

		public void UpdateEmployee(Employee employee)
		{
			_context.Employees.Update(employee);
			_context.SaveChanges();
		}

		public Employee GetEmployeeWithCompanies(int employeeId)
		{
			return _context.Employees
				.Include(e => e.Company)
				.FirstOrDefault(e => e.Id == employeeId);
		}



		public void DeleteEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			_context.Employees.Remove(employee);
			_context.SaveChanges();
		}
	}

}
