using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Origence.Helpers;
using Origence.Logic;
using Origence.Models.View;

namespace Origence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {


        private readonly ILogger<EmployeesController> _logger;
        protected IEmployeeLogic EmployeeLogic { get; set; }

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeLogic employeeLogic)
        {
            _logger = logger;
            EmployeeLogic = employeeLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return new OkObjectResult(await EmployeeLogic.GetAllEmployees());
            } catch (Exception ex)
            {
                return ExceptionsHelper.HandleException(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                return new OkObjectResult(await EmployeeLogic.FindEmployeeById(id));
            }
            catch (Exception ex)
            {
                return ExceptionsHelper.HandleException(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeVm vm)
        {
            try
            {
                return new OkObjectResult(await EmployeeLogic.AddEmployee(vm));
            }
            catch (Exception ex)
            {
                return ExceptionsHelper.HandleException(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeVm vm)
        {
            try
            {
                return new OkObjectResult(await EmployeeLogic.UpdateEmployee(id, vm));
            }
            catch (Exception ex)
            {
                return ExceptionsHelper.HandleException(ex);
            }
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> RemoveEmployee(Guid id)
        {
            try
            {
                await EmployeeLogic.RemoveEmployee(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return ExceptionsHelper.HandleException(ex);
            }
        }
    }
}
