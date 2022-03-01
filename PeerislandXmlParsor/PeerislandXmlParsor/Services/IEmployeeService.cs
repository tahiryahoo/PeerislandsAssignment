using System.Collections.Generic;
using XmlProcessorLibrary.Models;

namespace PeerislandXmlParsor.Services
{
    public interface IEmployeeService
    {
       bool AddEmployee(EmployeeModel employeeModel);

       bool DeleteEmployee(int employeeId);

       List<EmployeeModel> GetEmployees();

       EmployeeModel GetEmployee(int employeeId);

    }
}
