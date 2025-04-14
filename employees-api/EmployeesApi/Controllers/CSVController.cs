using Microsoft.AspNetCore.Mvc;
using EmployeesApi.Contracts.Services;

namespace EmployeesApi.Controllers
{
    public class CSVController : Controller
    {
        private readonly IPairCalculatorService _pairService;
        private readonly ICsvParserService _csvParserService;

        public CSVController(IPairCalculatorService pairService, ICsvParserService csvParserService)
        {
            _pairService = pairService;
            _csvParserService = csvParserService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                var usersList = _csvParserService.Parse(file);
                return Ok(await _pairService.FindLongestWorkingPair(usersList));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to parse CSV: {ex.Message}");
            }
        }
    }
}
