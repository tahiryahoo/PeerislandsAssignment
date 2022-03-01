using System;
using System.Xml.Serialization;

namespace XmlProcessorLibrary.Models
{
    /// <summary>
    /// Employee Model contain employee details
    /// </summary>
    [Serializable]
    public class EmployeeModel : IEmployeeModel
    {
        //Employee Unique Id
        public int EmployeeId { get; set; }

        //Employee First Name
        public string FirstName { get; set; }

        //Employee Last name
        public string LastName { get; set; }

        ////Employee age
        //public int Age { get; set; }

        ////Employee Designation
        //public string Designation { get; set; }
    }
}
