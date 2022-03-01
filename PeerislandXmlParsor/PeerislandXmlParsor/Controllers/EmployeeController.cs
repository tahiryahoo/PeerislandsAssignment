using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeerislandXmlParsor.Controllers.Exceptions;
using PeerislandXmlParsor.Services;
using XmlProcessorLibrary.Models;

namespace PeerislandXmlParsor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// Get all Employees exist in xml file
        /// </summary>
        /// <returns>All Employees</returns>
        [HttpGet("Employees")]
        [ProducesResponseType(typeof(List<EmployeeModel>), StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            try
            {
                var result = _employeeService.GetEmployees();

                // Assumes that if the result is NULL, then we should return NotFound
                if (result == null)
                    return NotFound(null); 

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Get Employee by employeeId
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Employee details</returns>
        [HttpGet("{employeeId}")]
        [ProducesResponseType(typeof(EmployeeModel), StatusCodes.Status200OK)]
        public IActionResult GetEmployee([FromRoute] int employeeId)
        {
            try
            {
                var result = _employeeService.GetEmployee(employeeId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employeeModel"> New employee model</param>
        /// <returns> Add status</returns>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult AddEmployee([FromBody] EmployeeModel employeeModel)
        {
            try
            {
                var result = _employeeService.AddEmployee(employeeModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employeeId">Deleted Employee Id</param>
        /// <returns>Delete status</returns>
        [HttpDelete("Delete/{employeeId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {
            try
            {
                var result = _employeeService.DeleteEmployee(employeeId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        private IActionResult ProcessException(Exception ex)
        {
            // If there is an inner exception, use that one
            Exception exception = ex.InnerException ?? ex;

            switch (exception)
            {
                case NotFoundException _:
                    return NotFound(null);
                case BadRequestException _:
                case SerializationException _:
                    return BadRequest(ex.Message);
                default:
                    return InternalServerError(exception);
            }
        }

        /// <summary>
        /// Returns an InternalServerError containing exception information
        /// </summary>
        /// <param name="ex">Exception to return information for</param>
        /// <returns>Internal Server Error action result</returns>
        protected IActionResult InternalServerError(Exception ex)
        {
            if (Request != null)
            {
                ApiErrorDetails errorDetails = new ApiErrorDetails()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorDetails);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
