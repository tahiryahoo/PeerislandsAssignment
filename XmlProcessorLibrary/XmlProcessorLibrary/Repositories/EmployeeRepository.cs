using System;
using System.Collections.Generic;
using System.Text;
using XmlProcessorLibrary.Models;
using XmlProcessorLibrary.Utilites;

namespace XmlProcessorLibrary.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool AddEmployee<T>(T employeeModel)
        {
            try
            {
                var employees = XmlUtility.ReadXML<T>();
                employees.Add(employeeModel);
                var writeStatus = XmlUtility.WriteXML<T>(employees);

                return writeStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployee<T>(int employeeId)
        {
            try
            {
                var employees = XmlUtility.ReadXML<T>();
                employees.RemoveAll(employee => ((IEmployeeModel)employee).EmployeeId == employeeId);
                var deleteStatus = XmlUtility.WriteXML<T>(employees);

                return deleteStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetEmployee<T>(int employeeId)
        {
            try
            {
                var employees = XmlUtility.ReadXML<T>();
                return employees.Find(employee => ((IEmployeeModel)employee).EmployeeId == employeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetEmployees<T>()
        {
            try
            {
                var employees = XmlUtility.ReadXML<T>();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
