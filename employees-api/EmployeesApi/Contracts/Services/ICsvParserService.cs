using EmployeesApi.Models;

namespace EmployeesApi.Contracts.Services
{
    public interface ICsvParserService
    {
        List<EmployeeProject> Parse(IFormFile file);
    }
}
