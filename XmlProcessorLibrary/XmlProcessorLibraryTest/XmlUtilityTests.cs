using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using XmlProcessorLibrary.Models;
using XmlProcessorLibrary.Utilites;
using Xunit;

namespace XmlProcessorLibraryTest
{
    public class XmlUtilityTests
    {
        [Theory, AutoMoqData]
        public void WriteXMLTest(Mock<List<EmployeeModel>> mockEmployeeModels) {
            
            mockEmployeeModels.Object.Add(new EmployeeModel { EmployeeId = 1, FirstName = "Tom", LastName = "Bin" });
            mockEmployeeModels.Object.Add(new EmployeeModel { EmployeeId = 2, FirstName = "Joy", LastName = "Russ" });

            var sut = XmlUtility.WriteXML(mockEmployeeModels.Object);
            Assert.True(sut);
        }

        [Theory, AutoMoqData]
        public void ReadXMLTest(Mock<List<EmployeeModel>> mockEmployeeModels)
        {

            mockEmployeeModels.Object.Add(new EmployeeModel { EmployeeId = 3, FirstName = "Tom", LastName = "Bin" });
            mockEmployeeModels.Object.Add(new EmployeeModel { EmployeeId = 2, FirstName = "Joy", LastName = "Russ" });

            var sut = XmlUtility.WriteXML(mockEmployeeModels.Object);

            var result = XmlUtility.ReadXML<EmployeeModel>();
            Assert.NotNull(result);
        }

        [Fact]
        public void ReadXMLTest_FileNotExist()
        {
            var result = XmlUtility.ReadXML<EmployeeModel>();
            Assert.Empty(result);
        }
    }
}
