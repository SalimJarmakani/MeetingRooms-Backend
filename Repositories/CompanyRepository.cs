
using MeetingRoom.Services;
using MeetingRooms_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoom.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly MeetingRoomsContext _context;

		public CompanyRepository(MeetingRoomsContext context)
		{
			_context = context;
		}

		public IEnumerable<Company> GetAllCompanies()
		{
			return _context.Companies.ToList();
		}

		public async Task<Company?> GetCompanyById(int id)
		{
			Company? company = await _context.Companies
				.Include(c => c.Employees) // Include the related employees
				.FirstOrDefaultAsync(c => c.Id == id);
			return company; 
		}

		public void AddCompany(Company company)
		{
			int maxId = _context.Companies.Max(c => (int?)c.Id) ?? 0;
			company.Id = maxId + 1;

			_context.Companies.Add(company);
			_context.SaveChanges();
		}


		public void UpdateCompany(Company company)
		{
			_context.Companies.Update(company);
			_context.SaveChanges();
		}

		public void DeleteCompany(int id)
		{
			var company = _context.Companies.Find(id);
			_context.Companies.Remove(company);
			_context.SaveChanges();
		}

		public List<Employee> GetEmployeesByCompanyId(int companyId)
		{
			var employees = _context.Employees
				.Where(e => e.CompanyId == companyId)
				.ToList();

			return employees;
		}
	}
}
