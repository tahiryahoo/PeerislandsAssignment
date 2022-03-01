using System;
using System.Collections.Generic;
using PeerislandXmlParsor.Models;
using XmlProcessorLibrary;

namespace PeerislandXmlParsor.Services
{
    /// <summary>
    /// Class used for Add, Delete and get all employees with Designation
    /// </summary>
    public class EmployeeDesignationService : IEmployeeDesignationService
    {
        private readonly IEmployeeGenerator _employeeGenerator;
        public EmployeeDesignationService(IEmployeeGenerator employeeGenerator)
        {
            _employeeGenerator = employeeGenerator ?? throw new ArgumentNullException(nameof(employeeGenerator));
        }

        /// <summary>
        /// Add Employee in xml
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns>Add status</returns>
        public bool AddEmployee(EmployeeDesignationModel employeeModel)
        {
            try
            {
                var addStatus = _employeeGenerator.AddEmployee(employeeModel);
                return addStatus;
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
                var deleteStatus = _employeeGenerator.DeleteEmployee<EmployeeDesignationModel>(employeeId);
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
        public EmployeeDesignationModel GetEmployee(int employeeId)
        {
            try
            {
                var selectedEmployee = _employeeGenerator.GetEmployee<EmployeeDesignationModel>(employeeId);
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
        public List<EmployeeDesignationModel> GetEmployees()
        {
            try
            {
                var allEmployees = _employeeGenerator.GetEmployees<EmployeeDesignationModel>();
                return allEmployees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
