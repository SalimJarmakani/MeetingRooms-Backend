

using MeetingRooms_Backend.Models;

namespace MeetingRoom.Services
{
	public interface IEmployeeRepository
	{

		IEnumerable<Employee> GetAllEmployees();
		Employee GetEmployeeById(int id);
		void AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(int id);

		public Employee GetEmployeeWithCompanies(int employeeId);
	}
}
