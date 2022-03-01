using System;
using System.Collections.Generic;
using System.Text;
using XmlProcessorLibrary.Models;

namespace XmlProcessorLibrary
{
    /// <summary>
    /// This Interface exposed to external consumer
    /// </summary>
    public interface IEmployeeGenerator
    {
        List<T> GetEmployees<T>();

        T GetEmployee<T>(int employeeId);

        bool AddEmployee<T>(T employeeModel);

        bool DeleteEmployee<T>(int employeeId);
    }
}
