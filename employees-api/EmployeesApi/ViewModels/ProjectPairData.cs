namespace EmployeesApi.ViewModels
{
    public class ProjectPairData
    {
        public int ProjectId { get; set; }
        public int CommonDays { get; set; }

        public ProjectPairData(int projectId, int commonDays)
        {
            this.ProjectId = projectId;
            this.CommonDays = commonDays;
        }
    }
}
