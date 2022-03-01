using System;
using System.Collections.Generic;
using System.Linq;
using XmlProcessorLibrary.Models;
using XmlProcessorLibrary.Repositories;

namespace XmlProcessorLibrary
{
    /// <summary>
    /// Interface exposed to outside client to do read/write opration on xml
    /// </summary>
    public sealed class EmployeeGenerator : IEmployeeGenerator
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeGenerator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        /// <summary>
        /// Add Employee in to existing employee list
        /// </summary>
        /// <typeparam name="T"> Generic type model</typeparam>
        /// <param name="employeeModel"> Employee model need to add in employee collection</param>
        /// <returns></returns>
        public bool AddEmployee<T>(T employeeModel)
        {
            try
            {
                var addStatus = _employeeRepository.AddEmployee<T>(employeeModel);
                return addStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Employee for xml file by EmployeeId
        /// </summary>
        /// <typeparam name="T">Generic type model</typeparam>
        /// <param name="employeeId">Delete employee by employeeId</param>
        /// <returns>Delete status</returns>
        public bool DeleteEmployee<T>(int employeeId)
        {
            try
            {                
                var deleteStatus = _employeeRepository.DeleteEmployee<T>(employeeId);

                return deleteStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Employee details of given id
        /// </summary>
        /// <typeparam name="T">IEmployee Model</typeparam>
        /// <param name="employeeId"> Employee Id</param>
        /// <returns>Employee Details</returns>
        public T GetEmployee<T>(int employeeId)
        {
            try
            {
                var employees = _employeeRepository.GetEmployees<T>();
                var selectedEmployee = employees.ToList().Single(emp => ((IEmployeeModel)emp).EmployeeId == employeeId);
                return selectedEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get List of all employees
        /// </summary>
        /// <typeparam name="T"> Generic type model require as return type</typeparam>
        /// <returns>List of all employees</returns>
        public List<T> GetEmployees<T>()
        {
            try
            {
                var employees = _employeeRepository.GetEmployees<T>();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
