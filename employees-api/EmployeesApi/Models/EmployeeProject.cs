﻿using EmployeesApi.Contracts.Models;

namespace EmployeesApi.Models
{
    public class EmployeeProject : IEmployeeProject
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
