

using MeetingRooms_Backend.Models;

namespace MeetingRoom.Services
{
	public interface ICompanyRepository
	{

		IEnumerable<Company> GetAllCompanies();
		Task<Company?> GetCompanyById(int companyId);
		void AddCompany(Company company);
		void UpdateCompany(Company company);
		void DeleteCompany(int id);

		public List<Employee> GetEmployeesByCompanyId(int companyId);
	}
}
