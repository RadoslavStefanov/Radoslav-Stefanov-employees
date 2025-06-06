﻿using EmployeesApi.Models;
using EmployeesApi.ViewModels;

namespace EmployeesApi.Contracts.Services
{
    public interface IPairCalculatorService
    {
        public Task<EmployeePairResult> FindLongestWorkingPair(List<EmployeeProject> records);
    }
}
