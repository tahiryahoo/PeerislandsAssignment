using System.Collections.Generic;
using XmlProcessorLibrary.Models;

namespace XmlProcessorLibrary.Repositories
{
    /// <summary>
    /// Employee repository insert, delete and get employee data from XML file
    /// </summary>
    public interface IEmployeeRepository
    {   
        //Fetch List of all employees details
        List<T> GetEmployees<T>();

        //Get employee details of given employeeId
        T GetEmployee<T>(int employeeId);

        //Add Employee in xml file
        bool AddEmployee<T>(T employeeModel);

        //Delete Employee from xml file
        bool DeleteEmployee<T>(int employeeId);

    }
}
