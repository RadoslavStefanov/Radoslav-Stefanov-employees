using EmployeesApi.Models;
using EmployeesApi.ViewModels;

namespace EmployeesApi.Services
{
    public static class GuardService
    {
        public static void AgainstNullOrSingleUser(List<EmployeeProject> records) {
            if (records.Count <= 1)
                throw new ArgumentException("List that are empty or hold only one entry are not supported!");
        }

        public static void AgainstNoPairs(Dictionary<string, EmployeePairResult> records) { 
            if(records.Count == 0)
                throw new ArgumentException("No pairs were found in the provided data!");
        }

    }
}
