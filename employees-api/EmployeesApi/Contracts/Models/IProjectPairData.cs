namespace EmployeesApi.Contracts.Models
{
    public interface IProjectPairData
    {
        public int ProjectId { get; set; }
        public int CommonDays { get; set; }
    }
}
