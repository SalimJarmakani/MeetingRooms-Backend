

using MeetingRoom.Services;
using MeetingRooms_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeetingRoom.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	[Authorize]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyController(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		[HttpGet]
		public IActionResult GetAllCompanies()
		{
			var companies = _companyRepository.GetAllCompanies();
			return Ok(companies);
		}

		[HttpGet("{id}")]
		public IActionResult GetCompanyById(int id)
		{
			var company = _companyRepository.GetCompanyById(id);
			if (company == null)
				return NotFound();

			return Ok(company);
		}

		[HttpPost]
		public IActionResult AddCompany(Company company)
		{
			if (company == null)
				return BadRequest();

			_companyRepository.AddCompany(company);

			return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCompany(int id, Company company)
		{
			if (company == null || id != company.Id)
				return BadRequest();

			var existingCompany = _companyRepository.GetCompanyById(id);
			if (existingCompany == null)
				return NotFound();

			_companyRepository.UpdateCompany(company);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCompany(int id)
		{
			var company = _companyRepository.GetCompanyById(id);
			if (company == null)
				return NotFound();

			_companyRepository.DeleteCompany(id);

			return NoContent();
		}

		[HttpGet("{companyId}/employees")]
		public ActionResult<List<Employee>> GetEmployeesByCompanyId(int companyId)
		{
			var employees = _companyRepository.GetEmployeesByCompanyId(companyId);
			if (employees == null || employees.Count == 0)
			{
				return NotFound();
			}

			return employees;
		}

	}
}
