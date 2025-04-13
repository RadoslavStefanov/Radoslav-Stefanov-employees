namespace EmployeesApi.Contracts.Models
{
    public interface IEmployeeProject
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
