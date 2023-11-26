﻿using _4Create.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
    }
}
