using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IServiceManager _services;
        
        public CompaniesV2Controller(IServiceManager service) => _services = service;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _services.CompanyService
                .GetAllCompaniesAsync(trackChanges: false);

            var companiesV2 = companies.Select(x => $"{x.Name} V2");

            return Ok(companiesV2);
        }
    }
}
