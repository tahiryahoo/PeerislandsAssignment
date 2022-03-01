using System.Collections.Generic;
using PeerislandXmlParsor.Models;

namespace PeerislandXmlParsor.Services
{
    /// <summary>
    /// Class used for Add, Delete and get all employees with Designation
    /// </summary>
    public interface IEmployeeDesignationService
    {
        /// <summary>
        /// Add Employee in xml
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns>Add status</returns>
        bool AddEmployee(EmployeeDesignationModel employeeModel);

        /// <summary>
        /// Delete given employee if exist
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns> Delete status</returns>
        bool DeleteEmployee(int employeeId);

        /// <summary>
        /// Get all employees in xml
        /// </summary>
        /// <returns>all employees</returns>
        List<EmployeeDesignationModel> GetEmployees();

        /// <summary>
        /// Get single employee by given employee id
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Selected employee details</returns>
        EmployeeDesignationModel GetEmployee(int employeeId);
    }
}
