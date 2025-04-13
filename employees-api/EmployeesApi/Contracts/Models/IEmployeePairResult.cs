using EmployeesApi.ViewModels;

namespace EmployeesApi.Contracts.Models
{
    public interface IEmployeePairResult
    {
        public int EmpId1 { get; set; }
        public int EmpId2 { get; set; }
        public int TotalDaysWorked { get; set; }
        public List<ProjectPairData> Projects { get; set; }
    }
}
