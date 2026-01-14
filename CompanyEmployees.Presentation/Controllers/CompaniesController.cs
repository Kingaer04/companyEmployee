using Microsoft.AspNetCore.Mvc;


namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var comapanies = _service.CompanyService.GetAllCompanies(trackChanges: false);
                return Ok(comapanies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
