using EmployeesApi.Contracts.Services;
using EmployeesApi.Models;
using EmployeesApi.ViewModels;

namespace EmployeesApi.Services
{
    public class PairCalculatorService : IPairCalculatorService
    {
        public async Task<EmployeePairResult> FindLongestWorkingPair(List<EmployeeProject> records)
        {
            GuardService.AgainstNullOrSingleUser(records);

            var projectGroups = records
                .GroupBy(e => e.ProjectId);

            var pairWorkDict = new Dictionary<string, EmployeePairResult>();

            foreach (var projectGroup in projectGroups)
            {
                var employees = projectGroup.ToList();

                for (int i = 0; i < employees.Count; i++)
                {
                    for (int j = i + 1; j < employees.Count; j++)
                    {
                        var emp1 = employees[i];
                        var emp2 = employees[j];

                        var overlapStart = emp1.DateFrom > emp2.DateFrom ? emp1.DateFrom : emp2.DateFrom;
                        var overlapEnd = emp1.DateTo < emp2.DateTo ? emp1.DateTo : emp2.DateTo;

                        if (overlapStart <= overlapEnd)
                        {
                            var daysWorked = (overlapEnd - overlapStart).Days;

                            var key = GetPairKey(emp1.EmpId, emp2.EmpId);

                            if (!pairWorkDict.ContainsKey(key))
                            {
                                pairWorkDict[key] = new EmployeePairResult
                                {
                                    EmpId1 = Math.Min(emp1.EmpId, emp2.EmpId),
                                    EmpId2 = Math.Max(emp1.EmpId, emp2.EmpId),
                                    TotalDaysWorked = 0
                                };
                            }

                            pairWorkDict[key].TotalDaysWorked += daysWorked;
                            if (pairWorkDict[key].Projects.Any(x => x.ProjectId == projectGroup.Key))
                                pairWorkDict[key].Projects.Find(x => x.ProjectId == projectGroup.Key).CommonDays += daysWorked;
                            else
                                pairWorkDict[key].Projects.Add(new ProjectPairData(projectGroup.Key, daysWorked));
                        }
                    }
                }
            }

            GuardService.AgainstNoPairs(pairWorkDict);

            return pairWorkDict.Values
                .OrderByDescending(p => p.TotalDaysWorked)
                .FirstOrDefault();
        }

        private string GetPairKey(int id1, int id2)
        {
            return $"{Math.Min(id1, id2)}-{Math.Max(id1, id2)}";
        }
    }
}
