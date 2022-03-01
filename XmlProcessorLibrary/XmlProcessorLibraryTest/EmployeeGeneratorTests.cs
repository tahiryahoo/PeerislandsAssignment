using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using XmlProcessorLibrary;
using XmlProcessorLibrary.Models;
using XmlProcessorLibrary.Repositories;
using Xunit;

namespace XmlProcessorLibraryTest
{
    public class EmployeeGeneratorTests
    {
        [Fact]
        public void ConstructorValidatesParams()
        {
            Assert.Throws<ArgumentNullException>(() => new EmployeeGenerator(null));
        }

        [Theory, AutoMoqData]
        public void AddEmployeeTest(Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {
            //Arrange
            mockEmployeeRepository.Setup(rep => rep.AddEmployee(It.IsAny<EmployeeModel>())).Returns(true);
            mockEmployeeModel.Object.EmployeeId = 1;
            mockEmployeeModel.Object.FirstName = "Tom";
            mockEmployeeModel.Object.LastName = "Bin" ;

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Act
            var result = sut.AddEmployee(mockEmployeeModel.Object);

            //Assert
            Assert.True(result);
        }

        [Theory, AutoMoqData]
        public void AddEmployeeTest_Exception(Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {
            //Arrange
            mockEmployeeRepository.Setup(rep => rep.AddEmployee(It.IsAny<EmployeeModel>())).Throws(new FileNotFoundException());
            
            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Assert
            Assert.Throws<FileNotFoundException>(() => sut.AddEmployee(mockEmployeeModel.Object));

        }

        [Theory, AutoMoqData]
        public void DeleteEmployeeTest(Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            mockEmployeeRepository.Setup(rep => rep.DeleteEmployee<EmployeeModel>(It.IsAny<int>())).Returns(true);            

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Act
            var result = sut.DeleteEmployee<EmployeeModel>(mockEmployeeModel.Object.EmployeeId);

            //Assert
            Assert.True(result);
        }

        [Theory, AutoMoqData]
        public void DeleteEmployeeTest_Exception(Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            mockEmployeeRepository.Setup(rep => rep.DeleteEmployee<EmployeeModel>(It.IsAny<int>())).Throws(new FileNotFoundException());

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Assert
            Assert.Throws<FileNotFoundException>(()=> sut.DeleteEmployee<EmployeeModel>(mockEmployeeModel.Object.EmployeeId));

        }

        [Theory, AutoMoqData]
        public void GetEmployeesTest(Mock<List<EmployeeModel>> mockEmployeeModels, Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            mockEmployeeModels.Object.Add(mockEmployeeModel.Object);
            mockEmployeeRepository.Setup(rep => rep.GetEmployees<EmployeeModel>()).Returns(mockEmployeeModels.Object);

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Act
            var result = sut.GetEmployees<EmployeeModel>();

            //Assert
            Assert.Equal(mockEmployeeModels.Object.Count, result.Count);
        }

        [Theory, AutoMoqData]
        public void GetEmployeesTest_Exception(Mock<List<EmployeeModel>> mockEmployeeModels, Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            mockEmployeeModels.Object.Add(mockEmployeeModel.Object);
            mockEmployeeRepository.Setup(rep => rep.GetEmployees<EmployeeModel>()).Throws(new FileNotFoundException());

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Act
            Assert.Throws<FileNotFoundException>(() => sut.GetEmployees<EmployeeModel>());
        }

        [Theory, AutoMoqData]
        public void GetEmployeeTest(Mock<List<EmployeeModel>> mockEmployeeModels, Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            var employeeId = 1;
            mockEmployeeModel.Object.EmployeeId = employeeId;
            mockEmployeeModel.Object.FirstName = "ABC";
            mockEmployeeModels.Object.Add(mockEmployeeModel.Object);
            mockEmployeeRepository.Setup(rep => rep.GetEmployees<EmployeeModel>()).Returns(mockEmployeeModels.Object);

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);

            //Act
            var result = sut.GetEmployee<EmployeeModel>(employeeId);

            //Assert
            Assert.Equal(mockEmployeeModel.Object.EmployeeId, result.EmployeeId);
        }

        [Theory, AutoMoqData]
        public void GetEmployeeTest_EmployeeNotExist(Mock<List<EmployeeModel>> mockEmployeeModels, Mock<EmployeeModel> mockEmployeeModel, Mock<IEmployeeRepository> mockEmployeeRepository)
        {

            //Arrange
            var employeeId = 1;
            mockEmployeeModel.Object.EmployeeId = 2;
            mockEmployeeModel.Object.FirstName = "ABC";
            mockEmployeeModels.Object.Add(mockEmployeeModel.Object);
            mockEmployeeRepository.Setup(rep => rep.GetEmployees<EmployeeModel>()).Returns(mockEmployeeModels.Object);

            var sut = new EmployeeGenerator(mockEmployeeRepository.Object);
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.GetEmployee<EmployeeModel>(employeeId));
        }
    }
}
