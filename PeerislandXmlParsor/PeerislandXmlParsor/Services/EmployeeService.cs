using System;
using System.Collections.Generic;
using XmlProcessorLibrary;
using XmlProcessorLibrary.Models;

namespace PeerislandXmlParsor.Services
{
    /// <summary>
    /// Class used for Add, Delete and get all employees details
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeGenerator _employeeGenerator;
        public EmployeeService(IEmployeeGenerator employeeGenerator)
        {
            _employeeGenerator = employeeGenerator ?? throw new ArgumentNullException(nameof(employeeGenerator));
        }

        /// <summary>
        /// Add Employee in xml
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns>Add status</returns>
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {            
                var writeStatus = _employeeGenerator.AddEmployee(employeeModel);
                return writeStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete given employee if exist
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns> Delete status</returns>
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var deleteStatus = _employeeGenerator.DeleteEmployee<EmployeeModel>(employeeId);
                return deleteStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Employee Details for given employeeid
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Employee details</returns>
        public EmployeeModel GetEmployee(int employeeId)
        {
            try
            {
                var selectedEmployee = _employeeGenerator.GetEmployee<EmployeeModel>(employeeId);
                return selectedEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all employees in xml
        /// </summary>
        /// <returns>all employees</returns>
        public List<EmployeeModel> GetEmployees()
        {
            try
            {
                var employees = _employeeGenerator.GetEmployees<EmployeeModel>();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
