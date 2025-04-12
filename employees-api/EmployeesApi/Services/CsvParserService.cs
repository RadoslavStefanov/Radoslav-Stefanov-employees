using CsvHelper.Configuration;
using CsvHelper;
using EmployeesApi.Contracts.Services;
using EmployeesApi.Models;
using System.Globalization;

namespace EmployeesApi.Services
{
    public class CsvParserService : ICsvParserService
    {
        public List<EmployeeProject> Parse(IFormFile file)
        {
            var records = new List<EmployeeProject>();

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                IgnoreBlankLines = true,
                TrimOptions = TrimOptions.Trim,
            });

            var rawRows = csv.GetRecords<dynamic>();

            foreach (var row in rawRows)
            {
                int empId = int.Parse(row.EmpID);
                int projectId = int.Parse(row.ProjectID);

                DateTime dateFrom = DateTime.Parse(row.DateFrom);
                DateTime dateTo = string.IsNullOrWhiteSpace(row.DateTo) || row.DateTo == "NULL"
                    ? DateTime.Today
                    : DateTime.Parse(row.DateTo);

                records.Add(new EmployeeProject
                {
                    EmpId = empId,
                    ProjectId = projectId,
                    DateFrom = dateFrom,
                    DateTo = dateTo
                });
            }

            return records;
        }

    }
}
