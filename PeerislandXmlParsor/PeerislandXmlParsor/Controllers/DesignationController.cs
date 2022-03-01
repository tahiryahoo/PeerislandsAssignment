using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeerislandXmlParsor.Controllers.Exceptions;
using PeerislandXmlParsor.Models;
using PeerislandXmlParsor.Services;

namespace PeerislandXmlParsor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IEmployeeDesignationService _employeeDesignationService;
        public DesignationController(IEmployeeDesignationService employeeDesignationService)
        {
            _employeeDesignationService = employeeDesignationService ?? throw new ArgumentNullException(nameof(employeeDesignationService));
        }

        /// <summary>
        /// Get all Employees exist in xml file
        /// </summary>
        /// <returns>All Employees</returns>
        [HttpGet("Employees")]
        [ProducesResponseType(typeof(List<EmployeeDesignationModel>), StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            try
            {
                var result = _employeeDesignationService.GetEmployees();

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
        [ProducesResponseType(typeof(EmployeeDesignationModel), StatusCodes.Status200OK)]
        public IActionResult GetEmployee([FromRoute] int employeeId)
        {
            try
            {
                var result = _employeeDesignationService.GetEmployee(employeeId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Add Employee Designation
        /// </summary>
        /// <param name="employeeDesignationModel"></param>
        /// <returns> Add status</returns>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult AddEmployee([FromBody] EmployeeDesignationModel employeeDesignationModel) 
        {
            try
            {
                var result = _employeeDesignationService.AddEmployee(employeeDesignationModel);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Delete Employee Designation
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Delete status</returns>
        [HttpDelete("Delete/{employeeId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {
            try
            {
                var result = _employeeDesignationService.DeleteEmployee(employeeId);

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
