using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XmlProcessorLibrary.Models;

namespace PeerislandXmlParsor.Models
{
    public interface IEmployeeDesignationModel : IEmployeeModel
    {
        public string Designation { get; set; }
    }
}
