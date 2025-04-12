namespace EmployeesApi.ViewModels
{
    public class EmployeePairResult
    {
        public int EmpId1 { get; set; }
        public int EmpId2 { get; set; }
        public int TotalDaysWorked { get; set; }
        public List<ProjectPairData> Projects { get; set; } = new();
    }
}
